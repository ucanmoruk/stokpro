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

namespace mKYS.Musteri
{
    public partial class GorusmeList : Form
    {
        public GorusmeList()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select c.Tarih, k.Ad + ' ' + k.Soyad as 'Plasiyer', c.Firma, c.FirmaAd as 'Firma Adı', c.Yetkili, c.Iletisim, c.Tur as 'Görüşme türü',
	        c.Konu, c.Mesaj,c.Durumu, c.ID from CrmMusteri c 
	        left join  StokKullanici k on c.PlasiyerID = k.ID where c.Durum = 'Aktif'
	        order by c.Tarih desc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

            gridView3.Columns["ID"].Visible = false;

            this.gridView3.Columns[0].Width = 70;
            this.gridView3.Columns[1].Width = 70;
            this.gridView3.Columns[2].Width = 50;
            this.gridView3.Columns[3].Width = 200;
            this.gridView3.Columns[4].Width = 70;
            this.gridView3.Columns[5].Width = 70;
            this.gridView3.Columns[6].Width = 70;
            this.gridView3.Columns[7].Width = 80;
            this.gridView3.Columns[8].Width = 200;
            this.gridView3.Columns[9].Width = 100;

            RepositoryItemMemoEdit memo = new RepositoryItemMemoEdit();
            gridView3.Columns["Mesaj"].ColumnEdit = memo;
            gridView3.Columns["Mesaj"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

        }

        private void gridView3_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }
        }

        private void GorusmeList_Load(object sender, EventArgs e)
        {
           listele();
        }

        string gID, plasiyer;
        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            gID = dr["ID"].ToString();
            plasiyer = dr["Plasiyer"].ToString();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (plasiyer == Anasayfa.tamad)
            {
                GorusmeEkle.gID = gID;
                GorusmeEkle ge = new GorusmeEkle();
                ge.Show();
            }
            else
            {
                MessageBox.Show("Sadece kendi görüşmelerinizi güncelleyebilirsiniz!", "Ooppss!", MessageBoxButtons.OK , MessageBoxIcon.Exclamation);
            }


        }
    }
}
