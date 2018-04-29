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
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBeginScan
            // 
            this.btnBeginScan.Location = new System.Drawing.Point(713, 82);
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
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current Directory: ";
            // 
            // lblCurrentDirectory
            // 
            this.lblCurrentDirectory.AutoSize = true;
            this.lblCurrentDirectory.Location = new System.Drawing.Point(111, 68);
            this.lblCurrentDirectory.Name = "lblCurrentDirectory";
            this.lblCurrentDirectory.Size = new System.Drawing.Size(35, 13);
            this.lblCurrentDirectory.TabIndex = 2;
            this.lblCurrentDirectory.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Directory To Scan:";
            // 
            // lblDirectoryToScan
            // 
            this.lblDirectoryToScan.AutoSize = true;
            this.lblDirectoryToScan.Location = new System.Drawing.Point(114, 35);
            this.lblDirectoryToScan.Name = "lblDirectoryToScan";
            this.lblDirectoryToScan.Size = new System.Drawing.Size(35, 13);
            this.lblDirectoryToScan.TabIndex = 4;
            this.lblDirectoryToScan.Text = "label3";
            // 
            // btnSelectScanDirectory
            // 
            this.btnSelectScanDirectory.Location = new System.Drawing.Point(713, 35);
            this.btnSelectScanDirectory.Name = "btnSelectScanDirectory";
            this.btnSelectScanDirectory.Size = new System.Drawing.Size(75, 23);
            this.btnSelectScanDirectory.TabIndex = 5;
            this.btnSelectScanDirectory.Text = "Browse";
            this.btnSelectScanDirectory.UseVisualStyleBackColor = true;
            this.btnSelectScanDirectory.Click += new System.EventHandler(this.btnSelectScanDirectory_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(673, 154);
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
            this.listBox1.Size = new System.Drawing.Size(635, 264);
            this.listBox1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

