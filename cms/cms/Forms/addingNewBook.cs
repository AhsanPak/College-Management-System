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
    public partial class addingNewBook : Form
    {
        
        QueriesClass qc;
        library li;
        public addingNewBook()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                 li = new library();
                li.title = textBox2.Text;
                li.authorName = textBox3.Text;
                li.quantityBook = Convert.ToInt32(textBox4.Text);
                li.place = comboBox1.Text;
                li.condition = comboBox2.Text;
                li.insertBook();
                dataGridView1.DataSource = goFill().Tables[0];
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            catch(FormatException)
            {
                MessageBox.Show("Insert All Values!!","Alert!!");
            }
            
        }

        private void addingNewBook_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            dataGridView1.DataSource = goFill().Tables[0];
            qc = new QueriesClass();
            string strSQL = "SELECT MAX(serialNo) as 'LastID' FROM addingBooks";
            textBox1.Text = qc.GetLastID(strSQL).ToString();
            radioLoad rl = new radioLoad();
            comboBox1.DataSource = rl.mydt("select * from shelvesLibrary");
            comboBox1.DisplayMember = "titleShelves";
            comboBox1.ValueMember = "ID";

        }
        public DataSet goFill()
        {
            connection cn = new connection();
            OleDbConnection conn = cn.Connect();
            conn.Open();
            DataSet ds = new DataSet();
            string mySelect;
            mySelect = "SELECT * from addingBooks";
            OleDbDataAdapter adapter = new OleDbDataAdapter(mySelect, conn);
            adapter.Fill(ds);
            return ds;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int index = e.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                textBox1.Text = selectedRow.Cells[0].Value.ToString();
                textBox2.Text = selectedRow.Cells[1].Value.ToString();
                textBox3.Text = selectedRow.Cells[2].Value.ToString();
                textBox4.Text = selectedRow.Cells[3].Value.ToString();
                comboBox1.Text = selectedRow.Cells[4].Value.ToString();
                comboBox2.Text = selectedRow.Cells[5].Value.ToString();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Not inserted correctly!!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            li = new library();
            li.serial = Convert.ToInt32(textBox1.Text);
            li.deleteBook();
            dataGridView1.DataSource = goFill().Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                li = new library();
             string query  ="update addingBooks SET titleBook = '" + textBox2.Text + "', authorBook = '" + textBox3.Text + "', quantity ='" + Convert.ToInt32(textBox4.Text) + "', placeLibrary='" + comboBox1.Text + "', conditionBook='" + comboBox2.Text + "' where serialNo= " + Convert.ToInt32(textBox1.Text);
                li.updateBook(query);
                dataGridView1.DataSource = goFill().Tables[0];
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("Insert All Values!!", "Alert!!");
            }
        }
   
    }
}
