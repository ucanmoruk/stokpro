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
    public partial class RaporYukle : Form
    {
        public RaporYukle()
        {
            InitializeComponent();
        }


        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select ID, Firma_Adi from Firma where Durum = 'Aktif' order by Firma_Adi", bgl.baglanti());
            da.Fill(dt);

            gridLookUpEdit1.Properties.DataSource = dt;
            gridLookUpEdit1.Properties.DisplayMember = "Firma_Adi";
            gridLookUpEdit1.Properties.ValueMember = "ID";


            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select ID, Firma_Adi from Firma where Durum = 'Aktif' and Tur = 'Proje' order by Firma_Adi", bgl.baglanti());
            da2.Fill(dt2);

            gridLookUpEdit2.Properties.DataSource = dt2;
            gridLookUpEdit2.Properties.DisplayMember = "Firma_Adi";
            gridLookUpEdit2.Properties.ValueMember = "ID";
        }


        RaporMaster m = (RaporMaster)System.Windows.Forms.Application.OpenForms["RaporMaster"];

        private void btn_yukle_Click(object sender, EventArgs e)
        {
            ekleme();
        }
    
      




        private void DokumanYeni_Load(object sender, EventArgs e)
        {
            date_now.EditValue = DateTime.Now;
            listele();
            gridLookUpEdit2.EditValue = 5487;
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


        string name, path, yeniyol, count, parola, ftpfullpath;
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
        void ekleme()
        {
            try
            {
               
                if (count == "1")
                {
                    //char[] cr = "0123456789abcdefghijklmnopqrstuvwxyz".ToCharArray();
                    //string result = string.Empty;
                    //Random r = new Random();
                    //parola += cr[r.Next(0, cr.Length - 1)].ToString();

                    //for (int i = 0; i < 6; i++)
                    //{
                    //    parola += cr[r.Next(0, cr.Length - 1)].ToString();
                    //}


                    Random rastgele = new Random();
                    string harfler = "0123456789ABCDEFGHIJKLMNOPRSTUVYZabcdefghijklmnoprstuvyz";
                    parola = "";
                    for (int i = 0; i < 6; i++)
                    {
                        parola += harfler[rastgele.Next(harfler.Length)];
                    }
                    

                    //     yeniyol = "..";

                    //  isim = Path.GetFileName(name);
                    path = trapor.Text + "-" + parola + ".pdf";
                 
                  
                    using (var client = new WebClient())
                    {

                        string ftpUsername = "cosm8617";
                        string ftpPassword = "6627168f9aT";      
                        ftpfullpath = "ftp://" + "www.cosmoliz.com/portal.cosmoliz.com/raporlar" + "/" + path;
                        // yeniyol = "http://" + "www.portal.cosmoliz.com/cosmo/Raporlar" + "/" + path;
                        client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                        client.UploadFile(ftpfullpath, WebRequestMethods.Ftp.UploadFile, name);
                      //  client.UploadFile(@Anasayfa.kpath, name);
                    }

                  //  File.Copy(name, Path.Combine(yeniyol, path), true);

                    SqlCommand add = new SqlCommand("insert into Rapor (RaporNo, TalepNo, RaporID, FirmaID, ProjeID, NumuneTur, NumuneAd, Tarih, Yol, Durum) values(@a1, @a2, @a3, @a4, @a5, @a6, @a7, @a8, @a9, @a10)", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", trapor.Text);
                    add.Parameters.AddWithValue("@a2", ttalep.Text);
                    add.Parameters.AddWithValue("@a3", parola);
                    add.Parameters.AddWithValue("@a4", gridLookUpEdit1.EditValue);
                    add.Parameters.AddWithValue("@a5", gridLookUpEdit2.EditValue);
                    add.Parameters.AddWithValue("@a6", ctur.Text);
                    add.Parameters.AddWithValue("@a7", tad.Text);
                    add.Parameters.AddWithValue("@a8", date_now.EditValue);
                    add.Parameters.AddWithValue("@a9", path);
                    add.Parameters.AddWithValue("@a10", "Aktif");
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    DialogResult Secim = new DialogResult();
                    Secim = MessageBox.Show("Dosya başarı ile yüklendi. Yeni bir dosya daha yüklemek ister misiniz ? ", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (Secim == DialogResult.Yes)
                    {
                        trapor.Text = "";
                        tad.Text = "";
                        ttalep.Text = "";
                        count = "0";
                    }
                    else
                    {
                        this.Close();
                    }

                    if (Application.OpenForms["RaporMaster"] == null)
                    { }
                    else
                    {
                        m.listele();
                    }


                }
                else
                {
                    MessageBox.Show("Lütfen dosya seçiniz!");
                }



            

              
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata D1:" + ex);
            }
        }


    }
}
