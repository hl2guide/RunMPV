/*
 * REPO: https://github.com/hl2guide/RunMPV
 * VERSION: 1.0.5
 * AUTHOR: hl2guide
 * LICENSE: MIT
 */

/*
 * 1.0.5 Fixes:
 * - Window's titlebar shows status
 * - TODO: Non-responsiveness during starting MPV process 
 * - Improved message boxes
 * - Added suitable exception catching (error handling)
 * - Changed status strip style and font size
 * - Improved code to use constants for message strings
 *
 * 1.0.4 Fixes:
 * - Added a status bar
 * - Increased font size to 12pt
 * - Added tooltips where relevant
 * - Changed layout of controls
 * - Added a checkbox for an unscaled video option
 * - Added filesize check for MPV.exe
 *
 * 1.0.3 Fixes:
 * - The Window now accepts drag and drop events for valid URLs
 * - The URL TextBox now accepts drag and drop events for valid URLs
 * - Limited the URL TextBox to 50 characters
 * - Added user settings for application, retained using RunMPV.exe.config
 *
 * 1.0.2 Fixes:
 * - Window maximize function removed
 *
 * 1.0.1 Fixes:
 * - UI elements focus
 * - UI colourization
 * - Window border type
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunMPV
{
    public partial class FormMain : Form
    {
        // Sets basic variables
        private string mpvEXE = Application.StartupPath + "\\mpv.exe",
            urlMessage = "Please input one URL of a video or playlist..",
            programName = "RunMPV", programVersion = "1.0.5",
            arguments = "", fpsValue = "", frameHeight = "",
            fullscreenStatus = "", unscaledStatus = "";

        private long detectedMPVFileSize = 0;

        // Constants
        const string messageToolStripIdle = "Idle - Waiting for URL",
            messageValidURLDetected = "Valid URL Detected",
            messageAwaitingValidURL = "Awaiting Valid URL",
            messageDragDropAccepted = "Drag-and-Drop Detected",
            messageSavingSettings = "Saving Settings",
            messageInputIgnored = "Input Ignored",
            messageLaunching = "MPV Launching",
            messageStarted = "MPV Started",
            messageCheckMPV = "Check MPV Window",
            messageBoxApplicationSettingsTitle = "Application Settings Missing",
            messageBoxApplicationSettingsText = "Failed to load application settings.\n" +
                    "The application will exit now.",
            messageBoxMPVRequiredTitle = "MPV Required",
            messageBoxMPVRequiredText = "This app requires MPV.exe in the same folder.\n" +
                    "Please place it in the MPV folder and run this app again.",
            messageBoxMPVIncorrectSizeTitle = "MPV Invalid Filesize",
            messageBoxMPVIncorrectSizeText = "MPV.exe detected but seems to be the wrong filesize.\n" +
                    "Please check that mpv.exe is at least 55MB and run this app again.",
            messageBoxMPVFailedMPVLaunchTitle = "MPV Launch Failed",
            messageBoxMPVFailedMPVLaunchText = "Failed to launch MPV with settings, please check permissions.",
            messageToolStripReady = "Ready - The URL is valid, press the green button to play it",
            messageToolStripIdleForValidURL = "Idle - Please enter a valid URL " +
                    "(no space characters and well-formed)",
            messageToolStripReadyURLAcceptedDragDrop = "Ready - The URL drag-and-drop has been accepted",
            messageToolStripInputIgnored = "Input Ignored - Space characters are ignored",
            messageToolStripMPVLaunching = "Launching - MPV is launching, the video should appear within 12 seconds",
            messageToolStripMPVStarted = "Started - The video should have appeared";

        // Main Constructor
        public FormMain()
        {
            InitializeComponent();
            Text = programName + " " + programVersion;
            // mpvEXE = "C:\\Portable Software\\PortableApps\\PortableApps\\" +
            // "MPV Video Player\\mpv.exe";
            // Sets the GUI elements to defaults
            comboBoxFormat.SelectedIndex = 2;
            comboBoxQuality.SelectedIndex = 1;
            comboBoxFPS.SelectedIndex = 0;
            textBoxURL.Text = urlMessage;
            textBoxURL.ForeColor = Color.MediumPurple;
            toolStripStatusLabelStatus.Text = messageToolStripIdle;

            // Loads Application Settings
            try
            {
                loadApplicationSettings();
                //changeFontIfAvailable();
            }
            catch (Exception)
            {
                MessageBox.Show(messageBoxApplicationSettingsText,
                    messageBoxApplicationSettingsTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(1);
            }

            if (!File.Exists(mpvEXE))
            {
                MessageBox.Show(messageBoxMPVRequiredText,
                    messageBoxMPVRequiredTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Environment.Exit(1);
            }
            else
            {
                detectedMPVFileSize = new FileInfo(mpvEXE).Length;
                if (detectedMPVFileSize < 58000000)
                {
                    MessageBox.Show(messageBoxMPVIncorrectSizeText,
                        messageBoxMPVIncorrectSizeTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    System.Environment.Exit(1);
                }
            }
        }

        // DISABLED
        /*private void changeFontIfAvailable()
        {
            string fontName = "Iosevka";
            bool isAvailable = false;
            using (var testFont = new Font(fontName, 8))
                isAvailable = fontName.Equals(testFont.Name, StringComparison.InvariantCultureIgnoreCase);
            if (isAvailable == true)
            {
                Font = new Font(fontName, 12, FontStyle.Regular);
            }
        }*/

        // Loads in user settings to GUI
        private void loadApplicationSettings()
        {
            comboBoxFormat.SelectedItem = Properties.Settings.Default.Format;
            comboBoxFPS.SelectedItem = Properties.Settings.Default.FPS;
            comboBoxQuality.SelectedItem = Properties.Settings.Default.Quality;
            checkBoxFullscreen.Checked = Properties.Settings.Default.Fullscreen;
            checkBoxUnscaled.Checked = Properties.Settings.Default.Unscaled;
        }

        // Checks whether the textBoxURL is valid or not and modifies UI elements
        private void CheckValid()
        {
            if (textBoxURL.Text == String.Empty)
            {
                //textBoxURL.Text = urlMessage;
                textBoxURL.ForeColor = Color.MediumPurple;
            }
            if (Uri.IsWellFormedUriString(textBoxURL.Text, UriKind.Absolute))
            {
                textBoxURL.BackColor = Color.LightGreen;
                buttonRun.Enabled = true;
                buttonRun.ForeColor = Color.White;
                buttonRun.BackColor = Color.DarkGreen;
                buttonRun.Focus();
                toolStripStatusLabelStatus.Text = messageToolStripReady;
                Text = programName + " " + programVersion + " - " + messageValidURLDetected;
            }
            else
            {
                string xCol = "#F6E5FA";
                Color c = System.Drawing.ColorTranslator.FromHtml(xCol);
                textBoxURL.BackColor = c;
                xCol = "#4C2057";
                c = System.Drawing.ColorTranslator.FromHtml(xCol);
                textBoxURL.ForeColor = c;
                buttonRun.BackColor = Color.LightGray;
                buttonRun.Enabled = false;
                toolStripStatusLabelStatus.Text = messageToolStripIdleForValidURL;
                Text = programName + " " + programVersion + " - " + messageAwaitingValidURL;
            }
        }

        // Event for the text changed for the URL textbox
        private void textBoxURL_TextChanged(object sender, EventArgs e)
        {
            CheckValid();
        }

        // Event for the drag drop for the URL textbox
        private void textBoxURL_DragDrop(object sender, DragEventArgs e)
        {
            string dataLink = e.Data.GetData(DataFormats.Text).ToString();
            if (Uri.IsWellFormedUriString(dataLink, UriKind.Absolute))
            {
                textBoxURL.Text = dataLink;
                toolStripStatusLabelStatus.Text = messageToolStripReadyURLAcceptedDragDrop;
                Text = programName + " " + programVersion + " - " + messageDragDropAccepted;
            }
        }

        // Event for the drag enter for URL textbox
        private void textBoxURL_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        // Event for the drag drop for the form
        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            string dataLink = e.Data.GetData(DataFormats.Text).ToString();
            if (Uri.IsWellFormedUriString(dataLink, UriKind.Absolute))
            {
                textBoxURL.Text = dataLink;
                toolStripStatusLabelStatus.Text = messageToolStripReadyURLAcceptedDragDrop;
                Text = programName + " " + programVersion + " - " + messageDragDropAccepted;
            }
        }

        // Event for the drag enter for the form
        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        // Event for closing the main form
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Text = programName + " " + programVersion + " - " + messageSavingSettings;

            // Gets settings from the GUI
            Properties.Settings.Default.Format = comboBoxFormat.SelectedItem.ToString();
            Properties.Settings.Default.FPS = comboBoxFPS.SelectedItem.ToString();
            Properties.Settings.Default.Quality = comboBoxQuality.SelectedItem.ToString();
            Properties.Settings.Default.Fullscreen = checkBoxFullscreen.Checked;
            Properties.Settings.Default.Unscaled = checkBoxUnscaled.Checked;

            // Saves all settings to RunMPV.exe.config
            Properties.Settings.Default.Save();
        }

        // Responsive linked comboxes
        // Event for the selected index change for the Format combobox
        private void comboBoxFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFormat.SelectedItem.ToString() == "8K")
            {
                ArrayList qualityItems = new ArrayList();
                qualityItems.Add("4320p");
                comboBoxQuality.DataSource = qualityItems;
            }
            else if (comboBoxFormat.SelectedItem.ToString() == "4K")
            {
                ArrayList qualityItems = new ArrayList();
                qualityItems.Add("2160p");
                comboBoxQuality.DataSource = qualityItems;
            }
            else
            {
                ArrayList qualityItems = new ArrayList();
                qualityItems.Add("1440p");
                qualityItems.Add("1080p");
                qualityItems.Add("720p");
                qualityItems.Add("480p");
                comboBoxQuality.DataSource = qualityItems;
            }
        }

        // Event for entering the URL textbox
        private void textBoxURL_Enter(object sender, EventArgs e)
        {
            if (textBoxURL.Text == urlMessage)
            {
                textBoxURL.Text = String.Empty;
                textBoxURL.ForeColor = Color.Black;
            }
        }

        // Event for leaving the URL textbox
        private void textBoxURL_Leave(object sender, EventArgs e)
        {
            CheckValid();
        }

        // Event for a key press on the URL textbox
        private void textBoxURL_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Ignores spaces and control
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                toolStripStatusLabelStatus.Text = messageToolStripInputIgnored;
                Text = programName + " " + programVersion + " - " + messageInputIgnored;
            }
        }

        // Event for a button click on the run button
        private async void buttonRun_Click(object sender, EventArgs e)
        {
            try
            {
                fpsValue = comboBoxFPS.SelectedItem.ToString();
                frameHeight = comboBoxQuality.Text;
                frameHeight = frameHeight.Replace("p", "");
                fullscreenStatus = checkBoxFullscreen.Checked.ToString();
                unscaledStatus = checkBoxUnscaled.Checked.ToString();

                if (fullscreenStatus == "False")
                {
                    fullscreenStatus = "no";
                }
                else
                {
                    fullscreenStatus = "yes";
                }

                if (unscaledStatus == "False")
                {
                    unscaledStatus = "no";
                }
                else
                {
                    unscaledStatus = "yes";
                }

                arguments = "--fullscreen=" + fullscreenStatus +
                    " --video-unscaled=" + unscaledStatus +
                    " --ytdl-format=bestvideo[height<=?" +
                    frameHeight + "][fps<=?" + fpsValue +
                    "][vcodec!=?vp9]+bestaudio/best " + textBoxURL.Text;
                // MessageBox.Show(arguments);

                detectedMPVFileSize = new FileInfo(mpvEXE).Length;

                if (!File.Exists(mpvEXE) && detectedMPVFileSize < 9000)
                {
                    MessageBox.Show(messageBoxMPVRequiredText,
                        messageBoxMPVRequiredTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Starts the MPV process with passed arguments
                    Process myProcess = new Process();
                    myProcess.StartInfo.UseShellExecute = false;
                    // You can start any process
                    myProcess.StartInfo.FileName = mpvEXE;
                    myProcess.StartInfo.CreateNoWindow = true;
                    myProcess.StartInfo.Arguments = arguments;
                    myProcess.Start();
                    toolStripStatusLabelStatus.Text = messageToolStripMPVLaunching;
                    Text = programName + " " + programVersion + " - " + messageLaunching;
                    // Waits 12 seconds
                    // Thread.Sleep(12000);
                    await Task.Delay(12000);
                    toolStripStatusLabelStatus.Text = messageToolStripMPVStarted;
                    Text = programName + " " + programVersion + " - " + messageCheckMPV;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(messageBoxMPVFailedMPVLaunchText,
                    messageBoxMPVFailedMPVLaunchTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}