namespace FinalProject
{
    partial class HomeScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeScreen));
            this.Coin = new System.Windows.Forms.Label();
            this.TTDD = new System.Windows.Forms.DateTimePicker();
            this.DateWindow = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.BuyCoins = new System.Windows.Forms.Button();
            this.DollarSign = new System.Windows.Forms.Label();
            this.Libary_Panel = new System.Windows.Forms.Panel();
            this.BREAKOUT = new System.Windows.Forms.Button();
            this.ZOMBIEGAME = new System.Windows.Forms.Button();
            this.PACMAN = new System.Windows.Forms.Button();
            this.addShortCut = new System.Windows.Forms.Button();
            this.Menu_Button = new System.Windows.Forms.Button();
            this.Menu_Panel = new System.Windows.Forms.Panel();
            this.Admin_Button = new System.Windows.Forms.Button();
            this.Exit_Button = new System.Windows.Forms.Button();
            this.Logout_Button = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Reload_BTN = new System.Windows.Forms.Button();
            this.deleteAllShortCut = new System.Windows.Forms.Button();
            this.Libary_Panel.SuspendLayout();
            this.Menu_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Coin
            // 
            this.Coin.BackColor = System.Drawing.Color.Transparent;
            this.Coin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Coin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Coin.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Coin.Location = new System.Drawing.Point(687, 9);
            this.Coin.Name = "Coin";
            this.Coin.Size = new System.Drawing.Size(100, 20);
            this.Coin.TabIndex = 0;
            this.Coin.Text = "0";
            // 
            // TTDD
            // 
            this.TTDD.CalendarMonthBackground = System.Drawing.SystemColors.Info;
            this.TTDD.Location = new System.Drawing.Point(246, 2);
            this.TTDD.Name = "TTDD";
            this.TTDD.Size = new System.Drawing.Size(200, 20);
            this.TTDD.TabIndex = 1;
            // 
            // DateWindow
            // 
            this.DateWindow.BackColor = System.Drawing.Color.Transparent;
            this.DateWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.DateWindow.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.DateWindow.Location = new System.Drawing.Point(243, 2);
            this.DateWindow.Name = "DateWindow";
            this.DateWindow.Size = new System.Drawing.Size(214, 20);
            this.DateWindow.TabIndex = 3;
            this.DateWindow.Text = "0";
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // BuyCoins
            // 
            this.BuyCoins.BackColor = System.Drawing.Color.Transparent;
            this.BuyCoins.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BuyCoins.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.BuyCoins.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.BuyCoins.Location = new System.Drawing.Point(771, 9);
            this.BuyCoins.Name = "BuyCoins";
            this.BuyCoins.Size = new System.Drawing.Size(49, 31);
            this.BuyCoins.TabIndex = 5;
            this.BuyCoins.Text = "💲";
            this.BuyCoins.UseVisualStyleBackColor = false;
            this.BuyCoins.Click += new System.EventHandler(this.BuyCoins_Click);
            // 
            // DollarSign
            // 
            this.DollarSign.BackColor = System.Drawing.Color.Transparent;
            this.DollarSign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DollarSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.DollarSign.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.DollarSign.Location = new System.Drawing.Point(677, 9);
            this.DollarSign.Name = "DollarSign";
            this.DollarSign.Size = new System.Drawing.Size(14, 20);
            this.DollarSign.TabIndex = 6;
            this.DollarSign.Text = "$";
            // 
            // Libary_Panel
            // 
            this.Libary_Panel.BackColor = System.Drawing.Color.Transparent;
            this.Libary_Panel.Controls.Add(this.BREAKOUT);
            this.Libary_Panel.Controls.Add(this.ZOMBIEGAME);
            this.Libary_Panel.Controls.Add(this.PACMAN);
            this.Libary_Panel.Controls.Add(this.addShortCut);
            this.Libary_Panel.Location = new System.Drawing.Point(345, 139);
            this.Libary_Panel.Name = "Libary_Panel";
            this.Libary_Panel.Size = new System.Drawing.Size(1178, 313);
            this.Libary_Panel.TabIndex = 7;
            // 
            // BREAKOUT
            // 
            this.BREAKOUT.BackColor = System.Drawing.Color.Transparent;
            this.BREAKOUT.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BREAKOUT.BackgroundImage")));
            this.BREAKOUT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BREAKOUT.FlatAppearance.BorderSize = 0;
            this.BREAKOUT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BREAKOUT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.BREAKOUT.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.BREAKOUT.Location = new System.Drawing.Point(605, 73);
            this.BREAKOUT.Name = "BREAKOUT";
            this.BREAKOUT.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.BREAKOUT.Size = new System.Drawing.Size(259, 186);
            this.BREAKOUT.TabIndex = 4;
            this.BREAKOUT.Text = "200";
            this.BREAKOUT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BREAKOUT.UseVisualStyleBackColor = false;
            this.BREAKOUT.Click += new System.EventHandler(this.BREAKOUT_Click);
            // 
            // ZOMBIEGAME
            // 
            this.ZOMBIEGAME.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ZOMBIEGAME.BackgroundImage")));
            this.ZOMBIEGAME.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ZOMBIEGAME.FlatAppearance.BorderSize = 0;
            this.ZOMBIEGAME.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ZOMBIEGAME.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ZOMBIEGAME.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.ZOMBIEGAME.Location = new System.Drawing.Point(329, 73);
            this.ZOMBIEGAME.Name = "ZOMBIEGAME";
            this.ZOMBIEGAME.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.ZOMBIEGAME.Size = new System.Drawing.Size(259, 186);
            this.ZOMBIEGAME.TabIndex = 3;
            this.ZOMBIEGAME.Text = "300";
            this.ZOMBIEGAME.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ZOMBIEGAME.UseVisualStyleBackColor = true;
            this.ZOMBIEGAME.Click += new System.EventHandler(this.ZOMBIEGAME_Click);
            // 
            // PACMAN
            // 
            this.PACMAN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PACMAN.BackgroundImage")));
            this.PACMAN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PACMAN.FlatAppearance.BorderSize = 0;
            this.PACMAN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PACMAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.PACMAN.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.PACMAN.Location = new System.Drawing.Point(45, 73);
            this.PACMAN.Name = "PACMAN";
            this.PACMAN.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.PACMAN.Size = new System.Drawing.Size(259, 186);
            this.PACMAN.TabIndex = 2;
            this.PACMAN.Text = "100";
            this.PACMAN.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.PACMAN.UseVisualStyleBackColor = true;
            this.PACMAN.Click += new System.EventHandler(this.PACMAN_Click);
            // 
            // addShortCut
            // 
            this.addShortCut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addShortCut.FlatAppearance.BorderSize = 0;
            this.addShortCut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addShortCut.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addShortCut.ForeColor = System.Drawing.SystemColors.Desktop;
            this.addShortCut.Location = new System.Drawing.Point(892, 73);
            this.addShortCut.Name = "addShortCut";
            this.addShortCut.Size = new System.Drawing.Size(259, 186);
            this.addShortCut.TabIndex = 1;
            this.addShortCut.Text = "🎮🕹️👾➕";
            this.addShortCut.UseVisualStyleBackColor = true;
            this.addShortCut.Click += new System.EventHandler(this.addShortCut_Click);
            // 
            // Menu_Button
            // 
            this.Menu_Button.BackColor = System.Drawing.Color.Transparent;
            this.Menu_Button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Menu_Button.BackgroundImage")));
            this.Menu_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Menu_Button.FlatAppearance.BorderSize = 0;
            this.Menu_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Menu_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 2.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Menu_Button.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Menu_Button.Location = new System.Drawing.Point(-1, 2);
            this.Menu_Button.Name = "Menu_Button";
            this.Menu_Button.Size = new System.Drawing.Size(61, 56);
            this.Menu_Button.TabIndex = 2;
            this.Menu_Button.Text = ".";
            this.Menu_Button.UseVisualStyleBackColor = false;
            this.Menu_Button.Click += new System.EventHandler(this.Menu_Button_Click);
            // 
            // Menu_Panel
            // 
            this.Menu_Panel.BackColor = System.Drawing.Color.Transparent;
            this.Menu_Panel.Controls.Add(this.Admin_Button);
            this.Menu_Panel.Controls.Add(this.Exit_Button);
            this.Menu_Panel.Controls.Add(this.Logout_Button);
            this.Menu_Panel.Location = new System.Drawing.Point(66, 2);
            this.Menu_Panel.Name = "Menu_Panel";
            this.Menu_Panel.Size = new System.Drawing.Size(118, 124);
            this.Menu_Panel.TabIndex = 8;
            this.Menu_Panel.Visible = false;
            // 
            // Admin_Button
            // 
            this.Admin_Button.FlatAppearance.BorderSize = 0;
            this.Admin_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Admin_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Admin_Button.Location = new System.Drawing.Point(1, 86);
            this.Admin_Button.Name = "Admin_Button";
            this.Admin_Button.Size = new System.Drawing.Size(117, 36);
            this.Admin_Button.TabIndex = 4;
            this.Admin_Button.Text = "Admin";
            this.Admin_Button.UseVisualStyleBackColor = true;
            this.Admin_Button.Visible = false;
            this.Admin_Button.Click += new System.EventHandler(this.Admin_Button_Click);
            // 
            // Exit_Button
            // 
            this.Exit_Button.FlatAppearance.BorderSize = 0;
            this.Exit_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Exit_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Exit_Button.Location = new System.Drawing.Point(0, 44);
            this.Exit_Button.Name = "Exit_Button";
            this.Exit_Button.Size = new System.Drawing.Size(117, 36);
            this.Exit_Button.TabIndex = 3;
            this.Exit_Button.Text = "Exit";
            this.Exit_Button.UseVisualStyleBackColor = true;
            this.Exit_Button.Click += new System.EventHandler(this.Exit_Button_Click);
            // 
            // Logout_Button
            // 
            this.Logout_Button.FlatAppearance.BorderSize = 0;
            this.Logout_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Logout_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Logout_Button.Location = new System.Drawing.Point(0, 2);
            this.Logout_Button.Name = "Logout_Button";
            this.Logout_Button.Size = new System.Drawing.Size(117, 36);
            this.Logout_Button.TabIndex = 2;
            this.Logout_Button.Text = "Logout";
            this.Logout_Button.UseVisualStyleBackColor = true;
            this.Logout_Button.Click += new System.EventHandler(this.Logout_Button_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Reload_BTN
            // 
            this.Reload_BTN.BackColor = System.Drawing.Color.Transparent;
            this.Reload_BTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Reload_BTN.FlatAppearance.BorderSize = 0;
            this.Reload_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reload_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reload_BTN.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Reload_BTN.Location = new System.Drawing.Point(264, 212);
            this.Reload_BTN.Name = "Reload_BTN";
            this.Reload_BTN.Size = new System.Drawing.Size(62, 44);
            this.Reload_BTN.TabIndex = 5;
            this.Reload_BTN.Text = "🔄";
            this.Reload_BTN.UseVisualStyleBackColor = false;
            this.Reload_BTN.Click += new System.EventHandler(this.Reload_BTN_Click);
            // 
            // deleteAllShortCut
            // 
            this.deleteAllShortCut.BackColor = System.Drawing.Color.Transparent;
            this.deleteAllShortCut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deleteAllShortCut.FlatAppearance.BorderSize = 0;
            this.deleteAllShortCut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteAllShortCut.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteAllShortCut.ForeColor = System.Drawing.SystemColors.Desktop;
            this.deleteAllShortCut.Location = new System.Drawing.Point(264, 289);
            this.deleteAllShortCut.Name = "deleteAllShortCut";
            this.deleteAllShortCut.Size = new System.Drawing.Size(62, 44);
            this.deleteAllShortCut.TabIndex = 9;
            this.deleteAllShortCut.Text = "❎";
            this.deleteAllShortCut.UseVisualStyleBackColor = false;
            this.deleteAllShortCut.Click += new System.EventHandler(this.deleteAllShortCut_Click);
            // 
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1553, 822);
            this.Controls.Add(this.deleteAllShortCut);
            this.Controls.Add(this.Reload_BTN);
            this.Controls.Add(this.Menu_Panel);
            this.Controls.Add(this.Menu_Button);
            this.Controls.Add(this.Libary_Panel);
            this.Controls.Add(this.DollarSign);
            this.Controls.Add(this.BuyCoins);
            this.Controls.Add(this.DateWindow);
            this.Controls.Add(this.TTDD);
            this.Controls.Add(this.Coin);
            this.DoubleBuffered = true;
            this.Name = "HomeScreen";
            this.Text = "HomeScreen";
            this.Load += new System.EventHandler(this.HomeScreen_Load);
            this.Libary_Panel.ResumeLayout(false);
            this.Menu_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker TTDD;
        private System.Windows.Forms.Label DateWindow;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Button BuyCoins;
        private System.Windows.Forms.Label Coin;
        private System.Windows.Forms.Label DollarSign;
        private System.Windows.Forms.Panel Libary_Panel;
        private System.Windows.Forms.Button addShortCut;
        private System.Windows.Forms.Button Menu_Button;
        private System.Windows.Forms.Panel Menu_Panel;
        private System.Windows.Forms.Button Exit_Button;
        private System.Windows.Forms.Button Logout_Button;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button PACMAN;
        private System.Windows.Forms.Button ZOMBIEGAME;
        private System.Windows.Forms.Button BREAKOUT;
        private System.Windows.Forms.Button Reload_BTN;
        private System.Windows.Forms.Button Admin_Button;
        private System.Windows.Forms.Button deleteAllShortCut;
    }
}