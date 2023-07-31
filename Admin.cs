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
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();

            GetUser();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }
        public void GetUser()
        {
            try
            {
          
                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlCommand.CommandText = "Select UserName from Login;";
                mySqlConnection.Open();
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                while (mySqlDataReader.Read())
                {
                    Users_Data_LB.Items.Add(mySqlDataReader["UserName"].ToString());
                }
                mySqlDataReader.Close();
                mySqlConnection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private string[] UserInfo(string username)
        {
            try
            {
                string[] str = new string[3];
                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlCommand.CommandText = "Select Email,Password,Coins from Login where UserName='" + username + "';";
                mySqlConnection.Open();
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();

                while (mySqlDataReader.Read())
                {
                    str[0] = mySqlDataReader["Email"].ToString();
                    str[1] = mySqlDataReader["Password"].ToString();
                    str[2] = mySqlDataReader["Coins"].ToString();
                }
                mySqlDataReader.Close();
                mySqlConnection.Close();
                return str;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return null;
            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            Admin_Panel.Location = new Point(
               this.ClientSize.Width / 2 - Admin_Panel.Size.Width / 2,
               this.ClientSize.Height / 2 - Admin_Panel.Size.Height / 2);
        }

        private void ShowUsers_Button_Click(object sender, EventArgs e)
        {

        }

        private void Users_Data_LB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string[] str = new string[4];
                str = UserInfo(Users_Data_LB.Text);
                UserInfo_LBL.Text = "Email: " + str[0] + "\nPassword: " + str[1] + "\n Coins: " + str[2];
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
