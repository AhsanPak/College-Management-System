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
    public partial class employeeSalaryInformation : Form
    {
        datagridVeiwWorking dg = new datagridVeiwWorking();
        public employeeSalaryInformation()
        {
            InitializeComponent();
        }

        private void employeeSalaryInformation_Load(object sender, EventArgs e)
        {

            radioLoad rad = new radioLoad();

            comboBox1.DataSource = rad.mydt("select * from employeeBoxData");
            comboBox1.DisplayMember = "Id";
            comboBox1.ValueMember = "Id";

            dg.query = "select * from employeePayments";
            dataGridView1.DataSource = dg.goFill().Tables[0];

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            dg.query = "select * from employeePayments where employeeID='"+comboBox1.Text+"'";
            dataGridView1.DataSource = dg.goFill().Tables[0];
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
