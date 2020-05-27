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
    public partial class issueBook : Form
    {
        // limit has to change
        int limit =3;
        library li;
        int countingAdmissions;
        int numberOfQuantity;
        showingData sd;
        datagridVeiwWorking dg = new datagridVeiwWorking();
        
        public issueBook()
        {
            InitializeComponent();
        }

        private void issueBook_Load(object sender, EventArgs e)
        {
           
               
           // dataGridView1.DataSource = dg.goFill().Tables[0];
            radioLoad rad = new radioLoad();

            comboBox1.DataSource = rad.mydt("select * from libraryMembershipForm");
            comboBox1.DisplayMember = "registrationNo";
            comboBox1.ValueMember = "registrationNo";

            comboBox2.DataSource = rad.mydt("select * from addingBooks");
            comboBox2.DisplayMember = "serialNo";
            comboBox2.ValueMember = "serialNo";
            li= new library();


            textBox3.Text =limit.ToString(); 
            textBox4.Text = DateTime.Now.ToShortDateString();
            textBox5.Text = DateTime.Now.AddDays(15).ToShortDateString();
        
            
        }
         

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

           sd = new showingData();
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
            string query = "select firstName from libraryMembershipForm where registrationNo = " + comboBox1.Text;
            string queryForCount = "select count(studentID) from IssueBooks where studentID = "+comboBox1.Text;
            countingAdmissions = sd.countAdmission(queryForCount);
            textBox1.Text = countingAdmissions.ToString();
            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                textBox2.Text = read[0].ToString();
              
            }
           

            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            library li = new library();
            dataGridView1.DataSource = li.fillData(Convert.ToInt32(comboBox2.Text)).Tables[0];
        }
       
          
            
        
        private void button1_Click(object sender, EventArgs e)
        {
           dg.query = "SELECT serialNo,titleBook,authorBook,quantity,placeLibrary,conditionBook from addingBooks where quantity >" + 0;
            dataGridView1.DataSource = dg.goFill().Tables[0];
            sd = new showingData();
            li = new library();
            string queryForCount = "select count(studentID) from IssueBooks where studentID = " + comboBox1.Text;
            countingAdmissions = sd.countAdmission(queryForCount);
             
              numberOfQuantity=  li.checkQuantity(Convert.ToInt32(comboBox2.Text));
            if (countingAdmissions >= limit)
            {
                MessageBox.Show("Return previous Books!!", "Alert");
            }
            else
            {
                if (numberOfQuantity > 0)
                {
                      string querya = "Select bookID from IssueBooks where studentID ="+comboBox1.Text;
                      string checkID= li.alreadyExitsBook(querya);
                     if (comboBox2.Text != checkID)
                     {
                         string query = "insert into IssueBooks(studentID,studentName,takenBooks,maxAllowed,bookID,issueDate,lastDate)values('" + comboBox1.Text + "','" + textBox2.Text + "','" + Convert.ToInt32(textBox1.Text) + "','" + Convert.ToInt32(textBox3.Text) + "','" + comboBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                         li = new library();
                         li.updateBook(query);
                         li.minusQuantity(Convert.ToInt32(comboBox2.Text));

                         MessageBox.Show("Book has been issued Successfully!!!");
                         textBox1.Clear();
                         textBox2.Clear();
                     }
                     else
                     {
                         MessageBox.Show("This book is already Issued to you!!");
                     }
                }
                else
                { MessageBox.Show("Book quantity is zero!!", "Alert"); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
