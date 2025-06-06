namespace MeltMediaConverter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBeginScan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurrentDirectory = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDirectoryToScan = new System.Windows.Forms.Label();
            this.btnSelectScanDirectory = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusPass = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.chckMkv = new System.Windows.Forms.CheckBox();
            this.chckHEVC = new System.Windows.Forms.CheckBox();
            this.chckAge = new System.Windows.Forms.CheckBox();
            this.chckPreffBitRate = new System.Windows.Forms.CheckBox();
            this.numAge = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numPrefferredBitRate = new System.Windows.Forms.NumericUpDown();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrefferredBitRate)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBeginScan
            // 
            this.btnBeginScan.Location = new System.Drawing.Point(713, 121);
            this.btnBeginScan.Name = "btnBeginScan";
            this.btnBeginScan.Size = new System.Drawing.Size(75, 23);
            this.btnBeginScan.TabIndex = 0;
            this.btnBeginScan.Text = "scan";
            this.btnBeginScan.UseVisualStyleBackColor = true;
            this.btnBeginScan.Click += new System.EventHandler(this.BtnBeginScan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Directory: ";
            // 
            // lblCurrentDirectory
            // 
            this.lblCurrentDirectory.AutoSize = true;
            this.lblCurrentDirectory.Location = new System.Drawing.Point(107, 126);
            this.lblCurrentDirectory.Name = "lblCurrentDirectory";
            this.lblCurrentDirectory.Size = new System.Drawing.Size(35, 13);
            this.lblCurrentDirectory.TabIndex = 2;
            this.lblCurrentDirectory.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Directory To Scan:";
            // 
            // lblDirectoryToScan
            // 
            this.lblDirectoryToScan.AutoSize = true;
            this.lblDirectoryToScan.Location = new System.Drawing.Point(107, 103);
            this.lblDirectoryToScan.Name = "lblDirectoryToScan";
            this.lblDirectoryToScan.Size = new System.Drawing.Size(35, 13);
            this.lblDirectoryToScan.TabIndex = 4;
            this.lblDirectoryToScan.Text = "label3";
            // 
            // btnSelectScanDirectory
            // 
            this.btnSelectScanDirectory.Location = new System.Drawing.Point(713, 98);
            this.btnSelectScanDirectory.Name = "btnSelectScanDirectory";
            this.btnSelectScanDirectory.Size = new System.Drawing.Size(75, 23);
            this.btnSelectScanDirectory.TabIndex = 5;
            this.btnSelectScanDirectory.Text = "Browse";
            this.btnSelectScanDirectory.UseVisualStyleBackColor = true;
            this.btnSelectScanDirectory.Click += new System.EventHandler(this.btnSelectScanDirectory_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(682, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Convert Queue";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusTime,
            this.toolStripStatusPass,
            this.toolStripStatusFile});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusTime
            // 
            this.toolStripStatusTime.Name = "toolStripStatusTime";
            this.toolStripStatusTime.Size = new System.Drawing.Size(111, 17);
            this.toolStripStatusTime.Text = "toolStripStatusTime";
            // 
            // toolStripStatusPass
            // 
            this.toolStripStatusPass.Name = "toolStripStatusPass";
            this.toolStripStatusPass.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusPass.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusFile
            // 
            this.toolStripStatusFile.Name = "toolStripStatusFile";
            this.toolStripStatusFile.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusFile.Text = "toolStripStatusLabel3";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 154);
            this.listBox1.MultiColumn = true;
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox1.Size = new System.Drawing.Size(635, 264);
            this.listBox1.TabIndex = 8;
            // 
            // chckMkv
            // 
            this.chckMkv.AutoSize = true;
            this.chckMkv.Location = new System.Drawing.Point(13, 13);
            this.chckMkv.Name = "chckMkv";
            this.chckMkv.Size = new System.Drawing.Size(109, 17);
            this.chckMkv.TabIndex = 9;
            this.chckMkv.Text = "Check file is .mkv";
            this.chckMkv.UseVisualStyleBackColor = true;
            // 
            // chckHEVC
            // 
            this.chckHEVC.AutoSize = true;
            this.chckHEVC.Location = new System.Drawing.Point(13, 36);
            this.chckHEVC.Name = "chckHEVC";
            this.chckHEVC.Size = new System.Drawing.Size(147, 17);
            this.chckHEVC.TabIndex = 9;
            this.chckHEVC.Text = "Check file is HEVC (x265)";
            this.chckHEVC.UseVisualStyleBackColor = true;
            // 
            // chckAge
            // 
            this.chckAge.AutoSize = true;
            this.chckAge.Location = new System.Drawing.Point(195, 13);
            this.chckAge.Name = "chckAge";
            this.chckAge.Size = new System.Drawing.Size(152, 17);
            this.chckAge.TabIndex = 9;
            this.chckAge.Text = "Check if file is X weeks old";
            this.chckAge.UseVisualStyleBackColor = true;
            // 
            // chckPreffBitRate
            // 
            this.chckPreffBitRate.AutoSize = true;
            this.chckPreffBitRate.Location = new System.Drawing.Point(195, 36);
            this.chckPreffBitRate.Name = "chckPreffBitRate";
            this.chckPreffBitRate.Size = new System.Drawing.Size(174, 17);
            this.chckPreffBitRate.TabIndex = 9;
            this.chckPreffBitRate.Text = "Check if file is prefferred bit rate";
            this.chckPreffBitRate.UseVisualStyleBackColor = true;
            // 
            // numAge
            // 
            this.numAge.Location = new System.Drawing.Point(593, 13);
            this.numAge.Name = "numAge";
            this.numAge.Size = new System.Drawing.Size(54, 20);
            this.numAge.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(511, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "File Age (days)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(493, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Prefferred Bit Rate";
            // 
            // numPrefferredBitRate
            // 
            this.numPrefferredBitRate.Location = new System.Drawing.Point(593, 39);
            this.numPrefferredBitRate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPrefferredBitRate.Name = "numPrefferredBitRate";
            this.numPrefferredBitRate.Size = new System.Drawing.Size(54, 20);
            this.numPrefferredBitRate.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numPrefferredBitRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numAge);
            this.Controls.Add(this.chckPreffBitRate);
            this.Controls.Add(this.chckAge);
            this.Controls.Add(this.chckHEVC);
            this.Controls.Add(this.chckMkv);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSelectScanDirectory);
            this.Controls.Add(this.lblDirectoryToScan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCurrentDirectory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBeginScan);
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrefferredBitRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBeginScan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurrentDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDirectoryToScan;
        private System.Windows.Forms.Button btnSelectScanDirectory;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusPass;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusFile;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckBox chckMkv;
        private System.Windows.Forms.CheckBox chckHEVC;
        private System.Windows.Forms.CheckBox chckAge;
        private System.Windows.Forms.CheckBox chckPreffBitRate;
        private System.Windows.Forms.NumericUpDown numAge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numPrefferredBitRate;
    }
}

