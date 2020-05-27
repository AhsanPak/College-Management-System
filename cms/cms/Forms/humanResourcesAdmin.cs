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
    public partial class humanResourcesAdmin : Form
    {
        public humanResourcesAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            humanResources hr = new humanResources();
            hr.Show();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            loginAuthentication la = new loginAuthentication();
            this.Close();
            
            la.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            changePasswordBox cp = new changePasswordBox();
            cp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            updatingEmployeeFaculty ue = new updatingEmployeeFaculty();
            ue.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            employeeInformation ei = new employeeInformation();
            ei.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateFaculty uf = new updateFaculty();
            uf.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
