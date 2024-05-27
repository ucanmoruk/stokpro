using DevExpress.XtraEditors.Repository;
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
    public partial class ValidasyonListesi : Form
    {
        public ValidasyonListesi()
        {
            InitializeComponent();
        }


        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter("select v.AnalizID as 'ID', s.Kod, s.Ad, d.Kod + ' '+ d.Ad as 'Metot Kaynağı', v.Urun as 'Matriksler', v.Lod as 'LOD',v.Loq as 'LOQ', v.Birim as 'Birim', v.GK as 'Geri Kazanım', v.Bel as 'Belirsizlik', v.Tarih1 as 'Başlangıç', v.Tarih2 as 'Bitiş'  from ValidasyonVeri v " +
            //    "inner join StokAnalizListesi s on v.AnalizID = s.ID inner join StokDKDListe d on s.Metot = d.ID where v.Durum = 'Aktif' or v.Durum = 'Ortak'", bgl.baglanti());

            SqlDataAdapter da = new SqlDataAdapter(@"select  v.AnalizID as 'ID', s.Kod, v.Ek, s.Ad, d.Kod + ' '+ d.Ad as 'Metot Kaynağı', v.Urun as 'Matriksler', 
                v.Birim as 'Birim', v.Kalibrasyon, v.Lod as 'LOD',v.Loq as 'LOQ', 
                v.GK as 'Geri Kazanım', v.Bel as 'Belirsizlik', v.Tarih1 as 'Başlangıç', v.Tarih2 as 'Bitiş',
                 STUFF((SELECT DISTINCT ' , ' + listek.Ad + ' ' + listek.Soyad AS [text()]
                                FROM ValidasyonVeri listev
                                left join StokAnalizListesi listel on listev.AnalizID = listel.ID
		                        left join ValidasyonYetkili listey on listev.AnalizID = listey.AnalizID
		                        left join StokKullanici listek on listey.PersonelID = listek.ID
		                        where listel.Kod = s.Kod and listey.Durum = 'Aktif'
                                FOR XML PATH('')
                                ), 2, 2, '' )
                            AS 'Personel'
                from ValidasyonVeri v 
                left join StokAnalizListesi s on v.AnalizID = s.ID 
                left join StokDKDListe d on s.Metot = d.ID 
                where v.Durum = 'Aktif'  order by s.Kod", bgl.baglanti());

            da.Fill(dt);
            gridControl1.DataSource = dt;

            gridView1.Columns["ID"].Visible = false;
            this.gridView1.Columns[1].Width = 45;
            this.gridView1.Columns[2].Width = 30;
            this.gridView1.Columns[3].Width = 150;
            this.gridView1.Columns[4].Width = 180;
            this.gridView1.Columns[5].Width = 110;
            this.gridView1.Columns[6].Width = 40;
            this.gridView1.Columns[7].Width = 45;
            this.gridView1.Columns[8].Width = 40;
            this.gridView1.Columns[9].Width = 40;
            this.gridView1.Columns[10].Width = 45;
            this.gridView1.Columns[11].Width = 40;
            this.gridView1.Columns[12].Width = 40;
            this.gridView1.Columns[13].Width = 40;
            this.gridView1.Columns[14].Width = 110;

            RepositoryItemMemoEdit memo = new RepositoryItemMemoEdit();
            gridView1.Columns["Personel"].ColumnEdit = memo;
            gridView1.Columns["Personel"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
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
             
            }
            else
            {
                barButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
         
            }

        }

        private void ValidasyonListesi_Load(object sender, EventArgs e)
        {
            listele();
            yetkibul();
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }
        }

        private void ValidasyonListesi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                listele();
            }

        }

        string aID, kod;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            aID = dr["ID"].ToString();
            kod = dr["Kod"].ToString();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //sil
            try
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show(kod + " analizine ait validasyon verilerini silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Secim == DialogResult.Yes)
                {
                    // SqlCommand komutSil = new SqlCommand("delete from Firma where ID = @p1", bgl.baglanti());
                    SqlCommand komutSil = new SqlCommand("update ValidasyonVeri set Durum=@a1 where AnalizID = N'" + aID + "' and Durum = 'Aktif' or Durum='Ortak'", bgl.baglanti());
                    komutSil.Parameters.AddWithValue("@a1", "Pasif");
                    komutSil.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Silme işlemi gerçekleşmiştir.");
                    listele();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri bulunamadı! " + ex.Message);
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "LOD" || e.Column.FieldName == "Başlangıç" || e.Column.FieldName == "Bitiş"  || e.Column.FieldName == "Geri Kazanım" || e.Column.FieldName == "Belirsizlik" || e.Column.FieldName == "LOQ" || e.Column.FieldName == "Birim" || e.Column.FieldName == "Kalibrasyon")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            ValidasyonEkle.gelis = "güncelle";
            ValidasyonEkle.aID = aID;
            ValidasyonEkle ve = new ValidasyonEkle();
            ve.Show();
        }
    }
}
