using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using mKYS.Musteri;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace mKYS
{
    public partial class MusteriTakip : Form
    {
        sqlbaglanti bgl = new sqlbaglanti();

        public MusteriTakip()
        {
            InitializeComponent();
        }
        
        private void button_getir_Click(object sender, EventArgs e)
        {
            NumuneKabul f1 = new NumuneKabul();
            f1.Show();
        }

        public void listele()
        {
            date_baslangic.EditValue = date_basla.EditValue;
            date_baslangic.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            date_baslangic.Properties.Mask.EditMask = "yyyy-MM-dd";
            date_baslangic.Properties.Mask.UseMaskAsDisplayFormat = true;

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(@"select distinct n.Tarih, n.Servis, t.Termin, n.Evrak_No as 'Evrak No', n.RaporNo as 'Rapor No', 
            f.Firma_Adi as 'Firma Adı', n.Numune_Adi as 'Numune Adı', n.Grup, n.Tur,
             n.Aciklama as 'Açıklama', n.Rapor_Durumu as 'Rapor Durumu', o.Odeme_Durumu as 'Fatura Durumu', f.Odeme, f.Vade, 
			 k.Ad+ ' ' + k.Soyad as 'Plasiyer', n.ID as 'aID' from NKR n 
            join Firma f on f.ID = n.Firma_ID join Odeme o on o.Evrak_No = n.Evrak_No left join Termin t on t.RaporID = n.ID left join StokKullanici k on
			f.PlasiyerID = k.ID
            where n.Tarih >= N'" + date_baslangic.Text + "' and n.Durum = 'Aktif' order by n.ID desc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView3.Columns["aID"].Visible = false;
        }

        public void listele2()
        {
            date_baslangic.EditValue = date_basla.EditValue;
            date_baslangic.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            date_baslangic.Properties.Mask.EditMask = "yyyy-MM-dd";
            date_baslangic.Properties.Mask.UseMaskAsDisplayFormat = true;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select distinct n.Tarih, n.Servis, t.Termin, n.Evrak_No as 'Evrak No', n.RaporNo as 'Rapor No', 
            f.Firma_Adi as 'Firma Adı', n.Numune_Adi as 'Numune Adı', n.Grup, n.Tur,
             n.Aciklama as 'Açıklama', n.Rapor_Durumu as 'Rapor Durumu', o.Odeme_Durumu as 'Fatura Durumu', f.Odeme, f.Vade, 
			 k.Ad+ ' ' + k.Soyad as 'Plasiyer', n.ID as 'aID' from NKR n 
            join Firma f on f.ID = n.Firma_ID join Odeme o on o.Evrak_No = n.Evrak_No left join Termin t on t.RaporID = n.ID left join StokKullanici k on
			f.PlasiyerID = k.ID where n.Tarih >= N'" + date_baslangic.Text + "'  and n.Durum = 'Aktif' and not ( n.Rapor_Durumu = 'Gönderildi' and o.Odeme_Durumu = 'Ödendi') order by RaporNo desc", bgl.baglanti());

            da.Fill(dt);
            gridControl1.DataSource = dt;

            gridView3.Columns["aID"].Visible = false;
            
        }
        public static int boold;
        public static string bid;

        private void gridduzen()
        {
            this.gridView3.Columns[0].Width = 90;
            this.gridView3.Columns[1].Width = 70;
            this.gridView3.Columns[2].Width = 60;
            this.gridView3.Columns[3].Width = 60;
            this.gridView3.Columns[4].Width = 75; 
            this.gridView3.Columns[5].Width = 150;
            this.gridView3.Columns[6].Width = 100;
            this.gridView3.Columns[7].Width = 60;
            this.gridView3.Columns[8].Width = 75;
            this.gridView3.Columns[9].Width = 75;
            this.gridView3.Columns[10].Width = 75;
            this.gridView3.Columns[11].Width = 75;
            this.gridView3.Columns[12].Width = 55;
            this.gridView3.Columns[13].Width = 40;
            this.gridView3.Columns[14].Width = 60;
        }
        
        private void NKR_Load(object sender, EventArgs e)
        {
            splitContainer2.Panel2Collapsed = true;
            listele();
            gridduzen();

            date_basla.EditValue = DateTime.Now.AddDays(-30);
            date_bit.EditValue = DateTime.Now;
            date_basla.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            date_basla.Properties.Mask.EditMask = "dd-MM-yyyy";
            date_basla.Properties.Mask.UseMaskAsDisplayFormat = true;

            gridView3.Columns["Tarih"].DisplayFormat.FormatType = FormatType.DateTime;
            gridView3.Columns["Tarih"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm ";
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (faturaDurumu == "Fatura Kesilmedi")
            {
                FaturaKaydet fo = new FaturaKaydet();
                fo.Show();
            }
            else if (faturaDurumu == "Proforma Oluşturuldu")
            {
                MessageBox.Show("Lütfen proformanın onaylanması için plasiyer ile irtibata geçin", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (faturaDurumu == "Proforma Onaylandı")
            {
                ProformatoFatura to = new ProformatoFatura();
                to.Show();
            }
            else if (faturaDurumu == "Proforma Reddedildi")
            {
                FaturaKaydet fo = new FaturaKaydet();
                fo.Show();
            }
            else
            {
                MessageBox.Show("Fatura kesilmiş zaten.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void gridView3_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }
        }

        private void gridView3_RowStyle(object sender, RowStyleEventArgs e)
        {
         //  Tüm satırı renklendirmek istediğin zaman kullan
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string Kategori = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Rapor Durumu"]);
                string ODurum = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Fatura Durumu"]);
                if (Kategori == "Gönderildi" && ODurum == "Ödendi")
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.BackColor2 = Color.LightGreen;
                    e.HighPriority = true;
                }
            }
        }

        private void gridView3_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            string hadi = gridView3.GetRowCellValue(e.RowHandle, "Rapor Durumu").ToString();
            string adam = gridView3.GetRowCellValue(e.RowHandle, "Fatura Durumu").ToString();
            if (e.RowHandle > -1 && e.Column.FieldName == "Rapor Durumu" && hadi == "İmza Bekliyor")
                e.Appearance.BackColor = Color.LightGreen;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Rapor Durumu" && hadi == "Gönderildi")
                e.Appearance.BackColor = Color.Green;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Fatura Durumu" && adam == "Ödendi")
                e.Appearance.BackColor = Color.Green;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Fatura Durumu" && adam == "Ödeme Bekliyor")
                e.Appearance.BackColor = Color.DarkOrange;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Fatura Durumu" && adam == "Fatura Kesilmedi")
                e.Appearance.BackColor = Color.IndianRed;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Fatura Durumu" && adam == "Proforma Reddedildi")
                e.Appearance.BackColor = Color.OrangeRed;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Fatura Durumu" && adam == "Proforma Oluşturuldu")
                e.Appearance.BackColor = Color.Azure;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Fatura Durumu" && adam == "Proforma Onaylandı")
                e.Appearance.BackColor = Color.LightGreen;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Rapor Durumu" && hadi == "Rapor Hazırlanıyor")
                e.Appearance.BackColor = Color.LightPink;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Rapor Durumu" && hadi == "Gönderim Bekliyor")
                e.Appearance.BackColor = Color.Goldenrod;
        }

        private void NKR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                listele();
            }
            if (e.Control == true && e.KeyCode == Keys.D)
            {
                NumuneGuncelle f3 = new NumuneGuncelle();
                f3.Show();
            }

            if (e.Control == true && e.KeyCode == Keys.F)
            {
                if (faturaDurumu == "Fatura Kesilmedi")
                {
                    //FaturaKaydet fo = new FaturaKaydet();
                    //fo.Show();
                }
                else
                {
                    MessageBox.Show("Fatura kesilmiş zaten.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        public static string raporNo, revizyonNo, akreditasyon ;

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listele();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        public static int nkrID, turID;
        public static string evrakNo, raporDurumu, faturaDurumu, ftarih, ffirma, fnumune, fadet, ftur, fgrup, fanaliz, faciklama, fbirim;

        int projeid, rapornos;
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            rapornos = Convert.ToInt32(dr["Rapor No"].ToString());       
        }

        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
           
        }

        private void btn_analizekle_Click(object sender, EventArgs e)
        {
            NumuneGuncelle f3 = new NumuneGuncelle();
            f3.Show();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ProformatoFatura nw = new ProformatoFatura();
            nw.Show();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TeklifNoSec.evrakno = evrakNo;
            TeklifNoSec.firma = ffirma;
            TeklifNoSec pf = new TeklifNoSec();
            pf.Show();
        }

        private void date_bit_EditValueChanged(object sender, EventArgs e)
        {
            listele();         
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            listele2();
            gridduzen();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            listele();
            gridduzen();        
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Numune.NumuneDurum.gelis = raporNo;
            //Numune.NumuneDurum nd = new Numune.NumuneDurum();
            //nd.Show();

            //denetim

            Numune.NumDurum.raporno = raporNo;
            Numune.NumDurum nd = new Numune.NumDurum();
            nd.Show();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string path = "numunelistesi.xlsx";
            gridControl1.ExportToXlsx(path);
            Process.Start(path);
        }

        string id, nkrno, nkrid;

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //manuel proforma
            Musteri.ManuelProforma.evrakno = evrakNo;
            Musteri.ManuelProforma mf = new Musteri.ManuelProforma();
            mf.Show();
        }

        private void date_filtre_EditValueChanged(object sender, EventArgs e)
        {
            listele();
        }

        //PrintDialog prd = new PrintDialog();

        private void buton_kargola_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //mNiS.KargoAdres ka = new mNiS.KargoAdres();
            //ka.Show();
        }

        public static decimal kesilen, kalan;
        public static string firmaad;
        private void gridView3_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {         
            if (e.Column.FieldName == "Rapor No" || e.Column.FieldName == "Termin" || e.Column.FieldName == "Vade" || e.Column.FieldName == "Servis" ||  e.Column.FieldName == "Fatura Durumu" || e.Column.FieldName == "Rapor Durumu"  || e.Column.FieldName == "Evrak No" || e.Column.FieldName =="Tarih" )
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;        
        }

        public static string alicifirma, termin, lot, skt, üt, basvuru, model, marka, adres, ntur, nakr, nrev;
        
        private void  termint()
        {
            SqlCommand detay2 = new SqlCommand("Select Termin from Termin where RaporID = N'" + label1.Text + "'", bgl.baglanti());
            SqlDataReader dre = detay2.ExecuteReader();
            while (dre.Read())
            {
                termin = dre["Termin"].ToString();
            }
        }

        private void Numunedet()
        {
            SqlCommand detay = new SqlCommand("Select * from NumuneDetay where RaporID = N'" + label1.Text + "'", bgl.baglanti());
            SqlDataReader drd = detay.ExecuteReader();
            while (drd.Read())
            {
                alicifirma = drd["AliciFirma"].ToString();
                lot = drd["SeriNo"].ToString();
                skt = drd["SKT"].ToString();
                üt = drd["UretimTarihi"].ToString();
                basvuru = drd["BasvuruNo"].ToString();
                model = drd["Model"].ToString();
                marka = drd["Marka"].ToString();
                fadet = drd["Miktar"].ToString();
                fbirim = drd["Birim"].ToString();
            }
            bgl.baglanti().Close();

            SqlCommand detay2 = new SqlCommand("select Tur, Akreditasyon, Revno from NKR where ID = N'" + label1.Text + "'", bgl.baglanti());
            SqlDataReader drd2 = detay2.ExecuteReader();
            while (drd2.Read())
            {
                ntur = drd2["Tur"].ToString();
                nakr = drd2["Akreditasyon"].ToString();
                nrev = drd2["Revno"].ToString();
            }
            bgl.baglanti().Close();
        }
        public static int firmaid, revno, aID;
       
        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
                evrakNo = dr["Evrak No"].ToString();
                raporNo = dr["Rapor No"].ToString(); 
                //   revizyonNo = dr["Revizyon"].ToString(); 
                raporDurumu = dr["Rapor Durumu"].ToString();
                faturaDurumu = dr["Fatura Durumu"].ToString();
                ftarih = dr["Tarih"].ToString();
                ffirma = dr["Firma Adı"].ToString();
                fnumune = dr["Numune Adı"].ToString();
                    aID = Convert.ToInt32(dr["aID"].ToString());
            //     ftur = dr["Tür"].ToString();
                fgrup = dr["Grup"].ToString();
                //    fanaliz = dr["Analiz"].ToString();
                faciklama = dr["Açıklama"].ToString();
            //    akreditasyon = dr["Akreditasyon"].ToString();

                SqlCommand komut2 = new SqlCommand("Select ID, Revno from NKR where RaporNo = N'" + raporNo + "'", bgl.baglanti());
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    nkrID = Convert.ToInt32(dr2["ID"]);
                    revno = Convert.ToInt32(dr2["Revno"]);
                    label1.Text = Convert.ToString(nkrID);
                }
                bgl.baglanti().Close();

                SqlCommand komut3 = new SqlCommand("Select Adres from Firma where Firma_Adi = N'" + ffirma + "'", bgl.baglanti());
                SqlDataReader dr3 = komut3.ExecuteReader();
                while (dr3.Read())
                {
                    adres = dr3["Adres"].ToString();
                }
                bgl.baglanti().Close();

                //termint();
                //Numunedet();
                //  MessageBox.Show(nkrID + model);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata1 : " + ex.Message);
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Numunedet();
            termint();
            //NumuneGuncelle2.nID = aID;
            //NumuneGuncelle2 f3 = new NumuneGuncelle2();
            //f3.Show();

            NumKabv2 numKabv2 = new NumKabv2();
            NumKabv2.nID = aID;
            numKabv2.isUpdated = true;
            numKabv2.ShowDialog();
        }

    }
}
