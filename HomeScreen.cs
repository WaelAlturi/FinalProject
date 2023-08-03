using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Diagnostics;

namespace FinalProject
{
    public partial class HomeScreen : Form
    {
        public static int GetCoins;
        public static int myGames;
        private Button[] Button = new Button[99];
        int numOfButtons = 1;
        public HomeScreen()
        {
            InitializeComponent();
            Timer.Start();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            GetColumn();

        }
        private void HomeScreen_Load(object sender, EventArgs e) {}
        private void Timer_Tick(object sender, EventArgs e)
        {
            TTDD.Format = DateTimePickerFormat.Custom;
            TTDD.CustomFormat = "dddd MMMM dd, yyyy";
            DateWindow.Text = TTDD.Text;
            ShowCoins();
            Sort();
            Libary();
        }
        private void BuyCoins_Click(object sender, EventArgs e)
        {
            BuyCoinsForm BCF = new BuyCoinsForm();
            this.Hide();
            BCF.ShowDialog();
        }
        private void Libary()
        {
            switch (myGames)
            {
                case 1:
                    PACMAN.Text = "START";
                    break;
                case 2:
                    ZOMBIEGAME.Text = "START";
                    break;
                case 3:
                    ZOMBIEGAME.Text = "START";
                    PACMAN.Text = "START";
                    break;
                case 4:
                    BREAKOUT.Text = "START";
                    break;
                case 5:
                    BREAKOUT.Text = "START";
                    PACMAN.Text = "START";
                    break;
                case 6:
                    BREAKOUT.Text = "START";
                    ZOMBIEGAME.Text = "START";
                    break;
                case 7:
                    ZOMBIEGAME.Text = "START";
                    PACMAN.Text = "START";
                    BREAKOUT.Text = "START";
                    break;
                default:
                    // Handle cases when myGames is not any of the specified values.
                    break;
            }
        }
        public void ShowCoins()
        {
            try
            {
                string Cheack ="";
                string Games = "";
                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlConnection.Open();
                mySqlCommand.CommandText = $"Select Coins,Games from Login where UserName = '{LoginForm.username}';";
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    Cheack = mySqlDataReader["Coins"].ToString();
                    Games = mySqlDataReader["Games"].ToString();
                }
                mySqlDataReader.Close();
                mySqlConnection.Close();
                GetCoins = int.Parse(Cheack);
                myGames = int.Parse(Games);
                Coin.Text = GetCoins.ToString();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        public void UpdateCoins(int x)
        {
            try
            {
                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlConnection.Open();
                mySqlCommand.CommandText = $"update Login set Coins = {x} where UserName = '{LoginForm.username}';";
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                mySqlDataReader.Close();
                mySqlConnection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        public void Updategames()
        {
            try
            {
                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlConnection.Open();
                mySqlCommand.CommandText = $"update Login set Games = {myGames} where UserName = '{LoginForm.username}';";
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                mySqlDataReader.Close();
                mySqlConnection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        public void Sort()
        {
            BuyCoins.Location = new Point(1870, 9);
            DollarSign.Location = new Point(1790, 15);
            Coin.Location = new Point(1800, 15);
        }
        private void addShortCut_Click(object sender, EventArgs e)
        {
            string path = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                Timer.Stop();
                Timer.Start();
            }
                string name = Path.GetFileNameWithoutExtension(path);
            //Process.Start(@"" + path);
            bool tableExists = CheckIfTableExists(LoginForm.username);

            if (tableExists)
            {
                MessageBox.Show($"The Login table exists in the database.");
                addvalue(path,name);
            }
            else
            {
                createNewTable(path,name);
            }
           
        }
        private void createNewTable(string path, string name)
        {
            try
            {
                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                SqlCommand mySqlCommand2 = mySqlConnection.CreateCommand();

                mySqlCommand.CommandText = $"CREATE TABLE {LoginForm.username} ({name} varchar(100));";
                mySqlCommand2.CommandText = $"INSERT INTO {LoginForm.username} ({name}) VALUES ('{path}');";
                mySqlConnection.Open();

                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                mySqlDataReader.Close();

                SqlDataReader mySqlDataReader2 = mySqlCommand2.ExecuteReader();
                mySqlDataReader2.Close();

                mySqlConnection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void addvalue(string path, string name)
        {
            try
            {
                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                SqlCommand mySqlCommand2 = mySqlConnection.CreateCommand();

                mySqlCommand.CommandText = $"ALTER TABLE {LoginForm.username} ADD {name} varchar(100);";
                mySqlCommand2.CommandText = $"INSERT INTO {LoginForm.username} ({name}) VALUES ('{path}');";
                mySqlConnection.Open();

                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                mySqlDataReader.Close();

                SqlDataReader mySqlDataReader2 = mySqlCommand2.ExecuteReader();
                mySqlDataReader2.Close();

                mySqlConnection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void Menu_Button_Click(object sender, EventArgs e)
        {
            try 
            {
                if (Menu_Button.Text == ".")
                {
                    Menu_Button.Text = "..";
                    Menu_Panel.Visible = true;
                    Menu_Button.BackgroundImage = Image.FromFile(@"C:\Users\HP\Desktop\שנה ב (א)\FinalProject\FinalProject\bin\Debug\Desgin\ButtonImages\OpenMenu.png");
                }
                else
                {
                    Menu_Button.Text = ".";
                    Menu_Panel.Visible = false;
                    Menu_Button.BackgroundImage = Image.FromFile(@"C:\Users\HP\Desktop\שנה ב (א)\FinalProject\FinalProject\bin\Debug\Desgin\ButtonImages\Menu.png");
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void Exit_Button_Click(object sender, EventArgs e)
        {
            Admin LF = new Admin();
            this.Hide();
            LF.ShowDialog();
        }
        private void Logout_Button_Click(object sender, EventArgs e)
        {
            LoginForm LF = new LoginForm();
            this.Hide();
            LF.ShowDialog();
        }

        private void SuccessBuy(Button gameName)
        {
            try
            {
                if (GetCoins >= int.Parse(gameName.Text))
                {
                    string str = gameName.Text.Remove(gameName.Text.Length-1);
                    MessageBox.Show("Buying Success");
                    UpdateCoins(GetCoins -= int.Parse(gameName.Text));
                    gameName.Text = "START";
                }
                else
                    MessageBox.Show("Not have enough MOney");

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void PACMAN_Click(object sender, EventArgs e)
        {
            if (PACMAN.Text != "START")
            {
                SuccessBuy(PACMAN);
                myGames += 1;
                Updategames();
            }
            else
                Process.Start(@"C:\Users\HP\Desktop\שנה ב (א)\FinalProject\FinalProject\bin\Debug\GamesSection\Pacman\Pacman\bin\Debug\Pacman.exe");

        }
        private void ZOMBIEGAME_Click(object sender, EventArgs e)
        {
            if (ZOMBIEGAME.Text != "START")
            {
                SuccessBuy(ZOMBIEGAME);
                myGames += 2;
                Updategames();
            }
            {
                Process.Start(@"C:\Users\HP\Desktop\שנה ב (א)\FinalProject\FinalProject\bin\Debug\GamesSection\Zombie\Shoot Out Game MOO ICT\bin\Debug\Shoot Out Game MOO ICT.exe");
            }
        }

        private void BREAKOUT_Click(object sender, EventArgs e)
        {
            if (BREAKOUT.Text != "START")
            {
                SuccessBuy(BREAKOUT);
                myGames += 4;
                Updategames();
            }
            else
                Process.Start(@"C:\Users\HP\Desktop\שנה ב (א)\FinalProject\FinalProject\bin\Debug\GamesSection\Breakout\Breakout\bin\Debug\Breakout.exe");
        }
        private bool CheckIfTableExists(string tableName)
        {
            string connectionString = "server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @TableName";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TableName", tableName);
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        // If count is greater than 0, the table exists
                        return count > 0;
                    }
                }
                catch
                {
                    // Handle exceptions here (e.g., log or display error messages)
                    return false;
                }
            }
        }
        public void GetColumn()
        {
            try
            {

                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlCommand.CommandText = $"SELECT TOP 0 * FROM {LoginForm.username};";
                mySqlConnection.Open();
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                // Get the schema table containing column information
                DataTable schemaTable = mySqlDataReader.GetSchemaTable();

                // Loop through the rows in the schema table to get column names
              
                foreach (DataRow row in schemaTable.Rows)
                {
                    string columnName = row["ColumnName"].ToString();
                    int i, xx = 382, yy = 472,c = 0;

                    for (i = 1; i <= numOfButtons; i++)
                    {
                        Button[i] = new Button();
                        Button[i].FlatStyle = FlatStyle.Popup;
                        Button[i].BackColor = Color.Transparent;
                        Button[i].Location = new Point(xx, yy);
                        Button[i].Size = new Size(259, 186);
                        xx += 284;
                        Button[i].Text = columnName;
                        c++;
                        if (c == 4)
                        {
                            yy += 200;
                            xx = 382;
                            c = 0;
                        }
                        Controls.Add(Button[i]);
                        Button[i].Click += new EventHandler(GetDataOfShortCut);
                    }
                   numOfButtons++;
                }
                
                mySqlDataReader.Close();
                mySqlConnection.Close();
            }
            catch (Exception err)
            {
                if (err.Message.Contains($"Invalid object name '{LoginForm.username}'")) ;
                else
                    MessageBox.Show(err.Message);

            }
        }
        public void GetDataOfShortCut(object sender, EventArgs e)
        {
            try
            {
                Button my = (Button)sender;
                string Cheack = "";
                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlConnection.Open();
                mySqlCommand.CommandText = $"Select {my.Text} from {LoginForm.username} WHERE {my.Text} IS NOT NULL ;";
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    Cheack = mySqlDataReader[my.Text].ToString();
                }
                mySqlDataReader.Close();
                mySqlConnection.Close();
                //MessageBox.Show(Cheack);
                Process.Start(Cheack);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        
    }
}
