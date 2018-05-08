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
using NReco.VideoConverter;
using static MeltMediaConverter.Enums;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace MeltMediaConverter
{
    public partial class Form1 : Form
    {
        List<ConversionJob> filesToConvert;
        Stopwatch watch;

        public Form1()
        {
            InitializeComponent();
            filesToConvert = new List<ConversionJob>();
            watch = new Stopwatch();
        }

        private void BtnBeginScan_Click(object sender, EventArgs e)
        {
            var path = lblDirectoryToScan.Text;
            
            new Task(() => { ScanDirectory(path); }).Start();
        }

        private void RefreshVisibleQueue()
        {
            listBox1.Invoke(new Action(() => { listBox1.Items.Clear(); }));

            foreach (var item in filesToConvert)
            {
                listBox1.Invoke(new Action(() => { listBox1.Items.Add(item); }));
            }
        }

        private void ScanDirectory(string directory)
        {
            ScanningHelper scanHelper = new ScanningHelper();

            toolStripStatusPass.Text = "Scanning";
            lblCurrentDirectory.Invoke(new Action(() => { lblCurrentDirectory.Text = directory; }));
            if (Directory.Exists(directory))
            {
                foreach (string f in Directory.GetFiles(directory))
                {
                    toolStripStatusFile.Text = Path.GetFileName(f);

                    var job = new ConversionJob(f
                        ,scanHelper.CheckMediaFile(f, chckHEVC.Checked, chckMp4.Checked, chckAge.Checked, chckPreffBitRate.Checked, (int) numPrefferredBitRate.Value)
                        , (int) numPrefferredBitRate.Value
                        ,EContainer.MKV);
                        
                    if (job.ConversionType == EConversionTypeRequired.Remux || job.ConversionType == EConversionTypeRequired.Transcode)
                    {
                        filesToConvert.Add(job);
                    }
                }

                foreach (string d in Directory.GetDirectories(directory))
                {
                    ScanDirectory(d);
                }
            }
            toolStripStatusPass.Text = "Completed";
        }

        private void btnSelectScanDirectory_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            lblDirectoryToScan.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            foreach (var job in filesToConvert)
            {
                StartConversionJob(job);
            }
            button1.Enabled = true;
        }

        private void StartConversionJob(ConversionJob job)
        {
            ScanningHelper scanHelper = new ScanningHelper();
            var oldfile = job.Path;
            
            string pass1Command;
            string pass2Command;

            toolStripStatusFile.Text = Path.GetFileName(job.Path);

            if (job.ConversionType == EConversionTypeRequired.Transcode)
            {
                pass1Command = string.Format("-y -i \"{0}\" -c:v libx265 -b:v {1}k -x265-params pass=1 -c:a aac -b:a 128k -f mp4 NUL",job.Path, job.PreferredBitRate);
                pass2Command = string.Format("-i \"{0}\" -c:v libx265 -b:v {1}k -x265-params pass=2 -c:a aac -b:a 128k \"{2}.mp4\"",job.Path, job.PreferredBitRate, scanHelper.GetNewFileName(job.Path, true));

                toolStripStatusPass.Text = "Pass 1";
                ProcessConversion(pass1Command);
                
                toolStripStatusPass.Text = "Pass 2";
                ProcessConversion(pass2Command);
            }
            else if (job.ConversionType == EConversionTypeRequired.Remux)
            {
                pass1Command = string.Format("-i \"{0}\" -codec copy \"{2}.mp4\"",job.Path, scanHelper.GetNewFileName(job.Path, true));
                
                toolStripStatusPass.Text = "Pass 1";
                ProcessConversion(pass1Command);
            }
            else
            {
                throw new Exception("Code tried to process a job with invalid conversion type");
            }

            File.Delete(oldfile);
            //filesToConvert.Remove(job);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            toolStripStatusTime.Text = watch.Elapsed.ToString();
        }

        private void ProcessConversion(string args)
        {
            Process process = new Process();
            process.StartInfo.RedirectStandardOutput = false;
            process.StartInfo.RedirectStandardError = false;
            process.StartInfo.FileName = @"ffmpeg.exe";

            process.StartInfo.Arguments = args;


            process.StartInfo.UseShellExecute = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();

            process.WaitForExit();
        }
    }
}
