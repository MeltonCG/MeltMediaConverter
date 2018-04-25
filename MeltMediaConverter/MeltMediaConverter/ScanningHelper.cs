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

        

        public EConversionTypeRequired CheckMediaFile(string path, bool checkHEVC, bool checkMP4, bool checkTwoWeeks, bool checkBitRate)
        {
            bool isHEVC = false;
            bool isMp4 = false;
            bool isCorrectBitRate = false;
            bool isTwoWeeksOld = false;

            List<MediaCheck> checksCompleted = new List<MediaCheck>();

            var ffProbe = new FFProbe();
            MediaInfo videoInfo;
            try
            {
                videoInfo = ffProbe.GetMediaInfo(path);
            }
            catch (Exception ex)
            {
                return EConversionTypeRequired.NoConversionRequired;
            }

            if (checkHEVC)
                checksCompleted.Add(PerformMediaCheck(EMediaCheckType.Codec, videoInfo, path));

            if (checkMP4)
                checksCompleted.Add(PerformMediaCheck(EMediaCheckType.Container, videoInfo, path));

            if (checkTwoWeeks)
                checksCompleted.Add(PerformMediaCheck(EMediaCheckType.Age, videoInfo, path));

            if (checkBitRate)
                checksCompleted.Add(PerformMediaCheck(EMediaCheckType.BitRate, videoInfo, path));

            if (checksCompleted.All(x => x.Result == false))
                return EConversionTypeRequired.NoConversionRequired;
            else if (checksCompleted.Contains()
                return EConversionTypeRequired.Remux;
            else
                return EConversionTypeRequired.Transcode;
        }

        private MediaCheck PerformMediaCheck(EMediaCheckType checkType, MediaInfo videoInfo, string path)
        {
            MediaCheck result = new MediaCheck();

            switch (checkType)
            {
                case EMediaCheckType.Container:
                    result.Result = videoInfo.FormatName.Contains("mp4");
                    break;
                case EMediaCheckType.Codec:
                    result.Result = videoInfo.Streams[0].CodecName.Contains("hevc");
                    break;
                case EMediaCheckType.BitRate:
                    result.Result = ((new FileInfo(path).Length * 0.008) / videoInfo.Duration.TotalSeconds) <= (1100 + 300);
                    break;
                case EMediaCheckType.Age:
                    result.Result = File.GetCreationTime(path) < DateTime.Now.AddDays(-14);
                    break;
                default:
                    break;
            }

            return result;
        }  
          

    }
}
