using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mKYS.Musteri;

namespace mKYS.Musteri
{
    public partial class Faturax : Form
    {
        public Faturax()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();

        public static string yil;
        int ayi;
        public void listele()
        {
            DataTable dt = new DataTable();
            //// SqlDataAdapter da = new SqlDataAdapter("select Fatura_No as 'Fatura No', Tutar, KDV, Toplam, Durumu from Fatura", bgl.baglanti());
            ////SqlDataAdapter da = new SqlDataAdapter("select f.ID as 'No',  f.Fatura_No as 'Fatura No', y.Rapor_No as 'Rapor No', k.Firma_Adi, f.Tutar, f.KDV, f.Toplam, f.Durumu from Fatura f inner join NKR y on f.Rapor_Id = y.ID inner join Firma k on k.ID = y.Firma_ID ", bgl.baglanti());
            //SqlDataAdapter da = new SqlDataAdapter("select DISTINCT f.Fatura_No as 'Fatura No' , f.Tarih, n.Evrak_No as 'Evrak No' , n.Grup, a.Firma_Adi as 'Faturalandırılacak Firma', c.Firma_Adi as 'Proje', " +
            //"b.Firma_Adi as 'Raporlandırılacak Firma' ,f.Tutar, f.KDV, f.Toplam, f.Aciklama as 'Açıklama', o.Odeme_Durumu as 'Ödeme Durumu', f.ID as 'ID' from Fatura f " +
            //"inner join Odeme o on o.Fatura_ID= f.ID inner join Proje p on p.ID = f.Proje_ID inner join NKR n on n.Evrak_No=o.Evrak_No " +
            //"inner join Firma a on a.ID = f.FaturaFirmaID inner join Firma b on b.ID = f.RaporFirmaID inner join NumuneDetay nd on nd.RaporID = n.ID inner join Firma c on c.ID = nd.ProjeID " +
            //"where year(f.Tarih) = N'" + combo_year.Text + "' and month(f.Tarih) = N'" + ayi + "' and f.Durum='Aktif'", bgl.baglanti());
            //SqlDataAdapter da = new SqlDataAdapter("select DISTINCT f.Fatura_No  as 'Fatura No', f.Tarih, o.Evrak_No  as 'Evrak No', n.Grup, n.Tur, a.Firma_Adi as 'Faturalandırılacak Firma', b.Firma_Adi as 'Proje', c.Firma_Adi  as 'Raporlandırılacak Firma',  " +
            //   " f.Tutar, f.KDV, f.Toplam, f.Aciklama as 'Açıklama', o.Odeme_Durumu as 'Ödeme Durumu', f.ID as 'ID' from Fatura f  " +
            //   " inner join Odeme o on o.Fatura_ID =f.ID inner join Firma a on a.ID = f.FaturaFirmaID " +
            //   " inner join Firma b on b.ID = f.Proje_ID inner join Firma c on c.ID = f.RaporFirmaID inner join NKR n on n.Evrak_No = o.Evrak_No " +
            //   "where year(f.Tarih) = N'" + combo_year.Text + "' and month(f.Tarih) = N'" + ayi + "' and f.Durum='Aktif'", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(@"select DISTINCT f.Fatura_No  as 'Fatura No', f.Tarih, o.Evrak_No  as 'Evrak No', n.Grup, a.Firma_Adi as 'Faturalandırılacak Firma', b.Firma_Adi as 'Proje', c.Firma_Adi  as 'Raporlandırılacak Firma',  
            f.Tutar, f.KDV, f.Toplam, f.Aciklama as 'Açıklama', o.Odeme_Durumu as 'Ödeme Durumu', f.ID as 'ID' from Fatura f  
            inner join Odeme o on o.Fatura_ID =f.ID inner join Firma a on a.ID = f.FaturaFirmaID 
            inner join Firma b on b.ID = f.Proje_ID inner join Firma c on c.ID = f.RaporFirmaID inner join NKR n on n.Evrak_No = o.Evrak_No 
           where year(f.Tarih) = N'" + combo_year.Text + "' and month(f.Tarih) = N'" + ayi + "' and f.Durum='Aktif'", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();

            gridView1.Columns["ID"].Visible = false;

        }


        private void Fatura_Load(object sender, EventArgs e)
        {
            listele();

            combo_ay.Text = DateTime.Now.ToString("MMMM");
            if (combo_ay.Text == "Ocak")
                ayi = 1;
            else if (combo_ay.Text == "Şubat")
                ayi = 2;
            else if (combo_ay.Text == "Şubat")
                ayi = 2;
            else if (combo_ay.Text == "Mart")
                ayi = 3;
            else if (combo_ay.Text == "Nisan")
                ayi = 4;
            else if (combo_ay.Text == "Mayıs")
                ayi = 5;
            else if (combo_ay.Text == "Haziran")
                ayi = 6;
            else if (combo_ay.Text == "Temmuz")
                ayi = 7;
            else if (combo_ay.Text == "Ağustos")
                ayi = 8;
            else if (combo_ay.Text == "Eylül")
                ayi = 9;
            else if (combo_ay.Text == "Ekim")
                ayi = 10;
            else if (combo_ay.Text == "Kasım")
                ayi = 11;
            else if (combo_ay.Text == "Aralık")
                ayi = 12;


            this.gridView1.Columns[0].Width = 70;
            this.gridView1.Columns[1].Width = 70;
            this.gridView1.Columns[2].Width = 70;
            this.gridView1.Columns[3].Width = 70;
            this.gridView1.Columns[4].Width = 200;
            this.gridView1.Columns[5].Width = 70;
            this.gridView1.Columns[8].Width = 70;
            this.gridView1.Columns[9].Width = 70;


            GridGroupSummaryItem item = new GridGroupSummaryItem();
            item.FieldName = "Toplam";
            item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            item.DisplayFormat = "/ Toplam = {0:c2}";
            gridView1.GroupSummary.Add(item);

            GridColumnSummaryItem item2 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Toplam", "{0}");
            gridView1.Columns["Toplam"].Summary.Add(item2);
           
           GridColumnSummaryItem item1 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, " Fatura No", "Adet={0}");
            gridView1.Columns["Fatura No"].Summary.Add(item1);

        }


        FaturaGuncelle fg;
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
                fg = new FaturaGuncelle();              
                fg.Show();  
                
        }
        FaturaOdeme fo;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FaturaOdeme.fID = fID;
                fo = new FaturaOdeme();
                fo.Show();          
        }
        public static string faturaNo, tutar, kdv, toplam, aciklama, bakiye, durum, odenen, raporId, ftarih, fproje, ffaturafirma, fraporfirma, odemed;

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void combo_ay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_ay.Text == "Ocak")
                ayi = 1;
            else if (combo_ay.Text == "Şubat")
                ayi = 2;
            else if (combo_ay.Text == "Şubat")
                ayi = 2;
            else if (combo_ay.Text == "Mart")
                ayi = 3;
            else if (combo_ay.Text == "Nisan")
                ayi = 4;
            else if (combo_ay.Text == "Mayıs")
                ayi = 5;
            else if (combo_ay.Text == "Haziran")
                ayi = 6;
            else if (combo_ay.Text == "Temmuz")
                ayi = 7;
            else if (combo_ay.Text == "Ağustos")
                ayi = 8;
            else if (combo_ay.Text == "Eylül")
                ayi = 9;
            else if (combo_ay.Text == "Ekim")
                ayi = 10;
            else if (combo_ay.Text == "Kasım")
                ayi = 11;
            else if (combo_ay.Text == "Aralık")
                ayi = 12;
            listele();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //// SqlDataAdapter da = new SqlDataAdapter("select Fatura_No as 'Fatura No', Tutar, KDV, Toplam, Durumu from Fatura", bgl.baglanti());
            ////SqlDataAdapter da = new SqlDataAdapter("select f.ID as 'No',  f.Fatura_No as 'Fatura No', y.Rapor_No as 'Rapor No', k.Firma_Adi, f.Tutar, f.KDV, f.Toplam, f.Durumu from Fatura f inner join NKR y on f.Rapor_Id = y.ID inner join Firma k on k.ID = y.Firma_ID ", bgl.baglanti());
            ////SqlDataAdapter da = new SqlDataAdapter("select DISTINCT f.Fatura_No as 'Fatura No' , f.Tarih, n.Evrak_No as 'Evrak No' , n.Grup, a.Firma_Adi as 'Faturalandırılacak Firma', p.Proje, " +
            //    "b.Firma_Adi as 'Raporlandırılacak Firma' ,f.Tutar, f.KDV, f.Toplam, f.Aciklama as 'Açıklama', o.Odeme_Durumu as 'Ödeme Durumu' from Fatura f " +
            //    "inner join Odeme o on o.Fatura_ID= f.ID inner join Proje p on p.ID = f.Proje_ID inner join NKR n on n.Evrak_No=o.Evrak_No " +
            //    "inner join Firma a on a.ID = f.FaturaFirmaID inner join Firma b on b.ID = f.RaporFirmaID " +
            //    "where year(f.Tarih) = N'" + combo_year.Text + "' and f.Durum='Aktif'", bgl.baglanti());
            //SqlDataAdapter da = new SqlDataAdapter("select DISTINCT f.Fatura_No  as 'Fatura No', f.Tarih, o.Evrak_No  as 'Evrak No', n.Grup, n.Tur, a.Firma_Adi as 'Faturalandırılacak Firma', b.Firma_Adi as 'Proje', c.Firma_Adi  as 'Raporlandırılacak Firma',  " +
            //" f.Tutar, f.KDV, f.Toplam, f.Aciklama as 'Açıklama', o.Odeme_Durumu as 'Ödeme Durumu', f.ID as 'ID' from Fatura f  " +
            //" inner join Odeme o on o.Fatura_ID =f.ID inner join Firma a on a.ID = f.FaturaFirmaID " +
            //" inner join Firma b on b.ID = f.Proje_ID inner join Firma c on c.ID = f.RaporFirmaID inner join NKR n on n.Evrak_No = o.Evrak_No " +
            //"where year(f.Tarih) = N'" + combo_year.Text + "' and f.Durum='Aktif'", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(@"select DISTINCT f.Fatura_No  as 'Fatura No', f.Tarih, o.Evrak_No  as 'Evrak No', n.Grup, a.Firma_Adi as 'Faturalandırılacak Firma', b.Firma_Adi as 'Proje', c.Firma_Adi  as 'Raporlandırılacak Firma', 
            f.Tutar, f.KDV, f.Toplam, f.Aciklama as 'Açıklama', o.Odeme_Durumu as 'Ödeme Durumu', f.ID as 'ID' from Fatura f 
            inner join Odeme o on o.Fatura_ID =f.ID inner join Firma a on a.ID = f.FaturaFirmaID
            inner join Firma b on b.ID = f.Proje_ID inner join Firma c on c.ID = f.RaporFirmaID inner join NKR n on n.Evrak_No = o.Evrak_No
            where year(f.Tarih) = N'" + combo_year.Text + "' and f.Durum='Aktif'", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();

            gridView1.Columns["ID"].Visible = false;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            string path = "output.xlsx";
            gridControl1.ExportToXlsx(path);
            Process.Start(path);
            

 
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {

                string Kategori = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Ödeme Durumu"]);
                if (Kategori == "Ödendi")
                {
                    e.Appearance.BackColor = Color.LightGreen;
                    e.Appearance.BackColor2 = Color.LightGreen;
                    e.HighPriority = true;

                }
            }
        }

        private void Fatura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                listele();
            }
            if (e.Control == true && e.KeyCode == Keys.Y)
            {
                YeniFatura yf = new YeniFatura();
                yf.Show();
            }
            if (e.Control == true && e.KeyCode == Keys.O)
            {
                FaturaOdeme f3 = new FaturaOdeme();
                f3.Show();
            }
            if (e.Control == true && e.KeyCode == Keys.G)
            {
                FaturaGuncelle fg = new FaturaGuncelle();
                fg.Show();
            }
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

            if (e.Column.FieldName == "Fatura No" || e.Column.FieldName == "Tarih" || e.Column.FieldName == "Evrak No" || e.Column.FieldName == "Tutar" || e.Column.FieldName == "KDV" || e.Column.FieldName == "Toplam" || e.Column.FieldName == "Ödeme Durumu")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            string adam = gridView1.GetRowCellValue(e.RowHandle, "Ödeme Durumu").ToString();
            if (e.RowHandle > -1 && e.Column.FieldName == "Ödeme Durumu" && adam == "Ödendi")
                e.Appearance.BackColor = Color.Green;
        }

        public static int raporNO;
        int faturaid, fID;
     
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show("Silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Secim == DialogResult.Yes)
                {
                    // SqlCommand komutSil = new SqlCommand("delete from Firma where ID = @p1", bgl.baglanti());
                    SqlCommand komutSil = new SqlCommand("update Fatura set Durum=@a1 where ID = @p1; update Odeme set Odeme_Durumu=@a2 where Fatura_ID=@p1", bgl.baglanti());
                    komutSil.Parameters.AddWithValue("@p1", fID);
                    komutSil.Parameters.AddWithValue("@a1", "Pasif");
                    komutSil.Parameters.AddWithValue("@a2", "İptal");
                    komutSil.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    listele();
                    MessageBox.Show("Silme işlemi gerçekleşmiştir.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }
        }

        private void combo_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            listele();
            yil = combo_year.Text;
        }

        

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        //public static int top = 0, ode = 0, bak = 0;

        //void bakiyebul()
        //{
        //    SqlCommand komutID = new SqlCommand("Select Odenen_Tutar, Toplam From Fatura where Fatura_No='" + faturaNo + "'", bgl.baglanti());
        //    SqlDataReader drI = komutID.ExecuteReader();
        //    while (drI.Read())
        //    {
        //        // top= Convert.ToInt32(drI["Toplam"].ToString());
        //        ode = Convert.ToInt32(drI["Odenen_tutar"]);
        //        top = Convert.ToInt32(drI["Toplam"]);
        //        // ode = Convert.ToInt32(drI["Odenen_tutar"].ToString());

        //    }
        //    bgl.baglanti().Close();
        //    //bak = Convert.ToInt32();
        //    //bak2 = Convert.ToInt32();
        //}
        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                faturaNo = dr["Fatura No"].ToString();
                tutar = dr["Tutar"].ToString();
                kdv = dr["KDV"].ToString();
                toplam = dr["Toplam"].ToString();
                //durum = dr["Durumu"].ToString();
                raporNO = Convert.ToInt32(dr["Evrak No"].ToString());
                ftarih = dr["Tarih"].ToString();
                fproje = dr["Proje"].ToString();
                ffaturafirma = dr["Faturalandırılacak Firma"].ToString();
                fraporfirma = dr["Raporlandırılacak Firma"].ToString();
                odemed = dr["Ödeme Durumu"].ToString();
                aciklama = dr["Açıklama"].ToString();
                fID = Convert.ToInt32(dr["ID"].ToString());

                SqlCommand komutID = new SqlCommand("Select ID From Fatura where Fatura_No= N'" + faturaNo + "'", bgl.baglanti());
                SqlDataReader drI = komutID.ExecuteReader();
                while (drI.Read())
                {
                    faturaid = Convert.ToInt32(drI["ID"].ToString());
                }
                bgl.baglanti().Close();

                // bakiye = Convert.ToString(Convert.ToInt32(toplam)-odenen);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }

            
        }

        private void gridView1_PopupMenuShowing_1(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }


        }

        YeniFatura yeniFatura;
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            yeniFatura = new YeniFatura();
            yeniFatura.Show();
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
  
                //if (e.Column.Caption == "No")
                //    e.DisplayText = (e.ListSourceRowIndex + 1).ToString();
            
        }


    }
}
