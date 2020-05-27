using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
namespace cms
{
    class loginClass
    {
     
       loginAuthentication la;
        public string comboBoxValue { get; set; }
        public int userID { get; set; }
        public string UserPass { get; set; }
        bool checking;
        connection con;


       

           
        

        public bool GetLogin()
        {
           
            con = new connection();
            
           OleDbConnection conn =  con.Connect();
           conn.Open();
           string query = "SELECT * FROM employeeBoxData WHERE Id = " + userID+ " AND passwordGiven = '" +UserPass + "' AND worksFor = '" + comboBoxValue+"'";
           
          
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                checking = true;
            }
            else
            {
                checking = false;
            }
            return checking;
        }
        public void showData()
        {
            la = new loginAuthentication();
            if (comboBoxValue == "Addmission Department")
            {
                admissionDepartAdmin ad = new admissionDepartAdmin();
                ad.Show();
                la.Hide();
            }
            else if (comboBoxValue == "Finance")
            {
                //financeAdmin fa = new financeAdmin();

                FinanceAdministration fa = new FinanceAdministration();
                fa.Show();
               
                la.Hide();
            }
            else if(comboBoxValue =="Library")
            {
                libraryAdmin lab = new libraryAdmin();
                lab.Show();
                la.Hide();
                
            }
            else if (comboBoxValue == "Master Admin")
            {
                masterAdmin ma = new masterAdmin();
                ma.Show();
                la.Hide();
            }

            else if (comboBoxValue == "Human Resource")
            {

                humanResourcesAdmin hra = new humanResourcesAdmin();
                hra.Show();

            }
            
          
        }

    }
}
