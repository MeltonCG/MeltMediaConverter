using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeltMediaConverter
{
    class Enums
    {
        public enum EConversionTypeRequired
        {
            Unknown = 0,
            NoConversionRequired = 1,
            Remux = 2,
            Transcode = 3,
        }

    }
}
