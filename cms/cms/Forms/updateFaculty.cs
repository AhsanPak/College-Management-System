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
    public partial class updateFaculty : Form
    {
        showingData sd = new showingData();
        public updateFaculty()
        {
            InitializeComponent();
        }

        private void updateFaculty_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = sd.tableData("select facultyID,fistName,lastName,phone,email,address from facultyData");
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                updatingClass cp = new updatingClass();
                string query = "update facultyData set fistName='" + textBox1.Text + "', lastName = '" + textBox2.Text + "',phone = '" + textBox3.Text + "',email = '" + textBox4.Text + "',address = '" + richTextBox1.Text + "' where facultyID=" + textBox5.Text;
                cp.update(query);
                dataGridView1.DataSource = sd.tableData("select facultyID,fistName,lastName,phone,email,address from facultyData");

            }
            catch (FormatException)
            {
                MessageBox.Show("Insert All Values!!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) // make sure user select at least 1 row 
            {
                string empID = dataGridView1.SelectedRows[0].Cells[0].Value + string.Empty;
                string firstName = dataGridView1.SelectedRows[0].Cells[1].Value + string.Empty;
                string lastName = dataGridView1.SelectedRows[0].Cells[2].Value + string.Empty;
                string phone = dataGridView1.SelectedRows[0].Cells[3].Value + string.Empty;
                string email = dataGridView1.SelectedRows[0].Cells[4].Value + string.Empty;

                string address = dataGridView1.SelectedRows[0].Cells[5].Value + string.Empty;
                textBox1.Text = firstName;
                textBox2.Text = lastName;
                textBox3.Text = phone;
                textBox4.Text = email;
                richTextBox1.Text = address;
                textBox5.Text = empID;
            }
        }
    }
}
