using BusinessLayer.Services;
using BusinessLayer.ViewModels;
using DevExpress.XtraEditors;
using mKYS.Numune;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace mKYS
{
    public partial class NumKabv2 : Form
    {
        NKR n = (NKR)System.Windows.Forms.Application.OpenForms["NKR"];
        sqlbaglanti bgl = new sqlbaglanti();
        NKRService nKRService = new NKRService(Giris.sqlTip);
        NKR2Service nKR2Service = new NKR2Service(Giris.sqlTip);
        NumuneDetayService numuneDetayService = new NumuneDetayService(Giris.sqlTip);
        NumuneDetay2Service numuneDetay2Service = new NumuneDetay2Service(Giris.sqlTip);
        TerminService terminService = new TerminService(Giris.sqlTip);
        Rapor_DurumService rapor_DurumService = new Rapor_DurumService(Giris.sqlTip);
        OdemeService odemeService = new OdemeService(Giris.sqlTip);
        FotografService fotografService = new FotografService(Giris.sqlTip);

        public static int nID;
        public bool isUpdated = false;

        int yetkiliID, denetciID;
        string taleppath, talepad, talepext;

        public static string akredite, analizsayisi, id, o2;
        public static string name;
        public static string name2;

        string yenisim, ftpfullpath, yeniyol;
        string analizadi, metot;
        public static int TurID, ykrID;
        string alicifirma;
        int contRap, oo2;
        public static string rDurumu = "Rapor Beklemede";
        public static string fDurumu = "Fatura Kesilmedi";

        public static int EvrakNo, maxevrak;
        public static int maxrapor;

        NKRVM nKRVMYeni;
        NKRVM nKRVMEski;
        NKR2VM nKR2VMYeni;
        NKR2VM nKR2VMEski;
        NumuneDetayVM numuneDetayVMEski;
        NumuneDetayVM numuneDetayVMYeni;
        NumuneDetay2VM numuneDetay2VMEski;
        NumuneDetay2VM numuneDetay2VMYeni;
        TerminVM terminVMEski;
        TerminVM terminVMYeni;
        Rapor_DurumVM rapor_DurumuVMEski;
        Rapor_DurumVM rapor_DurumuVMYeni;
        OdemeVM odemeVMEski;
        OdemeVM odemeVMYeni;
        FotografVM fotografVMEski;
        FotografVM fotografVMYeni;


        public NumKabv2()
        {
            InitializeComponent();
        } 

        public void Firma()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select ID, Firma_Adi from Firma where Durum = N'Aktif'", bgl.baglanti());
            da2.Fill(dt2);
            gridLookUpEdit3.Properties.DataSource = dt2;
            gridLookUpEdit3.Properties.DisplayMember = "Firma_Adi";
            gridLookUpEdit3.Properties.ValueMember = "ID";

            DataTable dt12 = new DataTable();
            SqlDataAdapter da12 = new SqlDataAdapter("select ID, Firma_Adi from Firma where Durum = N'Aktif'", bgl.baglanti());
            da12.Fill(dt12);
            gridLookUpEdit6.Properties.DataSource = dt12;
            gridLookUpEdit6.Properties.DisplayMember = "Firma_Adi";
            gridLookUpEdit6.Properties.ValueMember = "ID";

            DataTable dt22 = new DataTable();
            SqlDataAdapter da22 = new SqlDataAdapter("select ID, Firma_Adi from Firma where Tur = 'Proje' and Durum = N'Aktif' ", bgl.baglanti());
            da22.Fill(dt22);
            gridLookUpEdit5.Properties.DataSource = dt22;
            gridLookUpEdit5.Properties.DisplayMember = "Firma_Adi";
            gridLookUpEdit5.Properties.ValueMember = "ID";

            DataTable dt122 = new DataTable();
            SqlDataAdapter da122 = new SqlDataAdapter("select l.ID as 'ID', l.TeklifNo as 'TeklifNo', f.Firma_Adi from TeklifListe l left join Firma f on l.FirmaID = f.ID where l.Durum <> 'Pasif' order by l.ID desc", bgl.baglanti());
            da122.Fill(dt122);
            gridLookUpEdit2.Properties.DataSource = dt122;
            gridLookUpEdit2.Properties.DisplayMember = "TeklifNo";
            gridLookUpEdit2.Properties.ValueMember = "ID";
        }
      
        private void Evrakmax()
        {
            SqlCommand komutm = new SqlCommand("select max(Evrak_No) from NKR", bgl.baglanti());
            SqlDataReader drm = komutm.ExecuteReader();
            while (drm.Read())
            {
                maxevrak = Convert.ToInt32(drm[0].ToString());
            }
            bgl.baglanti().Close();
        }

        private void EvrakNoo()
        {
            SqlCommand komut2 = new SqlCommand("select count(Evrak_No) from NKR where Evrak_No = N'" + txtEvrak.Text + "'", bgl.baglanti());
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                EvrakNo = Convert.ToInt32(dr[0].ToString());
            }
            bgl.baglanti().Close();
        }

        private void txtEvrak_TextChanged(object sender, EventArgs e)
        {
            EvrakNoo();
        }
   
        private void RaporNoMax()
        {
            if (combo_grup.Text == "Özel2")
            {
                SqlCommand komutm = new SqlCommand("select TOP 1 RaporNo from NKR where Grup = 'Özel2' order by ID desc ", bgl.baglanti());
                SqlDataReader drm = komutm.ExecuteReader();
                while (drm.Read())
                {
                    maxrapor = Convert.ToInt32(drm[0].ToString());
                }
                bgl.baglanti().Close();
            }
            else
            {
                SqlCommand komutm = new SqlCommand("select MAX(RaporNo) from NKR", bgl.baglanti());
                SqlDataReader drm = komutm.ExecuteReader();
                while (drm.Read())
                {
                    maxrapor = Convert.ToInt32(drm[0].ToString());
                }
                bgl.baglanti().Close();
            }

        }

        private void combo_grup_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            combo_tur.Text = null;

            combo_tur.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("Select * from Numune_Grup where Grup = N'" + combo_grup.Text + "' order by Tur", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                combo_tur.Properties.Items.Add(dr["Tur"]);
            }
            bgl.baglanti().Close();

            RaporNoMax();
            txtRapor.Text = (maxrapor + 1).ToString();

            if (combo_grup.Text == "Özel" || combo_grup.Text == "Özel2")
            {
                // txt_basvuru.Enabled = false;
                //  txt_marka.Enabled = false;
                //  txt_model.Enabled = false;
                //  combo_tur.Enabled = false;
                labelControl5.Text = "Alıcı / Üretici Firma:";
                txt_lot.Enabled = true;
                txt_skt.Enabled = true;
                txt_uretim.Enabled = true;
                combo_denetci.Visible = false;
                txt_alicifirma.Visible = true;
                combo_bakanlik.Visible = false;
            }
            else if (combo_grup.Text == "Bakanlık")
            {
                txt_lot.Enabled = false;
                txt_skt.Enabled = false;
                txt_uretim.Enabled = false;
                combo_tur.Enabled = true;
                txt_basvuru.Enabled = true;
                txt_marka.Enabled = true;
                //txt_model.Enabled = true;
                txt_alicifirma.Visible = false;
                combo_bakanlik.Visible = true;
                combo_denetci.Visible = true;
                labelControl5.Text = "Bakanlık / Denetçi:";

            }
            else if (combo_grup.Text == "Tareks")
            {
                txt_lot.Enabled = false;
                txt_skt.Enabled = false;
                txt_uretim.Enabled = false;
                combo_tur.Enabled = true;
                txt_basvuru.Enabled = true;
                txt_marka.Enabled = true;
                //txt_model.Enabled = true;
                txt_alicifirma.Visible = true;
                combo_bakanlik.Visible = false;
                labelControl5.Text = "Alıcı / Üretici Firma:";
                combo_denetci.Visible = false;
            }
            else
            {
                txt_lot.Enabled = true;
                txt_skt.Enabled = true;
                txt_uretim.Enabled = true;
                combo_tur.Enabled = false;
                labelControl5.Text = "Alıcı / Üretici Firma:";
                txt_basvuru.Enabled = true;
                txt_marka.Enabled = true;
                //txt_model.Enabled = true;
                txt_alicifirma.Visible = true;
                combo_bakanlik.Visible = false;
                combo_denetci.Visible = false;
            }
        }

        private void gridLookUpEdit3_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select ID, Yetkili From Yetkili where Firma_ID = N'" + gridLookUpEdit3.EditValue + "'", bgl.baglanti());
            da2.Fill(dt2);
            gridLookUpEdit4.Properties.DataSource = dt2;
            gridLookUpEdit4.Properties.DisplayMember = "Yetkili";
            gridLookUpEdit4.Properties.ValueMember = "ID";
        }

        private void btn_devam_Click(object sender, EventArgs e)
        {
            tabPane1.SelectedPage = tabNavigationPage3;
        }

        public void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select ID, Aciklama from NumuneX3 where Durum = 'Aktif'", bgl.baglanti());
            da2.Fill(dt2);
            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "Aciklama";
            gridLookUpEdit1.Properties.ValueMember = "ID";
        }

        private void txtEvrak_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }

        }

        private void txtAdet_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }
        }

        private void fotokaydet()
        {
            try
            {
                if (name == null || name == "")
                {

                }
                else
                {
                    string isim = Path.GetFileName(name);
                    yenisim = DateTime.Now.ToString("dd.MM.yyyy") + "_" + DateTime.Now.ToString("HH.mm.ss") + lbl_rapno.Text + " - " + isim;

                    using (var client = new WebClient())
                    {
                        string ftpUsername = "massgrup";
                        string ftpPassword = "!88n2ee5Q";
                        ftpfullpath = "ftp://" + "www.massgrup.com/httpdocs/mask/Numune/Foto_2021" + "/" + yenisim;
                        yeniyol = "http://" + "www.massgrup.com/mask/Numune/Foto_2021" + "/" + yenisim;
                        client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                        client.UploadFile(ftpfullpath, name);
                    }

                    //  File.Copy(name, Path.Combine(@"\\WDMyCloud\Numune\2020\Foto", yenisim), true);
                    //  string yol = Path.Combine(@"C:\Users\X260\Desktop\Yeni Klasör", yenisim);
                    //string yol = Path.Combine(@"\\WDMyCloud\Numune\2020\Foto", yenisim);
                    //File.Copy(name, yol, true);

                    SqlCommand komut = new SqlCommand("Select ID from NKR where RaporNo = N'" + lbl_rapno.Text + "' ", bgl.baglanti());
                    SqlDataReader dr = komut.ExecuteReader();
                    while (dr.Read())
                    {
                        txt_yeniID.Text = dr[0].ToString();
                    }
                    bgl.baglanti().Close();


                    SqlCommand ekle = new SqlCommand("insert into Fotograf(RaporID,Path) values(@d1,@d2)", bgl.baglanti());
                    ekle.Parameters.AddWithValue("@d1", txt_yeniID.Text);
                    ekle.Parameters.AddWithValue("@d2", yenisim);
                    ekle.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    name = "";
                }

                // Fotograf db sine kaydedilir bundan sonra..
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata 124134: " + ex);
            }
        }

        private void fotokaydetTalep(string yenifile)
        {
            try
            {
                using (var client = new WebClient())
                {
                    string ftpUsername = "massgrup";
                    string ftpPassword = "!88n2ee5Q";
                    string ftpfullpath2 = "ftp://" + "www.massgrup.com/httpdocs/mask/Numune/Foto_2021" + "/" + yenifile;
                    string yeniyol2 = "http://" + "www.massgrup.com/mask/Numune/Foto_2021" + "/" + yenifile;
                    client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                    client.UploadFile(ftpfullpath2, name2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata 124134: " + ex);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // open.InitialDirectory = "C:\\";
            open.InitialDirectory = path;
            open.Filter = "Fotoğraf (*.jpg)|*.jpg|Tüm Dosyalar(*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                name = open.FileName;
                pictureEdit1.Image = new Bitmap(open.FileName);
            }
        }

        private void durumekle()
        {
            DateTime tarih = DateTime.Now;
            SqlCommand add = new SqlCommand("insert into NumuneDurum (RaporNo, Durum, Kim) values (@o1, @o3,@o4) ; " +
                " insert into NumuneTeslim (RaporNo,Tarih, Durum, Kim) values (@o1, @o2, @o3,@o4)", bgl.baglanti());
            add.Parameters.AddWithValue("@o1", lbl_rapno.Text);
            add.Parameters.AddWithValue("@o2", tarih);
            add.Parameters.AddWithValue("@o3", "Numune Kabul Edildi");
            add.Parameters.AddWithValue("@o4", Giris.kullaniciID);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
        }  

        private void denetcibul()
        {
            if (combo_bakanlik.Text == "Avrupa")
            {
                SqlCommand komut2 = new SqlCommand("select Yetkili from yetkili where Firma_ID in (select ID from Firma where Firma_Adi like '%Ticaret Bakanlığı Avrupa%')", bgl.baglanti());
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    combo_denetci.Properties.Items.Add(dr2[0]);
                }
                bgl.baglanti().Close();
            }
            else if (combo_bakanlik.Text == "Anadolu")
            {
                SqlCommand komut2 = new SqlCommand("select Yetkili from yetkili where Firma_ID in (select ID from Firma where Firma_Adi like '%Ticaret Bakanlığı Anadolu%')", bgl.baglanti());
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    combo_denetci.Properties.Items.Add(dr2[0]);
                }
                bgl.baglanti().Close();
            }
            else if (combo_bakanlik.Text == "Gürbulak")
            {
                SqlCommand komut2 = new SqlCommand("select Yetkili from yetkili where Firma_ID in (select ID from Firma where Firma_Adi like '%Ticaret Bakanlığı Gürbulak%')", bgl.baglanti());
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    combo_denetci.Properties.Items.Add(dr2[0]);
                }
                bgl.baglanti().Close();
            }
            else
            {
                SqlCommand komut2 = new SqlCommand("select Yetkili from yetkili where Firma_ID in (select ID from Firma where Firma_Adi like '%Ticaret Bakanlığı İzmir%')", bgl.baglanti());
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    combo_denetci.Properties.Items.Add(dr2[0]);
                }
                bgl.baglanti().Close();
            }
        }

        private void combo_denetci_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_bakanlik.Text == "Avrupa")
            {
                SqlCommand komut2 = new SqlCommand("select ID from yetkili where Yetkili = N'" + combo_denetci.Text + "' and Firma_ID in (select ID from Firma where Firma_Adi like '%Ticaret Bakanlığı Avrupa%')", bgl.baglanti());
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    denetciID = Convert.ToInt32(dr2[0].ToString());
                }
                bgl.baglanti().Close();
            }
            else if (combo_bakanlik.Text == "Anadolu")
            {
                SqlCommand komut2 = new SqlCommand("select ID from yetkili where Yetkili = N'" + combo_denetci.Text + "' and Firma_ID in (select ID from Firma where Firma_Adi like '%Ticaret Bakanlığı Anadolu%')", bgl.baglanti());
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    denetciID = Convert.ToInt32(dr2[0].ToString());
                }
                bgl.baglanti().Close();
            }
            else if (combo_bakanlik.Text == "Gürbulak")
            {
                SqlCommand komut2 = new SqlCommand("select ID from yetkili where Yetkili = N'" + combo_denetci.Text + "' and Firma_ID in (select ID from Firma where Firma_Adi like '%Ticaret Bakanlığı Gürbulak%')", bgl.baglanti());
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    denetciID = Convert.ToInt32(dr2[0].ToString());
                }
                bgl.baglanti().Close();
            }
            else
            {
                SqlCommand komut2 = new SqlCommand("select ID from yetkili where Yetkili = N'" + combo_denetci.Text + "' and Firma_ID in (select ID from Firma where Firma_Adi like '%Ticaret Bakanlığı İzmir%')", bgl.baglanti());
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    denetciID = Convert.ToInt32(dr2[0].ToString());
                }
                bgl.baglanti().Close();
            }

        }

        private void combo_bakanlik_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_denetci.Properties.Items.Clear();
            combo_denetci.Text = "";
            denetcibul();
        }

        private void analizler()
        {
            //DataTable dt2 = new DataTable();
            //SqlDataAdapter da2 = new SqlDataAdapter(@"select l.Kod, l.Ad, l.Method, l.ID as 'aID' from NumuneX4 x
            //left join StokAnalizDetay d on x.AltAnalizID = d.ID
            //left join StokAnalizListesi l on d.AnalizID = l.ID
            //where d.Tur = 'Toplam' and x.X3ID = '" + gridLookUpEdit1.EditValue + "' except Select l.Kod, l.Ad, l.Method, l.ID as 'aID' from NumuneX4 x left join StokAnalizDetay d on x.AltAnalizID = d.ID left join StokAnalizListesi l on d.AnalizID = l.ID where l.ID in (select AnalizID from NumuneX1 where RaporID = '"+ykrID+"') order by l.Kod ", bgl.baglanti());

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(@"select l.Kod, l.Ad, l.Method, l.ID as 'aID' from NumuneX4 x
            left join StokAnalizDetay d on x.AltAnalizID = d.ID
            left join StokAnalizListesi l on d.AnalizID = l.ID
            where d.Tur = 'Toplam' and x.X3ID = '" + gridLookUpEdit1.EditValue + "' except Select l.Kod, l.Ad, l.Method, l.ID as 'aID' from NumuneX4 x left join StokAnalizDetay d on x.AltAnalizID = d.ID left join StokAnalizListesi l on d.AnalizID = l.ID where l.ID in (select AnalizID from NumuneX1 where RaporID = '" + Donen + "') order by l.Kod ", bgl.baglanti());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
            gridView1.Columns["aID"].Visible = false;
            if (dt2 != null)
            {
                this.gridView1.Columns[0].Width = 35;
                this.gridView1.Columns[1].Width = 80;
                this.gridView1.Columns[2].Width = 45;
            }
        }

        private void analizler2()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(@"select l.Kod, l.Ad, l.Method, l.ID as 'aID' from NumuneX1 x
            left join StokAnalizListesi l on x.AnalizID = l.ID
            where x.RaporID = '" + Donen + "' order by l.Kod", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;
            gridView3.Columns["aID"].Visible = false;

            this.gridView3.Columns[0].Width = 35;
            this.gridView3.Columns[1].Width = 80;
            this.gridView3.Columns[2].Width = 45;
        }

        private void gridView2_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }
        }

        private void gridView3_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu2.ShowPopup(p2);
            }
        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //açıklama değişince listeleme

            analizler();

        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //seçili analizleri ekle

            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                id = gridView1.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                o2 = gridView1.GetRowCellValue(y, "aID").ToString();
                SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                    "insert into NumuneX1 (RaporID, AnalizID, x3ID) " +
                    "values (@o1,@o2, @o3);" +
                    "COMMIT TRANSACTION", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", Donen);
                add2.Parameters.AddWithValue("@o2", o2);
                add2.Parameters.AddWithValue("@o3", gridLookUpEdit1.EditValue);
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }

            analizler();
            analizler2();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //seçili analizleri kaldır
            for (int i = 0; i < gridView3.SelectedRowsCount; i++)
            {
                id = gridView3.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                o2 = gridView3.GetRowCellValue(y, "aID").ToString();
                SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                    "delete from NumuneX1 where AnalizID = @o2 and RaporID = @o1;" +
                    "COMMIT TRANSACTION", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", Donen);
                add2.Parameters.AddWithValue("@o2", o2);
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }

            analizler();
            analizler2();
        }

        private void NumuneKabul_Load(object sender, EventArgs e)
        {
            name = "";

            Firma();
            listele();

            if (nID == 0)
            {
                Evrakmax();
                RaporNoMax();
                txtEvrak.Text = (maxevrak + 1).ToString();
                txtRapor.Text = (maxrapor + 1).ToString();
                dateTermin.EditValue = DateTime.Now.AddDays(7);
                dateTime.EditValue = DateTime.Now;
            }
            else
            {
                //NKR
                Donen = nID;
                nKRVMYeni = nKRService.Get("ID = @param1", nID);
                nKRVMEski = nKRService.Get("ID = @param1", nID);
                txtEvrak.Text = nKRVMEski.Evrak_No.ToString();
                txtNumune.Text = nKRVMEski.Numune_Adi.ToString();
                dateTime.EditValue = nKRVMEski.Tarih;
                combo_grup.SelectedItem = nKRVMEski.Grup;
                combo_tur.SelectedItem = nKRVMEski.Tur;
                memoEdit2.Text = nKRVMEski.Aciklama;
                txtRapor.Text = nKRVMEski.RaporNo.ToString();
                txtRev.Text = nKRVMEski.Revno.ToString();
                if (nKRVMEski.Akreditasyon == "Var")
                {
                    checkEdit1.Checked = true;
                    akredite = "Var";
                }
                else
                {
                    checkEdit1.Checked = false;
                    akredite = "Yok";
                }
                comboservis.SelectedItem = nKRVMEski.Servis;
                gridLookUpEdit3.EditValue = nKRVMEski.Firma_ID;


                //NKR2
                nKR2VMYeni = nKR2Service.Get("NKRID = @param1", nID);
                nKR2VMEski = nKR2Service.Get("NKRID = @param1", nID);
                gridLookUpEdit6.EditValue = nKR2VMEski.FaturaFirmaID;
                comboBoxEdit4.SelectedItem = nKR2VMEski.Talep;
                txt_talepno.Text = nKR2VMEski.TalepNo;
                gridLookUpEdit2.EditValue = nKR2VMEski.TeklifNo;
                comboBoxEdit5.SelectedItem = nKR2VMEski.RaporDili;
                comboBoxEdit6.SelectedItem = nKR2VMEski.Gonderim;
                textEdit4.Text = nKR2VMEski.GAdresi;
                comboBoxEdit7.SelectedItem = nKR2VMEski.Iade;
                comboBoxEdit8.SelectedItem = nKR2VMEski.KararKurali;
                memoEdit1.Text = nKR2VMEski.RaporAciklama;
                textEdit5.Text = nKR2VMEski.SartliKabul;
                textEdit1.Text = nKR2VMEski.Elyaf;
                memoEdit4.Text = nKR2VMEski.Yikama;
                taleppath = nKR2VMEski.TalepDosya;
                if (!string.IsNullOrEmpty(taleppath))
                {
                    simpleButton5.Visible = true;
                }      


                //NumunetDetay2
                numuneDetay2VMYeni = numuneDetay2Service.Get("RaporID = @param1", nID);
                numuneDetay2VMEski = numuneDetay2Service.Get("RaporID = @param1", nID);
                yetkiliID = numuneDetay2VMEski.YetkiliID;
                denetciID = numuneDetay2VMEski.DenetciID;
                gridLookUpEdit4.EditValue = yetkiliID;


                //NumuneDetay
                numuneDetayVMYeni = numuneDetayService.Get("RaporID = @param1" , nID);
                numuneDetayVMEski = numuneDetayService.Get("RaporID = @param1", nID);
                txtAdet.Text = numuneDetayVMEski.Miktar.ToString();
                txt_lot.Text = numuneDetayVMEski.SeriNo;
                txt_uretim.Text = numuneDetayVMEski.UretimTarihi;
                txt_basvuru.Text = numuneDetayVMEski.BasvuruNo;
                txt_marka.Text = numuneDetayVMEski.Marka;
                memoEdit3.Text = numuneDetayVMEski.Model;
                combo_birim.SelectedItem = numuneDetayVMEski.Birim;
                gridLookUpEdit5.EditValue = numuneDetayVMEski.ProjeID;
                if (combo_grup.Text == "Bakanlık")
                {
                    combo_bakanlik.SelectedItem = numuneDetayVMEski.AliciFirma;
                    alicifirma = combo_bakanlik.Text;
                    combo_denetci.SelectedItem = numuneDetay2Service.SelectText("select Yetkili from yetkili where ID = @param1", denetciID).Rows[0][0].ToString();
                }
                else
                {
                    txt_alicifirma.Text = numuneDetayVMEski.AliciFirma;
                    alicifirma = txt_alicifirma.Text;
                }


                //Termin
                terminVMYeni = terminService.Get("RaporID = @param1", nID);
                terminVMEski = terminService.Get("RaporID = @param1", nID);
                dateTermin.DateTime = terminVMEski.Termin;


                //RaporDurumu
                rapor_DurumuVMYeni = rapor_DurumService.Get("RaporID = @param1", nID);
                rapor_DurumuVMEski = rapor_DurumService.Get("RaporID = @param1", nID);

                //Odeme
                odemeVMEski = odemeService.Get("Evrak_No = @param1", Convert.ToInt32(txtEvrak.Text));
                odemeVMYeni = odemeService.Get("Evrak_No = @param1", Convert.ToInt32(txtEvrak.Text));

                //Fotofraf
                fotografVMEski = fotografService.Get("RaporID = @param1", nID);
                fotografVMYeni = fotografService.Get("RaporID = @param1", nID);
                if (!string.IsNullOrEmpty(fotografVMEski.Path))
                {
                    string uriPath = "http://www.massgrup.com/mask/Numune/Foto_2021/" + fotografVMEski.Path;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriPath);
                    try
                    {
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        Stream receiveStream = response.GetResponseStream();
                        if (receiveStream.CanRead)
                        {
                            pictureEdit1.Image = new Bitmap(receiveStream);
                        }
                    }
                    catch { }
                }


                DataTable dt2 = new DataTable();
                SqlDataAdapter da2 = new SqlDataAdapter(@"select l.Kod, l.Ad, l.Method, l.ID as 'aID' from NumuneX1 x
                        left join StokAnalizListesi l on x.AnalizID = l.ID
                        where x.RaporID = '" + nID + "' order by l.Kod", bgl.baglanti());
                da2.Fill(dt2);
                gridControl1.DataSource = dt2;
                gridView3.Columns["aID"].Visible = false;

                this.gridView3.Columns[0].Width = 35;
                this.gridView3.Columns[1].Width = 80;
                this.gridView3.Columns[2].Width = 45;

                simpleButton4.Text = "Güncelle";
                btn_kaydet.Text = "Güncelle";
            }
        }

        private void NumKabv2_FormClosed(object sender, FormClosedEventArgs e)
        {
            nID = 0;
        }

        private void btn_analizekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (isUpdated)
                {
                    lbl_rapno.Text = txtRapor.Text;

                    guncelle();

                    talepad = null;
                    taleppath = null;
                    simpleButton1.Text = "Seç";
                    
                    tabPane1.SelectedPage = tabNavigationPage2;
                }
                else
                {
                    EvrakNoo();

                    if (checkEdit1.Checked == true)
                        akredite = "Var";
                    else
                        akredite = "Yok";

                    if (txtRapor.Text == "") //comboFirma.Text == "" ||
                    {
                        MessageBox.Show("Bir şeyleri atlamış olabilir misin? Rapor no veya firma adı gibi..");
                    }
                    else
                    {
                        //  analiztalep();

                        if (EvrakNo == 0)
                        {
                            yenievrak();
                        }
                        else
                        {
                            tekrarevrak();
                        }

                        talepad = null;
                        taleppath = null;
                        simpleButton1.Text = "Seç";
                        lbl_rapno.Text = txtRapor.Text;
                        Evrakmax();
                        txtRapor.Text = "";
                        RaporNoMax();
                        int yenirap = maxrapor + 1;
                        txtRapor.Text = yenirap.ToString();

                        durumekle();

                        fotokaydet();

                        tabPane1.SelectedPage = tabNavigationPage2;
                    }

                    if (n != null)
                    {
                        n.listele();
                    }
                }       
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tüh ya! Bak ne oldu: " + ex.Message);
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(taleppath))
            {
                string ext = Path.GetExtension(taleppath);
                if (ext == ".png" || ext == ".jpg" || ext == ".jpeg")
                {
                    NumKabResimGoruntule numKabResimGoruntule = new NumKabResimGoruntule();
                    numKabResimGoruntule.yol = taleppath;
                    numKabResimGoruntule.Show();
                }
                else
                {
                    NumKabDokumanGoruntule numKabDokumanGoruntule = new NumKabDokumanGoruntule();
                    numKabDokumanGoruntule.yol = taleppath;
                    numKabDokumanGoruntule.Show();
                }
            }
            else
            {
                MessageBox.Show("Gösterilecek Dosya Bulunmamaktadır!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // incele

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            //To where your opendialog box get starting location. My initial directory location is desktop.
            open.InitialDirectory = path;
            //Your opendialog box title name.
            open.Title = "Yüklemek istediğiniz dosyayı seçiniz.";
            //which type file format you want to upload in database. just add them.
            open.Filter = "Select Valid Document(*.pdf; *.doc; *.xlsx; *.html; *.jpg; *.jpeg; *.png)|*.pdf; *.docx; *.xlsx; *.html; *.jpg; *.jpeg; *.png";
            //FilterIndex property represents the index of the filter currently selected in the file dialog box.
            open.FilterIndex = 1;
            try
            {
                if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (open.CheckFileExists)
                    {
                        name2 = open.FileName;
                        talepad = System.IO.Path.GetFullPath(open.FileName);
                        talepext = System.IO.Path.GetExtension(open.FileName);
                        simpleButton1.Text = "Seçildi";
                        //btnsertifika.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen dosya seçiniz.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void analiztalep()
        {
            if (talepad == "" || talepad == null)
            {
                taleppath = null;
            }
            else
            {
                if (talepext == ".png" || talepext == ".jpeg" || talepext == ".jpg")
                {
                    talepad = System.IO.Path.GetFileName(talepad);
                    taleppath = DateTime.Now.ToString("dd.MM.yyyy") + "_" + DateTime.Now.ToString("HH.mm.ss") + lbl_rapno.Text + " - " + talepad;

                    fotokaydetTalep(taleppath);
                }
                else
                {
                    taleppath = txtRapor.Text + ' ' + talepad;
                    //taleppath = txtRapor.Text + ' ' + talepad + ".pdf";
                    File.Copy(talepad, Path.Combine(@Anasayfa.path, taleppath), true);
                }
            }
        }

        int Donen = 0;


        string grid4ID;
        private void yenievrak()
        {
            SqlCommand komut2 = new SqlCommand("Select ID from Numune_Grup where Tur = '" + combo_tur.Text + "' and Grup = '" + combo_grup.Text + "'", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                TurID = Convert.ToInt32(dr2["ID"]);
            }
            bgl.baglanti().Close();

            if (combo_grup.Text == "Bakanlık")
            {
                alicifirma = combo_bakanlik.Text;
            }
            else
            {
                alicifirma = txt_alicifirma.Text;
            }

            analiztalep();            

            SqlCommand komut = new SqlCommand("BEGIN TRANSACTION " +
                         "insert into NKR (Evrak_No,Numune_Adi,Tarih,Tur,Grup,Firma_ID,Rapor_Durumu,Aciklama,RaporNo,Revno,Akreditasyon,Durum,Servis,Adet,Analiz) values (@n1,@n2,@n4,@n5,@n6,@n7,@n8,@n9,@n11,@n12,@n13,@n14,@n15,0,'') SET @ID = SCOPE_IDENTITY() ; " +
                         "insert into Odeme(Odeme_Durumu, Fatura_ID, Evrak_No) values(@o1,0,@o2); " +
                         "insert into NumuneDetay(AliciFirma,Miktar,SeriNo,UretimTarihi,SKT,BasvuruNo,Marka,RaporID,Model,ProjeID,Birim,MiktarEx) values(@a1,@a2,@a3,@a4,@a5,@a6,@a7,IDENT_CURRENT('NKR'),@a8,@a9,@a10,'')" +
                         "insert into NumuneDetay2(RaporID,YetkiliID, DenetciID) values(IDENT_CURRENT('NKR'),@x1,@x2);" +
                         "insert into Termin(RaporID,Termin) values(IDENT_CURRENT('NKR'),@b1); " +
                         "insert into Rapor_Durum(RaporNo, Durum, Tarih,TanimlayanID, RaporID) values (@c1,@c2, @c3,@c4,IDENT_CURRENT('NKR')); " +
                         "insert into NKR2 (NKRID, FaturaFirmaID,Talep,TalepNo,TalepDosya,TeklifNo,RaporDili,Gonderim,Gadresi,Iade,KararKurali,RaporAciklama,SartliKabul,Elyaf,Yikama) values (IDENT_CURRENT('NKR'),@e1,@e2,@e3,@e4,@e5,@e6,@e7,@e8,@e9,@e10,@e11,@e12,@e13,@e14); " +
                         "COMMIT TRANSACTION", bgl.baglanti());
            //  "insert into NumuneModel(RaporID,Urun_Kodu,Model) values(IDENT_CURRENT('NKR'),@c2,@c3)" 
            komut.Parameters.AddWithValue("@n1", txtEvrak.Text);
            komut.Parameters.AddWithValue("@n2", txtNumune.Text);
            komut.Parameters.AddWithValue("@n4", dateTime.EditValue);
            komut.Parameters.AddWithValue("@n5", combo_tur.Text);
            komut.Parameters.AddWithValue("@n6", combo_grup.Text);
            komut.Parameters.AddWithValue("@n7", gridLookUpEdit3.EditValue ?? (object)DBNull.Value);
            komut.Parameters.AddWithValue("@n8", "Yeni Numune");
            komut.Parameters.AddWithValue("@n9", memoEdit2.Text);
            komut.Parameters.AddWithValue("@n11", txtRapor.Text);
            komut.Parameters.AddWithValue("@n12", txtRev.Text);
            komut.Parameters.AddWithValue("@n13", akredite);
            komut.Parameters.AddWithValue("@n14", "Aktif");
            komut.Parameters.AddWithValue("@n15", comboservis.Text);
            komut.Parameters.AddWithValue("@o1", fDurumu);
            komut.Parameters.AddWithValue("@o2", txtEvrak.Text);
            komut.Parameters.AddWithValue("@a1", alicifirma);
            komut.Parameters.AddWithValue("@a2", txtAdet.Text);
            komut.Parameters.AddWithValue("@a3", txt_lot.Text);
            komut.Parameters.AddWithValue("@a4", txt_uretim.Text);
            komut.Parameters.AddWithValue("@a5", txt_skt.Text);
            komut.Parameters.AddWithValue("@a6", txt_basvuru.Text);
            komut.Parameters.AddWithValue("@a7", txt_marka.Text);
            komut.Parameters.AddWithValue("@a8", memoEdit3.Text);
            komut.Parameters.AddWithValue("@a9", gridLookUpEdit5.EditValue ?? (object)DBNull.Value);
            komut.Parameters.AddWithValue("@a10", combo_birim.Text);
            komut.Parameters.AddWithValue("@b1", dateTermin.EditValue);
            //komut.Parameters.AddWithValue("@x1", yetkiliID);
            komut.Parameters.AddWithValue("@x1", gridLookUpEdit4.EditValue ?? (object)DBNull.Value);
            komut.Parameters.AddWithValue("@x2", denetciID);
            komut.Parameters.AddWithValue("@c1", txtRapor.Text);
            komut.Parameters.AddWithValue("@c2", "Yeni Numune");
            komut.Parameters.AddWithValue("@c3", dateTime.EditValue);
            komut.Parameters.AddWithValue("@c4", Giris.kullaniciID);
            komut.Parameters.AddWithValue("@e1", gridLookUpEdit6.EditValue ?? (object)DBNull.Value);
            komut.Parameters.AddWithValue("@e2", comboBoxEdit4.Text);
            komut.Parameters.AddWithValue("@e3", txt_talepno.Text);
            if (string.IsNullOrEmpty(taleppath))
            {
                taleppath = "";
            }
            komut.Parameters.AddWithValue("@e4", taleppath);
            komut.Parameters.AddWithValue("@e5", gridLookUpEdit2.EditValue ?? (object)DBNull.Value);
            komut.Parameters.AddWithValue("@e6", comboBoxEdit5.Text);
            komut.Parameters.AddWithValue("@e7", comboBoxEdit6.Text);
            komut.Parameters.AddWithValue("@e8", textEdit4.Text);
            komut.Parameters.AddWithValue("@e9", comboBoxEdit7.Text);
            komut.Parameters.AddWithValue("@e10", comboBoxEdit8.Text);
            komut.Parameters.AddWithValue("@e11", memoEdit1.Text);
            komut.Parameters.AddWithValue("@e12", textEdit5.Text);
            komut.Parameters.AddWithValue("@e13", textEdit1.Text);
            komut.Parameters.AddWithValue("@e14", memoEdit4.Text);
            komut.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            komut.ExecuteNonQuery();
            Donen = Convert.ToInt32(komut.Parameters["@ID"].Value);
            bgl.baglanti().Close();
            ykrID = Donen;

            analizler();
            analizler2();
        }

        private void tekrarevrak()
        {
            SqlCommand komut2 = new SqlCommand("Select ID from Numune_Grup where Tur = '" + combo_tur.Text + "' and Grup = '" + combo_grup.Text + "'", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                TurID = Convert.ToInt32(dr2["ID"]);
            }
            bgl.baglanti().Close();

            if (combo_grup.Text == "Bakanlık")
            {
                alicifirma = combo_bakanlik.Text;
            }
            else
            {
                alicifirma = txt_alicifirma.Text;
            }

            analiztalep();

            SqlCommand komut = new SqlCommand("BEGIN TRANSACTION " +
                          "insert into NKR (Evrak_No,Numune_Adi,Tarih,Tur,Grup,Firma_ID,Rapor_Durumu,Aciklama,RaporNo,Revno,Akreditasyon,Durum,Servis) values (@n1,@n2,@n4,@n5,@n6,@n7,@n8,@n9,@n11,@n12,@n13,@n14,@n15)  SET @ID = SCOPE_IDENTITY()  ; " +
                          "insert into NumuneDetay(AliciFirma,Miktar,SeriNo,UretimTarihi,SKT,BasvuruNo,Marka,RaporID,Model,ProjeID,Birim) values(@a1,@a2,@a3,@a4,@a5,@a6,@a7,IDENT_CURRENT('NKR'),@a8,@a9,@a10)" +
                          "insert into NumuneDetay2(RaporID,YetkiliID, DenetciID) values(IDENT_CURRENT('NKR'),@x1,@x2);" +
                          "insert into Termin(RaporID,Termin) values(IDENT_CURRENT('NKR'),@b1); " +
                          "insert into Rapor_Durum(RaporNo, Durum, Tarih,TanimlayanID, RaporID) values (@c1,@c2, @c3,@c4,IDENT_CURRENT('NKR')); " +
                          "insert into NKR2 (NKRID, FaturaFirmaID,Talep,TalepNo,TalepDosya,TeklifNo,RaporDili,Gonderim,Gadresi,Iade,KararKurali,RaporAciklama,SartliKabul,Elyaf,Yikama) values (IDENT_CURRENT('NKR'),@e1,@e2,@e3,@e4,@e5,@e6,@e7,@e8,@e9,@e10,@e11,@e12,@e13,@e14); " +
                           "COMMIT TRANSACTION", bgl.baglanti());
            komut.Parameters.AddWithValue("@n1", txtEvrak.Text);
            komut.Parameters.AddWithValue("@n2", txtNumune.Text);
            komut.Parameters.AddWithValue("@n4", dateTime.EditValue);
            komut.Parameters.AddWithValue("@n5", combo_tur.Text);
            komut.Parameters.AddWithValue("@n6", combo_grup.Text);
            komut.Parameters.AddWithValue("@n7", gridLookUpEdit3.EditValue ?? (object)DBNull.Value);
            komut.Parameters.AddWithValue("@n8", "Yeni Numune");
            komut.Parameters.AddWithValue("@n9", memoEdit2.Text);
            komut.Parameters.AddWithValue("@n11", txtRapor.Text);
            komut.Parameters.AddWithValue("@n12", txtRev.Text);
            komut.Parameters.AddWithValue("@n13", akredite);
            komut.Parameters.AddWithValue("@n14", "Aktif");
            komut.Parameters.AddWithValue("@n15", comboservis.Text);
            komut.Parameters.AddWithValue("@a1", alicifirma);
            komut.Parameters.AddWithValue("@a2", txtAdet.Text);
            komut.Parameters.AddWithValue("@a3", txt_lot.Text);
            komut.Parameters.AddWithValue("@a4", txt_uretim.Text);
            komut.Parameters.AddWithValue("@a5", txt_skt.Text);
            komut.Parameters.AddWithValue("@a6", txt_basvuru.Text);
            komut.Parameters.AddWithValue("@a7", txt_marka.Text);
            komut.Parameters.AddWithValue("@a8", memoEdit3.Text);
            komut.Parameters.AddWithValue("@a9", gridLookUpEdit5.EditValue ?? (object)DBNull.Value);
            komut.Parameters.AddWithValue("@a10", combo_birim.Text);
            komut.Parameters.AddWithValue("@b1", dateTermin.EditValue);
            komut.Parameters.AddWithValue("@x1", yetkiliID);
            komut.Parameters.AddWithValue("@x2", denetciID);
            komut.Parameters.AddWithValue("@c1", txtRapor.Text);
            komut.Parameters.AddWithValue("@c2", "Yeni Numune");
            komut.Parameters.AddWithValue("@c3", dateTime.EditValue);
            komut.Parameters.AddWithValue("@c4", Giris.kullaniciID);
            komut.Parameters.AddWithValue("@e1", gridLookUpEdit6.EditValue ?? (object)DBNull.Value);
            komut.Parameters.AddWithValue("@e2", comboBoxEdit4.Text);
            komut.Parameters.AddWithValue("@e3", txt_talepno.Text);
            komut.Parameters.AddWithValue("@e4", taleppath ?? (object)DBNull.Value);
            komut.Parameters.AddWithValue("@e5", gridLookUpEdit2.EditValue ?? (object)DBNull.Value);
            komut.Parameters.AddWithValue("@e6", comboBoxEdit5.Text);
            komut.Parameters.AddWithValue("@e7", comboBoxEdit6.Text);
            komut.Parameters.AddWithValue("@e8", textEdit4.Text);
            komut.Parameters.AddWithValue("@e9", comboBoxEdit7.Text);
            komut.Parameters.AddWithValue("@e10", comboBoxEdit8.Text);
            komut.Parameters.AddWithValue("@e11", memoEdit1.Text);
            komut.Parameters.AddWithValue("@e12", textEdit5.Text);
            komut.Parameters.AddWithValue("@e13", textEdit1.Text);
            komut.Parameters.AddWithValue("@e14", memoEdit4.Text);
            komut.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            komut.ExecuteNonQuery();
            Donen = Convert.ToInt32(komut.Parameters["@ID"].Value);
            bgl.baglanti().Close();

            gridControl1.DataSource = null;
            gridView1.Columns.Clear();
            gridControl2.DataSource = null;
            gridView3.Columns.Clear();
            analizler();
            analizler2();
        }

        private void guncelle()
        {
            nKRVMYeni.Evrak_No = Convert.ToInt32(txtEvrak.Text);
            nKRVMYeni.Numune_Adi = txtNumune.Text;
            nKRVMYeni.Tarih = Convert.ToDateTime(dateTime.EditValue);
            nKRVMYeni.Tur = combo_tur.Text;
            nKRVMYeni.Grup = combo_grup.Text;
            nKRVMYeni.Firma_ID = Convert.ToInt32(gridLookUpEdit3.EditValue);
            nKRVMYeni.Aciklama = memoEdit2.Text;
            nKRVMYeni.RaporNo = Convert.ToInt32(txtRapor.Text);
            nKRVMYeni.Revno = Convert.ToInt32(txtRev.Text);
            nKRVMYeni.Akreditasyon = akredite;
            nKRVMYeni.Servis = comboservis.Text;

            if (nKRService.Update(nKRVMYeni))
            {
                numuneDetayVMYeni.AliciFirma = alicifirma;
                numuneDetayVMYeni.Miktar = Convert.ToInt32(txtAdet.Text);
                numuneDetayVMYeni.SeriNo = txt_lot.Text;
                numuneDetayVMYeni.UretimTarihi = txt_uretim.Text;
                numuneDetayVMYeni.SKT = txt_skt.Text;
                numuneDetayVMYeni.BasvuruNo = txt_basvuru.Text;
                numuneDetayVMYeni.Marka = txt_marka.Text;
                numuneDetayVMYeni.Model = memoEdit3.Text;
                numuneDetayVMYeni.ProjeID = Convert.ToInt32(gridLookUpEdit5.EditValue);
                numuneDetayVMYeni.Birim = combo_birim.Text;

                if (numuneDetayService.Update(numuneDetayVMYeni))
                {
                    numuneDetay2VMYeni.YetkiliID = yetkiliID;
                    numuneDetay2VMYeni.DenetciID = denetciID;

                    if (numuneDetay2Service.Update(numuneDetay2VMYeni))
                    {
                        terminVMYeni.Termin = Convert.ToDateTime(dateTermin.EditValue);

                        if (terminService.Update(terminVMYeni))
                        {
                            rapor_DurumuVMYeni.RaporNo = Convert.ToInt32(txtRapor.Text);
                            rapor_DurumuVMYeni.Tarih = Convert.ToDateTime(dateTime.EditValue);
                            rapor_DurumuVMYeni.TanimlayanID = Giris.kullaniciID;

                            if (rapor_DurumService.Update(rapor_DurumuVMYeni))
                            {
                                if (!string.IsNullOrEmpty(name2))
                                {
                                    analiztalep();
                                }

                                nKR2VMYeni.FaturaFirmaID = Convert.ToInt32(gridLookUpEdit6.EditValue);
                                nKR2VMYeni.Talep = comboBoxEdit4.Text;
                                nKR2VMYeni.TalepNo = txt_talepno.Text;
                                if (!string.IsNullOrEmpty(taleppath))
                                {
                                    nKR2VMYeni.TalepDosya = taleppath;
                                }
                                nKR2VMYeni.TeklifNo = Convert.ToInt32(gridLookUpEdit2.EditValue);
                                nKR2VMYeni.RaporDili = comboBoxEdit5.Text;
                                nKR2VMYeni.Gonderim = comboBoxEdit6.Text;
                                nKR2VMYeni.GAdresi = textEdit4.Text;
                                nKR2VMYeni.Iade = comboBoxEdit7.Text;
                                nKR2VMYeni.KararKurali = comboBoxEdit8.Text;
                                nKR2VMYeni.RaporAciklama = memoEdit1.Text;
                                nKR2VMYeni.SartliKabul = textEdit5.Text;
                                nKR2VMYeni.Elyaf = textEdit1.Text;
                                nKR2VMYeni.Yikama = memoEdit4.Text;

                                bool kayitkontrol = false;
                                if(nKR2VMYeni.ID == 0)
                                {
                                    nKR2VMYeni.NKRID = nID;
                                    kayitkontrol = nKR2Service.Insert(nKR2VMYeni) > 0 ? true : false;
                                }
                                else
                                {
                                    kayitkontrol = nKR2Service.Update(nKR2VMYeni);
                                }

                                if (kayitkontrol)
                                {
                                    if (!string.IsNullOrEmpty(name))
                                    {
                                        fotografVMYeni.Path = yenisim;
                                        fotografVMYeni.RaporID = nID;

                                        if(fotografVMEski.ID == 0)
                                        {
                                            fotokaydet();
                                        }
                                        else
                                        {
                                            string isim = Path.GetFileName(name);
                                            yenisim = DateTime.Now.ToString("dd.MM.yyyy") + "_" + DateTime.Now.ToString("HH.mm.ss") + lbl_rapno.Text + " - " + isim;

                                            using (var client = new WebClient())
                                            {
                                                string ftpUsername = "massgrup";
                                                string ftpPassword = "!88n2ee5Q";
                                                ftpfullpath = "ftp://" + "www.massgrup.com/httpdocs/mask/Numune/Foto_2021" + "/" + yenisim;
                                                yeniyol = "http://" + "www.massgrup.com/mask/Numune/Foto_2021" + "/" + yenisim;
                                                client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                                                client.UploadFile(ftpfullpath, name);
                                            }

                                            fotografService.Update(fotografVMYeni);
                                        }

                                        gridControl1.DataSource = null;
                                        gridView1.Columns.Clear();
                                        gridControl2.DataSource = null;
                                        gridView3.Columns.Clear();
                                        analizler();
                                        analizler2();
                                    }
                                    else
                                    {
                                        gridControl1.DataSource = null;
                                        gridView1.Columns.Clear();
                                        gridControl2.DataSource = null;
                                        gridView3.Columns.Clear();
                                        analizler();
                                        analizler2();
                                    }
                                }
                                else
                                {
                                    EskiKayitlariGeriKaydet();
                                }
                            }
                            else
                            {
                                EskiKayitlariGeriKaydet();
                            }
                        }
                        else
                        {
                            EskiKayitlariGeriKaydet();
                        }
                    }
                    else
                    {
                        EskiKayitlariGeriKaydet();
                    }
                }
                else
                {
                    EskiKayitlariGeriKaydet();
                }
            }
        }
        
        private void EskiKayitlariGeriKaydet()
        {
            nKRService.Update(nKRVMEski);
            numuneDetayService.Update(numuneDetayVMEski);
            numuneDetay2Service.Update(numuneDetay2VMEski);
            terminService.Update(terminVMEski);
            nKR2Service.Update(nKR2VMEski);
            rapor_DurumService.Update(rapor_DurumuVMEski);
            fotografService.Update(fotografVMEski);

            MessageBox.Show("Güncelleme Başarısız. Tekrar Deneyiniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (nID == 0)
                {
                    DialogResult cikis = new DialogResult();
                    cikis = MessageBox.Show("Analizler de tamam. Yeni Numune?", "Uyarı", MessageBoxButtons.YesNo);
                    if (cikis == DialogResult.Yes)
                    {
                        tabPane1.SelectedPage = tabNavigationPage1;
                        pictureEdit1.Image = null;
                    }

                    if (cikis == DialogResult.No)
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Analizler güncellendi!", "Uyarı", MessageBoxButtons.OK);
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tüh ya! Bak ne oldu 77: " + ex.Message);
            }
            //kaydettikten sonra nID sıfırlayıp ona göre ilerlese ? 
        }

        // güncellenecek

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            PrinterSettings ps = new PrinterSettings();
            PrintDocument Kagit = new PrintDocument();
            Kagit.PrinterSettings = ps;
            Kagit.DefaultPageSettings.PaperSize = new PaperSize("80x100 mm", 380, 315);
            DialogResult yazdirmaislemi;
            yazdirmaislemi = prd.ShowDialog();
            Kagit.PrintPage += Kagit_PrintPage;
            if (yazdirmaislemi == DialogResult.OK)
            {
                Kagit.Print();
            }
        }

        PrintDialog prd = new PrintDialog();
        string analiz, metod, kod;
        private void Kagit_PrintPage(object sender, PrintPageEventArgs e)
        {
            //throw new NotImplementedException();

            string yazi = "Evrak / Rapor No: " + txtEvrak.Text + " / " + (Convert.ToInt32(txtRapor.Text) - 1);
            string yazi2 = "Talep Edilen Testler:";
            string yazi3 = txtEvrak.Text;
            Font YaziAilesi = new Font("Tahoma", 11, FontStyle.Bold);
            Font Yazi2 = new Font("Tahoma", 8);
            Font analizler = new Font("Tahoma", 7);
            SolidBrush kalem = new SolidBrush(Color.Black);
            e.Graphics.DrawString(yazi, YaziAilesi, kalem, 30, 40);
            e.Graphics.DrawString(yazi2, Yazi2, kalem, 20, 75);

            int a = 90;
            int b = 1;
            for (int j = 0; j < gridView1.SelectedRowsCount; j++)
            {
                id = gridView1.GetSelectedRows()[j].ToString();
                int y = Convert.ToInt32(id);
                kod = gridView3.GetRowCellValue(y, "Kod").ToString();
                analiz = gridView3.GetRowCellValue(y, "Analiz Adı").ToString();
                metod = gridView3.GetRowCellValue(y, "Metot").ToString();

                e.Graphics.DrawString(b + ". " + kod + " " + analiz + " / " + metod, analizler, kalem, 20, a);
                a += 15;
                b++;

            }
        }

    }
}
