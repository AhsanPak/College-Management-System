using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace cms
{
    class library
    {
        public int serial { get; set; }
        public string title { get; set; }
        public string authorName  { get; set; }
        public string place { get; set; }
        public string condition { get; set; }
        public int quantityBook { get; set; }
        string checking;
        
        int minus = 1;

        public void insertBook()
        {
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
            string query = "Insert into addingBooks(titleBook,authorBook,quantity,placeLibrary,conditionBook)values('"+title+"','"+authorName+"','"+quantityBook+"','"+place+"','"+condition+"')";
            OleDbCommand cmd = new OleDbCommand(query,con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteBook()
        {
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
            string query = "delete * from addingBooks where serialNo = "+serial;
            OleDbCommand cmd = new OleDbCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        
        }
        public void updateBook(string query)
        {
            
                connection cn = new connection();
                OleDbConnection con = cn.Connect();
                con.Open();

                OleDbCommand cmd = new OleDbCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
        }
        public OleDbDataReader reader(string query)
        {
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public DataSet fillData(int id)
        {
            connection cn = new connection();

            OleDbConnection conn = cn.Connect();
            conn.Open();
            DataSet ds = new DataSet();
            string mySelect;


            mySelect = "SELECT serialNo,titleBook,authorBook,quantity,placeLibrary,conditionBook from addingBooks where serialNo ="+id;
            OleDbDataAdapter adapter = new OleDbDataAdapter(mySelect, conn);
            adapter.Fill(ds);
            return ds;
        }
        public void minusQuantity(int id)
        {
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
            string mySelect;
            mySelect = string.Format("update addingBooks set quantity= quantity - {0} where quantity > {1} and serialNo="+id, minus,0);
            OleDbCommand cmd = new OleDbCommand(mySelect,con);
           cmd.ExecuteNonQuery();
            con.Close();
          
        }
        public int checkQuantity(int id)
        {
            int numberOfQuantity=0;
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
            string query = "select quantity from addingBooks where serialNo = " +id;
            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                numberOfQuantity = Convert.ToInt32(reader[0]);
            }
            con.Close();
            return numberOfQuantity;
        }
        public string alreadyExitsBook(string query)
        {
            
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
          
            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                checking = reader[0].ToString();
            }
            return checking;
            
        }

    }
}
