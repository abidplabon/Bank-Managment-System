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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Creation Cr = new Creation();
            Cr.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Preview preview = new Preview();
            preview.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Withdraw withdraw = new Withdraw();

            withdraw.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Deposite deposite = new Deposite();
            deposite.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            Transfer transfer = new Transfer();
            transfer.Show();
        }
    }
}
