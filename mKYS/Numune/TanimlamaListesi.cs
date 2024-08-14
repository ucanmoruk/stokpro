using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;

namespace mKYS
{
    public partial class TanimlamaListesi : Form
    {
        public TanimlamaListesi()
        {
            InitializeComponent();
        }


        sqlbaglanti bgl = new sqlbaglanti();


        public void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select t.Termin, n.RaporNo as 'Rapor Numarası', n.Numune_Adi as 'Numune Adı', n.Tur as 'Numune Türü', d.Model, 
            n.Aciklama as 'Özel Not', k.Ad as 'Son Güncelleyen', r.Durum , r.Tarih as 'Son Güncelleme', r.RaporID from Rapor_Durum r 
            left join NKR n on n.ID = r.RaporID
            left join Termin t on n.ID = t.RaporID
            left join StokKullanici k on k.ID = r.TanimlayanID 
            left join NumuneDetay d on d.RaporID = n.ID 
            where n.Durum='Aktif' and year(r.Tarih) = N'" + combo_year.Text + "' and month(r.Tarih) = N'" + ayi + "' order by n.ID desc  ", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();

            gridView1.Columns["RaporID"].Visible = false;

            combo_ay.Text = DateTime.Now.ToString("MMMM");
            if (combo_ay.Text == "Ocak")
                ayi = 1;
            else if (combo_ay.Text == "Şubat")
                ayi = 2;
            else if (combo_ay.Text == "Şubat")
                ayi = 2;
            else if (combo_ay.Text == "Mart")
                ayi = 3;
            else if (combo_ay.Text == "Nisan")
                ayi = 4;
            else if (combo_ay.Text == "Mayıs")
                ayi = 5;
            else if (combo_ay.Text == "Haziran")
                ayi = 6;
            else if (combo_ay.Text == "Temmuz")
                ayi = 7;
            else if (combo_ay.Text == "Ağustos")
                ayi = 8;
            else if (combo_ay.Text == "Eylül")
                ayi = 9;
            else if (combo_ay.Text == "Ekim")
                ayi = 10;
            else if (combo_ay.Text == "Kasım")
                ayi = 11;
            else if (combo_ay.Text == "Aralık")
                ayi = 12;


            this.gridView1.Columns[0].Width = 75;
            this.gridView1.Columns[1].Width = 75;
            this.gridView1.Columns[2].Width = 180;
            this.gridView1.Columns[3].Width = 100;
            this.gridView1.Columns[4].Width = 100;
            this.gridView1.Columns[5].Width = 120;
            this.gridView1.Columns[6].Width = 75;
            this.gridView1.Columns[7].Width = 75;
            this.gridView1.Columns[8].Width = 75;

            //özel3
            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter(@"select d.RaporID, n.RaporNo as 'Rapor Numarası', n.Numune_Adi as 'Numune Adı', n.Tur as 'Numune Türü', d.Model, 
            //n.Aciklama as 'Özel Not' from NKR n
            //left join NumuneDetay d on d.RaporID = n.ID 
            //where n.Grup='Özel3' order by n.RaporNo desc  ", bgl.baglanti());
            //da.Fill(dt);
            //gridControl1.DataSource = dt;
            //bgl.baglanti().Close();

        }
        public static string raporno;

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                raporno = dr["Rapor Numarası"].ToString();
                raporID = dr["RaporID"].ToString();
                Numune.TanimDetay.raporID = raporID;
                Numune.TanimDetay td = new Numune.TanimDetay();
                td.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata 5: "+ex);
            }
 

        }

        int ayi;
        private void Tanimlama_Load(object sender, EventArgs e)
        {
            listele();


        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Son Güncelleyen" || e.Column.FieldName == "Son Güncelleme" || e.Column.FieldName == "Rapor Numarası" ||  e.Column.FieldName == "Durum" || e.Column.FieldName == "Termin")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

        }

        private void combo_ay_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (combo_ay.Text == "Ocak")
                    ayi = 1;
                else if (combo_ay.Text == "Şubat")
                    ayi = 2;
                else if (combo_ay.Text == "Şubat")
                    ayi = 2;
                else if (combo_ay.Text == "Mart")
                    ayi = 3;
                else if (combo_ay.Text == "Nisan")
                    ayi = 4;
                else if (combo_ay.Text == "Mayıs")
                    ayi = 5;
                else if (combo_ay.Text == "Haziran")
                    ayi = 6;
                else if (combo_ay.Text == "Temmuz")
                    ayi = 7;
                else if (combo_ay.Text == "Ağustos")
                    ayi = 8;
                else if (combo_ay.Text == "Eylül")
                    ayi = 9;
                else if (combo_ay.Text == "Ekim")
                    ayi = 10;
                else if (combo_ay.Text == "Kasım")
                    ayi = 11;
                else if (combo_ay.Text == "Aralık")
                    ayi = 12;
                listele();
            }
            catch (Exception)
            {
                MessageBox.Show("Bu ay hiç tanımlanacak numune bulunamadı!");
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select t.Termin, n.RaporNo as 'Rapor Numarası', n.Numune_Adi as 'Numune Adı', d.Model, n.Tur as 'Numune Türü', k.Ad as 'Son Güncelleyen', r.Durum , r.Tarih as 'Son Güncelleme', r.RaporID from Rapor_Durum r " +
            "left join NKR n on n.ID = r.RaporID left join Termin t on n.ID = t.RaporID left join StokKullanici k on k.ID = r.TanimlayanID left join NumuneDetay d on d.RaporID = n.ID where n.Durum = 'Aktif' order by r.RaporNo desc  ", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();

            gridView1.Columns["RaporID"].Visible = false;
        }

        private void combo_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            listele();
        }

        private void BarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Numune.TanimDetay.raporID = raporID;
            Numune.TanimDetay td = new Numune.TanimDetay();   
            td.Show();
        }

        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }                       
        }

        string durum, raporID;
        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                raporno = dr["Rapor Numarası"].ToString();
                raporID = dr["RaporID"].ToString();
                durum = gridView1.GetRowCellValue(e.FocusedRowHandle, "Durum").ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hatasız kul olmaz.." + ex);
            }


        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                //Numune.Mix.raporID = raporID;
                //Numune.Mix m = new Numune.Mix();
                //m.Show();

            Numune.Mix2.raporID = raporID;
            Numune.Mix2.raporno = raporno;
            Numune.Mix2 m = new Numune.Mix2();
            m.Show();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            listele();
        }
                
        private void TanimlamaListesi_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.F5)
            {
                listele();
            }


        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           // Hamveri rapor şablonu hazır olduğunda burayı aktifleştir.


           Raporlar.Hamveri.raporno = raporno;
            using (Raporlar.frmPrint frm = new Raporlar.frmPrint())
            {
                frm.Hamveri();
                frm.ShowDialog();
            }
        }

        int tanimsayi;
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlCommand komut = new SqlCommand("select Count(No) from Tanimlama where RaporID = N'"+ raporID  +"'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                tanimsayi = Convert.ToInt32(dr[0]);
            }
            bgl.baglanti().Close();

            if (tanimsayi == 0)
            {
                MessageBox.Show("Ben kopyalayacak bir şey göremedim. Sen görüyorsan söyle!");
            }
            else
            {
                Numune.TanimKopyaHedef.gelenrapor = raporno;
                Numune.TanimKopyaHedef hf = new Numune.TanimKopyaHedef();
                hf.Show();
            }

        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //barkod yazdır
            PrinterSettings ps = new PrinterSettings();
            PrintDocument Kagit = new PrintDocument();
            Kagit.PrinterSettings = ps;
            Kagit.DefaultPageSettings.PaperSize = new PaperSize("80x100 mm", 380, 315);
            DialogResult yazdirmaislemi;
            yazdirmaislemi = prd.ShowDialog();
            Kagit.PrintPage += Kagit_PrintPage;
            if (yazdirmaislemi == DialogResult.OK)
            {
                Kagit.Print();
            }
        }

        PrintDialog prd = new PrintDialog();
        string analiz, metod, kod;
        private void Kagit_PrintPage(object sender, PrintPageEventArgs e)
        {
            //throw new NotImplementedException();

            string yazi = "Rapor No: " + raporno;
            string yazi2 = "Talep Edilen Testler:";
            Font YaziAilesi = new Font("Tahoma", 11, FontStyle.Bold);
            Font Yazi2 = new Font("Tahoma", 8);
            Font analizler = new Font("Tahoma", 7);
            SolidBrush kalem = new SolidBrush(Color.Black);
            e.Graphics.DrawString(yazi, YaziAilesi, kalem, 30, 40);
            e.Graphics.DrawString(yazi2, Yazi2, kalem, 20, 75);

            int a = 90;
            int b = 1;

            SqlCommand komut = new SqlCommand("select * from StokAnalizListesi where ID in (select AnalizID from Numunex2 where RaporID = '" + raporID + "')", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                kod = dr["Kod"].ToString();
                analiz = dr["Ad"].ToString();
                metod = dr["Method"].ToString();

                e.Graphics.DrawString(b + ". " + kod + "-"+ analiz + " / " + metod, analizler, kalem, 20, a);
                a += 15;
                b++;
            }
            bgl.baglanti().Close();


            //for (int j = 0; j < gridView2.SelectedRowsCount; j++)
            //{
            //    id = gridView2.GetSelectedRows()[j].ToString();
            //    int y = Convert.ToInt32(id);
            //    analiz = gridView2.GetRowCellValue(y, "Analiz Adı").ToString();
            //    metod = gridView2.GetRowCellValue(y, "Metot").ToString();

            //    e.Graphics.DrawString(b + ". " + analiz + " / " + metod, analizler, kalem, 20, a);
            //    a += 15;
            //    b++;
            //}
        }

        Numune.SonucListesi sl;
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Sonuç girme 
           //raporID
            Numune.SonucListesi.raporID = raporID;
            Numune.SonucListesi.raporNo = raporno;

            Numune.SonucListesi sl = new Numune.SonucListesi();
            sl.Show();

            //if (sl == null || sl.IsDisposed)
            //{
            //    sl = new Numune.SonucListesi();
            //    sl.MdiParent = Application.OpenForms.OfType<Anasayfa>().FirstOrDefault();
            //    sl.Show();
            //}
        }
    }
}
