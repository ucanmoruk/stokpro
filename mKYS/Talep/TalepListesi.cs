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

namespace mKYS
{
    public partial class TalepListesi : Form
    {
        public TalepListesi()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select l.TalepNo, l.Olusturma as 'Talep Tarihi', k.Ad + ' ' + k.Soyad as 'Talep Oluşturan', l.Durum, z.Ad + ' ' + z.Soyad as 'Değerlendiren', l.Onaylama as 'Değerlendirme Tarihi', b.Ad + ' ' + b.Soyad as 'İşleme Alan', l.Isleme as 'İşleme Alınma Tarihi' from StokTalepListe l " +
                "left join StokKullanici k on l.TalepEdenID= k.ID left join StokKullanici z on l.OnaylayanID = z.ID left join StokKullanici b on l.IsleyenID = b.ID " +
                "where l.Aktif <> N'Pasif' order by l.TalepNo desc", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;
        }

        int olusturanid;
        void kullanicibul()
        {
            SqlCommand komut21 = new SqlCommand("Select * from StokTalepListe where TalepNo = '"+talepno+"'", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                olusturanid = Convert.ToInt32(dr21["TalepEdenID"]);
            }
            bgl.baglanti().Close();

            //if (Anasayfa.kullanici == olusturanid.ToString())
            //{
               
            //    if (talepdurum == "Talep Oluşturuldu")
            //    {
            //        bar_talepiptal.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //        guncelle.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //    }
                    
            //    else
            //    {
            //        bar_talepiptal.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //        guncelle.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    }
                    
            //}
            //else
            //{
            //    guncelle.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    bar_talepiptal.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //}
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TalepDetay.TalepNo = talepno;
            TalepDetay td = new TalepDetay();
            td.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show(talepno + " numaralı talebi işleme alıyorsunuz?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (Secim == DialogResult.Yes)
            {
                DateTime tarih = DateTime.Now;

                SqlCommand add2 = new SqlCommand("update StokTalepListe set IsleyenID=@o1, Isleme=@o2, Durum=@o3 where TalepNo = '" + talepno + "'", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", Anasayfa.kullanici);
                add2.Parameters.AddWithValue("@o2", tarih);
                add2.Parameters.AddWithValue("@o3", "İşleme Alındı");
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();

                listele();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (olusturan == Anasayfa.tamad)
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show(talepno + " numaralı talebi iptal ediyorsunuz?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (Secim == DialogResult.Yes)
                {
                    DateTime tarih = DateTime.Now;

                    SqlCommand add2 = new SqlCommand("update StokTalepListe set Aktif=@o1 where TalepNo = '" + talepno + "'", bgl.baglanti());
                    add2.Parameters.AddWithValue("@o1", "Pasif");
                    add2.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    listele();
                }
            }
            else
            {
                MessageBox.Show(talepno + " numaralı talebi sadece talebi oluşturan kişi iptal edebilir!", "Ooppss!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

           
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show(talepno + " numaralı talebi onaylıyorsunuz?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (Secim == DialogResult.Yes)
            {
                DateTime tarih = DateTime.Now;

                SqlCommand add2 = new SqlCommand("update StokTalepListe set OnaylayanID=@o1, Onaylama=@o2, Durum=@o3 where TalepNo = '"+talepno+"'", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", Anasayfa.kullanici);
                add2.Parameters.AddWithValue("@o2", tarih);
                add2.Parameters.AddWithValue("@o3", "Talep Onaylandı");
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();

                listele();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show(talepno + " numaralı talebi reddediyorsunuz?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (Secim == DialogResult.Yes)
            {
                DateTime tarih = DateTime.Now;

                SqlCommand add2 = new SqlCommand("update StokTalepListe set OnaylayanID=@o1, Onaylama=@o2, Durum=@o3 where TalepNo = '" + talepno + "'", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", Anasayfa.kullanici);
                add2.Parameters.AddWithValue("@o2", tarih);
                add2.Parameters.AddWithValue("@o3", "Talep Reddedildi");
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();

                listele();
            }
        }

        int yetki;
        void yetkibul()
        {
            SqlCommand komut21 = new SqlCommand("Select * from KaliteYetki where Gorev = N'" + Anasayfa.gorev + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                yetki = Convert.ToInt32(dr21["Talep"]);
            }
            bgl.baglanti().Close();

            //if (yetki == 0 || yetki.ToString() == null)
            //{
                
            // //   bar_talepkabul.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //}
            //else if (yetki == 1)
            //{
            //  //  bar_talepdurum.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //}
            //else if (yetki == 2)
            //{
            //    bar_talepdurum.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //}
            //else if (yetki == 3)
            //{
            //    bar_talepdurum.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //    bar_taleponay.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    bar_talepred.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    bar_talepiptal.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    bar_talepkabul.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    bar_talepisle.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //}
            //else
            //{
            //    barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //    //bar_talepdurum.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //}

        }

        private void TalepListesi_Load(object sender, EventArgs e)
        {
            listele();
         //   yetkibul();
            //kullanicibul();


            this.gridView1.Columns[0].Width = 30;
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "TalepNo" || e.Column.FieldName == "Talep Tarihi" || e.Column.FieldName == "Değerlendirme Tarihi" || e.Column.FieldName == "İşleme Alınma Tarihi" )
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);

            }
        }

        string talepno,talepdurum, olusturan;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            talepno = dr["TalepNo"].ToString();
            talepdurum = dr["Durum"].ToString();
            olusturan = dr["Talep Oluşturan"].ToString();


            kullanicibul();

            //if (talepdurum == "Talep Oluşturuldu")
            //{
            //    if (olusturan == Anasayfa.tamad)
            //    {
            //        guncelle.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //        bar_talepiptal.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //    }
            //    else
            //    {
            //        guncelle.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //        bar_talepiptal.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    }


            //    if (yetki == 0)
            //    {
            //        bar_talepdurum.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            //    }
            //    else if (yetki == 1)
            //    {
            //        bar_talepdurum.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            //    }
            //    else if (yetki == 2)
            //    {
            //        bar_talepdurum.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //        bar_taleponay.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //        bar_talepred.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //        bar_talepisle.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            //    }
            //    //bar_talepisle.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    //bar_taleptamam.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    //bar_talepkabul.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            //}
            //else if (talepdurum == "Talep Reddedildi" || talepdurum == "İşleme Alındı" || talepdurum == "Tamamlandı")
            //{
            //    guncelle.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    bar_talepiptal.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    bar_talepdurum.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            //}
            //else if (talepdurum == "Talep Onaylandı")
            //{
            //    if (yetki == 3)
            //    {
            //        bar_talepdurum.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //        bar_talepisle.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //        bar_taleponay.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //        bar_talepred.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            //    }
            //    else if (yetki == 2)
            //    {
            //        bar_talepdurum.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //        bar_talepisle.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //        bar_taleponay.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //        bar_talepred.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //    }
            //    else
            //    {
            //        bar_talepdurum.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    }
            //}


        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //talepno = dr["TalepNo"].ToString();
            //TalepDetay.TalepNo = talepno;
            //TalepDetay td = new TalepDetay();
            //td.ShowDialog();
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            string adam = gridView1.GetRowCellValue(e.RowHandle, "Durum").ToString();
            if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && adam == "Talep Oluşturuldu")
                e.Appearance.BackColor = Color.Salmon;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && adam == "Talep Reddedildi")
                e.Appearance.BackColor = Color.Red;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && adam == "Talep Onaylandı")
                e.Appearance.BackColor = Color.Turquoise;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && adam == "İşleme Alındı")
                e.Appearance.BackColor = Color.LightGreen;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && adam == "Tamamlandı")
                e.Appearance.BackColor = Color.Green;
        }

        private void guncelle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TalepYeni.talepno = talepno;

            var mfrm = (Anasayfa)Application.OpenForms["Anasayfa"];
            if (mfrm != null)
                mfrm.talepyeni();

        }

        private void TalepListesi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                listele();
            }
        }


        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //TalepKabul.TalepNo = talepno;
            //TalepKabul tk = new TalepKabul();
            //tk.Show();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //DialogResult Secim = new DialogResult();

            //Secim = MessageBox.Show(talepno + " numaralı talebi tamamladınız mı?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            //if (Secim == DialogResult.Yes)
            //{
            //    DateTime tarih = DateTime.Now;

            //    SqlCommand add2 = new SqlCommand("update StokTalepListe set IsleyenID=@o1, Isleme=@o2, Durum=@o3 where TalepNo = '" + talepno + "'", bgl.baglanti());
            //    add2.Parameters.AddWithValue("@o1", Anasayfa.kullanici);
            //    add2.Parameters.AddWithValue("@o2", tarih);
            //    add2.Parameters.AddWithValue("@o3", "Tamamlandı");
            //    add2.ExecuteNonQuery();
            //    bgl.baglanti().Close();

            //    listele();
            //}
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }
    }
}
