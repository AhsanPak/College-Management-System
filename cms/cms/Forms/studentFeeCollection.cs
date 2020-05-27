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
    public partial class studentFeeCollection : Form
    {
        radioLoad rl;
        studentFeeClass stFee = new studentFeeClass();
        showingData sd = new showingData();
        public studentFeeCollection()
        {
            InitializeComponent();
        }

        private void studentFeeCollection_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            
            dataGridView1.DataSource = sd.tableData("select * from studentFees");
           
            rl = new radioLoad();

            comboBox3.DataSource = rl.mydt("select * from monthNames");
            comboBox3.DisplayMember = "title";
            comboBox3.ValueMember = "ID";

            comboBox1.DataSource = rl.mydt("select * from studentDetails");
            comboBox1.DisplayMember = "registrationNo";
            comboBox1.ValueMember = "registrationNo";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            stFee.studentNo = comboBox1.Text;
           textBox1.Text = stFee.readStudentName();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                stFee.studentNo = comboBox1.Text;
                stFee.name = textBox1.Text;
                stFee.year = comboBox2.Text;
                stFee.month = comboBox3.Text;
                stFee.amountPaid = Convert.ToInt32(textBox2.Text);
                if (stFee.FeePaidAlreadyCheck() == false)
                {
                    stFee.insertStudentFee();
                    MessageBox.Show("Fees Successfully Paid!!");
                    dataGridView1.DataSource = sd.tableData("select * from studentFees");
                }
                else
                    MessageBox.Show("Student had Paid fees already!!");
            }catch(FormatException)
            {
                MessageBox.Show("Enter all values!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
          
        }

    }
}
