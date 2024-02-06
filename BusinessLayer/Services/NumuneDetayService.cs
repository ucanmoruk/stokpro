using BusinessLayer.ViewModels;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessLayer.Services
{
    public class NumuneDetayService: GenelService, IService<NumuneDetayVM>
    {
        ServiceBase<NumuneDetay> serviceBase = new ServiceBase<NumuneDetay>();

        int tip;
        public NumuneDetayService(int _tip) : base(_tip)
        {
            tip = _tip;
        }

        public NumuneDetayVM Get(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("NumuneDetay");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            DataTable dt = serviceBase.SelectText(tip, query, list);
            NumuneDetayVM item = new NumuneDetayVM();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                item.ID = Convert.ToInt32(row["ID"]);
                if (row["RaporID"] != DBNull.Value)
                {
                    item.RaporID = Convert.ToInt32(row["RaporID"]);
                }
                if (row["MiktarEx"] != DBNull.Value)
                {
                    item.MiktarEx = row["MiktarEx"].ToString();
                }
                if (row["Marka"] != DBNull.Value)
                {
                    item.Marka = row["Marka"].ToString();
                }
                if (row["Model"] != DBNull.Value)
                {
                    item.Model = row["Model"].ToString();
                }
                if (row["BasvuruNo"] != DBNull.Value)
                {
                    item.BasvuruNo = row["BasvuruNo"].ToString();
                }
                if (row["SeriNo"] != DBNull.Value)
                {
                    item.SeriNo = row["SeriNo"].ToString();
                }
                if (row["UretimTarihi"] != DBNull.Value)
                {
                    item.UretimTarihi = row["UretimTarihi"].ToString();
                }
                if (row["SKT"] != DBNull.Value)
                {
                    item.SKT = row["SKT"].ToString();
                }
                if (row["AliciFirma"] != DBNull.Value)
                {
                    item.AliciFirma = row["AliciFirma"].ToString();
                }
                if (row["ProjeID"] != DBNull.Value)
                {
                    item.ProjeID = Convert.ToInt32(row["ProjeID"]);
                }
                if (row["Miktar"] != DBNull.Value)
                {
                    item.Miktar = Convert.ToInt32(row["Miktar"]);
                }
                if (row["Birim"] != DBNull.Value)
                {
                    item.Birim = row["Birim"].ToString();
                }
        
            }

            return item;
        }

        public List<NumuneDetayVM> GetList(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("NumuneDetay");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            List<NumuneDetayVM> items = new List<NumuneDetayVM>();
            DataTable dt = serviceBase.SelectText(tip, query, list);

            foreach (DataRow row in dt.Rows)
            {
                NumuneDetayVM item = new NumuneDetayVM();
                item.ID = Convert.ToInt32(row["ID"]);
                if (row["RaporID"] != DBNull.Value)
                {
                    item.RaporID = Convert.ToInt32(row["RaporID"]);
                }
                if (row["MiktarEx"] != DBNull.Value)
                {
                    item.MiktarEx = row["MiktarEx"].ToString();
                }
                if (row["Marka"] != DBNull.Value)
                {
                    item.Marka = row["Marka"].ToString();
                }
                if (row["Model"] != DBNull.Value)
                {
                    item.Model = row["Model"].ToString();
                }
                if (row["BasvuruNo"] != DBNull.Value)
                {
                    item.BasvuruNo = row["BasvuruNo"].ToString();
                }
                if (row["SeriNo"] != DBNull.Value)
                {
                    item.SeriNo = row["SeriNo"].ToString();
                }
                if (row["UretimTarihi"] != DBNull.Value)
                {
                    item.UretimTarihi = row["UretimTarihi"].ToString();
                }
                if (row["SKT"] != DBNull.Value)
                {
                    item.SKT = row["SKT"].ToString();
                }
                if (row["AliciFirma"] != DBNull.Value)
                {
                    item.AliciFirma = row["AliciFirma"].ToString();
                }
                if (row["ProjeID"] != DBNull.Value)
                {
                    item.ProjeID = Convert.ToInt32(row["ProjeID"]);
                }
                if (row["Miktar"] != DBNull.Value)
                {
                    item.Miktar = Convert.ToInt32(row["Miktar"]);
                }
                if (row["Birim"] != DBNull.Value)
                {
                    item.Birim = row["Birim"].ToString();
                }

                items.Add(item);
            }

            return items;
        }

        public int Insert(NumuneDetayVM itemVM)
        {
            NumuneDetay item = new NumuneDetay();
            item.ID = itemVM.ID;
            item.RaporID = itemVM.RaporID;
            item.MiktarEx = itemVM.MiktarEx;
            item.Marka = itemVM.Marka;
            item.Model = itemVM.Model;
            item.BasvuruNo = itemVM.BasvuruNo;
            item.SeriNo = itemVM.SeriNo;
            item.UretimTarihi = itemVM.UretimTarihi;
            item.SKT = itemVM.SKT;
            item.AliciFirma = itemVM.AliciFirma;
            item.ProjeID = itemVM.ProjeID;
            item.Miktar = itemVM.Miktar;
            item.Birim = itemVM.Birim;

            string query = serviceBase.Insert_Olustur("NumuneDetay");

            return serviceBase.Insert(tip, query, item);
        }

        public bool Update(NumuneDetayVM itemVM)
        {
            NumuneDetay item = new NumuneDetay();
            item.ID = itemVM.ID;
            item.RaporID = itemVM.RaporID;
            item.MiktarEx = itemVM.MiktarEx;
            item.Marka = itemVM.Marka;
            item.Model = itemVM.Model;
            item.BasvuruNo = itemVM.BasvuruNo;
            item.SeriNo = itemVM.SeriNo;
            item.UretimTarihi = itemVM.UretimTarihi;
            item.SKT = itemVM.SKT;
            item.AliciFirma = itemVM.AliciFirma;
            item.ProjeID = itemVM.ProjeID;
            item.Miktar = itemVM.Miktar;
            item.Birim = itemVM.Birim;

            string query = serviceBase.Update_Olustur("NumuneDetay");

            return serviceBase.Update(tip, query, item);
        }

        public bool Delete(NumuneDetayVM itemVM)
        {
            NumuneDetay item = new NumuneDetay();
            item.ID = itemVM.ID;

            string query = serviceBase.Delete_Olustur("NumuneDetay");

            return serviceBase.Delete(tip, query, item);
        }
    }
}
