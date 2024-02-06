using BusinessLayer.ViewModels;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessLayer.Services
{
    public class NKR2Service: GenelService, IService<NKR2VM>
    {
        ServiceBase<NKR2> serviceBase = new ServiceBase<NKR2>();

        int tip;
        public NKR2Service(int _tip) : base(_tip)
        {
            tip = _tip;
        }

        public NKR2VM Get(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("NKR2");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            DataTable dt = serviceBase.SelectText(tip, query, list);
            NKR2VM item = new NKR2VM();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                item.ID = Convert.ToInt32(row["ID"]);
                if(row["NKRID"] != DBNull.Value)
                {
                    item.NKRID = Convert.ToInt32(row["NKRID"]);
                }
                if (row["FaturaFirmaID"] != DBNull.Value)
                {
                    item.FaturaFirmaID = Convert.ToInt32(row["FaturaFirmaID"]);
                }
                if (row["Talep"] != DBNull.Value)
                {
                    item.Talep = row["Talep"].ToString();
                }
                if (row["TalepNo"] != DBNull.Value)
                {               
                    item.TalepNo = row["TalepNo"].ToString();
                }
                if (row["TalepDosya"] != DBNull.Value)
                {
                    item.TalepDosya = row["TalepDosya"].ToString();
                }
                if (row["TeklifNo"] != DBNull.Value)
                {
                    item.TeklifNo = Convert.ToInt32(row["TeklifNo"]);
                }
                if (row["RaporDili"] != DBNull.Value)
                {
                    item.RaporDili = row["RaporDili"].ToString();
                }
                if (row["Gonderim"] != DBNull.Value)
                {
                    item.Gonderim = row["Gonderim"].ToString();
                }
                if (row["GAdresi"] != DBNull.Value)
                {
                    item.GAdresi = row["GAdresi"].ToString();
                }
                if (row["Iade"] != DBNull.Value)
                {
                    item.Iade = row["Iade"].ToString();
                }
                if (row["KararKurali"] != DBNull.Value)
                {
                    item.KararKurali = row["KararKurali"].ToString();
                }
                if (row["RaporAciklama"] != DBNull.Value)
                {
                    item.RaporAciklama = row["RaporAciklama"].ToString();
                }
                if (row["SartliKabul"] != DBNull.Value)
                {
                    item.SartliKabul = row["SartliKabul"].ToString();
                }
                if (row["Elyaf"] != DBNull.Value)
                {
                    item.Elyaf = row["Elyaf"].ToString();
                }
                if (row["Yikama"] != DBNull.Value)
                {
                    item.Yikama = row["Yikama"].ToString();
                }            
            }

            return item;
        }

        public List<NKR2VM> GetList(string filter = "", params object[] list)
        {
            string query = serviceBase.Select_Olustur("NKR2");
            if (!string.IsNullOrEmpty(filter))
            {
                query += " where " + filter;
            }

            List<NKR2VM> items = new List<NKR2VM>();
            DataTable dt = serviceBase.SelectText(tip, query, list);

            foreach (DataRow row in dt.Rows)
            {
                NKR2VM item = new NKR2VM();
                item.ID = Convert.ToInt32(row["ID"]);
                if (row["NKRID"] != DBNull.Value)
                {
                    item.NKRID = Convert.ToInt32(row["NKRID"]);
                }
                if (row["FaturaFirmaID"] != DBNull.Value)
                {
                    item.FaturaFirmaID = Convert.ToInt32(row["FaturaFirmaID"]);
                }
                if (row["Talep"] != DBNull.Value)
                {
                    item.Talep = row["Talep"].ToString();
                }
                if (row["TalepNo"] != DBNull.Value)
                {
                    item.TalepNo = row["TalepNo"].ToString();
                }
                if (row["TalepDosya"] != DBNull.Value)
                {
                    item.TalepDosya = row["TalepDosya"].ToString();
                }
                if (row["TeklifNo"] != DBNull.Value)
                {
                    item.TeklifNo = Convert.ToInt32(row["TeklifNo"]);
                }
                if (row["RaporDili"] != DBNull.Value)
                {
                    item.RaporDili = row["RaporDili"].ToString();
                }
                if (row["Gonderim"] != DBNull.Value)
                {
                    item.Gonderim = row["Gonderim"].ToString();
                }
                if (row["GAdresi"] != DBNull.Value)
                {
                    item.GAdresi = row["GAdresi"].ToString();
                }
                if (row["Iade"] != DBNull.Value)
                {
                    item.Iade = row["Iade"].ToString();
                }
                if (row["KararKurali"] != DBNull.Value)
                {
                    item.KararKurali = row["KararKurali"].ToString();
                }
                if (row["RaporAciklama"] != DBNull.Value)
                {
                    item.RaporAciklama = row["RaporAciklama"].ToString();
                }
                if (row["SartliKabul"] != DBNull.Value)
                {
                    item.SartliKabul = row["SartliKabul"].ToString();
                }
                if (row["Elyaf"] != DBNull.Value)
                {
                    item.Elyaf = row["Elyaf"].ToString();
                }
                if (row["Yikama"] != DBNull.Value)
                {
                    item.Yikama = row["Yikama"].ToString();
                }

                items.Add(item);
            }

            return items;
        }

        public int Insert(NKR2VM itemVM)
        {
            NKR2 item = new NKR2();
            item.ID = itemVM.ID;
            item.NKRID = itemVM.NKRID;
            item.FaturaFirmaID = itemVM.FaturaFirmaID;
            item.Talep = itemVM.Talep;
            item.TalepNo = itemVM.TalepNo;
            item.TalepDosya = itemVM.TalepDosya;
            item.TeklifNo = itemVM.TeklifNo;
            item.RaporDili = itemVM.RaporDili;
            item.Gonderim = itemVM.Gonderim;
            item.GAdresi = itemVM.GAdresi;
            item.Iade = itemVM.Iade;
            item.KararKurali = itemVM.KararKurali;
            item.RaporAciklama = itemVM.RaporAciklama;
            item.SartliKabul = itemVM.SartliKabul;
            item.Elyaf = itemVM.Elyaf;
            item.Yikama = itemVM.Yikama;

            string query = serviceBase.Insert_Olustur("NKR2");

            return serviceBase.Insert(tip, query, item);
        }

        public bool Update(NKR2VM itemVM)
        {
            NKR2 item = new NKR2();
            item.ID = itemVM.ID;
            item.NKRID = itemVM.NKRID;
            item.FaturaFirmaID = itemVM.FaturaFirmaID;
            item.Talep = itemVM.Talep;
            item.TalepNo = itemVM.TalepNo;
            item.TalepDosya = itemVM.TalepDosya;
            item.TeklifNo = itemVM.TeklifNo;
            item.RaporDili = itemVM.RaporDili;
            item.Gonderim = itemVM.Gonderim;
            item.GAdresi = itemVM.GAdresi;
            item.Iade = itemVM.Iade;
            item.KararKurali = itemVM.KararKurali;
            item.RaporAciklama = itemVM.RaporAciklama;
            item.SartliKabul = itemVM.SartliKabul;
            item.Elyaf = itemVM.Elyaf;
            item.Yikama = itemVM.Yikama;

            string query = serviceBase.Update_Olustur("NKR2");

            return serviceBase.Update(tip, query, item);
        }

        public bool Delete(NKR2VM itemVM)
        {
            NKR2 item = new NKR2();
            item.ID = itemVM.ID;

            string query = serviceBase.Delete_Olustur("NKR2");

            return serviceBase.Delete(tip, query, item);
        }

    }
}
