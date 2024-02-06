using System.Data.SqlClient;

namespace DataAccessLayer.DataBase
{
    public class DataBaseConnection
    {
        public DataBaseConnection()
        {
        }

        public static SqlConnection GetConnection(int tip)
        {
            SqlConnection con = new SqlConnection();
            switch (tip)
            {
                case 1:
                    con = new SqlConnection(@"Data Source=mssql04.trwww.com,1433; Initial Catalog = massgrup_denetim; persist Security Info = True; User ID = masslab; Password = 123qweASD_*");
                    break;
                case 2:
                    con = new SqlConnection(@"Data Source=mssql04.trwww.com,1433; Initial Catalog = massgrup_mass; persist Security Info = True; User ID = masslab; Password = 123qweASD_* ; MultipleActiveResultSets=True; Connection Timeout=900");
                    break;
                default:
                    break;
            }

            return con;
        }

    }
}
