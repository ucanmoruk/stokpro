using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
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
    public partial class TeklifF : Form
    {
        public TeklifF()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();
        NKR n = (NKR)Application.OpenForms["NKR"];

        void listele()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(@"select ROW_NUMBER() OVER(ORDER BY RaporID) as No, n.Numune_Adi + ' - '+ISNULL(d.Model,'') + ' Test Bedeli' as [Açıklama],
            n.Tur as [Ürün Grubu], d.Miktar, d.Birim, t.BirimFiyat as [Teklif Birim Fiyat], t.FiyatBirim as 'Para Birimi', 
            CAST(t.BirimFiyat*@a1 as decimal(18, 2)) as 'Birim Fiyat Tl', CAST(t.BirimFiyat*@a1*d.Miktar as decimal(18, 2)) as 'Total' , 
            Iskonto=@a2 , CAST(ISNULL(((t.BirimFiyat*@a1*d.Miktar)-(t.BirimFiyat*@a1*d.Miktar*@a2/100)),0) as decimal(18, 2)) as 'Genel Toplam' 
            from NKR n inner join NumuneDetay d on n.ID= d.RaporID inner join Numune_Grup g on g.Tur = n.Tur 
            inner join TeklifX2 t on g.ID = t.PaketID where n.Evrak_No = @w1 and t.TeklifNo = @w2", bgl.baglanti());
            da.SelectCommand.Parameters.AddWithValue("@a1", Convert.ToDecimal(txt_kur.Text));
            da.SelectCommand.Parameters.AddWithValue("@w1", txt_evrak.Text);
            da.SelectCommand.Parameters.AddWithValue("@w2", txt_teklifno.Text);
            da.SelectCommand.Parameters.AddWithValue("@a2", indirim);
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();
        }

        void kozmetiklistele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select ROW_NUMBER() OVER(ORDER BY a.ID) as 'No', a.Ad as 'Test Adı', n.Tur +' - Ürün Test Bedeli' as 'Açıklama' ,  
            Count(d.Miktar) as 'Miktar' , Birim='Adet', ISNULL(t.BirimFiyat,0) as 'Teklif Birim Fiyat', 
            t.FiyatBirim as 'Para Birimi', 
            CAST(t.BirimFiyat*@a1 as decimal(18, 2)) as 'Birim Fiyat Tl', CAST(t.BirimFiyat*@a1*Count(d.Miktar) as decimal(18, 2)) as 'Total', 
            Iskonto=@a2 , CAST(ISNULL(((t.BirimFiyat*@a1*Count(d.Miktar))-(t.BirimFiyat*@a1*Count(d.Miktar)*@a2/100)),0) as decimal(18, 2)) as 'Genel Toplam' 
            from NumuneX1 m 
            inner join NKR n on m.RaporID = n.ID
            inner join StokAnalizListesi a on m.AnalizID = a.ID
            inner join NumuneDetay d on d.RaporID = n.ID 
            inner join TeklifX2 t on t.AnalizID = a.ID 
            where n.Evrak_No = @w1  and t.TeklifNo = @w2 
            group by a.ID, a.Ad , n.Tur +' - Ürün Test Bedeli' , d.Miktar, t.BirimFiyat, t.FiyatBirim 
            order by 'No' asc", bgl.baglanti());
            da.SelectCommand.Parameters.AddWithValue("@a1", Convert.ToDecimal(txt_kur.Text));
            da.SelectCommand.Parameters.AddWithValue("@w1", txt_evrak.Text);
            da.SelectCommand.Parameters.AddWithValue("@w2", txt_teklifno.Text);
            da.SelectCommand.Parameters.AddWithValue("@a2", indirim);
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();
        }

        void mixlistele()
        {
            DataTable dt = new DataTable();

            //SqlDataAdapter da = new SqlDataAdapter(@"select ROW_NUMBER() OVER(ORDER BY a.Analiz_Adi) as 'No', n.Tur+' - '+Model+' - Test Bedeli' as 'Numune Adı' ,  
            //a.Ad as 'Açıklama', Count(m.Kod)as 'Miktar' , Birim='Adet', ISNULL(t.BirimFiyat,0) as 'Teklif Birim Fiyat', 
            //t.FiyatBirim as 'Para Birimi', 
            //CAST(t.BirimFiyat*@a1 as decimal(18, 2)) as 'Birim Fiyat Tl', CAST(t.BirimFiyat*@a1*Count(m.Kod) as decimal(18, 2)) as 'Total', 
            //Iskonto=@a2 , CAST(ISNULL(((t.BirimFiyat*@a1*Count(m.Kod))-(t.BirimFiyat*@a1*Count(m.Kod)*@a2/100)),0) as decimal(18, 2)) as 'Genel Toplam' 
            //from NumuneX2 m 
            //inner join NKR n on m.RaporID = n.ID
            //inner join StokAnalizListesi a on m.AnalizID = a.ID
            //inner join NumuneDetay d on d.RaporID = n.ID 
            //inner join TeklifX2 t on t.AnalizID = a.ID 
            //where n.Evrak_No = @w1  and t.TeklifNo = @w2 group by n.Tur+' - '+Model+' - Test Bedeli', a.Ad,  t.BirimFiyat, t.FiyatBirim order by 'No' asc", bgl.baglanti());
            //da.SelectCommand.Parameters.AddWithValue("@a1", Convert.ToDecimal(txt_kur.Text));
            //da.SelectCommand.Parameters.AddWithValue("@w1", txt_evrak.Text);
            //da.SelectCommand.Parameters.AddWithValue("@w2", txt_teklifno.Text);
            //da.SelectCommand.Parameters.AddWithValue("@a2", indirim);
            //da.Fill(dt);
            //gridControl1.DataSource = dt;
            //bgl.baglanti().Close();

            SqlDataAdapter da = new SqlDataAdapter(@"select ROW_NUMBER() OVER(ORDER BY a.ID) as 'No', n.Tur+' - '+Model+' - Test Bedeli' as 'Numune Adı' ,  
            a.Ad as 'Açıklama', Count(m.Kod)as 'Miktar' , Birim='Adet', ISNULL(t.BirimFiyat,0) as 'Teklif Birim Fiyat', 
            t.FiyatBirim as 'Para Birimi', 
            CAST(t.BirimFiyat*@a1 as decimal(18, 2)) as 'Birim Fiyat Tl', CAST(t.BirimFiyat*@a1*Count(m.Kod) as decimal(18, 2)) as 'Total', 
            Iskonto=@a2 , CAST(ISNULL(((t.BirimFiyat*@a1*Count(m.Kod))-(t.BirimFiyat*@a1*Count(m.Kod)*@a2/100)),0) as decimal(18, 2)) as 'Genel Toplam' 
            from NumuneX2 m 
            inner join NKR n on m.RaporID = n.ID
            inner join StokAnalizListesi a on m.AnalizID = a.ID
            inner join NumuneDetay d on d.RaporID = n.ID 
            inner join TeklifX2 t on t.AnalizID = a.ID 
            where n.Evrak_No = @w1  and t.TeklifNo = @w2 
            group by a.ID, n.Tur+' - '+Model+' - Test Bedeli', a.Ad,  t.BirimFiyat, t.FiyatBirim 
            order by 'No' asc", bgl.baglanti());
            da.SelectCommand.Parameters.AddWithValue("@a1", Convert.ToDecimal(txt_kur.Text));
            da.SelectCommand.Parameters.AddWithValue("@w1", txt_evrak.Text);
            da.SelectCommand.Parameters.AddWithValue("@w2", txt_teklifno.Text);
            da.SelectCommand.Parameters.AddWithValue("@a2", indirim);
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();
        }

        void bakanliklistele()
        {
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(@"select ROW_NUMBER() OVER(ORDER BY a.Ad) as 'No', d.BasvuruNo+' - '+n.Tur+' - '+d.Model+' - Test Bedeli' as 'Numune Adı' ,  
            a.Ad as 'Açıklama', Count(m.Kod)as 'Miktar' , Birim='Adet', ISNULL(t.BirimFiyat,0) as 'Teklif Birim Fiyat', t.FiyatBirim, 
            CAST(t.BirimFiyat*@a1 as decimal(18, 2)) as 'Birim Fiyat Tl', CAST(t.BirimFiyat*@a1*Count(m.Kod) as decimal(18, 2)) as 'Total', 
            Iskonto=@a2 , CAST(ISNULL(((t.BirimFiyat*@a1*Count(m.Kod))-(t.BirimFiyat*@a1*Count(m.Kod)*@a2/100)),0) as decimal(18, 2)) as 'Genel Toplam' 
            from NumuneX2 m 
            inner join NKR n on n.ID = m.RaporID
            inner join StokAnalizListesi a on m.AnalizID = a.ID
            inner join NumuneDetay d on d.RaporID = n.ID 
            inner join TeklifX2 t on t.AnalizID = a.ID 
            where n.Evrak_No = @w1  and t.TeklifNo = @w2 
            group by d.BasvuruNo+' - '+n.Tur+' - '+d.Model+' - Test Bedeli', a.Ad,  t.BirimFiyat, t.FiyatBirim order by 'No' asc", bgl.baglanti());
            da.SelectCommand.Parameters.AddWithValue("@a1", Convert.ToDecimal(txt_kur.Text));
            da.SelectCommand.Parameters.AddWithValue("@w1", txt_evrak.Text);
            da.SelectCommand.Parameters.AddWithValue("@w2", txt_teklifno.Text);
            da.SelectCommand.Parameters.AddWithValue("@a2", indirim);
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();
        }


        int urunsayi;
        void urunsay()
        {

            if (txt_tekliftur.Text == "Paket")
            {
                SqlCommand komut = new SqlCommand("Select COUNT(ID) from NKR where Evrak_No = '" + txt_evrak.Text + "'", bgl.baglanti());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    urunsayi = Convert.ToInt32(dr[0].ToString());
                }
                bgl.baglanti().Close();
            }
            else
            {
                SqlCommand komut = new SqlCommand("select COUNT(Kod) from NumuneX2 where RaporID in (select ID from NKR where Evrak_No = '" + txt_evrak.Text + "')", bgl.baglanti());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    urunsayi = Convert.ToInt32(dr[0].ToString());
                }
                bgl.baglanti().Close();
            }
            
        }
        void kontrol()
        {
            urunsay();
            for (int i = 0; i < gridView1.RowCount; ++i)
            {
                gridtoplam += Convert.ToInt32(gridView1.GetRowCellValue(i, "Miktar").ToString());
            }
            if (urunsayi == gridtoplam)
            {
                kontrolet = "Ok";
            }
            else
            {
                kontrolet = "bok";
            }
        }

        string kontrolet;
        private void TeklifF_Load(object sender, EventArgs e)
        {


            try
            {
                kontrolet = "Ok";
                indirim = 0;
                sum = 0;
                evrakno();
                combo_firma.Text = txt_firma.Text;
                firmadetay();
                Firma();

                DovizKur();

                txt_teklifno.Text = TeklifNoSec.teklifno.ToString();
                teklifdetay();

                if (txt_tekliftur.Text == "Paket")
                {
                    listele();
                    topla();
                   
                }
                else
                {
                    if (gurup == "Bakanlık")
                    {
                        bakanliklistele();
                    }
                    else if (turko == "Kozmetik")
                    {
                        kozmetiklistele();
                    }
                    else
                    {
                        mixlistele();
                    }                    
                    topla();
                    kontrol();

                    GridGroupSummaryItem item = new GridGroupSummaryItem();
                    item.FieldName = "Genel Toplam";
                    //  item.ShowInGroupColumnFooter = gridView1.Columns["Tutar"];
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    item.DisplayFormat = "/ Toplam = {0:c2}";
                    gridView1.GroupSummary.Add(item);

                }


                this.gridView1.Columns[0].Width = 20;
                // this.gridView1.Columns[1].Width = 20;
                // this.gridView1.Columns[2].Width = 70;
                this.gridView1.Columns[3].Width = 35;
                this.gridView1.Columns[4].Width = 35;
                this.gridView1.Columns[5].Width = 35;
                this.gridView1.Columns[6].Width = 35;
                this.gridView1.Columns[7].Width = 35;
                this.gridView1.Columns[8].Width = 35;
                this.gridView1.Columns[9].Width = 35;
                this.gridView1.Columns[10].Width = 35;

             }
            catch (Exception ex)
            {
                MessageBox.Show("Sanırım teklifi bir kontrol etmelisin! Hata Kodu 23 : " + ex.Message);
            }
}

        public static string proje, urun, gurup, nkrevrak, nkrfirma, turko;
        public static int rapor, projeID, urunID;
        public void evrakno()
        {
            txt_evrak.Text = nkrevrak;
            txt_firma.Text = nkrfirma;
            SqlCommand komut = new SqlCommand("select Grup, Tur from NKR where Evrak_No = '" + txt_evrak.Text + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                gurup = dr[0].ToString();
                turko = dr[1].ToString();
            }
            bgl.baglanti().Close();

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


        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "No" || e.Column.FieldName == "Para Birimi" || e.Column.FieldName == "Genel Fiyat" || e.Column.FieldName == "Teklif Birim Fiyat" || e.Column.FieldName == "Iskonto" || e.Column.FieldName == "Miktar" || e.Column.FieldName == "Birim" || e.Column.FieldName == "Birim Fiyat ₺" || e.Column.FieldName == "Toplam Fiyat")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        string paketfiyat;

        private void combo_firma_SelectedIndexChanged(object sender, EventArgs e)
        {
            firmadetay();
        }

        private void combo_tur_SelectedIndexChanged(object sender, EventArgs e)
        {
            DovizKur();
        }

        public double tfiyat = 0;
        public static decimal sum;
        private decimal KDV = 0, SToplam = 0, iskonto = 0;
        int toplam;
        private void topla()
        {

            for (int i = 0; i < gridView1.RowCount; ++i)
            {
                sum += Convert.ToDecimal(gridView1.GetRowCellValue(i, "Genel Toplam").ToString());
            }
            indirim = 0;
            txt_toplam.Text = sum.ToString();
            KDV = Math.Round(sum * 20 / 100, 2);
            txt_kdv.Text = Convert.ToString(KDV);
            SToplam = Math.Round(sum + KDV, 2);
            txt_genel.Text = Convert.ToString(SToplam);

        }

        private void txt_iskonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44)
            // text'e sadece sayıların girmesi,geri silme tuşu(ascii kodu:08),virgül(ascii kodu:44) karakterinin girilmesini sağlar.
            //del tuşununda aktif olmasını isterseniz del ascıı kodu:127
            //
            {
                e.Handled = true;
            }

        }

        private void txt_iskonto_TextChanged(object sender, EventArgs e)
        {

            try
            {
                
             //   gridView1.Columns["Numune Adı"].UnGroup();
             //   simpleButton1.Text = "Gruplandır";

                if (txt_iskonto.Text == "")
                {
                    indirim = 0;
                }
                else
                {
                    // iskonto = Convert.ToDecimal(txt_iskonto.Text);
                    //  decimal isk = Math.Round(SToplam - (SToplam * iskonto / 100), 2);
                    //txt_genel.Text = Convert.ToString(isk);
                    indirim = Convert.ToInt32(txt_iskonto.Text);
                    //txt_toplam.Text = "";
                    //topla();
                    if (txt_tekliftur.Text == "Paket")
                    {
                        listele();
                    }
                    else
                    {
                        if (gurup == "Bakanlık")
                        {
                            bakanliklistele();
                        }
                        else
                        {
                            mixlistele();
                        }
                    }

                    sum = 0;
                    for (int i = 0; i < gridView1.RowCount; ++i)
                    {
                        sum += Convert.ToDecimal(gridView1.GetRowCellValue(i, "Genel Toplam").ToString());
                    }
                    txt_toplam.Text = sum.ToString();
                    KDV = Math.Round(sum * 20 / 100, 2);
                    txt_kdv.Text = Convert.ToString(KDV);
                    SToplam = Math.Round(sum + KDV, 2);
                    txt_genel.Text = Convert.ToString(SToplam);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata 1: " + ex);
            }


        }

        public static double bfiyat = 0.0;
        private double indirim = 0.0;
        private double Euro = 0.0;
        private double Dolar = 0.0;
        private DataSet dsDovizKur;
        private void DovizKur()
        {
            dsDovizKur = new DataSet();
            dsDovizKur.ReadXml(@"https://www.tcmb.gov.tr/kurlar/today.xml");
            DataRow dr = dsDovizKur.Tables[1].Rows[0];
            Dolar = Convert.ToDouble(dr[6].ToString().Replace('.', ','));
            dr = dsDovizKur.Tables[1].Rows[3];
            Euro = Convert.ToDouble(dr[6].ToString().Replace('.', ','));

            //Dolar = 8.08;
            //Euro = 9.68;

            if (combo_tur.Text == "$")
            {
                txt_kur.Text = Dolar.ToString();
                // bfiyat = Math.Round(Convert.ToDouble(paketfiyat) * Dolar, 2);
            }
            else if (combo_tur.Text == "€")
            {
                txt_kur.Text = Euro.ToString();
                //    bfiyat = Math.Round(Convert.ToDouble(paketfiyat) * Euro, 2);
            }
            else
            {
                txt_kur.Text = "1";
                //  bfiyat = Math.Round(Convert.ToDouble(paketfiyat) * 1, 2);
            }

        }

        public static int profnok;
        private void profkontrol()
        {
            SqlCommand komut2 = new SqlCommand("select COUNT(ProformaNo) from FaturaDetay where ProformaNo = '" + txt_evrak.Text + "'", bgl.baglanti());
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                profnok = Convert.ToInt32(dr[0].ToString());
            }
            bgl.baglanti().Close();
        }

        private void kayit()
        {
            if (txt_tekliftur.Text == "Paket")
            {
                DateTime tarih = DateTime.Now;

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    SqlCommand komut = new SqlCommand("insert into FaturaDetay " +
                        "(ProformaNo,FaturaFirmaID,Aciklama,UrunGrubu, Miktar, Birim, BirimFiyat, ParaBirimi, KurTl, BirimFiyatTl, ToplamFiyat, Iskonto, GenelFiyat, TeklifNo, Tarih) values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9,@a10,@a11,@a12,@a13,@a14,@a15)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@a1", txt_evrak.Text);
                    komut.Parameters.AddWithValue("@a2", faturafirmaID);
                    komut.Parameters.AddWithValue("@a3", gridView1.GetRowCellValue(i, "Açıklama").ToString());
                    komut.Parameters.AddWithValue("@a4", gridView1.GetRowCellValue(i, "Ürün Grubu").ToString());
                    komut.Parameters.AddWithValue("@a5", Convert.ToInt32(gridView1.GetRowCellValue(i, "Miktar").ToString()));
                    komut.Parameters.AddWithValue("@a6", gridView1.GetRowCellValue(i, "Birim").ToString());
                    komut.Parameters.AddWithValue("@a7", Convert.ToDecimal(gridView1.GetRowCellValue(i, "Teklif Birim Fiyat").ToString()));
                    komut.Parameters.AddWithValue("@a8", kurturu);
                    komut.Parameters.AddWithValue("@a9", kurTl);
                    komut.Parameters.AddWithValue("@a10", Convert.ToDecimal(gridView1.GetRowCellValue(i, "Birim Fiyat Tl").ToString()));
                    komut.Parameters.AddWithValue("@a11", Convert.ToDecimal(gridView1.GetRowCellValue(i, "Total").ToString()));
                    komut.Parameters.AddWithValue("@a12", fkiskonto);
                    komut.Parameters.AddWithValue("@a13", Convert.ToDecimal(gridView1.GetRowCellValue(i, "Genel Toplam").ToString()));
                    komut.Parameters.AddWithValue("@a14", fteklifno);
                    komut.Parameters.AddWithValue("@a15", tarih);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }

                SqlCommand komut2 = new SqlCommand("insert into ProformaDurum (ProformaNo, Durum, Total, TeklifNo,FirmaID, OlusturanID, OlusturmaTarih, Dipnot) values (@z1,@z2,@z3,@z4,@z5,@z6,@z7,@z8);" +
                    " update Odeme set Odeme_Durumu = @o1 where Evrak_No = @o2 ", bgl.baglanti());
                komut2.Parameters.AddWithValue("@z1", Convert.ToInt32(txt_evrak.Text));
                komut2.Parameters.AddWithValue("@z2", "Onay Bekleniyor");
                komut2.Parameters.AddWithValue("@z3", Convert.ToDecimal(txt_genel.Text));
                komut2.Parameters.AddWithValue("@z4", Convert.ToInt32(txt_teklifno.Text));
                komut2.Parameters.AddWithValue("@z5", faturafirmaID);
                komut2.Parameters.AddWithValue("@z6", Anasayfa.kullanici);
                komut2.Parameters.AddWithValue("@z7", tarih);
                komut2.Parameters.AddWithValue("@z8", txt_not.Text);
                komut2.Parameters.AddWithValue("@o1", "Proforma Oluşturuldu");
                komut2.Parameters.AddWithValue("@o2", Convert.ToInt32(txt_evrak.Text));
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Proforma başarı ile oluşturuldu.");
                this.Close();
            }
            else
            {
                if (turko == "Kozmetik")
                {
                    kozmetikkayit();
                }
                else
                {
                    mixkayit();
                }
              
            }
  
        }
        private void mixkayit()
        {
            DateTime tarih = DateTime.Now;

            gridView1.ClearGrouping();

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                SqlCommand komut = new SqlCommand("insert into FaturaDetay " +
                    "(ProformaNo,FaturaFirmaID,Aciklama,UrunGrubu, Miktar, Birim, BirimFiyat, ParaBirimi, KurTl, BirimFiyatTl, ToplamFiyat, Iskonto, GenelFiyat, TeklifNo, Tarih) values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9,@a10,@a11,@a12,@a13,@a14,@a15)", bgl.baglanti());
                komut.Parameters.AddWithValue("@a1", txt_evrak.Text);
                komut.Parameters.AddWithValue("@a2", faturafirmaID);
                komut.Parameters.AddWithValue("@a3", gridView1.GetRowCellValue(i, "Açıklama").ToString());
                komut.Parameters.AddWithValue("@a4", gridView1.GetRowCellValue(i, "Numune Adı").ToString());
                komut.Parameters.AddWithValue("@a5", Convert.ToInt32(gridView1.GetRowCellValue(i, "Miktar").ToString()));
                komut.Parameters.AddWithValue("@a6", "Adet");
                komut.Parameters.AddWithValue("@a7", Convert.ToDecimal(gridView1.GetRowCellValue(i, "Teklif Birim Fiyat").ToString()));
                komut.Parameters.AddWithValue("@a8", kurturu);
                komut.Parameters.AddWithValue("@a9", kurTl);
                komut.Parameters.AddWithValue("@a10", Convert.ToDecimal(gridView1.GetRowCellValue(i, "Birim Fiyat Tl").ToString()));
                komut.Parameters.AddWithValue("@a11", Convert.ToDecimal(gridView1.GetRowCellValue(i, "Total").ToString()));
                komut.Parameters.AddWithValue("@a12", fkiskonto);
                komut.Parameters.AddWithValue("@a13", Convert.ToDecimal(gridView1.GetRowCellValue(i, "Genel Toplam").ToString()));
                komut.Parameters.AddWithValue("@a14", fteklifno);
                komut.Parameters.AddWithValue("@a15", tarih);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
            }

            SqlCommand komut2 = new SqlCommand("insert into ProformaDurum (ProformaNo, Durum, Total, TeklifNo,FirmaID, OlusturanID, OlusturmaTarih, Dipnot) values (@z1,@z2,@z3,@z4,@z5, @z6, @z7,@z8);" +
                " update Odeme set Odeme_Durumu = @o1 where Evrak_No = @o2 ", bgl.baglanti());
            komut2.Parameters.AddWithValue("@z1", Convert.ToInt32(txt_evrak.Text));
            komut2.Parameters.AddWithValue("@z2", "Onay Bekleniyor");
            komut2.Parameters.AddWithValue("@z3", Convert.ToDecimal(txt_genel.Text));
            komut2.Parameters.AddWithValue("@z4", Convert.ToInt32(txt_teklifno.Text));
            komut2.Parameters.AddWithValue("@z5", faturafirmaID);
            komut2.Parameters.AddWithValue("@z6", Anasayfa.kullanici);
            komut2.Parameters.AddWithValue("@z7", tarih);
            komut2.Parameters.AddWithValue("@z8", txt_not.Text);
            komut2.Parameters.AddWithValue("@o1", "Proforma Oluşturuldu");
            komut2.Parameters.AddWithValue("@o2", Convert.ToInt32(txt_evrak.Text));
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Proforma başarı ile oluşturuldu.");
            this.Close();
        }
        private void kozmetikkayit()
        {
            DateTime tarih = DateTime.Now;

            gridView1.ClearGrouping();

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                SqlCommand komut = new SqlCommand("insert into FaturaDetay " +
                    "(ProformaNo,FaturaFirmaID,Aciklama,UrunGrubu, Miktar, Birim, BirimFiyat, ParaBirimi, KurTl, BirimFiyatTl, ToplamFiyat, Iskonto, GenelFiyat, TeklifNo, Tarih) values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9,@a10,@a11,@a12,@a13,@a14,@a15)", bgl.baglanti());
                komut.Parameters.AddWithValue("@a1", txt_evrak.Text);
                komut.Parameters.AddWithValue("@a2", faturafirmaID);
                komut.Parameters.AddWithValue("@a3", gridView1.GetRowCellValue(i, "Açıklama").ToString());
                komut.Parameters.AddWithValue("@a4", gridView1.GetRowCellValue(i, "Test Adı").ToString());
                komut.Parameters.AddWithValue("@a5", Convert.ToInt32(gridView1.GetRowCellValue(i, "Miktar").ToString()));
                komut.Parameters.AddWithValue("@a6", "Adet");
                komut.Parameters.AddWithValue("@a7", Convert.ToDecimal(gridView1.GetRowCellValue(i, "Teklif Birim Fiyat").ToString()));
                komut.Parameters.AddWithValue("@a8", kurturu);
                komut.Parameters.AddWithValue("@a9", kurTl);
                komut.Parameters.AddWithValue("@a10", Convert.ToDecimal(gridView1.GetRowCellValue(i, "Birim Fiyat Tl").ToString()));
                komut.Parameters.AddWithValue("@a11", Convert.ToDecimal(gridView1.GetRowCellValue(i, "Total").ToString()));
                komut.Parameters.AddWithValue("@a12", fkiskonto);
                komut.Parameters.AddWithValue("@a13", Convert.ToDecimal(gridView1.GetRowCellValue(i, "Genel Toplam").ToString()));
                komut.Parameters.AddWithValue("@a14", fteklifno);
                komut.Parameters.AddWithValue("@a15", tarih);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
            }

            SqlCommand komut2 = new SqlCommand("insert into ProformaDurum (ProformaNo, Durum, Total, TeklifNo,FirmaID, OlusturanID, OlusturmaTarih, Dipnot) values (@z1,@z2,@z3,@z4,@z5, @z6, @z7,@z8);" +
                " update Odeme set Odeme_Durumu = @o1 where Evrak_No = @o2 ", bgl.baglanti());
            komut2.Parameters.AddWithValue("@z1", Convert.ToInt32(txt_evrak.Text));
            komut2.Parameters.AddWithValue("@z2", "Onay Bekleniyor");
            komut2.Parameters.AddWithValue("@z3", Convert.ToDecimal(txt_genel.Text));
            komut2.Parameters.AddWithValue("@z4", Convert.ToInt32(txt_teklifno.Text));
            komut2.Parameters.AddWithValue("@z5", faturafirmaID);
            komut2.Parameters.AddWithValue("@z6", Anasayfa.kullanici);
            komut2.Parameters.AddWithValue("@z7", tarih);
            komut2.Parameters.AddWithValue("@z8", txt_not.Text);
            komut2.Parameters.AddWithValue("@o1", "Proforma Oluşturuldu");
            komut2.Parameters.AddWithValue("@o2", Convert.ToInt32(txt_evrak.Text));
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Proforma başarı ile oluşturuldu.");
            this.Close();
        }
        int gridtoplam;

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txt_tekliftur.Text == "Analiz")
            {
                if (simpleButton1.Text == "Gruplandır")
                {
                    gridView1.Columns["Numune Adı"].Group();
                    gridView1.ExpandAllGroups();
                    simpleButton1.Text = "Grubu Dağıt";
                }
                else
                {
                    gridView1.Columns["Numune Adı"].UnGroup();
                    simpleButton1.Text = "Gruplandır";
                }

            }
            else
            {
               
            }


        }

        private void btn_yeni_Click(object sender, EventArgs e)
        {
            //gridView1.AddNewRow();
            //gridView1.SetRowCellValue(GridControl.NewItemRowHandle, gridView1.Columns["Birim"], "Adet");
            //gridView1.SetRowCellValue(GridControl.NewItemRowHandle, gridView1.Columns["Para Birimi"], combo_tur.Text);
            //gridView1.SetRowCellValue(GridControl.NewItemRowHandle, gridView1.Columns["Iskonto"], 0);
        }

        private void btn_fatura_Click(object sender, EventArgs e)
        {
            if (txt_tekliftur.Text == "Paket")
            {
                
            }
            else
            {
                if (turko == "Kozmetik")
                {
                    gridView1.Columns["Test Adı"].UnGroup();
                }
                else
                {
                    gridView1.Columns["Numune Adı"].UnGroup();
                }
              
            }


            try
            {
                gtutar = Convert.ToDecimal(txt_toplam.Text);
                kdv = Convert.ToDecimal(txt_kdv.Text); ;
                gtoplam = Convert.ToDecimal(txt_genel.Text);
                faturafirma = combo_firma.Text.ToString();

                //        birimfiyat = Convert.ToDecimal(txt_paketfiyat.Text);
                kurTl = Convert.ToDecimal(txt_kur.Text);
                kurturu = combo_tur.Text.ToString();
                fkiskonto = Convert.ToInt32(txt_iskonto.Text);
                fteklifno = Convert.ToInt32(txt_teklifno.Text);

                if (kontrolet == "Ok")
                {
                    SqlCommand komut4 = new SqlCommand("Select ID from Firma where Firma_Adi = N'" + faturafirma + "' and Durum = N'Aktif'", bgl.baglanti());
                    SqlDataReader dr4 = komut4.ExecuteReader();
                    while (dr4.Read())
                    {
                        faturafirmaID = Convert.ToInt32(dr4["ID"].ToString());
                    }
                    bgl.baglanti().Close();


                    DialogResult cikis = new DialogResult();
                    cikis = MessageBox.Show("Bu işin geri dönüşü yok. Emin misin ?", "Uyarı", MessageBoxButtons.YesNo);
                    if (cikis == DialogResult.Yes)
                    {
                        profkontrol();
                        if (profnok == 0)
                        {
                            kayit();
                        }
                        else
                        {
                            SqlCommand komut12 = new SqlCommand("delete from FaturaDetay where ProformaNo = @z1 ", bgl.baglanti());
                            komut12.Parameters.AddWithValue("@z1", Convert.ToInt32(txt_evrak.Text));
                            komut12.ExecuteNonQuery();
                            bgl.baglanti().Close();

                            kayit();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Bende öyle düşünmüştüm.");
                    }
                }
                else
                {
                    DialogResult cikis = new DialogResult();
                    cikis = MessageBox.Show("Analizi yapılan ama teklifte fiyatı olmayan bazı şeyler var! Bir kontrol etmek ister misin ?", "Uyarı", MessageBoxButtons.YesNo);
                    if (cikis == DialogResult.Yes)
                    {
                        MessageBox.Show("Bende öyle düşünmüştüm.");
                    }
                    else
                    {
                        SqlCommand komut4 = new SqlCommand("Select ID from Firma where Firma_Adi = N'" + faturafirma + "' and Durum = N'Aktif'", bgl.baglanti());
                        SqlDataReader dr4 = komut4.ExecuteReader();
                        while (dr4.Read())
                        {
                            faturafirmaID = Convert.ToInt32(dr4["ID"].ToString());
                        }
                        bgl.baglanti().Close();

                        profkontrol();
                        if (profnok == 0)
                        {
                            kayit();
                        }
                        else
                        {
                            SqlCommand komut12 = new SqlCommand("delete from FaturaDetay where ProformaNo = @z1 ", bgl.baglanti());
                            komut12.Parameters.AddWithValue("@z1", Convert.ToInt32(txt_evrak.Text));
                            komut12.ExecuteNonQuery();
                            bgl.baglanti().Close();

                            kayit();

                        }


                    }

                    
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hoydaa! İşte bunlar hep sıkıntı. Neyse ki yazılımcı tanıdık.. " + ex.Message);
            }
            //using (MAYS.Raporlar.frmPrint frm = new MAYS.Raporlar.frmPrint())
            //{
            //    frm.PrintInvoice();
            //    frm.ShowDialog();
            //}
        }


        public static decimal gtutar, kdv, gtoplam;
        public static string faturafirma, kurturu;
        public static decimal birimfiyat, kurTl, BirimFiyatTl;
        public static int fkiskonto, faturafirmaID, fteklifno;

        public void teklifdetay()
        {
            SqlCommand komutp = new SqlCommand("select TeklifTuru from TeklifX1 where TeklifNo = '"+txt_teklifno.Text+"'", bgl.baglanti());
            SqlDataReader drp = komutp.ExecuteReader();
            while (drp.Read())
            {
                txt_tekliftur.Text = drp["TeklifTuru"].ToString();
            }
            bgl.baglanti().Close();

            SqlCommand komutp2 = new SqlCommand("select FiyatBirim from TeklifX2 where TeklifNo = '" + txt_teklifno.Text + "'", bgl.baglanti());
            SqlDataReader drp2 = komutp2.ExecuteReader();
            while (drp2.Read())
            {
                combo_tur.Text = drp2["FiyatBirim"].ToString();
            }
            bgl.baglanti().Close();
        }


    }
}
