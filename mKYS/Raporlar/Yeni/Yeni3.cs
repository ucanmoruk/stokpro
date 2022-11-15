using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using mKYS;
using System.Data.SqlClient;

namespace mKYS.Raporlar.Yeni
{
    public partial class YeniRapor3 : DevExpress.XtraReports.UI.XtraReport
    {
        public YeniRapor3()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        string revno, tarih;
        int ID;
        public static string raporno, miktar, birim, mail, telefon, akr;
        public void bilgi()
        {

            pRaporNo.Value = raporno;

            SqlCommand komut = new SqlCommand("select Akreditasyon, RevNo from NKR where RaporNo = N'" + pRaporNo.Value + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                revno = dr["RevNo"].ToString();
                pRaprev.Value = raporno + " / " + revno;
                akr = dr["Akreditasyon"].ToString();

                if (akr == "Var")
                {
                    xrTable1.Visible = true;
                }
                else
                {
                    xrTable1.Visible = false;
                }
            }
            bgl.baglanti().Close();

           // SqlCommand komut = new SqlCommand("select ID, Revno, Tarih from NKR where RaporNo = N'" + pRaporNo.Value + "'", bgl.baglanti());
           // SqlDataReader dr = komut.ExecuteReader();
           // while (dr.Read())
           // {
           //     revno = dr["Revno"].ToString();
           //     ID = Convert.ToInt32(dr["ID"]);
           //     //     tarih = dr["Tarih"].ToString();
           // }
           // bgl.baglanti().Close();

           // // pRaporID.Value = ID;
           //pRaprev.Value = raporno + " / " + revno;
           
            //DateTime ptarih = DateTime.Parse(tarih);
            //pTarih.Value = ptarih.ToShortDateString();


        }
    }
}
