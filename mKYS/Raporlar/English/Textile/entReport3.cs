using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using mKYS;
using System.Data.SqlClient;

namespace mKYS.Raporlar.English.Textile
{
    public partial class entReport3 : DevExpress.XtraReports.UI.XtraReport
    {
        public entReport3()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        string revno, tarih;
        int ID, nikelID;
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

            //1206 nikel alt parametre ID
            SqlCommand komut2 = new SqlCommand("select Count(ID) from Numunex5 where AltAnalizID = 1206 and x2ID in (select ID from NumuneX2 where RaporID in (select ID from NKR where RaporNo = '" + pRaporNo.Value+"'))", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                nikelID = Convert.ToInt32(dr2[0].ToString());

                if (nikelID == 0)
                {
                    Nikel.Visible = false;
                }
                else
                {
                    Nikel.Visible = true;
                }
            }
            bgl.baglanti().Close();

            

        }
    }
}
