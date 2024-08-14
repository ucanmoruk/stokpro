using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace mKYS.Musteri
{
    public partial class Teklif : Form
    {
        sqlbaglanti bgl = new sqlbaglanti();

        public Teklif()
        {
            InitializeComponent();
        }

        public void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select t.Tarih, t.TeklifNo as [Teklif No],  k.Ad as [Plasiyer], t.TeklifTuru as [Teklif Türü],
            f.Firma_Adi as [Firma adı],  t.Aciklama, t.TeklifDurum, t.ID from TeklifX1 t 
             inner join Firma f on t.FirmaID = f.ID 
            inner join StokKullanici k on k.ID = t.PlasiyerID 
            where t.Durum = 'Aktif' order by t.TeklifNo desc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.Columns["ID"].Visible = false;
        }

        private void Teklif_Load(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = true;
            listele();

            this.gridView1.Columns[0].Width = 50;
            this.gridView1.Columns[1].Width = 30;
            this.gridView1.Columns[2].Width = 75;
            this.gridView1.Columns[3].Width = 60;
            this.gridView1.Columns[4].Width = 200;
            this.gridView1.Columns[5].Width = 100;
            this.gridView1.Columns[6].Width = 75;
        }

        //private void simpleButton1_Click(object sender, EventArgs e)
        //{
        //    //TeklifDetay.gelis = "update";
        //    //TeklifDetay n = new TeklifDetay();
        //    //n.Show();
        //}

        private void groupControl2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            splitContainer1.Panel2Collapsed = true;
        }

        public static string paket, kullanici, girisk, tID;
        public static int teklifno;
       
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = false;

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            paket = dr["Teklif Türü"].ToString();
            teklifno = Convert.ToInt32(dr["Teklif No"].ToString());
            kullanici = dr["Plasiyer"].ToString();
            tID = dr["ID"].ToString();

            if (paket == "Paket")
            {
                gridControl2.DataSource = null;
                gridView2.Columns.Clear();

                //paket listeleme fonksiyonu

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(@"Select n.Tur as 'Analiz', Cast (t.BirimFiyat as NVARCHAR) + ' ' + t.FiyatBirim as 'Birim Fiyat', t.Adet, 
                Cast (t.Toplam as NVARCHAR) + ' ' + t.FiyatBirim as 'Toplam Fiyat' from TeklifX2 t 
                inner join Numune_Grup n on n.ID = t.PaketID 
                where t.TeklifNo = '" + teklifno + "' order by Analiz", bgl.baglanti());
                da.Fill(dt);
                gridControl2.DataSource = dt;

                this.gridView2.Columns[0].Width = 75;
                this.gridView2.Columns[1].Width = 55;
                this.gridView2.Columns[2].Width = 35;
                this.gridView2.Columns[3].Width = 55;
            }
            else
            {
                gridControl2.DataSource = null;
                gridView2.Columns.Clear();

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(@"Select n.Ad as 'Analiz', n.Method, Cast (t.BirimFiyat as NVARCHAR) + ' ' + t.FiyatBirim as 'Birim Fiyat',
                t.Adet, Cast (t.Toplam as NVARCHAR) + ' ' + t.FiyatBirim as 'Toplam Fiyat'  from TeklifX2 t 
                left join StokAnalizListesi n on n.ID = t.AnalizID 
                where t.TeklifNo = '" + teklifno + "' order by Analiz", bgl.baglanti());
                da.Fill(dt);
                gridControl2.DataSource = dt;
                this.gridView2.Columns[0].Width = 105;
                this.gridView2.Columns[1].Width = 85;
                this.gridView2.Columns[2].Width = 55;
                this.gridView2.Columns[3].Width = 35;
                this.gridView2.Columns[4].Width = 55;
            }
        }
       
        private void btn_update_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show("Seçili teklifi iptal etmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Secim == DialogResult.Yes)
            {
                girisk = mKYS.Anasayfa.ad.ToString();

                if (kullanici == girisk)
                {
                    SqlCommand komutz = new SqlCommand("update TeklifX1 set Durum = @o1 where TeklifNo = @o2 ", bgl.baglanti());
                    komutz.Parameters.AddWithValue("@o1", "Pasif");
                    komutz.Parameters.AddWithValue("@o2", teklifno);
                    komutz.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    MessageBox.Show("İstediğin oldu! Teklif iptal edildi.");

                    splitContainer1.Panel2Collapsed = true;
                }
                else
                {
                    MessageBox.Show("Teklifi sadece teklif veren iptal edebilir!");
                }
            }
            else
            {
                
            }             
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //print

            mUnique.Raporlar.TeklifUni.teklifID = teklifID ;
            using (Raporlar.frmPrint frm = new Raporlar.frmPrint())
            {
                frm.Teklif();
                frm.ShowDialog();
            }

        }

        Teklifv2 fr6;
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6 == null || fr6.IsDisposed)
            {
                fr6 = new Teklifv2();
                fr6.MdiParent = Application.OpenForms.OfType<Anasayfa>().FirstOrDefault();
                fr6.Show();
            }
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }
        }

        string teklifID;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                teklifID = dr["ID"].ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //onaylandı

            SqlCommand komutz = new SqlCommand("update TeklifX1 set TekilfDurum = @o1, OnayTarih = @o3 where ID = @o2 ", bgl.baglanti());
            komutz.Parameters.AddWithValue("@o1", "Onaylandı");
            komutz.Parameters.AddWithValue("@o3", DateTime.Now);
            komutz.Parameters.AddWithValue("@o2", teklifID);
            komutz.ExecuteNonQuery();
            bgl.baglanti().Close();

            listele();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Onay bekliyor

            SqlCommand komutz = new SqlCommand("update TeklifX1 set TekilfDurum = @o1, OnayTarih = @o3 where ID = @o2 ", bgl.baglanti());
            komutz.Parameters.AddWithValue("@o1", "Onay Bekliyor");
            komutz.Parameters.AddWithValue("@o3", DateTime.Now);
            komutz.Parameters.AddWithValue("@o2", teklifID);
            komutz.ExecuteNonQuery();
            bgl.baglanti().Close();

            listele();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Teklifv2 n = new Teklifv2();
            n.Show();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
                if (e.Column.FieldName == "Tarih" || e.Column.FieldName == "Teklif No" || e.Column.FieldName == "TeklifDurum")
                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            girisk = Giris.ad.ToString();

            if (kullanici == girisk)
            {
                Teklifv2.tID = tID;
                if (fr6 == null || fr6.IsDisposed)
                {
                    fr6 = new Teklifv2();
                    fr6.MdiParent = Application.OpenForms.OfType<Anasayfa>().FirstOrDefault();
                    fr6.Show();
                }
            }
            else
            {
                MessageBox.Show("Teklifi sadece teklif veren güncelleyebilir!");
            }
        }
   
    }
}
