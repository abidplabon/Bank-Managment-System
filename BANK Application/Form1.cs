using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BANK_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int count;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_button_Click(object sender, EventArgs e)
        {
            string UserName, Password;
            UserName = Name_box.Text;
            Password = Password_box.Text;
            count = count + 1;
            if (count> 5)
            {
                MessageBox.Show("The user is blocked by the admin");
                Application.Exit();
            }
            if (UserName == "" && Password == "")
            {
                Status.Text = "No Data to login";
            }
            else if (UserName.Length >= 10 && Password.Length >= 10)
            {
                Status.Text = "The data is to huge to handle";
            }
            else
            {
                if (UserName == "Admin" && Password == "392")
                {
                    Progress_Bar pro = new Progress_Bar();
                    this.Hide();
                    pro.Show();
                }
                else
                {
                    Status.Text = "Invalid UserName";
                    Name_box.Clear();
                    Password_box.Clear();
                    Name_box.Focus();
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Status.Text = "";
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
