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
    public partial class returnBook : Form
    {
        datagridVeiwWorking dv = new datagridVeiwWorking();
        radioLoad rad;
        returnBookClass rbc;
        public returnBook()
        {
            InitializeComponent();
        }

        private void returnBook_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "select lastDate from IssueBooks where studentID =" + textBox5.Text + " and  bookID =" + comboBox2.Text;

            rbc.bookD = comboBox2.Text;
            rbc.studentD = textBox5.Text;
            textBox1.Text = rbc.dataShow(query).ToShortDateString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                rad = new radioLoad();
                rbc = new returnBookClass();
                string query = "select studentID,studentName, titleBook,authorBook,placeLibrary,conditionBook from  IssueBooks INNER JOIN addingBooks on  addingBooks.serialNo = IssueBooks.bookID where studentID = " + textBox5.Text;

                dataGridView1.DataSource = dv.goFill(query).Tables[0];
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox2.DataSource = rad.mydt("select * from IssueBooks where studentID = " + textBox5.Text);
                comboBox2.DisplayMember = "bookID";
                comboBox2.ValueMember = "studentID";
                rbc.bookD = comboBox2.Text;
                rbc.studentD = textBox5.Text;
            }
            else
            {
                MessageBox.Show("Enter Student ID","Alert!!");
            }
            textBox2.Text = DateTime.Now.ToString();
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                returnBookClass ba = new returnBookClass();
                DateTime d1 = Convert.ToDateTime(textBox1.Text);
                DateTime d2 = Convert.ToDateTime(textBox2.Text);
                ba.lastDate = d1;
                ba.returnDate = d2;
                ba.bookNo = comboBox2.Text;
                ba.studentNo = textBox5.Text;
                string query = "select conditionBook from addingBooks where serialNo =" + comboBox2.Text;
                ba.updateQuery = "update addingBooks set quantity = quantity + 1 where serialNo=" + comboBox2.Text;
                ba.conditionOfBook = comboBox3.Text;
                ba.returnBookWith = rbc.showingData(query);
                MessageBox.Show(ba.checkCondition(), "Alert!!");
                textBox5.Clear();
                textBox1.Clear();
                textBox2.Clear();
               
                
            }
            catch(FormatException)
            {
                MessageBox.Show("Insert Correct Values!!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
