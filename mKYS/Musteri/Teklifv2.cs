using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
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

namespace mKYS.Musteri
{
    public partial class Teklifv2 : Form
    {
        public Teklifv2()
        {
            InitializeComponent();
        }


        sqlbaglanti bgl = new sqlbaglanti();
        Teklif n = (Teklif)System.Windows.Forms.Application.OpenForms["Teklif"];

        void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select ID, Firma_Adi as 'Firma' from Firma where Durum = 'Aktif' order by Firma_Adi", bgl.baglanti());
            da2.Fill(dt2);
            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "Firma";
            gridLookUpEdit1.Properties.ValueMember = "ID";

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select ID, Firma_Adi as 'Firma' from Firma where Durum = 'Aktif' and (Tur = 'Proje' or Tur = 'Admin') order by Firma_Adi", bgl.baglanti());
            da.Fill(dt);
            gridLookUpEdit2.Properties.DataSource = dt;
            gridLookUpEdit2.Properties.DisplayMember = "Firma";
            gridLookUpEdit2.Properties.ValueMember = "ID";

        }

        void detaybul()
        {
            SqlCommand komut = new SqlCommand("select * from TeklifX1 where ID = '"+tID+"'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                combo_tur.Text = dr["TeklifTuru"].ToString();
                gridLookUpEdit1.EditValue = dr["FirmaID"].ToString();
                gridLookUpEdit2.EditValue = dr["ProjeID"].ToString();
                txt_no.Text = dr["TeklifNo"].ToString();
                dateEdit1.EditValue = Convert.ToDateTime(dr["Tarih"].ToString());
                txt_aciklama.Text = dr["Aciklama"].ToString();
                combo_birim.Text = dr["ParaBirimi"].ToString();
                txt_iskonto.Text = dr["Iskonto"].ToString();
            }
            bgl.baglanti().Close();

            if (combo_tur.Text == "Paket")
            {
                paketler();
            }
            else
            {
                analizler();
            }
            tekliflistele2();
        }

        public static int maxevrak;
        public void maxteklifno()
        {
            SqlCommand komutm = new SqlCommand("select max(TeklifNo) from TeklifX2", bgl.baglanti());
            SqlDataReader drm = komutm.ExecuteReader();
            while (drm.Read())
            {
                maxevrak = Convert.ToInt32(drm[0].ToString());
            }
            bgl.baglanti().Close();
        }

        public static string tID, gelis;
        private void Teklifv2_Load(object sender, EventArgs e)
        {
            listele();
            gridLookUpEdit2.EditValue = 5487;
            DateTime tarih = DateTime.Now;
            dateEdit1.EditValue = tarih;
            maxteklifno();
            txt_no.Text = (maxevrak + 1).ToString();
            //GridColumnSummaryItem item = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Toplam", "{0:C}");
            //gridView1.Columns["Toplam"].Summary.Add(item);


            if (tID == null || tID == "")
            {
                gelis = "yeni";
                btn_ok.Text = "Teklif Kaydet";
            }
            else
            {
                Text = "Teklif Detayları";
                btn_ok.Text = "Teklif Güncelle";
                gelis = "güncelle";
                detaybul();
                combo_tur.Enabled = false;
            }

        }

        private void Teklifv2_FormClosing(object sender, FormClosingEventArgs e)
        {
            tID = null;
        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;

        }

        private void gridLookUpEdit2_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;

        }

        private void combo_tur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_tur.Text == "Paket")
            {
                gridControl1.DataSource = null;
                gridView1.Columns.Clear();
                gridControl2.DataSource = null;
                gridView2.Columns.Clear();
                paketler();
            }
            else 
            {
                gridControl1.DataSource = null;
                gridView1.Columns.Clear();
                gridControl2.DataSource = null;
                gridView2.Columns.Clear();
                analizler();
            }

        }

        void paketler()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(@"select Grup as 'Grup', Tur as [Paket Adı], ID from Numune_Grup  where Grup = 'Özel' or Grup = 'Tareks'
            order by Grup", bgl.baglanti());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
            gridView2.Columns["ID"].Visible = false;
            this.gridView2.Columns[0].Width = 35;
            this.gridView2.Columns[1].Width = 65;

        }

        void analizler()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select Kod, Ad, Method, Matriks, ID from StokAnalizListesi where Durumu = 'Aktif'
            except select Kod, Ad, Method, Matriks, ID from StokAnalizListesi
            where ID in (select AnalizID from TeklifX2 where TeklifNo = '" + txt_no.Text + "')", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
            gridView2.Columns["ID"].Visible = false;
        }

        private void gridView2_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu2.ShowPopup(p2);
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

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cikarma();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ekleme();

            tekliflistele();
        }

        void tekliflistekontrol()
        {
            SqlCommand komut2 = new SqlCommand("select count(TeklifNo) as 'No' from TeklifX1 where TeklifNo = N'" + txt_no.Text + "'  ", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                detayk = Convert.ToInt32(dr2["No"]);
            }
            bgl.baglanti().Close();
        }

        int detayk;
        string id, o2;
        void ekleme()
        {

            if (combo_tur.Text == "Paket")
            {
                if (gridView2.SelectedRowsCount > 0)
                {
                    for (int i = 0; i < gridView2.SelectedRowsCount; i++)
                    {
                        id = gridView2.GetSelectedRows()[i].ToString();
                        int y = Convert.ToInt32(id);
                        o2 = gridView2.GetRowCellValue(y, "ID").ToString();                       

                        SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                            "insert into TeklifX2 (TeklifNo, PaketID, BirimFiyat, FiyatBirim) " +
                            "values (@o1,@o2,@o3,@o4);" +
                            "COMMIT TRANSACTION", bgl.baglanti());
                        add2.Parameters.AddWithValue("@o1", txt_no.Text);
                        add2.Parameters.AddWithValue("@o2", o2);
                        add2.Parameters.AddWithValue("@o3", 0);
                        add2.Parameters.AddWithValue("@o4", combo_birim.Text);
                        add2.ExecuteNonQuery();
                        bgl.baglanti().Close();
                    }
                }
            }
            else
            {
                for (int i = 0; i < gridView2.SelectedRowsCount; i++)
                {
                    id = gridView2.GetSelectedRows()[i].ToString();
                    int y = Convert.ToInt32(id);
                    o2 = gridView2.GetRowCellValue(y, "ID").ToString();
                    SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                        "insert into TeklifX2 (TeklifNo, AnalizID, BirimFiyat, FiyatBirim) " +
                        "values (@o1,@o2,@o3,@o4);" +
                        "COMMIT TRANSACTION", bgl.baglanti());
                    add2.Parameters.AddWithValue("@o1", txt_no.Text);
                    add2.Parameters.AddWithValue("@o2", o2);
                    add2.Parameters.AddWithValue("@o3", 0);
                    add2.Parameters.AddWithValue("@o4", combo_birim.Text);
                    add2.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }

                analizler();
            }

            tekliflistekontrol();
            if (detayk == 0)
            {  SqlCommand add = new SqlCommand("insert into TeklifX1 (TeklifNo, TeklifTuru,  Durum) " +
                "values (@a1,@a2,@a6) ", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", txt_no.Text);
                add.Parameters.AddWithValue("@a2", combo_tur.Text);
                add.Parameters.AddWithValue("@a6", "Pasif");
                add.ExecuteNonQuery();
                bgl.baglanti().Close();
            }
            else
            {

            }


            tekliflistele();

        }

        void cikarma()
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show("Seçili analizleri kaldırmak istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Secim == DialogResult.Yes)
                {
                    if (combo_tur.Text == "Paket")
                    {
                        for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                        {
                            id = gridView1.GetSelectedRows()[i].ToString();
                            int y = Convert.ToInt32(id);
                            o2 = gridView1.GetRowCellValue(y, "ID").ToString();
                            SqlCommand add = new SqlCommand("delete from TeklifX2 where TeklifNo = @p1 and PaketID = @p2 ", bgl.baglanti());
                            add.Parameters.AddWithValue("@p1", txt_no.Text);
                            add.Parameters.AddWithValue("@p2", o2);
                            add.ExecuteNonQuery();
                            bgl.baglanti().Close();
                        }
                    }
                    else
                    {
                        for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                        {
                            id = gridView1.GetSelectedRows()[i].ToString();
                            int y = Convert.ToInt32(id);
                            o2 = gridView1.GetRowCellValue(y, "ID").ToString();                          
                            SqlCommand add = new SqlCommand("delete from TeklifX2 where TeklifNo = @p1 and AnalizID = @p2 ", bgl.baglanti());
                            add.Parameters.AddWithValue("@p1", txt_no.Text);
                            add.Parameters.AddWithValue("@p2", o2);
                            add.ExecuteNonQuery();
                            bgl.baglanti().Close();

                        }
                        analizler();
                    }


                }
            }
            else
            {
                MessageBox.Show("Neyi mesela ?");
            }
            tekliflistele();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (gelis == "güncelle")
            {
                guncelle();
            }
            else
            {
                kaydet();
            }


            if (Application.OpenForms["Teklif"] == null)
            {

            }
            else
            {
                n.listele();
            }

        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Birim Fiyat" || e.Column.FieldName == "Para Birimi" || e.Column.FieldName == "Adet" || e.Column.FieldName == "Toplam" )
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column.FieldName == "Birim Fiyat")
            {
                //string adet = view.GetRowCellValue(e.RowHandle, view.Columns["BirimFiyat"]).ToString();
                decimal adet = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Adet"]).ToString());
                string kon = Convert.ToString(adet);
                decimal birimfiyat = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Birim Fiyat"]).ToString());
                decimal sonf = Math.Round(adet * birimfiyat, 2);
                view.SetRowCellValue(e.RowHandle, view.Columns["Toplam"], sonf);
            }
            else if (e.Column.FieldName == "Adet")
            {
                decimal adet = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Adet"]).ToString());
                string kon = Convert.ToString(adet);
                decimal birimfiyat = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Birim Fiyat"]).ToString());
                decimal sonf = Math.Round(adet * birimfiyat, 2);
                view.SetRowCellValue(e.RowHandle, view.Columns["Toplam"], sonf);
            }

            gridView1.Columns["Toplam"].Summary.Clear();
            GridColumnSummaryItem item = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Toplam", "{0:C}");
            gridView1.Columns["Toplam"].Summary.Add(item);

        }

        void kaydet()
        {
            try
            {
                if (gridLookUpEdit1.EditValue == null || gridLookUpEdit2.EditValue == null)
                {
                    MessageBox.Show("Lütfen firma seçiniz!");
                }
                else
                {
                    if (combo_tur.Text == "Paket")
                    {
                        for (int ik = 0; ik < gridView1.RowCount; ik++)
                        {
                            //id = gridView1.GetSelectedRows()[ik].ToString();
                            //int y = Convert.ToInt32(id);
                            o2 = gridView1.GetRowCellValue(ik, "ID").ToString();                                                  
                            SqlCommand komutz = new SqlCommand("update TeklifX2 set BirimFiyat = @o1 , FiyatBirim = @o2, Aciklama = @o4, Adet = @o5, Toplam=@o6 where PaketID = '" + o2+"' and TeklifNo = '" + txt_no.Text + "'", bgl.baglanti());
                            komutz.Parameters.AddWithValue("@o1", Convert.ToDecimal(gridView1.GetRowCellValue(ik, "Birim Fiyat").ToString()));
                            komutz.Parameters.AddWithValue("@o2", gridView1.GetRowCellValue(ik, "Para Birimi").ToString());
                            komutz.Parameters.AddWithValue("@o4", gridView1.GetRowCellValue(ik, "Açıklama").ToString());
                            komutz.Parameters.AddWithValue("@o5", Convert.ToInt32(gridView1.GetRowCellValue(ik, "Adet").ToString()));
                            komutz.Parameters.AddWithValue("@o6", Convert.ToDecimal(gridView1.GetRowCellValue(ik, "Toplam").ToString()));
                            komutz.ExecuteNonQuery();
                            bgl.baglanti().Close();
                        }

                    }
                    else
                    {
                        for (int ik = 0; ik < gridView1.RowCount; ik++)
                        {
                            //id = gridView1.GetSelectedRows()[ik].ToString();
                            //int y = Convert.ToInt32(id);
                            o2 = gridView1.GetRowCellValue(ik, "ID").ToString();
                            SqlCommand komutz = new SqlCommand("update TeklifX2 set BirimFiyat = @o1 , FiyatBirim = @o2, Adet = @o5, Toplam=@o6  where AnalizID = '" + o2 + "' and TeklifNo = '" + txt_no.Text + "'", bgl.baglanti());
                            komutz.Parameters.AddWithValue("@o1", Convert.ToDecimal(gridView1.GetRowCellValue(ik, "Birim Fiyat").ToString()));
                            komutz.Parameters.AddWithValue("@o2", gridView1.GetRowCellValue(ik, "Para Birimi").ToString());
                            komutz.Parameters.AddWithValue("@o5", Convert.ToInt32(gridView1.GetRowCellValue(ik, "Adet").ToString()));
                            komutz.Parameters.AddWithValue("@o6", Convert.ToDecimal(gridView1.GetRowCellValue(ik, "Toplam").ToString()));
                            komutz.ExecuteNonQuery();
                            bgl.baglanti().Close();
                        }
                    }
                    SqlCommand komutaz = new SqlCommand(@"update TeklifX1 set PlasiyerID = @a1, Tarih= @a2, FirmaID = @a3, ProjeID = @a4, Aciklama = @a5, Durum = @a6, Iskonto = @a7, ParaBirimi = @a8 
	                where TeklifNo = '" + txt_no.Text + "' ", bgl.baglanti());
                    komutaz.Parameters.AddWithValue("@a1", Anasayfa.kullanici);
                    komutaz.Parameters.AddWithValue("@a2", dateEdit1.EditValue);
                    komutaz.Parameters.AddWithValue("@a3", gridLookUpEdit1.EditValue);
                    komutaz.Parameters.AddWithValue("@a4", gridLookUpEdit2.EditValue);
                    komutaz.Parameters.AddWithValue("@a5", txt_aciklama.Text);
                    komutaz.Parameters.AddWithValue("@a6", "Aktif");
                    komutaz.Parameters.AddWithValue("@a7", txt_iskonto.Text);
                    komutaz.Parameters.AddWithValue("@a8", combo_birim.Text);
                    komutaz.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }

                MessageBox.Show("Teklif başarı ile oluşturuldu!");
                this.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata1 : " + ex);
            }
           

        }

        void guncelle()
        {
            try
            {
                if (gridLookUpEdit1.EditValue == null || gridLookUpEdit2.EditValue == null)
                {
                    MessageBox.Show("Lütfen firma seçiniz!");
                }
                else
                {
                    if (combo_tur.Text == "Paket")
                    {
                        for (int ik = 0; ik < gridView1.RowCount; ik++)
                        {
                            o2 = gridView1.GetRowCellValue(ik, "ID").ToString();
                            SqlCommand komutz = new SqlCommand("update TeklifX2 set BirimFiyat = @o1 , FiyatBirim = @o2, Aciklama = @o4, Adet = @o5, Toplam=@o6 where PaketID = '" + o2 + "' and TeklifNo = '" + txt_no.Text + "'", bgl.baglanti());
                            komutz.Parameters.AddWithValue("@o1", Convert.ToDecimal(gridView1.GetRowCellValue(ik, "Birim Fiyat").ToString()));
                            komutz.Parameters.AddWithValue("@o2", gridView1.GetRowCellValue(ik, "Para Birimi").ToString());
                            komutz.Parameters.AddWithValue("@o4", gridView1.GetRowCellValue(ik, "Açıklama").ToString());
                            komutz.Parameters.AddWithValue("@o5", Convert.ToInt32(gridView1.GetRowCellValue(ik, "Adet").ToString()));
                            komutz.Parameters.AddWithValue("@o6", Convert.ToDecimal(gridView1.GetRowCellValue(ik, "Toplam").ToString()));
                            komutz.ExecuteNonQuery();
                            bgl.baglanti().Close();
                        }

                    }
                    else
                    {
                        for (int ik = 0; ik < gridView1.RowCount; ik++)
                        {
                            o2 = gridView1.GetRowCellValue(ik, "ID").ToString();
                            SqlCommand komutz = new SqlCommand("update TeklifX2 set BirimFiyat = @o1 , FiyatBirim = @o2, Adet = @o5, Toplam=@o6  where AnalizID = '" + o2 + "' and TeklifNo = '" + txt_no.Text + "'", bgl.baglanti());
                            komutz.Parameters.AddWithValue("@o1", Convert.ToDecimal(gridView1.GetRowCellValue(ik, "Birim Fiyat").ToString()));
                            komutz.Parameters.AddWithValue("@o2", gridView1.GetRowCellValue(ik, "Para Birimi").ToString());
                            komutz.Parameters.AddWithValue("@o5", Convert.ToInt32(gridView1.GetRowCellValue(ik, "Adet").ToString()));
                            komutz.Parameters.AddWithValue("@o6", Convert.ToDecimal(gridView1.GetRowCellValue(ik, "Toplam").ToString()));
                            komutz.ExecuteNonQuery();
                            bgl.baglanti().Close();
                        }
                    }
                    SqlCommand komutaz = new SqlCommand(@"update TeklifX1 set PlasiyerID = @a1, Tarih= @a2, FirmaID = @a3, ProjeID = @a4, Aciklama = @a5, Iskonto = @a7, ParaBirimi = @a8 
	                where TeklifNo = '" + txt_no.Text + "' ", bgl.baglanti());
                    komutaz.Parameters.AddWithValue("@a1", Anasayfa.kullanici);
                    komutaz.Parameters.AddWithValue("@a2", dateEdit1.EditValue);
                    komutaz.Parameters.AddWithValue("@a3", gridLookUpEdit1.EditValue);
                    komutaz.Parameters.AddWithValue("@a4", gridLookUpEdit2.EditValue);
                    komutaz.Parameters.AddWithValue("@a5", txt_aciklama.Text);
                    komutaz.Parameters.AddWithValue("@a7", txt_iskonto.Text);
                    komutaz.Parameters.AddWithValue("@a8", combo_birim.Text);
                    komutaz.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }

                MessageBox.Show("Teklif başarı ile güncellendi!");
                this.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata1 : " + ex);
            }
        }

        void tekliflistele()
        {
            if (combo_tur.Text == "Paket")
            {
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(@"select n.tur as [Paket Adı], t.Aciklama as 'Açıklama', [Adet]=@a2, t.BirimFiyat as [Birim Fiyat], 
                [Para Birimi]=@a1, t.Toplam, n.ID from TeklifX2 t 
                inner join Numune_Grup n on t.PaketID = n.ID 
                where t.TeklifNo = '" + txt_no.Text + "' order by n.Tur", bgl.baglanti());
                da2.SelectCommand.Parameters.AddWithValue("@a1", combo_birim.Text);
                da2.SelectCommand.Parameters.AddWithValue("@a2", 1);
                da2.Fill(dt2);
                gridControl1.DataSource = dt2;
                gridView1.Columns["ID"].Visible = false;
                this.gridView1.Columns[0].Width = 85;
                this.gridView1.Columns[1].Width = 85;
                this.gridView1.Columns[2].Width = 35;
                this.gridView1.Columns[3].Width = 35;
                this.gridView1.Columns[4].Width = 35;
                this.gridView1.Columns[5].Width = 35;
                this.gridView1.Columns[5].AppearanceCell.BackColor = Color.LemonChiffon;
            }
            else
            {
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(@"select a.Kod , a.Ad as 'Analiz Adı', a.Method, [Adet]=@a2, t.BirimFiyat as [Birim Fiyat], [Para Birimi]=@a1,  t.Toplam, 
                a.ID from TeklifX2 t 
                left join StokAnalizListesi a on t.AnalizID = a.ID 
                where t.TeklifNo = '" + txt_no.Text + "' order by a.Ad", bgl.baglanti());
                da2.SelectCommand.Parameters.AddWithValue("@a1", combo_birim.Text);
                da2.SelectCommand.Parameters.AddWithValue("@a2", 1);
                da2.Fill(dt2);
                gridControl1.DataSource = dt2;
                gridView1.Columns["ID"].Visible = false;
                this.gridView1.Columns[0].Width = 55;
                this.gridView1.Columns[1].Width = 85;
                this.gridView1.Columns[2].Width = 85;
                this.gridView1.Columns[3].Width = 35;
                this.gridView1.Columns[4].Width = 35;
                this.gridView1.Columns[5].Width = 35;
                this.gridView1.Columns[6].Width = 35;
                this.gridView1.Columns[6].AppearanceCell.BackColor = Color.LemonChiffon;
            }


        }

        void tekliflistele2()
        {
            if (combo_tur.Text == "Paket")
            {
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(@"select n.tur as [Paket Adı], t.Aciklama as 'Açıklama', t.Adet, t.BirimFiyat as [Birim Fiyat], 
                t.FiyatBirim as 'Para Birimi', t.Toplam, n.ID from TeklifX2 t 
                inner join Numune_Grup n on t.PaketID = n.ID 
                where t.TeklifNo = '" + txt_no.Text + "' order by n.Tur", bgl.baglanti());
                da2.Fill(dt2);
                gridControl1.DataSource = dt2;
                gridView1.Columns["ID"].Visible = false;
                this.gridView1.Columns[0].Width = 85;
                this.gridView1.Columns[1].Width = 85;
                this.gridView1.Columns[2].Width = 35;
                this.gridView1.Columns[3].Width = 35;
                this.gridView1.Columns[4].Width = 35;
                this.gridView1.Columns[5].Width = 35;
                this.gridView1.Columns[5].AppearanceCell.BackColor = Color.LemonChiffon;
            }
            else
            {
                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(@"select a.Kod, a.Ad as 'Analiz Adı', a.Method, t.Adet, t.BirimFiyat as [Birim Fiyat], t.FiyatBirim as 'Para Birimi', t.Toplam, 
                a.ID from TeklifX2 t 
                inner join StokAnalizListesi a on t.AnalizID = a.ID 
                where t.TeklifNo = '" + txt_no.Text + "' order by a.Ad", bgl.baglanti());
                da2.Fill(dt2);
                gridControl1.DataSource = dt2;
                gridView1.Columns["ID"].Visible = false;
                this.gridView1.Columns[0].Width = 55;
                this.gridView1.Columns[1].Width = 85;
                this.gridView1.Columns[2].Width = 85;
                this.gridView1.Columns[3].Width = 35;
                this.gridView1.Columns[4].Width = 35;
                this.gridView1.Columns[5].Width = 35;
                this.gridView1.Columns[6].Width = 35;
                this.gridView1.Columns[6].AppearanceCell.BackColor = Color.LemonChiffon;
            }


        }
    }
}
