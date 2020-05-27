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
    public partial class libraryMemberShip : Form
    {
        int booksTaken;
        int maxAllowed;
        library li;
        public libraryMemberShip()
        {
            InitializeComponent();
        }

        private void libraryMemberShip_Load(object sender, EventArgs e)
        {
            radioLoad rad = new radioLoad();

            comboBox1.DataSource = rad.mydt("select * from studentDetails");
            comboBox1.DisplayMember = "registrationNo";
            comboBox1.ValueMember = "registrationNo";
            textBox2.Text = booksTaken.ToString();
            textBox3.Text = maxAllowed.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {

                    MessageBox.Show("Enter all values","Alert!!");

                }
                else 
                {
                    li = new library();
                    string query = "INSERT into libraryMembershipForm(registrationNo,firstName,booksTaken,maxAllowed,feeStudent,paymentStudent) values('" + comboBox1.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox2.Text + "','" + textBox4.Text + "')";
                    li.updateBook(query);
                }
            }
            catch(OleDbException)
            {
                MessageBox.Show("User already exits","Alert!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
