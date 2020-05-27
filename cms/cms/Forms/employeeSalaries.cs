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
    public partial class employeeSalaries : Form
    {
        employeeSalaryClass emp;
        datagridVeiwWorking dg = new datagridVeiwWorking();
    
        public employeeSalaries()
        {
            InitializeComponent();
        }

        private void employeeSalaries_Load(object sender, EventArgs e)
        {
            
            radioLoad rad = new radioLoad();

            comboBox1.DataSource = rad.mydt("select * from employeeBoxData");
            comboBox1.DisplayMember = "Id";
            comboBox1.ValueMember = "Id";

            comboBox2.DataSource = rad.mydt("select * from monthNames");
            comboBox2.DisplayMember = "title";
            comboBox2.ValueMember = "ID";
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox2.Text = DateTime.Now.ToShortDateString();
            dg.query = "SELECT * from employeePayments";
            dataGridView1.DataSource = dg.goFill().Tables[0];
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                emp = new employeeSalaryClass();
                emp.ID = Convert.ToInt32(comboBox1.Text);
                textBox1.Text = emp.getSalary().ToString();
           
          


        }

        private void button1_Click(object sender, EventArgs e)
        {

            emp.ID = Convert.ToInt32(comboBox1.Text);
            emp.months = comboBox2.Text;
            emp.empSalary = Convert.ToInt32(textBox1.Text);
            emp.today = Convert.ToDateTime(textBox2.Text);
            dg.query = "SELECT * from employeePayments";
           
           bool check =  emp.checkAlready();

            if (check == false)
            {
                  emp.insertPayment();
                  dataGridView1.DataSource = dg.goFill().Tables[0];
                MessageBox.Show("Done Successfully!!");
               

                
            }
            else
            {
                MessageBox.Show("Employee already paid !!","Alert");
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
