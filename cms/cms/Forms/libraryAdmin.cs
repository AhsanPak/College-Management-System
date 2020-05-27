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
    public partial class libraryAdmin : Form
    {
        public libraryAdmin()
        {
            InitializeComponent();
        }

        private void libraryAdmin_Load(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {

            loginAuthentication la = new loginAuthentication();
            la.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            addingNewBook ad = new addingNewBook();
            ad.Show();
                
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            issueBook ib = new issueBook();
            ib.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            libraryMemberShip lm = new libraryMemberShip();
            lm.Show();
        }

        private void addNewLimitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            returnBook rb = new returnBook();
            rb.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            renewBook rb = new renewBook();
            rb.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            changePasswordBox cp = new changePasswordBox();
            cp.Show();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}
