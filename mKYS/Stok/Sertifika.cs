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

namespace mKYS
{
    public partial class Sertifika : Form
    {
        public Sertifika()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();


        void glistele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select ID, Birim from StokFirmaBirim where Durum= 'Aktif'", bgl.baglanti());
            da2.Fill(dt2);

            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "Birim";
            gridLookUpEdit1.Properties.ValueMember = "ID";

            DataTable dt4 = new DataTable();
            SqlDataAdapter da4 = new SqlDataAdapter("Select ID, Kod, Ad from StokListesi where Durum= 'Aktif'", bgl.baglanti());
            da4.Fill(dt4);

            gridLookUpEdit2.Properties.DataSource = dt4;
            gridLookUpEdit2.Properties.DisplayMember = "Kod";
            gridLookUpEdit2.Properties.ValueMember = "ID";
        }


        //private void listele()
        //{
        //    SqlCommand komutID = new SqlCommand("Select * From StokListesi where Durum=N'Aktif'", bgl.baglanti());
        //    SqlDataReader drI = komutID.ExecuteReader();
        //    while (drI.Read())
        //    {
        //        combokod.Properties.Items.Add(drI["Kod"].ToString());
        //    }
        //    bgl.baglanti().Close();

        //}
        //private void birimbul()
        //{
        //    SqlCommand komutID = new SqlCommand("Select * From StokFirmaBirim where Durum=N'Aktif' and FirmaID = N'"+Anasayfa.firmaID+"'", bgl.baglanti());
        //    SqlDataReader drI = komutID.ExecuteReader();
        //    while (drI.Read())
        //    {
        //        combo_birim.Properties.Items.Add(drI["Birim"].ToString());
        //    }
        //    bgl.baglanti().Close();
        //}

        private void kbirim()
        {
            SqlCommand komutID = new SqlCommand("Select * From StokFirmaBirim where ID = N'" + Anasayfa.birimID + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
              //  combo_birim.Text = drI["Birim"].ToString();
                gridLookUpEdit1.EditValue = drI["ID"].ToString();
            }
            bgl.baglanti().Close();

        }

        private void parolaolustur()
        {
            char[] cr = "0123456789abcdefghijklmnopqrstuvwxyz".ToCharArray();
            string result = string.Empty;
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                parola += cr[r.Next(0, cr.Length - 1)].ToString();
            }
        }

        string yenisim, parola;
        private void ekleme()
        {
            try
            {
                string isim = Path.GetFileName(name);
                if (isim == null)
                {
                    MessageBox.Show("Lütfen geçerli bir doküman seçiniz.");
                }
                else
                {
                    if (gridLookUpEdit2.Text == "" || txtmarka.Text == "")
                    {
                        MessageBox.Show("Lütfen marka, lot veya skt tarihi belirtiniz!");
                    }
                    else
                    {
                        parolaolustur();
                        string path = gridLookUpEdit2.Text + "-" + txtmarka.Text + "-" + parola + ".pdf";
                        if (dateskt.Text == "")
                        {
                        DateTime tarih = DateTime.Now;
                        dateskt.EditValue = tarih;
                        yenisim = txtmarka.Text + "-" + txtlot.Text;
                        }
                        else
                        {
                        DateTime ptarih = DateTime.Parse(dateskt.Text);
                        string tarih = ptarih.ToShortDateString();
                        yenisim = txtmarka.Text + "-" + txtlot.Text + "-" + tarih;
                        }


                        //   File.Copy(name, Path.Combine(@"\\WDMyCloud\KYS_Uygulama\Belgelerim\Sertifikalar", path), true);
                        //   File.Copy(name, Path.Combine(@"H:\Drive'ım\Root_Satış", path), true);
                        File.Copy(name, Path.Combine(@Anasayfa.path, path), true);


                        SqlCommand add = new SqlCommand("insert into StokSertifika (StokID, Sertifika, SKT, Path, BirimID, Durum) values (@a1,@a2,@a3,@a4, @a5, @a6)", bgl.baglanti());
                        add.Parameters.AddWithValue("@a1", stokid);
                        add.Parameters.AddWithValue("@a2", yenisim);
                        add.Parameters.AddWithValue("@a3", dateskt.EditValue);
                        add.Parameters.AddWithValue("@a4", path);
                        add.Parameters.AddWithValue("@a5", birimID);
                        add.Parameters.AddWithValue("@a6", "Aktif");
                        add.ExecuteNonQuery();
                        bgl.baglanti().Close();


                        MessageBox.Show("Sertifika başarı ile yüklendi!", "Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        txtmarka.Text = "";
                        txtlot.Text = "";
                        dateskt.Text = "";
                        gridLookUpEdit2.Text = "";
                        btnsertifika.Enabled = true;
                    }
                    

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void detaybul()
        {
            SqlCommand komutID = new SqlCommand("Select ID From StokListesi where Kod = N'" + skod + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                //combo_birim.Text = drI["Birim"].ToString();
                gridLookUpEdit2.EditValue = drI["ID"].ToString();
            }
            bgl.baglanti().Close();

        }

        public static string skod;
        private void Sertifika_Load(object sender, EventArgs e)
        {
            if (skod == "" || skod == null)
            {
                //listele();
                //birimbul();
                glistele();
                kbirim();
            }
            else
            {
                //combokod.Text = skod;
                //    gridLookUpEdit2.EditValue = skod;
                
                //listele();
                //birimbul();
                glistele();
                kbirim();
                detaybul();
                //gridLookUpEdit2.EditValue = skod;
            }
           
        }

        public static string name;
        private void btnsertifika_Click(object sender, EventArgs e)

        {
            OpenFileDialog open = new OpenFileDialog();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //To where your opendialog box get starting location. My initial directory location is desktop.
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
                        btnsertifika.Enabled = false;
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

       
        //private void combokod_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    SqlCommand komutID = new SqlCommand("Select * From StokListesi where Kod = N'" + combokod.Text + "'", bgl.baglanti());
        //    SqlDataReader drI = komutID.ExecuteReader();
        //    while (drI.Read())
        //    {
        //        stokid = Convert.ToInt32(drI["ID"].ToString());
        //    }
        //    bgl.baglanti().Close();
        //}

        string birimID, stokid;
        //private void combo_birim_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    SqlCommand komutID = new SqlCommand("Select * From StokFirmaBirim where Birim = N'" + combo_birim.Text + "' and FirmaID = N'"+Anasayfa.firmaID+"'", bgl.baglanti());
        //    SqlDataReader drI = komutID.ExecuteReader();
        //    while (drI.Read())
        //    {
        //        birimID = Convert.ToInt32(drI["ID"].ToString());
        //    }
        //    bgl.baglanti().Close();
        //}

        private void gridLookUpEdit2_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void gridLookUpEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GridLookUpEdit edit = sender as GridLookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                gridLookUpEdit2.EditValue = null;

            }
        }

        private void gridLookUpEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GridLookUpEdit edit = sender as GridLookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                gridLookUpEdit1.EditValue = null;

            }
        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (gridLookUpEdit1.EditValue == null)
                birimID = null;
            else
                birimID = gridLookUpEdit1.EditValue.ToString();
        }

        private void gridLookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            if (gridLookUpEdit2.EditValue == null)
                stokid = null;
            else
                stokid = gridLookUpEdit2.EditValue.ToString();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            ekleme();
        }
    }
}
