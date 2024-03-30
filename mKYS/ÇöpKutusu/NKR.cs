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
using System.Diagnostics;
using DevExpress.Utils;

namespace mKYS
{
    public partial class NKR : Form
    {
        sqlbaglanti bgl = new sqlbaglanti();
        public static int boold;
        public static string bid;

        public NKR()
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
             n.Aciklama as 'Açıklama' , n.ID as 'aID' from NKR n 
            join Firma f on f.ID = n.Firma_ID inner join Termin t on t.RaporID = n.ID 
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
            SqlDataAdapter da = new SqlDataAdapter("select distinct n.Tarih, n.Servis, t.Termin, n.Evrak_No as 'Evrak No', n.RaporNo as 'Rapor No', f.Firma_Adi as 'Firma Adı', n.Numune_Adi as 'Numune Adı', n.Grup, n.Tur, n.Aciklama as 'Açıklama', n.Rapor_Durumu as 'Rapor Durumu',  o.Odeme_Durumu as 'Fatura Durumu' , n.ID as 'aID' " +
            "from NKR n join Firma f on f.ID = n.Firma_ID inner join Termin t on t.RaporID = n.ID" +
            " where n.Tarih >= N'" + date_baslangic.Text + "'  and n.Durum = 'Aktif'  order by n.ID desc", bgl.baglanti());

            da.Fill(dt);
            gridControl1.DataSource = dt;

            gridView3.Columns["aID"].Visible = false;

        }       

        private void gridduzen()
        {
            this.gridView3.Columns[0].Width = 90;
            this.gridView3.Columns[1].Width = 70;
            this.gridView3.Columns[2].Width = 60;
            this.gridView3.Columns[3].Width = 50; 
            this.gridView3.Columns[4].Width = 50; 
            this.gridView3.Columns[5].Width = 150;
            this.gridView3.Columns[6].Width = 100;
            this.gridView3.Columns[7].Width = 50;
            this.gridView3.Columns[8].Width = 75;
            this.gridView3.Columns[9].Width = 90;
            //this.gridView3.Columns[10].Width = 75;
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
            //GridView View = sender as GridView;
            //if (e.RowHandle >= 0)
            //{

            //    string Kategori = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Rapor Durumu"]);
            //    string ODurum = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Fatura Durumu"]);
            //    if (Kategori == "Raporlandı" && ODurum == "Ödendi")
            //    {
            //        e.Appearance.BackColor = Color.Green;
            //        e.Appearance.BackColor2 = Color.LightGreen;
            //        e.HighPriority = true;

            //    }
            //}
        }

        private void gridView3_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //string hadi = gridView3.GetRowCellValue(e.RowHandle, "Rapor Durumu").ToString();
            //string adam = gridView3.GetRowCellValue(e.RowHandle, "Fatura Durumu").ToString();
            //if (e.RowHandle > -1 && e.Column.FieldName == "Rapor Durumu" && hadi == "Rapor Hazır")
            //    e.Appearance.BackColor = Color.LightGreen;
            //else if (e.RowHandle > -1 && e.Column.FieldName == "Rapor Durumu" && hadi == "Raporlandı")
            //    e.Appearance.BackColor = Color.Green;
            //else if (e.RowHandle > -1 && e.Column.FieldName == "Fatura Durumu" && adam == "Ödendi")
            //    e.Appearance.BackColor = Color.Green;
            //else if (e.RowHandle > -1 && e.Column.FieldName == "Fatura Durumu" && adam == "Ödeme Bekliyor")
            //    e.Appearance.BackColor = Color.DarkOrange;
            //else if (e.RowHandle > -1 && e.Column.FieldName == "Fatura Durumu" && adam == "Fatura Kesilmedi")
            //    e.Appearance.BackColor = Color.IndianRed;
            //else if (e.RowHandle > -1 && e.Column.FieldName == "Fatura Durumu" && adam == "Proforma Reddedildi")
            //    e.Appearance.BackColor = Color.OrangeRed;
            //else if (e.RowHandle > -1 && e.Column.FieldName == "Fatura Durumu" && adam == "Proforma Oluşturuldu")
            //    e.Appearance.BackColor = Color.Azure;
            //else if (e.RowHandle > -1 && e.Column.FieldName == "Fatura Durumu" && adam == "Proforma Onaylandı")
            //    e.Appearance.BackColor = Color.LightGreen;
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                nkrno = gridView3.GetRowCellValue(y, "aID").ToString();

                try
                {
                    DialogResult Secim = new DialogResult();

                    Secim = MessageBox.Show("Silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (Secim == DialogResult.Yes)
                    {
                        // SqlCommand komutSil = new SqlCommand("delete from Firma where ID = @p1", bgl.baglanti());
                        SqlCommand komutSil = new SqlCommand("update NKR set Durum=@a1, RaporNo=@a2 where ID = @p1", bgl.baglanti());
                        komutSil.Parameters.AddWithValue("@p1", nkrno);
                        komutSil.Parameters.AddWithValue("@a2", "20-000");
                        komutSil.Parameters.AddWithValue("@a1", "Pasif");
                        komutSil.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        listele();
                        MessageBox.Show("Silme işlemi gerçekleşmiştir.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata2 : " + ex.Message);
                }
            }
           
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
            splitContainer2.Panel2Collapsed = false;
            txtAdet.Text = NKR.fadet;
            combo_birim.Text = NKR.fbirim;
            txt_basvuru.Text = NKR.basvuru;
            txt_model.Text = NKR.model;
            txt_marka.Text = NKR.marka;
            txt_akr.Text = nakr;
            txt_tur.Text = ntur;
            txt_rev.Text = nrev;


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select Kod, Ad, Method from StokAnalizListesi where ID in (select AnalizID from NumuneX1 where RaporID = N'" + nkrID + "')  ", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;

            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            rapornos = Convert.ToInt32(dr["Rapor No"].ToString());

            SqlCommand detay = new SqlCommand("select ProjeID from NumuneDetay where RaporID = (Select ID from NKR where RaporNo = N'" + rapornos + "')", bgl.baglanti());
            SqlDataReader drd = detay.ExecuteReader();
            while (drd.Read())
            {
                projeid = Convert.ToInt32(drd["ProjeID"]);
            }
            bgl.baglanti().Close();

            SqlCommand detayd = new SqlCommand("Select Firma_Adi from Firma where ID = N'" + projeid + "'", bgl.baglanti());
            SqlDataReader drde = detayd.ExecuteReader();
            while (drde.Read())
            {
                txt_proje.Text = drde["Firma_Adi"].ToString();
            }
            bgl.baglanti().Close();


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

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Numunedet();
            termint();
            NumuneGuncelle2.nID = aID;
            NumuneGuncelle2 f3 = new NumuneGuncelle2();
            f3.Show();
        }

        string miktar;

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }   

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //imha
            DateTime bugun = DateTime.Now;
            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                nkrno = gridView3.GetRowCellValue(y, "Rapor No").ToString();

                SqlCommand add2 = new SqlCommand("insert into NumuneImha (RaporNo, Tarih, pID) values (@o1,@o2,@o3) ", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", nkrno);
                add2.Parameters.AddWithValue("@o2", bugun);
                add2.Parameters.AddWithValue("@o3", Anasayfa.kullanici);
                add2.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();

            }

            MessageBox.Show("Başarılı!");

            gridView3.ClearSelection();

        }

        private void barButtonItem14_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Barkod

            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                nkrno = gridView3.GetRowCellValue(y, "aID").ToString();

                Raporlar.NKREtiket.nID = nkrno.ToString();
                using (Raporlar.frmPrint frm = new Raporlar.frmPrint())
                {
                    frm.NKREtiket();
                    frm.ShowDialog();
                }

            }

      
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
            
            if (e.Column.FieldName == "Rapor No" || e.Column.FieldName == "Termin" || e.Column.FieldName == "Evrak No" || e.Column.FieldName =="Tarih" || e.Column.FieldName == "Servis")
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
            //Numunedet();
            //termint();
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
