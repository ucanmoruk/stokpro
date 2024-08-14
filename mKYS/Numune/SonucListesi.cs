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

namespace mKYS.Numune
{
    public partial class SonucListesi : Form
    {
        public SonucListesi()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {
           DataTable dt = new DataTable();

            //SqlDataAdapter da = new SqlDataAdapter(@" select t.ID as 'ID', n.RaporNo as 'RaporNo', '(' + x.Kod + ') ' + x.Aciklama as 'Açıklama', 
            //d.Kod + ' - ' + d.Ad + ' - ' + d.Method as 'Analiz', t.Tartim as 'Tartım', t.Birim, y.Aciklama
            //, a.Sonuc, a.Birim, a.Limit, a.Degerlendirme from Numune_Tartim t
            //left join NumuneX2 x on t.MixID = x.ID
            //left join StokAnalizListesi d on x.AnalizID = d.ID
            //left join StokKullanici k on t.PersonelID = k.ID
            //left join NKR n on x.RaporID = n.ID
            //left join NumuneX5 a on x.ID = a.x2ID
            //left join StokAnalizDetay y on a.AltAnalizID = y.ID
            //where x.RaporID = '" + raporID+"' order by x.AnalizID desc", bgl.baglanti());
            //da.Fill(dt);
            //gridControl1.DataSource = dt;
            //gridView1.Columns["ID"].Visible = false;
            //gridView1.Columns["RaporNo"].Visible = false;



            SqlDataAdapter da = new SqlDataAdapter(@" select n.ID, n.RaporNo as 'RaporNo', '(' + x.Kod + ') ' + x.Aciklama as 'Açıklama', 
			d.Kod + ' - ' + d.Ad + ' - ' + d.Method as 'Analiz', y.Aciklama,
			a.Sonuc, a.Birim, a.Limit, a.Degerlendirme ,  a.Durum, a.ID as 'x5ID'
			from NKR n 
			left join NumuneX2 x on n.ID = x.RaporID
			left join StokAnalizListesi d on x.AnalizID = d.ID
			left join NumuneX5 a on x.ID = a.x2ID
			left join StokAnalizDetay y on a.AltAnalizID = y.ID
			where n.ID = '" + raporID + "' order by x.AnalizID  desc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.Columns["ID"].Visible = false;
            gridView1.Columns["RaporNo"].Visible = false;
            gridView1.Columns["x5ID"].Visible = false;
            gridView1.Columns["Açıklama"].Visible = false;


            //  this.gridView1.Columns[1].Width = 50;
           // this.gridView1.Columns[2].Width = 90;
            this.gridView1.Columns[3].Width = 140;
            this.gridView1.Columns[4].Width = 70;
            this.gridView1.Columns[5].Width = 70;
            this.gridView1.Columns[6].Width = 70;
            this.gridView1.Columns[7].Width = 80;
            this.gridView1.Columns[8].Width = 70;
            this.gridView1.Columns[9].Width = 90;
        }

        public static string raporID, raporNo, x5ID, limit, birim, sonuc, degerlendirme;
        int kontrolet;

        private void durumekle()
        {
            DateTime tarih = DateTime.Now;
            SqlCommand add = new SqlCommand("insert into NumuneDurum (RaporNo, Durum, Kim) values (@o1, @o3,@o4) ; " +
                " insert into NumuneTeslim (RaporNo,Tarih, Durum, Kim) values (@o1, @o2, @o3,@o4)", bgl.baglanti());
            add.Parameters.AddWithValue("@o1", raporNo);
            add.Parameters.AddWithValue("@o2", tarih);
            add.Parameters.AddWithValue("@o3", "Analiz Sonuçları Girildi!");
            add.Parameters.AddWithValue("@o4", Giris.kullaniciID);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        void kontrol()
        {
            SqlCommand komut = new SqlCommand(@"select Count(ID) from Numunex5 where X2ID in (select ID from NumuneX2 where RaporID = '" + raporID + "') and Durum = 'Analizde'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                kontrolet = Convert.ToInt32(dr[0].ToString());
            }
            dr.Close();
            bgl.baglanti().Close();
        }

        string analiz;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //kaydet

            for (int i = 0; i <= gridView1.RowCount - 1; i++)
            //for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                {
                x5ID = gridView1.GetRowCellValue(i, "x5ID").ToString();
                limit = gridView1.GetRowCellValue(i, "Limit").ToString();
                birim = gridView1.GetRowCellValue(i, "Birim").ToString();
                sonuc = gridView1.GetRowCellValue(i, "Sonuc").ToString();
                analiz = gridView1.GetRowCellValue(i, "Analiz").ToString();
                degerlendirme = gridView1.GetRowCellValue(i, "Degerlendirme").ToString();

               
                SqlCommand add = new SqlCommand("update NumuneX5 set Limit=@o1 , Birim =@o2, Sonuc=@o3, Degerlendirme=@o4, Durum=@o5 where ID = '"+x5ID+"' ", bgl.baglanti()) { CommandTimeout = 0 };
                add.Parameters.AddWithValue("@o1", limit);
                add.Parameters.AddWithValue("@o2", birim);
                add.Parameters.AddWithValue("@o3", sonuc);
                add.Parameters.AddWithValue("@o4", degerlendirme);
                add.Parameters.AddWithValue("@o5", "Sonuç Girildi");
                add.ExecuteNonQuery();
                bgl.baglanti().Close();

                string analizdurum = analiz + " sonucu girildi.";
                DateTime tarih = DateTime.Now;
                SqlCommand add2 = new SqlCommand("insert into NumuneTeslim (RaporNo,Tarih, Durum, Kim) values (@o1, @o2, @o3,@o4)", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", raporNo);
                add2.Parameters.AddWithValue("@o2", tarih);
                add2.Parameters.AddWithValue("@o3", analizdurum);
                add2.Parameters.AddWithValue("@o4", Giris.kullaniciID);
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();

            }

            MessageBox.Show("Kaydetme Başarılı");

            //kontrol();
            //if (kontrolet == 0)
            //{
            //    durumekle();
            //}
            //else
            //{

            //}
            

            listele();
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }
        }

        private void SonucListesi_Load(object sender, EventArgs e)
        {
            listele();
            Text = raporNo + " Analiz Listesi";
        }
    }
}
