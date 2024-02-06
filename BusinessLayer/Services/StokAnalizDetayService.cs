using BusinessLayer.ViewModels;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessLayer.Services
{
    public class StokAnalizDetayService: GenelService, IService<StokAnalizDetayVM>
    {
        ServiceBase<StokAnalizDetay> serviceBase = new ServiceBase<StokAnalizDetay>();

        int tip;
        public StokAnalizDetayService(int _tip) : base(_tip)
        {
            tip = _tip;
        }

        public StokAnalizDetayVM Get(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("StokAnalizDetay");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            DataTable dt = serviceBase.SelectText(tip, query, list);
            StokAnalizDetayVM item = new StokAnalizDetayVM();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                item.ID = Convert.ToInt32(row["ID"]);
                item.AnalizID = Convert.ToInt32(row["AnalizID"]);
                item.Aciklama = row["Aciklama"].ToString();
                item.AciklamaEn = row["AciklamaEn"].ToString();
                item.CasNo = row["CasNo"].ToString();
                item.Loq = row["Loq"].ToString();
                item.Birim = row["Birim"].ToString();
                item.Tur = row["Tur"].ToString();
                item.Durum = row["Durum"].ToString();
            }

            return item;
        }

        public List<StokAnalizDetayVM> GetList(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("StokAnalizDetay");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            List<StokAnalizDetayVM> items = new List<StokAnalizDetayVM>();
            DataTable dt = serviceBase.SelectText(tip, query, list);

            foreach (DataRow row in dt.Rows)
            {
                StokAnalizDetayVM item = new StokAnalizDetayVM();
                item.ID = Convert.ToInt32(row["ID"]);
                item.AnalizID = Convert.ToInt32(row["AnalizID"]);
                item.Aciklama = row["Aciklama"].ToString();
                item.AciklamaEn = row["AciklamaEn"].ToString();
                item.CasNo = row["CasNo"].ToString();
                item.Loq = row["Loq"].ToString();
                item.Birim = row["Birim"].ToString();
                item.Tur = row["Tur"].ToString();
                item.Durum = row["Durum"].ToString();

                items.Add(item);
            }

            return items;
        }

        public int Insert(StokAnalizDetayVM itemVM)
        {
            StokAnalizDetay item = new StokAnalizDetay();
            item.ID = itemVM.ID;
            item.AnalizID = itemVM.AnalizID;
            item.Aciklama = itemVM.Aciklama;
            item.AciklamaEn = itemVM.AciklamaEn;
            item.CasNo = itemVM.CasNo;
            item.Loq = itemVM.Loq;
            item.Birim = itemVM.Birim;
            item.Tur = itemVM.Tur;
            item.Durum = itemVM.Durum;

            string query = serviceBase.Insert_Olustur("StokAnalizDetay");

            return serviceBase.Insert(tip, query, item);
        }

        public bool Update(StokAnalizDetayVM itemVM)
        {
            StokAnalizDetay item = new StokAnalizDetay();
            item.ID = itemVM.ID;
            item.AnalizID = itemVM.AnalizID;
            item.Aciklama = itemVM.Aciklama;
            item.AciklamaEn = itemVM.AciklamaEn;
            item.CasNo = itemVM.CasNo;
            item.Loq = itemVM.Loq;
            item.Birim = itemVM.Birim;
            item.Tur = itemVM.Tur;
            item.Durum = itemVM.Durum;

            string query = serviceBase.Update_Olustur("StokAnalizDetay");

            return serviceBase.Update(tip, query, item);
        }

        public bool Delete(StokAnalizDetayVM itemVM)
        {
            StokAnalizDetay item = new StokAnalizDetay();
            item.ID = itemVM.ID;

            string query = serviceBase.Delete_Olustur("StokAnalizDetay");

            return serviceBase.Delete(tip, query, item);
        }
    }
}
