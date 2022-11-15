using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using mKYS;
using DevExpress.XtraGrid;

namespace mKYS.Musteri
{
    public partial class Limit : Form
    {
        public Limit()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();


        public void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select  x.ID as 'No', x.Tarih, k.Ad as 'Plasiyer' , x.Aciklama as 'Açıklama' from NumuneX3 x
            left join StokKullanici k on x.KID = k.ID where x.Durum = 'Aktif' order by x.ID desc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void Teklif_Load(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = true;
            listele();

            this.gridView1.Columns[0].Width = 40;
            this.gridView1.Columns[1].Width = 50;
            this.gridView1.Columns[2].Width = 75;
            this.gridView1.Columns[3].Width = 260;
        }

        //private void simpleButton1_Click(object sender, EventArgs e)
        //{
        //    //TeklifDetay.gelis = "update";
        //    //TeklifDetay n = new TeklifDetay();
        //    //n.Show();
        //}

        private void groupControl2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            splitContainer1.Panel2Collapsed = true;
        }

        public static string paket, kullanici, girisk, tID;
        public static int teklifno;
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {

            splitContainer1.Panel2Collapsed = false;

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            kullanici = dr["Plasiyer"].ToString();
            tID = dr["No"].ToString();

            gridControl2.DataSource = null;
            gridView2.Columns.Clear();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select k.Ad, k.Method, a.Aciklama, x.Limit, x.Birim from Numunex4 x 
                left join StokAnalizDetay a on x.AltAnalizID = a.ID
                left join StokAnalizListesi k on a.AnalizID = k.ID
                where x.x3ID = '" + tID + "' order by k.Ad ", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult Secim = new DialogResult();

            Secim = MessageBox.Show("Seçili limitleri iptal etmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Secim == DialogResult.Yes)
            {
                girisk = mKYS.Anasayfa.ad.ToString();

                if (kullanici == girisk)
                {
                    SqlCommand komutz = new SqlCommand("update NumuneX3 set Durum = @o1 where ID = @o2 ", bgl.baglanti());
                    komutz.Parameters.AddWithValue("@o1", "Pasif");
                    komutz.Parameters.AddWithValue("@o2", tID);
                    komutz.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    MessageBox.Show("İstediğin oldu! Limit iptal edildi.");

                    splitContainer1.Panel2Collapsed = true;

                }
                else
                {
                    MessageBox.Show("Limitleri sadece oluşturan iptal edebilir!");
                }
            }
            else
            {
                
            }




               
        }


        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //print
        }

        Limitv2 fr6;
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6 == null || fr6.IsDisposed)
            {
                fr6 = new Limitv2();
                fr6.MdiParent = Application.OpenForms.OfType<Anasayfa>().FirstOrDefault();
                fr6.Show();
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

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Limitv2 n = new Limitv2();
            n.Show();


        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
                if (e.Column.FieldName == "Tarih" || e.Column.FieldName == "No" )
                    e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            girisk = Giris.ad.ToString();

            if (kullanici == girisk)
            {

                Limitv2.tID = tID;
                if (fr6 == null || fr6.IsDisposed)
                {
                    fr6 = new Limitv2();
                    fr6.MdiParent = Application.OpenForms.OfType<Anasayfa>().FirstOrDefault();
                    fr6.Show();
                }

            }
            else
            {
                MessageBox.Show("Limitleri sadece oluşturan güncelleyebilir!");
            }





        }
    }
}
