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
    public partial class financeDepartUser : Form
    {
        public financeDepartUser()
        {
            InitializeComponent();
        }

        private void financeDepartUser_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = goFill().Tables[0];
            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }
        public DataSet goFill()
        {
            connection cn = new connection();

            OleDbConnection conn = cn.Connect();
            conn.Open();
            DataSet ds = new DataSet();
            string mySelect;
            //int a;
            //a = Convert.ToInt16(comboBox1.Text.Substring(0, 3));

            mySelect = "SELECT Id,works FROM employeeBoxData where works = 'Finance'";
            OleDbDataAdapter adapter = new OleDbDataAdapter(mySelect, conn);
            adapter.Fill(ds);
            return ds;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text == textBox4.Text)
                {
                    string id = textBox1.Text;
                    string depart = textBox2.Text;
                    string password = textBox3.Text;
                    connection cn = new connection();
                    OleDbConnection con = cn.Connect();
                    con.Open();
                    string query = "Insert into financeDepartUsers(ID,department_user,password_user) values('" + id + "','" + depart + "','" + password + "')";
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data sucessfully Inserted!!");
                }
                else
                {
                    MessageBox.Show("Password not matched!!");
                }
            }
            catch (OleDbException)
            {

                MessageBox.Show("Already created user!!");
            }
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
                textBox1.Enabled = false;
                textBox2.Enabled = false;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry, something went wrong");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
