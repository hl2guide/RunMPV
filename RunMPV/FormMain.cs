/*
 * REPO: https://github.com/hl2guide/RunMPV
 * VERSION: 1.0.6
 * AUTHOR: hl2guide
 * LICENSE: MIT
 * CODE CLEAN UP: CODEMAID (VISUAL STUDIO EXTENSION)
 */

/*  TODO:
 *  --title=<string>
 *  --screen=0-32
 * */

/*
 * 1.1 Changes:
 * - Code cleanup and standardization
 * - Increased tooltip display period
 * - Added audio volume (value, trackbar and mute checkbox controls)
 * - Added playlist mode
 * - Improved UI layout
 * - Added Arguments Preview
 *
 * 1.0.5 Changes:
 * - Window's titlebar shows status
 * - Improved message boxes
 * - Added suitable exception catching (error handling)
 * - Changed status strip style and font size
 * - Improved code to use constants for message strings
 *
 * 1.0.4 Changes:
 * - Added a status bar
 * - Increased font size to 12pt
 * - Added tooltips where relevant
 * - Changed layout of controls
 * - Added a checkbox for an unscaled video option
 * - Added filesize check for MPV.exe
 *
 * 1.0.3 Changes:
 * - The Window now accepts drag and drop events for valid URLs
 * - The URL TextBox now accepts drag and drop events for valid URLs
 * - Limited the URL TextBox to 50 characters
 * - Added user settings for application, retained using RunMPV.exe.config
 *
 * 1.0.2 Changes:
 * - Window maximize function removed
 *
 * 1.0.1 Changes:
 * - UI elements focus
 * - UI colourization
 * - Window border type
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace RunMPV
{
    public partial class FormMain : Form
    {
        // Sets readonly variables
        private readonly string mpvEXE = Application.StartupPath + "\\mpv.exe",
                urlMessage = "Please input one URL of a video or playlist..",
                programName = "RunMPV",
                programVersion = "1.1";

        // Sets basic variables
        private string arguments = "", // argumentsPreview = "",
            fpsValue = "", frameHeight = "",
            fullscreenStatus = "", unscaledStatus = "",
            videoPlaylistMode = "", playlistArguments = "";

        private long detectedMPVFileSize = 0;

        private int //currentNumberOfScreens = 0,
            audioVolume = 0;

        // Constants
        private const string messageToolStripIdle = "Idle - Waiting for a URL",
            messageValidURLDetected = "Valid URL Detected",
            messageAwaitingValidURL = "Awaiting Valid URL",
            messageDragDropAccepted = "Drag-and-Drop Detected",
            messageSavingSettings = "Saving Settings",
            messageInputIgnored = "Input Ignored",
            messageLaunching = "MPV Launching",
            // messageStarted = "MPV Started",
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
            messageBoxMPVFailedMPVLaunchText = "Failed to launch MPV with settings, " +
                    "please check permissions.",
            messageToolStripReady = "Ready - The URL is valid, press the green button to play it",
            messageToolStripIdleForValidURL = "Idle - Please enter a valid URL " +
                    "(no space characters and well-formed)",
            messageToolStripReadyURLAcceptedDragDrop = "Ready - The URL drag-and-drop has been accepted",
            messageToolStripInputIgnored = "Input Ignored - Space characters are ignored",
            messageToolStripMPVLaunching = "Launching - MPV is launching and buffering the video, " +
                    "it should appear within 15 seconds",
            messageToolStripMPVStarted = "Started - The video should have appeared",
            messageTextBoxURLToolTip = "Please enter the link to the video or playlist.";

        // Main Constructor
        public FormMain()
        {
            InitializeComponent();
            PopulatePlaylistModeDropDown();
            // NOTE: Disabled for release
            //mpvEXE = "D:\\Portable Software\\PortableApps\\PortableApps\\MPV Video Player\\mpv.exe";
            // Sets the GUI elements to defaults
            Text = programName + " " + programVersion;
            // textBoxURL.Text = urlMessage;
            toolStripStatusLabelStatus.Text = messageToolStripIdle;
            textBoxURL.ForeColor = Color.MediumPurple;
            //comboBoxFormat.SelectedIndex = 2;
            //comboBoxQuality.SelectedIndex = 1;
            //comboBoxFPS.SelectedIndex = 0;
            toolTipMain.SetToolTip(textBoxURL, messageTextBoxURLToolTip);
            
            // TODO: Add screen detection
            // currentNumberOfScreens = GetCountOfScreens();

            // Loads Application Settings
            try
            {
                LoadApplicationSettings();
                // textBoxConsolePreview.Text = generateArguments();
                //changeFontIfAvailable();
            }
            catch (Exception)
            {
                MessageBox.Show(messageBoxApplicationSettingsText,
                    messageBoxApplicationSettingsTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(1);
            }

            // Check if MPV.exe was detected
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

        private void PopulatePlaylistModeDropDown()
        {
            ArrayList playlistItems = new ArrayList
                {
                    "Normal",
                    "Reversed",
                    "Random"
                };
            comboBoxPlaylistMode.DataSource = playlistItems;
            comboBoxPlaylistMode.SelectedIndex = 0;
            textBoxConsolePreview.Text = GenerateArguments();
        }

        // Gets the number of screens the device has
        // TODO: Next Version
        /*private int GetCountOfScreens()
        {
            int countScreens = 0;
            foreach (var screen in Screen.AllScreens)
            {
                countScreens++;
            }
            return countScreens;
        }*/

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
                buttonRun.ForeColor = Color.White;
                buttonRun.BackColor = Color.DarkGreen;
                buttonRun.Enabled = true;
                buttonRun.Focus();
                toolStripStatusLabelStatus.Text = messageToolStripReady;
                Text = programName + " " + programVersion + " - " + messageValidURLDetected;
                // TODO: Fix the empty string response
                // toolTipMain.SetToolTip(textBoxURL, "Title: " +  GetVideoTitle(textBoxURL.Text));
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

        public static string GetVideoTitle(string url)
        {
            if (url.Contains("https://www.youtube.com/watch?v="))
            {
                var api = $"http://youtube.com/get_video_info?video_id={GetArgs(url, "v", '?')}";
                return GetArgs(new WebClient().DownloadString(api), "title", '&');
            }
            else
            {
                return "aa";
            }
        }

        private static string GetArgs(string args, string key, char query)
        {
            var iqs = args.IndexOf(query);
            return iqs == -1
                ? string.Empty
                : HttpUtility.ParseQueryString(iqs < args.Length - 1
                    ? args.Substring(iqs + 1) : string.Empty)[key];
        }

        private string GenerateArguments()
        {
            try
            {
                // TODO: FIX
                /*if(comboBoxFPS.SelectedValue != null && comboBoxFPS.SelectedIndex != -1)
                {
                    fpsValue = comboBoxFPS.SelectedValue.ToString();
                }
                else
                {
                    fpsValue = comboBoxFPS.SelectedItem.ToString();
                    if(comboBoxFPS.SelectedIndex >= 0)
                    {
                        MessageBox.Show(comboBoxFPS.SelectedItem.ToString());
                    }
                }*/

                if (comboBoxFPS.SelectedIndex >= 0)
                {
                    fpsValue = comboBoxFPS.SelectedItem.ToString();
                }

                fullscreenStatus = checkBoxFullscreen.Checked.ToString();
                unscaledStatus = checkBoxUnscaled.Checked.ToString();
                frameHeight = comboBoxQuality.Text;
                frameHeight = frameHeight.Replace("p", "");

                videoPlaylistMode = comboBoxPlaylistMode.SelectedItem.ToString();

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

                if(videoPlaylistMode == "Reversed")
                {
                    playlistArguments = "--ytdl-raw-options=playlist-reverse=";
                }
                else if(videoPlaylistMode == "Random")
                {
                    playlistArguments = "--ytdl-raw-options=playlist-random=";
                }
                else
                {
                    videoPlaylistMode = "Standard";
                    playlistArguments = "";
                }

                /*argumentsPreview =
                    "--volume=" + audioVolume +
                    " --ytdl-format=bestvideo[height<=?" +
                    frameHeight + "][fps<=?" + fpsValue +
                    "][vcodec!=?vp9]+bestaudio/best " +
                    " --video-unscaled=" + unscaledStatus +
                    " --fullscreen=" + fullscreenStatus +
                    " " + playlistArguments +
                    textBoxURL.Text;*/

                arguments =
                    "--volume=" + audioVolume +
                    " --ytdl-format=bestvideo[height<=?" +
                    frameHeight + "][fps<=?" + fpsValue +
                    "][vcodec!=?vp9]+bestaudio/best" +
                    " --video-unscaled=" + unscaledStatus +
                    " --fullscreen=" + fullscreenStatus +
                    " " + playlistArguments;

                //argumentsPreview = argumentsPreview.Trim();
                arguments = arguments.Trim();
                // MessageBox.Show(arguments);
            }
            catch (Exception)
            {
                MessageBox.Show(messageBoxMPVFailedMPVLaunchText,
                    messageBoxMPVFailedMPVLaunchTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return arguments;
            }
            return arguments;
        }

        private void ComboBoxPlaylistMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            videoPlaylistMode = comboBoxPlaylistMode.SelectedItem.ToString();
            textBoxConsolePreview.Text = GenerateArguments();
        }

        private void ComboBoxQuality_SelectedValueChanged(object sender, EventArgs e)
        {
            // textBoxConsolePreview.Text = generateArguments();
        }

        private void ComboBoxQuality_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxConsolePreview.Text = GenerateArguments();
        }

        private void ComboBoxFPS_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxConsolePreview.Text = GenerateArguments();
        }

        private void CheckBoxFullscreen_CheckedChanged(object sender, EventArgs e)
        {
            textBoxConsolePreview.Text = GenerateArguments();
        }

        private void CheckBoxUnscaled_CheckedChanged(object sender, EventArgs e)
        {
            textBoxConsolePreview.Text = GenerateArguments();
        }

        private void CheckBoxAudioMute_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAudioMute.Checked == true)
            {
                numericUpDownAudioVolume.Value = 0;
            }

            if (numericUpDownAudioVolume.Value == 0 && checkBoxAudioMute.Checked == false)
            {
                numericUpDownAudioVolume.Value = 50;
            }
        }

        private void TrackBarAudioVolume_Scroll(object sender, EventArgs e)
        {
            numericUpDownAudioVolume.Value = trackBarAudioVolume.Value;
            audioVolume = (int)numericUpDownAudioVolume.Value;
            textBoxConsolePreview.Text = GenerateArguments();
            if (audioVolume < 1)
            {
                checkBoxAudioMute.Checked = true;
            }
            else
            {
                checkBoxAudioMute.Checked = false;
            }
        }

        private void NumericUpDownAudioVolume_ValueChanged(object sender, EventArgs e)
        {
            trackBarAudioVolume.Value = (int)numericUpDownAudioVolume.Value;
            audioVolume = (int)numericUpDownAudioVolume.Value;
            textBoxConsolePreview.Text = GenerateArguments();
            if (audioVolume >= 1)
            {
                checkBoxAudioMute.Checked = false;
            }
            else
            {
                checkBoxAudioMute.Checked = true;
            }
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            //textBoxConsolePreview.Text = generateArguments();
        }

        private void FormMain_Validated(object sender, EventArgs e)
        {
            //textBoxConsolePreview.Text = generateArguments();
        }

        // Event for the text changed for the URL textbox
        private void TextBoxURL_TextChanged(object sender, EventArgs e)
        {
            CheckValid();
        }

        // Event for the drag drop for the URL textbox
        private void TextBoxURL_DragDrop(object sender, DragEventArgs e)
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
        private void TextBoxURL_DragEnter(object sender, DragEventArgs e)
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

        // Loads in user settings to GUI
        private void LoadApplicationSettings()
        {
            numericUpDownAudioVolume.Value = Properties.Settings.Default.Volume;
            comboBoxFormat.SelectedItem = Properties.Settings.Default.Format;
            comboBoxFPS.SelectedItem = Properties.Settings.Default.FPS;
            comboBoxQuality.SelectedItem = Properties.Settings.Default.Quality;
            checkBoxFullscreen.Checked = Properties.Settings.Default.Fullscreen;
            checkBoxUnscaled.Checked = Properties.Settings.Default.Unscaled;
            comboBoxPlaylistMode.SelectedItem = Properties.Settings.Default.PlaylistMode;
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
            Properties.Settings.Default.Volume = (int)numericUpDownAudioVolume.Value;
            Properties.Settings.Default.PlaylistMode = comboBoxPlaylistMode.SelectedItem.ToString();
            // =======================================

            // Saves all settings to RunMPV.exe.config
            Properties.Settings.Default.Save();
        }

        // Responsive linked comboxes
        // Event for the selected index change for the Format combobox
        private void ComboBoxFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFormat.SelectedItem.ToString() == "8K")
            {
                ArrayList qualityItems = new ArrayList
                {
                    "4320p"
                };
                comboBoxQuality.DataSource = qualityItems;
            }
            else if (comboBoxFormat.SelectedItem.ToString() == "4K")
            {
                ArrayList qualityItems = new ArrayList
                {
                    "2160p"
                };
                comboBoxQuality.DataSource = qualityItems;
            }
            else
            {
                ArrayList qualityItems = new ArrayList
                {
                    "1440p",
                    "1080p",
                    "720p",
                    "480p"
                };
                comboBoxQuality.DataSource = qualityItems;
            }

            // textBoxConsolePreview.Text = generateArguments();
        }

        // Event for entering the URL textbox
        private void TextBoxURL_Enter(object sender, EventArgs e)
        {
            if (textBoxURL.Text == urlMessage)
            {
                textBoxURL.Text = String.Empty;
                textBoxURL.ForeColor = Color.Black;
            }
        }

        // Event for leaving the URL textbox
        private void TextBoxURL_Leave(object sender, EventArgs e)
        {
            CheckValid();
        }

        // Event for a key press on the URL textbox
        private void TextBoxURL_KeyPress(object sender, KeyPressEventArgs e)
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
        private async void ButtonRun_Click(object sender, EventArgs e)
        {
            try {
                detectedMPVFileSize = new FileInfo(mpvEXE).Length;

                if (!File.Exists(mpvEXE) && detectedMPVFileSize < 9000)
                {
                    MessageBox.Show(messageBoxMPVRequiredText,
                        messageBoxMPVRequiredTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    arguments = arguments + " " + textBoxURL.Text;
                    
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