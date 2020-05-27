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
    public partial class masterAdmin : Form
    {
        public masterAdmin()
        {
            InitializeComponent();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            
        }

        private void hr_btn_Click(object sender, EventArgs e)
        {
            humanResources hr = new humanResources();
            hr.Show();
            this.Hide();
        }

        private void Addmision_btn_Click(object sender, EventArgs e)
        {
            addmisionDepart ad = new addmisionDepart();
            ad.Show();
            this.Hide();
        }

        private void finance_btn_Click(object sender, EventArgs e)
        {
        }

        private void library_btn_Click(object sender, EventArgs e)
        {
            libraryAdmin la = new libraryAdmin();
            la.Show();
            this.Hide();
        }

        private void hostel_btn_Click(object sender, EventArgs e)
        {
         
        }

        private void manage_btn_Click(object sender, EventArgs e)
        {
           
        }

        private void totalFeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            feesAmounts fa = new feesAmounts();
            fa.Show();
        }

        private void newAdmissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newAdmissionBox nab = new newAdmissionBox();
            nab.Show();
            
        }

        private void studentInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            studentDetails sd = new studentDetails();
            sd.Show();
        }

        private void humanResourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void admissionDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void hostelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
        }

        private void libraryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void transportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void managementToolStripMenuItem1_Click(object sender, EventArgs e)
        {
                  
        }

        private void financeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            financeDepartUser fdu = new financeDepartUser();
            fdu.Show();
        }

        private void limitingSeatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limitingSeats ls = new limitingSeats();
            ls.Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginAuthentication la = new loginAuthentication();
            la.Show();
            this.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void settingFeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            feeUpdationBox upb = new feeUpdationBox();
            upb.Show();
        }

        private void masterAdmin_Load(object sender, EventArgs e)
        {
            showingData sd = new showingData();
            string countBook = "select count(serialNo) from addingBooks";
            string countEmployees = "select count(Id) from employeeBoxData";
            string countStudents = "select count(registrationNo) from studentDetails";

            int countingBooks = sd.countAdmission(countBook);
            int countingEmployees = sd.countAdmission(countEmployees);
            int countingStudents = sd.countAdmission(countStudents);

            if (countingBooks != 0 || countingEmployees != 0 || countingStudents !=0)
            {
                label6.Text = countingBooks.ToString();
                label4.Text = countingEmployees.ToString();
                label2.Text = countingStudents.ToString();

            }
            else
            {
                MessageBox.Show("No records entered yet!!", "Alert");
            }
        }

        private void payScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            payScales ps = new payScales();
            ps.Show();
        }

        private void managementToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salariesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            salariesGiven sg = new salariesGiven();
            sg.Show();
        }

        private void employeesInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employeeInformation emp = new employeeInformation();
            emp.Show();
        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CountBooks cb = new CountBooks();
            cb.Show();
        }

        private void logOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            loginAuthentication la = new loginAuthentication();
            la.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changePasswordBox cpb = new changePasswordBox();
            cpb.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
