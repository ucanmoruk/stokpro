using BusinessLayer.ViewModels;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class AnalizlerService: GenelService, IService<AnalizlerVM>
    {
        ServiceBase<Analizler> serviceBase = new ServiceBase<Analizler>();

        int tip;
        public AnalizlerService(int _tip) : base(_tip)
        {
            tip = _tip;
        }

        public AnalizlerVM Get(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("Analizler");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            DataTable dt = serviceBase.SelectText(tip, query, list);
            AnalizlerVM item = new AnalizlerVM();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                item.ID = Convert.ToInt32(row["ID"]);
                item.Sira = Convert.ToInt32(row["Sira"]);
                item.Kod = row["Kod"].ToString();
                item.Analiz_Adi = row["Analiz_Adi"].ToString();
                item.Metot = row["Metot"].ToString();
                item.AdEn = row["AdEn"].ToString();
                item.MetotEn = row["MetotEn"].ToString();
                item.Matriks = row["Matriks"].ToString();
                item.Akreditasyon = row["Akreditasyon"].ToString();
                item.Teknik = row["Teknik"].ToString();
                item.Tur = row["Tur"].ToString();
                item.Sure = row["Sure"].ToString();
                item.Durum = row["Durum"].ToString();
            }

            return item;
        }

        public List<AnalizlerVM> GetList(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("Analizler");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            List<AnalizlerVM> items = new List<AnalizlerVM>();
            DataTable dt = serviceBase.SelectText(tip, query, list);

            foreach (DataRow row in dt.Rows)
            {
                AnalizlerVM item = new AnalizlerVM();
                item.ID = Convert.ToInt32(row["ID"]);
                item.Sira = Convert.ToInt32(row["Sira"]);
                item.Kod = row["Kod"].ToString();
                item.Analiz_Adi = row["Analiz_Adi"].ToString();
                item.Metot = row["Metot"].ToString();
                item.AdEn = row["AdEn"].ToString();
                item.MetotEn = row["MetotEn"].ToString();
                item.Matriks = row["Matriks"].ToString();
                item.Akreditasyon = row["Akreditasyon"].ToString();
                item.Teknik = row["Teknik"].ToString();
                item.Tur = row["Tur"].ToString();
                item.Sure = row["Sure"].ToString();
                item.Durum = row["Durum"].ToString();

                items.Add(item);
            }

            return items;
        }

        public int Insert(AnalizlerVM itemVM)
        {
            Analizler item = new Analizler();
            item.ID = itemVM.ID;
            item.Sira = itemVM.Sira;
            item.Kod = itemVM.Kod;
            item.Analiz_Adi = itemVM.Analiz_Adi;
            item.Metot = itemVM.Metot;
            item.AdEn = itemVM.AdEn;
            item.MetotEn = itemVM.MetotEn;
            item.Matriks = itemVM.Matriks;
            item.Akreditasyon = itemVM.Akreditasyon;
            item.Teknik = itemVM.Teknik;
            item.Tur = itemVM.Tur;
            item.Sure = itemVM.Sure;
            item.Durum = itemVM.Durum;

            string query = serviceBase.Insert_Olustur("Analizler");

            return serviceBase.Insert(tip, query, item);
        }

        public bool Update(AnalizlerVM itemVM)
        {
            Analizler item = new Analizler();
            item.ID = itemVM.ID;
            item.Sira = itemVM.Sira;
            item.Kod = itemVM.Kod;
            item.Analiz_Adi = itemVM.Analiz_Adi;
            item.Metot = itemVM.Metot;
            item.AdEn = itemVM.AdEn;
            item.MetotEn = itemVM.MetotEn;
            item.Matriks = itemVM.Matriks;
            item.Akreditasyon = itemVM.Akreditasyon;
            item.Teknik = itemVM.Teknik;
            item.Tur = itemVM.Tur;
            item.Sure = itemVM.Sure;
            item.Durum = itemVM.Durum;

            string query = serviceBase.Update_Olustur("Analizler");

            return serviceBase.Update(tip, query, item);
        }

        public bool Delete(AnalizlerVM itemVM)
        {
            Analizler item = new Analizler();
            item.ID = itemVM.ID;

            string query = serviceBase.Delete_Olustur("Analizler");

            return serviceBase.Delete(tip, query, item);
        }
    
    }
}
