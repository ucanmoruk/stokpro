using BusinessLayer.ViewModels;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessLayer.Services
{
    public class NKRService: GenelService, IService<NKRVM>
    {
        ServiceBase<NKR> serviceBase = new ServiceBase<NKR>();

        int tip;
        public NKRService(int _tip) : base(_tip)
        {
            tip = _tip;
        }

        public NKRVM Get(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("NKR");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            DataTable dt = serviceBase.SelectText(tip, query, list);
            NKRVM item = new NKRVM();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                item.ID = Convert.ToInt32(row["ID"]);
                if (row["Firma_ID"] != DBNull.Value)
                {
                    item.Firma_ID = Convert.ToInt32(row["Firma_ID"]);
                }
                if (row["Evrak_No"] != DBNull.Value)
                {
                    item.Evrak_No = Convert.ToInt32(row["Evrak_No"]);
                }
                if (row["Numune_Adi"] != DBNull.Value)
                {
                    item.Numune_Adi = row["Numune_Adi"].ToString();
                }
                if (row["Adet"] != DBNull.Value)
                {
                    item.Adet = Convert.ToInt32(row["Adet"]);
                }
                if (row["Tarih"] != DBNull.Value)
                {
                    item.Tarih = Convert.ToDateTime(row["Tarih"]);
                }
                if (row["Tur"] != DBNull.Value)
                {
                    item.Tur = row["Tur"].ToString();
                }
                if (row["Grup"] != DBNull.Value)
                {
                    item.Grup = row["Grup"].ToString();
                }
                if (row["Analiz"] != DBNull.Value)
                {
                    item.Analiz = row["Analiz"].ToString();
                }
                if (row["Rapor_Durumu"] != DBNull.Value)
                {
                    item.Rapor_Durumu = row["Rapor_Durumu"].ToString();
                }
                if (row["Aciklama"] != DBNull.Value)
                {
                    item.Aciklama = row["Aciklama"].ToString();
                }
                if (row["RaporNo"] != DBNull.Value)
                {
                    item.RaporNo = Convert.ToInt32(row["RaporNo"]);
                }
                if (row["Akreditasyon"] != DBNull.Value)
                {
                    item.Akreditasyon = row["Akreditasyon"].ToString();
                }
                if (row["Revno"] != DBNull.Value)
                {
                    item.Revno = Convert.ToInt32(row["Revno"]);
                }
                if (row["Servis"] != DBNull.Value)
                {
                    item.Servis = row["Servis"].ToString();
                }
                if (row["Durum"] != DBNull.Value)
                {
                    item.Durum = row["Durum"].ToString();
                }
                
            }

            return item;
        }

        public List<NKRVM> GetList(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("NKR");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            List<NKRVM> items = new List<NKRVM>();
            DataTable dt = serviceBase.SelectText(tip, query, list);

            foreach (DataRow row in dt.Rows)
            {
                NKRVM item = new NKRVM();
                item.ID = Convert.ToInt32(row["ID"]);
                if (row["Firma_ID"] != DBNull.Value)
                {
                    item.Firma_ID = Convert.ToInt32(row["Firma_ID"]);
                }
                if (row["Evrak_No"] != DBNull.Value)
                {
                    item.Evrak_No = Convert.ToInt32(row["Evrak_No"]);
                }
                if (row["Numune_Adi"] != DBNull.Value)
                {
                    item.Numune_Adi = row["Numune_Adi"].ToString();
                }
                if (row["Adet"] != DBNull.Value)
                {
                    item.Adet = Convert.ToInt32(row["Adet"]);
                }
                if (row["Tarih"] != DBNull.Value)
                {
                    item.Tarih = Convert.ToDateTime(row["Tarih"]);
                }
                if (row["Tur"] != DBNull.Value)
                {
                    item.Tur = row["Tur"].ToString();
                }
                if (row["Grup"] != DBNull.Value)
                {
                    item.Grup = row["Grup"].ToString();
                }
                if (row["Analiz"] != DBNull.Value)
                {
                    item.Analiz = row["Analiz"].ToString();
                }
                if (row["Rapor_Durumu"] != DBNull.Value)
                {
                    item.Rapor_Durumu = row["Rapor_Durumu"].ToString();
                }
                if (row["Aciklama"] != DBNull.Value)
                {
                    item.Aciklama = row["Aciklama"].ToString();
                }
                if (row["RaporNo"] != DBNull.Value)
                {
                    item.RaporNo = Convert.ToInt32(row["RaporNo"]);
                }
                if (row["Akreditasyon"] != DBNull.Value)
                {
                    item.Akreditasyon = row["Akreditasyon"].ToString();
                }
                if (row["Revno"] != DBNull.Value)
                {
                    item.Revno = Convert.ToInt32(row["Revno"]);
                }
                if (row["Servis"] != DBNull.Value)
                {
                    item.Servis = row["Servis"].ToString();
                }
                if (row["Durum"] != DBNull.Value)
                {
                    item.Durum = row["Durum"].ToString();
                }

                items.Add(item);
            }

            return items;
        }

        public int Insert(NKRVM itemVM)
        {
            NKR item = new NKR();
            item.ID = itemVM.ID;
            item.Firma_ID = itemVM.Firma_ID;
            item.Evrak_No = itemVM.Evrak_No;
            item.Numune_Adi = itemVM.Numune_Adi;
            item.Adet = itemVM.Adet;
            item.Tarih = itemVM.Tarih;
            item.Tur = itemVM.Tur;
            item.Grup = itemVM.Grup;
            item.Analiz = itemVM.Analiz;
            item.Rapor_Durumu = itemVM.Rapor_Durumu;
            item.Aciklama = itemVM.Aciklama;
            item.RaporNo = itemVM.RaporNo;
            item.Akreditasyon = itemVM.Akreditasyon;
            item.Revno = itemVM.Revno;
            item.Servis = itemVM.Servis;
            item.Durum = itemVM.Durum;

            string query = serviceBase.Insert_Olustur("NKR");

            return serviceBase.Insert(tip, query, item);
        }

        public bool Update(NKRVM itemVM)
        {
            NKR item = new NKR();
            item.ID = itemVM.ID;
            item.Firma_ID = itemVM.Firma_ID;
            item.Evrak_No = itemVM.Evrak_No;
            item.Numune_Adi = itemVM.Numune_Adi;
            item.Adet = itemVM.Adet;
            item.Tarih = itemVM.Tarih;
            item.Tur = itemVM.Tur;
            item.Grup = itemVM.Grup;
            item.Analiz = itemVM.Analiz;
            item.Rapor_Durumu = itemVM.Rapor_Durumu;
            item.Aciklama = itemVM.Aciklama;
            item.RaporNo = itemVM.RaporNo;
            item.Akreditasyon = itemVM.Akreditasyon;
            item.Revno = itemVM.Revno;
            item.Servis = itemVM.Servis;
            item.Durum = itemVM.Durum;

            string query = serviceBase.Update_Olustur("NKR");

            return serviceBase.Update(tip, query, item);
        }

        public bool Delete(NKRVM itemVM)
        {
            NKR item = new NKR();
            item.ID = itemVM.ID;

            string query = serviceBase.Delete_Olustur("NKR");

            return serviceBase.Delete(tip, query, item);
        }
    }
}
