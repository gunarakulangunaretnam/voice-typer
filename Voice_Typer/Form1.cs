using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NHotkey.WindowsForms;
using NHotkey;

namespace Voice_Typer
{
    public partial class Form1 : Form
    {

        string startupPath = Environment.CurrentDirectory;

        public Form1()
        {
            InitializeComponent();

            HotkeyManager.Current.AddOrReplace("Start System", Keys.Control | Keys.Alt | Keys.Q, StartHotKey);

            HotkeyManager.Current.AddOrReplace("English", Keys.Control | Keys.Alt | Keys.E, EnglishHotKey);

            HotkeyManager.Current.AddOrReplace("Tamil", Keys.Control | Keys.Alt | Keys.T, TamilHotKey);

            HotkeyManager.Current.AddOrReplace("Sinhala", Keys.Control | Keys.Alt | Keys.S, SinhalaHotKey);

        }

        private void StartHotKey(object sender, HotkeyEventArgs e)
        {
            StartBTN();
        }

        private void EnglishHotKey(object sender, HotkeyEventArgs e)
        {
            if (Running_Status == true)
            {
                English();
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(startupPath + @"\English\English.wav");
                player.Play();
            }
            else if (Running_Status == false)
            {

                System.Media.SoundPlayer player = new System.Media.SoundPlayer(startupPath + @"\Start_Stop\Please.wav");
                player.Play();

            }

        }

        private void TamilHotKey(object sender, HotkeyEventArgs e)
        {
            if (Running_Status == true) { 

                Tamil();
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(startupPath + @"\Tamil\Tamil.wav");
                player.Play();

            }
            else if (Running_Status == false)
            {

                System.Media.SoundPlayer player = new System.Media.SoundPlayer(startupPath + @"\Start_Stop\Please.wav");
                player.Play();

            }
        }


        private void SinhalaHotKey(object sender, HotkeyEventArgs e)
        {
            if (Running_Status == true)
            {
                Sinhala();
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(startupPath + @"\Sinhala\Sinhala.wav");
                player.Play();
            }
            else if(Running_Status == false) {

                System.Media.SoundPlayer player = new System.Media.SoundPlayer(startupPath + @"\Start_Stop\Please.wav");
                player.Play();

            }
        }

        bool Running_Status = false;


        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            using (StreamWriter writetext = new StreamWriter("System_Status.txt"))
            {
                writetext.WriteLine("True");

            }

            using (StreamWriter writetext = new StreamWriter("Running_Status.txt"))
            {
                writetext.WriteLine("Stopped");

            }

            using (StreamWriter writetext = new StreamWriter("Language_Status.txt"))
            {
                writetext.WriteLine("English");

            }

            english.BackColor = Color.LightBlue;


            System.Diagnostics.Process.Start("Run.bat");
        }

        public void StartBTN() {

            if (Running_Status == false)
            {

                using (StreamWriter writetext = new StreamWriter("Running_Status.txt"))
                {
                    writetext.WriteLine("Running");

                }
                Running_Status = true;

                startbtn.Text = "Stop";
                startbtn.BackColor = Color.DarkRed;

                System.Media.SoundPlayer player = new System.Media.SoundPlayer(startupPath + @"\Start_Stop\Started.wav");
                player.Play();
                English();

            }
            else if (Running_Status == true)
            {

                using (StreamWriter writetext = new StreamWriter("Running_Status.txt"))
                {
                    writetext.WriteLine("Stopped");

                }


                Running_Status = false;

                startbtn.Text = "Start";
                startbtn.BackColor = Color.Green;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(startupPath + @"\Start_Stop\Stopped.wav");
                player.Play();

            }


        }

        public void English() {

            using (StreamWriter writetext = new StreamWriter("Language_Status.txt"))
            {
                writetext.WriteLine("English");

            }

            english.BackColor = Color.LightBlue;
            tamil.BackColor = Color.Lavender;
            sinhala.BackColor = Color.Lavender;

        }

        public void Tamil() {

            using (StreamWriter writetext = new StreamWriter("Language_Status.txt"))
            {
                writetext.WriteLine("Tamil");

            }

            english.BackColor = Color.Lavender;
            tamil.BackColor = Color.LightBlue;
            sinhala.BackColor = Color.Lavender;

        }

        public void Sinhala() {

            using (StreamWriter writetext = new StreamWriter("Language_Status.txt"))
            {
                writetext.WriteLine("Sinhala");

            }

            english.BackColor = Color.Lavender;
            tamil.BackColor = Color.Lavender;
            sinhala.BackColor = Color.LightBlue;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            StartBTN();

        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (Running_Status == true)
            {
                English();
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(startupPath + @"\English\English.wav");
                player.Play();
            }
            else if (Running_Status == false)
            {

                System.Media.SoundPlayer player = new System.Media.SoundPlayer(startupPath + @"\Start_Stop\Please.wav");
                player.Play();

            }
        }

        private void tamil_Click(object sender, EventArgs e)
        {
            if (Running_Status == true)
            {

                Tamil();
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(startupPath + @"\Tamil\Tamil.wav");
                player.Play();

            }
            else if (Running_Status == false)
            {

                System.Media.SoundPlayer player = new System.Media.SoundPlayer(startupPath + @"\Start_Stop\Please.wav");
                player.Play();

            }

        }

        private void sinhala_Click(object sender, EventArgs e)
        {
            if (Running_Status == true)
            {
                Sinhala();
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(startupPath + @"\Sinhala\Sinhala.wav");
                player.Play();

            }
            else if (Running_Status == false)
            {

                System.Media.SoundPlayer player = new System.Media.SoundPlayer(startupPath + @"\Start_Stop\Please.wav");
                player.Play();

            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (StreamWriter writetext = new StreamWriter("System_Status.txt"))
            {
                writetext.WriteLine("False");

            }
        }
    }
}
