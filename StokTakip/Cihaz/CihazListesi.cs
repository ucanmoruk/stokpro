﻿using DevExpress.XtraGrid.Views.Grid;
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

namespace StokTakip.Cihaz
{
    public partial class CihazListesi : Form
    {
        public CihazListesi()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        private void CihazListesi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                listele();
            }

        }
        private void btn_yenile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }
        private void btn_kullanim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btn_kullanim.Caption == "Kullanıma Al")
            {
                SqlCommand komutSil = new SqlCommand("update CihazListesi set Durumu=@a1 where ID = N'" + cID + "' ", bgl.baglanti());
                komutSil.Parameters.AddWithValue("@a1", "Kullanımda");
                komutSil.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Cihaz kullanıma alınmıştır! ", "Ooppss!");

            }
            else
            {
                SqlCommand komutSil = new SqlCommand("update CihazListesi set Durumu=@a1 where ID = N'" + cID + "' ", bgl.baglanti());
                komutSil.Parameters.AddWithValue("@a1", "Kullanım Dışı");
                komutSil.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Cihaz kullanım dışı bırakılmıştır! " + "\n" + "Yetkili kullanıcılara bilgi vermeyi unutmayınız!", "Ooppss!");
            }
            listele();

        }
        private void btn_sil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show(cad + " cihazını silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (Secim == DialogResult.Yes)
            {
                SqlCommand komutSil = new SqlCommand("update CihazListesi set Durum=@a1 where ID = N'" + cID + "' ", bgl.baglanti());
                komutSil.Parameters.AddWithValue("@a1", "Pasif");
                komutSil.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Cihaz silme işlemi başarılı!", "Ooppss!");
                listele();
            }
            else
            {

            }



        }
        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }

            if (durum == "Kullanım Dışı")
            {
                btn_kullanim.Caption = "Kullanıma Al";
            }
            else
            {

                btn_kullanim.Caption = "Kullanım Dışı";
            }
        }

        string cID, durum, cad;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                cID = dr["ID"].ToString();
                cad = dr["Ad"].ToString();
                durum = dr["Durumu"].ToString();
            }
            catch (Exception)
            {
                // MessageBox.Show("Aradığınız cihaz bulunamadı!", "Oopss!");
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Tarih" || e.Column.FieldName == "Durumu")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string ODurum = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Durumu"]);
                if (ODurum == "Kullanım Dışı")
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }
        }


        int yetki;
        void yetkibul()
        {
            SqlCommand komut21 = new SqlCommand("Select * from KaliteYetki where Gorev = N'" + Anasayfa.gorev + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                yetki = Convert.ToInt32(dr21["Cihaz"]);
            }
            bgl.baglanti().Close();

            if (yetki == 0 || yetki.ToString() == null)
            {
            }
            else
            {
                btn_sil.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btn_kullanim.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }

        }

        public void listele()
        {
            DataTable dt6 = new DataTable();
            SqlDataAdapter da6 = new SqlDataAdapter("select b.Birim, c.ID, c.Kod as 'Cihaz Kodu', c.Ad as 'Cihaz Adı', c.Marka as 'Marka / Model', c.Seri as 'Seri No' ," +
                "t.Ad as 'Tedarikçi Firma', c.Tarih, c.Durumu from CihazListesi c" +
                " inner join StokTedarikci t on c.FirmaID = t.ID inner join StokFirmaBirim b on c.BirimID = b.ID where c.Durum = 'Aktif' order by c.Kod ", bgl.baglanti());
            da6.Fill(dt6);
            gridControl1.DataSource = dt6;
            gridView1.Columns["ID"].Visible = false;

            gridView1.Columns[0].Width = 60;
            gridView1.Columns[2].Width = 35;
            gridView1.Columns[3].Width = 105;
            gridView1.Columns[4].Width = 50;
            gridView1.Columns[5].Width = 50;
            gridView1.Columns[6].Width = 100;

        }



        private void CihazListesi_Load(object sender, EventArgs e)
        {
            listele();
            yetkibul();
        }

        private void btn_sicil_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //cihaz sicil kartı
        }

        private void btn_chzbilgi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CihazEkle.cihazkod = "1";
            CihazEkle.cID = cID;
            CihazEkle ce = new CihazEkle();
            ce.Show();
        }

        private void btn_chzkal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CihazEkle.cihazkod = "2";
            CihazEkle.cID = cID;
            CihazEkle ce = new CihazEkle();
            ce.Show();
        }

        private void btn_chzanaliz_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CihazEkle.cihazkod = "3";
            CihazEkle.cID = cID;
            CihazEkle ce = new CihazEkle();
            ce.Show();
        }

        private void btn_kalibrasyon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //kalibrasyon ekle
        }



 }
}
