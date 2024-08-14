using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mKYS.Dokuman
{
    public partial class DKDEkle : Form
    {
        public DKDEkle()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        string dkkont;
        void detaybul()
        {
            SqlCommand komutID = new SqlCommand("Select * From StokDKDListe where ID = '"+dkdID+"' ", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                txt_aciklama.Text = drI["Tur"].ToString();
                txt_dokuman.Text = drI["Ad"].ToString();
                txt_kod.Text = drI["Kod"].ToString();
                txt_kaynak.Text = drI["Kaynak"].ToString(); 
                txt_tarih.Text = drI["Tarih"].ToString(); 
                txt_link.Text = drI["Link"].ToString();
                dkkont = drI["Path"].ToString();
                combo_birim.Text = drI["Birim"].ToString();

            }
            bgl.baglanti().Close();
        }

        private void birimbul()
        {
            SqlCommand komutID = new SqlCommand("Select * From StokFirmaBirim where Durum=N'Aktif' and FirmaID = N'" + Anasayfa.firmaID + "' order by Birim", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                combo_birim.Properties.Items.Add(drI["Birim"].ToString());
            }
            bgl.baglanti().Close();
        }

        public static string dkdkod, dkdad, dkdID;
        private void DKDEkle_Load(object sender, EventArgs e)
        {
            birimbul();
            
            if (dkdID == "" || dkdID == null)
            {

            }
            else
            {
                detaybul();
                btn_ekle.Text = "Güncelle";
            }
        }

        DKDListe m = (DKDListe)System.Windows.Forms.Application.OpenForms["DKDListe"];

        public static string name;
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
                        btn_sec.Enabled = false;
                        lbl_bas.Visible = true;
                    }
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

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            if (btn_ekle.Text == "Güncelle")
            {
                guncelle();
                //if (Application.OpenForms["DKDListe"] == null)
                //{ }
                //else
                //{ m.listele(); }
            }
            else
            {
                ekle();
                //if (Application.OpenForms["DKDListe"] == null)
                //{ }
                //else
                //{ m.listele(); }
            }

            MessageBox.Show("İşlem başarılı!");
        }

        void temizle()
        {
            txt_aciklama.Text = "";
            txt_dokuman.Text = "";
            txt_kod.Text = "";
            txt_kaynak.Text = "";
            txt_tarih.Text = "";
            txt_link.Text = "";
            combo_birim.Text = "";
        }

        void ekle()
        {
            dokekle();

            SqlCommand add = new SqlCommand("insert into StokDKDListe(Tur, Kaynak, Kod, Ad, Tarih, Path, Link, Durum,Birim) values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9)", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", txt_aciklama.Text);
            add.Parameters.AddWithValue("@a2", txt_kaynak.Text);
            add.Parameters.AddWithValue("@a3", txt_kod.Text);
            add.Parameters.AddWithValue("@a4", txt_dokuman.Text);
            add.Parameters.AddWithValue("@a5", txt_tarih.Text);
            add.Parameters.AddWithValue("@a6", path);
            add.Parameters.AddWithValue("@a7", txt_link.Text);
            add.Parameters.AddWithValue("@a8", "Aktif");
            add.Parameters.AddWithValue("@a9", combo_birim.Text);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Doküman ekleme işlemi başarılı.", "Ooppss!",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            temizle();
        }

        string path;
        void dokekle()
        {
            if (btn_sec.Enabled == false)
            {
                string isim = Path.GetFileName(name);
                if (isim == null)
                {
                    MessageBox.Show("Lütfen geçerli bir doküman seçiniz.", "Oooppss!!");
                }
                else
                {
                    path = txt_kod.Text + "-" + txt_tarih.Text + ".pdf";
                   // File.Copy(name, Path.Combine(@Anasayfa.kpath, path), true);
                    File.Copy(name, Path.Combine("\\\\DESKTOP-UCOU692\\Dokuman" , path), true);
                }
            }
            else
            {
                path = "";
            }
            
        }

        void guncelle()
        {
            if (dkkont == "" || dkkont == null)
            {
                dokekle();

                SqlCommand add = new SqlCommand("update StokDKDListe set Tur=@a1, Kaynak=@a2, Kod=@a3, Ad=@a4, Tarih=@a5, Path=@a6, Link=@a7, Birim=@a8 where ID = '"+dkdID+"'", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", txt_aciklama.Text);
                add.Parameters.AddWithValue("@a2", txt_kaynak.Text);
                add.Parameters.AddWithValue("@a3", txt_kod.Text);
                add.Parameters.AddWithValue("@a4", txt_dokuman.Text);
                add.Parameters.AddWithValue("@a5", txt_tarih.Text);
                add.Parameters.AddWithValue("@a6", path);
                add.Parameters.AddWithValue("@a7", txt_link.Text);
                add.Parameters.AddWithValue("@a8", combo_birim.Text);
                add.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Doküman güncelleme işlemi başarılı.", "Ooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                if (btn_sec.Enabled == false)
                {
                    DialogResult Secim = new DialogResult();
                    Secim = MessageBox.Show("Bu doküman daha önce yüklenmiş. Güncellemek mi istiyorsunuz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (Secim == DialogResult.Yes)
                    {
                        dokekle();

                        SqlCommand add = new SqlCommand("update StokDKDListe set Tur=@a1, Kaynak=@a2, Kod=@a3, Ad=@a4, Tarih=@a5, Path=@a6, Link=@a7, Birim=@a8 where ID = '" + dkdID + "'", bgl.baglanti());
                        add.Parameters.AddWithValue("@a1", txt_aciklama.Text);
                        add.Parameters.AddWithValue("@a2", txt_kaynak.Text);
                        add.Parameters.AddWithValue("@a3", txt_kod.Text);
                        add.Parameters.AddWithValue("@a4", txt_dokuman.Text);
                        add.Parameters.AddWithValue("@a5", txt_tarih.Text);
                        add.Parameters.AddWithValue("@a6", path);
                        add.Parameters.AddWithValue("@a7", txt_link.Text);
                        add.Parameters.AddWithValue("@a8", combo_birim.Text);
                        add.ExecuteNonQuery();
                        bgl.baglanti().Close();
                    }
                    else
                    {
                        MessageBox.Show("Doküman güncelleme yapmak istemiyorsanız, lütfen seçim yapmadan tekrar deneyiniz.", "Ooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    }
                }
                else
                {

                    SqlCommand add = new SqlCommand("update StokDKDListe set Tur=@a1, Kaynak=@a2, Kod=@a3, Ad=@a4, Tarih=@a5, Link=@a7, Birim=@a8 where ID = '" + dkdID + "'", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", txt_aciklama.Text);
                    add.Parameters.AddWithValue("@a2", txt_kaynak.Text);
                    add.Parameters.AddWithValue("@a3", txt_kod.Text);
                    add.Parameters.AddWithValue("@a4", txt_dokuman.Text);
                    add.Parameters.AddWithValue("@a5", txt_tarih.Text);
                    add.Parameters.AddWithValue("@a7", txt_link.Text);
                    add.Parameters.AddWithValue("@a8", combo_birim.Text);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    MessageBox.Show("Doküman güncelleme işlemi başarılı.", "Ooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
            }
        }
        
        private void DKDEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            dkdkod = "";
            dkdID = null;
        }
    }
}
