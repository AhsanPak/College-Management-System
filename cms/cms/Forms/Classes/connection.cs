using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
namespace cms
{
    class connection
    {

        string connectionString = "cms.accdb";
        OleDbConnection con;


        public OleDbConnection Connect()
        {

            try
            {
                con = new OleDbConnection(connectionString);

                return con;
            }
            catch (Exception excep)
            {
                throw excep;
            }
        }
    }
}
