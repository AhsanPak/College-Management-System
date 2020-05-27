using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
namespace cms
{
    class QueriesClass
    {
        connection cn = new connection();
        
        public string FirstName { get; set; } // common
        public string LastName { get; set; } // common
        public string Cnic { get; set; }
        public string FatherName { get; set; } // common
        public string relationShip { get; set; }
        public string Occupation { get; set; }
        public int YearIncome { get; set; }
        public string national { get; set; } // common
        public string BloodGroup { get; set; }
        public string Religion { get; set; } // common
        public string addmisionProgram { get; set; }
        public string PhoneNumber { get; set; } // common
        public string EmailAddress { get; set; } // common
        public string Qualification { get; set; } // common
        public string Address { get; set; }
        public string Gender { get; set; }
        public int Salary { get; set; }
        public int employeeID{ get; set; }
        public string workAs { get; set; }
        public int salaryPM { get; set; }
        public int facultyid { get; set; }
        public string Categories { get; set; }
        public string Subject { get; set; }
        public int Experience { get; set; }
        public string DocumentCheck { get; set; }
        public int conEmpID { get; set; }
        public string conWork { get; set; }
        public int payCon { get; set; }
        public string passwords { get; set; }
        public int payScl { get; set; }

        public void employeeRegistration()
        {
            
        
                    OleDbConnection con = cn.Connect();
                con.Open();
                string query = @"insert into employeeData(firstName,lastName,fatherName,cnic,gender,phone,qualification,email,address)
                            values('" + FirstName + "','" + LastName + "','" + FatherName + "','" + Cnic + "','" + Gender + "','" + PhoneNumber + "','" + Qualification + "','" + EmailAddress + "','" + Address + "')";
                OleDbCommand insertCommand = new OleDbCommand(query, con);
                insertCommand.ExecuteNonQuery();
                con.Close();
        }

        public void emmployeeBox()
        {
            OleDbConnection con = cn.Connect();
            con.Open();
            string query = @"insert into employeeBoxData(Id,passwordGiven,worksFor,salaryPerMonth)
                            values('" + employeeID + "','" + passwords + "','" + workAs + "','" + salaryPM + "')";
            OleDbCommand insertCommand = new OleDbCommand(query, con);
            insertCommand.ExecuteNonQuery();
            con.Close();
        }
        public void facultyBOX()
        {
            OleDbConnection con = cn.Connect();
            con.Open();
            string query = @"insert into facultyDataBox(Id,salary)
                            values('" + facultyid + "','" + Salary + "')";
            OleDbCommand insertCommand = new OleDbCommand(query, con);
            insertCommand.ExecuteNonQuery();
            con.Close();
        }
       
        // for increement id by one to show employee iD
        public int GetLastID(string query)
        {

            OleDbConnection con = cn.Connect();
            con.Open();

            
            OleDbCommand insertCommand = new OleDbCommand(query, con);
            insertCommand.ExecuteNonQuery();

            return Convert.ToInt32(insertCommand.ExecuteScalar()) + 1;

        }
        //------------------------------------------------------
        public void facultyRegistration()
        {

            
            OleDbConnection con = cn.Connect();
            con.Open();
            string query = @"insert into facultyData(fistName,lastName,fatherName,cnic,gender,phone,qualification,email,address,subject,experience,documentCheck,category,payScale)
                            values('" + FirstName + "','" + LastName + "','" + FatherName + "','" + Cnic + "','" + Gender + "','" + PhoneNumber + "','" + Qualification + "','" + EmailAddress + "','" + Address + "','" + Subject + "','" + Experience + "','" + DocumentCheck + "','"+Categories +"','"+payScl+"')";
            OleDbCommand insertCommand = new OleDbCommand(query, con);
            insertCommand.ExecuteNonQuery();
            con.Close();
        }
        public int returnRollNumber()
        {
            QueriesClass qc = new QueriesClass();
            string strSQL = "SELECT MAX(registrationNo) as 'LastID' FROM studentDetails";
            return qc.GetLastID(strSQL);
        }
        public string CreatePassword()
        {
            int length=10;
            const string valid = "abcdefghijklmnopqrstuvwxyz1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}
