using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mKYS
{
    public partial class NumuneKabul : Form
    {
        NKR2 n = (NKR2)System.Windows.Forms.Application.OpenForms["NKR2"];

        public NumuneKabul()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();

        public void Firma()
        {
            SqlCommand komut = new SqlCommand("Select Firma_Adi from Firma where Durum = 'Aktif'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboFirma.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
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

        public static int EvrakNo, maxevrak;
        void Evrakmax()
        {
            SqlCommand komutm = new SqlCommand("select max(evrak_no) from NKR", bgl.baglanti());
            SqlDataReader drm = komutm.ExecuteReader();
            while (drm.Read())
            {
                maxevrak = Convert.ToInt32(drm[0].ToString());
            }
            bgl.baglanti().Close();
        }

        public static int maxrapor;
        void RaporNoMax()
        {
            if (combo_grup.Text == "Özel2")
            {
                SqlCommand komutm = new SqlCommand("select MAX(RaporNo) from NKR where Grup = 'Özel2' ", bgl.baglanti());
                SqlDataReader drm = komutm.ExecuteReader();
                while (drm.Read())
                {
                    maxrapor = Convert.ToInt32(drm[0].ToString());
                }
                bgl.baglanti().Close();
            }
            else
            {
                SqlCommand komutm = new SqlCommand("select MAX(RaporNo) from NKR where Grup = 'Özel' ", bgl.baglanti());
                SqlDataReader drm = komutm.ExecuteReader();
                while (drm.Read())
                {
                    string rno = drm[0].ToString();

                    if (rno == "" || rno == null)
                    {
                        maxrapor = 240001;
                    }
                    else
                    {
                        maxrapor = Convert.ToInt32(rno);
                    }
                }
                bgl.baglanti().Close();
            }

        }

        void EvrakNoo()
        {
            SqlCommand komut2 = new SqlCommand("select count(Evrak_No) from NKR where Evrak_No = N'" + txtEvrak.Text + "'", bgl.baglanti());
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                EvrakNo = Convert.ToInt32(dr[0].ToString());
            }
            bgl.baglanti().Close();

        }

        int firmaId;


        private void NumuneKabul_Load(object sender, EventArgs e)
        {

            Firma();
            Evrakmax();
            RaporNoMax();
            proje();
            listele();
            txtEvrak.Text = (maxevrak + 1).ToString();
            txtRapor.Text = (maxrapor+ 1).ToString();
            comboBoxEdit1.Text = "DİĞER";
            dateTermin.EditValue = DateTime.Now.AddDays(7);
            dateTime.EditValue = DateTime.Now;


        }

        private void txtAdet_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtEvrak_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btn_firmaekle_Click(object sender, EventArgs e)
        {
            //Firmalar f1 = new Firmalar();
            //f1.ShowDialog();
        }

        private void durumekle()
        {
            DateTime tarih = DateTime.Now;
            SqlCommand add = new SqlCommand("insert into NumuneDurum (RaporNo, Durum, Kim) values (@o1, @o3,@o4) ; " +
                " insert into NumuneTeslim (RaporNo,Tarih, Durum, Kim) values (@o1, @o2, @o3,@o4)", bgl.baglanti());
            add.Parameters.AddWithValue("@o1", txtRapor.Text);
            add.Parameters.AddWithValue("@o2", tarih);
            add.Parameters.AddWithValue("@o3", "Numune Kabul Edildi");
            add.Parameters.AddWithValue("@o4", Giris.kullaniciID);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        private void btn_analizekle_Click(object sender, EventArgs e)
        {
            try
            {
                EvrakNoo();
               

                if (checkEdit1.Checked == true)
                    akredite = "Var";
                else
                    akredite = "Yok";

                if (comboFirma.Text == "" || txtRapor.Text == "")
                {
                    MessageBox.Show("Bir şeyleri atlamış olabilir misin? Rapor no veya firma adı gibi..");
                }
                else
                {
 

                    if (EvrakNo == 0)
                    {
                        yenievrak();
                    }
                    else
                    {
                        tekrarevrak();
                    }

                    //   lbl_rapno.Text = txtRapor.Text;
                    durumekle();
                    fotokaydet();                  
                    n.listele();                    

                    tabPane1.SelectedPage = tabNavigationPage2;

                }

              //  n.listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tüh ya! Bak ne oldu: " + ex.Message);
            }

            

        }

        private void txtEvrak_TextChanged(object sender, EventArgs e)
        {
            EvrakNoo();
        }


        public static string rDurumu = "Rapor Beklemede";
        public static string fDurumu = "Fatura Kesilmedi";

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

            //if (combo_grup.Text == "Özel" || combo_grup.Text == "Özel2")
            //{
            //   // txt_basvuru.Enabled = false;
            //  //  txt_marka.Enabled = false;
            //  //  txt_model.Enabled = false;
            //  //  combo_tur.Enabled = false;
            //    labelControl5.Text = "Alıcı / Üretici Firma:";
            //    txt_lot.Enabled = true;
            //    txt_skt.Enabled = true;
            //    txt_uretim.Enabled = true;
            //    combo_denetci.Visible = false;
            //    txt_alicifirma.Visible = true;
            //    combo_bakanlik.Visible = false;
            //}
            //else if(combo_grup.Text == "Bakanlık")
            //{
            //    txt_lot.Enabled = false;
            //    txt_skt.Enabled = false;
            //    txt_uretim.Enabled = false;
            //    combo_tur.Enabled = true;
            //    txt_basvuru.Enabled = true;
            //    txt_marka.Enabled = true;
            //    txt_model.Enabled = true;
            //    txt_alicifirma.Visible = false;
            //    combo_bakanlik.Visible = true;
            //    combo_denetci.Visible = true;
            //    labelControl5.Text = "Bakanlık / Denetçi:";

            //}
            //else if (combo_grup.Text == "Tareks")
            //{
            //    txt_lot.Enabled = false;
            //    txt_skt.Enabled = false;
            //    txt_uretim.Enabled = false;
            //    combo_tur.Enabled = true;
            //    txt_basvuru.Enabled = true;
            //    txt_marka.Enabled = true;
            //    txt_model.Enabled = true;
            //    txt_alicifirma.Visible = true;
            //    combo_bakanlik.Visible = false;
            //    labelControl5.Text = "Alıcı / Üretici Firma:";
            //    combo_denetci.Visible = false;
            //}
            //else
            //{
            //    txt_lot.Enabled = true;
            //    txt_skt.Enabled = true;
            //    txt_uretim.Enabled = true;
            //    combo_tur.Enabled = false;
            //    labelControl5.Text = "Alıcı / Üretici Firma:";
            //    txt_basvuru.Enabled = true;
            //    txt_marka.Enabled = true;
            //    txt_model.Enabled = true;
            //    txt_alicifirma.Visible = true;
            //    combo_bakanlik.Visible = false;
            //    combo_denetci.Visible = false;
            //}
        }

        private void comboFirma_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            combo_yetkili.Properties.Items.Clear();
            combo_yetkili.Text = "";

            SqlCommand komut2 = new SqlCommand("Select ID From Firma where Firma_Adi = N'" + comboFirma.Text + "'", bgl.baglanti());
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                firmaId = Convert.ToInt32(dr["ID"].ToString());
            }
            bgl.baglanti().Close();

            SqlCommand komut12 = new SqlCommand("Select Yetkili From Yetkili where Firma_ID = N'" + firmaId + "'", bgl.baglanti());
            SqlDataReader dr12 = komut12.ExecuteReader();
            while (dr12.Read())
            {
                combo_yetkili.Properties.Items.Add(dr12[0]);
            }
            bgl.baglanti().Close();

        }

        public static int TurID, ykrID;
        string alicifirma;
        void yenievrak()
        {
            SqlCommand komut2 = new SqlCommand("Select ID from Numune_Grup where Tur = '" + combo_tur.Text + "' and Grup = '"+ combo_grup.Text +"'", bgl.baglanti());
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
            int Donen = 0;

            SqlCommand komut = new SqlCommand("BEGIN TRANSACTION " +
                         "insert into NKR (Evrak_No,Numune_Adi,Tarih,Tur,Grup,Firma_ID,Rapor_Durumu,Aciklama,RaporNo,Revno,Akreditasyon,Durum,Karar,Dil) values (@n1,@n2,@n4,@n5,@n6,@n7,@n8,@n9,@n11,@n12,@n13,@n14,@n15,@n16) SET @ID = SCOPE_IDENTITY() ; " +
                         "insert into Odeme(Odeme_Durumu, Evrak_No) values(@o1,@o2); " +
                         "insert into NumuneDetay(AliciFirma,Miktar,SeriNo,UretimTarihi,SKT,BasvuruNo,Marka,RaporID,Model,ProjeID,Birim) values(@a1,@a2,@a3,@a4,@a5,@a6,@a7,IDENT_CURRENT('NKR'),@a8,@a9,@a10)" +
                         "insert into NumuneDetay2(RaporID,YetkiliID, DenetciID) values(IDENT_CURRENT('NKR'),@x1,@x2);" +
                         "insert into Termin(RaporID,Termin) values(IDENT_CURRENT('NKR'),@b1); " +
                         "insert into Rapor_Durum(RaporNo, Durum, Tarih,TanimlayanID, RaporID) values (@c1,@c2, @c3,@c4,IDENT_CURRENT('NKR')); " +
                         "COMMIT TRANSACTION", bgl.baglanti());
            //  "insert into NumuneModel(RaporID,Urun_Kodu,Model) values(IDENT_CURRENT('NKR'),@c2,@c3)"
            komut.Parameters.AddWithValue("@n1", txtEvrak.Text);
            komut.Parameters.AddWithValue("@n2", txtNumune.Text);
            komut.Parameters.AddWithValue("@n4", dateTime.EditValue);
            komut.Parameters.AddWithValue("@n5", combo_tur.Text);
            komut.Parameters.AddWithValue("@n6", combo_grup.Text);
            komut.Parameters.AddWithValue("@n7", firmaId);
            komut.Parameters.AddWithValue("@n8", rDurumu);
            komut.Parameters.AddWithValue("@n9", txt_aciklama.Text);
            komut.Parameters.AddWithValue("@n11", txtRapor.Text);
            komut.Parameters.AddWithValue("@n12", txtRev.Text);
            komut.Parameters.AddWithValue("@n13", akredite);
            komut.Parameters.AddWithValue("@n14", "Aktif");
            komut.Parameters.AddWithValue("@n15", combo_karar.Text);
            komut.Parameters.AddWithValue("@n16", combo_dil.Text);
            komut.Parameters.AddWithValue("@o1", fDurumu);
            komut.Parameters.AddWithValue("@o2", txtEvrak.Text);
            komut.Parameters.AddWithValue("@a1", alicifirma);
            komut.Parameters.AddWithValue("@a2", txtAdet.Text);
            komut.Parameters.AddWithValue("@a3", txt_lot.Text);
            komut.Parameters.AddWithValue("@a4", txt_uretim.Text);
            komut.Parameters.AddWithValue("@a5", txt_skt.Text);
            komut.Parameters.AddWithValue("@a6", txt_basvuru.Text);
            komut.Parameters.AddWithValue("@a7", txt_marka.Text);
            komut.Parameters.AddWithValue("@a8", txt_model.Text);
            komut.Parameters.AddWithValue("@a9", projeID);
            komut.Parameters.AddWithValue("@a10", combo_birim.Text);
            komut.Parameters.AddWithValue("@b1", dateTermin.EditValue);
            komut.Parameters.AddWithValue("@x1", yetkiliID);
            komut.Parameters.AddWithValue("@x2", denetciID);
            komut.Parameters.AddWithValue("@c1", txtRapor.Text);
            komut.Parameters.AddWithValue("@c2", "Yeni Numune");
            komut.Parameters.AddWithValue("@c3", dateTime.EditValue);
            komut.Parameters.AddWithValue("@c4", Giris.kullaniciID);
            komut.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            komut.ExecuteNonQuery();
            Donen = Convert.ToInt32(komut.Parameters["@ID"].Value);
            bgl.baglanti().Close();
            ykrID = Donen;
        }

        void tekrarevrak()
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

            SqlCommand komut = new SqlCommand("BEGIN TRANSACTION " +
                          "insert into NKR (Evrak_No,Numune_Adi,Tarih,Tur,Grup,Firma_ID,Rapor_Durumu,Aciklama,RaporNo,Revno,Akreditasyon,Durum,Karar, Dil) values (@n1,@n2,@n4,@n5,@n6,@n7,@n8,@n9,@n11,@n12,@n13,@n14,@n15,@n16)  SET @ID = SCOPE_IDENTITY() ; " +
                          "insert into NumuneDetay(AliciFirma,Miktar,SeriNo,UretimTarihi,SKT,BasvuruNo,Marka,RaporID,Model,ProjeID,Birim) values(@a1,@a2,@a3,@a4,@a5,@a6,@a7,IDENT_CURRENT('NKR'),@a8,@a9,@a10)" +
                          "insert into NumuneDetay2(RaporID,YetkiliID, DenetciID) values(IDENT_CURRENT('NKR'),@x1,@x2);" +
                          "insert into Termin(RaporID,Termin) values(IDENT_CURRENT('NKR'),@b1); " +
                          "insert into Rapor_Durum(RaporNo, Durum, Tarih,TanimlayanID, RaporID) values (@c1,@c2, @c3,@c4,IDENT_CURRENT('NKR')); "+
                          "COMMIT TRANSACTION", bgl.baglanti());
            komut.Parameters.AddWithValue("@n1", txtEvrak.Text);
            komut.Parameters.AddWithValue("@n2", txtNumune.Text);
            komut.Parameters.AddWithValue("@n4", dateTime.EditValue);
            komut.Parameters.AddWithValue("@n5", combo_tur.Text);
            komut.Parameters.AddWithValue("@n6", combo_grup.Text);
            komut.Parameters.AddWithValue("@n7", firmaId);
            komut.Parameters.AddWithValue("@n8", rDurumu);
            komut.Parameters.AddWithValue("@n9", txt_aciklama.Text);
            komut.Parameters.AddWithValue("@n11", txtRapor.Text);
            komut.Parameters.AddWithValue("@n12", txtRev.Text);
            komut.Parameters.AddWithValue("@n13", akredite);
            komut.Parameters.AddWithValue("@n14", "Aktif");
            komut.Parameters.AddWithValue("@n15", combo_karar.Text);
            komut.Parameters.AddWithValue("@n16", combo_dil.Text);
            komut.Parameters.AddWithValue("@a1", alicifirma);
            komut.Parameters.AddWithValue("@a2", txtAdet.Text);
            komut.Parameters.AddWithValue("@a3", txt_lot.Text);
            komut.Parameters.AddWithValue("@a4", txt_uretim.Text);
            komut.Parameters.AddWithValue("@a5", txt_skt.Text);
            komut.Parameters.AddWithValue("@a6", txt_basvuru.Text);
            komut.Parameters.AddWithValue("@a7", txt_marka.Text);
            komut.Parameters.AddWithValue("@a8", txt_model.Text);
            komut.Parameters.AddWithValue("@a9", projeID);
            komut.Parameters.AddWithValue("@a10", combo_birim.Text);
            komut.Parameters.AddWithValue("@b1", dateTermin.EditValue);
            komut.Parameters.AddWithValue("@x1", yetkiliID);
            komut.Parameters.AddWithValue("@x2", denetciID);
            komut.Parameters.AddWithValue("@c1", txtRapor.Text);
            komut.Parameters.AddWithValue("@c2", "Yeni Numune");
            komut.Parameters.AddWithValue("@c3", dateTime.EditValue);
            komut.Parameters.AddWithValue("@c4", Giris.kullaniciID);
            //komut.ExecuteNonQuery();
            //bgl.baglanti().Close();
            komut.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            komut.ExecuteNonQuery();
            ykrID = Convert.ToInt32(komut.Parameters["@ID"].Value);
            bgl.baglanti().Close();
           
        }

        //  int raporID;
        public static string akredite, analizsayisi, id, o2;

        public void proje()
        {
            SqlCommand komut = new SqlCommand("Select Firma_Adi from Firma where Tur= N'Proje' and Durum = N'Aktif' order by Firma_Adi", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBoxEdit1.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //Proje fp = new Proje();
            //fp.ShowDialog();
        }

        int projeID;
        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select ID from Firma where Firma_Adi = N'" + comboBoxEdit1.Text + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                string pID = dr["ID"].ToString();
                if (pID == "" || pID == null || pID == "0")
                {
                    projeID = 5487;
                }
                else
                {
                    projeID = Convert.ToInt32(pID);
                }
                
            }
            bgl.baglanti().Close();
        }

        int contRap, oo2;

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {

            //PrinterSettings ps = new PrinterSettings();
            //PrintDocument Kagit = new PrintDocument();
            //Kagit.PrinterSettings = ps;
            //Kagit.DefaultPageSettings.PaperSize = new PaperSize("80x100 mm", 380, 315);
            //DialogResult yazdirmaislemi;
            //yazdirmaislemi = prd.ShowDialog();
            //Kagit.PrintPage += Kagit_PrintPage;
            //if (yazdirmaislemi == DialogResult.OK)
            //{
            //    Kagit.Print();
            //}


            Raporlar.NKREtiket.nID = ykrID.ToString();
            using (Raporlar.frmPrint frm = new Raporlar.frmPrint())
            {
                frm.NKREtiket();
                frm.ShowDialog();
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
            for (int j = 0; j < gridView2.SelectedRowsCount; j++)
            {
                id = gridView2.GetSelectedRows()[j].ToString();
                int y = Convert.ToInt32(id);
                kod = gridView3.GetRowCellValue(y, "Kod").ToString();
                analiz = gridView3.GetRowCellValue(y, "Analiz Adı").ToString();
                metod = gridView3.GetRowCellValue(y, "Metot").ToString();

                e.Graphics.DrawString(b + ". " +kod + " "+analiz + " / " + metod, analizler, kalem, 20, a);
                a += 15;
                b++;

            }
        }

        private void txtAdet_KeyPress_1(object sender, KeyPressEventArgs e)
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


        public static string name;

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            
        }
        int yetkiliID, denetciID;
        private void combo_yetkili_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut12 = new SqlCommand("Select ID From Yetkili where Yetkili = N'" + combo_yetkili.Text + "' and Firma_ID = N'" + firmaId + "'", bgl.baglanti());
            SqlDataReader dr12 = komut12.ExecuteReader();
            while (dr12.Read())
            {
                yetkiliID = Convert.ToInt32(dr12[0].ToString());
            }
            bgl.baglanti().Close();
        }

        void denetcibul()
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


        void fotokaydet()
        {
            try
            {
                //string yol;
                //yol = pictureEdit1.GetLoadedImageLocation();
                //MessageBox.Show(yol + dateTime.EditValue);

                if (name == null || name =="")
                {

                }
                else
                {
                    string isim = Path.GetFileName(name);
                    yenisim = txtRapor.Text + " - " + isim;

                    using (var client = new WebClient())
                    {
                        string ftpUsername = "massgrup";
                        string ftpPassword = "!88n2ee5Q";
                        ftpfullpath = "ftp://" + "www.rootarge.com/httpdocs/cosmo/Numune" + "/" + yenisim;
                        yeniyol = "http://" + "www.rootarge.com/cosmo/Numune" + "/" + yenisim;
                        client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                        client.UploadFile(ftpfullpath, name);
                    }

                    //  File.Copy(name, Path.Combine(@"\\WDMyCloud\Numune\2020\Foto", yenisim), true);
                    //  string yol = Path.Combine(@"C:\Users\X260\Desktop\Yeni Klasör", yenisim);
                    //string yol = Path.Combine(@"\\WDMyCloud\Numune\2020\Foto", yenisim);
                    //File.Copy(name, yol, true);

                    //SqlCommand komut = new SqlCommand("Select ID from NKR where RaporNo = N'" + txtRapor.Text + "' ", bgl.baglanti());
                    //SqlDataReader dr = komut.ExecuteReader();
                    //while (dr.Read())
                    //{
                    //    txt_yeniID.Text = dr[0].ToString();
                    //}
                    //bgl.baglanti().Close();


                    SqlCommand ekle = new SqlCommand("insert into Fotograf(RaporID,Path) values(@d1,@d2)", bgl.baglanti());
                    ekle.Parameters.AddWithValue("@d1", ykrID);
                    ekle.Parameters.AddWithValue("@d2", yenisim);
                    ekle.ExecuteNonQuery();
                    bgl.baglanti().Close();

                }




                // Fotograf db sine kaydedilir bundan sonra..

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

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        void analizler()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(@"select l.Kod, l.Ad, l.Method, l.ID as 'aID' from NumuneX4 x
            left join StokAnalizDetay d on x.AltAnalizID = d.ID
            left join StokAnalizListesi l on d.AnalizID = l.ID
            where d.Tur = 'Toplam' and x.X3ID = '" + gridLookUpEdit1.EditValue + "' except Select l.Kod, l.Ad, l.Method, l.ID as 'aID' from NumuneX4 x left join StokAnalizDetay d on x.AltAnalizID = d.ID left join StokAnalizListesi l on d.AnalizID = l.ID where l.ID in (select AnalizID from NumuneX1 where RaporID = '"+ykrID+"') order by l.Kod ", bgl.baglanti());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
            gridView2.Columns["aID"].Visible = false;
            if (dt2 != null)
            {
                this.gridView2.Columns[0].Width = 35;
                this.gridView2.Columns[1].Width = 80;
                this.gridView2.Columns[2].Width = 45;
            }
  

        }

        void analizler2()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(@"select l.Kod, l.Ad, l.Method, x.Termin, l.ID as 'aID', x.ID as 'xID' from NumuneX1 x
            left join StokAnalizListesi l on x.AnalizID = l.ID
            where x.RaporID = '" + ykrID + "' order by l.Kod", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;
            gridView3.Columns["aID"].Visible = false;
            gridView3.Columns["xID"].Visible = false;

            this.gridView3.Columns[0].Width = 35;
            this.gridView3.Columns[1].Width = 80;
            this.gridView3.Columns[2].Width = 45;
            this.gridView3.Columns[3].Width = 55;

            RepositoryItemDateEdit da = new RepositoryItemDateEdit();
            da.ShowToday = true;
            gridView3.Columns["Termin"].ColumnEdit = da;

        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //açıklama değişince listeleme

            analizler();

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //seçili analizleri ekle

            for (int i = 0; i < gridView2.SelectedRowsCount; i++)
            {
                id = gridView2.GetSelectedRows()[i].ToString();
                int y = Convert.ToInt32(id);
                o2 = gridView2.GetRowCellValue(y, "aID").ToString();
                SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                    "insert into NumuneX1 (RaporID, AnalizID, x3ID) " +
                    "values (@o1,@o2, @o3);" +
                    "COMMIT TRANSACTION", bgl.baglanti());
                add2.Parameters.AddWithValue("@o1", ykrID);
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
                add2.Parameters.AddWithValue("@o1", ykrID);
                add2.Parameters.AddWithValue("@o2", o2);
                add2.ExecuteNonQuery();
                bgl.baglanti().Close();
            }

            analizler();
            analizler2();
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

        string yenisim, ftpfullpath, yeniyol;

        string analizadi, metot;
        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            try
            {


                for (int i = 0; i < gridView3.RowCount; i++)
                {                   
                    o2 = gridView3.GetRowCellValue(i, "xID").ToString();
                    SqlCommand add2 = new SqlCommand("BEGIN TRANSACTION " +
                        "update NumuneX1 set Termin = @o1, Durum = @o2, HizmetDurum = @o3 where ID = @o4;" +
                        "COMMIT TRANSACTION", bgl.baglanti());
                    add2.Parameters.AddWithValue("@o1", Convert.ToDateTime(gridView3.GetRowCellValue(i, "Termin").ToString()));
                    add2.Parameters.AddWithValue("@o2", "Aktif");
                    add2.Parameters.AddWithValue("@o3", "Yeni Analiz");
                    add2.Parameters.AddWithValue("@o4", o2);
                    add2.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }




                DialogResult cikis = new DialogResult();
                cikis = MessageBox.Show("Analizler de tamam. Yeni Numune?", "Uyarı", MessageBoxButtons.YesNo);
                if (cikis == DialogResult.Yes)
                {
                    gridControl1.DataSource = null;
                    gridView3.Columns.Clear();
                    analizler();
                    tabPane1.SelectedPage = tabNavigationPage1;
                    pictureEdit1.Image = null;

                    Evrakmax();
                    txtRapor.Text = "";
                    RaporNoMax();
                    int yenirap = maxrapor + 1;
                    txtRapor.Text = yenirap.ToString();
                }

                if (cikis == DialogResult.No)
                {
                    this.Close();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Tüh ya! Bak ne oldu 77: " + ex.Message);
            }

            //gridView2.ClearSelection();
            //tabPane1.SelectedPage = tabNavigationPage1;


        }


    }
}
