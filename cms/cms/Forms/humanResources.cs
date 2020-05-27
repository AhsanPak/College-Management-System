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
    public partial class humanResources : Form
    {

        string gender;
        string mess ="";
        QueriesClass ad;
        public humanResources()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "" || textBox4.Text != "" || textBox5.Text != "")
            {
                ad = new QueriesClass();
                radioLoad rl = new radioLoad();
                if (radioButton4.Checked)
                {
                    gender = "Male";
                }
                else if (radioButton5.Checked)
                {
                    gender = "Female";
                }
                if (radioButton6.Checked)
                { mess = "Yes"; }
                else if (radioButton7.Checked)
                { mess = "No"; }

                ad.FirstName = textBox1.Text;
                ad.LastName = textBox2.Text;

                ad.FatherName = textBox3.Text;
                ad.Cnic = textBox4.Text;
                ad.Gender = gender;

                ad.PhoneNumber = textBox5.Text;
                ad.Qualification = comboBox1.Text;

                ad.EmailAddress = textBox6.Text;

                ad.Address = richTextBox1.Text;
                ad.Categories = comboBox2.Text;
                ad.Subject = comboBox3.Text;
                ad.payScl = Convert.ToInt32(comboBox4.Text);
                ad.DocumentCheck = mess;
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox8.Clear();
                richTextBox1.Clear();
                if (radioButton1.Checked)
                {
                    rl.radioCheck = "Employee";
                    ad.employeeRegistration();
                   



                }
                else if (radioButton2.Checked)
                {
                    rl.radioCheck = "Faculty";
                    ad.facultyRegistration();
                    MessageBox.Show("New Faculty Member Hired!");

                }
                
                rl.check();
            }
            else 
            {
                MessageBox.Show("Enter all values!!","Alert!!");
            }
        }

        private void humanResources_Load(object sender, EventArgs e)
        {
            radioLoad rad = new radioLoad();
            comboBox2.DataSource = rad.mydt("select * from categoriesFields");
            comboBox2.DisplayMember = "title";
            comboBox2.ValueMember = "ID";
           
            comboBox1.DataSource = rad.mydt("select * from qualification");
            comboBox1.DisplayMember = "title";
            comboBox1.ValueMember = "ID";

            comboBox4.DataSource = rad.mydt("select * from payScales");
            comboBox4.DisplayMember = "title";
            comboBox4.ValueMember = "ID";
            
           

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                radioLoad rad = new radioLoad();

                comboBox3.DataSource = rad.mydt("select * from artsCourses");
                comboBox3.DisplayMember = "title";
                comboBox3.ValueMember = "ID";
            }
            else if(comboBox2.SelectedIndex == 1)
            {
                radioLoad rad = new radioLoad();

                comboBox3.DataSource = rad.mydt("select * from businessCourses");
                comboBox3.DisplayMember = "title";
                comboBox3.ValueMember = "ID";
                
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                radioLoad rad = new radioLoad();

                comboBox3.DataSource = rad.mydt("select * from engeneringCourses");
                comboBox3.DisplayMember = "title";
                comboBox3.ValueMember = "ID";

            }
            else if (comboBox2.SelectedIndex == 3)
            {
                radioLoad rad = new radioLoad();

                comboBox3.DataSource = rad.mydt("select * from medicalCourses");
                comboBox3.DisplayMember = "title";
                comboBox3.ValueMember = "ID";

            }
            else if (comboBox2.SelectedIndex == 4)
            {
                radioLoad rad = new radioLoad();

                comboBox3.DataSource = rad.mydt("select * from compulsoryCourses");
                comboBox3.DisplayMember = "title";
                comboBox3.ValueMember = "ID";

            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
              groupBox4.Enabled = false;
            
          
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
               groupBox4.Enabled = true;
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            
            
        }
    }
}
