using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.DataBase
{
    public class SqlCommandConnection
    {
        public static void OpenConnection(SqlConnection con)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public static void CloseConnection(SqlConnection con)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
