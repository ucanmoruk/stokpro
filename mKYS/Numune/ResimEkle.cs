using DevExpress.XtraEditors;
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

namespace mKYS.Numune
{
    public partial class ResimEkle : Form
    {
        public ResimEkle()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select ID, RaporNo, Numune_Adi from NKR where Durum = N'Aktif' order by ID desc", bgl.baglanti());
            da2.Fill(dt2);
            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "RaporNo";
            gridLookUpEdit1.Properties.ValueMember = "ID";

        }
        private void ResimEkle_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            SqlCommand detay2 = new SqlCommand("Select Path from Fotograf where RaporID = '" + gridLookUpEdit1.EditValue + "'", bgl.baglanti());
            SqlDataReader dre = detay2.ExecuteReader();
            while (dre.Read())
            {
                fotoname = dre["Path"].ToString();
            }

            bul();
        }
        string ftpfullpath, yeniyol;
        void fotokaydet()
        {
            try
            {
                //string yol;
                //yol = pictureEdit1.GetLoadedImageLocation();
                //MessageBox.Show(yol + dateTime.EditValue);

                if (name == null || name == "")
                {

                }
                else
                {
                    string isim = Path.GetFileName(name);
                    //yenisim = lbl_rapno.Text + " - " + isim;
                    File.Copy(name, Path.Combine(@Anasayfa.kpath, isim), true);
                    //using (var client = new WebClient())
                    //{
                    //    string ftpUsername = "massgrup";
                    //    string ftpPassword = "!88n2ee5Q";
                    //    ftpfullpath = "ftp://" + "www.massgrup.com/httpdocs/mask/Numune/Fotov2" + "/" + isim;
                    //    yeniyol = "http://" + "www.massgrup.com/mask/Numune/Fotov2" + "/" + isim;
                    //    client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                    //    client.UploadFile(ftpfullpath, name);

                    //}

                    //  File.Copy(name, Path.Combine(@"\\WDMyCloud\Numune\2020\Foto", yenisim), true);
                    //  string yol = Path.Combine(@"C:\Users\X260\Desktop\Yeni Klasör", yenisim);
                    //string yol = Path.Combine(@"\\WDMyCloud\Numune\2020\Foto", yenisim);
                    //File.Copy(name, yol, true);


                    SqlCommand ekle = new SqlCommand("insert into Fotograf(RaporID,Path) values(@d1,@d2)", bgl.baglanti());
                    ekle.Parameters.AddWithValue("@d1", gridLookUpEdit1.EditValue);
                    ekle.Parameters.AddWithValue("@d2", isim);
                    ekle.ExecuteNonQuery();
                    bgl.baglanti().Close();

                }




                // Fotograf db sine kaydedilir bundan sonra..

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata 124134: " + ex);
            }
        }
        string name, fotoname, isim;
        void sec()
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

        void bul()
        {
            try
            {
                if (fotoname == null || fotoname == "")
                {
                    //string logo = @"http://www.massgrup.com/mask/Numune/Fotov2/Logo.jpg";
                    //string logo = @"O:\Drive'ım\mKYS\Fotograf";
                    //pictureEdit1.Image = new Bitmap(logo);
                    //string yol = @"O:\Drive'ım\mKYS\Fotograf\" + "logo.jpg";
                    string yol = Path.Combine(@Anasayfa.kpath, "logo.jpg");
                    //MessageBox.Show(yol);
                    pictureEdit1.LoadAsync(yol);
                }
                else
                {
                    //string yol = @"http://www.massgrup.com/mask/Numune/Fotov2/" + fotoname;
                    ////   pictureEdit1.Image = new Bitmap(yol);

                    //var request = WebRequest.Create(yol);
                    //using (var response = request.GetResponse())
                    //using (var stream = response.GetResponseStream())
                    //{ pictureEdit1.Image = Bitmap.FromStream(stream); }

                    string yol = Path.Combine(@Anasayfa.kpath, fotoname);
                    pictureEdit1.LoadAsync(yol);


                }
            }
            catch (Exception)
            {

            }
        }

        void resimguncelle()
        {
            isim = Path.GetFileName(name);
            //yenisim = txtRapor.Text + " - " + isim;
            //  File.Copy(name, Path.Combine(@"\\WDMyCloud\Numune\2020\Foto", yenisim), true);
            //  string yol = Path.Combine(@"C:\Users\X260\Desktop\Yeni Klasör", yenisim);
            //string yol = Path.Combine(@"\\WDMyCloud\Numune\2020\Foto", yenisim);
            //File.Copy(name, yol, true);
      //      string isim = Path.GetFileName(name);
            //yenisim = lbl_rapno.Text + " - " + isim;
            File.Copy(name, Path.Combine(@Anasayfa.kpath, isim), true);

            //using (var client = new WebClient())
            //{
            //    string ftpUsername = "massgrup";
            //    string ftpPassword = "!88n2ee5Q";
            //    ftpfullpath = "ftp://" + "www.massgrup.com/httpdocs/mask/Numune/Fotov2" + "/" + isim;
            //    yeniyol = "http://" + "www.massgrup.com/mask/Numune/Fotov2" + "/" + isim;
            //    client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
            //    // client.UploadFile(ftpfullpath, WebRequestMethods.Ftp.UploadFile, name);
            //    client.UploadFile(ftpfullpath, name);
            //}

                SqlCommand komut = new SqlCommand("update Fotograf set Path=@t1 where RaporID = N'" + gridLookUpEdit1.EditValue + "'", bgl.baglanti());
                komut.Parameters.AddWithValue("@t1", isim);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
            


            //pictureEdit1.Image = new Bitmap(yeniyol);

            //var request = WebRequest.Create(yeniyol);
            //using (var response = request.GetResponse())
            //using (var stream = response.GetResponseStream())
            //{ pictureEdit1.Image = Bitmap.FromStream(stream); }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //sec
            sec();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //kaydet
            if (fotoname == null || fotoname == "")
            {
                fotokaydet();
            }
            else
            {
               // sec();
                resimguncelle();
            }
        }
    }
}
