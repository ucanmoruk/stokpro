using DevExpress.XtraRichEdit.Model;
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
using Tulpep.NotificationWindow;

namespace mKYS.Duyuru
{
    public partial class DuyuruYeni : Form
    {
        public DuyuruYeni()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select ID, Ad + ' ' + Soyad as 'Personel'  from StokKullanici where Durum = N'Aktif' and ID <> '"+Anasayfa.kullanici+"' ", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.Columns["ID"].Visible = false;
        }

        int kID, pID;
        void ekleme()
        {
            try
            {
                int Donen = 0;

                DateTime tarih = DateTime.Now;            

                SqlCommand add = new SqlCommand("insert into StokDuyuru (PersonelID, Tarih, Konu, Duyuru, Durum) values (@a1, @a2, @a3, @a4, @a5) SET @ID = SCOPE_IDENTITY() ", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", Anasayfa.kullanici);
                add.Parameters.AddWithValue("@a2", dateEdit1.EditValue);
                add.Parameters.AddWithValue("@a3", txt_konu.Text);
                add.Parameters.AddWithValue("@a4", memo_mesaj.Text);
                add.Parameters.AddWithValue("@a5", "Aktif");
                add.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                add.ExecuteNonQuery();
                Donen = Convert.ToInt32(add.Parameters["@ID"].Value);
                bgl.baglanti().Close();

                if (Combo_alici.Text == "Tüm personel")
                {
                    SqlCommand komut2 = new SqlCommand("Select ID from StokKullanici where Durum = N'Aktif' and ID <> '" + Anasayfa.kullanici + "'", bgl.baglanti());
                    SqlDataReader dr2 = komut2.ExecuteReader();
                    while (dr2.Read())
                    {
                        pID = Convert.ToInt32(dr2["ID"]);
                        SqlCommand ad = new SqlCommand("insert into StokDuyuruDurum (PersonelID, DuyuruID, Durum)  values (@a1, @a2, @a3)", bgl.baglanti());
                        ad.Parameters.AddWithValue("@a1", pID);
                        ad.Parameters.AddWithValue("@a2", Donen);
                        ad.Parameters.AddWithValue("@a3", "Beklemede");
                        ad.ExecuteNonQuery();
                        bgl.baglanti().Close();

                        PopupNotifier popp = new PopupNotifier();
                        popp.Image = mUnique.Properties.Resources.information;
                        popp.TitleText = "Bir yeni duyuru!";
                        popp.ContentText = txt_konu.Text + " konusunda yayınlanan duyurunun detaylarını duyurular sayfasından okuyunuz!";
                        popp.Popup();

                    }
                    bgl.baglanti().Close();

                }
                else
                {
                    for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                    {
                        int y = Convert.ToInt32(gridView1.GetSelectedRows()[i].ToString());
                        kID = Convert.ToInt32(gridView1.GetRowCellValue(y, "ID").ToString());
                        SqlCommand ad = new SqlCommand("insert into StokDuyuruDurum (PersonelID, DuyuruID, Durum) values (@a1, @a2, @a3)", bgl.baglanti());
                        ad.Parameters.AddWithValue("@a1", kID);
                        ad.Parameters.AddWithValue("@a2", Donen);
                        ad.Parameters.AddWithValue("@a3", "Beklemede");
                        ad.ExecuteNonQuery();
                        bgl.baglanti().Close();

                        if (Anasayfa.kullanici == kID.ToString())
                        {
                            PopupNotifier popu = new PopupNotifier();
                            popu.Image = mUnique.Properties.Resources.information;
                            popu.TitleText = "Bir yeni duyuru!";
                            popu.ContentText = txt_konu.Text + " konusunda yayınlanan duyurunun detaylarını duyurular sayfasından okuyunuz!";
                            popu.Popup();
                        }

                    }
                }


                MessageBox.Show("Mesajınız başarıyla yayınlandı!", "Ooppsss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                this.Close();

            }
            catch (Exception Ex)
            {

                MessageBox.Show("Hata D11: " + Ex);
            }            

        }

        private void Combo_alici_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Combo_alici.Text == "Tüm personel")
            {
                popup.Visible = false;
                Combo_alici.Size = new Size(342, 20);
            }
            else
            {
                popup.Visible = true;
                Combo_alici.Size = new Size(154, 20);
            }
        }

        DuyuruListe m = (DuyuruListe)System.Windows.Forms.Application.OpenForms["DuyuruListe"];

        private void btn_yayin_Click(object sender, EventArgs e)
        {
            ekleme();


            PopupNotifier popup = new PopupNotifier();
            popup.Image = mUnique.Properties.Resources.information;
            popup.TitleText = "Bir yeni duyuru!";
            popup.ContentText = txt_konu.Text + " konusunda yayınlanan duyurunun detaylarını duyurular sayfasından okuyunuz!";
            popup.Popup();

            if (Application.OpenForms["DuyuruListe"] == null)
            { }
            else
            {
                m.listele();
            }
        }

        private void DuyuruYeni_Load(object sender, EventArgs e)
        {
            listele();

              
        }
    }
}
