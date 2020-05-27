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
    public partial class admissionDepartAdmin : Form
    {
        public admissionDepartAdmin()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            addmisionDepart ad = new addmisionDepart();
            ad.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            studentDetails sd = new studentDetails();
            sd.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
