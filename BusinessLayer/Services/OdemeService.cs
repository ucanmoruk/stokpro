using BusinessLayer.ViewModels;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessLayer.Services
{
    public class OdemeService: GenelService, IService<OdemeVM>
    {
        ServiceBase<Odeme> serviceBase = new ServiceBase<Odeme>();

        int tip;
        public OdemeService(int _tip) : base(_tip)
        {
            tip = _tip;
        }

        public OdemeVM Get(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("Odeme");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            DataTable dt = serviceBase.SelectText(tip, query, list);
            OdemeVM item = new OdemeVM();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                item.ID = Convert.ToInt32(row["ID"]);
                if (row["Odeme_Durumu"] != DBNull.Value)
                {
                    item.Odeme_Durumu = row["Odeme_Durumu"].ToString();
                }
                if (row["Fatura_ID"] != DBNull.Value)
                {
                    item.Fatura_ID = Convert.ToInt32(row["Fatura_ID"]);
                }
                if (row["Evrak_No"] != DBNull.Value)
                {
                    item.Evrak_No = Convert.ToInt32(row["Evrak_No"]);
                }  
            }

            return item;
        }

        public List<OdemeVM> GetList(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("Odeme");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            List<OdemeVM> items = new List<OdemeVM>();
            DataTable dt = serviceBase.SelectText(tip, query, list);

            foreach (DataRow row in dt.Rows)
            {
                OdemeVM item = new OdemeVM();
                item.ID = Convert.ToInt32(row["ID"]);
                if (row["Odeme_Durumu"] != DBNull.Value)
                {
                    item.Odeme_Durumu = row["Odeme_Durumu"].ToString();
                }
                if (row["Fatura_ID"] != DBNull.Value)
                {
                    item.Fatura_ID = Convert.ToInt32(row["Fatura_ID"]);
                }
                if (row["Evrak_No"] != DBNull.Value)
                {
                    item.Evrak_No = Convert.ToInt32(row["Evrak_No"]);
                }

                items.Add(item);
            }

            return items;
        }

        public int Insert(OdemeVM itemVM)
        {
            Odeme item = new Odeme();
            item.ID = itemVM.ID;
            item.Odeme_Durumu = itemVM.Odeme_Durumu;
            item.Fatura_ID = itemVM.Fatura_ID;
            item.Evrak_No = itemVM.Evrak_No;

            string query = serviceBase.Insert_Olustur("Odeme");

            return serviceBase.Insert(tip, query, item);
        }

        public bool Update(OdemeVM itemVM)
        {
            Odeme item = new Odeme();
            item.ID = itemVM.ID;
            item.Odeme_Durumu = itemVM.Odeme_Durumu;
            item.Fatura_ID = itemVM.Fatura_ID;
            item.Evrak_No = itemVM.Evrak_No;

            string query = serviceBase.Update_Olustur("Odeme");

            return serviceBase.Update(tip, query, item);
        }

        public bool Delete(OdemeVM itemVM)
        {
            Odeme item = new Odeme();
            item.ID = itemVM.ID;

            string query = serviceBase.Delete_Olustur("Odeme");

            return serviceBase.Delete(tip, query, item);
        }
    }
}
