/*
 * REPO: https://github.com/hl2guide/RunMPV
 * VERSION: 1.0.3
 * AUTHOR: hl2guide
 * LICENSE: MIT
 */

/*
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
using System.Windows.Forms;

namespace RunMPV
{
    public partial class FormMain : Form
    {
        // Sets basic variables
        private string mpvEXE = Application.StartupPath + "\\mpv.exe",
        urlMessage = "Please input one URL of a video or playlist..", arguments = "",
            fpsValue = "", frameHeight = "", fullscreenStatus = "";

        // Main Constructor
        public FormMain()
        {
            InitializeComponent();
            Text = "RunMPV 1.0.3";
            //mpvEXE = "C:\\Portable Software\\PortableApps\\PortableApps\\" +
                //"MPV Video Player\\mpv.exe";
            // Sets the GUI elements to defaults
            comboBoxFormat.SelectedIndex = 2;
            comboBoxQuality.SelectedIndex = 1;
            comboBoxFPS.SelectedIndex = 0;
            textBoxURL.Text = urlMessage;
            textBoxURL.ForeColor = Color.MediumPurple;
            if (!File.Exists(mpvEXE))
            {
                MessageBox.Show("This app requires MPV.exe in the same folder.\n" +
                    "Please place it in the MPV folder and run it again.",
                    "RunMPV requires mpv.exe",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
                System.Environment.Exit(1);
            }
            loadApplicationSettings();
        }

        // Loads in user settings to GUI
        private void loadApplicationSettings()
        {
            comboBoxFormat.SelectedItem = Properties.Settings.Default.Format;
            comboBoxFPS.SelectedItem = Properties.Settings.Default.FPS;
            comboBoxQuality.SelectedItem = Properties.Settings.Default.Quality;
            checkBoxFullscreen.Checked = Properties.Settings.Default.Fullscreen;
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
            // Gets settings from the GUI
            Properties.Settings.Default.Format = comboBoxFormat.SelectedItem.ToString();
            Properties.Settings.Default.FPS = comboBoxFPS.SelectedItem.ToString();
            Properties.Settings.Default.Quality = comboBoxQuality.SelectedItem.ToString();
            Properties.Settings.Default.Fullscreen = checkBoxFullscreen.Checked;
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
                textBoxURL.Text = "";
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
        }

        // Event for a button click on the run button
        private void buttonRun_Click(object sender, EventArgs e)
        {
            fpsValue = comboBoxFPS.SelectedItem.ToString();
            frameHeight = comboBoxQuality.Text;
            frameHeight = frameHeight.Replace("p", "");
            fullscreenStatus = checkBoxFullscreen.Checked.ToString();

            if (fullscreenStatus == "False")
            {
                fullscreenStatus = "no";
            }
            else
            {
                fullscreenStatus = "yes";
            }

            arguments = "--fullscreen=" + fullscreenStatus +
                " --ytdl-format=bestvideo[height<=?" +
                frameHeight + "][fps<=?" + fpsValue +
                "][vcodec!=?vp9]+bestaudio/best " + textBoxURL.Text;
            // MessageBox.Show(arguments);

            if (!File.Exists(mpvEXE))
            {
                MessageBox.Show("This app requires MPV.exe in the same folder.\n" +
                    "Please place it in the MPV folder and click the button again.");
            }
            else
            {
                // Starts the MPV process with passed arguments
                Process myProcess = new Process();
                myProcess.StartInfo.UseShellExecute = false;
                // You can start any process, HelloWorld is a do-nothing example.
                myProcess.StartInfo.FileName = mpvEXE;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.Arguments = arguments;
                myProcess.Start();
            }
        }
    }
}