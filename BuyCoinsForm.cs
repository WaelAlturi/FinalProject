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

            // התחלת תור הזמן לבדוק את תקינות התשלום
            CheackPaymentTimer.Start();

            // הצמדת הטופס לאמצע המסך
            this.CenterToScreen();

            // עיצוב והגדרות נוספות לטופס
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        // פונקציה שמופעלת בעת ציור הלוח של טופס הקניית מטבעות
        private void Coin_Panel_Paint(object sender, PaintEventArgs e)
        {
            Coin_Panel.Location = new Point(
               this.ClientSize.Width / 2 - Coin_Panel.Size.Width / 2,
               this.ClientSize.Height / 2 - Coin_Panel.Size.Height / 2);
        }

        // פונקציה שמופעלת בלחיצה על כפתור לרכוש 10,000 מטבעות
        private void TenThousandCoinBtn_Click(object sender, EventArgs e)
        {
            // עדכון התווית של המחיר לפי הכמות שנבחרה
            PayLbl.Text = TenThousandCost.Text;

            // אפשור כניסת פרטי האשראי
            CardNumberTextBox.Enabled = true;
            CVVTextBox.Enabled = true;
            MonthCB.Enabled = true;
            YearCB.Enabled = true;
        }

        // פונקציה שמופעלת בכל צ'יק של תור הזמן שבודק תקינות התשלום
        private void CheackPaymentTimer_Tick(object sender, EventArgs e)
        {
            // בדיקת תקינות תעודת האשראי וה CVV
            if (CardNumberTextBox.Text.Length == 16 && CVVTextBox.Text.Length == 3 && MonthCB.Text.Length == 2 && YearCB.Text.Length == 4)
                PayBtn.Enabled = true; // אם הפרטים תקינים, אפשר ללחוץ על כפתור התשלום
            else
                PayBtn.Enabled = false; // אחרת, לא ניתן ללחוץ על כפתור התשלום
        }

        // פונקציה שמופעלת בלחיצה על כפתור לרכוש 5,000 מטבעות (אותו הדבר לרכוש 1,000 מטבעות)
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

        // פונקציה שמופעלת בלחיצה על כפתור התשלום
        private void PayBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // הגדרת משתנה לכמות המטבעות שיש להוסיף לחשבון
                int AddCoins = 0;

                // בדיקה על פי המחיר שנבחר, והוספת הכמות המתאימה למשתנה AddCoins
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

                // יצירת חיבור למסד הנתונים
                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                // פתיחת החיבור למסד הנתונים
                mySqlConnection.Open();

                // שאילתת SQL לעדכון הכמות המטבעות בטבלת Login
                mySqlCommand.CommandText = $"update Login set Coins = {AddCoins} where UserName ='{LoginForm.username}';";

                // ביצוע השאילתה
                mySqlCommand.ExecuteNonQuery();

                // הודעה למשתמש שהתשלום בוצע בהצלחה
                MessageBox.Show($"Succesfully Add Fund To {LoginForm.username}");

                // סגירת החיבור למסד הנתונים
                mySqlConnection.Close();

                // הסתרת הטופס הנוכחי ופתיחת הטופס HomeScreen שוב
                this.Hide();
                HomeScreen homescreen = new HomeScreen();
                homescreen.ShowDialog();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        // פונקציה שמופעלת בלחיצה על כפתור החזרה
        private void Back_Button_Click(object sender, EventArgs e)
        {
            // יצירת אובייקט חדש מסוג HomeScreen (טופס המסך הראשי) והצגתו
            HomeScreen hs = new HomeScreen();
            this.Hide();
            hs.ShowDialog();
        }
    }
}
