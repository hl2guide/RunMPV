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
            this.statusStripMain.SuspendLayout();
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
            this.textBoxURL.MaxLength = 50;
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(497, 26);
            this.textBoxURL.TabIndex = 1;
            this.textBoxURL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTipMain.SetToolTip(this.textBoxURL, "Please enter the link to the video or playlist.");
            this.textBoxURL.TextChanged += new System.EventHandler(this.textBoxURL_TextChanged);
            this.textBoxURL.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxURL_DragDrop);
            this.textBoxURL.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxURL_DragEnter);
            this.textBoxURL.Enter += new System.EventHandler(this.textBoxURL_Enter);
            this.textBoxURL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxURL_KeyPress);
            this.textBoxURL.Leave += new System.EventHandler(this.textBoxURL_Leave);
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
            this.comboBoxFormat.Location = new System.Drawing.Point(16, 72);
            this.comboBoxFormat.Name = "comboBoxFormat";
            this.comboBoxFormat.Size = new System.Drawing.Size(74, 28);
            this.comboBoxFormat.TabIndex = 3;
            this.comboBoxFormat.SelectedIndexChanged += new System.EventHandler(this.comboBoxFormat_SelectedIndexChanged);
            // 
            // labelFormat
            // 
            this.labelFormat.AutoSize = true;
            this.labelFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFormat.Location = new System.Drawing.Point(12, 49);
            this.labelFormat.Name = "labelFormat";
            this.labelFormat.Size = new System.Drawing.Size(60, 20);
            this.labelFormat.TabIndex = 2;
            this.labelFormat.Text = "&Format";
            // 
            // buttonRun
            // 
            this.buttonRun.BackColor = System.Drawing.Color.MediumPurple;
            this.buttonRun.Enabled = false;
            this.buttonRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRun.ForeColor = System.Drawing.Color.White;
            this.buttonRun.Location = new System.Drawing.Point(367, 49);
            this.buttonRun.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(190, 51);
            this.buttonRun.TabIndex = 9;
            this.buttonRun.Text = "&Play in MPV";
            this.toolTipMain.SetToolTip(this.buttonRun, "Runs MPV with the selected settings.");
            this.buttonRun.UseVisualStyleBackColor = false;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // checkBoxFullscreen
            // 
            this.checkBoxFullscreen.AutoSize = true;
            this.checkBoxFullscreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxFullscreen.Location = new System.Drawing.Point(260, 53);
            this.checkBoxFullscreen.Name = "checkBoxFullscreen";
            this.checkBoxFullscreen.Size = new System.Drawing.Size(101, 24);
            this.checkBoxFullscreen.TabIndex = 8;
            this.checkBoxFullscreen.Text = "&Fullscreen";
            this.toolTipMain.SetToolTip(this.checkBoxFullscreen, "Whether to run the video in fullscreen or not.");
            this.checkBoxFullscreen.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(99, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "&Quality";
            // 
            // comboBoxQuality
            // 
            this.comboBoxQuality.BackColor = System.Drawing.Color.Thistle;
            this.comboBoxQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxQuality.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxQuality.FormattingEnabled = true;
            this.comboBoxQuality.Location = new System.Drawing.Point(103, 72);
            this.comboBoxQuality.Name = "comboBoxQuality";
            this.comboBoxQuality.Size = new System.Drawing.Size(72, 28);
            this.comboBoxQuality.TabIndex = 5;
            this.toolTipMain.SetToolTip(this.comboBoxQuality, "The higher the number the more pixels and more bandwidth used.");
            // 
            // labelFPS
            // 
            this.labelFPS.AutoSize = true;
            this.labelFPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFPS.Location = new System.Drawing.Point(183, 49);
            this.labelFPS.Name = "labelFPS";
            this.labelFPS.Size = new System.Drawing.Size(40, 20);
            this.labelFPS.TabIndex = 6;
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
            this.comboBoxFPS.Location = new System.Drawing.Point(187, 72);
            this.comboBoxFPS.Name = "comboBoxFPS";
            this.comboBoxFPS.Size = new System.Drawing.Size(56, 28);
            this.comboBoxFPS.TabIndex = 7;
            this.toolTipMain.SetToolTip(this.comboBoxFPS, "The framerate.");
            // 
            // statusStripMain
            // 
            this.statusStripMain.BackColor = System.Drawing.SystemColors.Info;
            this.statusStripMain.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStatus});
            this.statusStripMain.Location = new System.Drawing.Point(0, 116);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(570, 22);
            this.statusStripMain.SizingGrip = false;
            this.statusStripMain.TabIndex = 10;
            this.statusStripMain.Text = "statusStripMain";
            // 
            // toolStripStatusLabelStatus
            // 
            this.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
            this.toolStripStatusLabelStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // toolTipMain
            // 
            this.toolTipMain.AutomaticDelay = 300;
            // 
            // checkBoxUnscaled
            // 
            this.checkBoxUnscaled.AutoSize = true;
            this.checkBoxUnscaled.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxUnscaled.Location = new System.Drawing.Point(260, 79);
            this.checkBoxUnscaled.Name = "checkBoxUnscaled";
            this.checkBoxUnscaled.Size = new System.Drawing.Size(95, 24);
            this.checkBoxUnscaled.TabIndex = 11;
            this.checkBoxUnscaled.Text = "&Unscaled";
            this.toolTipMain.SetToolTip(this.checkBoxUnscaled, "Whether to scale the video or not.");
            this.checkBoxUnscaled.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 138);
            this.Controls.Add(this.checkBoxUnscaled);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.comboBoxFPS);
            this.Controls.Add(this.labelFPS);
            this.Controls.Add(this.comboBoxQuality);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxFullscreen);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.labelFormat);
            this.Controls.Add(this.comboBoxFormat);
            this.Controls.Add(this.textBoxURL);
            this.Controls.Add(this.labelURL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RunMPV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
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
    }
}

