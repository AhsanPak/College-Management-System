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
    public partial class limitingSeats : Form
    {
        limitingSeatsClass lsc;
        public limitingSeats()
        {
            InitializeComponent();
        }

        private void limitingSeats_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                lsc = new limitingSeatsClass();
                lsc.totalSeatsFirstYear = Convert.ToInt32(textBox1.Text);
                lsc.totalSeatsSecondYear = Convert.ToInt32(textBox2.Text);
                lsc.firstMaxAllow = Convert.ToInt32(textBox3.Text);
                lsc.secondMaxAllow = Convert.ToInt32(textBox4.Text);
                lsc.insertData();
            }
            catch(FormatException)
            {
                MessageBox.Show("Insert All Values!!","Alert");
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
