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
    public partial class FinanceAdministration : Form
    {
        public FinanceAdministration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            studentFeeCollection fc = new studentFeeCollection();
            fc.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            checkingStudentFees csk = new checkingStudentFees();
            csk.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            changePasswordBox cpb = new changePasswordBox();
            cpb.Show();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            loginAuthentication la = new loginAuthentication();
            
            this.Close();
            la.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            employeeSalaries es = new employeeSalaries();
            es.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            employeeSalaryInformation empI = new employeeSalaryInformation();
            empI.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FinanceAdministration_Load(object sender, EventArgs e)
        {
        
           
        }
    }
}
