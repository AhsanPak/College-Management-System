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
    public partial class loginAuthentication : Form
    {
        loginClass log;
        public loginAuthentication()
        {
            InitializeComponent();
        }

        private void loginAuthentication_Load(object sender, EventArgs e)
        {
            radioLoad rl = new radioLoad();
        
            comboBox1.DataSource = rl.mydt("select * from workCategories");
            comboBox1.DisplayMember = "title";
            comboBox1.ValueMember = "ID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    log = new loginClass();
                    log.userID = Convert.ToInt32(textBox1.Text);
                    log.UserPass = textBox2.Text;
                    log.comboBoxValue = comboBox1.Text;

                    bool check = log.GetLogin();


                    if (check == true)
                    {
                        log.showData();
                        Program.id = Convert.ToInt32(textBox1.Text);
                        Program.oldPass = textBox2.Text;
                        Program.depart = comboBox1.Text;
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid User Name or Password", "Login Alert!!");

                        textBox1.Clear();
                        textBox2.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Please Specify User ID or Password", "Login Alert!!");
                }
            }
            catch (FormatException) { MessageBox.Show("Enter values correctly!!"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        
        }

        }
    }

