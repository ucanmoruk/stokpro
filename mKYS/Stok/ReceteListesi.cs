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

namespace mKYS.Stok
{
    public partial class ReceteListesi : Form
    {
        public ReceteListesi()
        {
            InitializeComponent();
        }


        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {
            DataTable dt2 = new DataTable();
            //SqlDataAdapter da2 = new SqlDataAdapter("select distinct a.ID, r.AnalizKod as 'Kod', a.Ad, a.Metot from StokRecete r inner join StokAnalizListesi a on r.AnalizKod = a.Kod ", bgl.baglanti());
            SqlDataAdapter da2 = new SqlDataAdapter("select distinct a.ID, a.Kod, a.Ad, d.Kod + ' '+ d.Ad as 'Metot' from StokRecete r inner join StokAnalizListesi a on r.AnalizID = a.ID inner join StokDKDListe d on a.Metot = d.ID", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;
            gridView1.Columns["ID"].Visible = false;

            this.gridView1.Columns[1].Width = 50;
            this.gridView1.Columns[2].Width = 120;
            this.gridView1.Columns[3].Width = 200;
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
                barButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                barButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }

        }

        private void ReceteListesi_Load(object sender, EventArgs e)
        {
            listele();
            yetkibul();
        }

        private void ReceteListesi_KeyDown(object sender, KeyEventArgs e)
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

        string skod, sad, aID;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //skod = dr["Kod"].ToString();
            //sad = dr["Ad"].ToString();
            aID = dr["ID"].ToString();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Stok.ReceteDetay.aID = aID;
            Stok.ReceteDetay rd = new Stok.ReceteDetay();
            rd.Show();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show(skod + " kodlu reçeteyi silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Secim == DialogResult.Yes)
                {
                    SqlCommand komutSil = new SqlCommand("delete from StokRecete where AnalizKod = N'" + skod + "'", bgl.baglanti());
                    komutSil.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Silme işlemi gerçekleşmiştir.");
                    listele();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata 11003 : " + ex.Message);
            }
        }
    }
}
