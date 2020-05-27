using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
namespace cms
{
    class returnBookClass
    {
        public string conditionOfBook { get; set; } //// 
        string result;
        DateTime secondResult;
        public DateTime lastDate { get; set; }
        public string bookD { get; set; }
        public DateTime returnDate { get; set; }
        public string studentD { get; set; }
        public string returnBookWith { get; set; } /////
        public string bookNo { get; set; }///
        public string studentNo { get; set; }///
        public string updateQuery { get; set; }
        string message;
   
        public DateTime dataShow(string query)
        {
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
           
            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                secondResult = Convert.ToDateTime(reader[0]);
            }
            return secondResult;
            con.Close();
        }
        public string showingData(string query)
        {
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
            OleDbCommand cmd = new OleDbCommand(query,con);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                result = reader[0].ToString();
                
            }
            return result;
            con.Close();
        }

        public void deleteRow()
        {
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
            string query = "delete * from IssueBooks where studentID=" +studentNo+"and bookID="+bookNo;
            OleDbCommand cmd = new OleDbCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void updateQuantity()
        {
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
           
            OleDbCommand cmd = new OleDbCommand(updateQuery, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public string checkCondition()
        {
            TimeSpan ts = returnDate-lastDate;
            int deff = ts.Days;
           
            if (deff == 0)
            {
                if (conditionOfBook == returnBookWith)
                {
                    message = "Book has been returned!!";
                    deleteRow();
                    updateQuantity();
                    return message;
                }
                else if (conditionOfBook != returnBookWith)
                {
                    message = "Book has been returned in different condition!! Fine has to pay!!";
                    deleteRow();
                    updateQuantity();
                    return message;
                }

            }
            else if (deff > 0)
            {

                if (conditionOfBook == returnBookWith)
                {
                    message = "Book has been returned!! ";
                    deleteRow();
                    updateQuantity();
                    return message;
                }
                else if (conditionOfBook != returnBookWith)
                {
                    message = "Book has been returned in different condition and  days late "+ deff;
                    deleteRow();
                    updateQuantity();
                    return message;
                }
            }
            else if(deff<0)
            {
                if (conditionOfBook == returnBookWith)
                {
                    message = "Book has been returned!!";
                    deleteRow();
                    updateQuantity();
                    return message;
                }
                else if (conditionOfBook != returnBookWith)
                {

                    message = "Book has been returned in different Condition Fine has to pay!!";
                    deleteRow();
                    updateQuantity();
                    return message;
                }
                
            }
            return message;

        }
        public void updateMethod(string query)
        {
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();

            OleDbCommand cmd = new OleDbCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        
        }
        public OleDbDataReader dataReader(string query)
        {
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataReader reader = cmd.ExecuteReader();
            return reader;
        }
    }
}
