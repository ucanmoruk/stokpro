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

namespace mKYS.Analiz
{
    public partial class ValidasyonEkle : Form
    {
        public ValidasyonEkle()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {
            DataTable dt5 = new DataTable();
            SqlDataAdapter da5 = new SqlDataAdapter("select ID, Ad + ' ' + Soyad as 'Personel' from StokKullanici where Durum= 'Aktif'", bgl.baglanti());
            da5.Fill(dt5);
            gridControl1.DataSource = dt5;
            gridView2.Columns["ID"].Visible = false;
        }

        void listele2()
        {
            DataTable dt6 = new DataTable();
            SqlDataAdapter da6 = new SqlDataAdapter("select Ad+ ' ' + Soyad as 'Personel' from StokKullanici where ID in (Select PersonelID from ValidasyonYetkili where AnalizID = '"+aID+"' and Durum = 'Aktif' or Durum = 'Ortak')", bgl.baglanti());
            da6.Fill(dt6);
            gridControl3.DataSource = dt6;
        }

        void planlistele()
        {
            DataTable dt6 = new DataTable();
            SqlDataAdapter da6 = new SqlDataAdapter("select Ad+ ' ' + Soyad as 'Personel' from StokKullanici where ID in (Select PersonelID from ValidasyonYetkili where AnalizID = '" + aID + "' and Durum = 'Plan')", bgl.baglanti());
            da6.Fill(dt6);
            gridControl3.DataSource = dt6;
        }

        int mID;
        void detaybul()
        {
            SqlCommand komut21 = new SqlCommand("Select * from ValidasyonVeri where AnalizID = N'" + aID + "' and Durum = 'Aktif'", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                urun.Text = dr21["Urun"].ToString();
                date_basla.EditValue = Convert.ToDateTime(dr21["Tarih1"].ToString());
                date_bit.EditValue = Convert.ToDateTime(dr21["Tarih2"].ToString());
                birim.Text = dr21["Birim"].ToString();
                lod.Text = dr21["Lod"].ToString();
                loq.Text = dr21["Loq"].ToString();
                gerikazanim.Text = dr21["GK"].ToString();
                bel.Text = dr21["Bel"].ToString();
                txt_kal.Text = dr21["Kalibrasyon"].ToString(); 
                txt_ek.Text = dr21["Ek"].ToString(); 

            }
            bgl.baglanti().Close();

            SqlCommand komut2 = new SqlCommand("Select * from  StokAnalizListesi where ID = N'" + aID + "' ", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                kod.Text = dr2["Kod"].ToString();
                ad.Text = dr2["Ad"].ToString();
                mID = Convert.ToInt32(dr2["Metot"].ToString());

                SqlCommand komut1 = new SqlCommand("Select * from  StokDKDListe where ID = N'" + mID + "' ", bgl.baglanti());
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    string kod = dr1["Kod"].ToString();
                    string ad = dr1["Ad"].ToString();
                    metot.Text = kod+" "+ad;
                }
                bgl.baglanti().Close();
            }
            bgl.baglanti().Close();


        }

        void analizdetaybul()
        {
            SqlCommand komut2 = new SqlCommand("Select * from  StokAnalizListesi where ID = N'" + aID + "' ", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                kod.Text = dr2["Kod"].ToString();
                ad.Text = dr2["Ad"].ToString();
                mID = Convert.ToInt32(dr2["Metot"].ToString());

                SqlCommand komut1 = new SqlCommand("Select * from  StokDKDListe where ID = N'" + mID + "' ", bgl.baglanti());
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    string kod = dr1["Kod"].ToString();
                    string ad = dr1["Ad"].ToString();
                    metot.Text = kod + " " + ad;
                }
                bgl.baglanti().Close();
            }
            bgl.baglanti().Close();


        }

        void plandetaybul()
        {
            SqlCommand komut21 = new SqlCommand("Select s.Kod, s.Ad, d.Kod+ ' '+d.Ad as 'Metot', v.Urun, v.Tarih1,v.Tarih2" +
                " from ValidasyonPlan v inner join StokAnalizListesi s on v.AnalizID = s.ID  " +
                " inner join StokDKDListe d on s.Metot = d.ID where v.ID = N'" + vID + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                kod.Text = dr21["Kod"].ToString();
                ad.Text = dr21["Ad"].ToString();
                metot.Text = dr21["Metot"].ToString();
                urun.Text = dr21["Urun"].ToString();
                date_basla.EditValue = Convert.ToDateTime(dr21["Tarih1"].ToString());
                date_bit.EditValue = Convert.ToDateTime(dr21["Tarih2"].ToString());
            }
            bgl.baglanti().Close();

        }

        int o2;
        string akod, aad;
        void kontrol()
        {
            SqlCommand komut2 = new SqlCommand("Select * from  StokAnalizListesi where ID = N'" + aID + "' ", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                akod= dr2["Kod"].ToString();
                aad = dr2["Ad"].ToString();
            }
            bgl.baglanti().Close();

            SqlCommand komut12 = new SqlCommand("Select Count(ID) from ValidasyonVeri where AnalizID = N'" + aID + "' and Durum = 'Aktif' ", bgl.baglanti());
                SqlDataReader dr12 = komut12.ExecuteReader();
                while (dr12.Read())
                {
                    o2 = Convert.ToInt32(dr12[0]);
                }
                bgl.baglanti().Close();
                      
        }

        int o3;
        void kontrol2()
        {
            SqlCommand komut12 = new SqlCommand("Select Count(ID) from ValidasyonVeri where AnalizID = N'" + aID + "'  and Ek= '"+txt_ek.Text+ "' and Durum = 'Aktif'", bgl.baglanti());
            SqlDataReader dr12 = komut12.ExecuteReader();
            while (dr12.Read())
            {
                o3 = Convert.ToInt32(dr12[0]);
            }
            bgl.baglanti().Close();
        }

        YeniPlanListesi X = (YeniPlanListesi)System.Windows.Forms.Application.OpenForms["YeniPlanListesi"];

        void ekleme()
        {
            if (date_basla.EditValue == null || date_bit.EditValue == null)
            {
                MessageBox.Show("Lütfen validasyon tarihlerini seçiniz!" , "Ooopss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (btn_save.Text == "Kaydet")
                {
                    SqlCommand add = new SqlCommand("insert into ValidasyonVeri (AnalizID, Urun, Tarih1, Tarih2, Birim, Lod, Loq, GK, Bel, Durum, Kalibrasyon, Ek) values (@a1, @a2, @a3, @a4, @a5, @a6,@a7,@a8,@a9,@a11, @a12, @a13) ", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", aID);
                    add.Parameters.AddWithValue("@a2", urun.Text);
                    add.Parameters.AddWithValue("@a3", date_basla.EditValue);
                    add.Parameters.AddWithValue("@a4", date_bit.EditValue);
                    add.Parameters.AddWithValue("@a5", birim.Text);
                    add.Parameters.AddWithValue("@a6", lod.Text);
                    add.Parameters.AddWithValue("@a7", loq.Text);
                    add.Parameters.AddWithValue("@a8", gerikazanim.Text);
                    add.Parameters.AddWithValue("@a9", bel.Text);
                    add.Parameters.AddWithValue("@a11", "Aktif");
                    add.Parameters.AddWithValue("@a12", txt_kal.Text);
                    add.Parameters.AddWithValue("@a13", txt_ek.Text);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    MessageBox.Show("Veriler başarıyla kaydedildi!", "Oooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if(btn_save.Text == "Güncelle")
                {
                    DialogResult cikis = new DialogResult();
                    cikis = MessageBox.Show(kod.Text + " kodlu analizin validasyon verilerini güncellemek mi istiyorsunuz ?", "Uyarı", MessageBoxButtons.YesNo);
                    if (cikis == DialogResult.Yes)
                    {
                        SqlCommand add = new SqlCommand("update ValidasyonVeri set Urun=@a1, Tarih1=@a2, Tarih2=@a3, Birim=@a4, Lod=@a5, Loq=@a6, GK=@a7, Bel=@a8, Kalibrasyon=@a9, Ek=@a10 where AnalizID = '" + aID + "' and Durum = 'Aktif' ", bgl.baglanti());
                        add.Parameters.AddWithValue("@a1", urun.Text);
                        add.Parameters.AddWithValue("@a2", date_basla.EditValue);
                        add.Parameters.AddWithValue("@a3", date_bit.EditValue);
                        add.Parameters.AddWithValue("@a4", birim.Text);
                        add.Parameters.AddWithValue("@a5", lod.Text);
                        add.Parameters.AddWithValue("@a6", loq.Text);
                        add.Parameters.AddWithValue("@a7", gerikazanim.Text);
                        add.Parameters.AddWithValue("@a8", bel.Text);
                        add.Parameters.AddWithValue("@a9", txt_kal.Text);
                        add.Parameters.AddWithValue("@a10", txt_ek.Text);
                        add.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        MessageBox.Show("Analiz validasyon bilgileri başarıyla güncellenmiştir!", "Ooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    }

                }
                else if (btn_save.Text == "Kaydet!")
                {
                    kontrol2();

                    if (o3 == 0)
                    {
                        SqlCommand add = new SqlCommand("insert into ValidasyonVeri (AnalizID, Urun, Tarih1, Tarih2, Birim, Lod, Loq, GK, Bel, Durum, Kalibrasyon, Ek) values (@a1, @a2, @a3, @a4, @a5, @a6,@a7,@a8,@a9,@a11, @a12, @a13) ", bgl.baglanti());
                        add.Parameters.AddWithValue("@a1", aID);
                        add.Parameters.AddWithValue("@a2", urun.Text);
                        add.Parameters.AddWithValue("@a3", date_basla.EditValue);
                        add.Parameters.AddWithValue("@a4", date_bit.EditValue);
                        add.Parameters.AddWithValue("@a5", birim.Text);
                        add.Parameters.AddWithValue("@a6", lod.Text);
                        add.Parameters.AddWithValue("@a7", loq.Text);
                        add.Parameters.AddWithValue("@a8", gerikazanim.Text);
                        add.Parameters.AddWithValue("@a9", bel.Text);
                        add.Parameters.AddWithValue("@a11", "Aktif");
                        add.Parameters.AddWithValue("@a12", txt_kal.Text);
                        add.Parameters.AddWithValue("@a13", txt_ek.Text);
                        add.ExecuteNonQuery();
                        bgl.baglanti().Close();

                        MessageBox.Show("Veriler başarıyla kaydedildi!", "Oooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        DialogResult cikis = new DialogResult();
                        cikis = MessageBox.Show(kod.Text + '-' + txt_ek.Text + " validasyon verileri tanımlı! Ek numarasını değiştirmek ister misiniz ?", "Uyarı", MessageBoxButtons.YesNo);
                        if (cikis == DialogResult.Yes)
                        {

                        }
                        else
                        {
                            SqlCommand add = new SqlCommand("insert into ValidasyonVeri (AnalizID, Urun, Tarih1, Tarih2, Birim, Lod, Loq, GK, Bel, Durum, Kalibrasyon, Ek) values (@a1, @a2, @a3, @a4, @a5, @a6,@a7,@a8,@a9,@a11, @a12, @a13) ", bgl.baglanti());
                            add.Parameters.AddWithValue("@a1", aID);
                            add.Parameters.AddWithValue("@a2", urun.Text);
                            add.Parameters.AddWithValue("@a3", date_basla.EditValue);
                            add.Parameters.AddWithValue("@a4", date_bit.EditValue);
                            add.Parameters.AddWithValue("@a5", birim.Text);
                            add.Parameters.AddWithValue("@a6", lod.Text);
                            add.Parameters.AddWithValue("@a7", loq.Text);
                            add.Parameters.AddWithValue("@a8", gerikazanim.Text);
                            add.Parameters.AddWithValue("@a9", bel.Text);
                            add.Parameters.AddWithValue("@a11", "Aktif");
                            add.Parameters.AddWithValue("@a12", txt_kal.Text);
                            add.Parameters.AddWithValue("@a13", txt_ek.Text);
                            add.ExecuteNonQuery();
                            bgl.baglanti().Close();

                            MessageBox.Show("Veriler başarıyla kaydedildi!", "Oooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }

                   
                }
                else 
                {
                    ////plan tamamlandığı zaman çalışacak kod!
                    //// validasyon plan listeslini güncellemeyi de buradan yaptır
                    //SqlCommand add2 = new SqlCommand("update ValidasyonVeri set Durumu=@o1, Durum = @o2, Urun= @o3,Tarih1= @o4, Tarih2= @o5, Birim= @o6," +
                    //    " Lod= @o7, Loq= @o8, GK= @o9, Bel= @o10 where ID = '" + vID + "'", bgl.baglanti());
                    //add2.Parameters.AddWithValue("@o1", "Gerçekleşti");
                    //add2.Parameters.AddWithValue("@o2", "Ortak");
                    //add2.Parameters.AddWithValue("@o3", urun.Text);
                    //add2.Parameters.AddWithValue("@o4", date_basla.EditValue);
                    //add2.Parameters.AddWithValue("@o5", date_bit.EditValue);
                    //add2.Parameters.AddWithValue("@o6", birim.Text);
                    //add2.Parameters.AddWithValue("@o7", lod.Text);
                    //add2.Parameters.AddWithValue("@o8", loq.Text);
                    //add2.Parameters.AddWithValue("@o9", gerikazanim.Text);
                    //add2.Parameters.AddWithValue("@o10", bel.Text);
                    //add2.ExecuteNonQuery();
                    //bgl.baglanti().Close();

                    SqlCommand add = new SqlCommand("insert into ValidasyonVeri (AnalizID, Urun, Tarih1, Tarih2, Birim, Lod, Loq, GK, Bel, Durum, Kalibrasyon, Ek) values (@a1, @a2, @a3, @a4, @a5, @a6,@a7,@a8,@a9,@a11, @a12, @a13) ", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", aID);
                    add.Parameters.AddWithValue("@a2", urun.Text);
                    add.Parameters.AddWithValue("@a3", date_basla.EditValue);
                    add.Parameters.AddWithValue("@a4", date_bit.EditValue);
                    add.Parameters.AddWithValue("@a5", birim.Text);
                    add.Parameters.AddWithValue("@a6", lod.Text);
                    add.Parameters.AddWithValue("@a7", loq.Text);
                    add.Parameters.AddWithValue("@a8", gerikazanim.Text);
                    add.Parameters.AddWithValue("@a9", bel.Text);
                    add.Parameters.AddWithValue("@a11", "Aktif");
                    add.Parameters.AddWithValue("@a12", txt_kal.Text);
                    add.Parameters.AddWithValue("@a13", txt_ek.Text);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    MessageBox.Show("Veriler başarıyla kaydedildi!", "Oooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


               //     MessageBox.Show("Başarıyla kaydedildi! ", "Oooppss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    if (Application.OpenForms["YeniPlanListesi"] == null)
                    { }
                    else
                    {
                        X.listele();
                    }

                }

            }
        }


        ValidasyonListesi m = (ValidasyonListesi)System.Windows.Forms.Application.OpenForms["ValidasyonListesi"];

        public static string aID, gelis, vID;
        private void ValidasyonEkle_Load(object sender, EventArgs e)
        {
            listele();
        

            if (gelis == "plan")
            {
                planlistele();
                plandetaybul();
                btn_save.Text = "Plan Tamamlandı!";
            }
            else if (gelis == "güncelle")
            {
                detaybul();
                listele2();
                btn_save.Text = "Güncelle";

            }
            else if (gelis == "analiz")
            {

                kontrol();

                if (o2 == 0)
                {
                    analizdetaybul();
                    btn_save.Text = "Kaydet";
                }
                else
                {
                    DialogResult cikis = new DialogResult();
                    cikis = MessageBox.Show(akod + ' ' + aad + " analizin validasyon verilerini güncellemek mi istiyorsunuz ?", "Uyarı", MessageBoxButtons.YesNo);
                    if (cikis == DialogResult.Yes)
                    {
                        detaybul();
                        listele2();
                        btn_save.Text = "Güncelle";
                    }
                    else
                    {
                        analizdetaybul();
                        btn_save.Text = "Kaydet!";
                    }
                   

                }
            }
            else
            {               
                
                kontrol();

                if (o2 == 0)
                {
                    btn_save.Text = "Kaydet";
                }
                else
                {
                    detaybul();
                    listele2();
                    btn_save.Text = "Güncelle";
                }
            }

        }

        string pID;
        private void btn_aktary_Click(object sender, EventArgs e)
        {
            SqlCommand ad = new SqlCommand("delete from ValidasyonYetkili where AnalizID = '" + aID + "' and Durum = 'Aktif' ", bgl.baglanti());
            ad.ExecuteNonQuery();
            bgl.baglanti().Close();

            for (int i = 0; i < gridView2.SelectedRowsCount; i++)
            {
                int y = Convert.ToInt32(gridView2.GetSelectedRows()[i].ToString());
                pID = gridView2.GetRowCellValue(y, "ID").ToString();
                SqlCommand add = new SqlCommand("insert into ValidasyonYetkili (AnalizID, PersonelID, Durum) values (@a1, @a2, @a3) ", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", aID);
                add.Parameters.AddWithValue("@a2", pID);
                add.Parameters.AddWithValue("@a3", "Aktif");
                add.ExecuteNonQuery();
                bgl.baglanti().Close();
            }


            listele2();
        }

        private void ValidasyonEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            aID = null;
            gelis = null;
            vID = null;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            ekleme();

            if (Application.OpenForms["ValidasyonListesi"] == null)
            { }
            else
            {
                m.listele();
            }
        }

        private void gridControl3_Click(object sender, EventArgs e)
        {

        }

        private void popupContainerEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
