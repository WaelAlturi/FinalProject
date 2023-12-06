namespace FinalProject
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.UserName_lbl = new System.Windows.Forms.Label();
            this.Login_Register_btn = new System.Windows.Forms.Button();
            this.UserName_Text = new System.Windows.Forms.TextBox();
            this.PassWord_Text = new System.Windows.Forms.TextBox();
            this.Password_lbl = new System.Windows.Forms.Label();
            this.Email_Text = new System.Windows.Forms.TextBox();
            this.Email_lbl = new System.Windows.Forms.Label();
            this.Login_Register_Panel = new System.Windows.Forms.Panel();
            this.newPassword_Text = new System.Windows.Forms.TextBox();
            this.confirmPassword_Text = new System.Windows.Forms.TextBox();
            this.forgetPassword_BTN = new System.Windows.Forms.Button();
            this.ShowPassword_CB = new System.Windows.Forms.CheckBox();
            this.AddData_Button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Login_Register_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // UserName_lbl
            // 
            this.UserName_lbl.AutoSize = true;
            this.UserName_lbl.BackColor = System.Drawing.Color.Transparent;
            this.UserName_lbl.Font = new System.Drawing.Font("Poor Richard", 12F);
            this.UserName_lbl.ForeColor = System.Drawing.Color.White;
            this.UserName_lbl.Location = new System.Drawing.Point(95, 136);
            this.UserName_lbl.Name = "UserName_lbl";
            this.UserName_lbl.Size = new System.Drawing.Size(76, 19);
            this.UserName_lbl.TabIndex = 0;
            this.UserName_lbl.Text = "UserName:";
            // 
            // Login_Register_btn
            // 
            this.Login_Register_btn.BackColor = System.Drawing.Color.Transparent;
            this.Login_Register_btn.FlatAppearance.BorderSize = 0;
            this.Login_Register_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Login_Register_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Login_Register_btn.ForeColor = System.Drawing.Color.White;
            this.Login_Register_btn.Location = new System.Drawing.Point(227, 255);
            this.Login_Register_btn.Name = "Login_Register_btn";
            this.Login_Register_btn.Size = new System.Drawing.Size(113, 70);
            this.Login_Register_btn.TabIndex = 1;
            this.Login_Register_btn.Text = "Login";
            this.Login_Register_btn.UseVisualStyleBackColor = false;
            this.Login_Register_btn.Click += new System.EventHandler(this.Login_Register_btn_Click);
            // 
            // UserName_Text
            // 
            this.UserName_Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(121)))), ((int)(((byte)(157)))));
            this.UserName_Text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UserName_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.UserName_Text.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.UserName_Text.Font = new System.Drawing.Font("Poor Richard", 12F);
            this.UserName_Text.ForeColor = System.Drawing.Color.Black;
            this.UserName_Text.Location = new System.Drawing.Point(99, 163);
            this.UserName_Text.Multiline = true;
            this.UserName_Text.Name = "UserName_Text";
            this.UserName_Text.Size = new System.Drawing.Size(281, 28);
            this.UserName_Text.TabIndex = 2;
            this.UserName_Text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PassWord_Text
            // 
            this.PassWord_Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(121)))), ((int)(((byte)(157)))));
            this.PassWord_Text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PassWord_Text.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PassWord_Text.Font = new System.Drawing.Font("Poor Richard", 12F);
            this.PassWord_Text.ForeColor = System.Drawing.Color.Black;
            this.PassWord_Text.Location = new System.Drawing.Point(99, 221);
            this.PassWord_Text.Multiline = true;
            this.PassWord_Text.Name = "PassWord_Text";
            this.PassWord_Text.Size = new System.Drawing.Size(281, 28);
            this.PassWord_Text.TabIndex = 4;
            this.PassWord_Text.TextChanged += new System.EventHandler(this.PassWord_Text_TextChanged);
            // 
            // Password_lbl
            // 
            this.Password_lbl.AutoSize = true;
            this.Password_lbl.BackColor = System.Drawing.Color.Transparent;
            this.Password_lbl.Font = new System.Drawing.Font("Poor Richard", 12F);
            this.Password_lbl.ForeColor = System.Drawing.Color.White;
            this.Password_lbl.Location = new System.Drawing.Point(95, 194);
            this.Password_lbl.Name = "Password_lbl";
            this.Password_lbl.Size = new System.Drawing.Size(67, 19);
            this.Password_lbl.TabIndex = 3;
            this.Password_lbl.Text = "Password:";
            // 
            // Email_Text
            // 
            this.Email_Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(121)))), ((int)(((byte)(157)))));
            this.Email_Text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Email_Text.CausesValidation = false;
            this.Email_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.Email_Text.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Email_Text.Font = new System.Drawing.Font("Poor Richard", 12F);
            this.Email_Text.ForeColor = System.Drawing.Color.Black;
            this.Email_Text.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Email_Text.Location = new System.Drawing.Point(99, 105);
            this.Email_Text.Multiline = true;
            this.Email_Text.Name = "Email_Text";
            this.Email_Text.Size = new System.Drawing.Size(281, 28);
            this.Email_Text.TabIndex = 8;
            this.Email_Text.Visible = false;
            // 
            // Email_lbl
            // 
            this.Email_lbl.AutoSize = true;
            this.Email_lbl.BackColor = System.Drawing.Color.Transparent;
            this.Email_lbl.Font = new System.Drawing.Font("Poor Richard", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Email_lbl.ForeColor = System.Drawing.Color.White;
            this.Email_lbl.Location = new System.Drawing.Point(95, 78);
            this.Email_lbl.Name = "Email_lbl";
            this.Email_lbl.Size = new System.Drawing.Size(46, 19);
            this.Email_lbl.TabIndex = 7;
            this.Email_lbl.Text = "Email:";
            this.Email_lbl.Visible = false;
            // 
            // Login_Register_Panel
            // 
            this.Login_Register_Panel.BackColor = System.Drawing.Color.Transparent;
            this.Login_Register_Panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Login_Register_Panel.Controls.Add(this.newPassword_Text);
            this.Login_Register_Panel.Controls.Add(this.confirmPassword_Text);
            this.Login_Register_Panel.Controls.Add(this.forgetPassword_BTN);
            this.Login_Register_Panel.Controls.Add(this.ShowPassword_CB);
            this.Login_Register_Panel.Controls.Add(this.AddData_Button);
            this.Login_Register_Panel.Controls.Add(this.Email_Text);
            this.Login_Register_Panel.Controls.Add(this.UserName_lbl);
            this.Login_Register_Panel.Controls.Add(this.Email_lbl);
            this.Login_Register_Panel.Controls.Add(this.Login_Register_btn);
            this.Login_Register_Panel.Controls.Add(this.PassWord_Text);
            this.Login_Register_Panel.Controls.Add(this.UserName_Text);
            this.Login_Register_Panel.Controls.Add(this.Password_lbl);
            this.Login_Register_Panel.Location = new System.Drawing.Point(400, 158);
            this.Login_Register_Panel.Name = "Login_Register_Panel";
            this.Login_Register_Panel.Size = new System.Drawing.Size(483, 441);
            this.Login_Register_Panel.TabIndex = 9;
            // 
            // newPassword_Text
            // 
            this.newPassword_Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(121)))), ((int)(((byte)(157)))));
            this.newPassword_Text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.newPassword_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.newPassword_Text.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.newPassword_Text.Font = new System.Drawing.Font("Poor Richard", 12F);
            this.newPassword_Text.ForeColor = System.Drawing.Color.Black;
            this.newPassword_Text.Location = new System.Drawing.Point(99, 163);
            this.newPassword_Text.Multiline = true;
            this.newPassword_Text.Name = "newPassword_Text";
            this.newPassword_Text.Size = new System.Drawing.Size(281, 28);
            this.newPassword_Text.TabIndex = 14;
            this.newPassword_Text.Visible = false;
            // 
            // confirmPassword_Text
            // 
            this.confirmPassword_Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(121)))), ((int)(((byte)(157)))));
            this.confirmPassword_Text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.confirmPassword_Text.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.confirmPassword_Text.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.confirmPassword_Text.Font = new System.Drawing.Font("Poor Richard", 12F);
            this.confirmPassword_Text.ForeColor = System.Drawing.Color.Black;
            this.confirmPassword_Text.Location = new System.Drawing.Point(99, 221);
            this.confirmPassword_Text.Multiline = true;
            this.confirmPassword_Text.Name = "confirmPassword_Text";
            this.confirmPassword_Text.Size = new System.Drawing.Size(281, 28);
            this.confirmPassword_Text.TabIndex = 13;
            this.confirmPassword_Text.Visible = false;
            // 
            // forgetPassword_BTN
            // 
            this.forgetPassword_BTN.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.forgetPassword_BTN.BackColor = System.Drawing.Color.Transparent;
            this.forgetPassword_BTN.FlatAppearance.BorderSize = 0;
            this.forgetPassword_BTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.forgetPassword_BTN.Font = new System.Drawing.Font("Miriam Fixed", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forgetPassword_BTN.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.forgetPassword_BTN.Location = new System.Drawing.Point(46, 354);
            this.forgetPassword_BTN.Name = "forgetPassword_BTN";
            this.forgetPassword_BTN.Size = new System.Drawing.Size(175, 48);
            this.forgetPassword_BTN.TabIndex = 12;
            this.forgetPassword_BTN.Text = "I Forget Password";
            this.forgetPassword_BTN.UseVisualStyleBackColor = false;
            this.forgetPassword_BTN.Click += new System.EventHandler(this.forgetPassword_BTN_Click);
            // 
            // ShowPassword_CB
            // 
            this.ShowPassword_CB.AutoSize = true;
            this.ShowPassword_CB.Font = new System.Drawing.Font("Poor Richard", 12F);
            this.ShowPassword_CB.ForeColor = System.Drawing.Color.White;
            this.ShowPassword_CB.Location = new System.Drawing.Point(103, 264);
            this.ShowPassword_CB.Name = "ShowPassword_CB";
            this.ShowPassword_CB.Size = new System.Drawing.Size(118, 23);
            this.ShowPassword_CB.TabIndex = 11;
            this.ShowPassword_CB.Text = "Show Password";
            this.ShowPassword_CB.UseVisualStyleBackColor = true;
            this.ShowPassword_CB.CheckedChanged += new System.EventHandler(this.ShowPassword_CB_CheckedChanged);
            // 
            // AddData_Button
            // 
            this.AddData_Button.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AddData_Button.BackColor = System.Drawing.Color.Transparent;
            this.AddData_Button.FlatAppearance.BorderSize = 0;
            this.AddData_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddData_Button.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddData_Button.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.AddData_Button.Location = new System.Drawing.Point(245, 366);
            this.AddData_Button.Name = "AddData_Button";
            this.AddData_Button.Size = new System.Drawing.Size(66, 25);
            this.AddData_Button.TabIndex = 10;
            this.AddData_Button.Text = "Register";
            this.AddData_Button.UseVisualStyleBackColor = false;
            this.AddData_Button.Click += new System.EventHandler(this.AddData_Button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 960);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(195, 131);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1120, 698);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Login_Register_Panel);
            this.DoubleBuffered = true;
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load_1);
            this.Login_Register_Panel.ResumeLayout(false);
            this.Login_Register_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label UserName_lbl;
        private System.Windows.Forms.TextBox UserName_Text;
        private System.Windows.Forms.TextBox PassWord_Text;
        private System.Windows.Forms.Label Password_lbl;
        private System.Windows.Forms.TextBox Email_Text;
        private System.Windows.Forms.Label Email_lbl;
        private System.Windows.Forms.Button Login_Register_btn;
        private System.Windows.Forms.Panel Login_Register_Panel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button AddData_Button;
        private System.Windows.Forms.CheckBox ShowPassword_CB;
        private System.Windows.Forms.Button forgetPassword_BTN;
        private System.Windows.Forms.TextBox newPassword_Text;
        private System.Windows.Forms.TextBox confirmPassword_Text;
    }
}

