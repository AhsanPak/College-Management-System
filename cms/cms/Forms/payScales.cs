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
    public partial class payScales : Form
    {
       
        public payScales()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void payScales_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                comboBox1.Text += comboBox1.Items.Add(i).ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                returnBookClass rbc = new returnBookClass();
                rbc.updateMethod("insert into payScales(gradeNo,salary) values('" + comboBox1.Text + "','" + Convert.ToInt32(textBox2.Text) + "')");
                MessageBox.Show("Pay Scale Inserted!!");
            }
            catch(FormatException)
            {
                MessageBox.Show("Enter all values!!");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
