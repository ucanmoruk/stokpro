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

namespace mKYS.Numune
{
    public partial class TanimKopyaHedef : Form
    {
        public TanimKopyaHedef()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();
        TanimlamaListesi m = (TanimlamaListesi)System.Windows.Forms.Application.OpenForms["TanimlamaListesi"];


        private void txt_hedef_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                kontrol();
            }

        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            kontrol();
        }

        public static string No, Grup, Tanim, Ortak, gelenrapor;
        private void TanimKopyaHedef_Load(object sender, EventArgs e)
        {
            
        }
        int tanimsayi;
        void kontrol()
        {
            SqlCommand komut = new SqlCommand("select Count(No) from Tanimlama where RaporNo = N'" + txt_hedef.Text + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                tanimsayi = Convert.ToInt32(dr[0]);
            }
            bgl.baglanti().Close();

            if (tanimsayi == 0)
            {
                SqlCommand add = new SqlCommand("insert into Tanimlama(RaporNo, No, Grup, Tanim, Ortak) select RaporNo=@o1, No, Grup, Tanim, Ortak from Tanimlama where RaporNo = '"+gelenrapor+"' ", bgl.baglanti());
                add.Parameters.AddWithValue("@o1", txt_hedef.Text);
                add.ExecuteNonQuery();
                bgl.baglanti().Close();

                DateTime tarih = DateTime.Now;
                
                SqlCommand komut2 = new SqlCommand("update Rapor_Durum set Durum = @r1, Tarih=@r2, TanimlayanID = @r3 where RaporNo = '" + txt_hedef.Text + "' ", bgl.baglanti());
                komut2.Parameters.AddWithValue("@r1", "Tanımlandı");
                komut2.Parameters.AddWithValue("@r2", tarih);
                komut2.Parameters.AddWithValue("@r3", Giris.kullaniciID);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                m.listele();

                MessageBox.Show("Hadi iyisin! Bunun da kolayını buldun..");
                this.Close();
            }
            else
            {
                MessageBox.Show("Bence sen şaşırdın! Bu rapor zaten tanımlanmış!");
            }
        }

    }
}
