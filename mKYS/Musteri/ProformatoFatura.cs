using mKYS;
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

namespace mKYS.Musteri
{
    public partial class ProformatoFatura : Form
    {

        sqlbaglanti bgl = new sqlbaglanti();


        public ProformatoFatura()
        {
            InitializeComponent();
        }

        public static string faturadetayID;

        string teklifnum;
        void proforma()
        {
            txtRaporNo.Text = NKR.evrakNo;
            combo_raporfirma.Text = NKR.ffirma;


            SqlCommand detayd = new SqlCommand("Select Firma_Adi from Firma where ID in (select FaturaFirmaID from FaturaDetay where ProformaNo = '"+ txtRaporNo.Text + "')", bgl.baglanti());
            SqlDataReader drde = detayd.ExecuteReader();
            while (drde.Read())
            {
               combo_faturafirma.Text = drde["Firma_Adi"].ToString();

            }
            bgl.baglanti().Close();

            SqlCommand detaym = new SqlCommand("select  TeklifNo from FaturaDetay where ProformaNo = '" + txtRaporNo.Text + "'", bgl.baglanti());
            SqlDataReader drdm = detaym.ExecuteReader();
            while (drdm.Read())
            {
                teklifnum = drdm["TeklifNo"].ToString();
            }
            bgl.baglanti().Close();

            if (teklifnum == "2101000")
            {
                SqlCommand detay = new SqlCommand("select  sum(ToplamFiyat) as 'Total' from FaturaDetay where ProformaNo = '" + txtRaporNo.Text + "'", bgl.baglanti());
                SqlDataReader drd = detay.ExecuteReader();
                while (drd.Read())
                {
                    txtTutar.Text = drd["Total"].ToString();

                }
                bgl.baglanti().Close();
            }
            else
            {
                SqlCommand detay = new SqlCommand("select  sum(GenelFiyat) as 'Total' from FaturaDetay where ProformaNo = '" + txtRaporNo.Text + "'", bgl.baglanti());
                SqlDataReader drd = detay.ExecuteReader();
                while (drd.Read())
                {
                    txtTutar.Text = drd["Total"].ToString();

                }
                bgl.baglanti().Close();
            }




            //SqlCommand detayq = new SqlCommand("select ID, Tarih from FaturaDetay where ProformaNo = '" + txtRaporNo.Text + "'", bgl.baglanti());
            //SqlDataReader drq = detayq.ExecuteReader();
            //while (drq.Read())
            //{
            //    dateEdit1.Text = drq["Tarih"].ToString();

            //}
            //bgl.baglanti().Close();

          
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

        public void proje()
        {
            SqlCommand komut = new SqlCommand("Select Firma_Adi from Firma where Tur=N'Proje' and Durum=N'Aktif' order by Firma_Adi asc", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                combo_proje.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        void temizle()
        {
            txtFaturaNo.Text = "";
            txtKDV.Text = "";
            txtToplam.Text = "";
            txtTutar.Text = "";

        }

        int projeid;
        string projeadi;
        public void projebul()
        {

            SqlCommand detay = new SqlCommand("select Firma_Adi from Firma where ID in (select ProjeID from NumuneDetay where RaporID = (Select ID from NKR where RaporNo = '" + NKR.raporNo + "'))", bgl.baglanti());
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
            //combo_proje.Text = projeadi;
        }

        private void ProformatoFatura_Load(object sender, EventArgs e)
        {
            
            firma();
            proje();
            projebul();
            proforma();
            //DateTime tarih = DateTime.Now;
            //dateEdit1.EditValue = tarih;

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
            else if (txtTutar.Text == "")
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

        int odemeID, faturafirma, raporfirma, projeID, faturasayi;
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand getir2 = new SqlCommand("Select ID from Odeme where Evrak_No =N'" + txtRaporNo.Text + "'", bgl.baglanti());
                SqlDataReader dr3 = getir2.ExecuteReader();
                while (dr3.Read())
                {
                    odemeID = Convert.ToInt32(dr3[0].ToString());

                }
                bgl.baglanti().Close();

                SqlCommand getir3 = new SqlCommand("Select ID from Firma where Firma_Adi =N'" + combo_raporfirma.Text + "' and Durum = 'Aktif'", bgl.baglanti());
                SqlDataReader dr4 = getir3.ExecuteReader();
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

                SqlCommand getir5 = new SqlCommand("Select ID from Firma where Firma_Adi =N'" + combo_proje.Text + "' and Durum = 'Aktif'", bgl.baglanti());
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

                if (faturasayi == 0)
                {
                    if (dateEdit1.EditValue == null)
                    {
                        MessageBox.Show("Lütfen fatura tarihini girer misiniz ? Rica ediyorum..");
                    }
                    else
                    {
                        SqlCommand komut = new SqlCommand("insert into Fatura (Fatura_No,Tutar,KDV,Toplam,Proje_Id,RaporFirmaID,FaturaFirmaID,Tarih,Durum,Odenen_Tutar,ProformaNo) values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9,@a10,@a11); update Odeme set Odeme_Durumu=@o1 , Evrak_No = @o2, Fatura_ID =IDENT_CURRENT('Fatura') where ID = @o3 ; update ProformaDurum set Durum = @k1 where ProformaNo = @k2 and Durum = @k3", bgl.baglanti());
                        komut.Parameters.AddWithValue("@a1", txtFaturaNo.Text);
                        komut.Parameters.AddWithValue("@a2", Convert.ToDecimal(txtTutar.Text));
                        komut.Parameters.AddWithValue("@a3", Convert.ToDecimal(txtKDV.Text));
                        komut.Parameters.AddWithValue("@a4", Convert.ToDecimal(txtToplam.Text));
                        komut.Parameters.AddWithValue("@a5", projeID);
                        komut.Parameters.AddWithValue("@a6", raporfirma);
                        komut.Parameters.AddWithValue("@a7", faturafirma);
                        komut.Parameters.AddWithValue("@a8", dateEdit1.EditValue);
                        komut.Parameters.AddWithValue("@o1", "Ödeme Bekliyor");
                        komut.Parameters.AddWithValue("@o2", txtRaporNo.Text);
                        komut.Parameters.AddWithValue("@o3", odemeID);
                        komut.Parameters.AddWithValue("@a9", "Aktif");
                        komut.Parameters.AddWithValue("@a10", 0);
                        komut.Parameters.AddWithValue("@a11", txtRaporNo.Text);
                        komut.Parameters.AddWithValue("@k1", "Faturalandırıldı");
                        komut.Parameters.AddWithValue("@k2", txtRaporNo.Text);
                        komut.Parameters.AddWithValue("@k3", "Onaylandı");
                        komut.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        MessageBox.Show("Kayıt İşlemi Başarılı.");
                        this.Close();
                        temizle();
                        // f.listele();
                        //  n.listele();
                    }


                }
                else
                {
                    MessageBox.Show("Bu fatura numarası daha önce işlenmiş!");
                }

              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hatasız kul olmaz! : " + ex.Message);
            }
        }

        
    }
}
