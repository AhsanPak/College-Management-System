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
    public partial class changePasswordBox : Form
    {
        updatingClass uc;
        string oldPass;
        public changePasswordBox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text !=null || textBox3.Text !=null||textBox4.Text != null)
            {
                
            
           
            uc = new updatingClass();
            OleDbDataReader reader = uc.selecting();
            
            if (textBox3.Text == textBox4.Text)
            {
                   
                   
                        if (textBox2.Text == Program.oldPass )
                        {
                            string query = "update employeeBoxData set passwordGiven ='" + textBox3.Text + "' where Id = " + textBox1.Text + " and worksFor='" + Program.depart+"'";
                            uc.update(query);
                            MessageBox.Show("Password Updated!!");
                        }
                        else
                        {
                            label6.Show();
                        }
                    
                  
            }
            else
            {
                label7.Show();
                
                }
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void changePasswordBox_Load(object sender, EventArgs e)
        {
            textBox1.Text = Program.id.ToString();
            textBox1.Enabled = false;
            label6.Hide();
            label7.Hide();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label6.Hide();
            label7.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label6.Hide();
            label7.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label6.Hide();
            label7.Hide();
        }
    }
}
