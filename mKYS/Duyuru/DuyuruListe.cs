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

namespace mKYS.Duyuru
{
    public partial class DuyuruListe : Form
    {
        public DuyuruListe()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select d.ID, k.ID as 'PersonelID', k.Ad + ' ' + k.Soyad as 'Mesaj Gönderen', d.Tarih, d.Konu, d.Duyuru from StokDuyuru d " +
                "inner join StokKullanici k on d.PersonelID = k.ID inner join StokDuyuruDurum m on d.ID = m.DuyuruID where d.Durum = 'Aktif' and m.Durum = 'Beklemede' and m.PersonelID = '" + Anasayfa.kullanici+"' order by d.Tarih desc", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;

            gridView1.Columns["ID"].Visible = false;
            gridView1.Columns["PersonelID"].Visible = false;
            this.gridView1.Columns[2].Width = 40;
            this.gridView1.Columns[3].Width = 40;
            this.gridView1.Columns[4].Width = 50;
            this.gridView1.Columns[5].Width = 275;

            RepositoryItemMemoEdit memo = new RepositoryItemMemoEdit();
            gridView1.Columns["Duyuru"].ColumnEdit = memo;

            gridView1.Columns["Duyuru"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        int dID, pID;
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show("Seçili duyuruları silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Secim == DialogResult.Yes)
                {                                   

                    for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                    {
                        int y = Convert.ToInt32(gridView1.GetSelectedRows()[i].ToString());
                        dID = Convert.ToInt32(gridView1.GetRowCellValue(y, "ID").ToString());
                        pID = Convert.ToInt32(gridView1.GetRowCellValue(y, "PersonelID").ToString());

                        if (pID.ToString() == Anasayfa.kullanici)
                        {
                            SqlCommand ad = new SqlCommand("update StokDuyuru set Durum = 'Pasif' where ID = '" + dID + "'", bgl.baglanti());
                            ad.ExecuteNonQuery();
                            bgl.baglanti().Close();

                            MessageBox.Show("Silme işlemi başarıyla gerçekleşmiştir.");
                        }
                        else
                        {
                            MessageBox.Show("Sadece kendi yayınladığınız mesajları iptal edebilirsiniz!", "Ooppss!", MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                        }                   
                        
                    }
                    
                    listele();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata 1113 : " + ex.Message);
            }
        }

        private void DuyuruListe_Load(object sender, EventArgs e)
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

        private void DuyuruListe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                listele();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                MessageBox.Show("Okunmamış mesajınız bulunmamaktadır!", "...", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                string peID = dr["PersonelID"].ToString();

                if (peID == Anasayfa.kullanici)
                {
                    barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                }
                else
                {
                    barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }

           

        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Mesaj Gönderen" || e.Column.FieldName == "Tarih")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;          
        }

        private void DuyuruListe_FormClosing(object sender, FormClosingEventArgs e)
        {
            var mfrm = (Anasayfa)Application.OpenForms["Anasayfa"];
            if (mfrm != null)
                mfrm.ogizle();
        }

        int kID;

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0)
            {
                MessageBox.Show("Lütfen seçim yapınız!", "Ooppss", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                DuyuruTarih dy = new DuyuruTarih();
                dy.Show();
                // Okundu();
            }

        }


        public static string ytarih;

        public void Okundu()
        {
            DialogResult cikis = new DialogResult();
            cikis = MessageBox.Show("Seçili mesajları okuduğunuzu onaylıyor musunuz?", "Ooppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cikis == DialogResult.Yes)
            {
                for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                {
                    DateTime ptarih = DateTime.Parse(ytarih);
                    
                    int y = Convert.ToInt32(gridView1.GetSelectedRows()[i].ToString());
                    kID = Convert.ToInt32(gridView1.GetRowCellValue(y, "ID").ToString());
                    SqlCommand ad = new SqlCommand("update StokDuyuruDurum set Durum = N'Okundu' , Tarih = @a1 where DuyuruID = '" + kID + "' and PersonelID = '" + Anasayfa.kullanici + "'", bgl.baglanti());
                    ad.Parameters.AddWithValue("@a1", ptarih);
                    ad.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }
                listele();
            }

        }
    }
}
