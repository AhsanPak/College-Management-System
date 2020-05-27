using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
namespace cms
{
    class showingData
    {

        public int totalAdmission { get; set; }
        int count;
        public int getAmounts { get; set; }
        public string month { get; set; }
        string mess;
        
        public int countAdmission(string query )
        {
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
          
            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                
                count = reader.GetInt32(0);
            }
            return count;
        }
        public DataTable tableData(string query)
        {
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            OleDbCommand objCmd = new OleDbCommand(query, con);
            OleDbDataAdapter objDA = new OleDbDataAdapter(objCmd);
            objDA.SelectCommand.CommandText = objCmd.CommandText.ToString();
            DataTable dt = new DataTable();
            objDA.Fill(dt);
            return dt;
        }
        public int readFees(string myQuery)
        {
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();

            OleDbCommand cmd = new OleDbCommand(myQuery, con);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                getAmounts = Convert.ToInt32(reader[0]);

            }
          
            return getAmounts;  
        }
        public bool getFirstName()
        {
            bool check;
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
            string queryMy = "select monthName from studentFees where monthName='"+month+"' and studentYear = '1st Year'";
            OleDbCommand cmd = new OleDbCommand(queryMy, con);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                check = true;

            }
            else { check = false; }
            return check;  
        
        }
        public bool getSecondName()
        {
            bool check;
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
            string queryMy = "select monthName from studentFees where monthName='" + month + "' and studentYear = '2nd Year'";
            OleDbCommand cmd = new OleDbCommand(queryMy, con);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                check = true;

            }
            else { check = false; }
            return check;

        }
        public string countingDepartUsers(string query)
        {

            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
            OleDbCommand cmd = new OleDbCommand(query, con);

            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {

                mess = reader[0].ToString();
            }
            return mess;


        }
    }
}
