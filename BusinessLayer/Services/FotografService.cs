using BusinessLayer.ViewModels;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessLayer.Services
{
    public class FotografService: GenelService, IService<FotografVM>
    {
        ServiceBase<Fotograf> serviceBase = new ServiceBase<Fotograf>();

        int tip;
        public FotografService(int _tip) : base(_tip)
        {
            tip = _tip;
        }

        public FotografVM Get(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("Fotograf");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            DataTable dt = serviceBase.SelectText(tip, query, list);
            FotografVM item = new FotografVM();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                item.ID = Convert.ToInt32(row["ID"]);
                if (row["RaporID"] != DBNull.Value)
                {
                    item.RaporID = Convert.ToInt32(row["RaporID"]);
                }
                if (row["Path"] != DBNull.Value)
                {
                    item.Path = row["Path"].ToString();
                }
            }

            return item;
        }

        public List<FotografVM> GetList(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("Fotograf");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            List<FotografVM> items = new List<FotografVM>();
            DataTable dt = serviceBase.SelectText(tip, query, list);

            foreach (DataRow row in dt.Rows)
            {
                FotografVM item = new FotografVM();
                item.ID = Convert.ToInt32(row["ID"]);
                if (row["RaporID"] != DBNull.Value)
                {
                    item.RaporID = Convert.ToInt32(row["RaporID"]);
                }
                if (row["Path"] != DBNull.Value)
                {
                    item.Path = row["Path"].ToString();
                }

                items.Add(item);
            }

            return items;
        }

        public int Insert(FotografVM itemVM)
        {
            Fotograf item = new Fotograf();
            item.ID = itemVM.ID;
            item.RaporID = itemVM.RaporID;
            item.Path = itemVM.Path;

            string query = serviceBase.Insert_Olustur("Fotograf");

            return serviceBase.Insert(tip, query, item);
        }

        public bool Update(FotografVM itemVM)
        {
            Fotograf item = new Fotograf();
            item.ID = itemVM.ID;
            item.RaporID = itemVM.RaporID;
            item.Path = itemVM.Path;

            string query = serviceBase.Update_Olustur("Fotograf");

            return serviceBase.Update(tip, query, item);
        }

        public bool Delete(FotografVM itemVM)
        {
            Fotograf item = new Fotograf();
            item.ID = itemVM.ID;

            string query = serviceBase.Delete_Olustur("Fotograf");

            return serviceBase.Delete(tip, query, item);
        }

    }
}
