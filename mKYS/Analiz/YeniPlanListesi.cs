using DevExpress.XtraEditors.Repository;
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

namespace mKYS.Analiz
{
    public partial class YeniPlanListesi : Form
    {
        public YeniPlanListesi()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt2 = new DataTable();

            SqlDataAdapter da2 = new SqlDataAdapter(@"SELECT DISTINCT(l.Kod), l.Ad as 'Analiz Adı', d.Kod + ' ' + d.Ad as 'Metot Kaynağı' , v.Tarih3 as 'Plan Oluşturma' , v.Urun as 'Matriks',  
			v.Tarih1 as 'Başlangıç', v.Tarih2 as 'Bitiş', v.Aciklama as 'Açıklama', v.Durumu, 
            STUFF((SELECT DISTINCT ' , ' + listek.Ad + ' ' + listek.Soyad AS [text()]
                FROM ValidasyonPlan listev
                left join StokAnalizListesi listel on listev.AnalizID = listel.ID
		        left join ValidasyonYetkili listey on listev.AnalizID = listey.AnalizID
		        left join StokKullanici listek on listey.PersonelID = listek.ID
		        where listel.Kod = l.Kod and listey.Durum = 'Plan'
                FOR XML PATH('')
                ), 2, 2, '' )
            AS 'Personel', v.ID, v.AnalizID 
        FROM  ValidasyonPlan v
        left join StokAnalizListesi l on v.AnalizID = l.ID
        left join ValidasyonYetkili y on v.AnalizID = y.AnalizID
        left join StokKullanici k on y.PersonelID = k.ID
		left join StokDKDListe d on l.Metot = d.ID
		where v.Durum = 'Aktif' order by l.Kod", bgl.baglanti());

            da2.Fill(dt2);
            gridControl1.DataSource = dt2;

            gridView1.Columns["ID"].Visible = false;
            gridView1.Columns["AnalizID"].Visible = false;
            this.gridView1.Columns[0].Width = 35;
            this.gridView1.Columns[1].Width = 95;
            this.gridView1.Columns[2].Width = 100;
            this.gridView1.Columns[3].Width = 35;
            this.gridView1.Columns[4].Width = 75;
            this.gridView1.Columns[5].Width = 35;
            this.gridView1.Columns[6].Width = 35;
            this.gridView1.Columns[7].Width = 95;
            this.gridView1.Columns[8].Width = 40;
            this.gridView1.Columns[9].Width = 150;

            RepositoryItemMemoEdit memo = new RepositoryItemMemoEdit();
            gridView1.Columns["Açıklama"].ColumnEdit = memo;
            gridView1.Columns["Personel"].ColumnEdit = memo;
            gridView1.Columns["Açıklama"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gridView1.Columns["Personel"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show("Seçili validasyon planını gerçekleştirdiniz mi ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (Secim == DialogResult.Yes)
            {

                SqlCommand add2 = new SqlCommand("update ValidasyonPlan set Durumu=@o1 where ID = '" + vID + "'", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", "Gerçekleşti");
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();

                ValidasyonEkle.gelis = "plan";
                ValidasyonEkle.aID = AnalizID;
                ValidasyonEkle.vID = vID;
                ValidasyonEkle ve = new ValidasyonEkle();
                ve.Show();

                listele();
            }


           
           
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show("Seçili validasyon planını silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Secim == DialogResult.Yes)
                {

                    SqlCommand ad = new SqlCommand("update ValidasyonPlan set Durum = 'Pasif' where ID = '" + vID + "'", bgl.baglanti());
                    ad.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    listele();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata vx3 : " + ex.Message);
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        private void ValidasyonPlanListesi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                listele();
            }

        }

        string vID, AnalizID, durum;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            vID = dr["ID"].ToString();
            AnalizID = dr["AnalizID"].ToString();
            durum = dr["Durumu"].ToString();


           
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);

                //if (durum == "Planlandı")
                //{
                //    barButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //    barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                //    barButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                //}
                //else if (durum == "Gerçekleşti")
                //{
                //    barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //    barButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                //    barButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                //}
                //else
                //{
                //    barButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //    barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //    barButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                //}
            }

        }

        private void ValidasyonPlanListesi_Load(object sender, EventArgs e)
        {
            listele();
            yetkibul();
        }
       
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Başlangıç" || e.Column.FieldName == "Durumu" || e.Column.FieldName == "Bitiş" || e.Column.FieldName == "Plan Oluşturma")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string ODurum = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Durumu"]);
                if (ODurum == "İptal Edildi")
                {
                    e.Appearance.BackColor = Color.MediumVioletRed;
                }
                else if (ODurum == "Gerçekleşti")
                {
                    e.Appearance.BackColor = Color.LightGreen;
                }
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlCommand add2 = new SqlCommand("update ValidasyonPlan set Durumu=@o1 where ID = '" + vID + "'", bgl.baglanti());
            add2.Parameters.AddWithValue("@o1", "İptal Edildi");
            add2.ExecuteNonQuery();
            bgl.baglanti().Close();

            listele();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlCommand add2 = new SqlCommand("update ValidasyonPlan set Durumu=@o1 where ID = '" + vID + "'", bgl.baglanti());
            add2.Parameters.AddWithValue("@o1", "Planlandı");
            add2.ExecuteNonQuery();
            bgl.baglanti().Close();

            listele();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YeniPlan.planID = vID;
            YeniPlan yp = new YeniPlan();
            yp.Show();
        }

        int yetki;
        void yetkibul()
        {
            SqlCommand komut21 = new SqlCommand("Select * from KaliteYetki where Gorev = N'" + Anasayfa.gorev + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                yetki = Convert.ToInt32(dr21["Analiz"]);
            }
            bgl.baglanti().Close();

            if (yetki == 0 || yetki.ToString() == null)
            {
                barButtonItem7.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barSubItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barButtonItem7.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }

        }

    }
}
