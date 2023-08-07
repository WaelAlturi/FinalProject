using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Breakout
{
    public partial class Form1 : Form
    {

        bool goLeft;// משתנה בוליאני לציון האם השחקן מתקדם לצד שמאל.
        bool goRight;// משתנה בוליאני לציון האם השחקן מתקדם לצד ימין.
        bool isGameOver;// משתנה בוליאני לציון האם המשחק נגמר.

        int score;// משתנה לאחסון ניקוד השחקן.
        int ballx;// משתנה לאחסון תנועה בציר האופקי של הכדור.
        int bally;// משתנה לאחסון תנועה בציר האנכי של הכדור.
        int playerSpeed;// משתנה לאחסון מהירות השחקן.

        Random rnd = new Random(); // אובייקט Random ליצירת מספרים אקראיים.

        PictureBox[] blockArray; // מערך לאחסון הבלוקים במשחק.


        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;

            PlaceBlocks(); // הפעלת הפונקציה PlaceBlocks() להצגת הבלוקים במשחק.
        }

        private void setupGame()
        {
            // עריכת המשחק לפתיחה.

            isGameOver = false;// השמת ערך false למשתנה הבוליאני isGameOver.
            score = 0;// איפוס הניקוד של השחקן.
            ballx = 5;// הגדרת תנועה התחלתית לכדור בציר האופקי.
            bally = 5;// הגדרת תנועה התחלתית לכדור בציר האנכי.
            playerSpeed = 12;// הגדרת מהירות השחקן ל-12.

            // הצגת הניקוד הנוכחי של השחקן בתיבת הטקסט.
            txtScore.Text = "Score: " + score;

            // פתיחת המסגרת של הכדור והשחקן במקומות ההתחלתיים
            ball.Left = 376;
            ball.Top = 328;
            player.Left = 347;


            gameTImer.Start();// הפעלת הטיימר של המשחק.

            // הגדרת צבע רנדומלי לבלוקים במשחק.
            foreach (Control x in this.Controls)
            {
                if(x is PictureBox && (string)x.Tag == "blocks")
                {
                    x.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                }
            }
        }


        private void gameOver(string message)
        {
            // סיום המשחק עם הודעה לשחקן.

            isGameOver = true;// השמת ערך true למשתנה הבוליאני isGameOver.
            gameTImer.Stop();// עצירת הטיימר של המשחק.

            // הצגת הניקוד הסופי של השחקן והודעת סיום.
            txtScore.Text = "Score: " + score + " " + message;
        }

        private void PlaceBlocks()
        {
            // הצגת הבלוקים במקומות הנכונים.

            blockArray = new PictureBox[15];

            int a = 0;

            int top = 50;
            int left = 100;

            for(int i = 0; i < blockArray.Length; i++)
            {
                // יצירת PictureBox חדש לכל בלוק והגדרת מאפייניו.
                blockArray[i] = new PictureBox();
                blockArray[i].Height = 32;
                blockArray[i].Width = 100;
                blockArray[i].Tag = "blocks";
                blockArray[i].BackColor = Color.White;


                if(a == 5)
                {
                    top = top + 50;
                    left = 100;
                    a = 0;
                }

                if(a < 5)
                {
                    a++;
                    blockArray[i].Left = left;
                    blockArray[i].Top = top;
                    this.Controls.Add(blockArray[i]);
                    left = left + 130;
                }

            }
            setupGame(); // פתיחת המשחק לאחר הצגת הבלוקים.
        }

        private void removeBlocks()
        {
            // הסרת כל הבלוקים מהמשחק.

            foreach (PictureBox x in blockArray)
            {
                this.Controls.Remove(x);
            }
        }



        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            // תהליך המשחק בכל צעד של הטיימר.

            txtScore.Text = "Score: " + score;// עדכון הניקוד בתיבת הטקסט.

            // תנועת השחקן והכדור.
            if (goLeft == true && player.Left > 0)
            {
                player.Left -= playerSpeed;
            }

            if (goRight == true && player.Left < 700)
            {
                player.Left += playerSpeed;
            }

            ball.Left += ballx;
            ball.Top += bally;

            // התקדמות הכדור ובדיקת פיגוע בקירות המסגרת.

            if (ball.Left < 0 || ball.Left > 775)
            {
                ballx = -ballx;
            }
            if (ball.Top < 0)
            {
                bally = -bally;
            }

            // פיגוע בשחקן ושינוי תנועת הכדור בהתאם.

            if (ball.Bounds.IntersectsWith(player.Bounds))
            {

                ball.Top = 463;

                bally = rnd.Next(5, 12) * -1;

                if (ballx < 0)
                {
                    ballx = rnd.Next(5, 12) * -1;
                }
                else
                {
                    ballx = rnd.Next(5, 12);
                }
            }

            // פיגוע בבלוקים וציון נקודות.

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "blocks")
                {
                    if(ball.Bounds.IntersectsWith(x.Bounds))
                    {
                        score += 1;

                        bally = -bally; // הגדלת הניקוד בכדי נקודה עבור כל בלוק פגוע.

                        this.Controls.Remove(x); // הסרת הבלוק מהמשחק.
                    }
                }

            }

            // סיום המשחק עם ניקוד מקסימלי.

            if (score == 15)
            {
                gameOver("You Win!! Press Enter to Play Again");
            }

            // סיום המשחק עם ניקוד מינימלי.

            if (ball.Top > 580)
            {
                gameOver("You Lose!! Press Enter to try again");
            }



        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            // השקפת השחקן במקלע תנועה.


            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if(e.KeyCode == Keys.Right)
            {
                goRight = true;
            }

        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            // עצירת השחקן כאשר המקשים מופקעים.

            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            // התחלת משחק חדש עם לחיצה על Enter כאשר המשחק הסתיים.
            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                removeBlocks();// הסרת הבלוקים הקודמים מהמשחק
                PlaceBlocks();// הצגת בלוקים חדשים למשחק חדש.
            }
        }
    }
}
