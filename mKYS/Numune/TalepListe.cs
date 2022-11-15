using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Menu;
using mKYS.Musteri;
using mKYS.Numune;
using mKYS.Raporlar;

namespace mKYS
{
    public partial class TalepListe : Form
    {
        public TalepListe()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();

        private void button_getir_Click(object sender, EventArgs e)
        {
            NumuneKabul f1 = new NumuneKabul();
            f1.Show();
        }


        public void listele()
        {
            //date_baslangic.EditValue = date_basla.EditValue;
            //date_baslangic.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            //date_baslangic.Properties.Mask.EditMask = "yyyy-MM-dd";
            //date_baslangic.Properties.Mask.UseMaskAsDisplayFormat = true;

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(@"select t.ID, t.TalepNo, t.Tarih, f.Firma_Adi, r.Firma as 'Raporlama Firma', r.UreticiFirma as 'Üretici', t.Durum from Talep t 
            left join Firma f on t.FirmaKodu = f.Kod
            left join TalepRaporlama r on t.ID = r.TalepID
            order by ID desc ", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView3.Columns["ID"].Visible = false;
        }

        public void listele2()
        {
            //date_baslangic.EditValue = date_basla.EditValue;
            //date_baslangic.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            //date_baslangic.Properties.Mask.EditMask = "yyyy-MM-dd";
            //date_baslangic.Properties.Mask.UseMaskAsDisplayFormat = true;
            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter("select distinct n.Tarih, t.Termin, n.Evrak_No as 'Evrak No', n.RaporNo as 'Rapor No', f.Firma_Adi as 'Firma Adı', n.Numune_Adi as 'Numune Adı', n.Grup, n.Tur, n.Aciklama as 'Açıklama', n.Rapor_Durumu as 'Rapor Durumu',  o.Odeme_Durumu as 'Fatura Durumu' , n.ID as 'aID' " +
            //"from NKR n join Firma f on f.ID = n.Firma_ID join Odeme o on o.Evrak_No = n.Evrak_No inner join Termin t on t.RaporID = n.ID" +
            //" where n.Tarih >= N'" + date_baslangic.Text + "'  and n.Durum = 'Aktif' and not ( n.Rapor_Durumu = 'Raporlandı' and o.Odeme_Durumu = 'Ödendi') order by RaporNo desc", bgl.baglanti());

            //da.Fill(dt);
            //gridControl1.DataSource = dt;

            //gridView3.Columns["aID"].Visible = false;
        }
        public static int boold;
        public static string bid;

        void gridduzen()
        {
            this.gridView3.Columns[1].Width = 45;
            this.gridView3.Columns[2].Width = 55;
            this.gridView3.Columns[3].Width = 150;
           // this.gridView3.Columns[4].Width = 25; 
            this.gridView3.Columns[4].Width = 120; 
            this.gridView3.Columns[5].Width = 100;
          //  this.gridView3.Columns[7].Width = 50;
            this.gridView3.Columns[6].Width = 50;

        }
        private void NKR_Load(object sender, EventArgs e)
        {
            splitContainer2.Panel2Collapsed = true;
            listele();
            gridduzen();

            //date_basla.EditValue = DateTime.Now.AddDays(-30);
            //date_bit.EditValue = DateTime.Now;
            //date_basla.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            //date_basla.Properties.Mask.EditMask = "dd-MM-yyyy";
            //date_basla.Properties.Mask.UseMaskAsDisplayFormat = true;

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
                string ODurum = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Durum"]);
                if (ODurum == "Raporlandı")
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.BackColor2 = Color.LightGreen;
                    e.HighPriority = true;

                }
            }
        }

        private void gridView3_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
           
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //try
            //{
            //    DialogResult Secim = new DialogResult();

            //    Secim = MessageBox.Show("Silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            //    if (Secim == DialogResult.Yes)
            //    {
            //        // SqlCommand komutSil = new SqlCommand("delete from Firma where ID = @p1", bgl.baglanti());
            //        SqlCommand komutSil = new SqlCommand("update NKR set Durum=@a1, RaporNo=@a2 where ID = @p1", bgl.baglanti());
            //        komutSil.Parameters.AddWithValue("@p1", nkrID);
            //        komutSil.Parameters.AddWithValue("@a2", "20-000");
            //        komutSil.Parameters.AddWithValue("@a1", "Pasif");
            //        komutSil.ExecuteNonQuery();
            //        bgl.baglanti().Close();
            //        listele();
            //        MessageBox.Show("Silme işlemi gerçekleşmiştir.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Hata2 : " + ex.Message);
            //}
        }

        private void NKR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {

                listele();
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
            //splitContainer2.Panel2Collapsed = false;
            //txtAdet.Text = NKR.fadet;
            //combo_birim.Text = NKR.fbirim;
            //txt_basvuru.Text = NKR.basvuru;
            //txt_model.Text = NKR.model;
            //txt_marka.Text = NKR.marka;
            //txt_akr.Text = nakr;
            //txt_tur.Text = ntur;
            //txt_rev.Text = nrev;


            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter("select Kod, Ad, Method from StokAnalizListesi where ID in (select AnalizID from NumuneX1 where RaporID = N'" + nkrID + "')  ", bgl.baglanti());
            //da.Fill(dt);
            //gridControl2.DataSource = dt;

            //DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            //rapornos = Convert.ToInt32(dr["Rapor No"].ToString());

            //SqlCommand detay = new SqlCommand("select ProjeID from NumuneDetay where RaporID = (Select ID from NKR where RaporNo = N'" + rapornos + "')", bgl.baglanti());
            //SqlDataReader drd = detay.ExecuteReader();
            //while (drd.Read())
            //{
            //    projeid = Convert.ToInt32(drd["ProjeID"]);
            //}
            //bgl.baglanti().Close();

            //SqlCommand detayd = new SqlCommand("Select Firma_Adi from Firma where ID = N'" + projeid + "'", bgl.baglanti());
            //SqlDataReader drde = detayd.ExecuteReader();
            //while (drde.Read())
            //{
            //    txt_proje.Text = drde["Firma_Adi"].ToString();
            //}
            //bgl.baglanti().Close();


        }

        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            splitContainer2.Panel2Collapsed = true;
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
            TeklifNoSec pf = new TeklifNoSec();
            pf.Show();
        }

        private void date_bit_EditValueChanged(object sender, EventArgs e)
        {
            listele();
           
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            //gridControl1.DataSource = null;
            //gridView3.Columns.Clear();

            listele2();
            gridduzen();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {

            //gridControl1.DataSource = null;
            //gridView3.Columns.Clear();

            listele();
            gridduzen();
            
        }

        string tID;
        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {       
            // analizde 
            try
            {
                SqlCommand komut = new SqlCommand("update Talep set Durum = @r1 where ID=@r2", bgl.baglanti());
                komut.Parameters.AddWithValue("@r1", "Analiz Aşamasında");
                komut.Parameters.AddWithValue("@r2", tID);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                //   listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata 2:" + ex);
            }
     
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            // Raporlandı
            try
            {
                SqlCommand komut = new SqlCommand("update Talep set Durum = @r1 where ID=@r2", bgl.baglanti());
                komut.Parameters.AddWithValue("@r1", "Raporlandı");
                komut.Parameters.AddWithValue("@r2", tID);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                //   listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata 3:" + ex);
            }
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update NKR set Rapor_Durumu = @r1 where Evrak_No=@r2", bgl.baglanti());
                komut.Parameters.AddWithValue("@r1", "Rapor Beklemede");
                komut.Parameters.AddWithValue("@r2", evrakNo);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                //   listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata 4:" + ex);
            }
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Rapor1.raporno = raporNo;
            tReportx2.raporno = raporNo;
            // mNiS.Raporlar.RaporSonuc.raporno = raporNo;
            using (frmPrint frm = new frmPrint())
            {
                frm.Rapor();
                frm.ShowDialog();
            }


        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //açıklama
            Numune.Aciklama.RaporNo = raporNo;
            Numune.Aciklama.RevNo = revno;
            Numune.Aciklama a = new Numune.Aciklama();
            a.ShowDialog();
        }



        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //mNiS.Raporlar.Rapor1.raporno = raporNo;
            //mNiS.Raporlar.Rapor2Exp.raporno = raporNo;
            //mNiS.Raporlar.RaporSonuc.raporno = raporNo;
            //using (mNiS.Raporlar.frmPrint frm = new mNiS.Raporlar.frmPrint())
            //{
            //    frm.RaporAzo();
            //    frm.ShowDialog();
            //}
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Numune.NumuneDurum.gelis = raporNo;
            Numune.NumuneDurum nd = new Numune.NumuneDurum();
            nd.Show();
        }

        private void txt_arama_TextChanged(object sender, EventArgs e)
        {
            //arama

            //date_baslangic.EditValue = date_basla.EditValue;
            //date_baslangic.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            //date_baslangic.Properties.Mask.EditMask = "yyyy-MM-dd";
            //date_baslangic.Properties.Mask.UseMaskAsDisplayFormat = true;

            DataTable dt = new DataTable();

            //SqlDataAdapter da = new SqlDataAdapter(@"select distinct n.Tarih, t.Termin, n.Evrak_No as 'Evrak No', n.RaporNo as 'Rapor No', 
            //f.Firma_Adi as 'Firma Adı', n.Numune_Adi as 'Numune Adı', n.Grup, 
            //n.Aciklama as 'Açıklama', n.Rapor_Durumu as 'Rapor Durumu',  o.Odeme_Durumu as 'Fatura Durumu', n.ID as 'aID' from NKR n 
            //join Firma f on f.ID = n.Firma_ID join Odeme o on o.Evrak_No = n.Evrak_No inner join Termin t on t.RaporID = n.ID 
            //where n.Tarih >= N'" + date_baslangic.Text + "' and n.Durum = 'Aktif' and(n.RaporNo like '%"+txt_arama.Text+ "%' or f.Firma_Adi like  '%" + txt_arama.Text + "%'or n.Numune_Adi like  '%" + txt_arama.Text + "%'or n.Aciklama like  '%" + txt_arama.Text + "%') order by n.RaporNo desc ", bgl.baglanti());
            //da.Fill(dt);
            //if (dt == null)
            //{

            //}
            //else
            //{
            //    gridControl1.DataSource = dt;
            //}

            //gridView3.Columns["aID"].Visible = false;

        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //mKYS.Raporlar.Kozmetik.RaporKozmetik.raporID = aID;
            //mKYS.Raporlar.Kozmetik.RaporKozmetik2.raporID = aID;
            //using (Raporlar.frmPrint frm = new Raporlar.frmPrint())
            //{
            //    frm.KozmetikRapor();
            //    frm.ShowDialog();
            //}
        }

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
            
            if (e.Column.FieldName == "TalepNo" || e.Column.FieldName == "Tarih" || e.Column.FieldName == "Durum" || e.Column.FieldName == "Rapor Durumu"  || e.Column.FieldName == "Evrak No" || e.Column.FieldName =="Tarih" )
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
                tID = dr["ID"].ToString();
                //    evrakNo = dr["Evrak No"].ToString();
                //    raporNo = dr["Rapor No"].ToString(); 
                // //   revizyonNo = dr["Revizyon"].ToString(); 
                //    raporDurumu = dr["Rapor Durumu"].ToString();
                //    faturaDurumu = dr["Fatura Durumu"].ToString();
                //    ftarih = dr["Tarih"].ToString();
                //    ffirma = dr["Firma Adı"].ToString();
                //    fnumune = dr["Numune Adı"].ToString();
                //        aID = Convert.ToInt32(dr["aID"].ToString());
                ////     ftur = dr["Tür"].ToString();
                //fgrup = dr["Grup"].ToString();
                //    //    fanaliz = dr["Analiz"].ToString();
                //    faciklama = dr["Açıklama"].ToString();
                ////    akreditasyon = dr["Akreditasyon"].ToString();

                //    SqlCommand komut2 = new SqlCommand("Select ID, Revno from NKR where RaporNo = N'" + raporNo + "'", bgl.baglanti());
                //    SqlDataReader dr2 = komut2.ExecuteReader();
                //    while (dr2.Read())
                //    {
                //        nkrID = Convert.ToInt32(dr2["ID"]);
                //        revno = Convert.ToInt32(dr2["Revno"]);
                //        label1.Text = Convert.ToString(nkrID);

                //    }
                //    bgl.baglanti().Close();

                //    SqlCommand komut3 = new SqlCommand("Select Adres from Firma where Firma_Adi = N'" + ffirma + "'", bgl.baglanti());
                //    SqlDataReader dr3 = komut3.ExecuteReader();
                //    while (dr3.Read())
                //    {
                //        adres = dr3["Adres"].ToString();
                //    }
                //    bgl.baglanti().Close();


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
            NumuneGuncelle2.nID = aID;
            NumuneGuncelle2 f3 = new NumuneGuncelle2();
            f3.Show();
        }

        public string yenirDurumu = "Raporlandı";

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (raporDurumu == NumuneKabul.rDurumu)
            {
                SqlCommand komut = new SqlCommand("update NKR set Rapor_Durumu = @r1 where Evrak_No=@r2", bgl.baglanti());
                komut.Parameters.AddWithValue("@r1", yenirDurumu);
                komut.Parameters.AddWithValue("@r2", evrakNo);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
             //   listele();

            }
            else
            {
                SqlCommand komut2 = new SqlCommand("update NKR set Rapor_Durumu = @r1 where Evrak_No=@r2", bgl.baglanti());
                komut2.Parameters.AddWithValue("@r1", NumuneKabul.rDurumu);
                komut2.Parameters.AddWithValue("@r2", evrakNo);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
             //   listele();
            }






        }
    }
}
