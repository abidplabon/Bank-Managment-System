using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace BANK_Application
{
    public partial class Creation : Form
    {
        public Creation()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("server = localhost;database=bank_managment;user=root;password=;");
        public void Customer_ID()
        {
            con.Open();
            string query = "select max(Customer_ID) from customer";
            MySqlCommand cmd = new MySqlCommand(query, con);

            MySqlDataReader dr;

            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if(val=="")
                {
                    textBox1.Text = "1000";
                }
                else
                {
                    int a;
                    a = int.Parse(dr[0].ToString());
                    a = a + 1;
                    textBox1.Text = a.ToString();
                }
                con.Close();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Creation_Load(object sender, EventArgs e)
        {
            Customer_ID();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[5];
            Random r = new Random();
            r.NextBytes(buffer);
            MessageBox.Show(BitConverter.ToString(buffer));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
            button3.BackColor = ColorTranslator.FromHtml("#d90a0a");
            button4.BackColor = ColorTranslator.FromHtml("#d90a0a");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            button3.BackColor = ColorTranslator.FromHtml("#068ea2");
            button4.BackColor = ColorTranslator.FromHtml("#d90a0a");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cu_id, fname, lname,street,city, state,date, ph, email, ano, aty, desi, bala;
            cu_id = label13.Text;
            fname = first_name.Text;
            lname = last_name.Text;
            street = stree.Text;
            city = cit.Text;
            state = stat.Text;
            date = dat.Text;
            ph = phon.Text;
            email = mail.Text;
            ano = acc_no.Text;
            aty = acc_type.Text;
            desi = des.Text;
            bala = bal.Text;


            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            MySqlTransaction transaction;
            transaction = con.BeginTransaction();

            cmd.Connection = con;
            cmd.Transaction = transaction;

            try
            {
                cmd.CommandText = "insert into Customer(Customer_ID,First_Name,Last_Name,Street,City,State,Phone,Date,Email) values('" + cu_id + "','" + fname + "','" + lname + "','" + street + "','" + city + "','" + state + "','" + ph + "','" + date + "','"+email+"')";
                cmd.ExecuteNonQuery();

                transaction.Commit();
                MessageBox.Show("Completed!!");
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            MySqlTransaction transaction;
            transaction = con.BeginTransaction();

            cmd.Connection = con;
            cmd.Transaction = transaction;

            int id = Int32.Parse(acc_no.Text);
            int balance = Int32.Parse(bal.Text);

            try
            {
                cmd.CommandText = "insert into account(Account_ID,Account_type,Discription,Balance,date) values('" + id + "','" + acc_type.Text + "','" + des.Text + "','" + balance + "','"+dateTimePicker1.Text+"')";
                cmd.ExecuteNonQuery();

                transaction.Commit();
                MessageBox.Show("Completed!!");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
