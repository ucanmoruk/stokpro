using DevExpress.XtraGrid;
using mKYS;
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

namespace mKYS.Musteri
{
    public partial class ProformaUpdate : Form
    {
        public ProformaUpdate()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public static decimal sum = 0;
        string koz;
        void goster()
        {
            txt_evrak.Text = ProformaListesi.profno.ToString();

            SqlCommand komut4 = new SqlCommand("select Firma_Adi from Firma where ID in (select Firma_ID from NKR where Evrak_No = N'" + txt_evrak.Text + "')", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                txt_firma.Text = dr4["Firma_Adi"].ToString();
            }
            bgl.baglanti().Close();

            SqlCommand komut414 = new SqlCommand("select Tur from NKR where Evrak_No = N'" + txt_evrak.Text + "' ", bgl.baglanti());
            SqlDataReader dr414 = komut414.ExecuteReader();
            while (dr414.Read())
            {
                koz = dr414["Tur"].ToString();
            }
            bgl.baglanti().Close();

            SqlCommand komut14 = new SqlCommand("select TeklifNo, ParaBirimi, KurTl, Iskonto from FaturaDetay where ProformaNo = N'" + txt_evrak.Text + "'", bgl.baglanti());
            SqlDataReader dr14 = komut14.ExecuteReader();
            while (dr14.Read())
            {
                txt_teklifno.Text = dr14["TeklifNo"].ToString();
                txt_iskonto.Text = dr14["Iskonto"].ToString();
                combo_tur.Text = dr14["ParaBirimi"].ToString();
                if (txt_teklifno.Text == "2101000")
                {
                    txt_kur.Text = "1";
                    txt_tekliftur.Text = "Manuel";
                    SqlCommand komut104 = new SqlCommand("select ISNULL(SUM(GenelFiyat),0) as 'stotal' from FaturaDetay where ProformaNo = N'" + txt_evrak.Text + "'", bgl.baglanti());
                    SqlDataReader dr104 = komut104.ExecuteReader();
                    while (dr104.Read())
                    {
                        txt_genel.Text = dr104["stotal"].ToString();
                    }
                    bgl.baglanti().Close();
                }
                else
                {
                    txt_kur.Text = dr14["KurTl"].ToString();
                    SqlCommand komut104 = new SqlCommand("select ISNULL(SUM(GenelFiyat),0) as 'stotal' from FaturaDetay where ProformaNo = N'" + txt_evrak.Text + "'", bgl.baglanti());
                    SqlDataReader dr104 = komut104.ExecuteReader();
                    while (dr104.Read())
                    {
                        txt_toplam.Text = dr104["stotal"].ToString();
                    }
                    bgl.baglanti().Close();
                    SqlCommand komut44 = new SqlCommand("select TeklifTuru from TeklifX1 where TeklifNo = N'" + txt_teklifno.Text + "'", bgl.baglanti());
                    SqlDataReader dr44 = komut44.ExecuteReader();
                    while (dr44.Read())
                    {
                        txt_tekliftur.Text = dr44["TeklifTuru"].ToString();
                    }
                    bgl.baglanti().Close();
                }
               
            }
            bgl.baglanti().Close();

            
            SqlCommand komut34 = new SqlCommand("select Firma_Adi from Firma where ID in (select FaturaFirmaID from FaturaDetay where ProformaNo = N'" + txt_evrak.Text + "')", bgl.baglanti());
            SqlDataReader dr34 = komut34.ExecuteReader();
            while (dr34.Read())
            {
                combo_firma.Text = dr34["Firma_Adi"].ToString();
            }
            bgl.baglanti().Close();
            

        }


        void listele()
        {
            if (txt_teklifno.Text == "2101000")
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select ROW_NUMBER() OVER(ORDER BY ID) as No, Aciklama as 'Açıklama', UrunGrubu as 'Ürün Grubu', Miktar, " +
                    " Birim,  ParaBirimi, BirimFiyatTl as 'Birim Fiyat', ToplamFiyat as 'Fiyat', KDV, Iskonto, GenelFiyat as 'Toplam' from FaturaDetay where ProformaNo = N'" + txt_evrak.Text + "'", bgl.baglanti());
                da.Fill(dt);
                gridControl1.DataSource = dt;
                bgl.baglanti().Close();
            }
            else
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter("select ROW_NUMBER() OVER(ORDER BY ID) as No, Aciklama as 'Açıklama', UrunGrubu as 'Ürün Grubu', Miktar, Birim, BirimFiyat, ParaBirimi, KurTl as 'Kur', " +
                    "BirimFiyatTl, ToplamFiyat as 'Total', Iskonto, GenelFiyat from FaturaDetay where ProformaNo = N'" + txt_evrak.Text + "'", bgl.baglanti());
                da.Fill(dt);
                gridControl1.DataSource = dt;
                bgl.baglanti().Close();
            }


        }

        public void Firma()
        {
            SqlCommand komut = new SqlCommand("Select Firma_Adi from Firma where Durum = 'Aktif'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                combo_firma.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        public void firmadetay()
        {
            SqlCommand komut = new SqlCommand("Select Adres, Vergi_Dairesi,Vergi_No,Mail from Firma where Firma_Adi = '" + combo_firma.Text + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txt_adres.Text = dr["Adres"].ToString();
                txt_vdaire.Text = dr["Vergi_Dairesi"].ToString();
                txt_vergino.Text = dr["Vergi_No"].ToString();
                txt_mail.Text = dr["Mail"].ToString();
            }
            bgl.baglanti().Close();
        }

        //public void Durum()
        //{
        //    //SqlCommand komut = new SqlCommand("Select Durum, Dipnot from ProformaDurum where ProformaNo = N'"+txt_evrak.Text+"'", bgl.baglanti());
        //    //SqlDataReader dr = komut.ExecuteReader();
        //    //while (dr.Read())
        //    //{
        //    //    durumo= dr[0].ToString();
        //    //}
        //    //bgl.baglanti().Close();

        //    //SqlCommand komut2 = new SqlCommand("select Ad from Kullanici where ID in (select PlasiyerID from TeklifListe where TeklifNo ='"+txt_teklifno.Text+"' and Durum = N'Aktif')", bgl.baglanti());
        //    //SqlDataReader dr2 = komut2.ExecuteReader();
        //    //while (dr2.Read())
        //    //{
        //    //    kullanici = dr2[0].ToString();
        //    //}
        //    //bgl.baglanti().Close();

        //}

        public void Dipnot()
        {
            SqlCommand komut = new SqlCommand("Select Durum, Dipnot from ProformaDurum where ID = N'" + ProformaListesi.profid + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                durumo = dr[0].ToString();
                txtnot.Text = dr[1].ToString();
            }
            bgl.baglanti().Close();

            //SqlCommand komut2 = new SqlCommand("select Ad from Kullanici where ID in (select PlasiyerID from TeklifListe where TeklifNo ='"+txt_teklifno.Text+"' and Durum = N'Aktif')", bgl.baglanti());
            //SqlDataReader dr2 = komut2.ExecuteReader();
            //while (dr2.Read())
            //{
            //    kullanici = dr2[0].ToString();
            //}
            //bgl.baglanti().Close();

        }


        public void gridduzen()
        {
            GridGroupSummaryItem item = new GridGroupSummaryItem();
            item.FieldName = "GenelFiyat";
            //  item.ShowInGroupColumnFooter = gridView1.Columns["Tutar"];
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            item.DisplayFormat = "/ Toplam = {0:c2}";
            gridView1.GroupSummary.Add(item);
        }

        public static string girisk, kullanici, kgorev, durumo;
        private void ProformaUpdate_Load(object sender, EventArgs e)
        {
            goster();
            listele();
            Firma();
            firmadetay();
            hesapla();        
            Dipnot();
           // Durum();

            gridduzen();

            //girisk = MAYS.Kullanici.ad.ToString();
            //kgorev = MAYS.Kullanici.gorev.ToString();
            KullaniciID = Convert.ToInt32(Anasayfa.kullanici);

                                   
            //if (kullanici == girisk || kgorev == "Muhasebe")
            //{
                if (txt_tekliftur.Text == "Analiz")
                {
                        if (koz == "Kozmetik")
                        {

                        }
                        else
                        {
                            gridView1.Columns["Ürün Grubu"].Group();
                            gridView1.ExpandAllGroups();
                        }
                    
                }
                else
                {

                }
                if (durumo == "Onaylandı" || durumo == "Faturalandırıldı" || durumo == "Reddedildi")
                {
                    //string newLine = Environment.NewLine;
                    //MessageBox.Show("Sonuçlanan proformaları sadece önizleme yapabilir ve faturalandırabilirsiniz." + newLine + "" + newLine + "Üzgünüm acı sözlerim için..");
                    btn_fatura.Visible = false;
                    simpleButton1.Visible = false;
                }
                else
                {

                }
            //}
            //else
            //{
            //    MessageBox.Show("Proformanın sahibi gelsin sahibi..");
            //    this.Close();
            //}


        }

        void hesapla()
        {
            //decimal sub = Convert.ToDecimal(txt_genel.Text);
            //decimal kdv = Math.Round(sub * 100 / 118,2);
            //decimal total = Math.Round(sub - kdv,2);
            //txt_kdv.Text = total.ToString();
            //txt_toplam.Text = kdv.ToString();
            if (txt_teklifno.Text == "2101000")
            {
                decimal total = Convert.ToDecimal(txt_genel.Text);
                decimal sub = Math.Round(total * 100 / 120 ,2);
                decimal kdv = Math.Round(sub * 20 / 100 , 2);
                txt_kdv.Text = kdv.ToString();
                txt_toplam.Text = sub.ToString();
            }
            else
            {
                decimal sub = Convert.ToDecimal(txt_toplam.Text);
                decimal kdv = Math.Round(sub * 20 / 100, 2);
                decimal total = Math.Round(sub + kdv, 2);
                txt_kdv.Text = kdv.ToString();
                txt_genel.Text = total.ToString();
            }


        }


        int KullaniciID;
        private void btn_fatura_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tarih = DateTime.Now;

                SqlCommand komut = new SqlCommand("update ProformaDurum set Durum=@t1, OnaylayanID = @x1, Tarih= @x2, Dipnot=@x3 where ProformaNo =@t2 and Durum = @z1;" +
                 "update Odeme set Odeme_Durumu = @t3 where Evrak_No =@t2", bgl.baglanti());
                komut.Parameters.AddWithValue("@t1", "Onaylandı");
                komut.Parameters.AddWithValue("@t2", Convert.ToInt32(txt_evrak.Text));
                komut.Parameters.AddWithValue("@t3", "Proforma Onaylandı");
                komut.Parameters.AddWithValue("@z1", "Onay Bekleniyor");
                komut.Parameters.AddWithValue("@x1", KullaniciID);
                komut.Parameters.AddWithValue("@x2", tarih);
                komut.Parameters.AddWithValue("@x3", txtnot.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Vakit ayırdığınız için teşekkür ederiz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Try again please : " + ex.Message);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tarih = DateTime.Now;

                SqlCommand komut = new SqlCommand("update ProformaDurum set Durum=@t1, OnaylayanID = @x1, Tarih= @x2  where ProformaNo =@t2 ;" +
             "update Odeme set Odeme_Durumu = @t3 where Evrak_No =@t2", bgl.baglanti());
                komut.Parameters.AddWithValue("@t1", "Reddedildi");
                komut.Parameters.AddWithValue("@t2", Convert.ToInt32(txt_evrak.Text));
                komut.Parameters.AddWithValue("@t3", "Proforma Reddedildi");
                komut.Parameters.AddWithValue("@x1", KullaniciID);
                komut.Parameters.AddWithValue("@x2", tarih);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Vakit ayırdığınız için teşekkür ederiz! Lütfen reddetme sebebinizi yetkiliye bildiriniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Try again please : " + ex.Message);
            }
        }


        public static string faturafirma, evrakno, urun, adres, vd, vn, mail, parabirimi, raporfirma, teklifno, teklifturu;

        private void combo_firma_SelectedIndexChanged(object sender, EventArgs e)
        {
            firmadetay();
        }

        public static decimal gtutar, kdv, gtoplam;
        public static decimal kurTl, iskonto;
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            yazdir();
        }

        public void yazdir()
        {
            evrakno = txt_evrak.Text;
            raporfirma = txt_firma.Text;
            faturafirma = combo_firma.Text;
            adres = txt_adres.Text;
            vd = txt_vdaire.Text;
            vn = txt_vergino.Text;
            mail = txt_mail.Text;
            iskonto = Convert.ToDecimal(txt_iskonto.Text);

            gtutar = Convert.ToDecimal(txt_toplam.Text);
            kdv = Convert.ToDecimal(txt_kdv.Text);
            gtoplam = Convert.ToDecimal(txt_genel.Text);

            teklifno = txt_teklifno.Text;
            teklifturu = txt_tekliftur.Text;
            parabirimi = combo_tur.Text;
            kurTl = Convert.ToDecimal(txt_kur.Text);

            using (Raporlar.frmPrint frm = new Raporlar.frmPrint())
            {
                if (txt_tekliftur.Text == "Paket")
                {
                    frm.ProformaYazdir();
                    frm.ShowDialog();
                }
                else if (txt_tekliftur.Text == "Manuel")
                {
                    frm.ProformaManuel();
                    frm.ShowDialog();
                }
                else
                {
                    frm.ProformaGrup();
                    frm.ShowDialog();
                }


               
            }
        }

    }
}
