using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pc_Man_Game_MOO_ICT
{
    public partial class Form1 : Form
    {
        bool goup, godown, goleft, goright, isGameOver;// הכרזה על משתנים בוליאניים למעקב אחר כיווני תנועה ומצב משחק.


        int score, playerSpeed, redGhostSpeed, yellowGhostSpeed, pinkGhostX, pinkGhostY; // הכרזה על משתנים שלמים למעקב אחר ציונים ומהירויות.

       

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        public Form1()
        {
            InitializeComponent();// מאתחל את מרכיבי הטופס.

            resetGame();// קורא לפונקציה "resetGame" כדי לאתחל את מצב המשחק.

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.Up)// אם מקש "מעלה" נלחץ, הגדר את דגל "גופ" ל-true.
            {
                goup = true;
            }
            if(e.KeyCode == Keys.Down)// אם מקש "למטה" נלחץ, הגדר את דגל ה-"godown" ל-true.
            {
                godown = true;
            }
            if(e.KeyCode == Keys.Left)// אם מקש "שמאל" נלחץ, הגדר את דגל "גולפט" ל-true.
            {
                goleft = true;
            }
            if(e.KeyCode == Keys.Right)// אם מקש "ימין" נלחץ, הגדר את דגל "goright" ל-true.
            {
                goright = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)// אם מקש "מעלה" משוחרר, הגדר את דגל "גופ" ל-false.
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)// אם מקש "Down" משוחרר, הגדר את דגל ה-"godown" ל-false.
            {
                godown = false;
            }
            if (e.KeyCode == Keys.Left)// אם מקש "שמאל" משוחרר, הגדר את דגל "גולפט" ל-false
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)// אם מקש "ימין" משוחרר, הגדר את דגל "goright" ל-false.
            {
                goright = false;
            }
            if(e.KeyCode == Keys.Enter && isGameOver == true)// אם מקש "Enter" שוחרר והמשחק נגמר, קרא לפונקציה "resetGame" כדי להפעיל מחדש את המשחק.
            {
                resetGame();
            }

        }
        
        private void mainGameTimer(object sender, EventArgs e)
        {

            txtScore.Text = "Score: " + score;// עדכן את הניקוד המוצג בתיבת הטקסט "txtScore"

            if (goleft == true)// אם השחקן צריך לזוז שמאלה
            {
                pacman.Left -= playerSpeed;// הזז את ה-"pacman" PictureBox שמאלה.
                pacman.Image = Properties.Resources.left;// שנה את התמונה של "פקמן" לתמונה הפונה שמאלה.
            }
            if (goright == true)// אם השחקן צריך לזוז ימינה
            {
                pacman.Left += playerSpeed; // הזז את ה-"pacman" PictureBox ימינה.
                pacman.Image = Properties.Resources.right;// שנה את התמונה של "פקמן" לתמונה הפונה ימינה.
            }
            if (godown == true)// אם השחקן צריך לזוז למטה
            {
                pacman.Top += playerSpeed;// הזז את ה-"pacman" PictureBox כלפי מטה.
                pacman.Image = Properties.Resources.down;// שנה את התמונה של "פקמן" לתמונה הפונה כלפי מטה.
            }
            if (goup == true)// אם השחקן צריך לעלות למעלה
            {
                pacman.Top -= playerSpeed;// הזז את ה-"pacman" PictureBox כלפי מעלה.
                pacman.Image = Properties.Resources.Up;// שנה את התמונה של "פקמן" לתמונה הפונה כלפי מעלה.
            }

            //if (pacman.Left < -10)// אם "pacman" זז מהגבול השמאלי
            //{
            //    pacman.Left = 680;// עטפו אותו עד הגבול הימני.
            //}
            //if (pacman.Left > 680)// אם "pacman" זז מהגבול הימני
            //{
            //    pacman.Left = -10;// עטפו אותו אל הגבול השמאלי.
            //}

            //if(pacman.Top < -10)// אם "pacman" זז מהגבול העליון
            //{
            //    pacman.Top = 550;// עטפו אותו עד לגבול התחתון.
            //}
            //if(pacman.Top > 550)// אם "pacman" זז מהגבול התחתון
            //{
            //    pacman.Top = 0;// עטפו אותו עד הגבול העליון
            //}

            foreach(Control x in this.Controls)// עברו בלולאה בין כל הפקדים בטופס.
            {
                if(x is PictureBox)// בדוק אם הפקד הוא PictureBox
                {
                    if ((string)x.Tag == "coin" && x.Visible == true) // אם ל-PictureBox יש תג "coin" והוא גלוי
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))// אם "pacman" מצטלב עם המטבע PictureBox
                        {
                            score += 1;// הגדל את הניקוד.
                            x.Visible = false;// הסתר את המטבע PictureBox.
                        }
                        
                    }

                    if((string)x.Tag == "wall")// אם ל-PictureBox יש תג "wall"
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))// אם "pacman" מצטלב עם הקיר PictureBox
                        {
                            //gameOver("You Lose!");// קרא לפונקציה "gameOver" עם ההודעה "You Lose!".
                            if(goleft == true)
                                pacman.Left += playerSpeed;
                            if (goright == true)
                                pacman.Left -= playerSpeed;
                            if (goup == true)
                                pacman.Top += playerSpeed;
                            if (godown == true)
                                pacman.Top -= playerSpeed;
                        }
                        

                    }

                    if((string)x.Tag == "ghost") //אם ל -PictureBox יש תג "ghost"
                    {
                        if (pacman.Bounds.IntersectsWith(x.Bounds))//אם "pacman" מצטלב עם ה-PictureBox הרוחות
                        {
                            gameOver("You Lose!");//הצג תיבת הודעה
                        }
                        if (x.Left > pacman.Left)
                        {
                            x.Left -= yellowGhostSpeed;
                        }
                        if (x.Left < pacman.Left)
                        {
                            x.Left += yellowGhostSpeed;
                        }
                        if (x.Top > pacman.Top)
                        {
                            x.Top -= yellowGhostSpeed;
                        }
                        if (x.Top < pacman.Top)
                        {
                            x.Top += yellowGhostSpeed;
                        }

                    }
                    
                }
            }


            // moving ghosts


            // בדוק אם pinkGhost מגיע לגבולות העליונים או התחתונים.
            if (pinkGhost.Top < 83 || pinkGhost.Top > 770)
            {
                pinkGhostY = -pinkGhostY;// הפוך את pinkGhostY כדי לשנות את הכיוון האנכי שלו.

            }
            // בדוק אם pinkGhost מגיע לגבול השמאלי או הימני.
            if (pinkGhost.Left < 0 || pinkGhost.Left > 620|| pinkGhost.Left < 424 || pinkGhost.Left > 1480)
            {
                pinkGhostX = -pinkGhostX;// הפוך את pinkGhostX כדי לשנות את הכיוון האופקי שלו.
            }
            if (redGhost.Left < 424 || redGhost.Left > 1480 || redGhost.Top < 83 || redGhost.Top > 770)
            {
                redGhostSpeed = -redGhostSpeed;
            }
            if (yellowGhost.Left < 424 || yellowGhost.Left > 1480 || yellowGhost.Top < 83 || yellowGhost.Top > 770)
            {
                yellowGhostSpeed = -yellowGhostSpeed;
            }


            //// בדוק אם הניקוד של השחקן מגיע ל-46, מה שמצביע על ניצחון.
            if (score == 75)
            {
                gameOver("You Win!");// קרא לפונקציית gameOver עם הסמל "אתה מנצח!" הוֹדָעָה.
            }


        }

        private void resetGame()
        {

            txtScore.Text = "Score: 0";// אפס את הניקוד המוצג בתיבת הטקסט "txtScore" ל-0.
            score = 0;// אפס את משתנה הניקוד ל-0.

            // אפס את המהירויות של רוחות הרפאים והשחקן.
            //redGhostSpeed = 0;
            yellowGhostSpeed = 2;
            //pinkGhostX = 0;
            //pinkGhostY = 0;
            playerSpeed = 8;

            isGameOver = false;// הגדר את דגל המשחק לשווא.

            // אפס את עמדות השחקן והרוחות.
            pacman.Left = 754 ;
            pacman.Top = 610;


            redGhost.Left = 853;
            redGhost.Top = 384;

            yellowGhost.Left = 1011;
            yellowGhost.Top = 381;

            pinkGhost.Left = 937;
            pinkGhost.Top = 381;

            // הפוך את כל הפקדים של PictureBox לגלויים.
            foreach (Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                   x.Visible = true;
                }
            }

             // הפעל את טיימר המשחק.
            gameTimer.Start();
        }

        private void gameOver(string message)
        {

            isGameOver = true;// הגדר את דגל המשחק על אמת.

            gameTimer.Stop();// עצור את טיימר המשחק.

            txtScore.Text = "Score: " + score + Environment.NewLine + message;// עדכן את הניקוד המוצג בתיבת הטקסט "txtScore" כך שיכלול את הניקוד ואת הודעת המשחק.

        }


    }
}
