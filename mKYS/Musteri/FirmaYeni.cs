using BusinessLayer.Services;
using BusinessLayer.ViewModels;
using System;
using System.Data;
using System.Windows.Forms;

namespace mKYS.Musteri
{
    public partial class FirmaYeni : Form
    {
        public bool isUpdated = false;
        public int firmaUpdateID = 0;
        FirmaService firmaService = new FirmaService(Giris.sqlTip);
        FirmaVM firmaVMEski;
        FirmaVM firmaVMYeni;
       
        public FirmaYeni()
        {
            InitializeComponent();
        }

        private void FirmaYeni_Load(object sender, EventArgs e)
        {
            DataTable dt = firmaService.SelectText("select ID, Kadi, Ad, Soyad from StokKullanici");
            gridLookUpEdit1.Properties.DataSource = dt;
            gridLookUpEdit1.Properties.DisplayMember = "Kadi";
            gridLookUpEdit1.Properties.ValueMember = "ID";

            firmaVMEski = firmaService.Get("ID = @param1", firmaUpdateID);
            firmaVMYeni = firmaService.Get("ID = @param1", firmaUpdateID);

            if (isUpdated)
            {
                combo_tur.SelectedItem = firmaVMYeni.Tur;
                txt_sektor.Text = firmaVMYeni.Sektor;
                txt_firmaad.Text = firmaVMYeni.Firma_Adi;
                txt_adres.Text = firmaVMYeni.Adres;
                txt_vergid.Text = firmaVMYeni.Vergi_Dairesi;
                txt_vergino.Text = firmaVMYeni.Vergi_No;
                txt_telefon.Text = firmaVMYeni.Telefon;
                txt_Mail.Text = firmaVMYeni.Mail;
                txt_not.Text = firmaVMYeni.Hizmet;
                txt_vade.Text = firmaVMYeni.Vade;
                gridLookUpEdit1.EditValue = firmaVMYeni.PlasiyerID;
                combo_odeme.SelectedItem = firmaVMYeni.Odeme;
            }
        }

        private void button_ekle_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_firmaad.Text) || string.IsNullOrWhiteSpace(txt_firmaad.Text))
            {
                MessageBox.Show("Firma Adını Boş Bırakamazsınız!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (combo_odeme.SelectedIndex < 0)
            {
                MessageBox.Show("Ödeme Türünü Boş Bırakamazsınız!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToInt32(gridLookUpEdit1.EditValue) < 0)
            {
                MessageBox.Show("Plasiyeri Boş Bırakamazsınız!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                firmaVMYeni.Firma_Adi = txt_firmaad.Text.Trim();
                firmaVMYeni.Plasiyer = gridLookUpEdit1.Text.Trim();
                firmaVMYeni.PlasiyerID = Convert.ToInt32(gridLookUpEdit1.EditValue);
                firmaVMYeni.Odeme = combo_odeme.Text.Trim();

                if (combo_tur.SelectedIndex < 0)
                {
                    firmaVMYeni.Tur = "";
                }
                else
                {
                    firmaVMYeni.Tur = combo_tur.Text;
                }

                if (string.IsNullOrEmpty(txt_sektor.Text) || string.IsNullOrWhiteSpace(txt_sektor.Text))
                {
                    firmaVMYeni.Sektor = "";
                }
                else
                {
                    firmaVMYeni.Sektor = txt_sektor.Text.Trim();
                }

                if (string.IsNullOrEmpty(txt_adres.Text) || string.IsNullOrWhiteSpace(txt_adres.Text))
                {
                    firmaVMYeni.Adres = "";
                }
                else
                {
                    firmaVMYeni.Adres = txt_adres.Text.Trim();
                }

                if (string.IsNullOrEmpty(txt_vergid.Text) || string.IsNullOrWhiteSpace(txt_vergid.Text))
                {
                    firmaVMYeni.Vergi_Dairesi = "";
                }
                else
                {
                    firmaVMYeni.Vergi_Dairesi = txt_vergid.Text.Trim();
                }

                if (string.IsNullOrEmpty(txt_vergino.Text) || string.IsNullOrWhiteSpace(txt_vergino.Text))
                {
                    firmaVMYeni.Vergi_No = "";
                }
                else
                {
                    firmaVMYeni.Vergi_No = txt_vergino.Text.Trim();
                }

                if (string.IsNullOrEmpty(txt_telefon.Text) || string.IsNullOrWhiteSpace(txt_telefon.Text))
                {
                    firmaVMYeni.Telefon = "";
                }
                else
                {
                    firmaVMYeni.Telefon = txt_telefon.Text.Trim();
                }
                
                if (string.IsNullOrEmpty(txt_Mail.Text) || string.IsNullOrWhiteSpace(txt_Mail.Text))
                {
                    firmaVMYeni.Mail = "";
                }
                else
                {
                    firmaVMYeni.Mail = txt_Mail.Text.Trim();
                }
               
                if (string.IsNullOrEmpty(txt_not.Text) || string.IsNullOrWhiteSpace(txt_not.Text))
                {
                    firmaVMYeni.Hizmet = "";
                }
                else
                {
                    firmaVMYeni.Hizmet = txt_not.Text.Trim();
                }
                
                if (string.IsNullOrEmpty(txt_vade.Text) || string.IsNullOrWhiteSpace(txt_vade.Text))
                {
                    firmaVMYeni.Vade = "";
                }
                else
                {
                    firmaVMYeni.Vade = txt_vade.Text.Trim();
                }             


                if (isUpdated)
                {
                    if(Convert.ToInt32( firmaService.SelectText("select count(*) from Firma where Firma_Adi = @param1 and ID <> @param2", firmaVMYeni.Firma_Adi, firmaVMYeni.ID).Rows[0][0]) > 0)
                    {
                        MessageBox.Show("Bu Firma Adı Zaten Kayıtlı!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (firmaService.Update(firmaVMYeni))
                        {
                            MessageBox.Show("Firma Bilgileri Başarıyla Güncellendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("İşlem Başarısız!\n Bilgileri Kontrol Edip Tekrar Deneyiniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    firmaVMYeni.Yetkili = "";
                    firmaVMYeni.Parola = parolaolustur();
                    firmaVMYeni.Durum = "Aktif";
                    firmaVMYeni.Kod = "MS" + firmaService.SelectText("select max(ID) from Firma").Rows[0][0].ToString();

                    if (Convert.ToInt32(firmaService.SelectText("select count(*) from Firma where Firma_Adi = @param1", firmaVMYeni.Firma_Adi).Rows[0][0]) > 0)
                    {
                        MessageBox.Show("Bu Firma Adı Zaten Kayıtlı!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        int firmaID = firmaService.Insert(firmaVMYeni);
                        if (firmaID > 0)
                        {
                            MessageBox.Show("Firma Bilgileri Başarıyla Kaydedildi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Yetkili yetkili = new Yetkili();
                            yetkili.firmaID = firmaID;
                            yetkili.firmaAdi = firmaVMYeni.Firma_Adi;
                            yetkili.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("İşlem Başarısız!\n Bilgileri Kontrol Edip Tekrar Deneyiniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    
                }
            }
            
        }

        public string parolaolustur()
        {
            string parola = "";
            char[] cr = "0123456789abcdefghijklmnopqrstuvwxyz".ToCharArray();
            string result = string.Empty;
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                parola += cr[r.Next(0, cr.Length - 1)].ToString();
            }

            return parola;
        }


    }
}
