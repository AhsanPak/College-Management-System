using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
namespace cms
{
    class employeeSalaryClass
    {
        public int ID  { get; set; }
        string grade;
        int salary;
        public string months { get; set; }
        public int empSalary { get; set; }
        public DateTime today { get; set; }
        bool check;
        public string getGrade()
        {
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
            string query = "select salaryPerMonth from employeeBoxData where Id=" + ID;
            OleDbCommand cmd = new OleDbCommand(query,con);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                grade = reader[0].ToString();
            }
            return grade;

        }
        public int getSalary()
        {
            getGrade();
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
            string query = "select salary from payScales where gradeNo=" +Convert.ToInt32(getGrade());
            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                salary = Convert.ToInt32(reader[0]);
            }
            return salary;

        }
        public void insertPayment()
        {
            
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
            string query = "insert into employeePayments(employeeID,salaryMonth,salary,datePayment) values('"+ID+"','"+months+"','"+empSalary+"','"+today+"')";
            OleDbCommand cmd = new OleDbCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public bool checkAlready()
        {
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
            string query = "select *  from employeePayments where employeeID='" + ID+ "' and salaryMonth = '"+months+"'";
            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                check = true;
            }
            else 
            {
                check = false;
            }
            return check;

        }


    }
}
