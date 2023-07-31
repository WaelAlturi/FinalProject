using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace Shoot_Out_Game_MOO_ICT
{
    class Bullet
    {
        public string direction;// כיוון הכדור.
        public int bulletLeft;// המיקום השמאלי של הכדור.
        public int bulletTop;// המיקום העליון של הכדור.

        private int speed = 20;// מהירות הכדור.
        private PictureBox bullet = new PictureBox();// הכדור PictureBox.
        private Timer bulletTimer = new Timer();// הטיימר לתנועת כדורים
        System.Media.SoundPlayer media = new System.Media.SoundPlayer();
        
        public void MakeBullet(Form form)
        {
            // הגדר את הכדור PictureBox.
            bullet.BackColor = Color.White;
            bullet.Size = new Size(5,5);
            bullet.Tag = "bullet";
            bullet.Left = bulletLeft;
            bullet.Top = bulletTop;
            bullet.BringToFront();

            // הוסף את התבליט לפקדים של הטופס.
            form.Controls.Add(bullet);

            // הגדר את טיימר הכדורים.
            bulletTimer.Interval = speed;
            bulletTimer.Tick += new EventHandler(BulletTimerEvent);
            bulletTimer.Start();
            //media.SoundLocation = "ShootAudio.wav";
            //media.Play();

        }

        private void BulletTimerEvent(object sender, EventArgs e)
        {
            // הזז את הכדור בכיוון שצוין.
            if (direction == "left")
            {
                bullet.Left -= speed;
            }

            if (direction == "right")
            {
                bullet.Left += speed;
            }

            if (direction == "up")
            {
                bullet.Top -= speed;
            }

            if (direction == "down")
            {
                bullet.Top += speed;
            }
            

            // בדוק אם הכדור מחוץ לתחום.
            //if (bullet.Left < 10 || bullet.Left > 860 || bullet.Top < 10 || bullet.Top > 600)
            //{

            //    bulletTimer.Stop();// עצור והפטר את טיימר הכדורים.
            //    bulletTimer.Dispose();
            //    // השלך את הכדור PictureBox.
            //    bullet.Dispose();
            //    // הגדר את האובייקטים ל-null לאיסוף אשפה.
            //    bulletTimer = null;
            //    bullet = null;
            //}



        }



    }
}
