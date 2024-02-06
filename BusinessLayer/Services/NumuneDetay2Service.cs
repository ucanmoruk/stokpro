using BusinessLayer.ViewModels;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessLayer.Services
{
    public class NumuneDetay2Service: GenelService, IService<NumuneDetay2VM>
    {
        ServiceBase<NumuneDetay2> serviceBase = new ServiceBase<NumuneDetay2>();

        int tip;
        public NumuneDetay2Service(int _tip) : base(_tip)
        {
            tip = _tip;
        }

        public NumuneDetay2VM Get(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("NumuneDetay2");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            DataTable dt = serviceBase.SelectText(tip, query, list);
            NumuneDetay2VM item = new NumuneDetay2VM();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                item.ID = Convert.ToInt32(row["ID"]);
                if (row["RaporID"] != DBNull.Value)
                {
                    item.RaporID = Convert.ToInt32(row["RaporID"]);
                }
                if (row["YetkiliID"] != DBNull.Value)
                {
                    item.YetkiliID = Convert.ToInt32(row["YetkiliID"]);
                }
                if (row["DenetciID"] != DBNull.Value)
                {
                    item.DenetciID = Convert.ToInt32(row["DenetciID"]);
                }   
            }

            return item;
        }

        public List<NumuneDetay2VM> GetList(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("NumuneDetay2");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            List<NumuneDetay2VM> items = new List<NumuneDetay2VM>();
            DataTable dt = serviceBase.SelectText(tip, query, list);

            foreach (DataRow row in dt.Rows)
            {
                NumuneDetay2VM item = new NumuneDetay2VM();
                item.ID = Convert.ToInt32(row["ID"]);
                if (row["RaporID"] != DBNull.Value)
                {
                    item.RaporID = Convert.ToInt32(row["RaporID"]);
                }
                if (row["YetkiliID"] != DBNull.Value)
                {
                    item.YetkiliID = Convert.ToInt32(row["YetkiliID"]);
                }
                if (row["DenetciID"] != DBNull.Value)
                {
                    item.DenetciID = Convert.ToInt32(row["DenetciID"]);
                }

                items.Add(item);
            }

            return items;
        }

        public int Insert(NumuneDetay2VM itemVM)
        {
            NumuneDetay2 item = new NumuneDetay2();
            item.ID = itemVM.ID;
            item.RaporID = itemVM.RaporID;
            item.YetkiliID = itemVM.YetkiliID;
            item.DenetciID = itemVM.DenetciID;

            string query = serviceBase.Insert_Olustur("NumuneDetay2");

            return serviceBase.Insert(tip, query, item);
        }

        public bool Update(NumuneDetay2VM itemVM)
        {
            NumuneDetay2 item = new NumuneDetay2();
            item.ID = itemVM.ID;
            item.RaporID = itemVM.RaporID;
            item.YetkiliID = itemVM.YetkiliID;
            item.DenetciID = itemVM.DenetciID;

            string query = serviceBase.Update_Olustur("NumuneDetay2");

            return serviceBase.Update(tip, query, item);
        }

        public bool Delete(NumuneDetay2VM itemVM)
        {
            NumuneDetay2 item = new NumuneDetay2();
            item.ID = itemVM.ID;

            string query = serviceBase.Delete_Olustur("NumuneDetay2");

            return serviceBase.Delete(tip, query, item);
        }
    }
}
