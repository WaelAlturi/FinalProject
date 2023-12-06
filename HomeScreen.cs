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
        // משתנה סטטי ציבורי לאחזור המטבעות
        public static int GetCoins;

        // משתנה סטטי ציבורי לשמירת מספר המשחקים של המשתמש
        public static int myGames;

        // מערך של כפתורים
        private Button[] Button = new Button[99];

        // מספר הכפתורים הנוכחי במערך
        int numOfButtons = 1;

        // בנאי של הקופם הראשי
        public HomeScreen()
        {
            InitializeComponent();

            // הפעלת טיימר במסך הראשי
            Timer.Start();

            // לקבוע את החלון למצב תופס כל המסך
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            // לקבוע כתיבת תאריך בפורמט מותאם אישית
            GetColumn();

            // בדיקה אם המשתמש הוא מנהל (admin) ואם כן, להציג את הכפתור למסך המנהל
            if (LoginForm.username == "admin")
                Admin_Button.Visible = true;
        }

        private void HomeScreen_Load(object sender, EventArgs e) { }

        // מערך הכפתורים הוא חלק מהמסך ולכן אין צורך באירוע טעינה
        // זהו מיקום לכל הכפתורים בציר הזמן
        private void Timer_Tick(object sender, EventArgs e)
        {
            // לקבוע את תצורת התאריך בפורמט מותאם אישית
            TTDD.Format = DateTimePickerFormat.Custom;
            TTDD.CustomFormat = "dddd MMMM dd, yyyy";

            // להציג את התאריך בתיבת הטקסט
            DateWindow.Text = TTDD.Text;

            // להציג את מספר המטבעות שברשות המשתמש
            ShowCoins();

            // לסדר את מיקום הכפתורים בחלון
            Sort();

            // להציג את הספריה של המשתמש
            Libary();
        }

        // אירוע לחיצה על כפתור רכישת מטבעות
        private void BuyCoins_Click(object sender, EventArgs e)
        {
            // יצירת מופע חדש של טופס הרכישת מטבעות
            BuyCoinsForm BCF = new BuyCoinsForm();
            // להסתיר את המסך הנוכחי ולהציג את טופס הרכישת מטבעות
            this.Hide();
            BCF.ShowDialog();
        }

        // טעינת המסך הראשי
        private void Libary()
        {
            // בהתאם למספר המשחקים שברשות המשתמש, לשנות את כפתורים המשחקים בספריה
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
                    // טיפול במקרים כאשר myGames אינו תואם את אף אחד מהערכים המצויינים
                    break;
            }
        }

        // הצגת המטבעות שברשות המשתמש
        public void ShowCoins()
        {
            try
            {
                // משתנה לשמירת התוצאות של שאילתת הבדיקה
                string Cheack = "";
                string Games = "";

                // יצירת חיבור לבסיס הנתונים
                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlConnection.Open();

                // שאילתת SQL לקבלת מספר המטבעות של המשתמש
                mySqlCommand.CommandText = $"Select Coins,Games from Login where UserName = '{LoginForm.username}';";

                // ביצוע השאילתה וקריאת התוצאה
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    // שמירת תוצאות השאילתה במשתנים
                    Cheack = mySqlDataReader["Coins"].ToString();
                    Games = mySqlDataReader["Games"].ToString();
                }

                // סגירת הקריאה מהבסיס נתונים והחיבור אליו
                mySqlDataReader.Close();
                mySqlConnection.Close();

                // קביעת המטבעות והמשחקים בטווח המתאים
                GetCoins = int.Parse(Cheack);
                myGames = int.Parse(Games);
                Coin.Text = GetCoins.ToString();
            }
            catch (Exception err)
            {
                // הצגת הודעת שגיאה במקרה של חריגה
                MessageBox.Show(err.Message);
            }
        }

        // עדכון כמות המטבעות שברשות המשתמש בבסיס הנתונים
        public void UpdateCoins(int x)
        {
            try
            {
                // יצירת חיבור לבסיס הנתונים
                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlConnection.Open();

                // שאילתת SQL לעדכון כמות המטבעות
                mySqlCommand.CommandText = $"update Login set Coins = {x} where UserName = '{LoginForm.username}';";

                // ביצוע השאילתה
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                mySqlDataReader.Close();

                // סגירת החיבור לבסיס הנתונים
                mySqlConnection.Close();
            }
            catch (Exception err)
            {
                // הצגת הודעת שגיאה במקרה של חריגה
                MessageBox.Show(err.Message);
            }
        }

        // עדכון מספר המשחקים בבסיס הנתונים
        public void Updategames()
        {
            try
            {
                // יצירת חיבור לבסיס הנתונים
                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlConnection.Open();

                // שאילתת SQL לעדכון מספר המשחקים
                mySqlCommand.CommandText = $"update Login set Games = {myGames} where UserName = '{LoginForm.username}';";

                // ביצוע השאילתה
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                mySqlDataReader.Close();

                // סגירת החיבור לבסיס הנתונים
                mySqlConnection.Close();
            }
            catch (Exception err)
            {
                // הצגת הודעת שגיאה במקרה של חריגה
                MessageBox.Show(err.Message);
            }
        }

        // שיטה לסידור את מיקום הכפתורים בחלון
        public void Sort()
        {
            BuyCoins.Location = new Point(1870, 9);
            DollarSign.Location = new Point(1790, 15);
            Coin.Location = new Point(1800, 15);
        }

        // אירוע לחיצה על כפתור הוספת קיצור דרך לשולחן העבודה
        private void addShortCut_Click(object sender, EventArgs e)
        {
            // משתנה לשמירת הנתיב של הקובץ
            string path = "";

            // הצגת תיבת דו-שיח לבחירת קובץ
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
            }

            // שמירת שם הקובץ ללא הסיומת
            string name = Path.GetFileNameWithoutExtension(path);

            // בדיקה האם טבלה עם שם המשתמש כבר קיימת בבסיס הנתונים

            bool tableExists = CheckIfTableExists(LoginForm.username);

            // במקרה שטבלה כזו כבר קיימת, להוסיף את הקיצור דרך לטבלה הקיימת
            if (tableExists)
                // להוסיף את הנתיב והשם לטבלה הקיימת
                addvalue(path, name);
            else
            {
                // במקרה שטבלה עם שם המשתמש עדיין לא קיימת, ליצור טבלה חדשה
                createNewTable(path, name);
            }
            HomeScreen hs = new HomeScreen();
            this.Hide();
            hs.ShowDialog();
        }
        private void createNewTable(string path, string name)
        {
            try
            {
                // יצירת חיבור למסד הנתונים
                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                SqlCommand mySqlCommand2 = mySqlConnection.CreateCommand();

                // יצירת הטבלה במסד הנתונים עם השם של המשתמש כשם הטבלה ועמודה בשם המשתנה "name" מסוג varchar באורך 100 תווים
                mySqlCommand.CommandText = $"CREATE TABLE {LoginForm.username} ({name} varchar(100));";

                // הכנסת הנתונים לטבלה, נכניס את ערך המשתנה "path" לשורת הנתונים הראשונה
                mySqlCommand2.CommandText = $"INSERT INTO {LoginForm.username} ({name}) VALUES ('{path}');";

                // פתיחת החיבור למסד הנתונים
                mySqlConnection.Open();

                // ביצוע הפעולות במסד הנתונים - יצירת הטבלה והכנסת הנתונים
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                mySqlDataReader.Close();

                SqlDataReader mySqlDataReader2 = mySqlCommand2.ExecuteReader();
                mySqlDataReader2.Close();

                // סגירת החיבור למסד הנתונים
                mySqlConnection.Close();
            }
            catch (Exception err)
            {
                // הצגת הודעת שגיאה במקרה של חריגה
                MessageBox.Show(err.Message);
            }
        }

        private void addvalue(string path, string name)
        {
            try
            {
                // יצירת חיבור לבסיס הנתונים
                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                SqlCommand mySqlCommand2 = mySqlConnection.CreateCommand();

                // שאילתת SQL להוספת עמודה חדשה לטבלה של המשתמש
                mySqlCommand.CommandText = $"ALTER TABLE {LoginForm.username} ADD {name} varchar(100);";
                // שאילתת SQL להכנסת הערך של הנתיב לתוך העמודה החדשה
                mySqlCommand2.CommandText = $"INSERT INTO {LoginForm.username} ({name}) VALUES ('{path}');";
                mySqlConnection.Open();

                // ביצוע השאילתות
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                mySqlDataReader.Close();
                SqlDataReader mySqlDataReader2 = mySqlCommand2.ExecuteReader();
                mySqlDataReader2.Close();

                // סגירת החיבור לבסיס הנתונים
                mySqlConnection.Close();
            }
            catch (Exception err)
            {
                // הצגת הודעת שגיאה במקרה של חריגה
                MessageBox.Show(err.Message);
            }
        }

        private bool SuccessBuy(Button gameName)
        {
            try
            {
                // בדיקה האם יש למשתמש מספיק מטבעות לרכישה
                if (GetCoins >= int.Parse(gameName.Text))
                {
                    // הצגת הודעת רכישה מוצלחת ועדכון כמות המטבעות
                    MessageBox.Show("רכישה מוצלחת");
                    UpdateCoins(GetCoins -= int.Parse(gameName.Text));
                    gameName.Text = "START";
                    return true;
                }
                else
                {
                    MessageBox.Show("אין מספיק מטבעות");
                    return false;
                }
            }
            catch (Exception err)
            {
                // הצגת הודעת שגיאה במקרה של חריגה
                MessageBox.Show(err.Message);
                return false;
            }
        }
        private void PACMAN_Click(object sender, EventArgs e)
        {
            if (PACMAN.Text != "START")
            {
                // במקרה שהכפתור "PACMAN" נלחץ והמשחק עדיין לא נרכש, לבצע רכישה
                if (SuccessBuy(PACMAN) == true)
                {
                    myGames += 1;
                    Updategames();
                }
            }
            else
            {
                // במקרה שהכפתור "PACMAN" נלחץ והמשחק כבר נרכש, להפעיל את המשחק
                Process.Start(@"C:\Users\HP\Desktop\שנה ב (א)\FinalProject\FinalProject\bin\Debug\GamesSection\Pacman\Pacman\bin\Debug\Pc Man Game MOO ICT.exe");
            }
        }

        // פונקציה דומה מוגדרת גם עבור כפתורי "ZOMBIEGAME" ו-"BREAKOUT"
        private void ZOMBIEGAME_Click(object sender, EventArgs e)
        {
            if (ZOMBIEGAME.Text != "START")
            {
                if (SuccessBuy(ZOMBIEGAME) == true)
                {
                    myGames += 2;
                    Updategames();
                }
            }
            else
                Process.Start(@"C:\Users\HP\Desktop\שנה ב (א)\FinalProject\FinalProject\bin\Debug\GamesSection\Zombie\Shoot Out Game MOO ICT\bin\Debug\Shoot Out Game MOO ICT.exe");
        }

        private void BREAKOUT_Click(object sender, EventArgs e)
        {
            if (BREAKOUT.Text != "START")
            {
                if (SuccessBuy(BREAKOUT) == true)
                {
                    myGames += 4;
                    Updategames();
                }
            }
            else
                Process.Start(@"C:\Users\HP\Desktop\שנה ב (א)\FinalProject\FinalProject\bin\Debug\GamesSection\Breakout\Breakout\bin\Debug\Breakout.exe");
        }

        private bool CheckIfTableExists(string tableName)
        {
            // בדיקה האם טבלה בשם שנמצא במשתנה tableName קיימת בבסיס הנתונים

            // חיבור לבסיס הנתונים
            string connectionString = "server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // שאילתת SQL לבדיקה האם הטבלה קיימת
                    string query = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @TableName";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TableName", tableName);
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        // אם המספר שהתקבל מהשאילתה גדול מ-0, הטבלה קיימת
                        return count > 0;
                    }
                }
                catch
                {
                    // מטפל בחריגות שאפשרות כאן (לדוגמה, יכול לשמור או להציג הודעות שגיאה)
                    return false;
                }
            }
        }

        // פונקציה להצגת הכפתורים בתיקייה
        public void GetColumn()
        {
            try
            {
                // חיבור לבסיס הנתונים
                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                // שאילתה לקבלת נתוני העמודות של הטבלה של המשתמש
                mySqlCommand.CommandText = $"SELECT TOP 0 * FROM {LoginForm.username};";
                mySqlConnection.Open();
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                // קבלת טבלת הסכימה של העמודות
                DataTable schemaTable = mySqlDataReader.GetSchemaTable();

                // לולאה על כל העמודות בטבלת הסכימה כדי לקבל את שמות העמודות
                foreach (DataRow row in schemaTable.Rows)
                {
                    // קבלת שם העמודה והצגת כפתור חדש עם שם העמודה בתוך לולאה
                    string columnName = row["ColumnName"].ToString();
                    int i, xx = 382, yy = 472, c = 0;

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
                // אם מתקבלת חריגה, בדיקה האם היא נובעת מהעובדה שהטבלה לא קיימת, אז לא להציג הודעת שגיאה.
                if (err.Message.Contains($"Invalid object name '{LoginForm.username}'")) ;
                else
                    MessageBox.Show(err.Message);
            }
        }

        // פונקציה לקבלת הנתונים של הקיצוריות דרך כפתור תיקייה
        public void GetDataOfShortCut(object sender, EventArgs e)
        {
            try
            {
                // בלחיצה על אחד מהכפתורים נקבל את השם של הכפתור ונחפש אותו בבסיס הנתונים
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

                // נפעיל את האפליקציה שקשורה לנתיב שהתקבל
                Process.Start(Cheack);
            }
            catch (Exception err)
            {
                // הצגת הודעת שגיאה במקרה של חריגה
                MessageBox.Show(err.Message);
            }
        }

        private void Reload_BTN_Click(object sender, EventArgs e)
        {
            // בלחיצה על הכפתור "Reload_BTN" ניצור חלון חדש של HomeScreen ונסתיר את החלון הנוכחי
            HomeScreen hs = new HomeScreen();
            this.Hide();
            hs.ShowDialog();
        }

        private void Menu_Button_Click(object sender, EventArgs e)
        {
            try
            {
                // בלחיצה על הכפתור "Menu_Button" נבצע בדיקת מצב התפריט ונפעיל פעולה בהתאם
                if (Menu_Button.Text == ".")
                {
                    // אם הכפתור נמצא במצב סגור, נשנה אותו למצב פתוח ונציג את התפריט
                    Menu_Button.Text = "..";
                    Menu_Panel.Visible = true;
                    Menu_Button.BackgroundImage = Image.FromFile(@"C:\Users\HP\Desktop\שנה ב (א)\FinalProject\FinalProject\bin\Debug\Desgin\ButtonImages\OpenMenu.png");
                }
                else
                {
                    // אם הכפתור נמצא במצב פתוח, נשנה אותו למצב סגור ונסתיר את התפריט
                    Menu_Button.Text = ".";
                    Menu_Panel.Visible = false;
                    Menu_Button.BackgroundImage = Image.FromFile(@"C:\Users\HP\Desktop\שנה ב (א)\FinalProject\FinalProject\bin\Debug\Desgin\ButtonImages\Menu.png");
                }
            }
            catch (Exception err)
            {
                // הצגת הודעת שגיאה במקרה של חריגה
                MessageBox.Show(err.Message);
            }
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            // בלחיצה על הכפתור "Exit_Button" נסיים את האפליקציה
            Application.Exit();
        }

        private void Logout_Button_Click(object sender, EventArgs e)
        {
            // בלחיצה על הכפתור "Logout_Button" ניצור חלון חדש של LoginForm ונסתיר את החלון הנוכחי
            LoginForm LF = new LoginForm();
            this.Hide();
            LF.ShowDialog();
        }

        private void Admin_Button_Click(object sender, EventArgs e)
        {
            // בלחיצה על הכפתור "Admin_Button" ניצור חלון חדש של Admin ונסתיר את החלון הנוכחי
            Admin LF = new Admin();
            this.Hide();
            LF.ShowDialog();
        }

        private void deleteAllShortCut_Click(object sender, EventArgs e)
        {
            try
            {
                // יצירת חיבור למסד הנתונים של SQL Server באמצעות מחרוזת החיבור
                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");

                // יצירת אובייקט של שאילתת SQL וקישור אותו לחיבור
                SqlCommand mysqlcommand = mySqlConnection.CreateCommand();

                // פתיחת החיבור למסד הנתונים
                mySqlConnection.Open();

                // בניית והגדרת השאילתה שתמחק טבלה בשם המבוסס על שם המשתמש מכינוי טופס ההתחברות
                mysqlcommand.CommandText = $"DROP TABLE {LoginForm.username} ;";

                // ביצוע השאילתה למחיקת הטבלה הנציינת
                mysqlcommand.ExecuteNonQuery();

                // הצגת תיבת הודעה המציינת שהפעולה בוצעה בהצלחה
                MessageBox.Show("All APPS Has Been Deleted");

                // סגירת החיבור למסד הנתונים
                mySqlConnection.Close();


            }
            catch (Exception err)
            {
                // אם חולצה חריגה, יציג תיבת הודעה עם הודעת שגיאה
                MessageBox.Show(err.Message);
            }
        }

    }
}
