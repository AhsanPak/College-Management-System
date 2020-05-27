using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
namespace cms
{
    class AdmissionQueries
    {
     public int Rno { get; set; }
     public DateTime admissionDate { get; set; }

     public string firstName{get;set;}
      public string lastName { get; set; }
      public DateTime dateBirth { get; set; }
      public string gender { get; set; }
      public string fatherName { get; set; }
      public string status { get; set; }
      public string fatheOccupation { get; set; }
      public int income { get; set; }
      public string nationality { get; set; }
      public string blood { get; set; }
      public string religion { get; set; }
      public string field { get; set; }
      public string year { get; set; }
      public string section { get; set; }
      public string phoneNumber { get; set; }
      public string address { get; set; }
      public int parcentage { get; set; }
      public int sectionASeats { get; set; }
      public int sectionBSeats { get; set; }
      public int sectionCSeats { get; set; }
      public int totalFee { get; set; }
      public int amountUserPaid { get; set; }
      public int balanceUser { get; set; }

      string seatsLimit;
      int count;
      int maxAllow;
      public void insertStudent()
      {
          connection cn = new connection();
          OleDbConnection con = cn.Connect();
          con.Open();
          string query = "INSERT INTO studentDetails(registrationNo,admissionDate,firstName, lastName, dateOfBirth, gender_std,fatherName,relationship_std,fatherOccupation,annualIncome,nationality_std,bloodGroup,religion_std,field_std,year_std,section_std,phoneNumber,address_std,parcentage_matric) VALUES (@rgNo,@AdmDate,@fName, @lName, @db, @gn,@fN,@rl,@fO,@In,@nt,@bld,@r,@fielD,@year,@sect,@phNo,@adrs,@mat)";
          OleDbCommand cmd = new OleDbCommand(query, con);
          cmd.Parameters.AddWithValue("@rgNo", Rno);
          cmd.Parameters.AddWithValue("@AdmDate", admissionDate);

          cmd.Parameters.AddWithValue("@fName", firstName);
          cmd.Parameters.AddWithValue("@lName", lastName);
          cmd.Parameters.AddWithValue("@db", dateBirth);
          cmd.Parameters.AddWithValue("@gn", gender);
          cmd.Parameters.AddWithValue("@fN", fatherName);
          cmd.Parameters.AddWithValue("@rl", status);
          cmd.Parameters.AddWithValue("@fO", fatheOccupation);
          cmd.Parameters.AddWithValue("@In", income);
          cmd.Parameters.AddWithValue("@nt", nationality);
          cmd.Parameters.AddWithValue("@bld", blood);
          cmd.Parameters.AddWithValue("@r", religion);

          cmd.Parameters.AddWithValue("@fielD", field);
          cmd.Parameters.AddWithValue("@year", year);
          cmd.Parameters.AddWithValue("@sect", section);
          cmd.Parameters.AddWithValue("@phNo", phoneNumber);
          cmd.Parameters.AddWithValue("@adrs", address);
          cmd.Parameters.AddWithValue("@mat", parcentage);
          
          cmd.ExecuteNonQuery();
          con.Close();
      }
      public void insertRollSection()
      {
          connection cn = new connection();
          OleDbConnection con = cn.Connect();
          con.Open();
          string query = "INSERT INTO rollNumbers(title,year_std) values('"+section+"','"+year+"')";
          OleDbCommand cmd = new OleDbCommand(query,con);
          cmd.ExecuteNonQuery();
          con.Close();
        
      }
      public OleDbDataReader sectionWork()
      {
          string query = null;
          connection cn = new connection();
          OleDbConnection con = cn.Connect();
          con.Open();
        
          if (section == "1st Year")
          {
              query = "SELECT COUNT(section_std) FROM studentDetails where year_std = '1st Year'";
          }
          else if (section == "2nd Year")
          {
              query = "SELECT COUNT(section_std) FROM studentDetails where year_std = '2nd Year'";
          }
          else
          {
              query = "SELECT COUNT(section_std) FROM studentDetails";
          }
          OleDbCommand cmd = new OleDbCommand(query, con);
          OleDbDataReader reader = cmd.ExecuteReader();
          return reader;
      }
      public int returningTotalSeats(string query)
      {
          connection cn = new connection();
          OleDbConnection con = cn.Connect();
          con.Open();

         
          OleDbCommand cmd = new OleDbCommand(query, con);
          OleDbDataReader reader = cmd.ExecuteReader();
          if (reader.Read())
          {
              maxAllow = Convert.ToInt32(reader[0]);
          }
          return maxAllow;
      }
      public string limitSeats()
      {
          

          OleDbDataReader reader = sectionWork();
          
          if (reader.Read())
          {
             
              count = reader.GetInt32(0);
          }
          string query = "select seatsFirstYear from seatsSections where ID = (SELECT MAX(ID) FROM seatsSections)";
          int limitsOfSeats = returningTotalSeats(query);
          if (count <= limitsOfSeats)
          {
              int half = limitsOfSeats/2;
              string queryb = "select maxAllowFyear from seatsSections where ID = (SELECT MAX(ID) FROM seatsSections)";
              int sectionsSeats = returningTotalSeats(queryb);
              
              if (count<= sectionsSeats)
              {
                  seatsLimit = "A";
              }
              else if (count > sectionsSeats && count <= half)
              {
                  seatsLimit = "B";
              }
              else if (count > half && count <= limitsOfSeats)
              {
                  seatsLimit = "C";
              }
                }
          else {
              seatsLimit = "Admission Closed";
          
          }

          
          return seatsLimit;
        
      }
      public void Update(string query)
      {

          connection cn = new connection();
          OleDbConnection con = cn.Connect();
          con.Open();
          
          
          OleDbCommand cmd = new OleDbCommand(query, con);
          cmd.ExecuteNonQuery();
          con.Close();
   
      }
      public string methodForId()
      {
         QueriesClass qc = new QueriesClass();

          string strsql = "select max(ID) as 'lastid' from studentFee";

          return qc.GetLastID(strsql).ToString();

      }
      

    }
}
