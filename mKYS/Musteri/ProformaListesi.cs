using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using mKYS;
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
    public partial class ProformaListesi : Form
    {
        public ProformaListesi()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();


        public void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select distinct p.ID as No, k.Ad as 'Olusturan', p.OlusturmaTarih as 'Oluşturma', o.Ad as 'Onaylayan', 
            p.Tarih as 'Onaylama', p.Durum, p.ProformaNo as 'Proforma No', 
              z.Firma_Adi as 'Firma Adı', p.Dipnot, p.Total from ProformaDurum p
            left join StokKullanici k on k.ID = p.OlusturanID 
            left join StokKullanici o on p.OnaylayanID = o.ID
            left join firma z on z.ID = p.FirmaID 
            order by p.ID desc 
             ", bgl.baglanti());

            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();
        }

        private void ProformaListesi_Load(object sender, EventArgs e)
        {
            listele();

            this.gridView1.Columns[0].Width = 30;
            this.gridView1.Columns[1].Width = 55;
            this.gridView1.Columns[2].Width = 55;
            this.gridView1.Columns[3].Width = 55;
            this.gridView1.Columns[4].Width = 55;
            this.gridView1.Columns[5].Width = 75;
            this.gridView1.Columns[6].Width = 75;
            this.gridView1.Columns[7].Width = 200;
            this.gridView1.Columns[8].Width = 150;
            this.gridView1.Columns[9].Width = 55;

        }


        public static string girisk, kullanici, kgorev, durumo;

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ProformaUpdate pu = new ProformaUpdate();
            pu.Show();

            //girisk = MAYS.Kullanici.ad.ToString();
            //kgorev = MAYS.Kullanici.gorev.ToString();

            //DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            //durumo = dr["Durum"].ToString();

            //if (durumo == "Onaylandı" || durumo == "Faturalandırıldı" || durumo == "Reddedildi")
            //{
            //    string newLine = Environment.NewLine;
            //    MessageBox.Show("Sonuçlanan proformaları sadece önizleme yapabilir ve faturalandırabilirsiniz." + newLine + "Üzgünüm acı sözlerim için..");
            //    ProformaUpdate p = new ProformaUpdate();
            //    p.yazdir();          

            //}
            //else
            //{
            //    if (kullanici == girisk || kgorev == "Muhasebe")
            //    {
            //        ProformaUpdate pu = new ProformaUpdate();
            //        pu.Show();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Sadece ilgili plasiyer değerlendirme yapabilir!");
            //    }
            //}


        }

        private void btn_update_Click(object sender, EventArgs e)
        {
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

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "No" || e.Column.FieldName == "Son İşlem" || e.Column.FieldName == "Proforma No" || e.Column.FieldName == "Total" || e.Column.FieldName == "Durum" || e.Column.FieldName == "Oluşturma" || e.Column.FieldName == "Onaylama")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
              
        }

        private void ProformaListesi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                listele();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            string adam = gridView1.GetRowCellValue(e.RowHandle, "Durum").ToString();
            if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && adam == "Onay Bekleniyor")
                e.Appearance.BackColor = Color.PaleTurquoise;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && adam == "Onaylandı")
                e.Appearance.BackColor = Color.PaleGreen;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && adam == "Reddedildi")
                e.Appearance.BackColor = Color.OrangeRed;
            else if (e.RowHandle > -1 && e.Column.FieldName == "Durum" && adam == "Faturalandırıldı")
                e.Appearance.BackColor = Color.MediumVioletRed;

            //Toplam sütununu değerine göre grid renklendiriyor

            //string total= gridView1.GetRowCellValue(e.RowHandle, "Total").ToString();
            //GridFormatRule gridFormatRule = new GridFormatRule();
            //FormatConditionRule3ColorScale formatConditionRule3ColorScale = new FormatConditionRule3ColorScale();
            //gridFormatRule.Column = gridView1.Columns["Total"];
            //formatConditionRule3ColorScale.PredefinedName = "Green, White, Red";
            //gridFormatRule.Rule = formatConditionRule3ColorScale;
            //gridView1.FormatRules.Add(gridFormatRule);



        }

        public static int profno, profid;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                profno = Convert.ToInt32(dr["Proforma No"].ToString());
                kullanici = dr["Olusturan"].ToString();
                profid = Convert.ToInt32(dr["No"].ToString());
            }
            catch (Exception)
            {

                throw;
            }

  
        }



















    }




    
}
