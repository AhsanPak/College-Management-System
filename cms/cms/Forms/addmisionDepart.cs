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
    public partial class addmisionDepart : Form
    {
        string myGender;
        AdmissionQueries aq;
        radioLoad rad;
        QueriesClass qc;
           
        public addmisionDepart()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            this.Close();
        }
       
        private void addmisionDepart_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox3.Enabled = false;

            qc = new QueriesClass();
            textBox1.Text = qc.returnRollNumber().ToString();
            rad = new radioLoad();
            aq = new AdmissionQueries();
            textBox3.Text = aq.limitSeats();
            comboBox1.DataSource = rad.mydt("select * from categoriesFields");
            comboBox1.DisplayMember = "title";
            comboBox1.ValueMember = "ID";
            comboBox4.DataSource = rad.mydt("select * from bloodGroups");
            comboBox4.DisplayMember = "title";
            comboBox4.ValueMember = "ID";
          }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {

            changePasswordBox cb = new changePasswordBox();
            cb.Show();
            
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginAuthentication la = new loginAuthentication();
            la.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            aq = new AdmissionQueries();
            AdmissionQueries ad = new AdmissionQueries();
            qc = new QueriesClass();
            
            if (radioButton1.Checked)
                myGender = "Male";   
            else if(radioButton2.Checked)
                myGender = "Female";

            try
            {
                if (aq.limitSeats() != "Admission Closed")
                {


                    
                    ad.Rno = Convert.ToInt32(textBox1.Text);
                    ad.admissionDate = dateTimePicker1.Value;
                    ad.firstName = textBox4.Text;
                    ad.lastName = textBox5.Text;
                    ad.dateBirth = dateTimePicker2.Value;
                    ad.gender = myGender;
                    ad.fatherName = textBox6.Text;
                    ad.status = comboBox3.Text;
                    ad.fatheOccupation = textBox7.Text;
                    ad.income = Convert.ToInt32(textBox8.Text);
                    ad.nationality = textBox9.Text;
                    ad.blood = comboBox4.Text;
                    ad.religion = comboBox5.Text;
                    ad.field = comboBox1.Text;
                    ad.year = comboBox2.Text;
                    ad.section = textBox3.Text;
                    ad.phoneNumber = textBox2.Text;
                    ad.address = richTextBox1.Text;
                    ad.parcentage = Convert.ToInt32(textBox10.Text);
                    ad.insertStudent();
                    ad.insertRollSection();
                    qc.returnRollNumber();
                    textBox3.Text = aq.limitSeats();
                    
                    textBox1.Text = qc.returnRollNumber().ToString();
          
                }
                else
                { MessageBox.Show("Registration Closed!!","Admission Alert!!"); }
            }
            catch(FormatException)
            {
                MessageBox.Show("Enter All values!!");
            }
            
            textBox2.Clear();
            
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();

           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
