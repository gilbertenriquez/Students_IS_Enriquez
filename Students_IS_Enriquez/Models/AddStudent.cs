using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using static Students_IS_Enriquez.Includes.SQLconfig;
using System.Threading.Tasks;

namespace Students_IS_Enriquez.Models
{
    public class AddStudent
    {
        public string S_ID { get; set; }
        public string S_Fname { get; set; }
        public string S_Lname { get; set; }
        public string S_Address { get; set; }
        public string S_Mobile_Num { get; set; } 
        public string S_B_Date { get; set; }




        public async Task<bool> Addstudent(string sID, string sFname, string sLname, string sAdd,string sMN,string BDate)
        {
            //try
            //{
                Sqlcmd.Parameters.Clear();
                await Conopen();
                Strsql =
                    "Insert into TblStudents(S_ID,S_Fname,S_Lname,S_Address,S_Mobile_Num,S_B_Date) " +
                    "Values(@S_ID, @S_Fname, @S_Lname, @S_Address,@S_Mobile_Num,@S_B_Date)";
                Sqlcmd.Parameters.AddWithValue("@S_ID", sID);
                Sqlcmd.Parameters.AddWithValue("@S_Fname", sFname);
                Sqlcmd.Parameters.AddWithValue("@S_Lname", sLname);
                Sqlcmd.Parameters.AddWithValue("@S_Address", sAdd);
                Sqlcmd.Parameters.AddWithValue("@S_Mobile_Num", sMN);
                Sqlcmd.Parameters.AddWithValue("@S_B_Date", DateTime.Parse(BDate));
                Sqlcmd.Connection = Cnn;
                Sqlcmd.CommandText = Strsql;
                await Sqlcmd.ExecuteNonQueryAsync();
                Sqlcmd.Dispose();
                Strsql = "";
                Cnn.Close();
                return true;
            //}
            //catch
            //{
            //    return false;
            //}

        }

    }
}
