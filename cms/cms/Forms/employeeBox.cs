using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.OleDb;
namespace cms
{
    public partial class employeeBox : Form
    {
        QueriesClass qc;

        public employeeBox()
        {
            InitializeComponent();
            
        }

        
        
        private void employeeBox_Load(object sender, EventArgs e)
        {
            qc = new QueriesClass();
            string strSQL = "SELECT MAX(Id) as 'LastID' FROM employeeBoxData";
           
            textBox1.Text = qc.GetLastID(strSQL).ToString();

             
            radioLoad rad = new radioLoad();

            comboBox1.DataSource = rad.mydt("select * from workCategories");
            comboBox1.DisplayMember = "title";
            comboBox1.ValueMember = "ID";
             comboBox2.DataSource = rad.mydt("select * from payScales");
            comboBox2.DisplayMember = "gradeNo";
            comboBox2.ValueMember = "ID";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                qc = new QueriesClass();
                qc.employeeID = Convert.ToInt32(textBox1.Text);
                qc.workAs = comboBox1.Text;
                qc.salaryPM = Convert.ToInt32(comboBox2.Text);
                qc.passwords = textBox3.Text;
                qc.emmployeeBox();
                MessageBox.Show("New Employee has been Hired !!");
                this.Hide();
            }
            catch (FormatException)
            {
                
                throw;
            }
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            qc = new QueriesClass();
            textBox3.Text = qc.CreatePassword();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
