using BusinessLayer.ViewModels;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessLayer.Services
{
    public class TerminService: GenelService, IService<TerminVM>
    {
        ServiceBase<Terminn> serviceBase = new ServiceBase<Terminn>();

        int tip;
        public TerminService(int _tip) : base(_tip)
        {
            tip = _tip;
        }

        public TerminVM Get(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("Termin");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            DataTable dt = serviceBase.SelectText(tip, query, list);
            TerminVM item = new TerminVM();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                item.ID = Convert.ToInt32(row["ID"]);
                if (row["RaporID"] != DBNull.Value)
                {
                    item.RaporID = Convert.ToInt32(row["RaporID"]);
                }
                if (row["Termin"] != DBNull.Value)
                {
                    item.Termin = Convert.ToDateTime(row["Termin"]);
                } 
            }

            return item;
        }

        public List<TerminVM> GetList(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("Termin");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            List<TerminVM> items = new List<TerminVM>();
            DataTable dt = serviceBase.SelectText(tip, query, list);

            foreach (DataRow row in dt.Rows)
            {
                TerminVM item = new TerminVM();
                item.ID = Convert.ToInt32(row["ID"]);
                if (row["RaporID"] != DBNull.Value)
                {
                    item.RaporID = Convert.ToInt32(row["RaporID"]);
                }
                if (row["Termin"] != DBNull.Value)
                {
                    item.Termin = Convert.ToDateTime(row["Termin"]);
                }

                items.Add(item);
            }

            return items;
        }

        public int Insert(TerminVM itemVM)
        {
            Terminn item = new Terminn();
            item.ID = itemVM.ID;
            item.RaporID = itemVM.RaporID;
            item.Termin = itemVM.Termin;

            string query = serviceBase.Insert_Olustur("Termin");

            return serviceBase.Insert(tip, query, item);
        }

        public bool Update(TerminVM itemVM)
        {
            Terminn item = new Terminn();
            item.ID = itemVM.ID;
            item.RaporID = itemVM.RaporID;
            item.Termin = itemVM.Termin;

            string query = serviceBase.Update_Olustur("Termin");

            return serviceBase.Update(tip, query, item);
        }

        public bool Delete(TerminVM itemVM)
        {
            Terminn item = new Terminn();
            item.ID = itemVM.ID;

            string query = serviceBase.Delete_Olustur("Termin");

            return serviceBase.Delete(tip, query, item);
        }
    }
}
