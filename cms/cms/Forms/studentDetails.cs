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
    public partial class studentDetails : Form
    {
        public studentDetails()
        {
            InitializeComponent();
        }
        showingData sd = new showingData();

        private void button1_Click(object sender, EventArgs e)
        {
            
               
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void studentDetails_Load(object sender, EventArgs e)
        {
            //DataTable table = new DataTable();
            
            comboBox1.DataSource = sd.tableData("select * from studentDetails");
            comboBox1.DisplayMember = "registrationNo";
            comboBox1.ValueMember = "registrationNo";
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) // make sure user select at least 1 row 
            {
                string firstName = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                string lastName = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                string phone = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
                string year = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;
                string section = dataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;
                string address = dataGridView1.SelectedRows[0].Cells[6].Value + string.Empty;
                textBox2.Text = firstName;
                textBox3.Text = lastName;
                textBox4.Text = phone;
                textBox5.Text = year;
                textBox6.Text = section;
                richTextBox1.Text = address; 

            }           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = sd.tableData("select registrationNo,firstName,lastName,phoneNumber,year_std,section_std,address_std from studentDetails where registrationNo ="+comboBox1.Text);
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
            if (textBox2.Text != null && textBox3.Text != null && textBox4.Text != null && textBox5.Text != null && textBox6.Text != null && richTextBox1.Text != null)
            {
                string query = @"update studentDetails SET firstName = '" + textBox2.Text + "', lastName = '" + textBox3.Text + "', year_std ='" + textBox5.Text + "', section_std='" + textBox6.Text + "', phoneNumber='" + textBox4.Text + "', address_std='" + richTextBox1.Text + "' where registrationNo = " + comboBox1.Text;
                OleDbCommand cmd = new OleDbCommand(query, con);
                cmd.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Insert all values");
                
            } 
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            richTextBox1.Clear();
        }

        
    }
}
