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
    public partial class NumDurum : Form
    {
        public NumDurum()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public static string raporno;
        string kabul, tanimlama, tanimlayan, kID, tartim, tID, tartan, sonuc, imha , iID, imhaeden;

        void bul()
        {
            SqlCommand komut = new SqlCommand("select CONVERT(VARCHAR(10),Tarih,105) Tarih from NKR where RaporNo = '" + raporno+"' ", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                kabul = dr["Tarih"].ToString();                
            }
            bgl.baglanti().Close();

            SqlCommand kom = new SqlCommand("select CONVERT(VARCHAR(10),Tarih,105) Tarih, kID from Tanimlama where RaporNo = '" + raporno + "' ", bgl.baglanti());
            SqlDataReader dr1 = kom.ExecuteReader();
            while (dr1.Read())
            {
                tanimlama = dr1["Tarih"].ToString();
                kID = dr1["KID"].ToString();    
            }
            bgl.baglanti().Close();

            SqlCommand kom2 = new SqlCommand("select * from StokKullanici where ID = '" + kID + "' ", bgl.baglanti());
            SqlDataReader dr2 = kom2.ExecuteReader();
            while (dr2.Read())
            {
                tanimlayan = dr2["Ad"].ToString() + " " + dr2["Soyad"].ToString();
            }
            bgl.baglanti().Close();

            SqlCommand kom3 = new SqlCommand("select CONVERT(VARCHAR(10),Tarih,105) Tarih, pID from NumuneImha where RaporNo = '" + raporno + "' ", bgl.baglanti());
            SqlDataReader dr11 = kom3.ExecuteReader();
            while (dr11.Read())
            {
                imha = dr11["Tarih"].ToString();
                iID = dr11["pID"].ToString();
            }
            bgl.baglanti().Close();


            SqlCommand kom12 = new SqlCommand("select * from StokKullanici where ID = '" + iID + "' ", bgl.baglanti());
            SqlDataReader dr12 = kom12.ExecuteReader();
            while (dr12.Read())
            {
                imhaeden = dr12["Ad"].ToString() + " " + dr12["Soyad"].ToString();
            }
            bgl.baglanti().Close();



            SqlCommand kom31 = new SqlCommand("select CONVERT(VARCHAR(10),Tarih,105) Tarih, TanimlayanID from Rapor_Durum where Durum like '%Tartım%' and  RaporNo = '" + raporno + "' ", bgl.baglanti());
            SqlDataReader dr31 = kom31.ExecuteReader();
            while (dr31.Read())
            {
                tartim = dr31["Tarih"].ToString();
                tID = dr31["TanimlayanID"].ToString();
            }
            bgl.baglanti().Close();

            SqlCommand kom22 = new SqlCommand("select * from StokKullanici where ID = '" + tID + "' ", bgl.baglanti());
            SqlDataReader dr22 = kom22.ExecuteReader();
            while (dr22.Read())
            {
                tartan = dr22["Ad"].ToString() + " " + dr22["Soyad"].ToString();
            }
            bgl.baglanti().Close();

            listBoxControl1.Items.Add(kabul + " tarihinde Can Karadeniz tarafından kabul edildi.");
            listBoxControl1.Items.Add(tanimlama + " tarihinde " + tanimlayan + " tarafından teslim alındı ve tanımlandı.");
         //   listBoxControl1.Items.Add(tartim + " tarihinde " + tartan + " tarafından numune hazırlık ve tartım işlemleri gerçekleştirildi.");

            SqlCommand kom32 = new SqlCommand(@"select l.Kod + ' '+ l.Ad as 'Analiz', CONVERT(VARCHAR(10),x.Tarih,105) Tarih , k.Ad +' '+ k.Soyad as 'Personel' from NumuneX5 x
            left join Numunex2 y on x.x2ID = y.ID
            left join NKR n on y.RaporID = n.ID
            left join StokKullanici k on x.PersonelID = k.ID
            left join StokAnalizListesi l on y.AnalizID = l.ID
            where n.RaporNo = '" + raporno+"'", bgl.baglanti());
            SqlDataReader dr32 = kom32.ExecuteReader();
            while (dr32.Read())
            {
                sonuc = dr32["Tarih"].ToString() + " tarihinde " + dr32["Analiz"].ToString() + " analizi " +  dr32["Personel"].ToString() + " tarafından sonuçlandırılmıştır.";
                listBoxControl1.Items.Add(sonuc);
            }
            bgl.baglanti().Close();

            listBoxControl1.Items.Add(imha + " tarihinde " + imhaeden + " tarafından imha edildi.");           
        }


        private void NumDurum_Load(object sender, EventArgs e)
        {
            bul();
        }
    }
}
