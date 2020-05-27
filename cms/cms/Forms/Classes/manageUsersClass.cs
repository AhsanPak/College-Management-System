using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
namespace cms
{
    class manageUsersClass
    {
        public DataSet studentSheet()
        {
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            DataSet ds = new DataSet();
            string ayub1;
            ayub1 = "select * from employeeDataBox";
            OleDbDataAdapter adapter = new OleDbDataAdapter(ayub1, con);
            adapter.Fill(ds);
            return ds;
        }
    }
}
