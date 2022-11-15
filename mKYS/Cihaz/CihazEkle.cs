using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
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

namespace mKYS.Cihaz
{
    public partial class CihazEkle : Form
    {
        public CihazEkle()
        {
            InitializeComponent();
        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;

        }

        private void gridLookUpEdit3_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void gridLookUpEdit4_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void gridLookUpEdit2_Properties_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void gridLookUpEdit3_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GridLookUpEdit edit = sender as GridLookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Close)
            {
                gridLookUpEdit3.EditValue = null;
            }

        }

        private void gridLookUpEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GridLookUpEdit edit = sender as GridLookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                gridLookUpEdit1.EditValue = null;

            }
        }

        private void gridLookUpEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GridLookUpEdit edit = sender as GridLookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                gridLookUpEdit2.EditValue = null;

            }

        }

        private void gridLookUpEdit4_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GridLookUpEdit edit = sender as GridLookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                gridLookUpEdit4.EditValue = null;

            }
        }

        private void tabPane1_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            if (tabPane1.SelectedPage == tabNavigationPage1)
            {
                if (cihazkod == "sicil")
                {
                    Size = new Size(869,420);
                    this.CenterToScreen();
                }
                else
                {
                    Size = new Size(525, 417);
                    this.CenterToScreen();
                }

            }
            else
            {
                Size = new Size(869,420);
                this.CenterToScreen();
            }
        }

        string tedarikciID, birimID, talimatID, kaynakID;
        private void gridLookUpEdit3_EditValueChanged(object sender, EventArgs e)
        {

            if (gridLookUpEdit3.EditValue == null)
                tedarikciID = null;
            else
                tedarikciID = gridLookUpEdit3.EditValue.ToString();


            if (gridLookUpEdit4.EditValue == null)
                talimatID = null;
            else
                talimatID = gridLookUpEdit4.EditValue.ToString();


            if (gridLookUpEdit1.EditValue == null)
                birimID = null;
            else
                birimID = gridLookUpEdit1.EditValue.ToString();

            if (gridLookUpEdit2.EditValue == null)
                kaynakID = null;
            else
                kaynakID = gridLookUpEdit2.EditValue.ToString();

        }

        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select ID, Birim from StokFirmaBirim where Durum= 'Aktif'", bgl.baglanti());
            da2.Fill(dt2);

            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "Birim";
            gridLookUpEdit1.Properties.ValueMember = "ID";


            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID, Ad from StokTedarikci where Durum= 'Aktif'", bgl.baglanti());
            da.Fill(dt);

            gridLookUpEdit3.Properties.DataSource = dt;
            gridLookUpEdit3.Properties.DisplayMember = "Ad";
            gridLookUpEdit3.Properties.ValueMember = "ID";

            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("select ID, Kod, Ad from DokumanMaster where Tur = 'Kullanım Talimatı' and Durum = 'Aktif'", bgl.baglanti());
            da3.Fill(dt3);

            gridLookUpEdit4.Properties.DataSource = dt3;
            gridLookUpEdit4.Properties.DisplayMember = "Ad";
            gridLookUpEdit4.Properties.ValueMember = "ID";

            DataTable dt4 = new DataTable();
            SqlDataAdapter da4 = new SqlDataAdapter("Select ID, Kod, Ad from StokDKDListe where Durum= 'Aktif'", bgl.baglanti());
            da4.Fill(dt4);

            gridLookUpEdit2.Properties.DataSource = dt4;
            gridLookUpEdit2.Properties.DisplayMember = "Ad";
            gridLookUpEdit2.Properties.ValueMember = "ID";

            DataTable dt5 = new DataTable();
            SqlDataAdapter da5 = new SqlDataAdapter("select ID, Ad + ' ' + Soyad as 'Personel' from StokKullanici where Durum= 'Aktif'", bgl.baglanti());
            da5.Fill(dt5);
            gridControl1.DataSource = dt5;
            gridView2.Columns["ID"].Visible = false;

            DataTable dt6 = new DataTable();
            SqlDataAdapter da6 = new SqlDataAdapter("select ID, Kod, Ad from StokAnalizListesi where Durumu = 'Aktif'", bgl.baglanti());
            da6.Fill(dt6);
            gridControl2.DataSource = dt6;
            gridView3.Columns["ID"].Visible = false;
            gridView3.Columns["Kod"].Width = 20;

        }

        void listele2()
        {
            DataTable dt6 = new DataTable();
            SqlDataAdapter da6 = new SqlDataAdapter("select Ad+ ' ' + Soyad as 'Personel' from StokKullanici where ID in (Select PersonelID from CihazYetkili where CihazID = '"+lbl_ycID.Text+"' )", bgl.baglanti());
            da6.Fill(dt6);
            gridControl3.DataSource = dt6;
        }

        void listele3()
        {
            DataTable dt7 = new DataTable();
            SqlDataAdapter da7 = new SqlDataAdapter(" select Kod, Ad from StokAnalizListesi where ID in (Select AnalizID from CihazAnaliz where CihazID = '" + lbl_ycID.Text + "' )", bgl.baglanti());
            da7.Fill(dt7);
            gridControl4.DataSource = dt7;
            this.gridView7.Columns[0].Width = 35;
        }

        public void listele4()
        {
            DataTable dt7 = new DataTable();
            SqlDataAdapter da7 = new SqlDataAdapter("select i.ID, i.Tur as 'İşlem Türü', i.Tarih1 as 'Tarih', i.Aciklama as 'Açıklama', case i.Finout " +
                " when 'i' then k.Ad + ' ' +k.Soyad  when 'o' then t.Ad end as 'Uygulayan' " +
                "from CihazIslem i left join StokTedarikci t on i.FirmaID = t.ID left join StokKullanici k on i.PersonelID = k.ID " +
                " where i.CihazID = '"+cID+ "' and i.Durum='Aktif' order by i.Tarih1 desc ", bgl.baglanti());
            da7.Fill(dt7);
            gridControl5.DataSource = dt7;
            gridView8.Columns["ID"].Visible = false;


            RepositoryItemMemoEdit memo = new RepositoryItemMemoEdit();
            gridView8.Columns["Açıklama"].ColumnEdit = memo;
            gridView8.Columns["Uygulayan"].ColumnEdit = memo;
            gridView8.Columns["Açıklama"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gridView8.Columns["Uygulayan"].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
        }

        void detaybul()
        {
            if (cihazkod == "1")
            {
                SqlCommand komutID = new SqlCommand("Select * From CihazListesi where ID= N'" + cID + "'", bgl.baglanti());
                SqlDataReader drI = komutID.ExecuteReader();
                while (drI.Read())
                {
                    txt_kod.Text = drI["Kod"].ToString(); 
                    txt_ad.Text = drI["Ad"].ToString(); 
                    txt_marka.Text = drI["Marka"].ToString(); 
                    txt_seri.Text = drI["Seri"].ToString(); 
                    txt_tarih.Text = drI["Tarih"].ToString(); 
                    txt_ozellik.Text = drI["Ozellik"].ToString();
                    combo_durum.Text = drI["Durumu"].ToString();
                    int c2ID;
                    c2ID = Convert.ToInt32(drI["BirimID"].ToString());
                    gridLookUpEdit1.EditValue = c2ID;
                    gridLookUpEdit3.EditValue = drI["FirmaID"].ToString();
                    gridLookUpEdit4.EditValue = drI["TalimatID"].ToString();

                }
                bgl.baglanti().Close();

            }
            else if (cihazkod == "2")
            {
                SqlCommand komutID = new SqlCommand("Select * From CihazKalibrasyon where CihazID= N'" + cID + "' and Durum = N'Aktif'", bgl.baglanti());
                SqlDataReader drI = komutID.ExecuteReader();
                while (drI.Read())
                {
                    kal_tip.Text = drI["KalTip"].ToString();
                    ara_siklik.Text = drI["AraSiklik"].ToString();
                    kal_siklik.Text = drI["KalSiklik"].ToString();
                    kal_calisma.Text = drI["Calisma"].ToString();
                    kal_kabul.Text = drI["KabulKriteri"].ToString();
                    kal_aralik.Text = drI["Kalibrasyon"].ToString();
                    gridLookUpEdit2.EditValue = drI["Kaynak"].ToString();

                }
                bgl.baglanti().Close();

                SqlCommand komutI = new SqlCommand("Select * From CihazBakim where CihazID= N'" + cID + "' and Durum = N'Aktif'", bgl.baglanti());
                SqlDataReader dr = komutI.ExecuteReader();
                while (dr.Read())
                {
                    pf_siklik.Text = dr["PfSiklik"].ToString();
                    pf_detay.Text = dr["PfDetay"].ToString();
                    bkm_siklik.Text = dr["BakimSiklik"].ToString();
                    bkm_detay.Text = dr["BakimDetay"].ToString();
                }
                bgl.baglanti().Close();


            }
        }

        void detay2()
        {
            SqlCommand komutID = new SqlCommand("Select * From CihazListesi where ID= N'" + cID + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                txt_kod.Text = drI["Kod"].ToString();
                txt_ad.Text = drI["Ad"].ToString();
                txt_marka.Text = drI["Marka"].ToString();
                txt_seri.Text = drI["Seri"].ToString();
                txt_tarih.Text = drI["Tarih"].ToString();
                txt_ozellik.Text = drI["Ozellik"].ToString();
                combo_durum.Text = drI["Durumu"].ToString();
                int c2ID;
                c2ID = Convert.ToInt32(drI["BirimID"].ToString());
                gridLookUpEdit1.EditValue = c2ID;
                gridLookUpEdit3.EditValue = drI["FirmaID"].ToString();
                gridLookUpEdit4.EditValue = drI["TalimatID"].ToString();

            }
            bgl.baglanti().Close();

            SqlCommand komutI = new SqlCommand("Select * From CihazKalibrasyon where CihazID= N'" + cID + "' and Durum = N'Aktif'", bgl.baglanti());
            SqlDataReader dr = komutI.ExecuteReader();
            while (dr.Read())
            {
                kal_tip.Text = dr["KalTip"].ToString();
                ara_siklik.Text = dr["AraSiklik"].ToString();
                kal_siklik.Text = dr["KalSiklik"].ToString();
                kal_calisma.Text = dr["Calisma"].ToString();
                kal_kabul.Text = dr["KabulKriteri"].ToString();
                kal_aralik.Text = dr["Kalibrasyon"].ToString();
                gridLookUpEdit2.EditValue = dr["Kaynak"].ToString();

            }
            bgl.baglanti().Close();

            SqlCommand komutIx = new SqlCommand("Select * From CihazBakim where CihazID= N'" + cID + "' and Durum = N'Aktif'", bgl.baglanti());
            SqlDataReader drx = komutIx.ExecuteReader();
            while (drx.Read())
            {
                pf_siklik.Text = drx["PfSiklik"].ToString();
                pf_detay.Text = drx["PfDetay"].ToString();
                bkm_siklik.Text = drx["BakimSiklik"].ToString();
                bkm_detay.Text = drx["BakimDetay"].ToString();
            }
            bgl.baglanti().Close();
        }

        int yetki;
        void yetkibul()
        {
            SqlCommand komut21 = new SqlCommand("Select * from KaliteYetki where Gorev = N'" + Anasayfa.gorev + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                yetki = Convert.ToInt32(dr21["Cihaz"]);
            }
            bgl.baglanti().Close();

            if (yetki == 0 || yetki.ToString() == null)
            {
                btn_ekle.Visible = false;
                btn_kalkayit.Visible = false;
                btn_aktary.Visible = false;
                simpleButton1.Visible = false;
                btn_yeni.Visible = false;
                popupContainerEdit1.Visible = false;
                popupContainerEdit2.Visible = false;
                gridControl3.Location = new Point(55, 43);
                gridControl3.Size = new Size(324, 230);
                gridControl4.Location = new Point(439, 43);
                gridControl4.Size = new Size(376, 230);
                barButtonItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }                
            else
            {

            }
               
        }

        public static string cihazkod, cID, kodad;
        private void CihazEkle_Load(object sender, EventArgs e)
        {
            yetkibul();

            if (cihazkod == "" || cihazkod == null)
            {
                listele();
                Size = new Size(525, 417);
                this.CenterToScreen();

            }
            else if (cihazkod == "1")
            {
                lbl_ycID.Text = cID;
                btn_ekle.Text = "Güncelle";
                listele();
                Size = new Size(525, 420);
                this.CenterToScreen();
                tabPane1.SelectedPage = tabNavigationPage1;
                tabNavigationPage2.PageVisible = false;
                tabNavigationPage4.PageVisible = false;
                detaybul();
            }
            else if (cihazkod == "2")
            {
                lbl_ycID.Text = cID;
                btn_kalkayit.Text = "Güncelle";
                listele();
                Text = kodad + " Cihaz Bilgileri";
                Size = new Size(869, 420);
                this.CenterToScreen();
                tabPane1.SelectedPage = tabNavigationPage2;
                tabNavigationPage1.PageVisible = false;
                tabNavigationPage4.PageVisible = false;
                detaybul();
            }
            else if (cihazkod == "sicil")
            {
                lbl_ycID.Text = cID;
                Size = new Size(869, 420);
                this.CenterToScreen();
                btn_print.Visible = true;
                btn_print.Location = new Point(290, 276);
                btn_print.Size = new Size(156, 52);
                btn_ekle.Location = new Point(147, 276);
                btn_ekle.Size = new Size(137, 52);
                gridControl5.Visible = true;
                separatorControl3.Visible = true;
                listele4();
                listele();
                listele2();
                listele3();
                detay2();
                btn_ekle.Text = "Güncelle";
                btn_kalkayit.Text = "Güncelle";
                btn_yeni.Visible = false;
            }
            else
            {
                lbl_ycID.Text = cID;
                listele();
                listele2();
                listele3();
                Text = kodad + " Cihaz Bilgileri";
                Size = new Size(869, 420);
                this.CenterToScreen();
                tabPane1.SelectedPage = tabNavigationPage4;
                tabNavigationPage1.PageVisible = false;
                tabNavigationPage2.PageVisible = false;
                btn_yeni.Visible = false;
            }
        }

        private void CihazEkle_FormClosed(object sender, FormClosedEventArgs e)
        {
            cihazkod = null;
            cID = null;
            kodad = null;
        }

      
        void ekleme()
        {

            if (txt_kod.Text == null || txt_kod.Text == "")
            {
                MessageBox.Show("Lütfen cihaz kodunu giriniz!", "Oopss");
            }
            else
            {
                SqlCommand add = new SqlCommand(" insert into CihazListesi (Kod, Ad, Marka, Seri, FirmaID, BirimID, TalimatID, Tarih, Ozellik,Durumu,Durum) values (@a1, @a2, @a3, @a4, @a5, @a6,@a7,@a8,@a9,@a10,@a11) SET @ID = SCOPE_IDENTITY() ", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", txt_kod.Text);
                add.Parameters.AddWithValue("@a2", txt_ad.Text);
                add.Parameters.AddWithValue("@a3", txt_marka.Text);
                add.Parameters.AddWithValue("@a4", txt_seri.Text);
                if (String.IsNullOrEmpty(tedarikciID))
                {
                    add.Parameters.AddWithValue("@a5", DBNull.Value);
                }
                else
                {
                    add.Parameters.AddWithValue("@a5", tedarikciID);
                }
                if (String.IsNullOrEmpty(birimID))
                {
                    add.Parameters.AddWithValue("@a6", DBNull.Value);
                }
                else
                {
                    add.Parameters.AddWithValue("@a6", birimID);
                }
                if (String.IsNullOrEmpty(talimatID))
                {
                    add.Parameters.AddWithValue("@a7", DBNull.Value);
                }
                else
                {
                    add.Parameters.AddWithValue("@a7", talimatID);
                }
                add.Parameters.AddWithValue("@a8", txt_tarih.Text);
                add.Parameters.AddWithValue("@a9", txt_ozellik.Text);
                add.Parameters.AddWithValue("@a10", combo_durum.Text);
                add.Parameters.AddWithValue("@a11", "Aktif");
                add.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
                add.ExecuteNonQuery();
                lbl_ycID.Text = add.Parameters["@ID"].Value.ToString();
                bgl.baglanti().Close();

                DialogResult cikis = new DialogResult();
                cikis = MessageBox.Show("Cihaz ekleme işlemi başarılı!" + "\n" + "\n" + "Cihaz ile ilgili kalibrasyon, bakım gibi diğer özellikleri eklemek istiyor musunuz ?" + "\n" + "\n" + "Dilerseniz bu özellikleri sonra da güncelleyebilirsiniz!", "Ooppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                if (cikis == DialogResult.Yes)
                { tabPane1.SelectedPage = tabNavigationPage2; }
                else
                { temizle(); }

            }
           
        }

        void guncelle()
        {
            if (txt_kod.Text == null || txt_kod.Text == "")
            {
                MessageBox.Show("Lütfen cihaz kodunu giriniz!", "Oopss");
            }
            else
            {
                SqlCommand add = new SqlCommand(" update CihazListesi set Kod=@a1, Ad=@a2, Marka=@a3, Seri=@a4, FirmaID=@a5, BirimID=@a6, TalimatID=@a7, Tarih=@a8, Ozellik=@a9,Durumu=@a10 where ID = '"+cID+"' ", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", txt_kod.Text);
                add.Parameters.AddWithValue("@a2", txt_ad.Text);
                add.Parameters.AddWithValue("@a3", txt_marka.Text);
                add.Parameters.AddWithValue("@a4", txt_seri.Text);
                if (String.IsNullOrEmpty(tedarikciID))
                {
                    add.Parameters.AddWithValue("@a5", DBNull.Value);
                }
                else
                {
                    add.Parameters.AddWithValue("@a5", tedarikciID);
                }
                if (String.IsNullOrEmpty(birimID))
                {
                    add.Parameters.AddWithValue("@a6", DBNull.Value);
                }
                else
                {
                    add.Parameters.AddWithValue("@a6", birimID);
                }
                if (String.IsNullOrEmpty(talimatID))
                {
                    add.Parameters.AddWithValue("@a7", DBNull.Value);
                }
                else
                {
                    add.Parameters.AddWithValue("@a7", talimatID);
                }
                add.Parameters.AddWithValue("@a8", txt_tarih.Text);
                add.Parameters.AddWithValue("@a9", txt_ozellik.Text);
                add.Parameters.AddWithValue("@a10", combo_durum.Text);
                add.ExecuteNonQuery();
                bgl.baglanti().Close();

                MessageBox.Show("Güncelleme işlemi başarılı!", "Oopss");
            }
        }

        void eklekal()
        {
            if (kal_tip.Text != null || kal_siklik != null || ara_siklik != null || kal_calisma != null || kal_aralik != null || kal_kabul != null )
            {
                SqlCommand add = new SqlCommand("insert into CihazKalibrasyon (CihazID, KalTip, KalSiklik, AraSiklik, Calisma,Kalibrasyon,Kaynak,KabulKriteri, Durum) values (@a1, @a2, @a3, @a4, @a5, @a6,@a7,@a8, @a9)", bgl.baglanti());
                add.Parameters.AddWithValue("@a1", lbl_ycID.Text);
                add.Parameters.AddWithValue("@a2", kal_tip.Text);
                add.Parameters.AddWithValue("@a3", kal_siklik.Text);
                add.Parameters.AddWithValue("@a4", ara_siklik.Text);
                add.Parameters.AddWithValue("@a5", kal_calisma.Text);
                add.Parameters.AddWithValue("@a6", kal_aralik.Text);
                if (String.IsNullOrEmpty(kaynakID))
                {
                    add.Parameters.AddWithValue("@a7", DBNull.Value);
                }
                else
                {
                    add.Parameters.AddWithValue("@a7", kaynakID);
                }

                add.Parameters.AddWithValue("@a8", kal_kabul.Text);
                add.Parameters.AddWithValue("@a9", "Aktif");
                add.ExecuteNonQuery();
                bgl.baglanti().Close();
            }
            else
            {

            }


        }

        void eklebakim()
        {
            if (pf_siklik.Text != null || pf_detay.Text != null || bkm_detay != null || bkm_siklik != null )
            {
                SqlCommand add = new SqlCommand("insert into CihazBakim (CihazID, PfSiklik, PfDetay, BakimSiklik,BakimDetay, Durum) values (@o1, @o2, @o3, @o4, @o5, @o6) ", bgl.baglanti());
                add.Parameters.AddWithValue("@o1", lbl_ycID.Text);
                add.Parameters.AddWithValue("@o2", pf_siklik.Text);
                add.Parameters.AddWithValue("@o3", pf_detay.Text);
                add.Parameters.AddWithValue("@o4", bkm_siklik.Text);
                add.Parameters.AddWithValue("@o5", bkm_detay.Text);
                add.Parameters.AddWithValue("@o6", "Aktif");
                add.ExecuteNonQuery();
                bgl.baglanti().Close();
            }
            else
            {

            }



        }

        void guncellekal()
        {
            SqlCommand add = new SqlCommand("update CihazKalibrasyon set KalTip=@a2, KalSiklik=@a3, AraSiklik=@a4, Calisma=@a5,Kalibrasyon=@a6,Kaynak=@a7,KabulKriteri=@a8 where CihazID = '"+cID+"' " , bgl.baglanti());
            add.Parameters.AddWithValue("@a2", kal_tip.Text);
            add.Parameters.AddWithValue("@a3", kal_siklik.Text);
            add.Parameters.AddWithValue("@a4", ara_siklik.Text);
            add.Parameters.AddWithValue("@a5", kal_calisma.Text);
            add.Parameters.AddWithValue("@a6", kal_aralik.Text);
            if (String.IsNullOrEmpty(kaynakID))
            {
                add.Parameters.AddWithValue("@a7", DBNull.Value);
            }
            else
            {
                add.Parameters.AddWithValue("@a7", kaynakID);
            }

            add.Parameters.AddWithValue("@a8", kal_kabul.Text);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();

        }

        void guncellebakim()
        {
            SqlCommand add = new SqlCommand("update CihazBakim set PfSiklik=@o2, PfDetay=@o3, BakimSiklik=@o4,BakimDetay=@o5 where CihazID = '" + cID + "'", bgl.baglanti());
            add.Parameters.AddWithValue("@o2", pf_siklik.Text);
            add.Parameters.AddWithValue("@o3", pf_detay.Text);
            add.Parameters.AddWithValue("@o4", bkm_siklik.Text);
            add.Parameters.AddWithValue("@o5", bkm_detay.Text);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();

            
        }

        string kalkont, bakimkont;
        void kontrolkal()
        {
            SqlCommand komutI = new SqlCommand("select Count(ID) from CihazKalibrasyon where CihazID= N'" + cID + "' and Durum = 'Aktif'", bgl.baglanti());
            SqlDataReader dr = komutI.ExecuteReader();
            while (dr.Read())
            {
                kalkont = dr[0].ToString();
            }
            bgl.baglanti().Close();
        }

        void kontrolbakim()
        {
            SqlCommand komutI = new SqlCommand("select Count(ID) from CihazBakim where CihazID= N'" + cID + "' and Durum = 'Aktif'", bgl.baglanti());
            SqlDataReader dr = komutI.ExecuteReader();
            while (dr.Read())
            {
                bakimkont = dr[0].ToString();
            }
            bgl.baglanti().Close();
        }

        void temizle()
        {
            lbl_ycID.Text = "";
            txt_ad.Text = "";
            txt_kod.Text = "";
            txt_marka.Text = "";
            txt_ozellik.Text = "";
            txt_seri.Text = "";
            txt_tarih.Text = "";
            gridLookUpEdit1.EditValue = null;
            gridLookUpEdit3.EditValue = null;
            gridLookUpEdit4.EditValue = null;
            gridLookUpEdit2.EditValue = null;
            lbl_ycID.Text = "";
            kal_tip.Text = "";
            kal_siklik.Text = "";
            ara_siklik.Text = "";
            kal_aralik.Text = "";
            kal_aralik.Text = "";
            kal_kabul.Text = "";
            pf_siklik.Text = "";
            pf_detay.Text = "";
            bkm_detay.Text = "";
            bkm_siklik.Text = "";

        }

        string pID, aID;
        private void btn_aktary_Click(object sender, EventArgs e)
        {

            if (lbl_ycID.Text == "" || lbl_ycID.Text == null)
            {
                MessageBox.Show("Lütfen öncelikle 'Cihaz Bilgileri' sayfasından cihazın temel bilgilerini doldurarak kaydediniz!", "Ooopsss!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                SqlCommand ad = new SqlCommand("delete from CihazYetkili where CihazID = '" + lbl_ycID.Text + "' ", bgl.baglanti());
                ad.ExecuteNonQuery();
                bgl.baglanti().Close();

                for (int i = 0; i < gridView2.SelectedRowsCount; i++)
                {
                    int y = Convert.ToInt32(gridView2.GetSelectedRows()[i].ToString());
                    pID = gridView2.GetRowCellValue(y, "ID").ToString();
                    SqlCommand add = new SqlCommand("insert into CihazYetkili (CihazID, PersonelID) values (@a1, @a2) ", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", lbl_ycID.Text);
                    add.Parameters.AddWithValue("@a2", pID);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }

                listele2();

            }



        }

        private void gridView8_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }
        }

        string iid,tur;

        private void CihazEkle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                listele4();
            }
        }

        string yol, ad;
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlCommand komut21 = new SqlCommand("Select * from CihazIslem where ID = N'" + iid + "' ", bgl.baglanti());
            SqlDataReader dr21 = komut21.ExecuteReader();
            while (dr21.Read())
            {
                yol = dr21["Path"].ToString();
                ad = dr21["Tur"].ToString() + " Belgesi";
            }
            bgl.baglanti().Close();

            if (yol == "" || yol == null)
            {
                MessageBox.Show("Bu işlem için henüz belge yüklenmemiştir!", "Ooopss!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                SertifikaGoruntule.ad = ad;
                SertifikaGoruntule.yol = yol;
                SertifikaGoruntule sg = new SertifikaGoruntule();
                sg.Show();
            }

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CihazHareket.gelis = "Güncelle";
            CihazHareket.tur = tur;
            CihazHareket.cID = iid;
            CihazHareket ce = new CihazHareket();
            ce.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show(tur + " işlemini silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Secim == DialogResult.Yes)
                {
                    // SqlCommand komutSil = new SqlCommand("delete from Firma where ID = @p1", bgl.baglanti());
                    SqlCommand komutSil = new SqlCommand("update CihazIslem set Durum=@a1 where ID = N'" + iid + "'", bgl.baglanti());
                    komutSil.Parameters.AddWithValue("@a1", "Pasif");
                    komutSil.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Silme işlemi başarılı!", "Oooppss!");
                    listele4();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata2 : " + ex.Message);
            }
        }

        private void gridView8_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            DataRow dr = gridView8.GetDataRow(gridView8.FocusedRowHandle);
            if (dr == null)
            {

            }
            else
            {
                tur = dr["İşlem Türü"].ToString();
                iid = dr["ID"].ToString();
            }
                

        }

        private void btn_yeni_Click(object sender, EventArgs e)
        {
            tabPane1.SelectedPage = tabNavigationPage1;
            temizle();
            if (Application.OpenForms["CihazListesi"] == null)
            {

            }
            else
            {
                m.listele();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (lbl_ycID.Text == "" || lbl_ycID.Text == null)
            {
                MessageBox.Show("Lütfen öncelikle 'Cihaz Bilgileri' sayfasından cihazın temel bilgilerini doldurarak kaydediniz!", "Ooopsss!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                SqlCommand ad = new SqlCommand("delete from CihazAnaliz where CihazID = '" + lbl_ycID.Text + "' ", bgl.baglanti());
                ad.ExecuteNonQuery();
                bgl.baglanti().Close();

                for (int i = 0; i < gridView3.SelectedRowsCount; i++)
                {
                    int y = Convert.ToInt32(gridView3.GetSelectedRows()[i].ToString());
                    aID = gridView3.GetRowCellValue(y, "ID").ToString();
                    SqlCommand add = new SqlCommand("insert into CihazAnaliz (CihazID, AnalizID) values (@a1, @a2) ", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", lbl_ycID.Text);
                    add.Parameters.AddWithValue("@a2", aID);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }

                listele3();
            }


          
        }

        CihazListesi m = (CihazListesi)System.Windows.Forms.Application.OpenForms["CihazListesi"];

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_ekle.Text == "Güncelle")
                {
                    guncelle();
                }
                else
                {
                    ekleme();
                }
                

                if (Application.OpenForms["CihazListesi"] == null)
                {

                }
                else
                {
                    m.listele();
                }
            }
            catch (Exception Ex)
            {

                MessageBox.Show("Hata CE 121: " + Ex);
            }          

        }

        private void btn_kalkayit_Click(object sender, EventArgs e)
        {
            if (btn_kalkayit.Text == "Güncelle")
            {
                kontrolkal();


                if (kalkont == "0" )
                {
                    eklekal();  
                }
                else
                {
                    guncellekal();
                }

                kontrolbakim();

                if (bakimkont == "0")
                {
                    eklebakim();
                }
                else
                {
                    guncellebakim();
                }


                MessageBox.Show("Kalibrasyon ve bakım bilgileri başarıyla güncellenmiştir!", "Oopss");

            }
            else
            {

                if (lbl_ycID.Text == "" || lbl_ycID.Text == null)
                {
                    MessageBox.Show("Lütfen öncelikle 'Cihaz Bilgileri' sayfasından cihazın temel bilgilerini doldurarak kaydediniz!", "Ooopsss!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    eklekal();
                    tabPane1.SelectedPage = tabNavigationPage4;
                }
            }

           

        }

   





    }
}
