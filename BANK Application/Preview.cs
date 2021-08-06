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
    public partial class Preview : Form
    {
        public Preview()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("server = localhost;database=bank_managment;user=root;password=;");
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Preview_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlDataAdapter adapter = new MySqlDataAdapter("select * from account", con);
                DataSet set = new DataSet();
                adapter.Fill(set, "account");
                dataGridView1.DataSource = set.Tables["account"];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }
    }
}
