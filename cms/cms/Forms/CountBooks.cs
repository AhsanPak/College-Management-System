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
    public partial class CountBooks : Form
    {
        showingData sd = new showingData();
        public CountBooks()
        {
            InitializeComponent();
        }

        private void CountBooks_Load(object sender, EventArgs e)
        {
            
            string countBook = "select count(serialNo) from addingBooks";
            string countMembers = "select count(registrationNo) from libraryMembershipForm";
            string countIssuedBook = "select count(bookID) from IssueBooks";
            int countingBooks = sd.countAdmission(countBook);
            int countingMembers = sd.countAdmission(countMembers);
            int countingIssueBooks = sd.countAdmission(countIssuedBook);

            if (countingBooks != 0 || countingMembers != 0 || countingIssueBooks != 0)
            {
                label2.Text = countingBooks.ToString();
                label6.Text = countingMembers.ToString();
                label4.Text = countingIssueBooks.ToString();


            }
            else
            {
                MessageBox.Show("No records entered yet!!", "Alert");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
