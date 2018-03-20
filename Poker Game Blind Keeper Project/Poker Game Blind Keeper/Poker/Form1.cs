using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace Poker
{
    public partial class GrudithPoker : Form
    {
        int BlindTime = 0;
        int CheckTime = 0;
        int LevelTime = 0;

        SoundPlayer Gong = new SoundPlayer("..\\..\\Media\\gong.wav");          //Sound for end of Level
        Bitmap active = new Bitmap("..\\..\\Media\\active.png");                //Picture for Play/Pause Button
        Bitmap faded = new Bitmap("..\\..\\Media\\faded.JPG");                  //

        string FileLoc = "..\\..\\Media\\settings.txt";                         //Location of settings file

        ArrayList Blinds = new ArrayList();                                     //Array for Blinds : {0} - Small Blind. {1} - Big Blind, {3} - Ante.
        int Index = 0;

        string[,] BlindInputRows = new string[8, 4] { {"FirstLevel", "FirstSmall", "FirstBig", "FirstAnte"},
                                                        {"SecondLevel", "SecondSmall", "SecondBig", "SecondAnte"},
                                                        {"ThirdLevel", "ThirdSmall", "ThirdBig", "ThirdAnte"},
                                                        {"FourthLevel", "FourthSmall", "FourthBig", "FourthAnte"},
                                                        {"FifthLevel", "FifthSmall", "FifthBig", "FifthAnte"},
                                                        {"SixthLevel", "SixthSmall", "SixthBig", "SixthAnte"},
                                                        {"SeventhLevel", "SeventhSmall", "SeventhBig", "SeventhAnte"},
                                                        {"EighthLevel", "EighthSmall", "EighthBig", "EighthAnte"} };

        public GrudithPoker()
        {
            InitializeComponent();
            LoadFile();
        }

        //Function for when "Start Button" is clicked.
        private void StartButton_Click(object sender, EventArgs e)
        {
            currentBlind.Show();
            AnteDisplay.Show();
            ChangeBlinds();
            BlindTimer.Start();
            CheckTimer.Stop();
            CheckTime = 0;
            StartButton.Hide();
            PauseButton.Show();
            Edit_Blinds.Enabled = true;
        }

        //Function for the Blind Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            int minute, second;
            BlindTime = BlindTime - 1;
            minute = BlindTime / 60;
            second = BlindTime - (minute * 60);

            if(minute < 10 && second < 10)                          //Timer Display
            {
                timer.Text = "0" + minute + ":0" + second;
            }
            else if(minute < 10)
            {
                timer.Text = "0" + minute + ":" + second;
            }
            else if(second < 10)
            {
                timer.Text = minute + ":0" + second;
            }
            else
            {
                timer.Text = minute + ":" + second;
            }

            if(BlindTime == 0)                                      //Timer reaches 0
            {
                Gong.Play();
                PauseButton.Hide();
                BlindTimer.Stop();
                CheckTimer.Start();
                StartButton.Show();
                currentBlind.Hide();
                AnteDisplay.Hide();
                Edit_Blinds.Enabled = false;

                BlindTime = LevelTime;
                if (LevelTime < 600)
                {
                    timer.Text = "0" + (LevelTime / 60) + ":00";
                }
                else
                {
                    timer.Text = (LevelTime / 60) + ":00";
                }
            }
        }

        //Function for the Pause/Timer Button
        private void Pause_Click(object sender, EventArgs e)
        {
            if (BlindTimer.Enabled)
            {
                BlindTimer.Stop();
                PauseButton.Image = active;               
            }
            else
            {
                BlindTimer.Start();
                PauseButton.Image = faded;
            }
        }

        //Function for when Reset Button is clicked
        private void ResetButton_Click(object sender, EventArgs e)
        {
            BlindTimer.Stop();
            PauseButton.Image = active;

            BlindTime = Convert.ToInt32(ResetBox.Text) * 60;
            if (BlindTime < 600)
            {
                timer.Text = "0" + ResetBox.Text + ":00";
            }
            else
            {
                timer.Text = ResetBox.Text + ":00";
            }
            ResetBox.Text = "";
        }

        //Function for when reset text box is changed.
        private void ResetBox_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ResetBox.Text))                               //Not Null
            {
                ResetButton.Enabled = true;
            }
            else
            {
                ResetButton.Enabled = false;
            }
        }

        //Next Button to Manually Change Blind Level
        private void NextButton_Click(object sender, EventArgs e)
        {
            ChangeBlinds();
        }

        //Prev Button to Manually Change Blind Level
        private void PrevButton_Click(object sender, EventArgs e)
        {
            Index -= 2;
            if (Index == 0) PrevButton.Enabled = false;
            NextButton.Enabled = true;
            ChangeBlinds();        
        }

        //Reoccurring 30 reminder timer after blind timer reaches 0
        private void CheckTimer_Tick(object sender, EventArgs e)
        {
            ++CheckTime;
            if((CheckTime % 30) == 0)
            {
                Gong.Play();
            }
        }

        //Function to Change and Display the Blinds
        private void ChangeBlinds()
        {
            if (Index < Blinds.Count)
            {
                string[] current_blinds = Blinds[Index] as string[];
                currentBlind.Text = current_blinds[0] + "/" + current_blinds[1];
                AnteDisplay.Text = current_blinds[2];

                if (Index < Blinds.Count - 1)
                {
                    string[] next_blinds = Blinds[Index + 1] as string[];
                    nextBlind.Text = next_blinds[0] + "/" + next_blinds[1];
                }
                else
                {
                    nextBlind.Text = "0/0";
                    NextButton.Enabled = false;
                }

                Index++;
            }
            if (Index > 1) PrevButton.Enabled = true;
        }

        //Function to edit blinds.
        private void Edit_Blinds_Click(object sender, EventArgs e)
        {
            Blinds_Panel.Show();
            BlindTimer.Stop();
            PauseButton.Image = active;
            if (Index > 0)
            {
                Index--;
            }
        }

        //Function to set all starting inputs for game.
        private void DoneButton_Click(object sender, EventArgs e)
        {
            Blinds_Panel.Hide();
            LevelTime = (int)BlindTime_Input.Value * 60;
            BlindTime = LevelTime;
            if (LevelTime < 600)
            {
                timer.Text = "0" + BlindTime_Input.Value + ":00";
            }
            else
            {
                timer.Text = BlindTime_Input.Value + ":00";
            }
            DoneButton.Enabled = false;
            DoneButton.Hide();
            //clear txt file
            SaveBlinds();

            if (Blinds.Count > 1)
            {
                string[] temp = Blinds[0] as string[];
                currentBlind.Text = temp[0] + "/" + temp[1];
                AnteDisplay.Text = temp[2];
                temp = Blinds[1] as string[];
                nextBlind.Text = temp[0] + "/" + temp[1];
            }
            UpdateButton.Visible = true;
        }

        //Function to display the number of level rows based on changed input.
        private void LevelCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            int levels = Convert.ToInt16(LevelCount.Text);

            if (levels > 0)
            {
                DoneButton.Enabled = true;
            }

            for (int x = 0; x < 8; ++x)
            {
                Label num = this.Controls.Find(BlindInputRows[x, 0], true).FirstOrDefault() as Label;
                TextBox small = this.Controls.Find(BlindInputRows[x, 1], true).FirstOrDefault() as TextBox;
                TextBox big = this.Controls.Find(BlindInputRows[x, 2], true).FirstOrDefault() as TextBox;
                TextBox ante = this.Controls.Find(BlindInputRows[x, 3], true).FirstOrDefault() as TextBox;

                if (x < levels)                                                                             //Show Row
                {
                    num.Show();
                    small.Show();
                    big.Show();
                    ante.Show();
                }
                else
                {                                                                                           //Hide Row
                    num.Hide();
                    small.Hide();
                    small.Text = "0";
                    big.Hide();
                    big.Text = "0";
                    ante.Hide();
                    ante.Text = "0";
                }
            }
        }

        //Function to save inputed blinds into arraylist.
        private void SaveBlinds()
        {
            for(int x = 0; x < Convert.ToInt16(LevelCount.Text); ++x)
            {
                TextBox small = this.Controls.Find(BlindInputRows[x, 1], true).FirstOrDefault() as TextBox;
                TextBox big = this.Controls.Find(BlindInputRows[x, 2], true).FirstOrDefault() as TextBox;
                TextBox ante = this.Controls.Find(BlindInputRows[x, 3], true).FirstOrDefault() as TextBox;

                string[] blind_level = { small.Text, big.Text, ante.Text };

                Blinds.Add(blind_level);
            }

            if(File.Exists(FileLoc))
            {
                using (StreamWriter sw = new StreamWriter(FileLoc))
                {
                    sw.WriteLine(Blinds.Count);
                    sw.WriteLine(LevelTime / 60);
                    foreach (string[] i in Blinds)
                    {
                        sw.WriteLine(i[0]);
                        sw.WriteLine(i[1]);
                        sw.WriteLine(i[2]);
                    }
                }
            }
            else
            {
                MessageBox.Show("Error Saving to File!");
            }
        }

        //Function for when Update Button is clicked.
        //Saves new blinds and/or level time
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            Blinds.Clear();
            if (LevelTime != (BlindTime_Input.Value * 60))
            {
                LevelTime = (int)BlindTime_Input.Value * 60;
                BlindTime = LevelTime;
                if (LevelTime < 600)
                {
                    timer.Text = "0" + BlindTime_Input.Value + ":00";
                }
                else
                {
                    timer.Text = BlindTime_Input.Value + ":00";
                }               
            }
            SaveBlinds();

            string[] temp = Blinds[Index] as string[];
            currentBlind.Text = temp[0] + "/" + temp[1];
            AnteDisplay.Text = temp[2];

            if (Index < Blinds.Count - 1)
            {
                string[] next_blinds = Blinds[Index + 1] as string[];
                nextBlind.Text = next_blinds[0] + "/" + next_blinds[1];
                Index++;
            }
            else
            {
                nextBlind.Text = "0/0";
            }
            Blinds_Panel.Hide();
        }

        //Function to Load previous settings from .txt file.
        private void LoadFile()
        {
            if (File.Exists(FileLoc))                                               //Checking for File
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(FileLoc);
                line = file.ReadLine();
                if (line != null)
                {
                    LevelCount.SelectedIndex = LevelCount.FindString(line);
                    line = file.ReadLine();
                    BlindTime_Input.Value = Convert.ToInt16(line);
                    for (int x = 0; x < LevelCount.SelectedIndex + 1; ++x)
                    {
                        TextBox small = this.Controls.Find(BlindInputRows[x, 1], true).FirstOrDefault() as TextBox;
                        TextBox big = this.Controls.Find(BlindInputRows[x, 2], true).FirstOrDefault() as TextBox;
                        TextBox ante = this.Controls.Find(BlindInputRows[x, 3], true).FirstOrDefault() as TextBox;

                        line = file.ReadLine();
                        small.Text = line;
                        line = file.ReadLine();
                        big.Text = line;
                        line = file.ReadLine();
                        ante.Text = line;
                    }
                }
            }
            else
            {
                File.CreateText(FileLoc);                                           //Create New File
            }
        }
    }
}