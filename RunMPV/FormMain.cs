using System;
using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace RunMPV
{
    public partial class FormMain : Form
    {
        private string mpvEXE = Application.StartupPath + "\\mpv.exe",
        urlMessage = "Please input one URL of a video or playlist..", arguments = "",
            fpsValue = "", frameHeight = "", fullscreenStatus = "";

        public FormMain()
        {
            InitializeComponent();
            Text = "RunMPV 1.0.2";
            // mpvEXE = "C:\\Portable Software\\PortableApps\\PortableApps\\MPV Video Player\\mpv.exe";
            // Sets the GUI elements to defaults
            comboBoxFormat.SelectedIndex = 2;
            comboBoxQuality.SelectedIndex = 1;
            comboBoxFPS.SelectedIndex = 0;
            textBoxURL.Text = urlMessage;
            textBoxURL.ForeColor = Color.MediumPurple;
            if (!File.Exists(mpvEXE))
            {
                MessageBox.Show("This app requires MPV.exe in the same folder.\n" +
                    "Please place it in the MPV folder and run it again.");
                System.Environment.Exit(1);
            }
        }

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

        private void textBoxURL_TextChanged(object sender, EventArgs e)
        {
            CheckValid();
        }

        // Responsive linked comboxes
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

        private void textBoxURL_Enter(object sender, EventArgs e)
        {
            if(textBoxURL.Text == urlMessage)
            {
                textBoxURL.Text = "";
                textBoxURL.ForeColor = Color.Black;
            }
        }

        private void textBoxURL_Leave(object sender, EventArgs e)
        {
            CheckValid();
        }

        private void textBoxURL_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Ignores spaces and control
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            fpsValue = comboBoxFPS.SelectedItem.ToString();
            frameHeight = comboBoxQuality.Text;
            frameHeight = frameHeight.Replace("p","");
            fullscreenStatus = checkBoxFullscreen.Checked.ToString();

            if(fullscreenStatus == "False")
            {
                fullscreenStatus = "no";
            }
            else
            {
                fullscreenStatus = "yes";
            }

            arguments = "--fullscreen=" + fullscreenStatus + " --ytdl-format=bestvideo[height<=?" + 
                frameHeight + "][fps<=?" + fpsValue + "][vcodec!=?vp9]+bestaudio/best " + textBoxURL.Text;
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