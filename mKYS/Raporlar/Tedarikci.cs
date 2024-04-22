using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;

namespace mKYS.Raporlar
{
    public partial class Tedarikci : DevExpress.XtraReports.UI.XtraReport
    {
        public Tedarikci()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();
        string revno, tarih, ytarih;
        public static string firmaID;
        public void bilgi()
        {
            //pAciklama.Value = "Ç.02.PR.04";
            //pFirmaID.Value = firmaID;
            //SqlCommand komut = new SqlCommand("select * from DokumanMaster where Kod = N'" + pAciklama.Value + "'", bgl.baglanti());
            //SqlDataReader dr = komut.ExecuteReader();
            //while (dr.Read())
            //{
            //    revno = dr["Revno"].ToString();
            //    tarih = dr["RevTarihi"].ToString();
            //    ytarih = dr["YayinTarihi"].ToString();
            //}
            //bgl.baglanti().Close();

            //pRev.Value = revno + " / " + tarih;
            ////pYayin.Value = ytarih;
            //DateTime ptarih = DateTime.Parse(ytarih);
            //pYayin.Value = ptarih.ToShortDateString();

        }

    }
}
