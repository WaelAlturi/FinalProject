using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FinalProject
{
    
    public partial class BuyCoinsForm : Form
    {
        public BuyCoinsForm()
        {
            InitializeComponent();
            CheackPaymentTimer.Start();
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }
        private void Coin_Panel_Paint(object sender, PaintEventArgs e)
        {
            Coin_Panel.Location = new Point(
               this.ClientSize.Width / 2 - Coin_Panel.Size.Width / 2,
               this.ClientSize.Height / 2 - Coin_Panel.Size.Height / 2);
        }

        private void TenThousandCoinBtn_Click(object sender, EventArgs e)
        {
            PayLbl.Text = TenThousandCost.Text;
            CardNumberTextBox.Enabled = true;
            CVVTextBox.Enabled = true;
            MonthCB.Enabled = true;
            YearCB.Enabled = true;
        }
        private void CheackPaymentTimer_Tick(object sender, EventArgs e)
        {
            if (CardNumberTextBox.Text.Length == 16 && CVVTextBox.Text.Length == 3 && MonthCB.Text.Length == 2 && YearCB.Text.Length == 4)
                PayBtn.Enabled = true;
            else
                PayBtn.Enabled = false;
        }

        private void FiveThousandCoinBtn_Click(object sender, EventArgs e)
        {
            PayLbl.Text = FiveThousandCost.Text;
            CardNumberTextBox.Enabled = true;
            CVVTextBox.Enabled = true;
            MonthCB.Enabled = true;
            YearCB.Enabled = true;
        }

        private void OneThousandCoinBtn_Click(object sender, EventArgs e)
        {
            PayLbl.Text = OneThousandCost.Text;
            CardNumberTextBox.Enabled = true;
            CVVTextBox.Enabled = true;
            MonthCB.Enabled = true;
            YearCB.Enabled = true;
        }

        private void PayBtn_Click(object sender, EventArgs e)
        {

            try
            {
                int AddCoins = 0;
                if (PayLbl.Text == OneThousandCost.Text)
                {
                    AddCoins += HomeScreen.GetCoins + 1000;
                }
                if (PayLbl.Text == FiveThousandCost.Text)
                {
                    AddCoins += HomeScreen.GetCoins + 5000;
                }
                if (PayLbl.Text == TenThousandCost.Text)
                {
                    AddCoins += HomeScreen.GetCoins + 10000;
                }
                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlConnection.Open();
                mySqlCommand.CommandText = $"update Login set Coins = {AddCoins} where UserName ='{LoginForm.username}';";
                mySqlCommand.ExecuteNonQuery();
                MessageBox.Show($"Succfully Add Fund To {LoginForm.username}");
                mySqlConnection.Close();
                this.Hide();
                HomeScreen homescreen = new HomeScreen();
                homescreen.ShowDialog();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void Back_Button_Click(object sender, EventArgs e)
        {
            HomeScreen hs = new HomeScreen();
            this.Hide();
            hs.ShowDialog();
        }
    }
}
