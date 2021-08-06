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
    public partial class Withdraw : Form
    {
        public Withdraw()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("server=localhost; database=bank_managment; username=root;password=;");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int account_id = Int32.Parse(depo_acc_no.Text);
                con.Open();
                string str = "select* from account where Account_ID ='" + account_id + "'";
                MySqlCommand cmd = new MySqlCommand(str, con);

                MySqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    textBal.Text = rd[4].ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string A_N, DAT;
            double BAL, With;
            int acc_no = Int32.Parse(depo_acc_no.Text);
            DAT = datetime.Text;
            BAL = double.Parse(textBal.Text);
            With = double.Parse(W.Text);



            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            MySqlTransaction transaction;
            transaction = con.BeginTransaction();

            cmd.Connection = con;
            cmd.Transaction = transaction;

            try
            {
                cmd.CommandText = "update account set Balance=Balance-'" +With+ "'where Account_ID='" + acc_no + "'";
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
    }
}
