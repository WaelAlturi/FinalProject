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
{// הגדרת מחלקה חלקית ציבורית בשם LoginForm שמורישה מהמחלקה Form
    public partial class LoginForm : Form
    {
        // הגדרת משתנה מחרוזת סטטי ציבורי בשם "username" עם ערך ברירת מחדל של מחרוזת ריקה
        public static string username = "";
        // הגדרת משתנה שלם בשם "rowCount" עם ערך ברירת מחדל של 0
        int rowCount = 0;

        // בנאי עבור מחלקת LoginForm
        public LoginForm()
        {
            // אתחול הטופס ורכיביו
            InitializeComponent();

            // מרכז את הטופס על המסך
            this.CenterToScreen();

            // הסרת גבול החלון
            this.FormBorderStyle = FormBorderStyle.None;

            // מקסימיזציה של החלון
            this.WindowState = FormWindowState.Maximized;

            // קריאה לשיטה לבדיקת נתוני האימייל ושם המשתמש בבסיס הנתונים
            CheackEmailAndUserName();
        }

        // מטפל באירוע טעינת הטופס LoginForm
        private void LoginForm_Load_1(object sender, EventArgs e)
        {
            // הגדרת מיקום הפאנל Login_Register_Panel להיות ממורכז בטופס
            Login_Register_Panel.Location = new Point(
            this.ClientSize.Width / 2 - Login_Register_Panel.Size.Width / 2,
            this.ClientSize.Height / 2 - Login_Register_Panel.Size.Height / 2);
        }

        // מטפל באירוע לחיצה על הכפתור "Login/Register"
        private void Login_Register_btn_Click(object sender, EventArgs e)
        {
            try
            {
                // בדיקה אם טקסט הכפתור הוא "Register"
                if (Login_Register_btn.Text == "Register")
                {
                    // אם מתבצע רישום, אז יש לשלוף את נתוני האימייל ושם המשתמש הקיימים מהבסיס נתונים
                    string[,] Cheacks = new string[rowCount, 2];
                    Cheacks = CheackEmailAndUserName();

                    // לקבל את האימייל, הסיסמה ושם המשתמש שהוזנו מתיבות הטקסט המתאימות
                    string Email = Email_Text.Text;
                    string PassWord = PassWord_Text.Text;
                    string UserName = UserName_Text.Text;

                    // איתחול משתנה בוליאני למעקב אם האימייל ושם המשתמש זמינים
                    bool Cheack = true;

                    // לעבור על הנתונים הקיימים ולבדוק אם קיימים כפילויות
                    for (int i = 0; i < rowCount; i++)
                    {
                        if (Email == Cheacks[i, 0])
                        {
                            // אם האימייל כבר תפוס, להציג הודעת שגיאה
                            Cheack = false;
                            MessageBox.Show($"{Email} כבר תפוס", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (UserName == Cheacks[i, 1])
                        {
                            // אם שם המשתמש כבר תפוס, להציג הודעת שגיאה
                            Cheack = false;
                            MessageBox.Show($"{UserName} כבר תפוס", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    // אם האימייל ושם המשתמש זמינים, להמשיך עם התהליך של הרישום
                    if (Cheack)
                    {
                        try
                        {
                            // יצירת חיבור לבסיס הנתונים של שרת SQL
                            SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                            // הוספת משתמש חדש לטבלת Login בבסיס הנתונים
                            mySqlCommand.CommandText = $"insert into Login values('{Email}','{PassWord}','{UserName}',0,'{null}');";
                            mySqlConnection.Open();

                            // ביצוע הפקודה SQL להוספת הנתונים
                            SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                            // לנקות את תיבות הטקסט ולהציג הודעת ברוך הבא
                            Email_lbl.Visible = false;
                            Email_Text.Visible = false;
                            Email_Text.Text = "";
                            UserName_Text.Text = "";
                            PassWord_Text.Text = "";

                            // סגירת קורא הנתונים והחיבור
                            mySqlDataReader.Close();
                            mySqlConnection.Close();

                            // להציג הודעת ברוך הבא עם שם המשתמש שנרשם
                            MessageBox.Show($"ברוך הבא {UserName}");

                            // להחליף את טקסט הכפתור וטקסט התווית להחלפה למצב התחברות
                            Login_Register_btn.Text = "Login";
                            AddData_Button.Text = "Register";
                            Login_Rigester_LBL.Text = "אין לך חשבון?";
                        }
                        catch (Exception err)
                        {
                            // להציג הודעות שגיאות שקשורות לבסיס הנתונים
                            MessageBox.Show(err.Message);
                        }
                    }
                }
                else
                {
                    // אם טקסט הכפתור הוא "Login", להמשיך עם תהליך ההתחברות
                    AcceptToLogin();
                }
            }
            catch (Exception err)
            {
                // להציג הודעות שגיאות אחרות
                MessageBox.Show(err.Message);
            }
        }

        // שיטה לטיפול בתהליך התחברות
        private void AcceptToLogin()
        {
            try
            {
                // לקבל את שם המשתמש והסיסמה שהוזנו מתיבות הטקסט המתאימות
                string UserName = UserName_Text.Text;
                string PassWord = PassWord_Text.Text;

                // יצירת חיבור לבסיס הנתונים של שרת SQL
                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                // בדיקה אם שם המשתמש והסיסמה הנכונים מתאימים לנתונים בטבלת Login
                mySqlCommand.CommandText = $"Select * from Login where username='{UserName}' and password='{PassWord}';";
                mySqlConnection.Open();
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                // אם נמצאה התאמה, לבצע התחברות ולפתוח את המסך הראשי (HomeScreen)
                if (mySqlDataReader.Read())
                {
                    username = UserName_Text.Text;
                    HomeScreen hs = new HomeScreen();
                    this.Hide();
                    hs.ShowDialog();
                }
                else
                {
                    // אם לא נמצאה התאמה, להציג הודעת שגיאה
                    MessageBox.Show("שם המשתמש או הסיסמה אינם נכונים");
                }

                // לסגור את קורא הנתונים והחיבור
                mySqlDataReader.Close();
                mySqlConnection.Close();
            }
            catch (Exception err)
            {
                // להציג הודעות שגיאות שקשורות לבסיס הנתונים
                MessageBox.Show(err.Message);
            }
        }

        // שיטה לשליפת נתוני האימייל ושם המשתמש מהבסיס נתונים
        private string[,] CheackEmailAndUserName()
        {
            try
            {
                // יצירת חיבור לבסיס הנתונים של שרת SQL
                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();

                // שאילתה לבסיס הנתונים לשליפת נתוני האימייל ושם המשתמש
                mySqlCommand.CommandText = "Select email, username from Login;";
                mySqlConnection.Open();
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                // לקבוע את מספר השורות בתוצאה
                while (mySqlDataReader.Read())
                {
                    rowCount++;
                }

                // לאתחל מחדש את קורא הנתונים כדי לקרוא את הנתונים שוב
                mySqlDataReader.Close();
                mySqlDataReader = mySqlCommand.ExecuteReader();

                // ליצור מערך דו-ממדי לאחסון הנתונים
                string[,] data = new string[rowCount, 2];

                int rowIndex = 0;
                while (mySqlDataReader.Read())
                {
                    // לאחסן את נתוני האימייל ושם המשתמש המשובצים מהבסיס נתונים במערך
                    data[rowIndex, 0] = mySqlDataReader["email"].ToString();
                    data[rowIndex, 1] = mySqlDataReader["username"].ToString();
                    rowIndex++;
                }

                // לסגור את קורא הנתונים והחיבור
                mySqlDataReader.Close();
                mySqlConnection.Close();

                // להחזיר את הנתונים ששולפו
                return data;
            }
            catch (Exception err)
            {
                // להציג הודעות שגיאות שקשורות לבסיס הנתונים
                MessageBox.Show(err.Message);
                return null;
            }
        }

        // מטפל באירוע שינוי הטקסט בתיבת הטקסט PassWord_Text
        private void PassWord_Text_TextChanged(object sender, EventArgs e)
        {
            // להגדיר את PasswordChar להיות '●' כדי להסתיר את התווים שהוזנו
            PassWord_Text.PasswordChar = '●';
        }

        // מטפל באירוע לחיצה על הכפתור "Register/Login"
        private void AddData_Button_Click(object sender, EventArgs e)
        {
            try
            {
                // לבדוק אם טקסט הכפתור הוא "Register"
                if (AddData_Button.Text == "Register")
                {
                    // להחליף למצב רישום: לעדכן את טקסט הכפתור, טקסט התווית, ולהציג את תיבת הטקסט לאימייל
                    Login_Register_btn.Text = "Register";
                    AddData_Button.Text = "Login";
                    Login_Rigester_LBL.Text = "כבר יש לך חשבון?";
                    Email_lbl.Visible = true;
                    Email_Text.Visible = true;
                    Email_Text.Text = "";
                    UserName_Text.Text = "";
                    PassWord_Text.Text = "";
                }
                else
                {
                    // להחליף למצב התחברות: לעדכן את טקסט הכפתור, טקסט התווית, ולהסתיר את תיבת הטקסט לאימייל
                    Login_Register_btn.Text = "Login";
                    AddData_Button.Text = "Register";
                    Login_Rigester_LBL.Text = "אין לך חשבון?";
                    Email_lbl.Visible = false;
                    Email_Text.Visible = false;
                    Email_Text.Text = "";
                    UserName_Text.Text = "";
                    PassWord_Text.Text = "";
                }
            }
            catch (Exception err)
            {
                // להציג הודעות שגיאות אחרות
                MessageBox.Show(err.Message);
            }
        }

        // מטפל באירוע שינוי מצב התיבת סימון "Show Password"
        private void ShowPassword_CB_CheckedChanged(object sender, EventArgs e)
        {
            // אם התיבה מסומנת, להציג את התווים של הסיסמה; אחרת, להסתירם
            if (ShowPassword_CB.Checked)
                PassWord_Text.PasswordChar = '\0';
            else
                PassWord_Text.PasswordChar = '●';
        }
    }

}
