using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace RunMPV
{
    public partial class FormMain : Form
    {
        //private string mpvEXE = "C:\\Portable Software\\PortableApps\\PortableApps\\MPV Video Player\\mpv.exe",
        private string mpvEXE = Application.StartupPath + "\\mpv.exe",
        urlMessage = "Please input one URL of a video or playlist..", arguments = "";

        public FormMain()
        {
            InitializeComponent();
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
            if (textBoxURL.Text == String.Empty)
            {
                textBoxURL.Text = urlMessage;
                textBoxURL.ForeColor = Color.MediumPurple;
            }
            if (Uri.IsWellFormedUriString(textBoxURL.Text, UriKind.Absolute))
            {
                textBoxURL.BackColor = Color.LightGreen;
                buttonRun.Enabled = true;
            }
            else
            {
                textBoxURL.BackColor = Color.LightSlateGray;
                buttonRun.Enabled = false;
            }
        }

        private void textBoxURL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            string fpsValue = comboBoxFPS.SelectedItem.ToString();
            string frameHeight = comboBoxQuality.Text;
            frameHeight = frameHeight.Replace("p","");
            string fullscreenStatus = checkBoxFullscreen.Checked.ToString();
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
