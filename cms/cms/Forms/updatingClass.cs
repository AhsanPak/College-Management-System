using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
namespace cms
{
    class updatingClass
    {
        public string passwordMatch { get; set; }
        public string Id { get; set; }
        public OleDbDataReader selecting()
        {
            loginClass cl = new loginClass();
           
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
            string cmdText = "select Id from admissionDepartUsers";
            OleDbCommand cmd = new OleDbCommand(cmdText, con);
            OleDbDataReader reader = cmd.ExecuteReader();
            return reader;
           
        }
        public OleDbDataReader selectingOldPassword()
        {
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
            string cmdText = "select password_user from admissionDepartUsers";
            OleDbCommand cmd = new OleDbCommand(cmdText, con);
            OleDbDataReader reader = cmd.ExecuteReader();
            return reader;

        }
        public void update(string cmdText)
        {
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
           
            OleDbCommand cmd = new OleDbCommand(cmdText, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}
