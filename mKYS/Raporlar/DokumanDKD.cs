using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;

namespace mKYS.Raporlar
{
    public partial class DokumanDKD : DevExpress.XtraReports.UI.XtraReport
    {
        public DokumanDKD()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        string revno, tarih, ytarih;
        public void bilgi()
        {
            pAciklama.Value = "Ç.04.PR.02";

            SqlCommand komut = new SqlCommand("select * from DokumanMaster where Kod = N'" + pAciklama.Value + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                revno = dr["Revno"].ToString();
                tarih = dr["RevTarihi"].ToString();
                ytarih = dr["YayinTarihi"].ToString();
            }
            bgl.baglanti().Close();

            //pRaporID.Value = ID;
            pRev.Value = revno + " / " + tarih;

            DateTime ptarih = DateTime.Parse(ytarih);
            pYayin.Value = ptarih.ToShortDateString();

        }
    }
}
