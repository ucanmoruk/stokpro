using DataAccessLayer.DataBase;
using System.Reflection;

namespace BusinessLayer.Services
{
    public class ServiceBase<T> : DataBaseOperations<T> where T : class
    {
        public string Select_Olustur(string tablename)
        {
            return "select * from " + tablename + " ";
        }
       
        public string Insert_Olustur(string tablename)
        {
            string insert = "insert into " + tablename + "(";
            PropertyInfo[] pis = typeof(T).GetProperties();
            foreach (PropertyInfo pi in pis)
            {
                if (pi.Name.ToLower() != "ıd")
                {
                    insert += pi.Name + ", ";
                }         
            }

            insert = insert.Trim().Trim(',');
            insert += ") OUTPUT Inserted.ID values(";
            foreach (PropertyInfo pi in pis)
            {
                if (pi.Name.ToLower() != "ıd")
                {
                    if (pi.GetType() == typeof(float) || pi.GetType() == typeof(decimal) || pi.GetType() == typeof(double))
                    {
                        insert += "cast(@" + pi.Name + " as numeric(18,2)), ";
                    }
                    else
                    {
                        insert += "@" + pi.Name + ", ";
                    }
                }
            }

            insert = insert.Trim().Trim(',');
            insert += ")";
            return insert;
        }

        public string Update_Olustur(string tablename)
        {
            string update = "update " + tablename + " set ";
            PropertyInfo[] pis = typeof(T).GetProperties();
            foreach (PropertyInfo pi in pis)
            {
                if (pi.Name.ToLower() != "ıd")
                {
                    if (pi.GetType() == typeof(float) || pi.GetType() == typeof(decimal) || pi.GetType() == typeof(double))
                    {
                        update += pi.Name + " = cast(@" + pi.Name + " as numeric(18,2)), ";
                    }
                    else
                    {
                        update += pi.Name + " = @" + pi.Name + ", ";
                    }
                }
            }

            update = update.Trim().Trim(',');
            update += " where ID = @ID";
            return update;
        }

        public string Delete_Olustur(string tablename)
        {
            return "delete from " + tablename + " where ID = @ID";
        }
    }
}
