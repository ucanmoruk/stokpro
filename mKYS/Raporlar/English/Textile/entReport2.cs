using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using mKYS;
using System.Data.SqlClient;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Drawing;
using System.Net;
using System.IO;

namespace mKYS.Raporlar.English.Textile
{
    public partial class entReport2 : DevExpress.XtraReports.UI.XtraReport
    {
        public entReport2()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        string path;
        int ID, firmaID;

        private void xrPictureBox2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //bilgi();
            //pResimUrl.Value = @"https://" + "www.massgrup.com/mask/Numune/Foto_2021" + "/" + path;
        }

        public static string raporno, akr, revno, mail, telefon, analizadi, fotoname;
        public void bilgi()
        {
            pRaporNo.Value = raporno;

            SqlCommand komut = new SqlCommand("select Akreditasyon, RevNo from NKR where RaporNo = N'" + pRaporNo.Value + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                revno = dr["RevNo"].ToString();
                pRevNo.Value = raporno + " / " + revno;
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

            //SqlCommand komut2 = new SqlCommand("select Path from Fotograf where RaporID = N'" + ID + "'", bgl.baglanti());
            SqlCommand komut2 = new SqlCommand("select Path from Fotograf where RaporID = (select ID from NKR where RaporNo = N'" + raporno + "')", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                path = dr2["Path"].ToString();
            }
            bgl.baglanti().Close();


            pResimUrl.Value = @"http://" + "www.massgrup.com/mask/Numune/Foto_2021" + "/" + path;


        }
    }
}
