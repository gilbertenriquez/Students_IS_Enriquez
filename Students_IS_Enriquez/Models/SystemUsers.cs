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


        public async Task<bool> LoginUser(string uname, string pass)
        {
            try
            {
                await Conopen();
                Sqlcmd.Parameters.Clear();
                Strsql = "Select * from TBL_SystemUsers where Uname ='" + uname + "' and Password ='" + pass + "'";
                Sqlcmd.CommandText = Strsql;
                Sqlcmd.Connection = Cnn;
                Sqladapter.SelectCommand = Sqlcmd;
                Sqlreader = await Sqlcmd.ExecuteReaderAsync();

                if (Sqlreader.Read())
                {
                    Sqlcmd.Dispose();
                    await Sqlreader.CloseAsync();
                    Strsql = "";
                    return true;
                }

                Sqlcmd.Dispose();
                await Sqlreader.CloseAsync();
                Strsql = "";
                return false;
            }
            catch
            {
                return false;
            }

        }
    }
}


    
   

