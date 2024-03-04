using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mKYS
{
    public partial class FirmaDetay : Form
    {
        public FirmaDetay()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();


        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlCommand add = new SqlCommand("update StokFirmaBirim set Durum=N'Pasif' where Birim = N'"+birim+"' and FirmaID = N'"+firmaID+"' ", bgl.baglanti());
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Silme işlemi başarılı!", "Oppss!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            listele();
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            SqlCommand add = new SqlCommand("update StokFirma set SPath=N'"+txt_path.Text+"' where ID = N'" + firmaID + "' ", bgl.baglanti());
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Güncelleme işlemi başarılı!", "Oppss!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            listele();
            firmabul();
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }
        }

        string birim;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            birim = dr["Birim"].ToString();
        }

        int firmaID;
        void firmabul()
        {
            firmaID = Anasayfa.firmaID;
            SqlCommand komut21 = new SqlCommand("Select * from StokFirma where ID = N'" + firmaID + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                txt_ad.Text = dr21["FirmaAd"].ToString();
                txt_adres.Text = dr21["Adres"].ToString();
                txt_path.Text = dr21["SPath"].ToString();
                txt_dok.Text = dr21["KPath"].ToString();
            }
            bgl.baglanti().Close();
        }

        void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select Birim from StokFirmaBirim where Durum = N'Aktif' order by Birim ", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            SqlCommand add = new SqlCommand("insert into StokFirmaBirim(FirmaID, Birim, Durum) values (@o1,@o2, @o3)", bgl.baglanti());
            add.Parameters.AddWithValue("@o1", firmaID);
            add.Parameters.AddWithValue("@o2", txt_birim.Text);
            add.Parameters.AddWithValue("@o3", "Aktif");
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ekleme işlemi başarılı!", "Oppss!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            listele();
        }

        string fotoname;
        public void fotobul()
        {
            SqlCommand detay2 = new SqlCommand("Select Logo from StokFirma where ID = N'" + firmaID + "' ", bgl.baglanti());
            SqlDataReader dre = detay2.ExecuteReader();
            while (dre.Read())
            {
                fotoname = dre["Logo"].ToString();
            }

            string yol = @"http://www.massgrup.com/cosmo/Numune/" + fotoname;
            pictureEdit1.LoadAsync(yol);

        }

        int yetki;
        void yetkibul()
        {
            SqlCommand komut21 = new SqlCommand("Select * from KaliteYetki where Gorev = N'" + Anasayfa.gorev + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                yetki = Convert.ToInt32(dr21["Firma"]);
            }
            bgl.baglanti().Close();

            if (yetki == 0 || yetki.ToString() == null)
            {
                btn_dguncelle.Visible = false;
                btn_guncelle.Visible = false;
                btn_ekle.Visible = false;
                btn_kayit.Visible = false;
                btn_logo.Visible = false;
                barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                btn_dguncelle.Visible = true;
                btn_guncelle.Visible = true;
                btn_ekle.Visible = true;
                btn_kayit.Visible = true;
                btn_logo.Visible = true;
                barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
        }

        private void FirmaDetay_Load(object sender, EventArgs e)
        {
            firmabul();
            listele();
            fotobul();
            yetkibul();
        }

        string name;
        private void btn_logo_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // open.InitialDirectory = "C:\\";
            open.InitialDirectory = path;
            open.Filter = "Fotoğraf (*.jpg)|*.jpg|Tüm Dosyalar(*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                name = open.FileName;
                pictureEdit1.Image = new Bitmap(open.FileName);

            }
        }

        string yenisim, ftpfullpath, yeniyol;

        private void btn_dguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand add = new SqlCommand("update StokFirma set KPath=N'" + txt_dok.Text + "' where ID = N'" + firmaID + "' ", bgl.baglanti());
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Güncelleme işlemi başarılı!", "Oppss!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            listele();
            firmabul();
        }

        private void btn_kayit_Click(object sender, EventArgs e)
        {
            try
            {

                if (fotoname == "" || fotoname == null)
                {

                }
                else
                {
                    btn_kayit.Text = "Güncelle";
                }

                string isim = Path.GetFileName(name);
                yenisim = firmaID + " - " + isim;
                using (var client = new WebClient())
                {
                    string ftpUsername = "massgrup";
                    string ftpPassword = "!88n2ee5Q";
                    ftpfullpath = "ftp://" + "www.massgrup.com/httpdocs/cosmo/Numune" + "/" + yenisim;
                    yeniyol = "http://" + "www.massgrup.com/cosmo/Numune" + "/" + yenisim;
                    client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                    client.UploadFile(ftpfullpath, name);
                }

                SqlCommand ekle = new SqlCommand("update StokFirma set Logo = @d1 where ID = N'"+firmaID+"'", bgl.baglanti());
                ekle.Parameters.AddWithValue("@d1", yenisim);
                ekle.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Logo başarıyla yüklendi!", "Oppss!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata F44: " + ex);
            }
        }
    }
}
