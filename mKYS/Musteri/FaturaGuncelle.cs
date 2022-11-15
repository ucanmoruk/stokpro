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
    public partial class FaturaGuncelle : Form
    {
        public FaturaGuncelle()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        public void goster()
        {
            txtFaturaNo.Text = Faturax.faturaNo.ToString();
            txtTutar.Text = Faturax.tutar;
            txtKDV.Text = Faturax.kdv;
            txtToplam.Text = Faturax.toplam.ToString();
            txtRaporNo.Text = Faturax.raporNO.ToString();
            dateEdit1.EditValue = Convert.ToDateTime(Faturax.ftarih);
            combo_proje.Text = Faturax.fproje;
            combo_faturafirma.Text = Faturax.ffaturafirma;
            combo_raporfirma.Text = Faturax.fraporfirma;
            txt_aciklama.Text = Faturax.aciklama;
          
        }

        private void FaturaGuncelle_Load(object sender, EventArgs e)
        {
            goster();
            proje();
            firma();
           
        }

        void proje()
        {
            SqlCommand komut = new SqlCommand("Select Firma_Adi from Firma where Tur = N'Proje' and Durum=N'Aktif' order by Firma_Adi asc", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                combo_proje.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        void firma()
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
            // e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            //if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44)
            //// text'e sadece sayıların girmesi,geri silme tuşu(ascii kodu:08),virgül(ascii kodu:44) karakterinin girilmesini sağlar.
            ////del tuşununda aktif olmasını isterseniz del ascıı kodu:127
            ////
            //{
            //    e.Handled = true;
            //}
        }
        int faturaID;
        void FaturaID()
        {
            // SqlCommand komut2 = new SqlCommand("select Fatura_ID from Odeme where Fatura_ID = (select ID from Fatura where Fatura_No =  '" + txtFaturaNo.Text + "')", bgl.baglanti());
            SqlCommand komut2 = new SqlCommand("select ID from Fatura where Fatura_No =  N'" + txtFaturaNo.Text + "'", bgl.baglanti());
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                faturaID = dr["ID"] != DBNull.Value ? Convert.ToInt32(dr[0]) : 0;
                // faturaID = Convert.ToInt32(dr[0].ToString());
            }
            bgl.baglanti().Close();

        }

        Faturax f = (Faturax)System.Windows.Forms.Application.OpenForms["Faturax"];

        int  faturafirma, raporfirma, projeID,FaturaninID, faturasayi;

        private void txtTutar_EditValueChanged(object sender, EventArgs e)
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

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand getirr = new SqlCommand("Select ID from Fatura where Fatura_No =N'" + Faturax.faturaNo.ToString() + "'", bgl.baglanti());
                SqlDataReader drr = getirr.ExecuteReader();
                while (drr.Read())
                {
                    FaturaninID = Convert.ToInt32(drr[0].ToString());
                }
                bgl.baglanti().Close();

                SqlCommand getir3 = new SqlCommand("Select ID from Firma where Firma_Adi =N'" + combo_raporfirma.Text + "'", bgl.baglanti());
                SqlDataReader dr4 = getir3.ExecuteReader();
                while (dr4.Read())
                {
                    raporfirma = Convert.ToInt32(dr4[0].ToString());
                }
                bgl.baglanti().Close();

                SqlCommand getir4 = new SqlCommand("Select ID from Firma where Firma_Adi =N'" + combo_faturafirma.Text + "'", bgl.baglanti());
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


                SqlCommand getir11 = new SqlCommand("Select count(Fatura_no) from Fatura where Fatura_No =N'" + txtFaturaNo.Text + "'", bgl.baglanti());
                SqlDataReader dr11 = getir11.ExecuteReader();
                while (dr11.Read())
                {
                   faturasayi = Convert.ToInt32(dr11[0].ToString());
                }
                bgl.baglanti().Close();

                //if (faturasayi == 0)
                //{
                    SqlCommand komut = new SqlCommand("update Fatura set Fatura_No = @f1 , Tutar = @f2 , KDV = @f3 , " +
               "Toplam = @f4, Proje_ID = @f5, RaporFirmaID = @f6, FaturaFirmaID =@f7 , Tarih =@f8 , Aciklama = @f10  " +
               "where ID = @f9", bgl.baglanti());
                    komut.Parameters.AddWithValue("@f1", txtFaturaNo.Text);
                    komut.Parameters.AddWithValue("@f2", Convert.ToDecimal(txtTutar.Text));
                    komut.Parameters.AddWithValue("@f3", Convert.ToDecimal(txtKDV.Text));
                    komut.Parameters.AddWithValue("@f4", Convert.ToDecimal(txtToplam.Text));
                    komut.Parameters.AddWithValue("@f5", projeID);
                    komut.Parameters.AddWithValue("@f6", raporfirma);
                    komut.Parameters.AddWithValue("@f7", faturafirma);
                    komut.Parameters.AddWithValue("@f8", dateEdit1.EditValue);
                    komut.Parameters.AddWithValue("@f9", FaturaninID);
                    komut.Parameters.AddWithValue("@f10", txt_aciklama.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Güncelleme İşlemi Başarıyla Gerçekleşmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    f.listele();
                //}
                //else
                //{
                //    MessageBox.Show("Bu fatura numarası daha önce işlenmiş!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}

           
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }


        }
    }
}
