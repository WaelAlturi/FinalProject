namespace FinalProject
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.Admin_Panel = new System.Windows.Forms.Panel();
            this.Reload_BTN = new System.Windows.Forms.Button();
            this.Coins_TB = new System.Windows.Forms.TextBox();
            this.Password_TB = new System.Windows.Forms.TextBox();
            this.Email_TB = new System.Windows.Forms.TextBox();
            this.Update = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.UserInfo_LBL = new System.Windows.Forms.Label();
            this.Users_Data_LB = new System.Windows.Forms.ListBox();
            this.Users_Show_LBL = new System.Windows.Forms.Label();
            this.Back_Button = new System.Windows.Forms.Button();
            this.Admin_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Admin_Panel
            // 
            this.Admin_Panel.BackColor = System.Drawing.Color.Transparent;
            this.Admin_Panel.Controls.Add(this.Reload_BTN);
            this.Admin_Panel.Controls.Add(this.Coins_TB);
            this.Admin_Panel.Controls.Add(this.Password_TB);
            this.Admin_Panel.Controls.Add(this.Email_TB);
            this.Admin_Panel.Controls.Add(this.Update);
            this.Admin_Panel.Controls.Add(this.Delete);
            this.Admin_Panel.Controls.Add(this.UserInfo_LBL);
            this.Admin_Panel.Controls.Add(this.Users_Data_LB);
            this.Admin_Panel.Controls.Add(this.Users_Show_LBL);
            this.Admin_Panel.Location = new System.Drawing.Point(12, 107);
            this.Admin_Panel.Name = "Admin_Panel";
            this.Admin_Panel.Size = new System.Drawing.Size(1004, 424);
            this.Admin_Panel.TabIndex = 0;
            // 
            // Reload_BTN
            // 
            this.Reload_BTN.BackColor = System.Drawing.Color.Transparent;
            this.Reload_BTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Reload_BTN.FlatAppearance.BorderSize = 0;
            this.Reload_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reload_BTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reload_BTN.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Reload_BTN.Location = new System.Drawing.Point(3, 20);
            this.Reload_BTN.Name = "Reload_BTN";
            this.Reload_BTN.Size = new System.Drawing.Size(62, 44);
            this.Reload_BTN.TabIndex = 31;
            this.Reload_BTN.Text = "🔄";
            this.Reload_BTN.UseVisualStyleBackColor = false;
            this.Reload_BTN.Click += new System.EventHandler(this.Reload_BTN_Click);
            // 
            // Coins_TB
            // 
            this.Coins_TB.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Coins_TB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Coins_TB.Enabled = false;
            this.Coins_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Coins_TB.Location = new System.Drawing.Point(446, 140);
            this.Coins_TB.Name = "Coins_TB";
            this.Coins_TB.Size = new System.Drawing.Size(255, 31);
            this.Coins_TB.TabIndex = 10;
            // 
            // Password_TB
            // 
            this.Password_TB.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Password_TB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Password_TB.Enabled = false;
            this.Password_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Password_TB.Location = new System.Drawing.Point(446, 103);
            this.Password_TB.Name = "Password_TB";
            this.Password_TB.Size = new System.Drawing.Size(255, 31);
            this.Password_TB.TabIndex = 9;
            // 
            // Email_TB
            // 
            this.Email_TB.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Email_TB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Email_TB.Enabled = false;
            this.Email_TB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Email_TB.Location = new System.Drawing.Point(446, 66);
            this.Email_TB.Name = "Email_TB";
            this.Email_TB.Size = new System.Drawing.Size(255, 31);
            this.Email_TB.TabIndex = 8;
            // 
            // Update
            // 
            this.Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Update.Location = new System.Drawing.Point(520, 277);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(120, 103);
            this.Update.TabIndex = 7;
            this.Update.Text = "Update  Account";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Delete
            // 
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Delete.Location = new System.Drawing.Point(346, 277);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(120, 103);
            this.Delete.TabIndex = 6;
            this.Delete.Text = "Delete  Account";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // UserInfo_LBL
            // 
            this.UserInfo_LBL.Font = new System.Drawing.Font("Poor Richard", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserInfo_LBL.Location = new System.Drawing.Point(340, 66);
            this.UserInfo_LBL.Name = "UserInfo_LBL";
            this.UserInfo_LBL.Size = new System.Drawing.Size(109, 105);
            this.UserInfo_LBL.TabIndex = 5;
            this.UserInfo_LBL.Text = "Email:\r\nPassword:\r\nCoins:";
            // 
            // Users_Data_LB
            // 
            this.Users_Data_LB.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Users_Data_LB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Users_Data_LB.Font = new System.Drawing.Font("Poor Richard", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Users_Data_LB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Users_Data_LB.FormattingEnabled = true;
            this.Users_Data_LB.ItemHeight = 31;
            this.Users_Data_LB.Location = new System.Drawing.Point(97, 66);
            this.Users_Data_LB.Name = "Users_Data_LB";
            this.Users_Data_LB.Size = new System.Drawing.Size(237, 310);
            this.Users_Data_LB.TabIndex = 4;
            this.Users_Data_LB.SelectedIndexChanged += new System.EventHandler(this.Users_Data_LB_SelectedIndexChanged);
            // 
            // Users_Show_LBL
            // 
            this.Users_Show_LBL.AutoSize = true;
            this.Users_Show_LBL.Font = new System.Drawing.Font("Poor Richard", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Users_Show_LBL.Location = new System.Drawing.Point(91, 20);
            this.Users_Show_LBL.Name = "Users_Show_LBL";
            this.Users_Show_LBL.Size = new System.Drawing.Size(68, 31);
            this.Users_Show_LBL.TabIndex = 2;
            this.Users_Show_LBL.Text = "Users";
            // 
            // Back_Button
            // 
            this.Back_Button.BackColor = System.Drawing.Color.Transparent;
            this.Back_Button.FlatAppearance.BorderSize = 0;
            this.Back_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Back_Button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Back_Button.Location = new System.Drawing.Point(4, 1026);
            this.Back_Button.Name = "Back_Button";
            this.Back_Button.Size = new System.Drawing.Size(99, 63);
            this.Back_Button.TabIndex = 30;
            this.Back_Button.Text = "🔙";
            this.Back_Button.UseVisualStyleBackColor = false;
            this.Back_Button.Click += new System.EventHandler(this.Back_Button_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1934, 1061);
            this.Controls.Add(this.Back_Button);
            this.Controls.Add(this.Admin_Panel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Admin";
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.Admin_Load);
            this.Admin_Panel.ResumeLayout(false);
            this.Admin_Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Admin_Panel;
        private System.Windows.Forms.Label Users_Show_LBL;
        private System.Windows.Forms.ListBox Users_Data_LB;
        private System.Windows.Forms.Label UserInfo_LBL;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.TextBox Coins_TB;
        private System.Windows.Forms.TextBox Password_TB;
        private System.Windows.Forms.TextBox Email_TB;
        private System.Windows.Forms.Button Back_Button;
        private System.Windows.Forms.Button Reload_BTN;
    }
}