using mKYS.Dokuman;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace mKYS.Analiz
{
    public partial class AnalizListesi : Form
    {
        public AnalizListesi()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select l.ID, f.Birim ,l.Kod, l.Ad as 'Analiz Adı', d.Kod + ' ' + d.Ad as 'Metot Kaynağı', l.Matriks, l.Akreditasyon from StokAnalizListesi l " +
                "left join StokFirmaBirim f on l.Birim = f.ID left join StokDKDListe d on l.Metot = d.ID where l.Durumu = 'Aktif' order by l.Kod ", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;

            //denetim için

            //DataTable dt2 = new DataTable();
            //SqlDataAdapter da2 = new SqlDataAdapter("select l.ID, f.Birim ,l.Kod, l.Ad as 'Analiz Adı', d.Kod + ' ' + d.Ad as 'Metot Kaynağı', l.Matriks, l.Akreditasyon from StokAnalizListesi l " +
            //    "left join StokFirmaBirim f on l.Birim = f.ID left join StokDKDListe d on l.Metot = d.ID where l.Durumu = 'Aktif' and l.Akreditasyon = 'Var' order by l.Kod ", bgl.baglanti());
            //da2.Fill(dt2);
            //gridControl1.DataSource = dt2;


            gridView1.Columns["ID"].Visible = false;
        }

        int yetki;
        void yetkibul()
        {
            SqlCommand komut21 = new SqlCommand("Select * from KaliteYetki where Gorev = N'" + Anasayfa.gorev + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                yetki = Convert.ToInt32(dr21["Analiz"]);
            }
            bgl.baglanti().Close();

            if (yetki == 0 || yetki.ToString() == null)
            {
                barButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                barButtonItem3.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                barButtonItem8.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }

        }


        private void AnalizListesi_Load(object sender, EventArgs e)
        {
            listele();
            yetkibul();


            this.gridView1.Columns[2].Width = 40;
            this.gridView1.Columns[3].Width = 150;
            this.gridView1.Columns[4].Width = 180;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show(skod + " kodlu analizi silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Secim == DialogResult.Yes)
                {
                    string ykod = "P-" + skod;
                    SqlCommand komutSil = new SqlCommand("update StokAnalizListesi set Durumu=@a1 where ID= N'" + aID + "'", bgl.baglanti());
                    komutSil.Parameters.AddWithValue("@a1", "Pasif");
                    komutSil.Parameters.AddWithValue("@a1", ykod);
                    komutSil.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Silme işlemi gerçekleşmiştir.");
                    listele();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata 11003 : " + ex.Message);
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Analiz.AnalizYeni.kod = skod;
            AnalizYeni.aID = aID;
            Analiz.AnalizYeni any = new AnalizYeni();
            any.Show();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlCommand komut21 = new SqlCommand("Select * from DokumanMaster where Kod = N'" + skod + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                DokumanGoruntule.yol = dr21["Path"].ToString();
                DokumanGoruntule.ad = dr21["Ad"].ToString();
            }
            bgl.baglanti().Close();

            if (DokumanGoruntule.yol == "" || DokumanGoruntule.yol == null)
            {
                MessageBox.Show("Bu analiz talimatı henüz sisteme yüklenmemiştir!", "Oooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                DokumanGoruntule dg = new DokumanGoruntule();
                dg.Show();
            }


        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }

        }

        string skod, sad, aID;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr == null)
            {

            }
            else
            {
                skod = dr["Kod"].ToString();
                sad = dr["Analiz Adı"].ToString();
                aID = dr["ID"].ToString();
            }

        }

        private void AnalizListesi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                listele();
            }
        }

        void reizin()
        {
            if (yetki == 0 || yetki.ToString() == null)
            {
                MessageBox.Show("Bu analiz için henüz reçete oluşturulmamıştır!", "Oooppss!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                DialogResult Secim = new DialogResult();
                string newLine = Environment.NewLine;
                Secim = MessageBox.Show("Bu analiz için henüz reçete oluşturulmamıştır!" + newLine + "Yeni reçete oluşturmak ister misiniz ? ", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Secim == DialogResult.Yes)
                {
                    YeniRecete.aID = aID;
                    var mfrm = (Anasayfa)Application.OpenForms["Anasayfa"];
                    if (mfrm != null)
                        mfrm.YeniRecete();
                }
            }


        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //validas
            ValidasyonEkle.gelis = "analiz";
            ValidasyonEkle.aID = aID;
            ValidasyonEkle ve = new ValidasyonEkle();
            ve.Show();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AnalizDetay.aID = aID;
            AnalizDetay.sad = sad;
            AnalizDetay.skod = skod;
            AnalizDetay ad = new AnalizDetay();
            ad.Show();
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AnalizAlt.AnalizID = aID;
            AnalizAlt aa = new AnalizAlt();
            aa.Show();
        }

        int redurum;
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlCommand komut21 = new SqlCommand("Select Count(ID) from StokRecete where AnalizID = N'" + aID + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                redurum = Convert.ToInt32(dr21[0]);
            }
            bgl.baglanti().Close();

            if (redurum == 0)
            {
                reizin();
            }
            else
            {

                Stok.ReceteDetay.aID = aID;
                Stok.ReceteDetay rd = new Stok.ReceteDetay();
                rd.Show();
            }



        }
    }
}
