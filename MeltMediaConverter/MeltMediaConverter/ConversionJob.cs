using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MeltMediaConverter.Enums;

namespace MeltMediaConverter
{
    class ConversionJob
    {
        public ConversionJob(string path, EConversionTypeRequired conversionType, int prefferedBitRate, EContainer container)
        {
            Path = path;
            ConversionType = conversionType;
            PreferredBitRate = prefferedBitRate;
            ContainerRequired = container;
        }

        public string Path { get; set; }

        public EConversionTypeRequired ConversionType { get; set; }

        public EContainer ContainerRequired { get; set; }

        public int PreferredBitRate { get; set; }
    }
}
