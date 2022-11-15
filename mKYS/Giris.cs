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

namespace mKYS
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();
        public static string kullaniciadi, ad, soyad, gorev;
        public static int kullaniciID;

        private void Giris_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            labelControl3.Parent = pictureEdit1;
            labelControl3.BackColor = Color.Transparent;
        }

        private void Giris_FormClosing(object sender, FormClosingEventArgs e)
        {
         
        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            if (checkEdit1.Checked == true)
            {
                db = "1";
            }
            giris();
        }

        public static string db, katalog;

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_parola_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        Anasayfa f2;
        private void giris()
        {

            SqlCommand detay = new SqlCommand("Select * from StokKullanici where Kadi = N'" + txt_ad.Text + "' and Parola =  N'" + txt_parola.Text + "' ", bgl.baglanti());
            SqlDataReader drd = detay.ExecuteReader();           
            if (drd.Read())
            {
                this.Hide();

                kullaniciadi = txt_ad.Text;
                SqlCommand komutID = new SqlCommand("Select * from StokKullanici where Kadi = N'" + kullaniciadi + "'", bgl.baglanti());
                SqlDataReader drI = komutID.ExecuteReader();
                while (drI.Read())
                {
                    kullaniciID = Convert.ToInt32(drI["ID"]);
                    ad = drI["Ad"].ToString();
                    soyad = drI["Soyad"].ToString();
                    gorev = drI["Gorev"].ToString();
                }
                bgl.baglanti().Close();
                Anasayfa.kullanici = kullaniciID.ToString();
                f2 = new Anasayfa();
                f2.FormClosing += F2_FormClosing;
                f2.ShowDialog();

            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya parolayı yanlış girdiniz!", "Oppss!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bgl.baglanti().Close();
        }

        private void F2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }
    }
}
