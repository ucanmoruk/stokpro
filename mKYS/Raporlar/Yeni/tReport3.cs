using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using mKYS;
using System.Data.SqlClient;

namespace mKYS.Raporlar.Yeni
{
    public partial class tReport3 : DevExpress.XtraReports.UI.XtraReport
    {
        public tReport3()
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


        }
    }
}
