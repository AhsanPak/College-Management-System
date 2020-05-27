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
    public partial class feeUpdationBox : Form
    {
        radioLoad rad;
        AdmissionQueries aq = new AdmissionQueries();
        public feeUpdationBox()
        {
            InitializeComponent();
        }

        private void feeUpdationBox_Load(object sender, EventArgs e)
        {
            rad = new radioLoad();
            comboBox1.DataSource = rad.mydt("select * from monthNames");
            comboBox1.DisplayMember = "title";
            comboBox1.ValueMember = "ID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string query = "insert into feesUpdation(feeForMonth,amount,year_std) values('" + comboBox1.Text + "','" + Convert.ToInt32(textBox1.Text) + "','" + comboBox2.Text + "')";
                aq.Update(query);
                textBox1.Clear();
            }
            else 
                MessageBox.Show("Enter All values!!", "Alert");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
