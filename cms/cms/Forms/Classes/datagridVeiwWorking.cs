using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
namespace cms
{
    class datagridVeiwWorking
    {
        public string query { get; set; }
        
        public DataSet goFill()
        {
            connection cn = new connection();

            OleDbConnection conn = cn.Connect();
            conn.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            adapter.Fill(ds);
            return ds;
        }

        public DataSet goFill(string mySelect)
        {
            connection cn = new connection();
           
            OleDbConnection conn = cn.Connect();
            conn.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter adapter = new OleDbDataAdapter(mySelect, conn);
            adapter.Fill(ds);
            return ds;
        }

    }
}
