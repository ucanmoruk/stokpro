using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class Limitv2 : Form
    {
        public Limitv2()
        {
            InitializeComponent();
        }


        sqlbaglanti bgl = new sqlbaglanti();
        Limit n = (Limit)System.Windows.Forms.Application.OpenForms["Limit"];


        void detaybul()
        {
            SqlCommand komut = new SqlCommand("select * from NumuneX3 where ID = '" + tID + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txt_aciklama.Text = dr["Aciklama"].ToString();
            }
            bgl.baglanti().Close();

            analizler();

            tekliflistele2();
        }

        void tekliflistele2()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(@"select x.ID, k.Kod, k.Ad, k.Method, d.Aciklama , x.Limit, x.Birim from NumuneX4 x
                    left join StokAnalizDetay d on x.AltAnalizID = d.ID
                    left join StokAnalizListesi k on d.AnalizID = k.ID
                    where x.x3ID = '" + tID + "' order by K.Kod", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;
            gridView1.Columns["ID"].Visible = false;


        }

        public static int maxevrak;
        public void maxteklifno()
        {
            SqlCommand komutm = new SqlCommand("select max(ID) from NumuneX3 where Durum = 'Aktif' ", bgl.baglanti());
            SqlDataReader drm = komutm.ExecuteReader();
            while (drm.Read())
            {
                maxevrak = Convert.ToInt32(drm[0].ToString());
            }
            bgl.baglanti().Close();
        }

        public static string tID, gelis, kapama;
        private void Teklifv2_Load(object sender, EventArgs e)
        {

            //GridColumnSummaryItem item = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Toplam", "{0:C}");
            //gridView1.Columns["Toplam"].Summary.Add(item);


            if (tID == null || tID == "")
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(@"select Kod, Ad, Method, Matriks, ID from StokAnalizListesi where Durumu = 'Aktif'", bgl.baglanti());
                da.Fill(dt);
                gridControl2.DataSource = dt;
                gridView2.Columns["ID"].Visible = false;

                kapama = "2";
                maxteklifno();
              //  txt_no.Text = maxevrak.ToString();
                txt_no.Text = (maxevrak + 1).ToString();
                gelis = "yeni";
                btn_ok.Text = "Limit Kaydet";
            }
            else
            {
                kapama = "1";
                txt_no.Text = tID;
                Text = "Limit Detayları";
                btn_ok.Text = "Limit Güncelle";
                gelis = "güncelle";
                detaybul();
            }

        }

        private void Teklifv2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (kapama == "1")
            {

            }
            else
            {
                DialogResult sonuc = MessageBox.Show("Limitlerinizi kaydetmeden çıkmak istediğinizden emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (sonuc == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    SqlCommand add = new SqlCommand("delete from NumuneX4 where x3ID = @p1 ", bgl.baglanti());
                    add.Parameters.AddWithValue("@p1", txt_no.Text);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();

                }
            }
            tID = null;
            kapama = null;
        }
   

        private void combo_tur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_tur.Text == "Paket")
            {
                //gridControl1.DataSource = null;
                //gridView1.Columns.Clear();
                //gridControl2.DataSource = null;
                //gridView2.Columns.Clear();
                //paketler();
            }
            else 
            {
                gridControl1.DataSource = null;
                gridView1.Columns.Clear();
                gridControl2.DataSource = null;
                gridView2.Columns.Clear();
                analizler();
            }

        }

        void paketler()
        {
            //DataTable dt2 = new DataTable();
            //SqlDataAdapter da2 = new SqlDataAdapter(@"select Grup as 'Grup', Tur as [Paket Adı], ID from Numune_Grup  where Grup = 'Özel' or Grup = 'Tareks'
            //order by Grup", bgl.baglanti());
            //da2.Fill(dt2);
            //gridControl2.DataSource = dt2;
            //gridView2.Columns["ID"].Visible = false;
            //this.gridView2.Columns[0].Width = 35;
            //this.gridView2.Columns[1].Width = 65;

        }

        void analizler()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select Kod, Ad, Method, Matriks, ID from StokAnalizListesi where Durumu = 'Aktif'
            except select Kod, Ad, Method, Matriks, ID from StokAnalizListesi
            where ID in (select AnalizID from StokAnalizDetay where ID in (select AltAnalizID from Numunex4 where x3ID = '" + tID + "' ))", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
            gridView2.Columns["ID"].Visible = false;
        }

        void analizler2()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select Kod, Ad, Method, Matriks, ID from StokAnalizListesi where Durumu = 'Aktif'
            except select Kod, Ad, Method, Matriks, ID from StokAnalizListesi
            where ID in (select AnalizID from StokAnalizDetay where ID in (select AltAnalizID from Numunex4 where x3ID = '" +txt_no.Text+ "' ))", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
            gridView2.Columns["ID"].Visible = false;
        }

        private void gridView2_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu2.ShowPopup(p2);
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

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cikarma();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ekleme();

            tekliflistele();
        }

        //void tekliflistekontrol()
        //{
        //    SqlCommand komut2 = new SqlCommand("select count(ID) as 'No' from NumuneX3 where ID = N'" + txt_no.Text + "'  ", bgl.baglanti());
        //    SqlDataReader dr2 = komut2.ExecuteReader();
        //    while (dr2.Read())
        //    {
        //        detayk = Convert.ToInt32(dr2["No"]);
        //    }
        //    bgl.baglanti().Close();
        //}

        int detayk;
        string id, o2;
        void ekleme()
        {

            for (int i = 0; i < gridView2.SelectedRowsCount; i++)
            {
                id = gridView2.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                o2 = gridView2.GetRowCellValue(y, "ID").ToString();

                SqlCommand komut2 = new SqlCommand("select * from StokAnalizDetay where AnalizID = N'" + o2 + "' and Durum = N'Aktif' ", bgl.baglanti());
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    int altID = Convert.ToInt32(dr2["ID"]);
                    string birim = dr2["Birim"].ToString();

                    SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                    "insert into NumuneX4 (x3ID, AltAnalizID, Birim) " +
                    "values (@o1,@o2, @o3);" +
                    "COMMIT TRANSACTION", bgl.baglanti());
                    add2.Parameters.AddWithValue("@o1", txt_no.Text);
                    add2.Parameters.AddWithValue("@o2", altID);
                    add2.Parameters.AddWithValue("@o3", birim);
                    add2.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }
                bgl.baglanti().Close();



            }

            if (tID == "" || tID == null)
            {
                analizler2();
            }
            else
            {
                analizler();
            }


            tekliflistele();

        }

        void cikarma()
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show("Seçili analizleri kaldırmak istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Secim == DialogResult.Yes)
                {

                    for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                    {
                        id = gridView1.GetSelectedRows()[i].ToString();
                        int y = Convert.ToInt32(id);
                        o2 = gridView1.GetRowCellValue(y, "ID").ToString();
                        SqlCommand add = new SqlCommand("delete from NumuneX4 where x3ID = @p1 and ID = @p2 ", bgl.baglanti());
                        add.Parameters.AddWithValue("@p1", txt_no.Text);
                        add.Parameters.AddWithValue("@p2", o2);
                        add.ExecuteNonQuery();
                        bgl.baglanti().Close();

                    }

                    if (tID == "" || tID == null)
                    {
                        analizler2();
                    }
                    else
                    {
                        analizler();
                    }

                    tekliflistele();
                }
            }
            else
            {
                MessageBox.Show("Neyi mesela ?");
            }

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (gelis == "güncelle")
            {
                guncelle();
            }
            else
            {
                kaydet();
            }



            if (Application.OpenForms["Limit"] == null)
            {

            }
            else
            {
                n.listele();
            }

        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Limit" || e.Column.FieldName == "Birim" || e.Column.FieldName == "Kod" )
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //GridView view = sender as GridView;
            //if (view == null) return;
            //if (e.Column.FieldName == "Birim Fiyat")
            //{
            //    //string adet = view.GetRowCellValue(e.RowHandle, view.Columns["BirimFiyat"]).ToString();
            //    decimal adet = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Adet"]).ToString());
            //    string kon = Convert.ToString(adet);
            //    decimal birimfiyat = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Birim Fiyat"]).ToString());
            //    decimal sonf = Math.Round(adet * birimfiyat, 2);
            //    view.SetRowCellValue(e.RowHandle, view.Columns["Toplam"], sonf);
            //}
            //else if (e.Column.FieldName == "Adet")
            //{
            //    decimal adet = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Adet"]).ToString());
            //    string kon = Convert.ToString(adet);
            //    decimal birimfiyat = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Birim Fiyat"]).ToString());
            //    decimal sonf = Math.Round(adet * birimfiyat, 2);
            //    view.SetRowCellValue(e.RowHandle, view.Columns["Toplam"], sonf);
            //}

            //gridView1.Columns["Toplam"].Summary.Clear();
            //GridColumnSummaryItem item = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Toplam", "{0:C}");
            //gridView1.Columns["Toplam"].Summary.Add(item);

        }

        void kaydet()
        {
            try
            {

                for (int ik = 0; ik < gridView1.RowCount; ik++)
                {
                    //id = gridView1.GetSelectedRows()[ik].ToString();
                    //int y = Convert.ToInt32(id);
                    o2 = gridView1.GetRowCellValue(ik, "ID").ToString();
                    SqlCommand komutz = new SqlCommand("update NumuneX4 set Limit = @o1 , Birim = @o2   where ID = '" + o2 + "' and x3ID = '" + txt_no.Text + "'", bgl.baglanti());
                    komutz.Parameters.AddWithValue("@o1", gridView1.GetRowCellValue(ik, "Limit").ToString());
                    komutz.Parameters.AddWithValue("@o2", gridView1.GetRowCellValue(ik, "Birim").ToString());
                    komutz.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }
                DateTime tarih = DateTime.Now;
                SqlCommand komutaz = new SqlCommand(@"insert NumuneX3 (Aciklama, Tarih, Durum, KID) values (@a1, @a2, @a3, @a4)", bgl.baglanti());
                komutaz.Parameters.AddWithValue("@a1", txt_aciklama.Text);
                komutaz.Parameters.AddWithValue("@a2", tarih);
                komutaz.Parameters.AddWithValue("@a3", "Aktif");
                komutaz.Parameters.AddWithValue("@a4", Anasayfa.kullanici);
                komutaz.ExecuteNonQuery();
                bgl.baglanti().Close();

                kapama = "1";


                MessageBox.Show("Limit başarı ile oluşturuldu!");
                this.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata limit1 : " + ex);
            }
           

        }

        void guncelle()
        {
            try
            {

                for (int ik = 0; ik < gridView1.RowCount; ik++)
                {
                    //id = gridView1.GetSelectedRows()[ik].ToString();
                    //int y = Convert.ToInt32(id);
                    o2 = gridView1.GetRowCellValue(ik, "ID").ToString();
                    SqlCommand komutz = new SqlCommand("update NumuneX4 set Limit = @o1 , Birim = @o2   where ID = '" + o2 + "' and x3ID = '" + tID + "' ; " +
                        "update NumuneX3 set Aciklama = @o3 where ID = '"+tID+"' ", bgl.baglanti());
                    komutz.Parameters.AddWithValue("@o1", gridView1.GetRowCellValue(ik, "Limit").ToString());
                    komutz.Parameters.AddWithValue("@o2", gridView1.GetRowCellValue(ik, "Birim").ToString());
                    komutz.Parameters.AddWithValue("@o3", txt_aciklama.Text);
                    komutz.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }


                MessageBox.Show("Limit başarı ile güncellendi!");
                this.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata1 : " + ex);
            }
        }

        void tekliflistele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(@"select x.ID, k.Kod, k.Ad, k.Method, d.Aciklama , x.Limit, x.Birim from NumuneX4 x
                    left join StokAnalizDetay d on x.AltAnalizID = d.ID
                    left join StokAnalizListesi k on d.AnalizID = k.ID
                    where x.x3ID = '" + txt_no.Text + "' order by K.Kod", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;
            gridView1.Columns["ID"].Visible = false;

        }


    }
}
