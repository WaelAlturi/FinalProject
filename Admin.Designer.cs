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
            this.UserInfo_LBL = new System.Windows.Forms.Label();
            this.Users_Data_LB = new System.Windows.Forms.ListBox();
            this.Users_Show_LBL = new System.Windows.Forms.Label();
            this.Admin_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Admin_Panel
            // 
            this.Admin_Panel.BackColor = System.Drawing.Color.Transparent;
            this.Admin_Panel.Controls.Add(this.UserInfo_LBL);
            this.Admin_Panel.Controls.Add(this.Users_Data_LB);
            this.Admin_Panel.Controls.Add(this.Users_Show_LBL);
            this.Admin_Panel.Location = new System.Drawing.Point(12, 107);
            this.Admin_Panel.Name = "Admin_Panel";
            this.Admin_Panel.Size = new System.Drawing.Size(1004, 424);
            this.Admin_Panel.TabIndex = 0;
            // 
            // UserInfo_LBL
            // 
            this.UserInfo_LBL.Font = new System.Drawing.Font("Poor Richard", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserInfo_LBL.Location = new System.Drawing.Point(272, 66);
            this.UserInfo_LBL.Name = "UserInfo_LBL";
            this.UserInfo_LBL.Size = new System.Drawing.Size(396, 345);
            this.UserInfo_LBL.TabIndex = 5;
            this.UserInfo_LBL.Text = "label1";
            // 
            // Users_Data_LB
            // 
            this.Users_Data_LB.Font = new System.Drawing.Font("Poor Richard", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Users_Data_LB.FormattingEnabled = true;
            this.Users_Data_LB.ItemHeight = 31;
            this.Users_Data_LB.Location = new System.Drawing.Point(29, 66);
            this.Users_Data_LB.Name = "Users_Data_LB";
            this.Users_Data_LB.Size = new System.Drawing.Size(237, 345);
            this.Users_Data_LB.TabIndex = 4;
            this.Users_Data_LB.SelectedIndexChanged += new System.EventHandler(this.Users_Data_LB_SelectedIndexChanged);
            // 
            // Users_Show_LBL
            // 
            this.Users_Show_LBL.AutoSize = true;
            this.Users_Show_LBL.Font = new System.Drawing.Font("Poor Richard", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Users_Show_LBL.Location = new System.Drawing.Point(23, 20);
            this.Users_Show_LBL.Name = "Users_Show_LBL";
            this.Users_Show_LBL.Size = new System.Drawing.Size(68, 31);
            this.Users_Show_LBL.TabIndex = 2;
            this.Users_Show_LBL.Text = "Users";
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1028, 720);
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
    }
}