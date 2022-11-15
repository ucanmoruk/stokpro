using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class ManuelProforma : Form
    {
        public ManuelProforma()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listelegrid()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select d.Aciklama as 'Açıklama', d.UrunGrubu as 'Ürün', d.Miktar as 'Adet', d.ParaBirimi, d.BirimFiyat, 
            d.ToplamFiyat as 'Fiyat', d.KDV, d.GenelFiyat as 'Toplam' 
            from FaturaDetay d 
            left join ProformaDurum p on d.ProformaNo = p.ProformaNo
            where d.ProformaNo = N'" + txt_evrak.Text + "' and p.Durum <> 'Reddedildi' ", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();

        }

        private void listele()
        {
            SqlCommand komut4 = new SqlCommand("select Firma_Adi from Firma where ID in (select Firma_ID from NKR where Evrak_No = N'" + txt_evrak.Text + "')", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                txt_firma.Text = dr4["Firma_Adi"].ToString();
                combo_firma.Text = dr4["Firma_Adi"].ToString();
            }
            bgl.baglanti().Close();
        }

        public void Firma()
        {
            SqlCommand komut = new SqlCommand("Select Firma_Adi from Firma where Durum = 'Aktif'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                combo_firma.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        int faturafirmaID;
        public void firmadetay()
        {
            SqlCommand komut = new SqlCommand("Select ID, Adres, Vergi_Dairesi,Vergi_No,Mail from Firma where Firma_Adi = '" + combo_firma.Text + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                faturafirmaID = Convert.ToInt32(dr["ID"].ToString());
                txt_adres.Text = dr["Adres"].ToString();
                txt_vdaire.Text = dr["Vergi_Dairesi"].ToString();
                txt_vergino.Text = dr["Vergi_No"].ToString();
                txt_mail.Text = dr["Mail"].ToString();
            }
            bgl.baglanti().Close();
        }


        public static string evrakno, raporno;

        private void combo_firma_SelectedIndexChanged(object sender, EventArgs e)
        {
            firmadetay();
        }

        void hesapla()
        {
            //if (txt_aratoplam.Text == "")
            //{

            //}
            //else
            //{
            //    decimal sub = Convert.ToDecimal(txt_aratoplam.Text);
            //    decimal kdv = Math.Round(sub * 18 / 100, 2);
            //    decimal total = Math.Round(sub + kdv, 2);
            //    txt_kdv.Text = kdv.ToString();
            //    txt_genel.Text = total.ToString();
            //}


        }


        private void txt_aratoplam_TextChanged(object sender, EventArgs e)
        {
            hesapla();
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "ParaBirimi")
            {
                //if (e.Value == null)
                    e.DisplayText = "₺";
            }



        }


        private void gridstyle()
        {
            //gridControl1.ForceInitialize();
            //GridColumn unbColumn = gridView1.Columns.AddField("Fiyat");
            //unbColumn.VisibleIndex = gridView1.Columns.Count;
            //unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            //unbColumn.OptionsColumn.AllowEdit = false;
            //unbColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //unbColumn.DisplayFormat.FormatString = "c";
            //unbColumn.AppearanceCell.BackColor = Color.LemonChiffon;


            this.gridView1.Columns[0].Width = 75;
            this.gridView1.Columns[1].Width = 75;
            this.gridView1.Columns[2].Width = 35;
            this.gridView1.Columns[3].Width = 35;
            this.gridView1.Columns[4].Width = 35;
            this.gridView1.Columns[5].Width = 35;
            this.gridView1.Columns[6].Width = 35;
            this.gridView1.Columns[7].Width = 35;

            this.gridView1.Columns[5].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[6].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[7].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[5].AppearanceCell.BackColor = Color.LemonChiffon;
            this.gridView1.Columns[6].AppearanceCell.BackColor = Color.LemonChiffon;
            this.gridView1.Columns[7].AppearanceCell.BackColor = Color.LemonChiffon;




            GridColumnSummaryItem item = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Toplam", "{0:C}");
            gridView1.Columns["Toplam"].Summary.Add(item);

            GridColumnSummaryItem item2 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KDV", "{0:C}");
            gridView1.Columns["KDV"].Summary.Add(item2);

            GridColumnSummaryItem item3 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Fiyat", "{0:C}");
            gridView1.Columns["Fiyat"].Summary.Add(item3);


            //GridColumnSummaryItem item2 = new GridColumnSummaryItem();
            //item2.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            //item2.Tag = "1";
            //gridView1.Columns["Fiyat"].Summary.Add(item2);
            ////item = new GridColumnSummaryItem();
            //item.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            //item.Tag = "2";
            //gridView1.Columns["Fiyat"].Summary.Add(item);



        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
 
        }

        public static decimal sum;
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column.FieldName == "BirimFiyat")
            {
                //string adet = view.GetRowCellValue(e.RowHandle, view.Columns["BirimFiyat"]).ToString();
                decimal adet = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Adet"]).ToString());
                string kon = Convert.ToString(adet);
                if (kon == "")
                {

                }
                else
                {
                    decimal birimfiyat = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["BirimFiyat"]).ToString());
                    decimal sonf = Math.Round(adet * birimfiyat, 2);
                    decimal kdv = Math.Round(sonf * 18/100 , 2);
                    decimal genel = Math.Round(sonf * 118/100, 2);
                    view.SetRowCellValue(e.RowHandle, view.Columns["Fiyat"], sonf);
                    view.SetRowCellValue(e.RowHandle, view.Columns["KDV"], kdv);
                    view.SetRowCellValue(e.RowHandle, view.Columns["Toplam"], genel);
                }
        

                //txt_aratoplam.Text = gridView1.Columns["Fiyat"].SummaryItem.SummaryValue.ToString();

            }
            //if (e.Column.FieldName == "Para Birimi")
            //{
            //    string bir = view.GetRowCellValue(e.RowHandle, view.Columns["Para Birimi"]).ToString();
            //    if (bir == "")
            //    {
            //        string birim = "₺";
            //        view.SetRowCellValue(e.RowHandle, view.Columns["ParaBirimi"], birim);
            //        MessageBox.Show(birim);
            //    }
            //    else
            //    {
            //        MessageBox.Show("else");
            //    }

            //}




        }

        private void gridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            //GridView view = sender as GridView;
            //GridColumnSummaryItem item = e.Item as GridColumnSummaryItem;
            //if (item.Tag.ToString() == "1")
            //    e.TotalValue = int.Parse(view.Columns["Fiyat"].SummaryText) / 2;
            //else e.TotalValue = int.Parse(view.Columns["Fiyat"].SummaryText) * 2;
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "ParaBirimi" || e.Column.FieldName == "Adet" || e.Column.FieldName == "Toplam" || e.Column.FieldName == "KDV" || e.Column.FieldName == "Fiyat" || e.Column.FieldName == "BirimFiyat" )
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }
        public static decimal summary;
        private void toplamhesap()
        {
            summary = 0;
            for (int i = 0; i <= gridView1.RowCount - 2; i++)
            {
                summary += Convert.ToDecimal(gridView1.GetRowCellValue(i, "Toplam").ToString());
            }
        }
        private void btn_fatura_Click(object sender, EventArgs e)
        {
            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Bu işin geri dönüşü yok. Emin misin ?", "Uyarı", MessageBoxButtons.YesNo);
            if (cikis == DialogResult.Yes)
            {
                DateTime tarih = DateTime.Now;

                for (int i = 0; i <= gridView1.RowCount - 2; i++)
                {
                    SqlCommand komut = new SqlCommand("insert into FaturaDetay " +
                    "(ProformaNo,FaturaFirmaID,Aciklama,UrunGrubu, Miktar, Birim, ParaBirimi, BirimFiyatTl, ToplamFiyat, KDV, GenelFiyat, Tarih, TeklifNo, Iskonto) values (@a1,@a2,@a3,@a4,@a5,@a6,@a9,@a10,@a11,@a12,@a13,@a15,@a16,@a17)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@a1", Convert.ToInt32(txt_evrak.Text));
                    komut.Parameters.AddWithValue("@a2", faturafirmaID);
                    komut.Parameters.AddWithValue("@a3", gridView1.GetRowCellValue(i, "Açıklama").ToString());
                    komut.Parameters.AddWithValue("@a4", gridView1.GetRowCellValue(i, "Ürün").ToString());
                    komut.Parameters.AddWithValue("@a5", Convert.ToInt32(gridView1.GetRowCellValue(i, "Adet").ToString()));
                    komut.Parameters.AddWithValue("@a6", "Adet");
                    komut.Parameters.AddWithValue("@a9", "₺");
                    komut.Parameters.AddWithValue("@a10", Convert.ToDecimal(gridView1.GetRowCellValue(i, "BirimFiyat").ToString()));
                    komut.Parameters.AddWithValue("@a11", Convert.ToDecimal(gridView1.GetRowCellValue(i, "Fiyat").ToString()));
                    komut.Parameters.AddWithValue("@a12", Convert.ToDecimal(gridView1.GetRowCellValue(i, "KDV").ToString()));
                    komut.Parameters.AddWithValue("@a13", Convert.ToDecimal(gridView1.GetRowCellValue(i, "Toplam").ToString()));
                    komut.Parameters.AddWithValue("@a15", tarih);
                    komut.Parameters.AddWithValue("@a16", 2101000);
                    komut.Parameters.AddWithValue("@a17", 0);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }
                toplamhesap();

                SqlCommand komut2 = new SqlCommand("insert into ProformaDurum (ProformaNo, Durum, Total, TeklifNo,FirmaID, OlusturanID, OlusturmaTarih) values (@z1,@z2,@z3,@z4,@z5,@z6,@z7);" +
                    " update Odeme set Odeme_Durumu = @o1 where Evrak_No = @o2 ", bgl.baglanti());
                komut2.Parameters.AddWithValue("@z1", Convert.ToInt32(txt_evrak.Text));
                komut2.Parameters.AddWithValue("@z2", "Onay Bekleniyor");
                komut2.Parameters.AddWithValue("@z3", summary);
                komut2.Parameters.AddWithValue("@z4", 2101000);
                komut2.Parameters.AddWithValue("@z5", faturafirmaID);
                komut2.Parameters.AddWithValue("@z6", Anasayfa.kullanici);
                komut2.Parameters.AddWithValue("@z7", tarih);
                komut2.Parameters.AddWithValue("@o1", "Proforma Oluşturuldu");
                komut2.Parameters.AddWithValue("@o2", Convert.ToInt32(txt_evrak.Text));
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Proforma başarı ile oluşturuldu.");
                this.Close();

            }
            else
            {
                MessageBox.Show("Bende öyle düşünmüştüm.");
            }
        }

        private void ManuelProforma_Load(object sender, EventArgs e)
        {
            txt_evrak.Text = evrakno;
            listele();
            listelegrid();
            Firma();
            firmadetay();
            gridstyle();       

        }
    }
}
