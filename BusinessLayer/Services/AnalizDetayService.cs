using BusinessLayer.ViewModels;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessLayer.Services
{
    public class AnalizDetayService: GenelService, IService<AnalizDetayVM>
    {
        ServiceBase<AnalizDetay> serviceBase = new ServiceBase<AnalizDetay>();

        int tip;
        public AnalizDetayService(int _tip) : base(_tip)
        {
            tip = _tip;
        }

        public AnalizDetayVM Get(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("AnalizDetay");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            DataTable dt = serviceBase.SelectText(tip, query, list);
            AnalizDetayVM analizDetayVM = new AnalizDetayVM();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                analizDetayVM.ID = Convert.ToInt32(row["ID"]);

            }

            return analizDetayVM;
        }

        public List<AnalizDetayVM> GetList(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("AnalizDetay");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            List<AnalizDetayVM> analizDetayVMs = new List<AnalizDetayVM>();
            DataTable dt = serviceBase.SelectText(tip, query, list);

            foreach (DataRow item in dt.Rows)
            {
                AnalizDetayVM analizDetayVM = new AnalizDetayVM();
                analizDetayVM.ID = Convert.ToInt32(item["ID"]);


                analizDetayVMs.Add(analizDetayVM);
            }

            return analizDetayVMs;
        }

        public int Insert(AnalizDetayVM analizDetayVM)
        {
            AnalizDetay analizDetay = new AnalizDetay();
            analizDetay.ID = analizDetayVM.ID;

            string query = serviceBase.Insert_Olustur("AnalizDetay");

            return serviceBase.Insert(tip, query, analizDetay);
        }

        public bool Update(AnalizDetayVM analizDetayVM)
        {
            AnalizDetay analizDetay = new AnalizDetay();
            analizDetay.ID = analizDetayVM.ID;

            string query = serviceBase.Update_Olustur("AnalizDetay");

            return serviceBase.Update(tip, query, analizDetay);
        }

        public bool Delete(AnalizDetayVM analizDetayVM)
        {
            AnalizDetay analizDetay = new AnalizDetay();
            analizDetay.ID = analizDetayVM.ID;

            string query = serviceBase.Delete_Olustur("AnalizDetay");

            return serviceBase.Delete(tip, query, analizDetay);
        }
    
    }
}
