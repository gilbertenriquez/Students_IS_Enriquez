using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using static Students_IS_Enriquez.Includes.SQLconfig;
using System.Threading.Tasks;

namespace Students_IS_Enriquez.Models
{
    public class SystemUsers
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Uname { get; set; }
        public string Password { get; set; }

        public async Task<bool> AddSystemUser(string fname, string lname, string username, string pass)
        {
            try
            {
                Sqlcmd.Parameters.Clear();
                await Conopen();
                Strsql =
                    "Insert into TBL_SystemUsers(Fname,Lname,Uname,Password) " +
                    "Values(@Fname, @Lname, @Uname, @Password)";
                Sqlcmd.Parameters.AddWithValue("@Fname", fname);
                Sqlcmd.Parameters.AddWithValue("@Lname", lname);
                Sqlcmd.Parameters.AddWithValue("@Uname", username);
                Sqlcmd.Parameters.AddWithValue("@Password", pass);               
                Sqlcmd.Connection = Cnn;
                Sqlcmd.CommandText = Strsql;
                await Sqlcmd.ExecuteNonQueryAsync();
                Sqlcmd.Dispose();
                Strsql = "";
                Cnn.Close();
                return true;
            }
            catch
            {
               return false;
            }

        }



        //public async Task<bool> Users(string UserName)
        //{
        //    try
        //    {
        //        await Conopen();
        //        Strsql =
        //            "SELECT  * Student_IS_db_Enriquez WHERE Uname =" + UserName;
        //        Sqlcmd.Connection = Cnn;
        //        Sqlcmd.CommandText = Strsql;
        //        await Sqlcmd.ExecuteNonQueryAsync();
        //        Strsql = "";
        //        Cnn.Close();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }

        //}
    }
   
}
