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

namespace mKYS.Dokuman
{
    public partial class DokumanYeni : Form
    {
        public DokumanYeni()
        {
            InitializeComponent();
        }


        sqlbaglanti bgl = new sqlbaglanti();

        public void detaybul()
        {
            SqlCommand komutID = new SqlCommand("Select * From DokumanMaster where ID = '" + dID + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                txt_tur.Text = drI["Tur"].ToString();
                txt_ad.Text = drI["Ad"].ToString();
                txt_kod.Text = drI["Kod"].ToString();
                date_yayin.EditValue = Convert.ToDateTime(drI["YayinTarihi"].ToString());
                txt_rev.Text = drI["RevNo"].ToString();
                date_rev.Text = drI["RevTarihi"].ToString();
                combo_durum.Text = drI["Durumu"].ToString();
            }
            bgl.baglanti().Close();
        }

        public static string gelis, dID;

        string filekontrol, name, count, revdurum, revno, path, isim;
        void kontrol()
        {
            SqlCommand detayd = new SqlCommand("Select * from DokumanMaster where ID = N'" + dID + "'", bgl.baglanti());
            SqlDataReader drde = detayd.ExecuteReader();
            while (drde.Read())
            {
                filekontrol = drde["Path"].ToString();

            }
            bgl.baglanti().Close();
        }

        DokumanMaster m = (DokumanMaster)System.Windows.Forms.Application.OpenForms["DokumanMaster"];

        private void btn_yukle_Click(object sender, EventArgs e)
        {
            if (btn_yukle.Text == "Güncelle")
            {
                guncelle();
            }
            else
            {
                ekleme();
            }
        }
    
        private void txt_rev_KeyPress(object sender, KeyPressEventArgs e)
        {
            // e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44)
            // text'e sadece sayıların girmesi,geri silme tuşu(ascii kodu:08),virgül(ascii kodu:44) karakterinin girilmesini sağlar.
            //del tuşununda aktif olmasını isterseniz del ascıı kodu:127
            //
            {
                e.Handled = true;
            }
        }

        string ftpfullpath, yeniyol;
        private void btn_sec_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            open.InitialDirectory = path;
            //Your opendialog box title name.
            open.Title = "Yüklemek istediğiniz dosyayı seçiniz.";
            //which type file format you want to upload in database. just add them.
            open.Filter = "Select Valid Document(*.pdf; *.doc; *.xlsx; *.html)|*.pdf; *.docx; *.xlsx; *.html";
            //FilterIndex property represents the index of the filter currently selected in the file dialog box.
            open.FilterIndex = 1;
            try
            {
                if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (open.CheckFileExists)
                    {
                        name = System.IO.Path.GetFullPath(open.FileName);
                        lbl_bas.Visible = true;
                        lbl_bas.Text = "Seçim Başarılı!";
                        count = "1";
                    }

                    //isim = Path.GetFileName(name);
                    //path = txt_kod.Text + "-" + revno + ".pdf";
                    //using (var client = new WebClient())
                    //{
                    //    //path = txt_kod.Text + "-" + revno + ".pdf";
                    //    //File.Copy(name, Path.Combine(@Anasayfa.kpath, path), true);
                    //    string ftpUsername = "massgrup";
                    //    string ftpPassword = "!88n2ee5Q";
                    //    ftpfullpath = "ftp://" + "www.rootarge.com/httpdocs/cosmo/Raporlar" + "/" + path;
                    //    yeniyol = "http://" + "www.rootarge.com/cosmo/Raporlar" + "/" + path;
                    //    client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                    //    // client.UploadFile(ftpfullpath, WebRequestMethods.Ftp.UploadFile, name);
                    //    client.UploadFile(@Anasayfa.kpath, name);
                    //}


                }
                else
                {
                    MessageBox.Show("Lütfen dosya seçiniz.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DokumanYeni_FormClosing(object sender, FormClosingEventArgs e)
        {
            gelis = null;
            dID = null;
        }

        private void DokumanYeni_Load(object sender, EventArgs e)
        {
            if (gelis == "" || gelis == null)
            {

            }
            else
            {
                detaybul();
                kontrol();
                Text = "Doküman Bilgi Güncelleme";
                btn_yukle.Text = "Güncelle";
                if (filekontrol == "" || filekontrol == null)
                {
                    lbl_bas.Visible = true;
                    lbl_bas.Text = "Henüz doküman yüklenmemiş!";
                }
                else
                {
                    lbl_bas.Visible = true;
                    lbl_bas.Text = "Doküman yüklenmiş!";
                }
            }
        }

        void guncelle()
        {
            try
            {
                if (date_rev.Text == "" || date_rev.Text == null)
                    revdurum = "--.--.--";
                else
                    revdurum = date_rev.Text.ToString();


                if (txt_rev.Text == "" || txt_rev.Text == null)
                    revno = "0";
                else
                    revno = txt_rev.Text;

                kontrol();
                if (filekontrol == "" || filekontrol == null)
                {
                    if (count == "1")
                    {
                        path = txt_kod.Text + "-" + revno + ".pdf";
                       // File.Copy(name, Path.Combine(@Anasayfa.kpath, path), true);
                        File.Copy(name, Path.Combine("\\\\DESKTOP-UCOU692\\Dokuman", path), true);

                        SqlCommand add = new SqlCommand("update DokumanMaster set Tur = @a1, Kod = @a2, Ad=@a3, YayinTarihi = @a4, RevNo = @a5, Durumu = @a6, " +
                            " Path = @a7, RevTarihi = @a8 where ID = '" + dID + "'", bgl.baglanti());
                        add.Parameters.AddWithValue("@a1", txt_tur.Text);
                        add.Parameters.AddWithValue("@a2", txt_kod.Text);
                        add.Parameters.AddWithValue("@a3", txt_ad.Text);
                        add.Parameters.AddWithValue("@a4", date_yayin.EditValue);
                        add.Parameters.AddWithValue("@a5", revno);
                        add.Parameters.AddWithValue("@a6", combo_durum.Text);
                        add.Parameters.AddWithValue("@a7", path);
                        add.Parameters.AddWithValue("@a8", revdurum);
                        add.ExecuteNonQuery();
                        bgl.baglanti().Close();


                    }
                    else
                    {
                        SqlCommand add = new SqlCommand("update DokumanMaster set Tur = @a1, Kod = @a2, Ad=@a3, YayinTarihi = @a4, RevNo = @a5, Durumu = @a6, " +
                              " RevTarihi = @a8 where ID = '" + dID + "'", bgl.baglanti());
                        add.Parameters.AddWithValue("@a1", txt_tur.Text);
                        add.Parameters.AddWithValue("@a2", txt_kod.Text);
                        add.Parameters.AddWithValue("@a3", txt_ad.Text);
                        add.Parameters.AddWithValue("@a4", date_yayin.EditValue);
                        add.Parameters.AddWithValue("@a5", revno);
                        add.Parameters.AddWithValue("@a6", combo_durum.Text);
                        add.Parameters.AddWithValue("@a8", revdurum);
                        add.ExecuteNonQuery();
                        bgl.baglanti().Close();
                    }
                }
                else
                {
                    if (count == "1")
                    {
                        DialogResult Secim = new DialogResult();
                        Secim = MessageBox.Show("Bu doküman daha önce yüklenmiş. Güncellemek mi istiyorsunuz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (Secim == DialogResult.Yes)
                        {
                            path = txt_kod.Text + "-" + revno + ".pdf";
                          //  File.Copy(name, Path.Combine(@Anasayfa.kpath, path), true);
                            File.Copy(name, Path.Combine("\\\\DESKTOP-UCOU692\\Dokuman", path), true);
                            SqlCommand add = new SqlCommand("update DokumanMaster set Tur = @a1, Kod = @a2, Ad=@a3, YayinTarihi = @a4, RevNo = @a5, Durumu = @a6, " +
                                " Path = @a7, RevTarihi = @a8 where ID = '" + dID + "'", bgl.baglanti());
                            add.Parameters.AddWithValue("@a1", txt_tur.Text);
                            add.Parameters.AddWithValue("@a2", txt_kod.Text);
                            add.Parameters.AddWithValue("@a3", txt_ad.Text);
                            add.Parameters.AddWithValue("@a4", date_yayin.EditValue);
                            add.Parameters.AddWithValue("@a5", revno);
                            add.Parameters.AddWithValue("@a6", combo_durum.Text);
                            add.Parameters.AddWithValue("@a7", path);
                            add.Parameters.AddWithValue("@a8", revdurum);
                            add.ExecuteNonQuery();
                            bgl.baglanti().Close();
                        }
                        else
                        {
                            count = "0";
                        }

                    }
                    else
                    {
                        SqlCommand add = new SqlCommand("update DokumanMaster set Tur = @a1, Kod = @a2, Ad=@a3, YayinTarihi = @a4, RevNo = @a5, Durumu = @a6, " +
                              " RevTarihi = @a8 where ID = '" + dID + "'", bgl.baglanti());
                        add.Parameters.AddWithValue("@a1", txt_tur.Text);
                        add.Parameters.AddWithValue("@a2", txt_kod.Text);
                        add.Parameters.AddWithValue("@a3", txt_ad.Text);
                        add.Parameters.AddWithValue("@a4", date_yayin.EditValue);
                        add.Parameters.AddWithValue("@a5", revno);
                        add.Parameters.AddWithValue("@a6", combo_durum.Text);
                        add.Parameters.AddWithValue("@a8", revdurum);
                        add.ExecuteNonQuery();
                        bgl.baglanti().Close();
                    }
                }

                if (Application.OpenForms["DokumanMaster"] == null)
                { }
                else
                {
                    m.listele();
                }

                MessageBox.Show("Dokümanınız başarı ile güncellendi! ", "Oopppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata G1:" + ex);
            }

        }

        void ekleme()
        {
            try
            {
                if (date_rev.Text == "" || date_rev.Text == null)
                    revdurum = "--.--.--";
                else
                    revdurum = date_rev.Text.ToString();


                if (txt_rev.Text == "" || txt_rev.Text == null)
                    revno = "0";
                else
                    revno = txt_rev.Text;

                if (count == "1")
                {
                    path = txt_kod.Text + "-" + revno + ".pdf";
                    //File.Copy(name, Path.Combine(@Anasayfa.kpath, path), true);
                    File.Copy(name, Path.Combine("\\\\DESKTOP-UCOU692\\Dokuman" , path), true);

                    SqlCommand add = new SqlCommand("insert into DokumanMaster(Tur,Kod,Ad,YayinTarihi,RevNo,Durumu,Durum,RevTarihi,Path) values (@a1,@a2,@a3,@a4,@a5,@a6,@a8,@a9,@a10)", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", txt_tur.Text);
                    add.Parameters.AddWithValue("@a2", txt_kod.Text);
                    add.Parameters.AddWithValue("@a3", txt_ad.Text);
                    add.Parameters.AddWithValue("@a4", date_yayin.EditValue);
                    add.Parameters.AddWithValue("@a5", revno);
                    add.Parameters.AddWithValue("@a6", combo_durum.Text);
                    add.Parameters.AddWithValue("@a8", "Aktif");
                    add.Parameters.AddWithValue("@a9", revdurum);
                    add.Parameters.AddWithValue("@a10", path);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }
                else
                {
                    path = null;

                    SqlCommand add = new SqlCommand("insert into DokumanMaster(Tur,Kod,Ad,YayinTarihi,RevNo,Durumu,Durum,RevTarihi) values (@a1,@a2,@a3,@a4,@a5,@a6,@a8,@a9)", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", txt_tur.Text);
                    add.Parameters.AddWithValue("@a2", txt_kod.Text);
                    add.Parameters.AddWithValue("@a3", txt_ad.Text);
                    add.Parameters.AddWithValue("@a4", date_yayin.EditValue);
                    add.Parameters.AddWithValue("@a5", revno);
                    add.Parameters.AddWithValue("@a6", combo_durum.Text);
                    add.Parameters.AddWithValue("@a8", "Aktif");
                    add.Parameters.AddWithValue("@a9", revdurum);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }




                if (Application.OpenForms["DokumanMaster"] == null)
                { }
                else
                {
                    m.listele();
                }


                DialogResult Secim = new DialogResult();
                Secim = MessageBox.Show("Dokümanınız başarı ile kaydedildi. Yeni bir doküman daha kaydetmek ister misiniz ? ", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (Secim == DialogResult.Yes)
                {
                    txt_tur.Text = "";
                    txt_ad.Text = "";
                    txt_kod.Text = "";
                    txt_rev.Text = "";
                    date_rev.Text = "";
                    date_yayin.Text = "";
                    lbl_bas.Visible = false;
                    count = "0";
                }
                else
                {
                    this.Close();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata D1:" + ex);
            }
        }


    }
}
