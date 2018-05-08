using NReco.VideoInfo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MeltMediaConverter.Enums;

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
          

    }
}
