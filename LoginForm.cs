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
    public partial class LoginForm : Form
    {
        public static string username = "";
        public LoginForm()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }
        
        private void LoginForm_Load_1(object sender, EventArgs e)
        {
               Login_Register_Panel.Location = new Point(
               this.ClientSize.Width / 2 - Login_Register_Panel.Size.Width / 2,
               this.ClientSize.Height / 2 - Login_Register_Panel.Size.Height / 2);
        }
        private void Login_Register_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Login_Register_btn.Text == "Register")
                {
                    string[] Cheacks = new string[2];
                    Cheacks = CheackEmailAndUserName();
                    string Email = Email_Text.Text;
                    string PassWord = PassWord_Text.Text;
                    string UserName = UserName_Text.Text;
                    bool Cheack = true;

                    if (Email == Cheacks[0])
                    {
                        Cheack = false;
                        MessageBox.Show($"{Email} Already Taken");
                    }
                    if(UserName == Cheacks[1])
                    {
                        Cheack = false;
                        MessageBox.Show($"{UserName} Already Taken");
                    }
                    if (Cheack)
                    {
                        SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                        SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                        //------------------ Add New User To Login Table ---------------------//
                        mySqlCommand.CommandText = $"insert into Login values('{Email}','{PassWord}','{UserName}',0,'{null}');";
                        mySqlConnection.Open();
                        SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                        Email_lbl.Visible = false;
                        Email_Text.Visible = false;
                        Email_Text.Text = "";
                        UserName_Text.Text = "";
                        PassWord_Text.Text = "";
                        mySqlDataReader.Close();
                        mySqlConnection.Close();
                        MessageBox.Show($"Welcome {UserName}");
                        Login_Register_btn.Text = "Login";
                        AddData_Button.Text = "Register";
                        Login_Rigester_LBL.Text = "Don`t have an acoount ?";
                    }
                }
                else
                {
                    AcceptToLogin();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void AcceptToLogin()
        {
            try
            {
                string UserName = UserName_Text.Text;
                string PassWord = PassWord_Text.Text;
                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlCommand.CommandText = $"Select * from Login where username='{UserName}' and password='{PassWord}';";
                mySqlConnection.Open();
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    MessageBox.Show($"Welcome Back {UserName}");
                    username = UserName_Text.Text;
                    HomeScreen hs = new HomeScreen();
                    this.Hide();
                    hs.ShowDialog();
                }
                else
                {
                    MessageBox.Show("The UserName or PassWord is incorrect ");
                }
                mySqlDataReader.Close();
                mySqlConnection.Close();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private string[] CheackEmailAndUserName()
        {
            try
            {
                string[] Cheack = new string[2];
                SqlConnection mySqlConnection = new SqlConnection("server=DESKTOP-PC5NLQI\\SQLEXPRESS01;database=FinalProject;Integrated Security=SSPI;");
                SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlCommand.CommandText = "Select email,username from Login;";
                mySqlConnection.Open();
                SqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    Cheack[0] = mySqlDataReader["email"].ToString();
                    Cheack[1] = mySqlDataReader["username"].ToString();
                }
                mySqlDataReader.Close();
                mySqlConnection.Close();
                return Cheack;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return null;
            }
        }

        private void PassWord_Text_TextChanged(object sender, EventArgs e)
        {
            PassWord_Text.PasswordChar = '●';
        }

        private void AddData_Button_Click(object sender, EventArgs e)
        {
            try
            {

                if (AddData_Button.Text == "Register")
                {
                    Login_Register_btn.Text = "Register";
                    AddData_Button.Text = "Login";
                    Login_Rigester_LBL.Text = "Alredy have account #";
                    Email_lbl.Visible = true;
                    Email_Text.Visible = true;
                    Email_Text.Text = "";
                    UserName_Text.Text = "";
                    PassWord_Text.Text = "";
                }
                else
                {
                    Login_Register_btn.Text = "Login";
                    AddData_Button.Text = "Register";
                    Login_Rigester_LBL.Text = "Don`t have an acoount ?";
                    Email_lbl.Visible = false;
                    Email_Text.Visible = false;
                    Email_Text.Text = "";
                    UserName_Text.Text = "";
                    PassWord_Text.Text = "";
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void ShowPassword_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPassword_CB.Checked)
                PassWord_Text.PasswordChar = '\0';
            else
                PassWord_Text.PasswordChar = '●';
        }
    }
}
