namespace RunMPV
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.labelURL = new System.Windows.Forms.Label();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.comboBoxFormat = new System.Windows.Forms.ComboBox();
            this.labelFormat = new System.Windows.Forms.Label();
            this.buttonRun = new System.Windows.Forms.Button();
            this.checkBoxFullscreen = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxQuality = new System.Windows.Forms.ComboBox();
            this.labelFPS = new System.Windows.Forms.Label();
            this.comboBoxFPS = new System.Windows.Forms.ComboBox();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.checkBoxUnscaled = new System.Windows.Forms.CheckBox();
            this.groupBoxAudio = new System.Windows.Forms.GroupBox();
            this.numericUpDownAudioVolume = new System.Windows.Forms.NumericUpDown();
            this.checkBoxAudioMute = new System.Windows.Forms.CheckBox();
            this.trackBarAudioVolume = new System.Windows.Forms.TrackBar();
            this.labelAudioVolume = new System.Windows.Forms.Label();
            this.groupBoxVideo = new System.Windows.Forms.GroupBox();
            this.comboBoxPlaylistMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxPreview = new System.Windows.Forms.GroupBox();
            this.textBoxConsolePreview = new System.Windows.Forms.TextBox();
            this.statusStripMain.SuspendLayout();
            this.groupBoxAudio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAudioVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAudioVolume)).BeginInit();
            this.groupBoxVideo.SuspendLayout();
            this.groupBoxPreview.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelURL
            // 
            this.labelURL.AutoSize = true;
            this.labelURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelURL.Location = new System.Drawing.Point(12, 12);
            this.labelURL.Name = "labelURL";
            this.labelURL.Size = new System.Drawing.Size(42, 20);
            this.labelURL.TabIndex = 0;
            this.labelURL.Text = "&URL";
            // 
            // textBoxURL
            // 
            this.textBoxURL.AllowDrop = true;
            this.textBoxURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxURL.Location = new System.Drawing.Point(60, 10);
            this.textBoxURL.MaxLength = 100;
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(812, 26);
            this.textBoxURL.TabIndex = 1;
            this.textBoxURL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxURL.TextChanged += new System.EventHandler(this.TextBoxURL_TextChanged);
            this.textBoxURL.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBoxURL_DragDrop);
            this.textBoxURL.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBoxURL_DragEnter);
            this.textBoxURL.Enter += new System.EventHandler(this.TextBoxURL_Enter);
            this.textBoxURL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxURL_KeyPress);
            this.textBoxURL.Leave += new System.EventHandler(this.TextBoxURL_Leave);
            // 
            // comboBoxFormat
            // 
            this.comboBoxFormat.BackColor = System.Drawing.Color.Thistle;
            this.comboBoxFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFormat.FormattingEnabled = true;
            this.comboBoxFormat.Items.AddRange(new object[] {
            "8K",
            "4K",
            "Other"});
            this.comboBoxFormat.Location = new System.Drawing.Point(10, 49);
            this.comboBoxFormat.Name = "comboBoxFormat";
            this.comboBoxFormat.Size = new System.Drawing.Size(74, 28);
            this.comboBoxFormat.TabIndex = 1;
            this.comboBoxFormat.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFormat_SelectedIndexChanged);
            // 
            // labelFormat
            // 
            this.labelFormat.AutoSize = true;
            this.labelFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFormat.Location = new System.Drawing.Point(6, 26);
            this.labelFormat.Name = "labelFormat";
            this.labelFormat.Size = new System.Drawing.Size(60, 20);
            this.labelFormat.TabIndex = 0;
            this.labelFormat.Text = "&Format";
            // 
            // buttonRun
            // 
            this.buttonRun.BackColor = System.Drawing.Color.MediumPurple;
            this.buttonRun.Enabled = false;
            this.buttonRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRun.ForeColor = System.Drawing.Color.White;
            this.buttonRun.Location = new System.Drawing.Point(0, 317);
            this.buttonRun.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(884, 51);
            this.buttonRun.TabIndex = 4;
            this.buttonRun.Text = "&Play in MPV";
            this.toolTipMain.SetToolTip(this.buttonRun, "Runs MPV with the selected settings.");
            this.buttonRun.UseVisualStyleBackColor = false;
            this.buttonRun.Click += new System.EventHandler(this.ButtonRun_Click);
            // 
            // checkBoxFullscreen
            // 
            this.checkBoxFullscreen.AutoSize = true;
            this.checkBoxFullscreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxFullscreen.Location = new System.Drawing.Point(355, 56);
            this.checkBoxFullscreen.Name = "checkBoxFullscreen";
            this.checkBoxFullscreen.Size = new System.Drawing.Size(101, 24);
            this.checkBoxFullscreen.TabIndex = 7;
            this.checkBoxFullscreen.Text = "&Fullscreen";
            this.toolTipMain.SetToolTip(this.checkBoxFullscreen, "Whether to run the video in fullscreen or not.");
            this.checkBoxFullscreen.UseVisualStyleBackColor = true;
            this.checkBoxFullscreen.CheckedChanged += new System.EventHandler(this.CheckBoxFullscreen_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(93, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "&Quality";
            // 
            // comboBoxQuality
            // 
            this.comboBoxQuality.BackColor = System.Drawing.Color.Thistle;
            this.comboBoxQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxQuality.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxQuality.FormattingEnabled = true;
            this.comboBoxQuality.Location = new System.Drawing.Point(97, 49);
            this.comboBoxQuality.Name = "comboBoxQuality";
            this.comboBoxQuality.Size = new System.Drawing.Size(72, 28);
            this.comboBoxQuality.TabIndex = 3;
            this.toolTipMain.SetToolTip(this.comboBoxQuality, "The higher the number the more pixels and more bandwidth used.");
            this.comboBoxQuality.SelectedIndexChanged += new System.EventHandler(this.ComboBoxQuality_SelectedIndexChanged);
            this.comboBoxQuality.SelectedValueChanged += new System.EventHandler(this.ComboBoxQuality_SelectedValueChanged);
            // 
            // labelFPS
            // 
            this.labelFPS.AutoSize = true;
            this.labelFPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFPS.Location = new System.Drawing.Point(177, 26);
            this.labelFPS.Name = "labelFPS";
            this.labelFPS.Size = new System.Drawing.Size(40, 20);
            this.labelFPS.TabIndex = 4;
            this.labelFPS.Text = "&FPS";
            // 
            // comboBoxFPS
            // 
            this.comboBoxFPS.BackColor = System.Drawing.Color.Thistle;
            this.comboBoxFPS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFPS.FormattingEnabled = true;
            this.comboBoxFPS.Items.AddRange(new object[] {
            "60",
            "30"});
            this.comboBoxFPS.Location = new System.Drawing.Point(181, 49);
            this.comboBoxFPS.Name = "comboBoxFPS";
            this.comboBoxFPS.Size = new System.Drawing.Size(56, 28);
            this.comboBoxFPS.TabIndex = 5;
            this.toolTipMain.SetToolTip(this.comboBoxFPS, "The framerate.");
            this.comboBoxFPS.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFPS_SelectedIndexChanged);
            // 
            // statusStripMain
            // 
            this.statusStripMain.BackColor = System.Drawing.Color.Indigo;
            this.statusStripMain.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStatus});
            this.statusStripMain.Location = new System.Drawing.Point(0, 368);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(884, 22);
            this.statusStripMain.SizingGrip = false;
            this.statusStripMain.TabIndex = 5;
            this.statusStripMain.Text = "statusStripMain";
            // 
            // toolStripStatusLabelStatus
            // 
            this.toolStripStatusLabelStatus.ForeColor = System.Drawing.Color.White;
            this.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
            this.toolStripStatusLabelStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // toolTipMain
            // 
            this.toolTipMain.AutomaticDelay = 300;
            this.toolTipMain.AutoPopDelay = 12000;
            this.toolTipMain.InitialDelay = 300;
            this.toolTipMain.ReshowDelay = 60;
            // 
            // checkBoxUnscaled
            // 
            this.checkBoxUnscaled.AutoSize = true;
            this.checkBoxUnscaled.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxUnscaled.Location = new System.Drawing.Point(254, 56);
            this.checkBoxUnscaled.Name = "checkBoxUnscaled";
            this.checkBoxUnscaled.Size = new System.Drawing.Size(95, 24);
            this.checkBoxUnscaled.TabIndex = 6;
            this.checkBoxUnscaled.Text = "&Unscaled";
            this.toolTipMain.SetToolTip(this.checkBoxUnscaled, "Whether to scale the video or not.");
            this.checkBoxUnscaled.UseVisualStyleBackColor = true;
            this.checkBoxUnscaled.CheckedChanged += new System.EventHandler(this.CheckBoxUnscaled_CheckedChanged);
            // 
            // groupBoxAudio
            // 
            this.groupBoxAudio.Controls.Add(this.numericUpDownAudioVolume);
            this.groupBoxAudio.Controls.Add(this.checkBoxAudioMute);
            this.groupBoxAudio.Controls.Add(this.trackBarAudioVolume);
            this.groupBoxAudio.Controls.Add(this.labelAudioVolume);
            this.groupBoxAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAudio.Location = new System.Drawing.Point(12, 44);
            this.groupBoxAudio.Name = "groupBoxAudio";
            this.groupBoxAudio.Size = new System.Drawing.Size(860, 74);
            this.groupBoxAudio.TabIndex = 2;
            this.groupBoxAudio.TabStop = false;
            this.groupBoxAudio.Text = "&Audio Playback";
            // 
            // numericUpDownAudioVolume
            // 
            this.numericUpDownAudioVolume.Location = new System.Drawing.Point(75, 30);
            this.numericUpDownAudioVolume.Name = "numericUpDownAudioVolume";
            this.numericUpDownAudioVolume.Size = new System.Drawing.Size(55, 26);
            this.numericUpDownAudioVolume.TabIndex = 1;
            this.numericUpDownAudioVolume.ValueChanged += new System.EventHandler(this.NumericUpDownAudioVolume_ValueChanged);
            // 
            // checkBoxAudioMute
            // 
            this.checkBoxAudioMute.AutoSize = true;
            this.checkBoxAudioMute.Location = new System.Drawing.Point(783, 30);
            this.checkBoxAudioMute.Name = "checkBoxAudioMute";
            this.checkBoxAudioMute.Size = new System.Drawing.Size(64, 24);
            this.checkBoxAudioMute.TabIndex = 3;
            this.checkBoxAudioMute.Text = "&Mute";
            this.checkBoxAudioMute.UseVisualStyleBackColor = true;
            this.checkBoxAudioMute.CheckedChanged += new System.EventHandler(this.CheckBoxAudioMute_CheckedChanged);
            // 
            // trackBarAudioVolume
            // 
            this.trackBarAudioVolume.Location = new System.Drawing.Point(136, 22);
            this.trackBarAudioVolume.Maximum = 100;
            this.trackBarAudioVolume.Name = "trackBarAudioVolume";
            this.trackBarAudioVolume.Size = new System.Drawing.Size(641, 45);
            this.trackBarAudioVolume.TabIndex = 2;
            this.trackBarAudioVolume.TickFrequency = 5;
            this.trackBarAudioVolume.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarAudioVolume.Scroll += new System.EventHandler(this.TrackBarAudioVolume_Scroll);
            // 
            // labelAudioVolume
            // 
            this.labelAudioVolume.AutoSize = true;
            this.labelAudioVolume.Location = new System.Drawing.Point(6, 32);
            this.labelAudioVolume.Name = "labelAudioVolume";
            this.labelAudioVolume.Size = new System.Drawing.Size(63, 20);
            this.labelAudioVolume.TabIndex = 0;
            this.labelAudioVolume.Text = "&Volume";
            // 
            // groupBoxVideo
            // 
            this.groupBoxVideo.Controls.Add(this.comboBoxPlaylistMode);
            this.groupBoxVideo.Controls.Add(this.label2);
            this.groupBoxVideo.Controls.Add(this.labelFormat);
            this.groupBoxVideo.Controls.Add(this.comboBoxFormat);
            this.groupBoxVideo.Controls.Add(this.checkBoxUnscaled);
            this.groupBoxVideo.Controls.Add(this.checkBoxFullscreen);
            this.groupBoxVideo.Controls.Add(this.label1);
            this.groupBoxVideo.Controls.Add(this.comboBoxFPS);
            this.groupBoxVideo.Controls.Add(this.comboBoxQuality);
            this.groupBoxVideo.Controls.Add(this.labelFPS);
            this.groupBoxVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxVideo.Location = new System.Drawing.Point(12, 124);
            this.groupBoxVideo.Name = "groupBoxVideo";
            this.groupBoxVideo.Size = new System.Drawing.Size(860, 92);
            this.groupBoxVideo.TabIndex = 3;
            this.groupBoxVideo.TabStop = false;
            this.groupBoxVideo.Text = "&Video Playback";
            // 
            // comboBoxPlaylistMode
            // 
            this.comboBoxPlaylistMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlaylistMode.FormattingEnabled = true;
            this.comboBoxPlaylistMode.Location = new System.Drawing.Point(473, 49);
            this.comboBoxPlaylistMode.Name = "comboBoxPlaylistMode";
            this.comboBoxPlaylistMode.Size = new System.Drawing.Size(97, 28);
            this.comboBoxPlaylistMode.TabIndex = 9;
            this.comboBoxPlaylistMode.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPlaylistMode_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(469, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "&Playlist Mode";
            // 
            // groupBoxPreview
            // 
            this.groupBoxPreview.Controls.Add(this.textBoxConsolePreview);
            this.groupBoxPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPreview.Location = new System.Drawing.Point(12, 222);
            this.groupBoxPreview.Name = "groupBoxPreview";
            this.groupBoxPreview.Size = new System.Drawing.Size(860, 83);
            this.groupBoxPreview.TabIndex = 6;
            this.groupBoxPreview.TabStop = false;
            this.groupBoxPreview.Text = "&Arguments Preview";
            // 
            // textBoxConsolePreview
            // 
            this.textBoxConsolePreview.BackColor = System.Drawing.Color.Black;
            this.textBoxConsolePreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxConsolePreview.ForeColor = System.Drawing.Color.White;
            this.textBoxConsolePreview.Location = new System.Drawing.Point(5, 25);
            this.textBoxConsolePreview.Multiline = true;
            this.textBoxConsolePreview.Name = "textBoxConsolePreview";
            this.textBoxConsolePreview.Size = new System.Drawing.Size(850, 53);
            this.textBoxConsolePreview.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 390);
            this.Controls.Add(this.groupBoxPreview);
            this.Controls.Add(this.groupBoxVideo);
            this.Controls.Add(this.groupBoxAudio);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.textBoxURL);
            this.Controls.Add(this.labelURL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RunMPV";
            this.Activated += new System.EventHandler(this.FormMain_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.Validated += new System.EventHandler(this.FormMain_Validated);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.groupBoxAudio.ResumeLayout(false);
            this.groupBoxAudio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAudioVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAudioVolume)).EndInit();
            this.groupBoxVideo.ResumeLayout(false);
            this.groupBoxVideo.PerformLayout();
            this.groupBoxPreview.ResumeLayout(false);
            this.groupBoxPreview.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelURL;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.ComboBox comboBoxFormat;
        private System.Windows.Forms.Label labelFormat;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.CheckBox checkBoxFullscreen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxQuality;
        private System.Windows.Forms.Label labelFPS;
        private System.Windows.Forms.ComboBox comboBoxFPS;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
        private System.Windows.Forms.ToolTip toolTipMain;
        private System.Windows.Forms.CheckBox checkBoxUnscaled;
        private System.Windows.Forms.GroupBox groupBoxAudio;
        private System.Windows.Forms.GroupBox groupBoxVideo;
        private System.Windows.Forms.Label labelAudioVolume;
        private System.Windows.Forms.TrackBar trackBarAudioVolume;
        private System.Windows.Forms.CheckBox checkBoxAudioMute;
        private System.Windows.Forms.NumericUpDown numericUpDownAudioVolume;
        private System.Windows.Forms.GroupBox groupBoxPreview;
        private System.Windows.Forms.TextBox textBoxConsolePreview;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxPlaylistMode;
    }
}

