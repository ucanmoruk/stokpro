using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace mKYS.Analiz
{
    public partial class AnalizDetay : Form
    {
        public AnalizDetay()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt2 = new DataTable();
            //  SqlDataAdapter da2 = new SqlDataAdapter("select r.StokKod as 'Kod', l.Ad, l.Miktar, l.Birim, l.Limit as 'Kritik Limit' from StokRecete r inner join StokListesi l on r.StokKod = l.Kod where r.AnalizKod = N'" + skod + "' order by r.StokKod", bgl.baglanti());
            //   SqlDataAdapter da2 = new SqlDataAdapter("select Kod, Ad, Miktar, Birim, Limit as 'Kritik Limit' from StokListesi where ID in (select StokID from StokRecete where AnalizID = '" + aID + "')", bgl.baglanti());
            SqlDataAdapter da2 = new SqlDataAdapter("select l.Kod, l.Ad, l.Miktar as 'Stok Miktarı', r.Miktar as 'Kullanılan Miktar', l.Birim, l.Limit as 'Kritik Limit' " +
             " from StokListesi l left join StokRecete r on l.ID = r.StokID where r.AnalizID = '" + aID + "'", bgl.baglanti());

            da2.Fill(dt2);
            gridControl2.DataSource = dt2;

            this.gridView2.Columns[0].Width = 40;
            this.gridView2.Columns[3].Width = 30;
            this.gridView2.Columns[2].Width = 40;
            this.gridView2.Columns[4].Width = 40;
            this.gridView2.Columns[5].Width = 40;

            DataTable dt7 = new DataTable();
            SqlDataAdapter da7 = new SqlDataAdapter(" select Kod, Ad from CihazListesi where ID in (select CihazID from CihazAnaliz where AnalizID = '" + aID + "')", bgl.baglanti());
            da7.Fill(dt7);
            gridControl1.DataSource = dt7;
            this.gridView1.Columns[0].Width = 35;

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(" select Ad, Soyad from StokKullanici where ID in (select PersonelID from ValidasyonYetkili where AnalizID =  '" + aID + "')", bgl.baglanti());
            da1.Fill(dt1);
            gridControl3.DataSource = dt1;
        }

        int mID, bID;
        void detaybul()
        {

            SqlCommand komut21 = new SqlCommand("Select * from ValidasyonVeri where AnalizID = N'" + aID + "' and Durum = 'Aktif' or Durum = 'Ortak'", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                urun.Text = dr21["Urun"].ToString();
                date_basla.EditValue = Convert.ToDateTime(dr21["Tarih1"].ToString());
                date_bit.EditValue = Convert.ToDateTime(dr21["Tarih2"].ToString());
                birim.Text = dr21["Birim"].ToString();
                lod.Text = dr21["Lod"].ToString();
                loq.Text = dr21["Loq"].ToString();
                gerikazanim.Text = dr21["GK"].ToString();
                bel.Text = dr21["Bel"].ToString();

            }
            bgl.baglanti().Close();

            SqlCommand komut2 = new SqlCommand("Select * from  StokAnalizListesi where ID = N'" + aID + "' ", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                kod.Text = dr2["Kod"].ToString();
                ad.Text = dr2["Ad"].ToString();
                bID = Convert.ToInt32(dr2["Birim"].ToString());
                mID = Convert.ToInt32(dr2["Metot"].ToString());

                SqlCommand komut1 = new SqlCommand("Select * from  StokDKDListe where ID = N'" + mID + "' ", bgl.baglanti());
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    string kod = dr1["Kod"].ToString();
                    string ad = dr1["Ad"].ToString();
                    metot.Text = kod + " " + ad;
                }
                bgl.baglanti().Close();

                SqlCommand komut11 = new SqlCommand(" select * from StokFirmaBirim where ID = '" + bID + "' ", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    txt_birim.Text = dr11["Birim"].ToString();
                }
                bgl.baglanti().Close();

            }
            bgl.baglanti().Close();


        }
        public static string aID, skod, sad;
        private void AnalizDetay_Load(object sender, EventArgs e)
        {
            listele();
            detaybul();
            Text = skod + " - " + sad + " Analiz Detayları";

        }
    }
}