using System;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Poker_Records
{
    public partial class Record_Adder : Form
    {
        string[,] GameControlRows = new string[10, 4] { {"FirstLabel_G", "FirstPosition_G", "PrizeLabel1_G", "FirstPrize_G"},
                                                        {"SecondLabel_G", "SecondPosition_G", "PrizeLabel2_G", "SecondPrize_G"},
                                                        {"ThirdLabel_G", "ThirdPosition_G", "PrizeLabel3_G", "ThirdPrize_G"},
                                                        {"FourthLabel_G", "FourthPosition_G", "PrizeLabel4_G", "FourthPrize_G"},
                                                        {"FifthLabel_G", "FifthPosition_G", "PrizeLabel5_G", "FifthPrize_G"},
                                                        {"SixthLabel_G", "SixthPosition_G", "PrizeLabel6_G", "SixthPrize_G"},
                                                        {"SeventhLabel_G", "SeventhPosition_G", "PrizeLabel7_G", "SeventhPrize_G"},
                                                        {"EighthLabel_G", "EighthPosition_G", "PrizeLabel8_G", "EighthPrize_G"},
                                                        {"NinthLabel_G", "NinthPosition_G", "PrizeLabel9_G", "NinthPrize_G"},
                                                        {"TenthLabel_G", "TenthPosition_G", "PrizeLabel10_G", "TenthPrize_G"} };

        string[,] PotentialRecords = new string[10, 2] { { "", ""}, { "", ""}, { "", ""}, { "", ""}, { "", ""},
                                                         { "", ""}, { "", ""}, { "", ""}, { "", ""}, { "", ""} };

        public Record_Adder()
        {
            InitializeComponent();

            GameDate_G.Value = DateTime.Today;                                  //Set DatePickers to Today
            GameDate_S.Value = DateTime.Today;

            GetGameCount();                                                     //AutoFill Game Number
            GetPlayers();                                                       //AutoFill Player ComboBox
        }

        //Get the Current Game Count From Database and AutoFill the Game Number Field
        private void GetGameCount()
        {
            int gameCount;

            SqlConnection conn = new SqlConnection(@"Data Source = LOU-PC\SQLEXPRESS; Initial Catalog = SampleRecords; Integrated Security = True");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT MAX (Game) FROM Records";
            cmd.Connection = conn;

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            try
            {
                reader.Read();
                gameCount = reader.GetInt16(0);
                ++gameCount;
                GameNumber_G.Text = gameCount.ToString();

            }
            catch (Exception ex)                                                 //No Games - Default to 1
            {
                GameNumber_G.Text = "1";
            }
            conn.Close();
        }

        public void GetPlayers()
        {
            string player = "";
            SqlConnection conn = new SqlConnection(@"Data Source = LOU-PC\SQLEXPRESS; Initial Catalog = SampleRecords; Integrated Security = True");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT DISTINCT player FROM Records";
            cmd.Connection = conn;

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    player = reader.GetString(0);
                    FirstPosition_G.Items.Add(player);
                    SecondPosition_G.Items.Add(player);
                    ThirdPosition_G.Items.Add(player);
                    FourthPosition_G.Items.Add(player);
                    FifthPosition_G.Items.Add(player);
                    SixthPosition_G.Items.Add(player);
                    SeventhPosition_G.Items.Add(player);
                    EighthPosition_G.Items.Add(player);
                    NinthPosition_G.Items.Add(player);
                    TenthPosition_G.Items.Add(player);
                    Player_S.Items.Add(player);
                }
            }
            catch (Exception ex) { }                                                 //No Players Found
            conn.Close();
        }

        //Function to Clear Player ComboBoxes to later update with potential new player(s).
        private void ClearPlayers()
        {
            FirstPosition_G.Items.Clear();
            SecondPosition_G.Items.Clear();
            ThirdPosition_G.Items.Clear();
            FourthPosition_G.Items.Clear();
            FifthPosition_G.Items.Clear();
            SixthPosition_G.Items.Clear();
            SeventhPosition_G.Items.Clear();
            EighthPosition_G.Items.Clear();
            NinthPosition_G.Items.Clear();
            TenthPosition_G.Items.Clear();
            Player_S.Items.Clear();
        }

        //To Gather New Record(s) for Database when Submit Button is Clicked
        private void Submit_Click(object sender, EventArgs e)
        {
            if (GameRecord.Checked == true && PlayerCount_G.Text != "" && GameNumber_G.Text != "" && BuyIn_G.Text != "")     //Game Record to Add
            {
                for (int x = 0; x < Convert.ToInt16(PlayerCount_G.Text); ++x)                                //Loop to Get all Game Values
                {
                    ComboBox playerBox = this.Controls.Find(GameControlRows[x, 1], true).FirstOrDefault() as ComboBox;
                    TextBox prizeBox = this.Controls.Find(GameControlRows[x, 3], true).FirstOrDefault() as TextBox;

                    if (playerBox.Text != "" && prizeBox.Text != "")                            //Make sure not null, add to record array
                    {
                        PotentialRecords[x, 0] = playerBox.Text;
                        PotentialRecords[x, 1] = prizeBox.Text;
                    }
                    else
                    {                                                                           //Null Found
                        MessageBox.Show("All Fields are Required");
                        break;
                    }

                    if (DuplicateFound(playerBox.Text, Convert.ToInt16(PlayerCount_G.Text)))    //Make sure no Player Duplicates
                    {
                        MessageBox.Show("Error: Duplicate Player Found - " + playerBox.Text);
                        break;
                    }

                    if (x + 1 == Convert.ToInt16(PlayerCount_G.Text))                            //All values good, add records
                    {
                        AddRecords(Convert.ToInt16(PlayerCount_G.Text), "Game");
                    }
                }
            }
            else if (SingleRecord.Checked == true)                                               //Single Record to Add
            {
                if (GameNumber_S.Text != "" && Player_S.Text != "" &&                           //Make sure not null
                    Position_S.Text != "" && Prize_S.Text != "" && BuyIn_S.Text != "")
                {
                    AddRecords(0, "Single");                                                    //All values good, add records
                }
                else
                {
                    MessageBox.Show("All Fields are Required");                                 //Null Found
                }
            }
        }

        //To Toggle Between Single Record Panel and Game Record Panel
        private void GameRecord_CheckedChanged(object sender, EventArgs e)
        {
            if (GameRecord.Checked == true)
            {
                SingleRecordPanel.Hide();
                GameRecordPanel.Show();
            }
            else
            {
                SingleRecordPanel.Show();
                GameRecordPanel.Hide();
            }
        }

        //To Display Right Number of Positions Based on Player Count Selection (Game Record)
        private void PlayerCount_G_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayRows(Convert.ToInt16(PlayerCount_G.Text), true);
        }

        //Add Record(s) to Database - Uses game size and a string specifying records type (Single or Full Game)
        private void AddRecords(int gameSize, string recordType)
        {
            DeleteGameRecords();

            SqlConnection conn = new SqlConnection(@"Data Source = LOU-PC\SQLEXPRESS; Initial Catalog = SampleRecords; Integrated Security = True");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Records (game, game_date, player, position, prize, buy_in) VALUES(@game, @game_date, @player, @position, @prize, @buy_in)";
            cmd.Connection = conn;

            cmd.Parameters.Add("@game", SqlDbType.SmallInt);                        //Insert Parameters
            cmd.Parameters.Add("@game_date", SqlDbType.Date);
            cmd.Parameters.Add("@player", SqlDbType.VarChar);
            cmd.Parameters.Add("@position", SqlDbType.SmallInt);
            cmd.Parameters.Add("@prize", SqlDbType.SmallMoney);
            cmd.Parameters.Add("@buy_in", SqlDbType.SmallMoney);

            if (recordType == "Game")                                               //Add Full Game Record
            {
                bool success = false;
                DateTime gamedate = new DateTime(GameDate_G.Value.Year, GameDate_G.Value.Month, GameDate_G.Value.Day);

                conn.Open();

                for (int x = 0; x < gameSize; ++x)                                  //Adding each record
                {
                    cmd.Parameters["@game"].Value = Convert.ToInt16(GameNumber_G.Text);
                    cmd.Parameters["@game_date"].Value = gamedate;
                    cmd.Parameters["@player"].Value = PotentialRecords[x, 0];
                    cmd.Parameters["@position"].Value = x + 1;
                    cmd.Parameters["@prize"].Value = Convert.ToDouble(PotentialRecords[x, 1]);
                    cmd.Parameters["@buy_in"].Value = Convert.ToInt16(BuyIn_G.Text);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        success = true;
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show(ex.Message);
                        success = false;
                        ClearRecordArray();
                        DeleteGameRecords();                                        //Delete Records of that Game because of unknown error
                        conn.Close();
                        break;
                    }
                }
                conn.Close();

                if (success == true)                                                //Added Successfully - Show entry
                {
                    LastRecordDisplay.Text = "(Full Game -" + DateTime.Now + ")" +
                             "  Game:" + GameNumber_G.Text +
                             "  Game Date:" + gamedate.ToShortDateString() +
                             "  Players:" + PlayerCount_G.Text +
                             "  Buy-In:" + BuyIn_G.Text;
                    LastRecordDisplay.Show();
                    DisplayRows(0, true);
                    GetGameCount();
                    ClearPlayers();
                    GetPlayers();
                    ClearRecordArray();
                }
            }
            else if(recordType == "Single")                                         //Add Single Record
            {
                DateTime gamedate = new DateTime(GameDate_S.Value.Year, GameDate_S.Value.Month, GameDate_S.Value.Day);

                cmd.Parameters["@game"].Value = Convert.ToInt16(GameNumber_S.Text);
                cmd.Parameters["@game_date"].Value = gamedate;
                cmd.Parameters["@player"].Value = Player_S.Text;
                cmd.Parameters["@position"].Value = Convert.ToInt16(Position_S.Text);
                cmd.Parameters["@prize"].Value = Convert.ToDouble(Prize_S.Text);
                cmd.Parameters["@buy_in"].Value = Convert.ToInt16(BuyIn_S.Text);

                conn.Open();

                try
                {
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    LastRecordDisplay.Text = "(Single -" + DateTime.Now + ")" +
                                             "  Game:" + GameNumber_S.Text +
                                             "  Game Date:" + new DateTime(GameDate_S.Value.Year, GameDate_S.Value.Month, GameDate_S.Value.Day).ToShortDateString() +
                                             "  Player:" + Player_S.Text +
                                             "  Position:" + Position_S.Text +
                                             "  Prize:" + Prize_S.Text +
                                             "  Buy In:" + BuyIn_S.Text;
                    LastRecordDisplay.Show();
                    ClearPlayers();
                    GetPlayers();
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Source);
                    conn.Close();
                }
            }
        }

        //To Clear the Fields in Single Record Panel
        private void ClearSingleRecord_Click(object sender, EventArgs e)
        {
            GameNumber_S.Text = "";
            Player_S.Text = "";
            Position_S.Text = "";
            BuyIn_S.Text = "";
            Prize_S.ResetText();
            GameDate_S.Value = DateTime.Now;
        }

        //To Check for Duplicate Player Name Before Attempting to Add Game Records (Full Game Record)
        private bool DuplicateFound(string name, int gameCount)
        {
            int count = 0;

            for(int x = 0; x < gameCount; ++x)
            {
                if(name == PotentialRecords[x, 0])                          //Player Name Found in Array
                {
                    ++count;
                    if (count > 1)
                    {
                        ClearRecordArray();
                        return true;
                    }
                }
            }
            return false;
        }

        //To clear PotentialRecords Array (Full Game Record)
        private void ClearRecordArray()
        {
            for(int x = 0; x < 10; ++x)
            {
                PotentialRecords[x, 0] = "";
                PotentialRecords[x, 1] = "";
            }
        }

        //AutoFill Form with Records or Corresponding Game Number to Edit Records (Full Game Record)
        private void GameNumber_G_TextChanged(object sender, EventArgs e)
        {
            if (GameNumber_G.Text != "")
            {
                SqlConnection conn = new SqlConnection(@"Data Source = LOU-PC\SQLEXPRESS; Initial Catalog = SampleRecords; Integrated Security = True");
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Records WHERE (Game)=(@game) ORDER BY (position) ASC";
                cmd.Parameters.AddWithValue("@game", Convert.ToInt16(GameNumber_G.Text));
                cmd.Connection = conn;

                conn.Open();

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    conn.Close();
                    PlayerCount_G.Text = dt.Rows.Count.ToString();
                    if (PlayerCount_G.Text != "0")
                    {
                        DisplayRows(Convert.ToInt16(PlayerCount_G.Text), true);

                        GameDate_G.Value = (DateTime)dt.Rows[0][1];
                        int b = Convert.ToInt16(dt.Rows[0][5]);
                        BuyIn_G.Text = b.ToString();

                        int x = 0;
                        foreach (DataRow row in dt.Rows)
                        {
                            ComboBox playerBox = this.Controls.Find(GameControlRows[x, 1], true).FirstOrDefault() as ComboBox;
                            TextBox prizeBox = this.Controls.Find(GameControlRows[x, 3], true).FirstOrDefault() as TextBox;

                            playerBox.Text = row[2].ToString();
                            prizeBox.Text = Convert.ToInt16(row[4]).ToString();
                            ++x;
                        }
                    }
                    else
                    {
                        DisplayRows(0, true);
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //Function to Update Auto-Filled Prizes wheb "Buy-In" Field is changed.
        private void BuyIn_G_TextChanged(object sender, EventArgs e)
        {
            if (PlayerCount_G.Text != "0")
            {
                DisplayRows(Convert.ToInt16(PlayerCount_G.Text), false);
            }
        }

        //Delete Game Record to Insert Updated Game Record (Full Game Record)
        private void DeleteGameRecords()
        {
            SqlConnection conn = new SqlConnection(@"Data Source = LOU-PC\SQLEXPRESS; Initial Catalog = SampleRecords; Integrated Security = True");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM Records WHERE Game=@Game";
            cmd.Parameters.AddWithValue("@game", Convert.ToInt16(GameNumber_G.Text));
            cmd.Connection = conn;

            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }

        //Display Proper Number of Rows & AutoFill Payouts (Full Game Record)
        private void DisplayRows(int playerCount ,bool reset)
        {
            int pot = 0;                                                                                                //Total Prize Money

            for (int x = 0; x < 10; ++x)
            {
                Label num = this.Controls.Find(GameControlRows[x, 0], true).FirstOrDefault() as Label;
                ComboBox player = this.Controls.Find(GameControlRows[x, 1], true).FirstOrDefault() as ComboBox;
                Label prizeLabel = this.Controls.Find(GameControlRows[x, 2], true).FirstOrDefault() as Label;
                TextBox prizeAmount = this.Controls.Find(GameControlRows[x, 3], true).FirstOrDefault() as TextBox;
                if(reset) player.ResetText();

                if (x < playerCount)                                                                                    //Show Row
                {
                    num.Show();
                    player.Show();
                    prizeLabel.Show();
                    prizeAmount.Show();
                }
                else                                                                                                    //Hide Row
                {
                    num.Hide();
                    player.Hide();
                    prizeLabel.Hide();
                    prizeAmount.Hide();
                }

                if (BuyIn_G.Text != "")
                {
                    pot = Convert.ToInt16(BuyIn_G.Text) * playerCount;
                    switch (playerCount)                                                                                //To Auto-Fill Prizes
                    {
                        case 4:                                                                                         //4 Person Game
                            if (x == 0) prizeAmount.Text = pot.ToString();                                              //1st - 100% of Pot
                            else prizeAmount.Text = "0";
                            break;
                        case 5:                                                                                         //5 Person Game
                            if (x == 0) prizeAmount.Text = (pot * .66).ToString();                                      //1st - 66% of Pot
                            else if (x == 1) prizeAmount.Text = (pot * .34).ToString();                                 //2nd - 34% of Pot
                            else prizeAmount.Text = "0";
                            break;
                        case 6:                                                                                         //6 Person Game
                            if (x == 0) prizeAmount.Text = (pot * .50).ToString();                                      //1st - 50% of Pot
                            else if (x == 1) prizeAmount.Text = (pot * .30).ToString();                                 //2nd - 30% of Pot
                            else if (x == 2) prizeAmount.Text = (pot * .20).ToString();                                 //3rd - 20% of Pot
                            else prizeAmount.Text = "0";
                            break;
                        case 7:                                                                                         //7 Person Game
                            if (x == 0) prizeAmount.Text = (pot * .50).ToString();                                      //1st - 50% of Pot
                            else if (x == 1) prizeAmount.Text = (pot * .30).ToString();                                 //2nd - 30% of Pot
                            else if (x == 2) prizeAmount.Text = (pot * .20).ToString();                                 //3rd - 20% of Pot
                            else prizeAmount.Text = "0";
                            break;
                        case 8:                                                                                         //8 Person Game
                            if (x == 0) prizeAmount.Text = (pot * .50).ToString();                                      //1st - 50% of Pot
                            else if (x == 1) prizeAmount.Text = (pot * .30).ToString();                                 //2nd - 30% of Pot
                            else if (x == 2) prizeAmount.Text = (pot * .20).ToString();                                 //3rd - 20% of Pot
                            else prizeAmount.Text = "0";
                            break;
                        case 9:                                                                                         //9 Person Game
                            if (x == 0) prizeAmount.Text = (pot * .50).ToString();                                      //1st - 50% of Pot
                            else if (x == 1) prizeAmount.Text = (pot * .30).ToString();                                 //2nd - 30% of Pot
                            else if (x == 2) prizeAmount.Text = (pot * .20).ToString();                                 //3rd - 20% of Pot
                            else prizeAmount.Text = "0";
                            break;
                        case 10:                                                                                        //10 Person Game
                            if (x == 0) prizeAmount.Text = (pot * .50).ToString();                                      //1st - 50% of Pot
                            else if (x == 1) prizeAmount.Text = (pot * .30).ToString();                                 //2nd - 30% of Pot
                            else if (x == 2) prizeAmount.Text = (pot * .20).ToString();                                 //3rd - 20% of Pot
                            else prizeAmount.Text = "0";
                            break;
                    }
                }
            }
        }
    }
}