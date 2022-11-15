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
    public partial class FaturaOdeme : Form
    {
        public FaturaOdeme()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();
        Faturax f = (Faturax)Application.OpenForms["Faturax"];
        NKR n = new NKR();
       // int fNo;
        void goster()
        {
            comboBoxEdit1.Text = Faturax.durum;
            // fNo = Convert.ToInt32(Fatura.faturaNo);
            labelControl4.Text = Faturax.faturaNo;
        }


        public static decimal toplamTutar = 0, odenenTutar = 0, kalanBakiye = 0;

        void bakiyebul()
        {
           // SqlCommand komutID = new SqlCommand("Select Odenen_Tutar, Toplam From Fatura where Fatura_No= N'" + Fatura.faturaNo + "'", bgl.baglanti());
            SqlCommand komutID = new SqlCommand("Select Odenen_Tutar, Toplam From Fatura where ID= N'" +fID +"' ", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                // top= Convert.ToInt32(drI["Toplam"].ToString());
                odenenTutar = Convert.ToInt32(drI["Odenen_tutar"]);
                toplamTutar = Convert.ToInt32(drI["Toplam"]);
                // ode = Convert.ToInt32(drI["Odenen_tutar"].ToString());
            }
            bgl.baglanti().Close();
            //bak = Convert.ToInt32();
            //bak2 = Convert.ToInt32();
        }

        public static int fID;
        private void FaturaOdeme_Load(object sender, EventArgs e)
        {
            goster();
            bakiyebul();
            if (Faturax.odemed == "Kısmen Ödendi")
            {
                comboBoxEdit1.Text = "Kısmen Ödendi";
                comboBoxEdit1.ReadOnly = true;
                lblkismi.Visible = true;
                lblkismi.Text = "Kalan tutar: ";
                lblKalanTutar.Visible = true;
                kalanBakiye = toplamTutar - odenenTutar;
                lblKalanTutar.Text = Convert.ToString(kalanBakiye);


            }
            else if (Faturax.odemed == "Ödendi")
            {
                MessageBox.Show("Kardeşim ödendi dedik ya!");
                this.Close();
            }
            else
            {
                txtTutar.Enabled = false;
                txtTutar.ReadOnly = true;
            }

        }

        private void comboBoxEdit1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit1.SelectedItem.ToString() == "Ödendi")
            {
                txtTutar.Enabled = false;
                txtTutar.ReadOnly = true;
            }
            else
                txtTutar.Enabled = true;
                txtTutar.ReadOnly = false;
        }
        int FaturaID, FFirmaID;

        private void FaturaOdeme_FormClosing(object sender, FormClosingEventArgs e)
        {
            fID = 0;
        }

        decimal fatuta, ilkodeme, yenibakiye;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
               // SqlCommand getir = new SqlCommand("Select ID, FaturaFirmaID, Toplam, Odenen_Tutar from Fatura where Fatura_No = N'" + Fatura.faturaNo.ToString() + "'", bgl.baglanti());
                SqlCommand getir = new SqlCommand("Select  FaturaFirmaID, Toplam, Odenen_Tutar from Fatura where ID = N'" + fID + "'", bgl.baglanti());
                SqlDataReader dr2 = getir.ExecuteReader();
                while (dr2.Read())
                {
                 //   FaturaID = Convert.ToInt32(dr2["ID"].ToString());
                    FFirmaID = Convert.ToInt32(dr2["FaturaFirmaID"].ToString());
                    fatuta = Convert.ToDecimal(dr2["Toplam"].ToString());
                    ilkodeme = Convert.ToDecimal(dr2["Odenen_Tutar"].ToString());
                }
                bgl.baglanti().Close();

                
                if (comboBoxEdit1.Text == "Kısmen Ödendi")
                {

                    if (ilkodeme == 0)
                    {
                        SqlCommand komut = new SqlCommand("update Odeme set Odeme_Durumu = @d1 where Fatura_ID = @d2; update Fatura set Odenen_Tutar = @a1 where ID = @d2 ", bgl.baglanti());
                        komut.Parameters.AddWithValue("@d1", comboBoxEdit1.SelectedItem.ToString());
                        komut.Parameters.AddWithValue("@d2", fID);
                        komut.Parameters.AddWithValue("@a1", Convert.ToDecimal(txtTutar.Text));
                        komut.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        MessageBox.Show("Gelsin paralar. İyisin, iyi!");
                        f.listele();
                        n.listele();
                    }
                    else
                    {
                        yenibakiye = ilkodeme + Convert.ToDecimal(txtTutar.Text);
                        SqlCommand komut = new SqlCommand("update Odeme set Odeme_Durumu = @d1 where Fatura_ID = @d2; update Fatura set Odenen_Tutar = @a1 where ID = @d2  ", bgl.baglanti());
                        komut.Parameters.AddWithValue("@d1", comboBoxEdit1.SelectedItem.ToString());
                        komut.Parameters.AddWithValue("@d2", fID);
                        komut.Parameters.AddWithValue("@a1", Convert.ToDecimal(yenibakiye));
                        komut.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        MessageBox.Show("Gelsin paralar. İyisin, iyi!");
                        f.listele();
                        n.listele();
                    }


              
                }
                else
                {
                    //  SqlCommand komut = new SqlCommand("update Odeme set Odeme_Durumu = @d1 where Fatura_ID = @d2; insert into Bakiye (Firma_Id, Bakiye) values (@a1,@a2) ", bgl.baglanti());
                    SqlCommand komut = new SqlCommand("update Odeme set Odeme_Durumu = @d1 where Fatura_ID = @d2; update Fatura set Odenen_Tutar = @a1 where ID = @d2 ", bgl.baglanti());
                    komut.Parameters.AddWithValue("@d1", comboBoxEdit1.SelectedItem.ToString());
                    komut.Parameters.AddWithValue("@d2", fID);
                    komut.Parameters.AddWithValue("@a1", fatuta);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Gelsin paralar. İyisin, iyi!");
                    f.listele();
                    n.listele();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : "+ ex.Message);
            }

            this.Close();
        }
    }
}
