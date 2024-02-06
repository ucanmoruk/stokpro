using BusinessLayer.ViewModels;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessLayer.Services
{
    public class Rapor_DurumService: GenelService, IService<Rapor_DurumVM>
    {
        ServiceBase<Rapor_Durum> serviceBase = new ServiceBase<Rapor_Durum>();

        int tip;
        public Rapor_DurumService(int _tip) : base(_tip)
        {
            tip = _tip;
        }

        public Rapor_DurumVM Get(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("Rapor_Durum");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            DataTable dt = serviceBase.SelectText(tip, query, list);
            Rapor_DurumVM item = new Rapor_DurumVM();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                item.ID = Convert.ToInt32(row["ID"]);
                if (row["RaporNo"] != DBNull.Value)
                {
                    item.RaporNo = Convert.ToInt32(row["RaporNo"]);
                }
                if (row["RaporID"] != DBNull.Value)
                {
                    item.RaporID = Convert.ToInt32(row["RaporID"]);
                }
                if (row["Durum"] != DBNull.Value)
                {
                    item.Durum = row["Durum"].ToString();
                }
                if (row["TanimlayanID"] != DBNull.Value)
                {
                    item.TanimlayanID = Convert.ToInt32(row["TanimlayanID"]);
                }
                if (row["Tarih"] != DBNull.Value)
                {
                    item.Tarih = Convert.ToDateTime(row["Tarih"]);
                } 
                
            }

            return item;
        }

        public List<Rapor_DurumVM> GetList(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("Rapor_Durum");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            List<Rapor_DurumVM> items = new List<Rapor_DurumVM>();
            DataTable dt = serviceBase.SelectText(tip, query, list);

            foreach (DataRow row in dt.Rows)
            {
                Rapor_DurumVM item = new Rapor_DurumVM();
                item.ID = Convert.ToInt32(row["ID"]);
                if (row["RaporNo"] != DBNull.Value)
                {
                    item.RaporNo = Convert.ToInt32(row["RaporNo"]);
                }
                if (row["RaporID"] != DBNull.Value)
                {
                    item.RaporID = Convert.ToInt32(row["RaporID"]);
                }
                if (row["Durum"] != DBNull.Value)
                {
                    item.Durum = row["Durum"].ToString();
                }
                if (row["TanimlayanID"] != DBNull.Value)
                {
                    item.TanimlayanID = Convert.ToInt32(row["TanimlayanID"]);
                }
                if (row["Tarih"] != DBNull.Value)
                {
                    item.Tarih = Convert.ToDateTime(row["Tarih"]);
                }

                items.Add(item);
            }

            return items;
        }

        public int Insert(Rapor_DurumVM itemVM)
        {
            Rapor_Durum item = new Rapor_Durum();
            item.ID = itemVM.ID;
            item.RaporNo = itemVM.RaporNo;
            item.RaporID = itemVM.RaporID;
            item.Durum = itemVM.Durum;
            item.Tarih = itemVM.Tarih;
            item.TanimlayanID = itemVM.TanimlayanID;

            string query = serviceBase.Insert_Olustur("Rapor_Durum");

            return serviceBase.Insert(tip, query, item);
        }

        public bool Update(Rapor_DurumVM itemVM)
        {
            Rapor_Durum item = new Rapor_Durum();
            item.ID = itemVM.ID;
            item.RaporNo = itemVM.RaporNo;
            item.RaporID = itemVM.RaporID;
            item.Durum = itemVM.Durum;
            item.Tarih = itemVM.Tarih;
            item.TanimlayanID = itemVM.TanimlayanID;

            string query = serviceBase.Update_Olustur("Rapor_Durum");

            return serviceBase.Update(tip, query, item);
        }

        public bool Delete(Rapor_DurumVM itemVM)
        {
            Rapor_Durum item = new Rapor_Durum();
            item.ID = itemVM.ID;

            string query = serviceBase.Delete_Olustur("Rapor_Durum");

            return serviceBase.Delete(tip, query, item);
        }
    
    }
}
