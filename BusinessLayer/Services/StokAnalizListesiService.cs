using BusinessLayer.ViewModels;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessLayer.Services
{
    public class StokAnalizListesiService: GenelService, IService<StokAnalizListesiVM>
    {
        ServiceBase<StokAnalizListesi> serviceBase = new ServiceBase<StokAnalizListesi>();

        int tip;
        public StokAnalizListesiService(int _tip) : base(_tip)
        {
            tip = _tip;
        }

        public StokAnalizListesiVM Get(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("StokAnalizListesi");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            DataTable dt = serviceBase.SelectText(tip, query, list);
            StokAnalizListesiVM item = new StokAnalizListesiVM();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                item.ID = Convert.ToInt32(row["ID"]);
                item.Kod = row["Kod"].ToString();
                item.Ad = row["Ad"].ToString();
                item.Metot = Convert.ToInt32(row["Metot"]);
                item.Matriks = row["Matriks"].ToString();
                item.Akreditasyon = row["Akreditasyon"].ToString();
                item.Birim = Convert.ToInt32(row["Birim"]);
                item.Durumu = row["Durumu"].ToString();
                item.Method = row["Method"].ToString();
                item.AdEn = row["AdEn"].ToString();
                item.MethodEn = row["MethodEn"].ToString();
                item.Sure = Convert.ToInt32(row["Sure"]);
                item.Numune = row["Numune"].ToString();
                item.NumGereklilik = row["NumGereklilik"].ToString();
                item.NumDipnot = row["NumDipnot"].ToString();
                item.NumDipNotEn = row["NumDipNotEn"].ToString();
            }

            return item;
        }

        public List<StokAnalizListesiVM> GetList(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("StokAnalizListesi");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            List<StokAnalizListesiVM> items = new List<StokAnalizListesiVM>();
            DataTable dt = serviceBase.SelectText(tip, query, list);

            foreach (DataRow row in dt.Rows)
            {
                StokAnalizListesiVM item = new StokAnalizListesiVM();
                item.ID = Convert.ToInt32(row["ID"]);
                item.Kod = row["Kod"].ToString();
                item.Ad = row["Ad"].ToString();
                item.Metot = Convert.ToInt32(row["Metot"]);
                item.Matriks = row["Matriks"].ToString();
                item.Akreditasyon = row["Akreditasyon"].ToString();
                item.Birim = Convert.ToInt32(row["Birim"]);
                item.Durumu = row["Durumu"].ToString();
                item.Method = row["Method"].ToString();
                item.AdEn = row["AdEn"].ToString();
                item.MethodEn = row["MethodEn"].ToString();
                item.Sure = Convert.ToInt32(row["Sure"]);
                item.Numune = row["Numune"].ToString();
                item.NumGereklilik = row["NumGereklilik"].ToString();
                item.NumDipnot = row["NumDipnot"].ToString();
                item.NumDipNotEn = row["NumDipNotEn"].ToString();

                items.Add(item);
            }

            return items;
        }

        public int Insert(StokAnalizListesiVM itemVM)
        {
            StokAnalizListesi item = new StokAnalizListesi();
            item.ID = itemVM.ID;
            item.Kod = itemVM.Kod;
            item.Ad = itemVM.Ad;
            item.Metot = itemVM.Metot;
            item.Matriks = itemVM.Matriks;
            item.Akreditasyon = itemVM.Akreditasyon;
            item.Birim = itemVM.Birim;
            item.Durumu = itemVM.Durumu;
            item.Method = itemVM.Method;
            item.AdEn = itemVM.AdEn;
            item.MethodEn = itemVM.MethodEn;
            item.Sure = itemVM.Sure;
            item.Numune = itemVM.Numune;
            item.NumGereklilik = itemVM.NumGereklilik;
            item.NumDipnot = itemVM.NumDipnot;
            item.NumDipNotEn = itemVM.NumDipNotEn;

            string query = serviceBase.Insert_Olustur("StokAnalizListesi");

            return serviceBase.Insert(tip, query, item);
        }

        public bool Update(StokAnalizListesiVM itemVM)
        {
            StokAnalizListesi item = new StokAnalizListesi();
            item.ID = itemVM.ID;
            item.Kod = itemVM.Kod;
            item.Ad = itemVM.Ad;
            item.Metot = itemVM.Metot;
            item.Matriks = itemVM.Matriks;
            item.Akreditasyon = itemVM.Akreditasyon;
            item.Birim = itemVM.Birim;
            item.Durumu = itemVM.Durumu;
            item.Method = itemVM.Method;
            item.AdEn = itemVM.AdEn;
            item.MethodEn = itemVM.MethodEn;
            item.Sure = itemVM.Sure;
            item.Numune = itemVM.Numune;
            item.NumGereklilik = itemVM.NumGereklilik;
            item.NumDipnot = itemVM.NumDipnot;
            item.NumDipNotEn = itemVM.NumDipNotEn;

            string query = serviceBase.Update_Olustur("StokAnalizListesi");

            return serviceBase.Update(tip, query, item);
        }

        public bool Delete(StokAnalizListesiVM itemVM)
        {
            StokAnalizListesi item = new StokAnalizListesi();
            item.ID = itemVM.ID;

            string query = serviceBase.Delete_Olustur("StokAnalizListesi");

            return serviceBase.Delete(tip, query, item);
        }
    }
}
