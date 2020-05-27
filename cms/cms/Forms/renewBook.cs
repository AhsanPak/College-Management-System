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
    public partial class renewBook : Form
    {
        datagridVeiwWorking dg;
        returnBookClass rb;
        DateTime mydate;
        public renewBook()
        {
            InitializeComponent();
        }

        private void renewBook_Load(object sender, EventArgs e)
        {
            radioLoad rad = new radioLoad();

            comboBox1.DataSource = rad.mydt("select * from libraryMembershipForm");
            comboBox1.DisplayMember = "registrationNo";
            comboBox1.ValueMember = "registrationNo";
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dg = new datagridVeiwWorking();
            rb = new returnBookClass();
            radioLoad rad = new radioLoad();
            dg.query = "SELECT studentID,studentName,serialNo,titleBook,authorBook FROM addingBooks INNER JOIN IssueBooks ON addingBooks.serialNo = IssueBooks.bookID where studentID="+comboBox1.Text;
            dataGridView1.DataSource = dg.goFill().Tables[0];
            comboBox2.DataSource = rad.mydt("select * from IssueBooks where studentID = " + comboBox1.Text);
            comboBox2.DisplayMember = "bookID";
            comboBox2.ValueMember = "studentID";
           
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            rb = new returnBookClass();
            
            string query = "select lastDate from IssueBooks where studentID=" + comboBox1.Text+"and bookID="+comboBox2.Text;
           OleDbDataReader reader=  rb.dataReader(query);
         
           if (reader.Read())
           {
               mydate= Convert.ToDateTime(reader["lastDate"]);

           }
           textBox1.Text = mydate.ToShortDateString();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            string query = "update IssueBooks set lastDate ='"+mydate.AddDays(15)+"'  where studentID=" + comboBox1.Text + "and bookID=" + comboBox2.Text;
            rb.updateMethod(query);
            MessageBox.Show("Book has been Renewed successfy!!!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
