using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using mKYS.Raporlar;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace mKYS
{
    public partial class RaporTermin : Form
    {
        sqlbaglanti bgl = new sqlbaglanti();

        public RaporTermin()
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
            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(@"select distinct n.Tarih, n.Servis, t.Termin, n.Evrak_No as 'Evrak No', n.RaporNo as 'Rapor No', 
            f.Firma_Adi as 'Firma Adı', n.Numune_Adi as 'Numune Adı', n.Grup, n.Tur,
             n.Aciklama as 'Açıklama', n.Rapor_Durumu as 'Rapor Durumu', n.ID as 'aID' from NKR n 
            join Firma f on f.ID = n.Firma_ID join Odeme o on o.Evrak_No = n.Evrak_No inner join Termin t on t.RaporID = n.ID 
            where n.Durum = 'Aktif' order by n.ID desc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView3.Columns["aID"].Visible = false;

            //özel3

            //SqlDataAdapter da = new SqlDataAdapter(@"select distinct n.Tarih, n.Servis, n.Evrak_No as 'Evrak No', n.RaporNo as 'Rapor No', 
            //f.Firma_Adi as 'Firma Adı', n.Numune_Adi as 'Numune Adı', n.Grup, n.Tur,
            // n.Aciklama as 'Açıklama', n.Rapor_Durumu as 'Rapor Durumu', n.ID as 'aID' from NKR n 
            //join Firma f on f.ID = n.Firma_ID 
            //where n.Grup='Özel3' order by n.ID desc", bgl.baglanti());
            //da.Fill(dt);
            //gridControl1.DataSource = dt;
            //gridView3.Columns["aID"].Visible = false;
        }

        public static int boold;
        public static string bid;

        private void gridduzen()
        {
            this.gridView3.Columns[0].Width = 90;
            this.gridView3.Columns[1].Width = 70;
            this.gridView3.Columns[2].Width = 65;
            this.gridView3.Columns[3].Width = 65;
           // this.gridView3.Columns[4].Width = 25; 
            this.gridView3.Columns[4].Width = 70; 
            this.gridView3.Columns[5].Width = 150;
          //  this.gridView3.Columns[7].Width = 50;
            this.gridView3.Columns[6].Width = 100;
          //  this.gridView3.Columns[9].Width = 50;
            this.gridView3.Columns[7].Width = 60;
            this.gridView3.Columns[8].Width = 65;
            this.gridView3.Columns[9].Width = 75;
            this.gridView3.Columns[10].Width = 75;
        }

        private void NKR_Load(object sender, EventArgs e)
        {
            listele();
            gridduzen();

            gridView3.Columns["Tarih"].DisplayFormat.FormatType = FormatType.DateTime;
            gridView3.Columns["Tarih"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm ";
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
                if (Kategori == "Gönderildi")
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
            if (e.RowHandle > -1 && e.Column.FieldName == "Rapor Durumu" && hadi == "Rapor Hazırlanıyor")
                e.Appearance.BackColor = Color.LightSteelBlue;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Rapor Durumu" && hadi == "İmza Bekliyor")
                e.Appearance.BackColor = Color.Goldenrod;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Rapor Durumu" && hadi == "Gönderim Bekliyor")
                e.Appearance.BackColor = Color.LightGreen;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Rapor Durumu" && hadi == "Sonuçlar Hazır")
                e.Appearance.BackColor = Color.OrangeRed;
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

            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            rapornos = Convert.ToInt32(dr["Rapor No"].ToString());
        }

        private void btn_analizekle_Click(object sender, EventArgs e)
        {
            NumuneGuncelle f3 = new NumuneGuncelle();
            f3.Show();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                nkrno = gridView3.GetRowCellValue(y, "Rapor No").ToString();

                try
                {
                    SqlCommand komut = new SqlCommand("update NKR set Rapor_Durumu = @r1 where RaporNo=@r2", bgl.baglanti());
                    komut.Parameters.AddWithValue("@r1", "Rapor Hazırlanıyor");
                    komut.Parameters.AddWithValue("@r2", nkrno);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    //   listele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata 2:" + ex);
                }
            }     
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                nkrno = gridView3.GetRowCellValue(y, "Rapor No").ToString();

                try
                {
                    SqlCommand komut = new SqlCommand("update NKR set Rapor_Durumu = @r1 where RaporNo=@r2", bgl.baglanti());
                    komut.Parameters.AddWithValue("@r1", "İmza Bekliyor");
                    komut.Parameters.AddWithValue("@r2", nkrno);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    //   listele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata 2:" + ex);
                }
            }
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                nkrno = gridView3.GetRowCellValue(y, "Rapor No").ToString();

                try
                {
                    SqlCommand komut = new SqlCommand("update NKR set Rapor_Durumu = @r1 where RaporNo=@r2", bgl.baglanti());
                    komut.Parameters.AddWithValue("@r1", "Gönderim Bekliyor");
                    komut.Parameters.AddWithValue("@r2", nkrno);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    //   listele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata 2:" + ex);
                }
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

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {         
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

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                nkrno = gridView3.GetRowCellValue(y, "Rapor No").ToString();
                Rapor1.raporno = nkrno;
                tReportx2.raporno = nkrno;
                Rapor3.raporno = nkrno;

                Rapor1 report1 = new Rapor1();
                report1.bilgi();
                report1.CreateDocument();
                tReportx2 report2 = new tReportx2();
                report2.bilgi();
                report2.CreateDocument();
                Rapor3 report3 = new Rapor3();
                report3.bilgi();
                report3.CreateDocument();
                report1.Pages.AddRange(report2.Pages);
                report1.Pages.AddRange(report3.Pages);
                report1.PrintingSystem.ContinuousPageNumbering = true;
                report1.ShowPreviewDialog();
            }
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //mkys rapor
            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                nkrno = gridView3.GetRowCellValue(y, "Rapor No").ToString();
                Raporlar.Yeni.entReport.raporno = nkrno;
                Raporlar.Yeni.entReport2.raporno = nkrno;
                Raporlar.Yeni.entReport3.raporno = nkrno;

                name = gridView3.GetRowCellValue(y, "Numune Adı").ToString();
                frmPrint.name = nkrno + " - " + name;

                Raporlar.Yeni.entReport report1 = new Raporlar.Yeni.entReport();
                report1.bilgi();
                report1.Name = nkrno + " - " + name;
                report1.CreateDocument();
                Raporlar.Yeni.entReport2 report2 = new Raporlar.Yeni.entReport2();
                report2.bilgi();
                report2.CreateDocument();
                Raporlar.Yeni.entReport3 report3 = new Raporlar.Yeni.entReport3();
                report3.bilgi();
                report3.CreateDocument();
                report1.Pages.AddRange(report2.Pages);
                report1.Pages.AddRange(report3.Pages);
                report1.PrintingSystem.ContinuousPageNumbering = true;
                report1.ShowPreviewDialog();

                //Raporlar.Yeni.tReport.raporno = nkrno;
                ////Raporlar.Yeni.YeniRapor2.raporno = raporNo;
                ////Raporlar.Yeni.YeniRapor3.raporno = raporNo;
                //using (frmPrint frm = new frmPrint())
                //{
                //    frm.RaporYeni();
                //    frm.ShowDialog();
                //}
            }
        }

        string name;
        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //challenge
            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                nkrno = gridView3.GetRowCellValue(y, "Rapor No").ToString();
                name = gridView3.GetRowCellValue(y, "Numune Adı").ToString();
                frmPrint.name = nkrno +" - "+name;
                mKYS.Raporlar.Kozmetik.RaporKozmetik.raporID = nkrno;
                mKYS.Raporlar.Kozmetik.RaporKozmetik.tNu = "-1";
                mKYS.Raporlar.Kozmetik.RaporKozmetik3.raporID = nkrno;
                using (Raporlar.frmPrint frm = new Raporlar.frmPrint())
                {
                    frm.ChallengeRapor();
                    frm.ShowDialog();
                }
                //mKYS.Raporlar.Denetim.Koz1.raporID = nkrno;
                //mKYS.Raporlar.Denetim.Koz3.raporID = nkrno;
                //using (Raporlar.frmPrint frm = new Raporlar.frmPrint())
                //{
                //    frm.DChallengeRapor();
                //    frm.ShowDialog();
                //}
            }
        }

        string miktar;
        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                nkrno = gridView3.GetRowCellValue(y, "Rapor No").ToString();
                name = gridView3.GetRowCellValue(y, "Numune Adı").ToString();
                frmPrint.name = nkrno + " - " + name;
                Raporlar.English.Cosmetic.ReportCosmetic.raporID = nkrno;
                Raporlar.English.Cosmetic.ReportCosmetic2.raporID = nkrno;
                using (Raporlar.frmPrint frm = new Raporlar.frmPrint())
                {
                    frm.EKozmetikRapor();
                    frm.ShowDialog();
                }

                //English.name = nkrno + " - " + name;
                //English.numune = fnumune;
                //English.raporNo = nkrno;
                //English.tur = "1";
                //English en = new English();
                //en.Show();
            }
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                nkrno = gridView3.GetRowCellValue(y, "Rapor No").ToString();
                name = gridView3.GetRowCellValue(y, "Numune Adı").ToString();
                frmPrint.name = nkrno + " - " + name;
                Raporlar.English.Cosmetic.ReportCosmetic.raporID = nkrno;
                Raporlar.English.Cosmetic.ReportCosmetic3.raporID = nkrno;
                using (Raporlar.frmPrint frm = new Raporlar.frmPrint())
                {
                    frm.EChallengeRapor();
                    frm.ShowDialog();
                }

                //English.name = nkrno + " - " + name;
                //English.numune = fnumune;
                //English.raporNo = nkrno;
                //English.tur = "2";
                //English en = new English();
                //en.Show();
            }      
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ingilizce tekstil

            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                nkrno = gridView3.GetRowCellValue(y, "Rapor No").ToString();
                Raporlar.English.Textile.entReport.raporno = nkrno;
                Raporlar.English.Textile.entReport2.raporno = nkrno;
                Raporlar.English.Textile.entReport3.raporno = nkrno;

                name = gridView3.GetRowCellValue(y, "Numune Adı").ToString();
                frmPrint.name = nkrno + " - " + name;

                Raporlar.English.Textile.entReport report1 = new Raporlar.English.Textile.entReport();
                report1.bilgi();
                report1.Name = nkrno + " - " + name;
                report1.CreateDocument();
                Raporlar.English.Textile.entReport2 report2 = new Raporlar.English.Textile.entReport2();
                report2.bilgi();
                report2.CreateDocument();
                Raporlar.English.Textile.entReport3 report3 = new Raporlar.English.Textile.entReport3();
                report3.bilgi();
                report3.CreateDocument();
                report1.Pages.AddRange(report2.Pages);
                report1.Pages.AddRange(report3.Pages);
                report1.PrintingSystem.ContinuousPageNumbering = true;
                report1.ShowPreviewDialog();

                //Raporlar.Yeni.tReport.raporno = nkrno;
                ////Raporlar.Yeni.YeniRapor2.raporno = raporNo;
                ////Raporlar.Yeni.YeniRapor3.raporno = raporNo;
                //using (frmPrint frm = new frmPrint())
                //{
                //    frm.RaporYeni();
                //    frm.ShowDialog();
                //}
            }
        }

        private void barButtonItem5_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //stabilite rapor ingilizce
            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                nkrno = gridView3.GetRowCellValue(y, "Rapor No").ToString();
                name = gridView3.GetRowCellValue(y, "Numune Adı").ToString();
                frmPrint.name = nkrno + " - " + name;
                mKYS.Raporlar.English.Cosmetic.ReportCosmetic.raporID = nkrno;
            //    mKYS.Raporlar.English.Cosmetic.ReportCosmetic.tNu = "-2";
                mKYS.Raporlar.English.Cosmetic.Stability.raporID = nkrno;
                using (Raporlar.frmPrint frm = new Raporlar.frmPrint())
                {
                    frm.Stability();
                    frm.ShowDialog();
                }

                //mKYS.Raporlar.Denetim.Koz1.raporID = nkrno;
                //mKYS.Raporlar.Denetim.Koz2.raporID = nkrno;
                //using (Raporlar.frmPrint frm = new Raporlar.frmPrint())
                //{
                //    frm.DKozmetikRapor();
                //    frm.ShowDialog();
                //}
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //gönderildi
            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                nkrno = gridView3.GetRowCellValue(y, "Rapor No").ToString();

                try
                {
                    SqlCommand komut = new SqlCommand("update NKR set Rapor_Durumu = @r1 where RaporNo=@r2", bgl.baglanti());
                    komut.Parameters.AddWithValue("@r1", "Gönderildi");
                    komut.Parameters.AddWithValue("@r2", nkrno);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    //   listele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata 2:" + ex);
                }
            }
        }

        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //stabilite rapor
            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                nkrno = gridView3.GetRowCellValue(y, "Rapor No").ToString();
                name = gridView3.GetRowCellValue(y, "Numune Adı").ToString();
                frmPrint.name = nkrno + " - " + name;
                mKYS.Raporlar.Kozmetik.RaporKozmetik.raporID = nkrno;
                mKYS.Raporlar.Kozmetik.RaporKozmetik.tNu = "-2";
                mKYS.Raporlar.Kozmetik.Stabilite.raporID = nkrno;
                using (Raporlar.frmPrint frm = new Raporlar.frmPrint())
                {
                    frm.StabiliteRapor();
                    frm.ShowDialog();
                }

                //mKYS.Raporlar.Denetim.Koz1.raporID = nkrno;
                //mKYS.Raporlar.Denetim.Koz2.raporID = nkrno;
                //using (Raporlar.frmPrint frm = new Raporlar.frmPrint())
                //{
                //    frm.DKozmetikRapor();
                //    frm.ShowDialog();
                //}
            }

            //for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            //{
            //    id = gridView3.GetSelectedRows()[i].ToString();
            //    int y = Convert.ToInt32(id);
            //    nkrno = gridView3.GetRowCellValue(y, "Rapor No").ToString();

            //    mKYS.Raporlar.Kozmetik.RaporKozmetik.raporID = nkrno;
            //    mKYS.Raporlar.Kozmetik.Stabilite.raporID = nkrno;


            //    name = gridView3.GetRowCellValue(y, "Numune Adı").ToString();
            //    frmPrint.name = nkrno + " - " + name;

            //    mKYS.Raporlar.Kozmetik.RaporKozmetik report1 = new mKYS.Raporlar.Kozmetik.RaporKozmetik();
            //    report1.bilgi();
            //    report1.Name = nkrno + " - " + name;
            //    report1.CreateDocument();
            //    mKYS.Raporlar.Kozmetik.Stabilite report2 = new mKYS.Raporlar.Kozmetik.Stabilite();
            //    report2.bilgi();
            //    report2.CreateDocument();
            //    report1.Pages.AddRange(report2.Pages);
            //    report1.PrintingSystem.ContinuousPageNumbering = true;
            //    report1.ShowPreviewDialog();

            //}
        }

        string parola;
        protected void parolaolustur()
        {
            char[] cr = "0123456789abcdefghijklmnopqrstuvwxyz".ToCharArray();
            string result = string.Empty;
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                parola += cr[r.Next(0, cr.Length - 1)].ToString();
            }
        }

        private void barButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //onaylı rapor
            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                nkrno = gridView3.GetRowCellValue(y, "Rapor No").ToString();
                Raporlar.Yeni.entReport.raporno = nkrno;
                Raporlar.Yeni.entReport.onay = "yes";
                Raporlar.Yeni.entReport2.raporno = nkrno;
                Raporlar.Yeni.entReport3.raporno = nkrno;

                name = gridView3.GetRowCellValue(y, "Numune Adı").ToString();
                parolaolustur();
                frmPrint.name = nkrno + "-" + parola;
                Raporlar.Yeni.entReport.fname = nkrno + "-" + parola;

                Raporlar.Yeni.entReport report1 = new Raporlar.Yeni.entReport();
                report1.bilgi();
                report1.Name = nkrno + "-" + parola;
                report1.CreateDocument();
                Raporlar.Yeni.entReport2 report2 = new Raporlar.Yeni.entReport2();
                report2.bilgi();
                report2.CreateDocument();
                Raporlar.Yeni.entReport3 report3 = new Raporlar.Yeni.entReport3();
                report3.bilgi();
                report3.CreateDocument();
                report1.Pages.AddRange(report2.Pages);
                report1.Pages.AddRange(report3.Pages);
                report1.PrintingSystem.ContinuousPageNumbering = true;
                report1.ShowPreviewDialog();

                //Raporlar.Yeni.tReport.raporno = nkrno;
                ////Raporlar.Yeni.YeniRapor2.raporno = raporNo;
                ////Raporlar.Yeni.YeniRapor3.raporno = raporNo;
                //using (frmPrint frm = new frmPrint())
                //{
                //    frm.RaporYeni();
                //    frm.ShowDialog();
                //}
            }
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Rapor eski format
            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                nkrno = gridView3.GetRowCellValue(y, "Rapor No").ToString();

                Rapor1.raporno = nkrno;
                tReportx2.raporno = nkrno;
                Rapor3.raporno = nkrno;

                Rapor1 report1 = new Rapor1();
                report1.bilgi();
                report1.CreateDocument();
                tReportx2 report2 = new tReportx2();
                report2.bilgi();
                report2.CreateDocument();
                Rapor3 report3 = new Rapor3();
                report3.bilgi();
                report3.CreateDocument();
                report1.Pages.AddRange(report2.Pages);
                report1.Pages.AddRange(report3.Pages);
                report1.PrintingSystem.ContinuousPageNumbering = true;
                report1.ShowPreviewDialog();
            }
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                nkrno = gridView3.GetRowCellValue(y, "Rapor No").ToString();
                name = gridView3.GetRowCellValue(y, "Numune Adı").ToString();
                frmPrint.name = nkrno + " - " + name;
                mKYS.Raporlar.Kozmetik.RaporKozmetik.raporID = nkrno;
                mKYS.Raporlar.Kozmetik.RaporKozmetik2.raporID = nkrno;
                using (Raporlar.frmPrint frm = new Raporlar.frmPrint())
                {
                    frm.KozmetikRapor();
                    frm.ShowDialog();
                }

                //mKYS.Raporlar.Denetim.Koz1.raporID = nkrno;
                //mKYS.Raporlar.Denetim.Koz2.raporID = nkrno;
                //using (Raporlar.frmPrint frm = new Raporlar.frmPrint())
                //{
                //    frm.DKozmetikRapor();
                //    frm.ShowDialog();
                //}
            }
        }

        public static decimal kesilen, kalan;
        public static string firmaad;
        private void gridView3_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            
            if (e.Column.FieldName == "Rapor No" || e.Column.FieldName == "Termin" || e.Column.FieldName == "Rapor Durumu"  || e.Column.FieldName == "Evrak No" || e.Column.FieldName =="Tarih" || e.Column.FieldName == "Servis" )
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;        
        }

        public static string alicifirma, termin, lot, skt, üt, basvuru, model, marka, adres, ntur, nakr, nrev;
        
        private void  termint()
        {
            SqlCommand detay2 = new SqlCommand("Select Termin from Termin where RaporID = N'" + aID + "'", bgl.baglanti());
            SqlDataReader dre = detay2.ExecuteReader();
            while (dre.Read())
            {
                termin = dre["Termin"].ToString();
            }
        }
       
        private void Numunedet()
        {
            SqlCommand detay = new SqlCommand("Select * from NumuneDetay where RaporID = N'" + aID+ "'", bgl.baglanti());
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

            SqlCommand detay2 = new SqlCommand("select Tur, Akreditasyon, Revno from NKR where ID = N'" + aID + "'", bgl.baglanti());
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
                    //faturaDurumu = dr["Fatura Durumu"].ToString();
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

        public string yenirDurumu = "Raporlandı";

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (raporDurumu == NumuneKabul.rDurumu)
            {
                SqlCommand komut = new SqlCommand("update NKR set Rapor_Durumu = @r1 where RaporNo=@r2", bgl.baglanti());
                komut.Parameters.AddWithValue("@r1", yenirDurumu);
                komut.Parameters.AddWithValue("@r2", raporNo);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
             //   listele();

            }
            else
            {
                SqlCommand komut2 = new SqlCommand("update NKR set Rapor_Durumu = @r1 where RaporNo=@r2", bgl.baglanti());
                komut2.Parameters.AddWithValue("@r1", NumuneKabul.rDurumu);
                komut2.Parameters.AddWithValue("@r2", raporNo);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
             //   listele();
            }
        }
    }
}