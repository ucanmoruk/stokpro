using System;
using System.Data.SqlClient;
using System.Reflection;

namespace DataAccessLayer.DataBase
{
    public class Tools
    {
        public static void Parametre_Olustur<T>(SqlCommand cmd, KomutTip kt, T entity)
        {
            PropertyInfo[] pis = typeof(T).GetProperties();
            foreach (PropertyInfo pi in pis)
            {
                string name = pi.Name;
                //if ((name.ToLower() == "id" || name.ToLower() == "ıd") && kt == KomutTip.Update)
                //{
                //    continue;
                //}
                if (name.ToLower() == "ıd" && kt == KomutTip.Insert)
                {
                    continue;
                }
                else if (kt == KomutTip.Delete && name.ToLower() != "ıd")
                {
                    continue;
                }
                object val = pi.GetValue(entity);
                if (val == null)
                {
                    cmd.Parameters.AddWithValue("@" + pi.Name, DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@" + pi.Name, val);
                }
            }
        }

        public static void CustomParametre_Olustur<T>(SqlCommand cmd, T entity)
        {
            PropertyInfo[] pis = typeof(T).GetProperties();
            foreach (PropertyInfo pi in pis)
            {
                string name = pi.Name;

                object val = pi.GetValue(entity);
                if (val == null)
                {
                    cmd.Parameters.AddWithValue("@" + pi.Name, DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@" + pi.Name, val);
                }
            }
        }

        public static void CustomParametre_Olustur<T>(SqlCommand cmd, params object[] array)
        {
            for (int i = 0; i < array.Length; i += 2)
            {
                cmd.Parameters.AddWithValue("@" + array[i].ToString(), array[i + 1]);
            }
        }

    }
}
