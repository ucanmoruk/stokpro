using DevExpress.XtraGrid.Columns;
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
using System.Globalization;

namespace mKYS.Numune
{
    public partial class TanimDetay : Form
    {
        public TanimDetay()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter("select ROW_NUMBER() OVER(ORDER BY RaporID) as No, Grup=@a1, Tanim as 'Tanımlama' where RaporNo = '" + txt_raporno.Text + "'", bgl.baglanti());
            //da.SelectCommand.Parameters.AddWithValue("@a1", "A");
          //  SqlDataAdapter da = new SqlDataAdapter("select No, Grup, Tanim as 'Tanımlama', Ortak as 'Ortak Parça' from Tanimlama where RaporNo = '" + txt_raporno.Text + "' order by No asc", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter("select No, Grup, Tanim as 'Tanımlama', Ortak as 'Ortak Parça', EkNot from Tanimlama where RaporID = '" + raporID + "' order by No asc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();
        }

        int tanimsayi;
        void bul()
        {
            //SqlCommand komut2 = new SqlCommand("select count(Tanim) from Tanimlama where RaporNo = N'" + txt_raporno.Text + "'", bgl.baglanti());
            SqlCommand komut2 = new SqlCommand("select count(Tanim) from Tanimlama where RaporID = N'" + raporID + "'", bgl.baglanti());
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                tanimsayi = Convert.ToInt32(dr[0].ToString());
            }
            bgl.baglanti().Close();

        }



        public static string raporID, raporno;
        private void TanimDetay_Load(object sender, EventArgs e)
        {
            if (raporno == "" || raporno == null)
            {                
                txt_raporno.Text = TanimlamaListesi.raporno;
            }
            else
            {
                txt_raporno.Text = raporno;
            }
                   
            listele();
            bul();


            this.gridView1.Columns[0].Width = 30;
            this.gridView1.Columns[1].Width = 30;
            this.gridView1.Columns[2].Width = 235;
            this.gridView1.Columns[4].Width = 50;


        }

        void yenikayit()
        {
                DateTime tarih = DateTime.Now;

                for (int ik = 0; ik <= gridView1.RowCount-2; ik++)
                {
                string grup, grup2;
                grup = gridView1.GetRowCellValue(ik, "Grup").ToString();
                if (grup == "" || grup == null)
                    grup2 = "A";
                else
                    grup2 = grup;

                
                SqlCommand komutz = new SqlCommand("insert into Tanimlama (Grup, Tanim, RaporNo, No, Ortak, RaporID, Tarih, KID, Durumu, EkNot) values (@o1,@o2,@o3,@o4,@o5, @o6, @o7, @o8, @o9, @o10);" +
                " update NKR set Rapor_Durumu=@a1 where ID = N'" + raporID + "' ; " +
                " update Rapor_Durum set Durum=@a1, Tarih=@a2, TanimlayanID=@a3 where RaporID = N'" + raporID + "' ", bgl.baglanti());
                komutz.Parameters.AddWithValue("@o1", grup2.ToUpper());
                komutz.Parameters.AddWithValue("@o2", gridView1.GetRowCellValue(ik, "Tanımlama").ToString());
                komutz.Parameters.AddWithValue("@o3", txt_raporno.Text);
                komutz.Parameters.AddWithValue("@o4", ik+1);
                komutz.Parameters.AddWithValue("@o5", gridView1.GetRowCellValue(ik, "Ortak Parça").ToString().ToUpper());
                komutz.Parameters.AddWithValue("@o6", raporID);
                komutz.Parameters.AddWithValue("@o7", tarih);
                komutz.Parameters.AddWithValue("@o8", Giris.kullaniciID);
                komutz.Parameters.AddWithValue("@o9", "Aktif");
                komutz.Parameters.AddWithValue("@o10", gridView1.GetRowCellValue(ik, "EkNot").ToString());
                komutz.Parameters.AddWithValue("@a1", "Tanımlandı");
                komutz.Parameters.AddWithValue("@a2", tarih);
                komutz.Parameters.AddWithValue("@a3", Giris.kullaniciID);
                komutz.ExecuteNonQuery();
                bgl.baglanti().Close();
            }

            numunetakip();

            //DialogResult cikis = new DialogResult();
            //cikis = MessageBox.Show("Kompozit yapmak ister misin ?", "Uyarı", MessageBoxButtons.YesNo);
            //if (cikis == DialogResult.Yes)
            //{
            Mix2.raporno = txt_raporno.Text;
                   Mix2.raporID = raporID;
                   Mix2 m = new Mix2();
                   m.ShowDialog();
                  this.Close();
                 //}
                 //else
                 //{
                 // MessageBox.Show("Bu iş burada bitmez.");
                 //}



        }

        void eskisil()
        {
            //SqlCommand komutz = new SqlCommand("delete from Tanimlama where RaporNo =N'" + txt_raporno.Text + "' ", bgl.baglanti());
            SqlCommand komutz = new SqlCommand("delete from Tanimlama where RaporID =N'" + raporID + "' ", bgl.baglanti());
            komutz.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        TanimlamaListesi t = new TanimlamaListesi();

        void numunetakip()
        {
            SqlCommand add = new SqlCommand("update NumuneDurum set Kim = @o1, Durum = @o2 where RaporNo = '" + txt_raporno.Text + "' ", bgl.baglanti());
            add.Parameters.AddWithValue("@o1", Giris.kullaniciID);
            add.Parameters.AddWithValue("@o2", "Teslim Alındı");
            add.ExecuteNonQuery();
            bgl.baglanti().Close();

            DateTime tarih = DateTime.Now;
            SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                "insert into NumuneTeslim (RaporNo, Durum, Tarih, Kim) " +
                "values (@o1,@o2,@o3,@o4); " +
                "COMMIT TRANSACTION", bgl.baglanti());
            add2.Parameters.AddWithValue("@o1", txt_raporno.Text);
            add2.Parameters.AddWithValue("@o2", "Numune teslim alındı");
            add2.Parameters.AddWithValue("@o3", tarih);
            add2.Parameters.AddWithValue("@o4", Giris.kullaniciID);
            add2.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        private void btn_tanimla_Click(object sender, EventArgs e)
        {

            if (tanimsayi == 0)
            {
                yenikayit();
                

            }
            else
            {
                DialogResult cikis = new DialogResult();
                cikis = MessageBox.Show("Bu ürün daha önce tanımlanmış. Güncelleme yapmak istiyor musun ?", "Uyarı", MessageBoxButtons.YesNo);
                if (cikis == DialogResult.Yes)
                {
                    eskisil();
                    yenikayit();
                }
                else
                {
                    MessageBox.Show("Peki iyi günler.");
                }               
            }

            t.listele();
            listele();


        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "No" || e.Column.FieldName == "Grup")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "Tanımlama")
                if (e.Value == null)
                e.DisplayText = "Boş satır";
        
        }

        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "Grup")
            {
                e.DisplayText = e.DisplayText.ToUpper();
            }
            
        }

        private void TanimDetay_FormClosing(object sender, FormClosingEventArgs e)
        {
            raporID = null;
            raporno = null;
        }
    }
}
