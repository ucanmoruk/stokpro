using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.DataBase
{
    public class DataBaseOperations<T> where T : class
    {
        public string ClassName
        {
            get
            {
                return typeof(T).Name;
            }
        }

        public bool Delete(int connection, string query, T entity)
        {
            SqlConnection con = DataBaseConnection.GetConnection(connection);
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;

                Tools.Parametre_Olustur<T>(cmd, KomutTip.Delete, entity);

                SqlCommandConnection.OpenConnection(con);
                int etk = cmd.ExecuteNonQuery();
                return etk > 0 ? true : false;
            }
            catch (Exception ex) { }
            finally
            {
                SqlCommandConnection.CloseConnection(con);
            }
            return false;
        }

        public int Insert(int connection, string query, T entity)
        {
            SqlConnection con = DataBaseConnection.GetConnection(connection);
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                SqlCommandConnection.OpenConnection(con);
                Tools.Parametre_Olustur<T>(cmd, KomutTip.Insert, entity);
                int id = (int)cmd.ExecuteScalar();
                return id;
            }
            catch (Exception ex) { }
            finally
            {
                SqlCommandConnection.CloseConnection(con);
            }
            return 0;
        }

        public bool Update(int connection, string query, T entity)
        {
            SqlConnection con = DataBaseConnection.GetConnection(connection);
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                SqlCommandConnection.OpenConnection(con);
                Tools.Parametre_Olustur<T>(cmd, KomutTip.Update, entity);
                int etk = cmd.ExecuteNonQuery();
                return etk > 0 ? true : false;
            }
            catch (Exception ex) { }
            finally
            {
                SqlCommandConnection.CloseConnection(con);
            }


            return false;
        }

        public bool CustomProc(int connection, string query, T entity)
        {
            bool b;
            SqlConnection con = DataBaseConnection.GetConnection(connection);
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlCommandConnection.OpenConnection(con);
                Tools.CustomParametre_Olustur<T>(cmd, entity);
                cmd.ExecuteNonQuery();
                b = true;
            }
            catch (Exception ex)
            {
                b = false;
            }
            finally
            {
                SqlCommandConnection.CloseConnection(con);
            }

            return b;
        }

        public bool CustomText(int connection, string query, T entity)
        {
            bool b;
            SqlConnection con = DataBaseConnection.GetConnection(connection);
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                SqlCommandConnection.OpenConnection(con);
                Tools.CustomParametre_Olustur<T>(cmd, entity);
                cmd.ExecuteNonQuery();
                b = true;
            }
            catch (Exception ex)
            {
                b = false;
            }
            finally
            {
                SqlCommandConnection.CloseConnection(con);
            }

            return b;
        }

        public bool CustomProc(int connection, string query, params object[] array)
        {
            bool b;
            SqlConnection con = DataBaseConnection.GetConnection(connection);
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlCommandConnection.OpenConnection(con);
                Tools.CustomParametre_Olustur<T>(cmd, array);
                cmd.ExecuteNonQuery();
                b = true;
            }
            catch (Exception ex)
            {
                b = false;
            }
            finally
            {
                SqlCommandConnection.CloseConnection(con);
            }

            return b;
        }

        public bool CustomText(int connection, string query, params object[] array)
        {
            bool b;
            SqlConnection con = DataBaseConnection.GetConnection(connection);
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                SqlCommandConnection.OpenConnection(con);
                Tools.CustomParametre_Olustur<T>(cmd, array);
                cmd.ExecuteNonQuery();
                b = true;
            }
            catch (Exception ex)
            {
                b = false;
            }
            finally
            {
                SqlCommandConnection.CloseConnection(con);
            }

            return b;
        }

        public DataTable SelectText(int connection, string query, params object[] list)
        {
            try
            {
                SqlConnection con = DataBaseConnection.GetConnection(connection);
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                if (list.Length > 0)
                {
                    for (int i = 0; i < list.Length; i++)
                    {
                        int sira = i + 1;
                        da.SelectCommand.Parameters.AddWithValue("@param" + sira, list[i]);
                    }
                }
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public DataTable SelectProc(int connection, string query, params object[] list)
        {
            try
            {
                SqlConnection con = DataBaseConnection.GetConnection(connection);
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (list.Length > 0)
                {
                    for (int i = 0; i < list.Length; i++)
                    {
                        int sira = i + 1;
                        da.SelectCommand.Parameters.AddWithValue("@param" + sira, list[i]);
                    }
                }
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

    }
}
