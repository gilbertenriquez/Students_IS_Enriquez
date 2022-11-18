using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_IS_Enriquez.Includes
{
    public class SQLconfig
    {
        public static SqlDataReader Sqlreader;
        public static readonly SqlDataAdapter Sqladapter = new();
        public static readonly SqlCommand Sqlcmd = new();
        public static SqlConnection Cnn = new();
        public static string Strsql;

        public static async Task<bool> Conopen()
        {
            try
            {
                string? Cstring;
                Cstring =
                    $"Data Source = 192.168.102.113;Initial Catalog=Student_IS_db;Integrated Security=False;User ID=sa;Password=administrator01;";
                Cnn = new SqlConnection(Cstring);
                await Cnn.OpenAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}