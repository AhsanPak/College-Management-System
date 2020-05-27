using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data; 
namespace cms
{
    class radioLoad
    {
        public string radioCheck { get; set; }
       
        public void check()
        {
           
            if (radioCheck =="Employee")
            {
                employeeBox emp = new employeeBox();
                emp.Show();
            }
          
            
            
        }
        public DataTable mydt(string a)
        {
            connection cn = new connection();
            OleDbConnection con =  cn.Connect();
            OleDbCommand objCmd = new OleDbCommand(a,con);
            OleDbDataAdapter objDA = new OleDbDataAdapter(objCmd);
            objDA.SelectCommand.CommandText = objCmd.CommandText.ToString();
            DataTable dt = new DataTable();
            objDA.Fill(dt);
            return dt;
        }

    }
}
