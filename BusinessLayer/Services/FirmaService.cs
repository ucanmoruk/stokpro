using BusinessLayer.ViewModels;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessLayer.Services
{
    public class FirmaService : GenelService, IService<FirmaVM>
    {
        ServiceBase<Firma> serviceBase = new ServiceBase<Firma>();

        int tip;
        public FirmaService(int _tip) : base(_tip)
        {
            tip = _tip;
        }

        public FirmaVM Get(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("Firma");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            DataTable dt = serviceBase.SelectText(tip, query, list);
            FirmaVM item = new FirmaVM();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                item.ID = Convert.ToInt32(row["ID"]);
                if (row["Firma_Adi"] != DBNull.Value)
                {
                    item.Firma_Adi = row["Firma_Adi"].ToString();
                }
                if (row["Adres"] != DBNull.Value)
                {
                    item.Adres = row["Adres"].ToString();
                }
                if (row["Vergi_Dairesi"] != DBNull.Value)
                {
                    item.Vergi_Dairesi = row["Vergi_Dairesi"].ToString();
                }
                if (row["Vergi_No"] != DBNull.Value)
                {
                    item.Vergi_No = row["Vergi_No"].ToString();
                }
                if (row["Telefon"] != DBNull.Value)
                {
                    item.Telefon = row["Telefon"].ToString();
                }
                if (row["Plasiyer"] != DBNull.Value)
                {
                    item.Plasiyer = row["Plasiyer"].ToString();
                }
                if (row["Yetkili"] != DBNull.Value)
                {
                    item.Yetkili = row["Yetkili"].ToString();
                }
                if (row["Mail"] != DBNull.Value)
                {
                    item.Mail = row["Mail"].ToString();
                }
                if (row["Durum"] != DBNull.Value)
                {
                    item.Durum = row["Durum"].ToString();
                }
                if (row["Sektor"] != DBNull.Value)
                {
                    item.Sektor = row["Sektor"].ToString();
                }
                if (row["Hizmet"] != DBNull.Value)
                {
                    item.Hizmet = row["Hizmet"].ToString();
                }
                if (row["Kod"] != DBNull.Value)
                {
                    item.Kod = row["Kod"].ToString();
                }
                if (row["Parola"] != DBNull.Value)
                {
                    item.Parola = row["Parola"].ToString();
                }
                if (row["Tur"] != DBNull.Value)
                {
                    item.Tur = row["Tur"].ToString();
                }
                if (row["Vade"] != DBNull.Value)
                {
                    item.Vade = row["Vade"].ToString();
                }
                if (row["PlasiyerID"] != DBNull.Value)
                {
                    item.PlasiyerID = Convert.ToInt32(row["PlasiyerID"]);
                }
                if (row["Odeme"] != DBNull.Value)
                {
                    item.Odeme = row["Odeme"].ToString();
                }

            }

            return item;
        }

        public List<FirmaVM> GetList(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("Firma");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            List<FirmaVM> items = new List<FirmaVM>();
            DataTable dt = serviceBase.SelectText(tip, query, list);

            foreach (DataRow row in dt.Rows)
            {
                FirmaVM item = new FirmaVM();
                item.ID = Convert.ToInt32(row["ID"]);
                if (row["Firma_Adi"] != DBNull.Value)
                {
                    item.Firma_Adi = row["Firma_Adi"].ToString();
                }
                if (row["Adres"] != DBNull.Value)
                {
                    item.Adres = row["Adres"].ToString();
                }
                if (row["Vergi_Dairesi"] != DBNull.Value)
                {
                    item.Vergi_Dairesi = row["Vergi_Dairesi"].ToString();
                }
                if (row["Vergi_No"] != DBNull.Value)
                {
                    item.Vergi_No = row["Vergi_No"].ToString();
                }
                if (row["Telefon"] != DBNull.Value)
                {
                    item.Telefon = row["Telefon"].ToString();
                }
                if (row["Plasiyer"] != DBNull.Value)
                {
                    item.Plasiyer = row["Plasiyer"].ToString();
                }
                if (row["Yetkili"] != DBNull.Value)
                {
                    item.Yetkili = row["Yetkili"].ToString();
                }
                if (row["Mail"] != DBNull.Value)
                {
                    item.Mail = row["Mail"].ToString();
                }
                if (row["Durum"] != DBNull.Value)
                {
                    item.Durum = row["Durum"].ToString();
                }
                if (row["Sektor"] != DBNull.Value)
                {
                    item.Sektor = row["Sektor"].ToString();
                }
                if (row["Hizmet"] != DBNull.Value)
                {
                    item.Hizmet = row["Hizmet"].ToString();
                }
                if (row["Kod"] != DBNull.Value)
                {
                    item.Kod = row["Kod"].ToString();
                }
                if (row["Parola"] != DBNull.Value)
                {
                    item.Parola = row["Parola"].ToString();
                }
                if (row["Tur"] != DBNull.Value)
                {
                    item.Tur = row["Tur"].ToString();
                }
                if (row["Vade"] != DBNull.Value)
                {
                    item.Vade = row["Vade"].ToString();
                }
                if (row["PlasiyerID"] != DBNull.Value)
                {
                    item.PlasiyerID = Convert.ToInt32(row["PlasiyerID"]);
                }
                if (row["Odeme"] != DBNull.Value)
                {
                    item.Odeme = row["Odeme"].ToString();
                }

                items.Add(item);
            }

            return items;
        }

        public int Insert(FirmaVM itemVM)
        {
            Firma item = new Firma();
            item.ID = itemVM.ID;
            item.Firma_Adi = itemVM.Firma_Adi;
            item.Adres = itemVM.Adres;
            item.Vergi_Dairesi = itemVM.Vergi_Dairesi;
            item.Vergi_No = itemVM.Vergi_No;
            item.Telefon = itemVM.Telefon;
            item.Plasiyer = itemVM.Plasiyer;
            item.Yetkili = itemVM.Yetkili;
            item.Mail = itemVM.Mail;
            item.Durum = itemVM.Durum;
            item.Sektor = itemVM.Sektor;
            item.Hizmet = itemVM.Hizmet;
            item.Kod = itemVM.Kod;
            item.Parola = itemVM.Parola;
            item.Tur = itemVM.Tur;
            item.Vade = itemVM.Vade;
            item.PlasiyerID = itemVM.PlasiyerID;
            item.Odeme = itemVM.Odeme;

            string query = serviceBase.Insert_Olustur("Firma");

            return serviceBase.Insert(tip, query, item);
        }

        public bool Update(FirmaVM itemVM)
        {
            Firma item = new Firma();
            item.ID = itemVM.ID;
            item.Firma_Adi = itemVM.Firma_Adi;
            item.Adres = itemVM.Adres;
            item.Vergi_Dairesi = itemVM.Vergi_Dairesi;
            item.Vergi_No = itemVM.Vergi_No;
            item.Telefon = itemVM.Telefon;
            item.Plasiyer = itemVM.Plasiyer;
            item.Yetkili = itemVM.Yetkili;
            item.Mail = itemVM.Mail;
            item.Durum = itemVM.Durum;
            item.Sektor = itemVM.Sektor;
            item.Hizmet = itemVM.Hizmet;
            item.Kod = itemVM.Kod;
            item.Parola = itemVM.Parola;
            item.Tur = itemVM.Tur;
            item.Vade = itemVM.Vade;
            item.PlasiyerID = itemVM.PlasiyerID;
            item.Odeme = itemVM.Odeme;

            string query = serviceBase.Update_Olustur("Firma");

            return serviceBase.Update(tip, query, item);
        }

        public bool Delete(FirmaVM itemVM)
        {
            Firma item = new Firma();
            item.ID = itemVM.ID;

            string query = serviceBase.Delete_Olustur("Firma");

            return serviceBase.Delete(tip, query, item);
        }
    }
}
