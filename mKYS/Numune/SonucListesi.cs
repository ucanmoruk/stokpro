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

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //kaydet

            for (int i = 0; i <= gridView1.RowCount - 1; i++)
            {
                x5ID = gridView1.GetRowCellValue(i, "x5ID").ToString();
                limit = gridView1.GetRowCellValue(i, "Limit").ToString();
                birim = gridView1.GetRowCellValue(i, "Birim").ToString();
                sonuc = gridView1.GetRowCellValue(i, "Sonuc").ToString();
                degerlendirme = gridView1.GetRowCellValue(i, "Degerlendirme").ToString();


                SqlCommand add = new SqlCommand("update NumuneX5 set Limit=@o1 , Birim =@o2, Sonuc=@o3, Degerlendirme=@o4, Durum=@o5 where ID = '"+x5ID+"' ", bgl.baglanti()) { CommandTimeout = 0 };
                add.Parameters.AddWithValue("@o1", limit);
                add.Parameters.AddWithValue("@o2", birim);
                add.Parameters.AddWithValue("@o3", sonuc);
                add.Parameters.AddWithValue("@o4", degerlendirme);
                add.Parameters.AddWithValue("@o5", "Sonuç Girildi");
                add.ExecuteNonQuery();
                bgl.baglanti().Close();
            }

            MessageBox.Show("Kaydetme Başarılı");

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
