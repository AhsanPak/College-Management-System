using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
namespace cms
{
    class limitingSeatsClass
    {
        public int totalSeatsFirstYear{get;set;}
        public int totalSeatsSecondYear { get; set; }
        public int firstMaxAllow { get; set; }
        public int secondMaxAllow { get; set; }
        public int sectionsFyear { get; set; }
        public int sectionsLyear { get; set; }
        int remainingFyear;
        int remainingLyear;
      
        public void firstYearCalculation()
        {
            if (totalSeatsFirstYear % firstMaxAllow == 0)
            {
                sectionsFyear = totalSeatsFirstYear / firstMaxAllow;
                remainingFyear = 0;
            }
            else
            {
                sectionsFyear = totalSeatsFirstYear / firstMaxAllow;
                remainingFyear = totalSeatsFirstYear % firstMaxAllow;

            }
        }
        public void secondYearCalculation()
        {
            if (totalSeatsSecondYear % secondMaxAllow == 0)
            {
                 sectionsLyear = totalSeatsSecondYear / secondMaxAllow;
                 remainingLyear = 0;
            }
            else
            {
                sectionsLyear = totalSeatsSecondYear / secondMaxAllow;
                remainingLyear = totalSeatsSecondYear % secondMaxAllow;
                
            }
        }

        public void insertData()
        {
            firstYearCalculation();
            secondYearCalculation();
            connection cn = new connection();
            OleDbConnection con = cn.Connect();
            con.Open();
            string query = "insert into seatsSections(seatsFirstYear,sectionsFirstYear,remainingsFirstYear,maxAllowFyear,seatsSecondYear,sectionsSecondYear,remainingsSecondYear,maxAllowSyear)values('" + totalSeatsFirstYear + "','" + sectionsFyear + "','" + remainingFyear + "','"+firstMaxAllow+"','" + totalSeatsSecondYear + "','" + sectionsLyear + "','" + remainingLyear + "','"+secondMaxAllow+"')";
            OleDbCommand cmd = new OleDbCommand(query,con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
