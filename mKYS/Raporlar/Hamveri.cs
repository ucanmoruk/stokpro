using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;
using mKYS;

namespace mKYS.Raporlar
{
    public partial class Hamveri : DevExpress.XtraReports.UI.XtraReport
    {
        public Hamveri()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();

        string numuneadi, model, analiz, tanim, tarih;
        public static string raporno;
        int analizID, raporID;
        public void bilgi()
        {       
            //pRaporno.Value = Numune.Mix.raporno;
          //  pRaporno.Value = TanimlamaListesi.raporno;
            pRaporno.Value = raporno;

            SqlCommand komut = new SqlCommand("select Numune_Adi, Tarih, ID from NKR where RaporNo= '"+ pRaporno.Value + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                 numuneadi = dr["Numune_Adi"].ToString();
                 tarih = dr["Tarih"].ToString();
                 raporID = Convert.ToInt32(dr["ID"].ToString());
            }
            bgl.baglanti().Close();

            SqlCommand komut2 = new SqlCommand("select Model from NumuneDetay where RaporID ='"+raporID+"' ", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                model = dr2["Model"].ToString();
            }
            bgl.baglanti().Close();

           // SqlCommand komut12 = new SqlCommand(" Select concat(Kod, ' - ',Analiz_Adi,' - ', Metot),ID from Analizler where ID in (select MetotID from mix where RaporNo = '"+ pRaporno.Value + "')", bgl.baglanti());
            SqlCommand komut12 = new SqlCommand(" Select concat(Kod, ' - ',Ad,' - ', Method), ID from StokAnalizListesi where ID in (select AnalizID from NumuneX2 where RaporID = '"+ raporID + "')", bgl.baglanti());
            SqlDataReader dr12 = komut12.ExecuteReader();
            while (dr12.Read())
            {
                analiz = dr12[0].ToString();
                analizID = Convert.ToInt32(dr12[1].ToString());
            }
            bgl.baglanti().Close();

            SqlCommand komut13 = new SqlCommand(" Select Aciklama from NumuneX2 where RaporID = '"+ raporID+ "'", bgl.baglanti());
            //and AnalizID = '"+analizID+"'
            SqlDataReader dr13 = komut13.ExecuteReader();
            while (dr13.Read())
            {
                tanim = dr13[0].ToString();
            }
            bgl.baglanti().Close();

            pNumuneAd.Value = numuneadi+" - "+model;
            pAnaliz.Value = analiz;
            pTanim.Value = tanim;

            DateTime ptarih = DateTime.Parse(tarih);
            pKabul.Value = ptarih.ToShortDateString();
        }
    }
}
