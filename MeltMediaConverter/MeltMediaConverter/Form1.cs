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

                    var job = new ConversionJob(f, scanHelper.CheckMediaFile(f, chckHEVC.Checked, chckMp4.Checked, chckAge.Checked, chckPreffBitRate.Checked), (int) numPrefferredBitRate.Value);
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
            watch.Reset();
            watch.Start();
            var oldfile = job.Path;
            
            var pass1Command = string.Format("-y -i \"{0}\" -c:v libx265 -b:v {1}k -x265-params pass=1 -c:a aac -b:a 128k -f mp4 NUL",job.Path, job.PreferredBitRate);
            var pass2Complete = string.Format("-i \"{0}\" -c:v libx265 -b:v {1}k -x265-params pass=2 -c:a aac -b:a 128k \"{2}.mp4\"",job.Path, job.PreferredBitRate, GetNewFileName(job.Path, true));

            toolStripStatusFile.Text = Path.GetFileName(job.Path); ;

            toolStripStatusPass.Text = "Pass 1";
            ProcessConversion(pass1Command);
            
            toolStripStatusPass.Text = "Pass 2";
            ProcessConversion(pass2Complete);

            File.Delete(oldfile);
            //filesToConvert.Remove(job);
        }

        private string GetNewFileName(string path, bool withPath)
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
