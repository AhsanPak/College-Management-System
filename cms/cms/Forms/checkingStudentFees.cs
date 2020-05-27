using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cms
{
    public partial class checkingStudentFees : Form
    {
        radioLoad rl;
        datagridVeiwWorking dg;
        studentFeeClass sf;
        public checkingStudentFees()
        {
            InitializeComponent();
        }

        private void checkingStudentFees_Load(object sender, EventArgs e)
        {
            rl = new radioLoad();

            comboBox1.DataSource = rl.mydt("select * from monthNames");
            comboBox1.DisplayMember = "title";
            comboBox1.ValueMember = "ID";

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sf = new studentFeeClass();
                dg = new datagridVeiwWorking();
                sf.month = comboBox1.Text;
                sf.year = comboBox2.Text;
                if (radioButton1.Checked)
                {
                    string query = "select * from studentFees where monthName ='" + comboBox1.Text + "' and studentYear = '" + comboBox2.Text + "' and paymentAmount >= " + sf.monthlyFee();

                    dataGridView1.DataSource = dg.goFill(query).Tables[0];
                }
                else if (radioButton2.Checked)
                {
                    string query = "select * from studentFees where monthName ='" + comboBox1.Text + "' and studentYear = '" + comboBox2.Text + "' and paymentAmount < " + sf.monthlyFee();

                    dataGridView1.DataSource = dg.goFill(query).Tables[0];

                }
            }
            catch(FormatException)
            {
                MessageBox.Show("Enter Correct Values!!","Alert!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
