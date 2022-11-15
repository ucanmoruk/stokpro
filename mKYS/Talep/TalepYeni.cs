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

namespace mKYS
{
    public partial class TalepYeni : Form
    {
        public TalepYeni()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select Tur, Kod, Ad, AdEn as 'İngilizce', Cas, Ozellik, Birim from StokListesi where Durum = N'Aktif' order by Tur", bgl.baglanti());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
        }

        void listele2()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select Tur, Kod, Ad, AdEn as 'İngilizce', Cas, Ozellik, Birim from StokListesi where Durum = N'Aktif' " +
                " and not Kod in (select StokKod from StokTalepDetay where TalepNo = '"+teklifno+"' and Durumu = 'Aktif') order by Tur", bgl.baglanti());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
        }

        void listele3()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select d.StokKod as 'Kod', sl.Ad, d.Miktar, d.Birim, d.Marka, d.Ozellik from StokTalepDetay d " +
                " inner join StokListesi sl on d.StokKod = sl.Kod where d.TalepNo = N'"+teklifno+ "' and d.Durumu = 'Aktif'", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;

            this.gridView1.Columns[0].Width = 35;
            this.gridView1.Columns[1].Width = 75;
            this.gridView1.Columns[2].Width = 35;
            this.gridView1.Columns[3].Width = 35;
            this.gridView1.Columns[4].Width = 40;
            this.gridView1.Columns[5].Width = 50;
        }

        void listele4()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select d.StokKod as 'Kod', sl.Ad, d.Miktar, d.Birim, d.Marka, d.Ozellik from StokTalepDetay d " +
                " inner join StokListesi sl on d.StokKod = sl.Kod where d.TalepNo = N'" + talepno + "' and d.Durumu = 'Aktif'", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;

            this.gridView1.Columns[0].Width = 35;
            this.gridView1.Columns[1].Width = 75;
            this.gridView1.Columns[2].Width = 35;
            this.gridView1.Columns[3].Width = 35;
            this.gridView1.Columns[4].Width = 40;
            this.gridView1.Columns[5].Width = 50;
        }

        string yz;
        int teklifmax;
        void maxteklifno()
        {
            SqlCommand komut2 = new SqlCommand("select MAX(TalepNo) from StokTalepDetay ", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                yz = dr2[0].ToString();
                
                if (yz == "")
                {
                    teklifno = 1;
                }
                else
                {
                    teklifmax = Convert.ToInt32(yz);
                    teklifno = teklifmax + 1;
                }
            }
            bgl.baglanti().Close();

        

        }

        int teklifno;
        public static string talepno;
        private void TalepYeni_Load(object sender, EventArgs e)
        {
            listele();
            maxteklifno();

            if (talepno == ""|| talepno == null)
            {
              
                

            }
            else
            {
                btn_ok.Text = "Güncelle";
                Text = talepno +  " Numaralı Talep Güncelle";
                listele4();
            }
          
        }



        string id, kod, birim, ozellik;
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                ekleme();
                kapama = "1";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata TY 22: " + ex);
            }
            
        }

        private void TalepYeni_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (kapama == "1")
            //{
            //    DialogResult sonuc = MessageBox.Show("Yaptığınız değişiklikleri kaydetmeden çıkmak istediğinizden emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //    if (sonuc == DialogResult.No)
            //    {
            //        e.Cancel = true;
            //        return;
            //    }
            //    else
            //    {
            //        // eskisil();
            //        //this.Close();

            //    }
            //}
            //else
            //{


            
            //}

            talepno = null;

        }

        void eskisil()
        {
            if (btn_ok.Text == "Güncelle")
            {
                SqlCommand add2 = new SqlCommand("update StokTalepDetay set Durumu = 'Pasif' where TalepNo = '" + talepno + "'", bgl.baglanti());
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();

                SqlCommand add = new SqlCommand("update StokTalepDegerlendirme set Durumu = 'Pasif' where TalepNo = '" + talepno + "'", bgl.baglanti());
                add.ExecuteNonQuery();
                bgl.baglanti().Close();
            }
            else
            {
                SqlCommand add2 = new SqlCommand("update StokTalepDetay set Durumu = 'Pasif' where TalepNo = '" + teklifno + "'", bgl.baglanti());
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }

       
        }

        TalepListesi m = (TalepListesi)System.Windows.Forms.Application.OpenForms["TalepListesi"];

        void guncelle()
        {
            eskisil();

            for (int i = 0; i < gridView1.RowCount; i++)
            {
                kod = gridView1.GetRowCellValue(i, "Kod").ToString();
                birim = gridView1.GetRowCellValue(i, "Birim").ToString();
                ozellik = gridView1.GetRowCellValue(i, "Ozellik").ToString();

                SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                    "insert into StokTalepDetay (TalepNo, StokKod, Miktar, Birim, Marka, Ozellik,Durum, Durumu) values (@o1,@o2,@o3,@o4,@o5,@o6,@o8, @o9);" +
                    " insert into StokTalepDegerlendirme (TalepNo, TalepStokKod, KabulDurum, Durumu) values (@o1, @o2, @o7, @o9) ;" +
                    "COMMIT TRANSACTION", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", talepno);
                add2.Parameters.AddWithValue("@o2", kod);
                add2.Parameters.AddWithValue("@o3", gridView1.GetRowCellValue(i, "Miktar"));
                add2.Parameters.AddWithValue("@o4", birim);
                add2.Parameters.AddWithValue("@o5", gridView1.GetRowCellValue(i, "Marka"));
                add2.Parameters.AddWithValue("@o6", ozellik);
                add2.Parameters.AddWithValue("@o7", "Beklemede");
                add2.Parameters.AddWithValue("@o8", "Bekleniyor");
                add2.Parameters.AddWithValue("@o9", "Aktif");
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();

            }
            DateTime tarih = DateTime.Now;                     

            MessageBox.Show("Talebinizi başarıyla güncellendi.", "Çıkış", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (Application.OpenForms["TalepListesi"] == null)
            {

            }
            else
            {
                m.listele();
            }
            kapama = "1";
            this.Close();
        }

        string kapama;
        private void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_ok.Text == "Güncelle")
                {
                    guncelle();
                }
                else
                {
                    eskisil();

                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        kod = gridView1.GetRowCellValue(i, "Kod").ToString();
                        birim = gridView1.GetRowCellValue(i, "Birim").ToString();
                        ozellik = gridView1.GetRowCellValue(i, "Ozellik").ToString();

                        SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                            "insert into StokTalepDetay (TalepNo, StokKod, Miktar, Birim, Marka, Ozellik,Durum, Durumu) values (@o1,@o2,@o3,@o4,@o5,@o6,@o8, @o9);" +
                            " insert into StokTalepDegerlendirme (TalepNo, TalepStokKod, KabulDurum, Durumu) values (@o1, @o2, @o7, @o9) ;" +
                            "COMMIT TRANSACTION", bgl.baglanti());
                        add2.Parameters.AddWithValue("@o1", teklifno);
                        add2.Parameters.AddWithValue("@o2", kod);
                        add2.Parameters.AddWithValue("@o3", gridView1.GetRowCellValue(i, "Miktar"));
                        add2.Parameters.AddWithValue("@o4", birim);
                        add2.Parameters.AddWithValue("@o5", gridView1.GetRowCellValue(i, "Marka"));
                        add2.Parameters.AddWithValue("@o6", ozellik);
                        add2.Parameters.AddWithValue("@o7", "Beklemede");
                        add2.Parameters.AddWithValue("@o8", "Bekleniyor");
                        add2.Parameters.AddWithValue("@o9", "Aktif");
                        add2.ExecuteNonQuery();
                        bgl.baglanti().Close();

                    }
                    DateTime tarih = DateTime.Now;

                    SqlCommand add = new SqlCommand("BEGIN TRANSACTION " +
                            "insert into StokTalepListe (TalepNo, TalepEdenID, Durum, Olusturma, Aktif) values (@o1,@o2,@o4,@o5, @o6); " +
                            "COMMIT TRANSACTION", bgl.baglanti());
                    add.Parameters.AddWithValue("@o1", teklifno);
                    add.Parameters.AddWithValue("@o2", Anasayfa.kullanici);
                    add.Parameters.AddWithValue("@o4", "Talep Oluşturuldu");
                    add.Parameters.AddWithValue("@o5", tarih);
                    add.Parameters.AddWithValue("@o6", "Aktif");
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    MessageBox.Show("Talebinizi başarıyla oluşturuldu.", "Çıkış", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    if (Application.OpenForms["TalepListesi"] == null)
                    {

                    }
                    else
                    {
                        m.listele();
                    }
                    kapama = "1";
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata TY1: " + ex);
            }

        }

        private void btn_Kaldir_Click(object sender, EventArgs e)
        {
            try
            {

                silme();
                kapama = "1";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata 55: " + ex, "Lütfen!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

          
        }

        void ekleme()
        {
            if (btn_ok.Text == "Güncelle")
            {
                if (gridView2.SelectedRowsCount > 0)
                {
                    for (int i = 0; i < gridView2.SelectedRowsCount; i++)
                    {
                        id = gridView2.GetSelectedRows()[i].ToString();
                        int y = Convert.ToInt32(id);
                        kod = gridView2.GetRowCellValue(y, "Kod").ToString();
                        birim = gridView2.GetRowCellValue(y, "Birim").ToString();
                        ozellik = gridView2.GetRowCellValue(y, "Ozellik").ToString();

                        SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                            "insert into StokTalepDetay (TalepNo, StokKod, Birim, Ozellik, Durum, Durumu) values (@o1,@o2,@o4,@o5,@o6, @o7);" +
                            "COMMIT TRANSACTION", bgl.baglanti());
                        add2.Parameters.AddWithValue("@o1", talepno);
                        add2.Parameters.AddWithValue("@o2", kod);
                        add2.Parameters.AddWithValue("@o4", birim);
                        add2.Parameters.AddWithValue("@o5", ozellik);
                        add2.Parameters.AddWithValue("@o6", "Bekleniyor");
                        add2.Parameters.AddWithValue("@o7", "Aktif");
                        add2.ExecuteNonQuery();
                        bgl.baglanti().Close();

                    }
                    listele2();
                    listele4();
                }
                else
                {
                    MessageBox.Show("Lütfen seçim yapınız!", "Lütfen!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
            else
            {
                if (gridView2.SelectedRowsCount > 0)
                {
                    for (int i = 0; i < gridView2.SelectedRowsCount; i++)
                    {
                        id = gridView2.GetSelectedRows()[i].ToString();
                        int y = Convert.ToInt32(id);
                        kod = gridView2.GetRowCellValue(y, "Kod").ToString();
                        birim = gridView2.GetRowCellValue(y, "Birim").ToString();
                        ozellik = gridView2.GetRowCellValue(y, "Ozellik").ToString();

                        SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                            "insert into StokTalepDetay (TalepNo, StokKod, Birim, Ozellik, Durum, Durumu) values (@o1,@o2,@o4,@o5,@o6,@o7);" +
                            "COMMIT TRANSACTION", bgl.baglanti());
                        add2.Parameters.AddWithValue("@o1", teklifno);
                        add2.Parameters.AddWithValue("@o2", kod);
                        add2.Parameters.AddWithValue("@o4", birim);
                        add2.Parameters.AddWithValue("@o5", ozellik);
                        add2.Parameters.AddWithValue("@o6", "Bekleniyor");
                        add2.Parameters.AddWithValue("@o7", "Aktif");
                        add2.ExecuteNonQuery();
                        bgl.baglanti().Close();

                    }
                    listele2();
                    listele3();
                }
                else
                {
                    MessageBox.Show("Lütfen seçim yapınız!", "Lütfen!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
        }

        void silme()
        {
            if (btn_ok.Text == "Güncelle")
            {
                if (gridView1.SelectedRowsCount > 0)
                {
                    DialogResult Secim = new DialogResult();

                    Secim = MessageBox.Show("Seçili maddeleri talep listenizden kaldırmak istediğinizden emin misiniz ?", "Emin misiniz!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (Secim == DialogResult.Yes)
                    {
                        for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                        {
                            id = gridView1.GetSelectedRows()[i].ToString();
                            int y = Convert.ToInt32(id);
                            kod = gridView1.GetRowCellValue(y, "Kod").ToString();
                            SqlCommand add2 = new SqlCommand("update StokTalepDetay set Durumu = 'Pasif' where StokKod = '" + kod + "' and TalepNo = '" + talepno + "'", bgl.baglanti());
                            add2.ExecuteNonQuery();
                            bgl.baglanti().Close();

                        }

                        listele2();
                        listele4();
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen seçim yapınız'", "Lütfen!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                if (gridView1.SelectedRowsCount > 0)
                {
                    DialogResult Secim = new DialogResult();

                    Secim = MessageBox.Show("Seçili maddeleri talep listenizden kaldırmak istediğinizden emin misiniz ?", "Emin misin!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (Secim == DialogResult.Yes)
                    {
                        for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                        {
                            id = gridView1.GetSelectedRows()[i].ToString();
                            int y = Convert.ToInt32(id);
                            kod = gridView1.GetRowCellValue(y, "Kod").ToString();
                            SqlCommand add2 = new SqlCommand("update StokTalepDetay set Durumu = 'Pasif' where StokKod = '" + kod + "' and TalepNo = '" + teklifno + "'", bgl.baglanti());
                            add2.ExecuteNonQuery();
                            bgl.baglanti().Close();

                        }

                        listele2();
                        listele3();
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen seçim yapınız'", "Lütfen!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }

    }
}
