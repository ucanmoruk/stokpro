using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Menu;
using mKYS.Musteri;
using mKYS.Numune;
using mKYS.Raporlar;

namespace mKYS.Numune
{
    public partial class HizmetTermin : Form
    {
        public HizmetTermin()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();

        private void button_getir_Click(object sender, EventArgs e)
        {
            NumuneKabul f1 = new NumuneKabul();
            f1.Show();
        }


        public void listele()
        {
            //date_baslangic.EditValue = date_basla.EditValue;
            //date_baslangic.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            //date_baslangic.Properties.Mask.EditMask = "yyyy-MM-dd";
            //date_baslangic.Properties.Mask.UseMaskAsDisplayFormat = true;

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(@"SELECT * FROM VIEW_TERMINTAKIP ORDER BY Termin DESC, nID DESC", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView3.Columns["ID"].Visible = false;
            gridView3.Columns["Firma"].Visible = false;
            gridView3.Columns["Proje"].Visible = false;
            gridView3.Columns["nID"].Visible = false;
            gridView3.Columns["Rapor"].Visible = false;
        }

    
        public static int boold;
        public static string bid;

        void gridduzen()
        {
            this.gridView3.Columns[0].Width = 50;
            this.gridView3.Columns[1].Width = 55;
            this.gridView3.Columns[2].Width = 200;
            this.gridView3.Columns[3].Width = 150;
            this.gridView3.Columns[4].Width = 200; 
            this.gridView3.Columns[5].Width = 100;
            this.gridView3.Columns[6].Width = 60;
            this.gridView3.Columns[7].Width = 60;
            this.gridView3.Columns[8].Width = 60;
            this.gridView3.Columns[9].Width = 60;
            this.gridView3.Columns[10].Width = 60;
            this.gridView3.Columns[11].Width = 60;

        }
        private void NKR_Load(object sender, EventArgs e)
        {         
            listele();
            gridduzen();        

        }


        private void gridView3_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }

        }

        private void gridView3_RowStyle(object sender, RowStyleEventArgs e)
        {
         //  Tüm satırı renklendirmek istediğin zaman kullan
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string ODurum = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Durum"]);
                if (ODurum == "Tamamlandı")
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.BackColor2 = Color.LightGreen;
                    e.HighPriority = true;

                }
                else if (ODurum == "İşleme Alındı")
                {
                    e.Appearance.BackColor = Color.Salmon;
                    e.Appearance.BackColor2 = Color.LightSalmon;
                    e.HighPriority = true;
                }
            }
        }

        private void gridView3_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
           
        }

        private void NKR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {

                listele();
            }

        }
      

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        public static string raporno, raporID, durum, x1ID;
            
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = gridView3.GetDataRow(gridView1.FocusedRowHandle);
                raporno = dr["Rapor No"].ToString();
                raporID = dr["nID"].ToString();
                Numune.TanimDetay.raporID = raporID;
                Numune.TanimDetay td = new Numune.TanimDetay();
                td.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata 5: " + ex);
            }


        }


        private void gridView3_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            
            if (e.Column.FieldName == "Evrak No" || e.Column.FieldName == "Rapor No" || e.Column.FieldName == "Kabul" || e.Column.FieldName == "Termin"  || e.Column.FieldName == "Durum" || e.Column.FieldName =="Rapor" || e.Column.FieldName == "Yetkili")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
          
        }

        private void gridView3_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
                raporno = dr["Rapor No"].ToString();
                raporID = dr["nID"].ToString();
                x1ID = dr["ID"].ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hatasız kul olmaz.." + ex);
            }

        }


        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            Numune.Mix2.raporID = raporID;
            Numune.Mix2.raporno = raporno;
            Numune.Mix2 m = new Numune.Mix2();
            m.Show();
        }

        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // işleme alındı

            //SqlCommand komutSil = new SqlCommand("update NumuneX1 set HizmetDurum=@a1, Yetkili=@a2 where ID = @p1", bgl.baglanti());
            //komutSil.Parameters.AddWithValue("@p1", x1ID);
            //komutSil.Parameters.AddWithValue("@a1", "İşleme Alındı");
            //komutSil.Parameters.AddWithValue("@a2", Giris.kullaniciID);
            //komutSil.ExecuteNonQuery();
            //bgl.baglanti().Close();
            


            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                string o2;
                o2 = gridView3.GetRowCellValue(i, "ID").ToString();
                SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                    "update NumuneX1 set HizmetDurum=@o1, Yetkili=@o2 where ID = @o3; " +
                    "COMMIT TRANSACTION", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", "İşleme Alındı");
                add2.Parameters.AddWithValue("@o2", Giris.kullaniciID);
                add2.Parameters.AddWithValue("@o3", o2);
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }

            listele();

        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // tamamlandı

            //SqlCommand komutSil = new SqlCommand("update NumuneX1 set HizmetDurum=@a1 where ID = @p1", bgl.baglanti());
            //komutSil.Parameters.AddWithValue("@p1", x1ID);
            //komutSil.Parameters.AddWithValue("@a1", "Tamamlandı");
            //komutSil.ExecuteNonQuery();
            //bgl.baglanti().Close();


            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                string o2;
                o2 = gridView3.GetRowCellValue(i, "ID").ToString();
                SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                    "update NumuneX1 set HizmetDurum=@o1 where ID = @o3; " +
                    "COMMIT TRANSACTION", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", "Tamamlandı");
                add2.Parameters.AddWithValue("@o3", o2);
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }



            listele();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
            Numune.SonucListesi.raporID = raporID;
            Numune.SonucListesi.raporNo = raporno;

            Numune.SonucListesi sl = new Numune.SonucListesi();
            sl.Show();

            
        }

        private void BarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TanimDetay.raporno = raporno;
            Numune.TanimDetay.raporID = raporID;
            Numune.TanimDetay td = new Numune.TanimDetay();
            td.Show();
        }

    }
}
