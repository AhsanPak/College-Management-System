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
    public partial class salariesGiven : Form
    {
        showingData sd = new showingData();
        public salariesGiven()
        {
            InitializeComponent();
        }

        private void salariesGiven_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = sd.tableData("select * from monthNames");
            comboBox1.DisplayMember = "title";
            comboBox1.ValueMember = "ID";
            label14.Text = "0";
            label2.Text = "0";
            label5.Text = "0";
            label4.Text = "0";
            label3.Text = "0";
            label6.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sd.month = comboBox1.Text;


                string queryPayments = "SELECT SUM(salary) FROM employeePayments WHERE salaryMonth ='" + comboBox1.Text + "'";
                label14.Text = sd.readFees(queryPayments).ToString();
                string countAdmUser = "select count(worksFor) from employeeBoxData where worksFor='Addmission Department'";
                label2.Text = sd.countingDepartUsers(countAdmUser);
                string countFinanceUser = "select count(worksFor) from employeeBoxData where worksFor='Finance'";
                label5.Text = sd.countingDepartUsers(countFinanceUser);
                string countLibraryUser = "select count(worksFor) from employeeBoxData where worksFor='Library'";
                label4.Text = sd.countingDepartUsers(countLibraryUser);
                string countHrUser = "select count(worksFor) from employeeBoxData where worksFor='Human Resource'";
                label3.Text = sd.countingDepartUsers(countHrUser);
                string countAdminUser = "select count(worksFor) from employeeBoxData where worksFor='Master Admin'";
                label6.Text = sd.countingDepartUsers(countAdminUser);

            }
            catch(InvalidCastException)
            {
                label14.Text = "0";
                label2.Text = "0";
                label5.Text = "0";
                label4.Text = "0";
                label3.Text = "0";
                label6.Text = "0";
                

            }
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
