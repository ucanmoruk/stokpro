using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mKYS.Dokuman
{
    public partial class DKDListe : Form
    {
        public DKDListe()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select Row_number() over(order by l.ID) as 'No', l.Birim, l.Kaynak, l.Kod, l.Ad, l.Tarih, l.Tur as 'Açıklama', l.Link,  d.Kontrol as 'Kontrol Tarihi', k.Ad + ' ' +  k.Soyad as 'Kontrol Eden', l.ID  from StokDKDListe l " +
                " left join StokDKDKontrol d on l.Kod = d.Kod left join StokKullanici k on d.PersonelID = k.ID where l.Durum = N'Aktif' order by l.Birim", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

            this.gridView1.Columns[0].Width = 20;
            this.gridView1.Columns[1].Width = 35;
            this.gridView1.Columns[2].Width = 35;
            this.gridView1.Columns[3].Width = 50;
            this.gridView1.Columns[4].Width = 180;            
            this.gridView1.Columns[5].Width = 35;
            this.gridView1.Columns[6].Width = 55;
            this.gridView1.Columns[8].Width = 35;
            this.gridView1.Columns[9].Width = 50;

            gridView1.Columns["ID"].Visible = false;

            RepositoryItemMemoEdit memo = new RepositoryItemMemoEdit();
            gridView1.Columns["Ad"].ColumnEdit = memo;
            gridView1.Columns["Birim"].ColumnEdit = memo;
            gridView1.Columns["Ad"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gridView1.Columns["Birim"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;



        }

        int yetki;
        void yetkibul()
        {
            SqlCommand komut21 = new SqlCommand("Select * from KaliteYetki where Gorev = N'" + Anasayfa.gorev + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                yetki = Convert.ToInt32(dr21["Dokuman"]);
            }
            bgl.baglanti().Close();

            if (yetki == 0 || yetki.ToString() == null)
            {
                barButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
            }

        }

        string path, ad;
        void kontrol()
        {
            SqlCommand komut21 = new SqlCommand("Select * from StokDKDListe where Kod = N'" + dkdkod + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                path = dr21["Path"].ToString();
                ad = dr21["Kod"].ToString();
            }
            bgl.baglanti().Close();
        }

        int guncel;


        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            kontrol();
            if (path == "" || path == null)
            {
                MessageBox.Show(dkdkod + " dokümanı henüz sisteme yüklenmemiştir!", "Oooppss!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                kontrol();
                DokumanGoruntule.yol = path;
                DokumanGoruntule.ad = ad;
                DokumanGoruntule dg = new DokumanGoruntule();
                dg.Show();
            }
        }

        string ykod, id;
        public void kontrolet()
        {
            if (gridView1.SelectedRowsCount == 0)
            {
                MessageBox.Show("Lütfen kontrolünü sağladığınız dokümanı seçiniz!", "Oopppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                DateTime tarih = DateTime.Now;

                for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                {
                    id = gridView1.GetSelectedRows()[i].ToString();
                    int y = Convert.ToInt32(id);
                    ykod = gridView1.GetRowCellValue(y, "Kod").ToString();

                    SqlCommand komut21 = new SqlCommand("Select Count(ID) from StokDKDKontrol where Kod = N'" + ykod+ "' ", bgl.baglanti());
                    SqlDataReader dr21 = komut21.ExecuteReader();
                    while (dr21.Read())
                    {
                        guncel = Convert.ToInt32(dr21[0].ToString());
                    }
                    bgl.baglanti().Close();

                    if (guncel == 0)
                    {
                        SqlCommand komutSil = new SqlCommand("insert StokDKDKontrol (Kod, PersonelID, Kontrol) values (@a1, @a2, @a3) ", bgl.baglanti());
                        komutSil.Parameters.AddWithValue("@a1", ykod);
                        komutSil.Parameters.AddWithValue("@a2", Anasayfa.kullanici);
                        komutSil.Parameters.AddWithValue("@a3", tarih);
                        komutSil.ExecuteNonQuery();
                        bgl.baglanti().Close();
                    }
                    else
                    {
                        SqlCommand komutSil = new SqlCommand("update StokDKDKontrol set PersonelID=@a1, Kontrol=@a2 where Kod = N'" + ykod + "'", bgl.baglanti());
                        komutSil.Parameters.AddWithValue("@a1", Anasayfa.kullanici);
                        komutSil.Parameters.AddWithValue("@a2", tarih);
                        komutSil.ExecuteNonQuery();
                        bgl.baglanti().Close();

                    }
                }
                listele();
                MessageBox.Show("Kontrol işlemi başarıyla gerçekleşmiştir.");
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            kontrolet();
   
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //DKDEkle.dkdkod = dkdkod;
            //DKDEkle.dkdad = dkdad;
            DKDEkle.dkdID = dID;
            DKDEkle de = new DKDEkle();
            de.Show();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show(dkdkod + " dokümanını silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Secim == DialogResult.Yes)
                {
                    // SqlCommand komutSil = new SqlCommand("delete from Firma where ID = @p1", bgl.baglanti());
                   // SqlCommand komutSil = new SqlCommand("update StokDKDListe set Durum=@a1 where Kod = N'" + dkdkod + "' and Ad = N'"+dkdad+"'", bgl.baglanti());
                    SqlCommand komutSil = new SqlCommand("update StokDKDListe set Durum=@a1 where ID = N'" + dID + "' ", bgl.baglanti());
                    komutSil.Parameters.AddWithValue("@a1", "Pasif");
                    komutSil.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Silme işlemi gerçekleşmiştir.");
                    listele();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata 181 : " + ex.Message);
            }
        }

        private void DKDListe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                listele();
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

        private void DKDListe_Load(object sender, EventArgs e)
        {
            listele();
            yetkibul();
            //Anasayfa.b
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "No" || e.Column.FieldName == "Kontrol Tarihi")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

        }

    
        private void DKDListe_FormClosing(object sender, FormClosingEventArgs e)
        {
            var mfrm = (Anasayfa)Application.OpenForms["Anasayfa"];
            if (mfrm != null)
                mfrm.gizle();

        }

        private void DKDListe_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        public void excelaktar()
        {
            string path = "DKDListe.xlsx";
            gridControl1.ExportToXlsx(path);
            Process.Start(path);
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            excelaktar();
        }

        string dkdkod, dkdad, dID;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {        
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                dkdkod = dr["Kod"].ToString();
                dkdad = dr["Ad"].ToString();
                dID = dr["ID"].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Aradığınız doküman bulunamamıştır!", "Ooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
        }
    }
}
