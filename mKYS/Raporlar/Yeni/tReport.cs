using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using mKYS.Raporlar;
using System.Data.SqlClient;
using DevExpress.XtraPrinting.BarCode;
using QRCoder;

namespace mKYS.Raporlar.Yeni
{
    public partial class entReport : DevExpress.XtraReports.UI.XtraReport
    {
        public entReport()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        //int analizsayi;
        string analizaciklama;
        public void analizbul()
        {
            //SqlCommand komut3 = new SqlCommand(" declare @combinedString VARCHAR(MAX) select @combinedString = COALESCE(@combinedString + ', ', '') + Analiz_Adi from Analizler where ID in " +
            //    " (select AnalizID from Rapor_Analiz where RaporID = N'"+raporID+ "' except select distinct a.ID from Mix m inner join AnalizDetay d on d.ID = m.MetotID inner join Analizler a on a.ID = d.AnalizID where m.RaporNo = N'"+raporno+"' ) select @combinedString as yes", bgl.baglanti());

            SqlCommand komut3 = new SqlCommand(@"declare @combinedString VARCHAR(MAX) select @combinedString = COALESCE(@combinedString + ', ', '') + Ad 
            from StokAnalizListesi where ID in 
            (select AnalizID from NumuneX1 where RaporID = N'" + raporID + "' except select distinct a.ID from NumuneX2 m inner join StokAnalizListesi a on a.ID = m.AnalizID where m.RaporID = N'"+ raporID +"') select @combinedString as yes" , bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                analizaciklama = dr3["yes"].ToString();
            }
            bgl.baglanti().Close();


            if (analizaciklama == null)
            {
                xrLabel39.Visible = false;
            }
            else
            {
                pAnalizAciklama.Value = analizaciklama;
            }


        }



        string grup, uretici, aciklama, yonetmelik,revizyonaciklama, degisim;

        private void xrTable4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
        }

        int raporID, firmaID;
        public static string raporno, miktar, birim, mail, telefon, imza, onay, fname;

        public void bilgi()
        {
            pRaporNo.Value = raporno;


            SqlCommand komut = new SqlCommand("select ID, Grup, Aciklama from NKR where RaporNo = N'" + pRaporNo.Value + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                grup = dr["Grup"].ToString();
                raporID = Convert.ToInt32(dr["ID"]);
                aciklama = dr["Aciklama"].ToString();
            }
            bgl.baglanti().Close();

            SqlCommand komut2 = new SqlCommand("select AliciFirma from NumuneDetay where RaporID = N'" + raporID + "'", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                uretici = dr2["AliciFirma"].ToString();
            }
            bgl.baglanti().Close();

            if (grup == "Bakanlık")
            {
                string bakanlik = "Ticaret Bakanlığı " + uretici;

                SqlCommand komut12 = new SqlCommand("select ID, Firma_Adi, Adres from Firma where Firma_Adi like N'%"+bakanlik+"%'", bgl.baglanti());
                SqlDataReader dr12 = komut12.ExecuteReader();
                while (dr12.Read())
                {
                    pBakanlik.Value = dr12["Firma_Adi"].ToString();
                    pBakanlikAdres.Value = dr12["Adres"].ToString();
                    firmaID = Convert.ToInt32(dr12["ID"]);
                }
                bgl.baglanti().Close();
                if (aciklama != null)
                {
                    pUretici.Value = aciklama;
                }
                
                SqlCommand komuta2 = new SqlCommand("select Yetkili, Mail, Telefon from Yetkili where ID in (select DenetciID from NumuneDetay2 where RaporID= '"+raporID+"')", bgl.baglanti());
                SqlDataReader dra2 = komuta2.ExecuteReader();
                while (dra2.Read())
                {
                    pDenetci.Value = dra2["Yetkili"].ToString();
                    pDenetciBilgi.Value = dra2["Mail"].ToString() + ' ' + dra2["Telefon"].ToString();
                }
                bgl.baglanti().Close();

            }
            else
            {
                pUretici.Value = uretici;
            }

            SqlCommand komu2 = new SqlCommand("select * from Rapor_Aciklama where RaporNo = N'" + raporno + "'", bgl.baglanti());
            SqlDataReader d2 = komu2.ExecuteReader();
            while (d2.Read())
            {
                yonetmelik = d2["Aciklama"].ToString();
                revizyonaciklama = d2["Rev"].ToString();
                degisim = d2["Degisim"].ToString();
            }
            bgl.baglanti().Close();

            string raciklama = "Bu rapordaki test değerlendirmeleri, “Kimyasalların Kaydı, Değerlendirilmesi, İzni ve Kısıtlanması Hakkında Yönetmelik” ve standartlar ile yürürlükte olan diğer ilgili mevzuata göre yapılmıştır.";
            pAciklama.Value = raciklama;
            if (degisim != null)
            {
                if (degisim == "1")
                {
                    xLabel_rev.Visible = false;
                    pAciklama.Value = yonetmelik;
                }
                else if (degisim == "2")
                {
                    pRevizyonAciklama.Value = revizyonaciklama;
                }
                else if (degisim == "3")
                {
                    pAciklama.Value = yonetmelik;
                    pRevizyonAciklama.Value = revizyonaciklama;
                }
            }
            else
            {
                xLabel_rev.Visible = false;

            }


            analizbul();

            if (onay=="yes")
            {
                xrTableCell4.Text = "Doğrulama";
                xrLabel10.Visible = true;
                xrLabel6.Visible = true;
                xrPictureBox4.Visible = true;
                xrPictureBox5.Visible = true; 
                string str = "https://" + "www.massgrup.com/Raporlar/2023" + "/" + fname + ".pdf";
                QRCoder.QRCodeGenerator qrGenerator = new QRCoder.QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(str, QRCoder.QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);
                xrPictureBox3.Image = qrCodeImage;
            }

        }


    }
}
