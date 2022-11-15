using mKYS;
using mKYS.Musteri;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mKYS.Raporlar
{
    public partial class ProformaFatura : DevExpress.XtraReports.UI.XtraReport
    {
        public ProformaFatura()
        {
            InitializeComponent();
        }

        ProformaUpdate n = (ProformaUpdate)Application.OpenForms["ProformaUpdate"];
        sqlbaglanti bgl = new sqlbaglanti();

        
        public void bilgi()
        {

            //evrakno = NKR.evrakNo;
            //pEvrakNo.Value = evrakno;
            //faturafirma = MAYS.Fatura.PaketFatura.faturafirma;
            //pFaturaFirma.Value = faturafirma;
            //raporfirma = NKR.ffirma;
            //pRaporFirma.Value = raporfirma;

            //gtutar = MAYS.Fatura.PaketFatura.gtutar;
            //ptutar.Value = gtutar;
            //kdv = MAYS.Fatura.PaketFatura.kdv ;
            //pkdv.Value = kdv;
            //gtoplam = MAYS.Fatura.PaketFatura.gtoplam ;
            //pgtoplam.Value = gtoplam;

            //kurturu = Fatura.PaketFatura.kurturu ;
            //pparabirim.Value = kurturu;
            //kurTl = Fatura.PaketFatura.kurTl;
            //pkur.Value = kurTl;
            //birimfiyat = Fatura.PaketFatura.birimfiyat;
            //pPaket.Value = birimfiyat;

            //proje = Fatura.PaketFatura.proje;
            //pProjeAdı.Value = proje;
            //urun = NKR.ftur;
            //pUrungrubu.Value = urun;

            //SqlCommand komut = new SqlCommand("Select Adres, Vergi_Dairesi,Vergi_No,Mail, Plasiyer from Firma where Firma_Adi = '" + faturafirma + "'", bgl.baglanti());
            //SqlDataReader dr = komut.ExecuteReader();
            //while (dr.Read())
            //{
            //    adres = dr["Adres"].ToString();
            //    vd = dr["Vergi_Dairesi"].ToString();
            //    vn = dr["Vergi_No"].ToString();
            //    mail = dr["Mail"].ToString();
            //    pl = dr["Plasiyer"].ToString();
            //}
            //bgl.baglanti().Close();

            //pAdres.Value = ProformaUpdate.adres;
            //pVergiDairesi.Value = vd;
            //pVergiNo.Value = vn;
            //pMail.Value = mail;
            //pPlasiyer.Value = pl;

            //SqlCommand komut5 = new SqlCommand("select Aciklama, Miktar, Birim, BirimFiyatTl, ToplamFiyat, Iskonto, GenelFiyat from FaturaDetay where ProformaNo = '" + evrakno + "'", bgl.baglanti());
            //SqlDataReader dr5 = komut5.ExecuteReader();
            //while (dr5.Read())
            //{
            //    pAciklama.Value = dr5["Aciklama"].ToString();
            //    //vd = dr5["Adet"].ToString();
            //    //vn = dr5["AdetBirimi"].ToString();
            //    //mail = dr5["BirimFiyatTl"].ToString();
            //    //pl = dr5["ToplamFiyat"].ToString();
            //    //pl = dr5["Iskonto"].ToString();
            //    //pl = dr5["GenelFiyat"].ToString();
            //}
            //bgl.baglanti().Close();



        }

        public int len;
        public static string pl, aciklama;
        public void bilgi2()
        {
            pEvrakNo.Value = ProformaUpdate.evrakno;
            pFaturaFirma.Value = ProformaUpdate.faturafirma;
            pRaporFirma.Value = ProformaUpdate.raporfirma;

            ptutar.Value = ProformaUpdate.gtutar;
            pkdv.Value = ProformaUpdate.kdv;
            pgtoplam.Value = ProformaUpdate.gtoplam;

            pparabirim.Value = ProformaUpdate.parabirimi;
            pGunlukKur.Value = ProformaUpdate.kurTl;

            pAdres.Value = ProformaUpdate.adres;
            pVergiDairesi.Value = ProformaUpdate.vd;
            pVergiNo.Value = ProformaUpdate.vn;
            pMail.Value = ProformaUpdate.mail;

            
            //SqlCommand komut5 = new SqlCommand("select count(ID) as ad from FaturaDetay where ProformaNo = '" + ProformaUpdate.evrakno + "'", bgl.baglanti());
            //SqlDataReader dr5 = komut5.ExecuteReader();
            //while (dr5.Read())
            //{
            //    len = Convert.ToInt32(dr5["ad"].ToString()); 
            //}
      
            //bgl.baglanti().Close();
            //pPlasiyer.Value = pl;

            SqlCommand komut = new SqlCommand("select Ad from Kullanici where ID in (select PlasiyerID from TeklifListe where TeklifNo = '" + ProformaUpdate.teklifno + "')", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                pl = dr["Ad"].ToString();
            }
            bgl.baglanti().Close();
            pPlasiyer.Value = pl;


            //for (int i = 0; i < len; i++)
            //{
            //    SqlCommand komut2 = new SqlCommand("Select Aciklama, UrunGrubu, Miktar, Birim, BirimFiyat,ParaBirimi, BirimFiyatTl, ToplamFiyat, Iskonto, GenelFiyat from FaturaDetay where ProformaNo = '" + ProformaUpdate.evrakno + "' ", bgl.baglanti());
            //    SqlDataReader dr2 = komut2.ExecuteReader();
            //    while (dr2.Read())
            //    {
            //        aciklama = dr2["Aciklama"].ToString();

            //    }
            //    bgl.baglanti().Close();
            //}
           

            //pAciklama.Value = aciklama;

            pTeklifNo.Value = ProformaUpdate.teklifno;
            pTeklifTur.Value = ProformaUpdate.teklifturu;
            piskonto.Value = ProformaUpdate.iskonto;


        }

    }
}
