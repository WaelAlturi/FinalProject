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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();

            // קריאה לפונקציה GetUser שתמלא את רשימת המשתמשים בלוגין
            GetUser();

            // עיצוב והגדרות נוספות לטופס
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        // פונקציה שממלאה את רשימת המשתמשים בלוגין
        private void Admin_Load(object sender, EventArgs e)
        {
            // הגדרת מיקום לוח הניהול (Admin_Panel) במרכז הטופס
            Admin_Panel.Location = new Point(
               this.ClientSize.Width / 2 - Admin_Panel.Size.Width / 2,
               this.ClientSize.Height / 2 - Admin_Panel.Size.Height / 2);
        }
        public void GetUser()
        {
            try
            {
                // יצירת חיבור למסד הנתונים
                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                // שאילתת SQL למשיכת רשימת המשתמשים מטבלת Login
                mySqlCommand.CommandText = "Select UserName from Login;";

                // פתיחת החיבור למסד הנתונים
                mySqlConnection.Open();

                // ביצוע השאילתה וקריאת הנתונים
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                // קריאה לשורות בתוך התוצאה שחזרה ממסד הנתונים והוספתם לרשימה
                while (mySqlDataReader.Read())
                {
                    Users_Data_LB.Items.Add(mySqlDataReader["UserName"].ToString());
                }

                // סגירת הקורא והחיבור למסד הנתונים
                mySqlDataReader.Close();
                mySqlConnection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        // פונקציה לקבלת מידע על משתמש ספציפי לפי שם משתמש
        private string[] UserInfo(string username)
        {
            try
            {
                // מערך שבו יישמר המידע על המשתמש
                string[] str = new string[3];

                // יצירת חיבור למסד הנתונים
                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                // שאילתת SQL למשיכת מידע על המשתמש מטבלת Login לפי שם המשתמש
                mySqlCommand.CommandText = "Select Email,Password,Coins from Login where UserName='" + username + "';";

                // פתיחת החיבור למסד הנתונים
                mySqlConnection.Open();

                // ביצוע השאילתה וקריאת הנתונים
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                // קריאה לשורה בתוך התוצאה שחזרה ממסד הנתונים ושמירה של הנתונים במערך str
                while (mySqlDataReader.Read())
                {
                    str[0] = mySqlDataReader["Email"].ToString();
                    str[1] = mySqlDataReader["Password"].ToString();
                    str[2] = mySqlDataReader["Coins"].ToString();
                }

                // סגירת הקורא והחיבור למסד הנתונים
                mySqlDataReader.Close();
                mySqlConnection.Close();

                // החזרת המערך עם המידע על המשתמש
                return str;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

                // במקרה של חריגה, נחזיר null
                return null;
            }
        }

        // פונקציה שמתבצעת בעת בחירה של משתמש מרשימת המשתמשים
        private void Users_Data_LB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // מערך שבו יתקבלו הנתונים על המשתמש הנבחר
                string[] str = new string[4];

                // קריאה לפונקציה UserInfo ושמירת המידע המוחזר במערך str
                str = UserInfo(Users_Data_LB.Text);

                // מילוי שדות הטופס בהתאם למידע שנמצא במערך
                Email_TB.Text = str[0];
                Password_TB.Text = str[1];
                Coins_TB.Text = str[2];
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        // פונקציה שמתבצעת בלחיצה על כפתור העדכון
        private void Update_Click(object sender, EventArgs e)
        {
            if (Email_TB.Enabled == true)
            {
                try
                {
                    // יצירת חיבור למסד הנתונים
                    SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                    SqlCommand mysqlcommand = mySqlConnection.CreateCommand();

                    // פתיחת החיבור למסד הנתונים
                    mySqlConnection.Open();

                    // שאילתת SQL לעדכון המידע בטבלת Login לפי שם המשתמש
                    mysqlcommand.CommandText = $"update Login set Email='{Email_TB.Text}',Password= '{Password_TB.Text}',Coins= {Coins_TB.Text} where UserName='{Users_Data_LB.Text}';";

                    // ביצוע השאילתה
                    mysqlcommand.ExecuteNonQuery();

                    // הודעה למשתמש שהעדכון בוצע בהצלחה
                    MessageBox.Show("Updating Successfully");

                    // סגירת החיבור למסד הנתונים
                    mySqlConnection.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }

            // הפונקציה מצפה להפעלה כאשר מתבצעת לחיצה על כפתור העדכון, אם השדות היו כבר פעילים (לא ננעלו לעריכה) אז הפונקציה תפעיל אותם ותאפשר לעריכתם.
            Email_TB.Enabled = true;
            Password_TB.Enabled = true;
            Coins_TB.Enabled = true;
        }

        // פונקציה שמתבצעת בלחיצה על כפתור החזרה
        private void Back_Button_Click(object sender, EventArgs e)
        {
            // יצירת אובייקט חדש מסוג HomeScreen (טופס המסך הראשי) והצגתו
            HomeScreen hs = new HomeScreen();
            this.Hide();
            hs.ShowDialog();
        }

        // פונקציה שמתבצעת בלחיצה על כפתור המחיקה
        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                // יצירת חיבור למסד הנתונים
                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                SqlCommand mysqlcommand = mySqlConnection.CreateCommand();

                // פתיחת החיבור למסד הנתונים
                mySqlConnection.Open();

                // שאילתת SQL למחיקת המשתמש מטבלת Login לפי שם המשתמש
                mysqlcommand.CommandText = $"DELETE FROM Login WHERE UserName = '{Users_Data_LB.Text}';";

                // ביצוע השאילתה
                mysqlcommand.ExecuteNonQuery();

                // הודעה למשתמש שהמחיקה בוצעה בהצלחה
                MessageBox.Show("DELETE Successfully");

                // סגירת החיבור למסד הנתונים
                mySqlConnection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void Reload_BTN_Click(object sender, EventArgs e)
        {
            // בלחיצה על הכפתור "Reload_BTN" ניצור חלון חדש של Admin ונסתיר את החלון הנוכחי
            Admin LF = new Admin();
            this.Hide();
            LF.ShowDialog();
        }
    }
}
