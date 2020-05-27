using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace cms
{
    public partial class feesAmounts : Form
    {
        showingData sd = new showingData();
        public feesAmounts()
        {
            InitializeComponent();
        }

        private void feesAmounts_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = sd.tableData("select * from monthNames");
            comboBox1.DisplayMember = "title";
            comboBox1.ValueMember = "ID";
            label2.Text = "0";
            label3.Text = "0";
            label4.Text = "0";
            label9.Text = "0";
            label8.Text = "0";
            label7.Text = "0";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sd.month = comboBox1.Text;
            if (sd.getFirstName() == true)
            {
                string queryPayments = "SELECT SUM(paymentAmount) FROM studentFees where monthName='" + comboBox1.Text + "' and studentYear = '1st Year'";
                string queryDues = "SELECT SUM(dueAmount) FROM studentFees where monthName='" + comboBox1.Text + "' and studentYear = '1st Year'";
                string queryBalance = "SELECT SUM(balanceAmount) FROM studentFees where monthName='" + comboBox1.Text + "' and studentYear = '1st Year'";
                label2.Text = sd.readFees(queryPayments).ToString();
                label3.Text = sd.readFees(queryDues).ToString();
                label4.Text = sd.readFees(queryBalance).ToString();
            }
            else
            {
                label2.Text = "0";
                label3.Text = "0";
                label4.Text = "0";
            }      // for second year
             if(sd.getSecondName()==true){  
                
                string queryPayments2nd = "SELECT SUM(paymentAmount) FROM studentFees where monthName='" + comboBox1.Text + "' and studentYear = '2nd Year'";
                string queryDues2nd = "SELECT SUM(dueAmount) FROM studentFees where monthName='" + comboBox1.Text + "' and studentYear = '2nd Year'";
                string queryBalance2nd = "SELECT SUM(balanceAmount) FROM studentFees where monthName='" + comboBox1.Text + "' and studentYear = '2nd Year'";
                label9.Text = sd.readFees(queryPayments2nd).ToString();
                label8.Text = sd.readFees(queryDues2nd).ToString();
                label7.Text = sd.readFees(queryBalance2nd).ToString();
            }
            else
            {
                label9.Text = "0";
                label8.Text = "0";
                label7.Text = "0";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
