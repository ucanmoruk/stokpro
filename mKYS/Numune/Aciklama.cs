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

namespace mKYS.Numune
{
    public partial class Aciklama : Form
    {
        public Aciklama()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public static string RaporNo, aciklama;
        public static int RevNo;

        private void txt_rev_TextChanged(object sender, EventArgs e)
        {
            txt_revsebep.Text = RaporNo + "/ " + RevNo + " nolu rapor ........... sebebi ile revize edilmiştir. Geçerli rapor numarası: " + RaporNo + " / " + txt_rev.Text;
        }

        int raporaciklama;
        private void bul()
        {
            SqlCommand komut = new SqlCommand("select COUNT(ID) from Rapor_Aciklama where RaporNo = N'" + txt_rapor.Text + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                raporaciklama = Convert.ToInt32(dr[0]);
            }
            bgl.baglanti().Close();

            if (raporaciklama == 0)
            {

            }
            else
            {
                SqlCommand komut2 = new SqlCommand("select Aciklama from Rapor_Aciklama where RaporNo = N'" + txt_rapor.Text + "'", bgl.baglanti());
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    txt_aciklama.Text = dr2[0].ToString();
                }
                bgl.baglanti().Close();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            aciklama = "Bu rapordaki test değerlendirmeleri, “Kimyasalların Kaydı, Değerlendirilmesi, İzni ve Kısıtlanması Hakkında Yönetmelik” ve standartlar ile yürürlükte olan diğer ilgili mevzuata göre yapılmıştır.";
            if (raporsayi == 0)
            {
                if (txt_aciklama.Text == aciklama && RevNo.ToString() == txt_rev.Text)
                {

                }
                else if (txt_aciklama.Text != aciklama && RevNo.ToString() == txt_rev.Text)
                {
                    SqlCommand add = new SqlCommand("insert into Rapor_Aciklama(RaporNo, Aciklama, Degisim) values (@o1,@o2,@o3)", bgl.baglanti());
                    add.Parameters.AddWithValue("@o1", txt_rapor.Text);
                    add.Parameters.AddWithValue("@o2", txt_aciklama.Text);
                    add.Parameters.AddWithValue("@o3", 1);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("1. Başarı ile kaydedilmiştir.");             
                }
                else if (txt_aciklama.Text == aciklama && RevNo.ToString() != txt_rev.Text)
                {
                    SqlCommand add = new SqlCommand("insert into Rapor_Aciklama(RaporNo, Rev, Degisim) values (@o1,@o2, @o4) ; " +
                    " update NKR set Revno = @o3 where RaporNo = N'"+txt_rapor.Text+"' ", bgl.baglanti());
                    add.Parameters.AddWithValue("@o1", txt_rapor.Text);
                    add.Parameters.AddWithValue("@o2", txt_revsebep.Text);
                    add.Parameters.AddWithValue("@o4", 2);
                    add.Parameters.AddWithValue("@o3", txt_rev.Text);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("2. Başarı ile kaydedilmiştir.");

                }
                else if (txt_aciklama.Text != aciklama && RevNo.ToString() != txt_rev.Text)
                {
                    SqlCommand add = new SqlCommand("insert into Rapor_Aciklama(RaporNo, Rev, Aciklama, Degisim) values (@o1,@o2, @o3, @o5) ; " +
                     " update NKR set Revno = @o4 where RaporNo = N'" + txt_rapor.Text + "' ", bgl.baglanti());
                    add.Parameters.AddWithValue("@o1", txt_rapor.Text);
                    add.Parameters.AddWithValue("@o2", txt_revsebep.Text);
                    add.Parameters.AddWithValue("@o3", txt_aciklama.Text);
                    add.Parameters.AddWithValue("@o5", 3);
                    add.Parameters.AddWithValue("@o4", txt_rev.Text);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }

            }
            else
            {
                SqlCommand komut = new SqlCommand("update Rapor_Aciklama set Aciklama=@t1, Rev=@t2, Degisim=@t3 where RaporNo = N'" + txt_rapor.Text + "' ; " +
                " update NKR set Revno = @o4 where RaporNo = N'" + txt_rapor.Text + "' ", bgl.baglanti());
                komut.Parameters.AddWithValue("@t1", txt_aciklama.Text);
                komut.Parameters.AddWithValue("@t2", txt_revsebep.Text);
                komut.Parameters.AddWithValue("@t3", 3);
                komut.Parameters.AddWithValue("@o4", txt_rev.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
            }
           
        }
        int raporsayi;
        private void Aciklama_Load(object sender, EventArgs e)
        {
            txt_rapor.Text = RaporNo;
            txt_rev.Text = RevNo.ToString();
            bul();

            SqlCommand komut = new SqlCommand("Select count(RaporNo) from Rapor_Aciklama where RaporNo = N'"+txt_rapor.Text+"'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                raporsayi = Convert.ToInt32(dr[0]);
            }
            bgl.baglanti().Close();
        }
    }
}
