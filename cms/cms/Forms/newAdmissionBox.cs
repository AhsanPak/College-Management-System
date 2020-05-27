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
    public partial class newAdmissionBox : Form
    {
        
        public newAdmissionBox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newAdmissionBox_Load(object sender, EventArgs e)
        {
            showingData sd = new showingData();
            string query = "select count(registrationNo) from studentDetails";
            string queryforMales = "select count(gender_std) from studentDetails where gender_std ='Male'";
            string queryFemales = "select count(gender_std) from studentDetails where gender_std ='Female'";
            string firstYear = "select count(year_std) from studentDetails where year_std ='1st Year'";
            string secondYear = "select count(year_std) from studentDetails where year_std ='2nd Year'";
            
            int countingAdmissions= sd.countAdmission(query);
            int countingMales = sd.countAdmission(queryforMales);
            int countingFirstYear = sd.countAdmission(firstYear);
            int countingSecondYear = sd.countAdmission(secondYear);
            int countFemales = sd.countAdmission(queryFemales);

            label2.Text = countingAdmissions.ToString();
            label3.Text = countingMales.ToString();
            label7.Text = countingFirstYear.ToString();
            label9.Text = countingSecondYear.ToString();
            label5.Text = countFemales.ToString();
        }
    }
}
