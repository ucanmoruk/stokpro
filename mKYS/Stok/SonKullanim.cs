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
using mKYS.Stok;

namespace mKYS
{
    public partial class SonKullanim : Form
    {
        public SonKullanim()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select distinct l.Tur as 'Tür', l.Kod, l.Ad, l.Cas, l.Ambalaj, h.Marka, h.Lot, h.SKT, b.Birim, h.ID from StokHareket h " +
                " left join StokListesi l on h.StokID = l.ID left join StokFirmaBirim b on h.BirimID = b.ID where h.Hareket = N'Giriş' and YEAR(h.SKT) > 2020 order by h.SKT asc", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;
            gridView1.Columns["ID"].Visible = false;

        }

        private void SonKullanim_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //güncelle
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            //if (e.HitInfo.InRow)
            //{
            //    var p2 = MousePosition;
            //    popupMenu1.ShowPopup(p2);
            //}
        }

        string kod, ID;
        DateTime tarih;
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                kod = dr["Kod"].ToString();
                ID = dr["ID"].ToString();
                tarih = Convert.ToDateTime(dr["SKT"].ToString());

                SKTGuncelle.kod = kod;
                SKTGuncelle.tarih = tarih;
                SKTGuncelle.ID = ID;
                SKTGuncelle sd = new SKTGuncelle();
                sd.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata 1: " + ex);
            }
        }
    }
}
