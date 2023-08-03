using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shoot_Out_Game_MOO_ICT
{
    public partial class Form1 : Form
    {

        bool goLeft, goRight, goUp, goDown, gameOver;// דגלים לתנועת שחקן ומצב משחק.
        string facing = "up";// הכיוון שאליו פונה השחקן.
        int playerHealth = 100;// בריאותו של השחקן.
        int speed = 10;// מהירות התנועה של השחקן.
        int ammo = 10;// ספירת התחמושת של השחקן.
        int zombieSpeed = 3;// מהירות הזומבים.
        Random randNum = new Random();// מחולל מספר אקראי.
        int score;// הניקוד של השחקן.
        List<PictureBox> zombiesList = new List<PictureBox>();// רשימה לאחסון זומבים PictureBoxes.
        System.Media.SoundPlayer media = new System.Media.SoundPlayer();


        public Form1()
        {
            InitializeComponent();
            RestartGame();
            //this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            media.SoundLocation = "BackGroundAudio.wav";
            media.Play();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            
            if (playerHealth > 1)// עדכן את ערך סרגל הבריאות אם מצבו הבריאותי של השחקן גדול מ-1.
            {
                healthBar.Value = playerHealth;
            }
            else
            {
                // אם מצבו הבריאותי של השחקן קטן מ-1 או שווה ל-1, המשחק נגמר.
                gameOver = true;
                player.Image = Properties.Resources.dead;
                GameTimer.Stop();// עצור את טיימר המשחק.
            }

            txtAmmo.Text = "Ammo: " + ammo;// עדכן את תצוגת התחמושת.
            txtScore.Text = "Kills: " + score;// עדכן את תצוגת הניקוד.

            // הזיזו את השחקן על סמך דגלי הכיוון ובדקו את גבולות חלון המשחק.
            if (goLeft == true && player.Left > 0)
            {
                player.Left -= speed;
            }
            if (goRight == true && player.Left + player.Width < this.ClientSize.Width)
            {
                player.Left += speed;
            }
            if (goUp == true && player.Top > 45)
            {
                player.Top -= speed;
            }
            if (goDown == true && player.Top + player.Height < this.ClientSize.Height)
            {
                player.Top += speed;
            }


            // חזור דרך הפקדים בחלון המשחק.
            foreach (Control x in this.Controls)
            {
                // בדוק אם הפקד הוא PictureBox עם התגית "תחמושת"
                if (x is PictureBox && (string)x.Tag == "ammo")
                {
                    // בדוק אם הנגן מתנגש בתחמושת.
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);// הסר את התחמושת מחלון המשחק.
                        ((PictureBox)x).Dispose();// השלך את התחמושת PictureBox.
                        ammo += 5;// הגדל את ספירת התחמושת.
                        media.SoundLocation = "Ammo.wav";
                        media.Play();

                    }
                }


                if (x is PictureBox && (string)x.Tag == "zombie")// בדוק אם הפקד הוא PictureBox עם התגית "זומבי".
                {
                    // בדוק אם השחקן מתנגש בזומבי.
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        // הפחת את בריאותו של השחקן.
                        playerHealth -= 1;
                    }

                    // הזז את הזומבי לעבר השחקן על סמך מיקומו.
                    if (x.Left > player.Left)
                    {
                        x.Left -= zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zleft;
                    }
                    if (x.Left < player.Left)
                    {
                        x.Left += zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zright;
                    }
                    if (x.Top > player.Top)
                    {
                        x.Top -= zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zup;
                    }
                    if (x.Top < player.Top)
                    {
                        x.Top += zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zdown;
                    }

                }


                // חזור על הפקדים שוב כדי לבדוק אם יש התנגשויות כדורים-זומבים.
                foreach (Control j in this.Controls)
                {
                    // בדוק אם j הוא PictureBox עם התג "bullet" ו-x הוא PictureBox עם התג "זומב".
                    if (j is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string)x.Tag == "zombie" )
                    {
                        // בדוק אם כדור מתנגש בזומבי.
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            score++;// הגדל את הציון.

                            this.Controls.Remove(j);// הסר את הכדור מחלון המשחק.
                            ((PictureBox)j).Dispose();// השלך את הכדור PictureBox.
                            this.Controls.Remove(x);// הסר את הזומבי מחלון המשחק.
                            ((PictureBox)x).Dispose();// השלך את ה-PictureBox של הזומבים.
                            zombiesList.Remove(((PictureBox)x));// הסר את הזומבי מרשימת הזומבים.
                            MakeZombies();// צור זומבי חדש.
                        }
                    }
                }


            }


        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {

            if (gameOver == true)
            {
                return;
            }

            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;// הגדר את דגל goLeft ל-true.
                facing = "left";// הגדר את הכיוון הפונה לשמאל.
                player.Image = Properties.Resources.left;// שנה את תמונת הנגן לכיוון שמאל.
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = true;// הגדר את דגל goRight ל-true
                facing = "right";// הגדר את הכיוון הפונה ימינה.
                player.Image = Properties.Resources.right;// שנה את תמונת השחקן לפנים ימינה.
            }

            if (e.KeyCode == Keys.Up)
            {
                goUp = true;// הגדר את דגל goUp ל-true.
                facing = "up";// הגדר את הכיוון כלפי מעלה.
                player.Image = Properties.Resources.up;// שנה את תמונת הנגן לכיוון כלפי מעלה.
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = true;// הגדר את דגל goDown ל-true.
                facing = "down";// הגדר את הכיוון כלפי מטה.
                player.Image = Properties.Resources.down;// שנה את תמונת הנגן לכיוון כלפי מטה
            }



        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)// בדוק אם מקש החץ שמאלה משוחרר.
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.Right)// בדוק אם מקש החץ ימינה משוחרר.
            {
                goRight = false;
            }

            if (e.KeyCode == Keys.Up)// בדוק אם מקש החץ למעלה משוחרר.
            {
                goUp = false;
            }

            if (e.KeyCode == Keys.Down)// בדוק אם מקש החץ למטה משוחרר.
            {
                goDown = false;
            }

            if (e.KeyCode == Keys.Space && ammo > 0 && gameOver == false)// בדוק אם מקש הרווח שוחרר ויש תחמושת והמשחק לא נגמר.
            {
                ammo--;// הקטנת ספירת התחמושת.
                ShootBullet(facing);// ירה כדור בכיוון הפונה הנוכחי.


                if (ammo < 1)// בדוק אם לא נשארה תחמושת.
                {
                    DropAmmo();// זרוק תחמושת חדשה.
                }
            }

            if (e.KeyCode == Keys.Enter && gameOver == true)// בדוק אם מקש האנטר נלחץ והמשחק הסתיים.
            {
                RestartGame();// הפעל מחדש את המשחק.
            }

        }

        private void ShootBullet(string direction)
        {
            Bullet shootBullet = new Bullet();// צור אובייקט תבליט חדש.
            shootBullet.direction = direction;
            shootBullet.bulletLeft = player.Left + (player.Width / 2);
            shootBullet.bulletTop = player.Top + (player.Height / 2);
            shootBullet.MakeBullet(this);
            media.SoundLocation = "ShootAudio.wav";
            media.Play();

        }

        private void MakeZombies()
        {
            // צור PictureBox זומבי חדש.
            PictureBox zombie = new PictureBox();
            zombie.Tag = "zombie";
            zombie.Image = Properties.Resources.zdown;
            // הגדר את מיקום הזומבי באופן אקראי בתוך חלון המשחק.
            zombie.Left = randNum.Next(0, 900);
            zombie.Top = randNum.Next(0, 800);
            zombie.SizeMode = PictureBoxSizeMode.AutoSize;
            zombiesList.Add(zombie);// הוסף את ה-PictureBox של הזומבים ל-ZombieList.
            this.Controls.Add(zombie);// הוסף את ה-PictureBox של הזומבים לחלון המשחק.
            player.BringToFront();// הביאו את ה-PictureBox של הנגן לחזית.
        }

        private void DropAmmo()
        {
            // צור PictureBox חדש עבור התחמושת.
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.ammo_Image;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            // הגדר את מיקום התחמושת באופן אקראי בתוך חלון המשחק.
            ammo.Left = randNum.Next(10, this.ClientSize.Width - ammo.Width);
            ammo.Top = randNum.Next(60, this.ClientSize.Height - ammo.Height);

            ammo.Tag = "ammo";// הקצה תג לתחמושת PictureBox.
            this.Controls.Add(ammo);// הוסף את התחמושת PictureBox לחלון המשחק.

            ammo.BringToFront();// הביאו את התחמושת PictureBox לחזית.
            player.BringToFront();// הביאו את ה-PictureBox של הנגן לחזית.
        }

        private void RestartGame()
        {
           
            player.Image = Properties.Resources.up;// הגדר את תמונת הנגן כלפי מעלה.

            // הסר את כל ה-PictureBoxes של הזומבים מחלון המשחק.
            foreach (PictureBox i in zombiesList)
            {
                this.Controls.Remove(i);
            }

            zombiesList.Clear();// נקה את רשימת הזומבים.

            for (int i = 0; i < 3; i++)// צור זומבים חדשים.
            {
                MakeZombies();
            }
            // אפס משתני תנועה. 
            goUp = false;
            goDown = false;
            goLeft = false;
            goRight = false;
            gameOver = false;

            playerHealth = 100;// אפס את מצבו הבריאותי של השחקן.
            score = 0;// אפס את הניקוד.
            ammo = 10;// אפס את ספירת התחמושת.

            GameTimer.Start();// הפעל את טיימר המשחק.
        }

    }
}
