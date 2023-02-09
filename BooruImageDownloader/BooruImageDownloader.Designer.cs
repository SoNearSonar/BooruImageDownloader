namespace BooruImageDownloader
{
    partial class BooruImageDownloader
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GBX_Information = new System.Windows.Forms.GroupBox();
            this.BTN_Download = new System.Windows.Forms.Button();
            this.BTN_Browse = new System.Windows.Forms.Button();
            this.CHK_IndividualDownload = new System.Windows.Forms.CheckBox();
            this.TXT_Tags = new System.Windows.Forms.TextBox();
            this.LBL_Tags = new System.Windows.Forms.Label();
            this.TXT_ID = new System.Windows.Forms.TextBox();
            this.LBL_ID = new System.Windows.Forms.Label();
            this.TXT_OutputFolder = new System.Windows.Forms.TextBox();
            this.LBL_OutputFolder = new System.Windows.Forms.Label();
            this.TXT_DownloadLimit = new System.Windows.Forms.TextBox();
            this.LBL_DownloadLimit = new System.Windows.Forms.Label();
            this.CBX_Website = new System.Windows.Forms.ComboBox();
            this.LBL_Website = new System.Windows.Forms.Label();
            this.LBL_Size = new System.Windows.Forms.Label();
            this.LBL_Progress = new System.Windows.Forms.Label();
            this.PBR_DownloadedImages = new System.Windows.Forms.ProgressBar();
            this.LBL_ImageURL = new System.Windows.Forms.Label();
            this.LBL_ImageCount = new System.Windows.Forms.Label();
            this.GBX_Preview = new System.Windows.Forms.GroupBox();
            this.PBX_Preview = new System.Windows.Forms.PictureBox();
            this.GBX_ImageScaling = new System.Windows.Forms.GroupBox();
            this.LBL_ImageMessage = new System.Windows.Forms.Label();
            this.TBR_ImageScale = new System.Windows.Forms.TrackBar();
            this.LBL_ImageScale = new System.Windows.Forms.Label();
            this.GBX_Information.SuspendLayout();
            this.GBX_Preview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Preview)).BeginInit();
            this.GBX_ImageScaling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TBR_ImageScale)).BeginInit();
            this.SuspendLayout();
            // 
            // GBX_Information
            // 
            this.GBX_Information.Controls.Add(this.BTN_Download);
            this.GBX_Information.Controls.Add(this.BTN_Browse);
            this.GBX_Information.Controls.Add(this.CHK_IndividualDownload);
            this.GBX_Information.Controls.Add(this.TXT_Tags);
            this.GBX_Information.Controls.Add(this.LBL_Tags);
            this.GBX_Information.Controls.Add(this.TXT_ID);
            this.GBX_Information.Controls.Add(this.LBL_ID);
            this.GBX_Information.Controls.Add(this.TXT_OutputFolder);
            this.GBX_Information.Controls.Add(this.LBL_OutputFolder);
            this.GBX_Information.Controls.Add(this.TXT_DownloadLimit);
            this.GBX_Information.Controls.Add(this.LBL_DownloadLimit);
            this.GBX_Information.Controls.Add(this.CBX_Website);
            this.GBX_Information.Controls.Add(this.LBL_Website);
            this.GBX_Information.Location = new System.Drawing.Point(8, 2);
            this.GBX_Information.Name = "GBX_Information";
            this.GBX_Information.Size = new System.Drawing.Size(441, 235);
            this.GBX_Information.TabIndex = 0;
            this.GBX_Information.TabStop = false;
            this.GBX_Information.Text = "Information";
            // 
            // BTN_Download
            // 
            this.BTN_Download.Location = new System.Drawing.Point(185, 197);
            this.BTN_Download.Name = "BTN_Download";
            this.BTN_Download.Size = new System.Drawing.Size(82, 23);
            this.BTN_Download.TabIndex = 13;
            this.BTN_Download.Text = "Download";
            this.BTN_Download.UseVisualStyleBackColor = true;
            this.BTN_Download.Click += new System.EventHandler(this.BTN_Download_Click);
            // 
            // BTN_Browse
            // 
            this.BTN_Browse.Location = new System.Drawing.Point(344, 127);
            this.BTN_Browse.Name = "BTN_Browse";
            this.BTN_Browse.Size = new System.Drawing.Size(82, 23);
            this.BTN_Browse.TabIndex = 10;
            this.BTN_Browse.Text = "Browse";
            this.BTN_Browse.UseVisualStyleBackColor = true;
            this.BTN_Browse.Click += new System.EventHandler(this.BTN_Browse_Click);
            // 
            // CHK_IndividualDownload
            // 
            this.CHK_IndividualDownload.AutoSize = true;
            this.CHK_IndividualDownload.Location = new System.Drawing.Point(283, 77);
            this.CHK_IndividualDownload.Name = "CHK_IndividualDownload";
            this.CHK_IndividualDownload.Size = new System.Drawing.Size(140, 19);
            this.CHK_IndividualDownload.TabIndex = 7;
            this.CHK_IndividualDownload.Text = "Individual Download?";
            this.CHK_IndividualDownload.UseVisualStyleBackColor = true;
            this.CHK_IndividualDownload.CheckedChanged += new System.EventHandler(this.CHK_IndividualDownload_CheckedChanged);
            // 
            // TXT_Tags
            // 
            this.TXT_Tags.Location = new System.Drawing.Point(109, 162);
            this.TXT_Tags.Name = "TXT_Tags";
            this.TXT_Tags.Size = new System.Drawing.Size(317, 23);
            this.TXT_Tags.TabIndex = 12;
            // 
            // LBL_Tags
            // 
            this.LBL_Tags.AutoSize = true;
            this.LBL_Tags.Location = new System.Drawing.Point(9, 165);
            this.LBL_Tags.Name = "LBL_Tags";
            this.LBL_Tags.Size = new System.Drawing.Size(33, 15);
            this.LBL_Tags.TabIndex = 11;
            this.LBL_Tags.Text = "Tags:";
            // 
            // TXT_ID
            // 
            this.TXT_ID.Enabled = false;
            this.TXT_ID.Location = new System.Drawing.Point(109, 59);
            this.TXT_ID.Name = "TXT_ID";
            this.TXT_ID.Size = new System.Drawing.Size(141, 23);
            this.TXT_ID.TabIndex = 4;
            // 
            // LBL_ID
            // 
            this.LBL_ID.AutoSize = true;
            this.LBL_ID.Location = new System.Drawing.Point(9, 60);
            this.LBL_ID.Name = "LBL_ID";
            this.LBL_ID.Size = new System.Drawing.Size(21, 15);
            this.LBL_ID.TabIndex = 3;
            this.LBL_ID.Text = "ID:";
            // 
            // TXT_OutputFolder
            // 
            this.TXT_OutputFolder.Location = new System.Drawing.Point(109, 127);
            this.TXT_OutputFolder.Name = "TXT_OutputFolder";
            this.TXT_OutputFolder.Size = new System.Drawing.Size(229, 23);
            this.TXT_OutputFolder.TabIndex = 9;
            // 
            // LBL_OutputFolder
            // 
            this.LBL_OutputFolder.AutoSize = true;
            this.LBL_OutputFolder.Location = new System.Drawing.Point(9, 131);
            this.LBL_OutputFolder.Name = "LBL_OutputFolder";
            this.LBL_OutputFolder.Size = new System.Drawing.Size(84, 15);
            this.LBL_OutputFolder.TabIndex = 8;
            this.LBL_OutputFolder.Text = "Output Folder:";
            // 
            // TXT_DownloadLimit
            // 
            this.TXT_DownloadLimit.Location = new System.Drawing.Point(109, 93);
            this.TXT_DownloadLimit.Name = "TXT_DownloadLimit";
            this.TXT_DownloadLimit.Size = new System.Drawing.Size(141, 23);
            this.TXT_DownloadLimit.TabIndex = 6;
            // 
            // LBL_DownloadLimit
            // 
            this.LBL_DownloadLimit.AutoSize = true;
            this.LBL_DownloadLimit.Location = new System.Drawing.Point(9, 96);
            this.LBL_DownloadLimit.Name = "LBL_DownloadLimit";
            this.LBL_DownloadLimit.Size = new System.Drawing.Size(94, 15);
            this.LBL_DownloadLimit.TabIndex = 5;
            this.LBL_DownloadLimit.Text = "Download Limit:";
            // 
            // CBX_Website
            // 
            this.CBX_Website.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBX_Website.FormattingEnabled = true;
            this.CBX_Website.Items.AddRange(new object[] {
            "Danbooru",
            "Gelbooru",
            "Konachan",
            "Sakugabooru",
            "Yande.re"});
            this.CBX_Website.Location = new System.Drawing.Point(109, 25);
            this.CBX_Website.Name = "CBX_Website";
            this.CBX_Website.Size = new System.Drawing.Size(141, 23);
            this.CBX_Website.TabIndex = 2;
            // 
            // LBL_Website
            // 
            this.LBL_Website.AutoSize = true;
            this.LBL_Website.Location = new System.Drawing.Point(9, 28);
            this.LBL_Website.Name = "LBL_Website";
            this.LBL_Website.Size = new System.Drawing.Size(52, 15);
            this.LBL_Website.TabIndex = 1;
            this.LBL_Website.Text = "Website:";
            // 
            // LBL_Size
            // 
            this.LBL_Size.AutoSize = true;
            this.LBL_Size.Location = new System.Drawing.Point(227, 262);
            this.LBL_Size.Name = "LBL_Size";
            this.LBL_Size.Size = new System.Drawing.Size(55, 15);
            this.LBL_Size.TabIndex = 22;
            this.LBL_Size.Text = "Size: N/A";
            // 
            // LBL_Progress
            // 
            this.LBL_Progress.AutoSize = true;
            this.LBL_Progress.Location = new System.Drawing.Point(11, 331);
            this.LBL_Progress.Name = "LBL_Progress";
            this.LBL_Progress.Size = new System.Drawing.Size(55, 15);
            this.LBL_Progress.TabIndex = 24;
            this.LBL_Progress.Text = "Progress:";
            // 
            // PBR_DownloadedImages
            // 
            this.PBR_DownloadedImages.Location = new System.Drawing.Point(111, 327);
            this.PBR_DownloadedImages.Name = "PBR_DownloadedImages";
            this.PBR_DownloadedImages.Size = new System.Drawing.Size(317, 23);
            this.PBR_DownloadedImages.TabIndex = 25;
            // 
            // LBL_ImageURL
            // 
            this.LBL_ImageURL.AutoSize = true;
            this.LBL_ImageURL.Location = new System.Drawing.Point(11, 296);
            this.LBL_ImageURL.Name = "LBL_ImageURL";
            this.LBL_ImageURL.Size = new System.Drawing.Size(92, 15);
            this.LBL_ImageURL.TabIndex = 23;
            this.LBL_ImageURL.Text = "Image URL: N/A";
            // 
            // LBL_ImageCount
            // 
            this.LBL_ImageCount.AutoSize = true;
            this.LBL_ImageCount.Location = new System.Drawing.Point(10, 262);
            this.LBL_ImageCount.Name = "LBL_ImageCount";
            this.LBL_ImageCount.Size = new System.Drawing.Size(115, 15);
            this.LBL_ImageCount.TabIndex = 21;
            this.LBL_ImageCount.Text = "Image Number: N/A";
            // 
            // GBX_Preview
            // 
            this.GBX_Preview.Controls.Add(this.LBL_Size);
            this.GBX_Preview.Controls.Add(this.LBL_Progress);
            this.GBX_Preview.Controls.Add(this.PBR_DownloadedImages);
            this.GBX_Preview.Controls.Add(this.PBX_Preview);
            this.GBX_Preview.Controls.Add(this.LBL_ImageURL);
            this.GBX_Preview.Controls.Add(this.LBL_ImageCount);
            this.GBX_Preview.Location = new System.Drawing.Point(458, 2);
            this.GBX_Preview.Name = "GBX_Preview";
            this.GBX_Preview.Size = new System.Drawing.Size(441, 365);
            this.GBX_Preview.TabIndex = 26;
            this.GBX_Preview.TabStop = false;
            this.GBX_Preview.Text = "Preview";
            // 
            // PBX_Preview
            // 
            this.PBX_Preview.Location = new System.Drawing.Point(122, 25);
            this.PBX_Preview.Name = "PBX_Preview";
            this.PBX_Preview.Size = new System.Drawing.Size(220, 220);
            this.PBX_Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBX_Preview.TabIndex = 0;
            this.PBX_Preview.TabStop = false;
            // 
            // GBX_ImageScaling
            // 
            this.GBX_ImageScaling.Controls.Add(this.LBL_ImageMessage);
            this.GBX_ImageScaling.Controls.Add(this.TBR_ImageScale);
            this.GBX_ImageScaling.Controls.Add(this.LBL_ImageScale);
            this.GBX_ImageScaling.Location = new System.Drawing.Point(8, 238);
            this.GBX_ImageScaling.Name = "GBX_ImageScaling";
            this.GBX_ImageScaling.Size = new System.Drawing.Size(441, 129);
            this.GBX_ImageScaling.TabIndex = 14;
            this.GBX_ImageScaling.TabStop = false;
            this.GBX_ImageScaling.Text = "Image Scaling";
            // 
            // LBL_ImageMessage
            // 
            this.LBL_ImageMessage.AutoSize = true;
            this.LBL_ImageMessage.Location = new System.Drawing.Point(88, 82);
            this.LBL_ImageMessage.Name = "LBL_ImageMessage";
            this.LBL_ImageMessage.Size = new System.Drawing.Size(260, 15);
            this.LBL_ImageMessage.TabIndex = 14;
            this.LBL_ImageMessage.Text = "Lower = Less Memory Use But Lower Resolution";
            // 
            // TBR_ImageScale
            // 
            this.TBR_ImageScale.LargeChange = 25;
            this.TBR_ImageScale.Location = new System.Drawing.Point(206, 35);
            this.TBR_ImageScale.Maximum = 100;
            this.TBR_ImageScale.Minimum = 1;
            this.TBR_ImageScale.Name = "TBR_ImageScale";
            this.TBR_ImageScale.Size = new System.Drawing.Size(104, 45);
            this.TBR_ImageScale.SmallChange = 10;
            this.TBR_ImageScale.TabIndex = 13;
            this.TBR_ImageScale.TickFrequency = 10;
            this.TBR_ImageScale.Value = 100;
            // 
            // LBL_ImageScale
            // 
            this.LBL_ImageScale.AutoSize = true;
            this.LBL_ImageScale.Location = new System.Drawing.Point(127, 41);
            this.LBL_ImageScale.Name = "LBL_ImageScale";
            this.LBL_ImageScale.Size = new System.Drawing.Size(73, 15);
            this.LBL_ImageScale.TabIndex = 12;
            this.LBL_ImageScale.Text = "Image Scale:";
            // 
            // BooruImageDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 375);
            this.Controls.Add(this.GBX_ImageScaling);
            this.Controls.Add(this.GBX_Preview);
            this.Controls.Add(this.GBX_Information);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(923, 414);
            this.MinimumSize = new System.Drawing.Size(923, 414);
            this.Name = "BooruImageDownloader";
            this.Text = "Booru Image Downloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BooruImageDownloader_FormClosing);
            this.Load += new System.EventHandler(this.BooruImageDownloader_Load);
            this.GBX_Information.ResumeLayout(false);
            this.GBX_Information.PerformLayout();
            this.GBX_Preview.ResumeLayout(false);
            this.GBX_Preview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_Preview)).EndInit();
            this.GBX_ImageScaling.ResumeLayout(false);
            this.GBX_ImageScaling.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TBR_ImageScale)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox GBX_Information;
        private Button BTN_Download;
        private Button BTN_Browse;
        private CheckBox CHK_IndividualDownload;
        private TextBox TXT_Tags;
        private Label LBL_Tags;
        private TextBox TXT_ID;
        private Label LBL_ID;
        private TextBox TXT_OutputFolder;
        private Label LBL_OutputFolder;
        private TextBox TXT_DownloadLimit;
        private Label LBL_DownloadLimit;
        private ComboBox CBX_Website;
        private Label LBL_Website;
        private Label LBL_Progress;
        private ProgressBar PBR_DownloadedImages;
        private Label LBL_ImageURL;
        private Label LBL_ImageCount;
        private Label LBL_Size;
        private GroupBox GBX_Preview;
        private PictureBox PBX_Preview;
        private GroupBox GBX_ImageScaling;
        private Label LBL_ImageMessage;
        private TrackBar TBR_ImageScale;
        private Label LBL_ImageScale;
    }
}