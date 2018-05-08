using NReco.VideoInfo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MeltMediaConverter.Enums;
using System.Text.RegularExpressions;


namespace MeltMediaConverter
{
    class ScanningHelper
    {

        public EConversionTypeRequired CheckMediaFile(string path, bool checkHEVC, bool checkMP4, bool checkTwoWeeks, bool checkBitRate, int preferredBitRate)
        {
            List<MediaCheck> checksCompleted = new List<MediaCheck>();

            var ffProbe = new FFProbe();
            MediaInfo videoInfo;
            try
            {
                videoInfo = ffProbe.GetMediaInfo(path);
            }
            catch
            {
                return EConversionTypeRequired.NoConversionRequired;
            }

            if (checkHEVC)
                checksCompleted.Add(PerformMediaCheck(EMediaCheckType.Codec, videoInfo, path, null));

            if (checkMP4)
                checksCompleted.Add(PerformMediaCheck(EMediaCheckType.Container, videoInfo, path, null));

            if (checkTwoWeeks)
                checksCompleted.Add(PerformMediaCheck(EMediaCheckType.Age, videoInfo, path, null));

            if (checkBitRate)
                checksCompleted.Add(PerformMediaCheck(EMediaCheckType.BitRate, videoInfo, path, preferredBitRate));

            if (checksCompleted.All(x => x.Result == true))
                return EConversionTypeRequired.NoConversionRequired;
            else if (checksCompleted.Contains((new MediaCheck() { MediaCheckType = EMediaCheckType.Container, Result = true} ))
                && checksCompleted.Where(x => x.Result == true).Count() == 1)
                return EConversionTypeRequired.Remux;
            else
                return EConversionTypeRequired.Transcode;
        }

        private MediaCheck PerformMediaCheck(EMediaCheckType checkType, MediaInfo videoInfo, string path, int? preferredBitRate)
        {
            MediaCheck result = new MediaCheck();

            switch (checkType)
            {
                case EMediaCheckType.Container:
                    result.MediaCheckType = EMediaCheckType.Container;
                    result.Result = videoInfo.FormatName.Contains("mp4");
                    break;
                case EMediaCheckType.Codec:
                    result.MediaCheckType = EMediaCheckType.Codec;
                    result.Result = videoInfo.Streams[0].CodecName.Contains("hevc");
                    break;
                case EMediaCheckType.BitRate:
                    result.MediaCheckType = EMediaCheckType.BitRate;
                    var fileBitRate = (new FileInfo(path).Length * 0.008) / videoInfo.Duration.TotalSeconds;
                    result.Result = (fileBitRate <= (preferredBitRate + 300));
                    break;
                case EMediaCheckType.Age:
                    result.MediaCheckType = EMediaCheckType.Age;
                    result.Result = File.GetCreationTime(path) < DateTime.Now.AddDays(-14);
                    break;
                default:
                    break;
            }

            return result;
        }  
          
        public string GetNewFileName(string path, bool withPath)
        {
            var directory = Path.GetDirectoryName(path);
            var oldFileName = Path.GetFileNameWithoutExtension(path);
            bool useOldName = false;

            string Standard = @"^((?<series_name>.+?)[. _-]+)?s(?<season_num>\d+)[. _-]*e(?<ep_num>\d+)(([. _-]*e|-)(?<extra_ep_num>(?!(1080|720)[pi])\d+))*[. _-]*((?<extra_info>.+?)((?<![. _-])-(?<release_group>[^-]+))?)?$";

            var regexStandard = new Regex(Standard, RegexOptions.IgnoreCase);

            Match check = regexStandard.Match(oldFileName);

            var showName = check.Groups["series_name"].Value.Replace(".", " ");
            var season = check.Groups["season_num"].Value;
            var episode = check.Groups["ep_num"].Value;
            var doubleEpisode = check.Groups["extra_ep_num"].Value;
            string quality;

            //check to see data has been picked up
            if (string.IsNullOrWhiteSpace(showName) || string.IsNullOrWhiteSpace(season) || string.IsNullOrWhiteSpace(episode))
            {
                //try second parsing type
                string Fov = @"^((?<series_name>.+?)[\[. _-]+)?(?<season_num>\d+)x(?<ep_num>\d+)(([. _-]*x|-)(?<extra_ep_num>(?!(1080|720)[pi])(?!(?<=x)264)\d+))*[\]. _-]*((?<extra_info>.+?)((?<![. _-])-(?<release_group>[^-]+))?)?$";

                var regexFov = new Regex(Fov, RegexOptions.IgnoreCase);

                Match fovCheck = regexFov.Match(oldFileName);

                showName = fovCheck.Groups["series_name"].Value.Replace(".", " ");
                season = fovCheck.Groups["season_num"].Value;
                episode = fovCheck.Groups["ep_num"].Value;
                doubleEpisode = fovCheck.Groups["extra_ep_num"].Value;

                if (string.IsNullOrWhiteSpace(showName) || string.IsNullOrWhiteSpace(season) || string.IsNullOrWhiteSpace(episode))
                    useOldName = true;
            }

            if (oldFileName.Contains("720p"))
                quality = "720p";
            else if (oldFileName.Contains("1080p"))
                quality = "1080p";
            else
                quality = "";

            string newFileName;

            if (useOldName)
                newFileName = oldFileName;
            else
            {
                newFileName = string.Format("{0}.S{1}E{2}", showName, season, episode);
               
                if (!string.IsNullOrEmpty(doubleEpisode))
                    newFileName += string.Format("E{0}", doubleEpisode);

                if (!string.IsNullOrWhiteSpace(quality))
                    newFileName += string.Format(".{0}",quality);

                newFileName += ".HEVC.MELT";
            }

            return directory + "\\" + newFileName;
        }

        public Tuple<string, string> BuildCommandStringsFromJob(ConversionJob job)
        {
            string command1 = "";
            string command2 = "";
            
            string containerShort;
            string containerLong;

            switch (job.ContainerRequired)
            {
                case EContainer.MKV:
                containerShort = "mkv";
                containerLong = "matroska";
                break;
                case EContainer.MP4:
                containerShort = "mp4";
                containerLong = "mp4";
                break;
                default:
                throw new Exception("Tried to build command string for job with invalid container type");
            }

            switch (job.ConversionType)
            {
                case EConversionTypeRequired.Transcode:
                    command1 = string.Format("-y -i \"{0}\" -c:v libx265 -b:v {1}k -x265-params pass=1 -c:a aac -b:a 128k -f {2} NUL",job.Path, job.PreferredBitRate, containerLong);
                    command2 = string.Format("-i \"{0}\" -c:v libx265 -b:v {1}k -x265-params pass=2 -c:a aac -b:a 128k \"{2}.{3}\"",job.Path, job.PreferredBitRate, GetNewFileName(job.Path, true), containerShort);
                break;
                case EConversionTypeRequired.Remux:
                    command1 = string.Format("-i \"{0}\" -codec copy \"{1}.{2}\"",job.Path, GetNewFileName(job.Path, true), containerShort);
                break;
                default:
                    throw new Exception("Tried to build command string for job with invalid conversion type");
            }
            

            return new Tuple<string, string>(command1, command2);
        }
    }
}
