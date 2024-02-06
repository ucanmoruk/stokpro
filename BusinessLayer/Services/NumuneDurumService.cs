using BusinessLayer.ViewModels;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessLayer.Services
{
    public class NumuneDurumService : GenelService, IService<NumuneDurumVM>
    {
        ServiceBase<NumuneDurum> serviceBase = new ServiceBase<NumuneDurum>();

        int tip;
        public NumuneDurumService(int _tip) : base(_tip)
        {
            tip = _tip;
        }

        public NumuneDurumVM Get(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("NumuneDurum");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            DataTable dt = serviceBase.SelectText(tip, query, list);
            NumuneDurumVM item = new NumuneDurumVM();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                item.ID = Convert.ToInt32(row["ID"]);
            }

            return item;
        }

        public List<NumuneDurumVM> GetList(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("NumuneDurum");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            List<NumuneDurumVM> items = new List<NumuneDurumVM>();
            DataTable dt = serviceBase.SelectText(tip, query, list);

            foreach (DataRow row in dt.Rows)
            {
                NumuneDurumVM item = new NumuneDurumVM();
                item.ID = Convert.ToInt32(row["ID"]);

                items.Add(item);
            }

            return items;
        }

        public int Insert(NumuneDurumVM itemVM)
        {
            NumuneDurum item = new NumuneDurum();
            item.ID = itemVM.ID;


            string query = serviceBase.Insert_Olustur("NumuneDurum");

            return serviceBase.Insert(tip, query, item);
        }

        public bool Update(NumuneDurumVM itemVM)
        {
            NumuneDurum item = new NumuneDurum();
            item.ID = itemVM.ID;

            string query = serviceBase.Update_Olustur("NumuneDurum");

            return serviceBase.Update(tip, query, item);
        }

        public bool Delete(NumuneDurumVM itemVM)
        {
            NumuneDurum item = new NumuneDurum();
            item.ID = itemVM.ID;

            string query = serviceBase.Delete_Olustur("NumuneDurum");

            return serviceBase.Delete(tip, query, item);
        }
    }
}
