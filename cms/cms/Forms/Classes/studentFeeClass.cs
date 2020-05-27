using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
namespace cms
{
    class studentFeeClass
    {
        public string  studentNo { get; set; }
        public string name { get; set; }
        public string year { get; set; }
        public DateTime datePaid { get; set; } 
        public int amountPaid { get; set; }
        int due;
        int balance;
        public string month  { get; set; }
        string query;
        string returnName;
        int actualFees;
        bool check;
        public string readStudentName()
        {
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
            string querya = "select firstName from studentDetails where registrationNo=" +studentNo;
            OleDbCommand cmd = new OleDbCommand(querya, con);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                returnName = reader[0].ToString();
            }
            return returnName;
            con.Close();
        }
        public int monthlyFee()
        {
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
            query = "select fees from settingFees where monthName='" + month+"' and yearStudent = '"+year+"'";
            
            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                actualFees =Convert.ToInt32(reader[0]);
            }
            return actualFees;
            con.Close();
        }
        public bool FeePaidAlreadyCheck()
        {
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
            query = "select * from studentFees where  studentID ='"+studentNo+"' and monthName='" + month + "'";

            OleDbCommand cmd = new OleDbCommand(query, con);
            OleDbDataReader reader = cmd.ExecuteReader();
            
            if (reader.Read())
            {
                check = true;
            }
            else { check = false; }

            return check;
            con.Close();
        }

        //public void DueBalance()
        //{
        //    monthlyFee();
        //    if(amountPaid == actualFees)
        //    {
        //    due = 0;
        //    balance = 0;
        //    }
        //    else if (amountPaid > actualFees)
        //    {
        //        due = 0;
        //        balance = amountPaid - actualFees;
        //    }
        //    else if (amountPaid < actualFees)
        //    {
        //        due = actualFees - amountPaid;
        //        balance = 0;
        //    }
        //}
        public int dueAmount()
        {
            monthlyFee();
            int duem=0;
            if (amountPaid<actualFees)
            {
                duem = actualFees - amountPaid;   
            }
            return duem;
        }
        public int balanceAmount()
        {
            monthlyFee();
            int balanceM = 0;
            if (amountPaid > actualFees)
            {
                balanceM = amountPaid - actualFees;
            }
            return balanceM;
        }
        public void insertStudentFee()
        {
            
            datePaid = DateTime.Now;
            
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
           
                string query = "insert into studentFees(studentID,studentName,studentYear,paymentDate,paymentAmount,dueAmount,balanceAmount,monthName) values('" + studentNo + "','" + name + "','" + year + "','" + datePaid + "','" + amountPaid + "','" + dueAmount() + "','" + balanceAmount() + "','" + month + "')";
                OleDbCommand cmd = new OleDbCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            
            
        }
    }
}
