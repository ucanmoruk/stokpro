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
    public partial class FaturaKaydet : Form
    {
        public FaturaKaydet()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();
        void temizle()
        {
            txtFaturaNo.Text = "";
            txtKDV.Text = "";
            txtToplam.Text = "";
            txtTutar.Text = "";

        }


        void goster()
        {
            txtRaporNo.Text = NKR2.evrakNo;
            combo_raporfirma.Text = NKR2.ffirma;
            combo_faturafirma.Text = NKR2.ffirma;
         //   dateEdit1.Text = NKR.ftarih;
            combo_proje.Text = NumuneGuncelle.projeadi;
        }
        Faturax f = new Faturax();
        NKR2 n = (NKR2)Application.OpenForms["Numune Takip Listesi"];
        string odemeDurumu = "Ödeme Bekliyor";
        int odemeID,faturafirma,raporfirma,projeID, faturasayi;
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                //SqlCommand getir = new SqlCommand("Select Evrak_No from NKR where Evrak_No ='" + txtRaporNo.Text + "'", bgl.baglanti());
                //SqlDataReader dr2 = getir.ExecuteReader();
                //while (dr2.Read())
                //{
                //    evrakID = Convert.ToInt32(dr2[0].ToString());

                //}
                //bgl.baglanti().Close();

                SqlCommand getir2 = new SqlCommand("Select ID from Odeme where Evrak_No =N'" + txtRaporNo.Text + "'", bgl.baglanti());
                SqlDataReader dr3 = getir2.ExecuteReader();
                while (dr3.Read())
                {
                    odemeID = Convert.ToInt32(dr3[0].ToString());

                }
                bgl.baglanti().Close();

                SqlCommand getir3 = new SqlCommand("Select ID from Firma where Firma_Adi =N'" + combo_raporfirma.Text + "' and Durum = 'Aktif'", bgl.baglanti());
                SqlDataReader dr4= getir3.ExecuteReader();
                while (dr4.Read())
                {
                    raporfirma = Convert.ToInt32(dr4[0].ToString());
                }
                bgl.baglanti().Close();

                SqlCommand getir4 = new SqlCommand("Select ID from Firma where Firma_Adi =N'" + combo_faturafirma.Text + "' and Durum = 'Aktif'", bgl.baglanti());
                SqlDataReader dr5 = getir4.ExecuteReader();
                while (dr5.Read())
                {
                    faturafirma = Convert.ToInt32(dr5[0].ToString());
                }
                bgl.baglanti().Close();

                SqlCommand getir5 = new SqlCommand("Select ID from Firma where Firma_Adi =N'" + combo_proje.Text + "'", bgl.baglanti());
                SqlDataReader dr6 = getir5.ExecuteReader();
                while (dr6.Read())
                {
                    projeID = Convert.ToInt32(dr6[0].ToString());
                }
                bgl.baglanti().Close();

                //SqlCommand getir11 = new SqlCommand("Select count(Fatura_no) from Fatura where Fatura_No =N'" + txtFaturaNo.Text + "'", bgl.baglanti());
                //SqlDataReader dr11 = getir11.ExecuteReader();
                //while (dr11.Read())
                //{
                //    faturasayi = Convert.ToInt32(dr11[0].ToString());
                //}
                //bgl.baglanti().Close();

              //  if (faturasayi == 0)
                if (txtFaturaNo.Text != "" || txtFaturaNo.Text == null)
                {
                    if (dateEdit1.EditValue == null )
                    {
                        MessageBox.Show("Lütfen fatura tarihini seçiniz! Lütfen.. Rica ediyorum.");
                    }
                    else
                    {
                        //SqlCommand komut = new SqlCommand("insert into Fatura (Fatura_No,Tutar,KDV,Toplam) values (@a1,@a2,@a3,@a4);insert into Odeme (Odeme_Durumu,Rapor_ID,Fatura_ID) values (@o1,@o2,IDENT_CURRENT('Fatura'))", bgl.baglanti());
                        SqlCommand komut = new SqlCommand("insert into Fatura (Fatura_No,Tutar,KDV,Toplam,Proje_Id,RaporFirmaID,FaturaFirmaID,Tarih,Durum,Odenen_Tutar) values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9,@a10);update Odeme set Odeme_Durumu=@o1 , Evrak_No = @o2, Fatura_ID =IDENT_CURRENT('Fatura') where ID = @o3", bgl.baglanti());
                        komut.Parameters.AddWithValue("@a1", txtFaturaNo.Text);
                        komut.Parameters.AddWithValue("@a2", Convert.ToDecimal(txtTutar.Text));
                        komut.Parameters.AddWithValue("@a3", Convert.ToDecimal(txtKDV.Text));
                        komut.Parameters.AddWithValue("@a4", Convert.ToDecimal(txtToplam.Text));
                        komut.Parameters.AddWithValue("@a5", projeID);
                        komut.Parameters.AddWithValue("@a6", raporfirma);
                        komut.Parameters.AddWithValue("@a7", faturafirma);
                        komut.Parameters.AddWithValue("@a8", dateEdit1.EditValue);
                        komut.Parameters.AddWithValue("@o1", odemeDurumu);
                        komut.Parameters.AddWithValue("@o2", txtRaporNo.Text);
                        komut.Parameters.AddWithValue("@o3", odemeID);
                        komut.Parameters.AddWithValue("@a9", "Aktif");
                        komut.Parameters.AddWithValue("@a10", 0);
                        komut.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        MessageBox.Show("Kayıt İşlemi Başarılı.");
                        this.Close();
                        temizle();
                        f.listele();
                        //  n.listele();

                    }

                }
                else
                {
                 //   MessageBox.Show("Bu fatura numarası daha önce işlenmiş!");
                    MessageBox.Show("Fatura numarası bölümünü boş bırakmayınız!");
                }

             
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata 55: "+ ex.Message);
            }
            
        }

        void firma ()
        {
            SqlCommand komut = new SqlCommand("Select Firma_Adi from Firma where Durum = 'Aktif'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                combo_faturafirma.Properties.Items.Add(dr[0]);
                combo_raporfirma.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        public void proje ()
        {
            SqlCommand komut = new SqlCommand("Select Firma_Adi from Firma where Tur=N'Proje' and Durum=N'Aktif' order by Firma_Adi asc", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                combo_proje.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        int projeid;
        string projeadi;
        public void projebul()
        {

            SqlCommand detay = new SqlCommand("select Firma_Adi from Firma where ID in (select ProjeID from NumuneDetay where RaporID = (Select ID from NKR where RaporNo = '" + NKR2.raporNo + "'))", bgl.baglanti());
            SqlDataReader drd = detay.ExecuteReader();
            while (drd.Read())
            {
                projeadi = drd["Firma_Adi"].ToString();
            }
            bgl.baglanti().Close();

            //SqlCommand detayd = new SqlCommand("Select Proje from Proje where ID = N'" + projeid + "'", bgl.baglanti());
            //SqlDataReader drde = detayd.ExecuteReader();
            //while (drde.Read())
            //{
            //    projeadi = drde["Proje"].ToString();
            //}
            //bgl.baglanti().Close();
        }



        private void FaturaGuncelle_Load(object sender, EventArgs e)
        {
            goster();
            firma();
            proje();
            projebul();
            //DateTime tarih = DateTime.Now;
            //dateEdit1.EditValue = tarih;

            combo_proje.Text = projeadi;
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            //double KDV = 0, Tutar = 0, Toplam = 0;
            //Tutar = Convert.ToDouble(txtTutar.Text);
            //KDV = Tutar * 18 / 100;
            //Toplam = Tutar + KDV;
            //txtKDV.Text = Convert.ToString(KDV);
            //txtToplam.Text = Convert.ToString(Toplam);
        }

        private void btn_proje_Click(object sender, EventArgs e)
        {
            //Proje f1 = new Proje();
            //f1.ShowDialog();
        }

        private void txtTutar_TextChanged(object sender, EventArgs e)
        {
            if (txtTutar.Text != "")
            {
                decimal KDV = 0, Tutar = 0, Toplam = 0;
                Tutar = Convert.ToDecimal(txtTutar.Text);
                KDV = Tutar * 20 / 100;
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

        private void txtTutar_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtFaturaNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //// e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            //if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44)
            //// text'e sadece sayıların girmesi,geri silme tuşu(ascii kodu:08),virgül(ascii kodu:44) karakterinin girilmesini sağlar.
            ////del tuşununda aktif olmasını isterseniz del ascıı kodu:127
            ////
            //{
            //    e.Handled = true;
            //}
        }
    }
}
