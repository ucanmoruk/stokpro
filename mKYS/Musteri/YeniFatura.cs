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
using mKYS.Musteri;

namespace mKYS.Musteri
{
    public partial class YeniFatura : Form
    {
        public YeniFatura()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();

        public void Firma()
        {
            SqlCommand komut = new SqlCommand("Select Firma_Adi from Firma where Durum = 'Aktif'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                combo_faturafirma.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();

            SqlCommand komut1 = new SqlCommand("select Firma_Adi from Firma where ID in (select Firma_ID from NKR where Evrak_No = N'" + combo_evrak.Text + "') and Durum = 'Aktif'", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                combo_raporfirma.Text = dr1[0].ToString();
            }
            bgl.baglanti().Close();

            SqlCommand komutp = new SqlCommand("select Firma_Adi from Firma where Tur=N'Proje' and Durum= N'Aktif' order by Firma_Adi asc ", bgl.baglanti());
            SqlDataReader drp = komutp.ExecuteReader();
            while (drp.Read())
            {
                combo_proje.Properties.Items.Add(drp[0]);
            }
            bgl.baglanti().Close();

            SqlCommand komut3 = new SqlCommand("Select distinct Evrak_No from NKR where year(Tarih) = '2020'", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                combo_evrak.Properties.Items.Add(dr3[0]);
            }
            bgl.baglanti().Close();

        }

        void Temizle()
        {
            combo_faturafirma.Text = "";
            combo_proje.Text = "";
            txt_faturano.Text = "";
            dateEdit1.Text = "";
            txtTutar.Text = "";
        }

        private void txtTutar_TextChanged(object sender, EventArgs e)
        {
            if (txtTutar.Text != "")
            {
                decimal KDV = 0, Tutar = 0, Toplam = 0;
                Tutar = Convert.ToDecimal(txtTutar.Text);
                KDV = Tutar * 18 / 100;
                Toplam = Tutar + KDV;
                txtKDV.Text = Convert.ToString(KDV);
                txtToplam.Text = Convert.ToString(Toplam);
            }
            if (txtTutar.Text == "")
            {
                txtKDV.Text = "";
                txtToplam.Text = "";
            }
        }


        Faturax f = new Faturax();
        NKR n = (NKR)Application.OpenForms["NKR"];
        // int odemeID, faturafirma, raporfirma, projeID;
        object tarih;
        decimal odenenTutar = 0;
        int faturafirma, raporfirma, projeID, faturasayi;
        string FaturaNumarasi;
        private void btnKaydet_Click(object sender, EventArgs e)
        {

            try
            {

                //SqlCommand getir2 = new SqlCommand("Select ID from Odeme where Evrak_No ='" + combo_evrak.Text + "'", bgl.baglanti());
                //SqlDataReader dr3 = getir2.ExecuteReader();
                //while (dr3.Read())
                //{
                //    odemeID = Convert.ToInt32(dr3[0].ToString());

                //}
                //bgl.baglanti().Close();

                SqlCommand getir3 = new SqlCommand("Select ID from Firma where Firma_Adi = N'" + combo_raporfirma.Text + "'", bgl.baglanti());
                SqlDataReader dr4 = getir3.ExecuteReader();
                while (dr4.Read())
                {
                    raporfirma = Convert.ToInt32(dr4[0].ToString());
                }
                bgl.baglanti().Close();

                SqlCommand getir4 = new SqlCommand("Select ID from Firma where Firma_Adi = N'" + combo_faturafirma.Text + "'", bgl.baglanti());
                SqlDataReader dr5 = getir4.ExecuteReader();
                while (dr5.Read())
                {
                    faturafirma = Convert.ToInt32(dr5[0].ToString());
                }
                bgl.baglanti().Close();

                if (combo_proje.Text == "Diğer")
                {
                    projeID = 1;
                }
                else
                {
                    SqlCommand getir5 = new SqlCommand("Select ID from Firma where Firma_Adi = N'" + combo_proje.Text + "'", bgl.baglanti());
                    SqlDataReader dr6 = getir5.ExecuteReader();
                    while (dr6.Read())
                    {
                        projeID = Convert.ToInt32(dr6[0].ToString());
                    }
                    bgl.baglanti().Close();
                }

                if (txt_faturano.Text == "")
                {
                    MessageBox.Show("Fatura Numarasını Boş Geçemezsin Bro!");
                }
                else
                {
                   // FaturaNumarasi = Convert.ToInt32(textEdit4.Text);
                    FaturaNumarasi = txt_faturano.Text.ToString();
                }

                if (dateEdit1.EditValue == null)
                {
                    tarih = DateTime.Today;
                }
                else
                {
                    tarih = dateEdit1.EditValue;
                }

                SqlCommand getir11 = new SqlCommand("Select count(Fatura_no) from Fatura where Fatura_No =N'" + txt_faturano.Text + "'", bgl.baglanti());
                SqlDataReader dr11 = getir11.ExecuteReader();
                while (dr11.Read())
                {
                    faturasayi = Convert.ToInt32(dr11[0].ToString());
                }
                bgl.baglanti().Close();

                if (faturasayi == 0)
                {

                    //SqlCommand komut = new SqlCommand("insert into Fatura (Fatura_No,Tutar,KDV,Toplam) values (@a1,@a2,@a3,@a4);insert into Odeme (Odeme_Durumu,Rapor_ID,Fatura_ID) values (@o1,@o2,IDENT_CURRENT('Fatura'))", bgl.baglanti());
                    SqlCommand komut = new SqlCommand("insert into Fatura (Fatura_No,Tutar,KDV,Toplam,Proje_Id,RaporFirmaID,FaturaFirmaID,Tarih,Durum,Odenen_Tutar,Aciklama) values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9,@a10,@a11); insert into Odeme (Odeme_Durumu, Evrak_No, Fatura_ID) values (@o1, @o2, IDENT_CURRENT('Fatura'))", bgl.baglanti());
                    komut.Parameters.AddWithValue("@a1", FaturaNumarasi);
                    komut.Parameters.AddWithValue("@a2", Convert.ToDecimal(txtTutar.Text));
                    komut.Parameters.AddWithValue("@a3", Convert.ToDecimal(txtKDV.Text));
                    komut.Parameters.AddWithValue("@a4", Convert.ToDecimal(txtToplam.Text));
                    komut.Parameters.AddWithValue("@a5", projeID);
                    komut.Parameters.AddWithValue("@a6", raporfirma);
                    komut.Parameters.AddWithValue("@a7", faturafirma);
                    komut.Parameters.AddWithValue("@a8", tarih);
                    komut.Parameters.AddWithValue("@a9", "Aktif");
                    komut.Parameters.AddWithValue("@a10", odenenTutar);
                    komut.Parameters.AddWithValue("@a11", txt_aciklama.Text);
                    komut.Parameters.AddWithValue("@o1", "Ödeme Bekliyor");
                    komut.Parameters.AddWithValue("@o2", combo_evrak.SelectedItem);
                    // komut.Parameters.AddWithValue("@o3", odemeID);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Kayıt İşlemi Başarılı.");
                    f.listele();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Bu fatura numarası daha önce işlenmiş.");
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }

            Temizle();
        }

        private void txtTutar_TextChanged_1(object sender, EventArgs e)
        {
            if (txtTutar.Text != "")
            {
                double KDV = 0, Tutar = 0, Toplam = 0;
                Tutar = Convert.ToDouble(txtTutar.Text);
                KDV = Tutar * 18 / 100;
                Toplam = Tutar + KDV;
                txtKDV.Text = Convert.ToString(KDV);
                txtToplam.Text = Convert.ToString(Toplam);
            }
            if (txtTutar.Text == "")
            {
                txtKDV.Text = "";
                txtToplam.Text = "";
            }
        }
       
        private void YeniFatura_Load(object sender, EventArgs e)
        {
            Firma();
            combo_proje.Text = "Diğer";
            //DateTime tarih = DateTime.Now;
            //dateEdit1.Text = tarih.ToString("G");
            DateTime tarih = DateTime.Now;
            //  dateTime.Text = tarih.ToString("G");
            dateEdit1.EditValue = tarih;

        }

        private void btn_proje_Click(object sender, EventArgs e)
        {
            //Proje f1 = new Proje();
            //f1.ShowDialog();
        }

        private void txtTutar_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44)
            // text'e sadece sayıların girmesi,geri silme tuşu(ascii kodu:08),virgül(ascii kodu:44) karakterinin girilmesini sağlar.
            //del tuşununda aktif olmasını isterseniz del ascıı kodu:127
            //
            {
                e.Handled = true;
            }
        }

        private void combo_evrak_TextChanged(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("select Firma_Adi from Firma where ID in (select Firma_ID from NKR where Evrak_No = N'" + combo_evrak.Text + "')", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                combo_raporfirma.Text = dr1[0].ToString();
            }
            bgl.baglanti().Close();
        }
    }
}
