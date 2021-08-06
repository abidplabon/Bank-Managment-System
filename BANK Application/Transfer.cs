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
    public partial class Transfer : Form
    {
        public Transfer()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("server=localhost; database=bank_managment; username=root;password=;");
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string  date;
            double bbaal;

            int fno = Int32.Parse(textBox1.Text);
            int tono = Int32.Parse (textBox2.Text);

            bbaal = double.Parse(textBox3.Text);
            date = dateTimePicker1.Text;

            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            MySqlTransaction transaction;
            transaction = con.BeginTransaction();

            cmd.Connection = con;
            cmd.Transaction = transaction;

            try
            {
                cmd.CommandText = "update account set Balance=Balance-'" +bbaal+ "'where Account_ID='" +fno+ "'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "update account set Balance=Balance+'" + bbaal + "'where Account_ID='" + tono + "'";
                cmd.ExecuteNonQuery();


                cmd.CommandText = "insert into transfer(from_acc,to_acc,date,amount) values ('" +fno+ "','" +tono+ "','" +date+ "','" +bbaal+ "')";
                cmd.ExecuteNonQuery();


                transaction.Commit();
                MessageBox.Show("Succeded!!");
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

        private void button2_Click(object sender, EventArgs e)
        {
          
        }
    }
}
