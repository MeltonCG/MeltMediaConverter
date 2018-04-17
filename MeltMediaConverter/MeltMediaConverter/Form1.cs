using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using NReco.VideoInfo;

namespace MeltMediaConverter
{
    public partial class Form1 : Form
    {
        List<string> filesToConvert;

        int prefferedBitRate;
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnBeginScan_Click(object sender, EventArgs e)
        {
            var path = @"Z:\Tv Shows";
            filesToConvert = new List<string>();
            prefferedBitRate = 1100;
            ScanDirectory(path);
            Console.Write("test");
        }

        private void ScanDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                foreach (string f in Directory.GetFiles(directory))
                {
                    if (CheckMediaFile(f))
                        filesToConvert.Add(f);
                }

                foreach (string d in Directory.GetDirectories(directory))
                {
                    ScanDirectory(d);
                }
            }
        }

        private bool CheckMediaFile(string path)
        {
            bool isHEVC = false;
            bool isMp4 = false;
            bool isCorrectBitRate = false;
            bool isTwoWeeksOld = false;

            var ffProbe = new NReco.VideoInfo.FFProbe();
            MediaInfo videoInfo;
            try
            {
                videoInfo = ffProbe.GetMediaInfo(path);
            }
            catch (Exception ex)
            {
                return false;
            }

            if (videoInfo.Streams[0].CodecName.Contains("hevc"))
                isHEVC = true;

            if (videoInfo.FormatName.Contains("mp4"))
                isMp4 = true;

            if (File.GetCreationTime(path) < DateTime.Now.AddDays(-14))
                isTwoWeeksOld = true;

            var bitrate = (new FileInfo(path).Length * 0.008) / videoInfo.Duration.TotalSeconds;
            if (bitrate <= (prefferedBitRate + 300))
                isCorrectBitRate = true;

            if (isMp4 && isCorrectBitRate && isHEVC && isTwoWeeksOld)
                return false;
            else
                return true;
        }
    }
}
