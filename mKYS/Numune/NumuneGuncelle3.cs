using DevExpress.XtraEditors;
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
    public partial class NumuneGuncelle3 : Form
    {


        public NumuneGuncelle3()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();

        NKR n = (NKR)System.Windows.Forms.Application.OpenForms["NKR"];
        NKR2 m = (NKR2)System.Windows.Forms.Application.OpenForms["NKR2"];

        void analizler()
        {
            //where d.Tur = 'Toplam' and x.X3ID = '" + gridLookUpEdit1.EditValue + "' except Select l.Kod, l.Ad, l.Method, l.ID as 'aID' from NumuneX4 x left join StokAnalizDetay d on x.AltAnalizID = d.ID left join StokAnalizListesi l on d.AnalizID = l.ID where l.ID in (select AnalizID from NumuneX1 where RaporID = '" + nID + "') order by l.Kod ", bgl.baglanti());
                       
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(@"select l.Kod, l.Ad, l.Method, l.ID as 'aID' from NumuneX4 x
            left join StokAnalizDetay d on x.AltAnalizID = d.ID
            left join StokAnalizListesi l on d.AnalizID = l.ID
            where x.X3ID = '" + gridLookUpEdit1.EditValue + "' except Select l.Kod, l.Ad, l.Method, l.ID as 'aID' from NumuneX4 x left join StokAnalizDetay d on x.AltAnalizID = d.ID left join StokAnalizListesi l on d.AnalizID = l.ID where l.ID in (select AnalizID from NumuneX1 where RaporID = '" + nID + "') order by l.Kod ", bgl.baglanti());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
            gridView2.Columns["aID"].Visible = false;
        }

        void analizler2()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(@"select l.Kod, l.Ad, l.Method, l.ID as 'aID' from NumuneX1 x
            left join StokAnalizListesi l on x.AnalizID = l.ID
            where x.RaporID = '" + nID + "' order by l.Kod", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;
            gridView3.Columns["aID"].Visible = false;
        }

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

        string durum, fotoname;

        public void fotobul()
        {
            nID = NKR2.nkrID;
            SqlCommand detay2 = new SqlCommand("Select Path from Fotograf where RaporID = '" + nID + "'", bgl.baglanti());
            SqlDataReader dre = detay2.ExecuteReader();
            while (dre.Read())
            {
                fotoname = dre["Path"].ToString();
            }

            dateTermin.EditValue = Convert.ToDateTime(NKR2.termin);

        }

        public void goster()
        {
            nID = NKR2.nkrID;
            txtEvrak.Text = NKR2.evrakNo;
            txtNumune.Text = NKR2.fnumune;
            txtRapor.Text = NKR2.raporNo;
            //  txtRev.Text = NKR.revizyonNo;
            txtRev.Text = NKR2.nrev;
            dateTime.EditValue = Convert.ToDateTime(NKR2.ftarih);
            comboFirma.Text = NKR2.ffirma;
            //  combo_tur.Text = NKR.ftur;
            string tur = NKR2.ntur;
            combo_tur.Text = tur;
            combo_grup.Text = NKR2.fgrup;
            txt_aciklama.Text = NKR2.faciklama;
            // comboBoxEdit1.Text = projeadi;

            if (NKR2.nakr == "Var")
            {
                checkEdit1.Checked = true;

            }
            else
            {
                checkEdit1.Checked = false;

            }

            if (combo_grup.Text == "Bakanlık")
            {
                txt_alicifirma.Visible = false;
                combo_bakanlik.Visible = true;
                combo_denetci.Visible = true;
                combo_bakanlik.Text = NKR2.alicifirma;

                SqlCommand komut = new SqlCommand("select Yetkili from Yetkili where ID in (select DenetciID from NumuneDetay2 where RaporID = N'" + nID + "')", bgl.baglanti());
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    combo_denetci.Text = dr[0].ToString();
                }
                bgl.baglanti().Close();
            }
            else
            {
                txt_alicifirma.Visible = true;
                combo_bakanlik.Visible = false;
                combo_denetci.Visible = false;
                txt_alicifirma.Text = NKR2.alicifirma;
            }


            txtAdet.Text = NKR2.fadet;
            txt_lot.Text = NKR2.lot;
            txt_uretim.EditValue = NKR2.üt;
            txt_skt.Text = NKR2.skt;
            txt_basvuru.Text = NKR2.basvuru;
            txt_model.Text = NKR2.model;
            txt_marka.Text = NKR2.marka;
            combo_birim.Text = NKR2.fbirim;

            SqlCommand komut2 = new SqlCommand("select Yetkili from Yetkili where ID in (select YetkiliID from NumuneDetay2 where RaporID = N'" + nID + "')", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                combo_yetkili.Text = dr2[0].ToString();
            }
            bgl.baglanti().Close();

        }

        void temizle()
        {
            txtNumune.Text = "";
            txtAdet.Text = "";
            txt_aciklama.Text = "";
            txtEvrak.Text = "";
            txtRev.Text = "";
            txtRapor.Text = "";
            txt_alicifirma.Text = "";
            txt_alicifirma.Text = "";
            txt_basvuru.Text = "";
            txt_lot.Text = "";
            txt_marka.Text = "";
            txt_model.Text = "";
            txt_skt.Text = "";
            txt_uretim.Text = "";
            combo_yetkili.Text = "";
            combo_bakanlik.Text = "";
            combo_denetci.Text = "";
        }

        public static int nID, firmadanGelenID, aliciid;

        private void NumuneKabul_Load(object sender, EventArgs e)
        {            
            temizle();
            analizler2();
            listele();
            goster();
            fotobul();
            Firma();


            proje();
            projebul();

            //  OpenFileDialog open = new OpenFileDialog();
            try
            {
                if (fotoname == null)
                {
                    string logo = @"http://www.cosmoliz.com/cosmo/Numune/Logo.jpg";
                  //  pictureEdit1.Image = new Bitmap(logo);
                    pictureEdit1.LoadAsync(logo);
                }
                else
                {
                    string yol = @"http://www.cosmoliz.com/cosmo/Numune/" + fotoname;
                    //   pictureEdit1.Image = new Bitmap(yol);

                    var request = WebRequest.Create(yol);
                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream())
                    { pictureEdit1.Image = Bitmap.FromStream(stream); }
                }
            }
            catch (Exception)
            {


            }


        }

        void IDbul()
        {

            SqlCommand komut3 = new SqlCommand("Select ID from Firma where Firma_Adi = N'" + comboFirma.Text + "'", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                firmadanGelenID = Convert.ToInt32(dr3["ID"]);
            }
            bgl.baglanti().Close();


        }

        void Odemeidbul()
        {
            SqlCommand detay = new SqlCommand("select ID from Odeme where Evrak_No = N'" + txtEvrak.Text + "'", bgl.baglanti());
            SqlDataReader drd = detay.ExecuteReader();
            while (drd.Read())
            {
                odemeid = Convert.ToInt32(drd["ID"]);
            }
            bgl.baglanti().Close();
        }

        public static int projeid, odemeid;
        public static string projeadi;
        public void projebul()
        {

            SqlCommand detay = new SqlCommand("select ProjeID from NumuneDetay where RaporID = '"+nID+"' ", bgl.baglanti());
            SqlDataReader drd = detay.ExecuteReader();
            while (drd.Read())
            {
                projeid = Convert.ToInt32(drd["ProjeID"]);
            }
            bgl.baglanti().Close();

            SqlCommand detayd = new SqlCommand("Select Firma_Adi from Firma where ID = N'" + projeid + "'", bgl.baglanti());
            SqlDataReader drde = detayd.ExecuteReader();
            while (drde.Read())
            {
                projeadi = drde["Firma_Adi"].ToString();
                comboBoxEdit1.Text = projeadi;
            }
            bgl.baglanti().Close();
        }

        void guncelle()
        {
            try
            {
                SqlCommand komut2 = new SqlCommand("Select ID from Numune_Grup where Tur = '" + combo_tur.Text + "' and Grup = '" + combo_grup.Text + "'", bgl.baglanti());
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    TurID = Convert.ToInt32(dr2["ID"]);
                }
                bgl.baglanti().Close();



                // IDbul();
                IDbul();
                Odemeidbul();

                if (checkEdit1.Checked == true)
                {
                    durum = "Var";
                }
                else
                {
                    durum = "Yok";
                }

                if (combo_grup.Text == "Bakanlık")
                {
                    alicifirma = combo_bakanlik.Text;
                }
                else
                {
                    alicifirma = txt_alicifirma.Text;
                }


                bgl.baglanti().Close();
                SqlCommand komut = new SqlCommand("BEGIN TRANSACTION " +
                 "update NKR set Evrak_No=@n3, Revno=@n7, RaporNo = @n1,Numune_Adi=@n2,Tarih=@n4,Tur=@n5,Grup=@n6,Aciklama=@n8,Firma_ID=@n9, Akreditasyon=@n10 where ID = N'" + nID + "'" +
                 "update Termin set Termin=@t1 where RaporID = N'" + nID + "'" +
                 "update Odeme set Evrak_No=@k1 where ID = N'" + odemeid + "'" +
                 "update NumuneDetay2 set YetkiliID =@x1, DenetciID=@x2 where RaporID = N'" + nID + "'" +
                 "update NumuneDetay set AliciFirma=@o1, Marka=@o2, BasvuruNo=@o3, SeriNo=@o4,Model=@o5, Miktar=@o6, UretimTarihi=@o7, SKT=@o8, ProjeID=@o9, Birim=@o10 where  RaporID = N'" + nID + "'" +
                 "COMMIT TRANSACTION", bgl.baglanti());
                komut.Parameters.AddWithValue("@k1", txtEvrak.Text);
                komut.Parameters.AddWithValue("@n1", txtRapor.Text);
                komut.Parameters.AddWithValue("@n2", txtNumune.Text);
                komut.Parameters.AddWithValue("@n3", txtEvrak.Text);
                komut.Parameters.AddWithValue("@n4", dateTime.EditValue);
                komut.Parameters.AddWithValue("@n5", combo_tur.SelectedItem.ToString());
                komut.Parameters.AddWithValue("@n6", combo_grup.SelectedItem.ToString());
                komut.Parameters.AddWithValue("@n7", txtRev.Text);
                komut.Parameters.AddWithValue("@n8", txt_aciklama.Text);
                komut.Parameters.AddWithValue("@n9", firmadanGelenID);
                komut.Parameters.AddWithValue("@n10", durum);
                komut.Parameters.AddWithValue("@t1", dateTermin.EditValue);
                komut.Parameters.AddWithValue("@o1", alicifirma);
                komut.Parameters.AddWithValue("@o2", txt_marka.Text);
                komut.Parameters.AddWithValue("@o3", txt_basvuru.Text);
                komut.Parameters.AddWithValue("@o4", txt_lot.Text);
                komut.Parameters.AddWithValue("@o5", txt_model.Text);
                komut.Parameters.AddWithValue("@o6", txtAdet.Text);
                komut.Parameters.AddWithValue("@o7", txt_uretim.Text);
                komut.Parameters.AddWithValue("@o8", txt_skt.Text);
                komut.Parameters.AddWithValue("@o9", projeID);
                komut.Parameters.AddWithValue("@o10", combo_birim.Text);
                komut.Parameters.AddWithValue("@x1", yetkiliID);
                komut.Parameters.AddWithValue("@x2", denetciID);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Güncelleme İşlemi Başarıyla Gerçekleşmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (Application.OpenForms["NKR"] == null)
                {

                }
                else
                {
                    n.listele();
                }

                if (Application.OpenForms["NKR2"] == null)
                {

                }
                else
                {
                    m.listele();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Tüh ya bak ne oldu! : " + ex.Message);
            }
        }

        public void proje()
        {
            SqlCommand komut = new SqlCommand("Select Firma_Adi from Firma where Tur = N'Proje' and Durum = N'Aktif' order by Firma_Adi", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBoxEdit1.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
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

        int projeID;
        string ftpfullpath, yeniyol;
        string name;
        string yenisim, isim;

        void resimguncelle()
        {
            //try
            //{
            OpenFileDialog open = new OpenFileDialog();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // open.InitialDirectory = "C:\\";
            open.InitialDirectory = path;
            open.Filter = "Fotoğraf (*.jpg)|*.jpg|Tüm Dosyalar(*.*)|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                name = open.FileName;
                pictureEdit1.Image = new Bitmap(open.FileName);


                DialogResult cikis = new DialogResult();
                cikis = MessageBox.Show("Fotoğrafı güncelleyelim mi ?", "Uyarı", MessageBoxButtons.YesNo);

                if (cikis == DialogResult.Yes)
                {
                    isim = Path.GetFileName(name);
                    yenisim = txtRapor.Text + " - " + isim;
                    //  File.Copy(name, Path.Combine(@"\\WDMyCloud\Numune\2020\Foto", yenisim), true);
                    //  string yol = Path.Combine(@"C:\Users\X260\Desktop\Yeni Klasör", yenisim);
                    //string yol = Path.Combine(@"\\WDMyCloud\Numune\2020\Foto", yenisim);
                    //File.Copy(name, yol, true);
                    using (var client = new WebClient())
                    {
                        string ftpUsername = "massgrup";
                        string ftpPassword = "!88n2ee5Q";
                        ftpfullpath = "ftp://" + "www.cosmoliz.com/httpdocs/cosmo/Numune" + "/" + yenisim;
                        yeniyol = "http://" + "www.cosmoliz.com/cosmo/Numune" + "/" + yenisim;
                        client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                        // client.UploadFile(ftpfullpath, WebRequestMethods.Ftp.UploadFile, name);
                        client.UploadFile(ftpfullpath, name);
                    }

                    fotobul();
                    if (fotoname == null)
                    {
                        SqlCommand komut = new SqlCommand("insert into Fotograf (RaporID, Path) values (N'" + nID + "', @t1) ", bgl.baglanti());
                        komut.Parameters.AddWithValue("@t1", yenisim);
                        komut.ExecuteNonQuery();
                        bgl.baglanti().Close();
                    }
                    else
                    {

                        SqlCommand komut = new SqlCommand("update Fotograf set Path=@t1 where RaporID = N'" + nID + "'", bgl.baglanti());
                        komut.Parameters.AddWithValue("@t1", yenisim);
                        komut.ExecuteNonQuery();
                        bgl.baglanti().Close();
                    }


                    //pictureEdit1.Image = new Bitmap(yeniyol);

                    var request = WebRequest.Create(yeniyol);
                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream())
                    { pictureEdit1.Image = Bitmap.FromStream(stream); }


                }
                if (cikis == DialogResult.No)
                {
                    name = open.FileName;
                    pictureEdit1.Image = new Bitmap(open.FileName);
                }


            }



            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show("Hata 123: " + ex);
            //}
        }

        int firmaId;
        private void comboFirma_SelectedIndexChanged(object sender, EventArgs e)
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

        private void combo_bakanlik_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_denetci.Properties.Items.Clear();
            combo_denetci.Text = "";
            denetcibul();
        }

        int yetkiliID, denetciID;


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

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select ID from Firma where Firma_Adi = N'" + comboBoxEdit1.Text + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                projeID = Convert.ToInt32(dr["ID"].ToString());
            }
            bgl.baglanti().Close();
        }

        private void combo_grup_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            //  combo_tur.Properties.Items.Clear();
            //  combo_tur.Text = "";
            SqlCommand komut = new SqlCommand("Select * from Numune_Grup where Grup = N'" + combo_grup.Text + "' order by Tur", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                combo_tur.Properties.Items.Add(dr["Tur"]);
            }
            bgl.baglanti().Close();

            //if (combo_grup.Text == "Özel")
            //{
            //    //txt_basvuru.Enabled = false;
            //    //txt_marka.Enabled = false;
            //    //txt_model.Enabled = false;
            //    //combo_tur.Enabled = false;
            //    txt_lot.Enabled = true;
            //    txt_skt.Enabled = true;
            //    txt_uretim.Enabled = true;
            //    labelControl5.Text = "Alıcı / Üretici Firma:";
            //    combo_denetci.Visible = false;
            //    txt_alicifirma.Visible = true;
            //    combo_bakanlik.Visible = false;
            //}
            //else if (combo_grup.Text == "Bakanlık")
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
            //    labelControl5.Text = "Alıcı / Üretici Firma:";
            //    combo_denetci.Visible = false;
            //    txt_alicifirma.Visible = true;
            //    combo_bakanlik.Visible = false;
            //}
            //else
            //{
            //    txt_lot.Enabled = true;
            //    txt_skt.Enabled = true;
            //    txt_uretim.Enabled = true;
            //    combo_tur.Enabled = true;
            //    txt_basvuru.Enabled = true;
            //    txt_marka.Enabled = true;
            //    txt_model.Enabled = true;
            //    labelControl5.Text = "Alıcı / Üretici Firma:";
            //    combo_denetci.Visible = false;
            //    txt_alicifirma.Visible = true;
            //    combo_bakanlik.Visible = false;
            //}

        }


        private void btn_analizekle_Click(object sender, EventArgs e)
        {
            try
            {
                guncelle();
                if (Application.OpenForms["NKR"] == null)
                {

                }
                else
                {
                    n.listele();
                }

                if (Application.OpenForms["NKR2"] == null)
                {

                }
                else
                {
                    m.listele();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tüh ya! Bak ne oldu: " + ex.Message);
            }



        }










   


        //private void txtEvrak_TextChanged(object sender, EventArgs e)
        //{
        //    EvrakNoo();
        //}


        //public static string rDurumu = "Rapor Beklemede";
        //public static string fDurumu = "Fatura Kesilmedi";

        //private void combo_grup_SelectedIndexChanged_1(object sender, EventArgs e)
        //{
        //    combo_tur.Text = null;

        //    combo_tur.Properties.Items.Clear();
        //    SqlCommand komut = new SqlCommand("Select * from Numune_Grup where Grup = N'" + combo_grup.SelectedItem + "' order by Tur", bgl.baglanti());
        //    SqlDataReader dr = komut.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        combo_tur.Properties.Items.Add(dr["Tur"]);
        //    }
        //    bgl.baglanti().Close();

        //    if (combo_grup.Text == "Özel")
        //    {
        //        // txt_basvuru.Enabled = false;
        //        //  txt_marka.Enabled = false;
        //        //  txt_model.Enabled = false;
        //        //  combo_tur.Enabled = false;
        //        labelControl5.Text = "Alıcı / Üretici Firma:";
        //        txt_lot.Enabled = true;
        //        txt_skt.Enabled = true;
        //        txt_uretim.Enabled = true;
        //        combo_denetci.Visible = false;
        //        txt_alicifirma.Visible = true;
        //        combo_bakanlik.Visible = false;
        //    }
        //    else if (combo_grup.Text == "Bakanlık")
        //    {
        //        txt_lot.Enabled = false;
        //        txt_skt.Enabled = false;
        //        txt_uretim.Enabled = false;
        //        combo_tur.Enabled = true;
        //        txt_basvuru.Enabled = true;
        //        txt_marka.Enabled = true;
        //        txt_model.Enabled = true;
        //        txt_alicifirma.Visible = false;
        //        combo_bakanlik.Visible = true;
        //        combo_denetci.Visible = true;
        //        labelControl5.Text = "Bakanlık / Denetçi:";

        //    }
        //    else if (combo_grup.Text == "Tareks")
        //    {
        //        txt_lot.Enabled = false;
        //        txt_skt.Enabled = false;
        //        txt_uretim.Enabled = false;
        //        combo_tur.Enabled = true;
        //        txt_basvuru.Enabled = true;
        //        txt_marka.Enabled = true;
        //        txt_model.Enabled = true;
        //        txt_alicifirma.Visible = true;
        //        combo_bakanlik.Visible = false;
        //        labelControl5.Text = "Alıcı / Üretici Firma:";
        //        combo_denetci.Visible = false;
        //    }
        //    else
        //    {
        //        txt_lot.Enabled = true;
        //        txt_skt.Enabled = true;
        //        txt_uretim.Enabled = true;
        //        combo_tur.Enabled = false;
        //        labelControl5.Text = "Alıcı / Üretici Firma:";
        //        txt_basvuru.Enabled = true;
        //        txt_marka.Enabled = true;
        //        txt_model.Enabled = true;
        //        txt_alicifirma.Visible = true;
        //        combo_bakanlik.Visible = false;
        //        combo_denetci.Visible = false;
        //    }
        //}

        //private void comboFirma_SelectedIndexChanged_1(object sender, EventArgs e)
        //{
        //    combo_yetkili.Properties.Items.Clear();
        //    combo_yetkili.Text = "";

        //    SqlCommand komut2 = new SqlCommand("Select ID From Firma where Firma_Adi = N'" + comboFirma.Text + "'", bgl.baglanti());
        //    SqlDataReader dr = komut2.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        firmaId = Convert.ToInt32(dr["ID"].ToString());
        //    }
        //    bgl.baglanti().Close();

        //    SqlCommand komut12 = new SqlCommand("Select Yetkili From Yetkili where Firma_ID = N'" + firmaId + "'", bgl.baglanti());
        //    SqlDataReader dr12 = komut12.ExecuteReader();
        //    while (dr12.Read())
        //    {
        //        combo_yetkili.Properties.Items.Add(dr12[0]);
        //    }
        //    bgl.baglanti().Close();

        //}

        public static int TurID;
        string alicifirma;
        //void yenievrak()
        //{
        //    SqlCommand komut2 = new SqlCommand("Select ID from Numune_Grup where Tur = '" + combo_tur.Text + "' and Grup = '" + combo_grup.Text + "'", bgl.baglanti());
        //    SqlDataReader dr2 = komut2.ExecuteReader();
        //    while (dr2.Read())
        //    {
        //        TurID = Convert.ToInt32(dr2["ID"]);
        //    }
        //    bgl.baglanti().Close();

        //    if (combo_grup.Text == "Bakanlık")
        //    {
        //        alicifirma = combo_bakanlik.Text;
        //    }
        //    else
        //    {
        //        alicifirma = txt_alicifirma.Text;
        //    }

        //    SqlCommand komut = new SqlCommand("BEGIN TRANSACTION " +
        //                 "insert into NKR (Evrak_No,Numune_Adi,Tarih,Tur,Grup,Firma_ID,Rapor_Durumu,Aciklama,RaporNo,Revno,Akreditasyon,Durum) values (@n1,@n2,@n4,@n5,@n6,@n7,@n8,@n9,@n11,@n12,@n13,@n14) ; " +
        //                 "insert into Odeme(Odeme_Durumu, Evrak_No) values(@o1,@o2); " +
        //                 "insert into NumuneDetay(AliciFirma,Miktar,SeriNo,UretimTarihi,SKT,BasvuruNo,Marka,RaporID,Model,ProjeID,Birim) values(@a1,@a2,@a3,@a4,@a5,@a6,@a7,IDENT_CURRENT('NKR'),@a8,@a9,@a10)" +
        //                 "insert into NumuneDetay2(RaporID,YetkiliID, DenetciID) values(IDENT_CURRENT('NKR'),@x1,@x2);" +
        //                 "insert into Termin(RaporID,Termin) values(IDENT_CURRENT('NKR'),@b1); " +
        //                 "insert into Rapor_Durum(RaporNo, Durum, Tarih,TanimlayanID, RaporID) values (@c1,@c2, @c3,@c4,IDENT_CURRENT('NKR')); " +
        //                 "COMMIT TRANSACTION", bgl.baglanti());
        //    //  "insert into NumuneModel(RaporID,Urun_Kodu,Model) values(IDENT_CURRENT('NKR'),@c2,@c3)" 
        //    komut.Parameters.AddWithValue("@n1", txtEvrak.Text);
        //    komut.Parameters.AddWithValue("@n2", txtNumune.Text);
        //    komut.Parameters.AddWithValue("@n4", dateTime.EditValue);
        //    komut.Parameters.AddWithValue("@n5", combo_tur.Text);
        //    komut.Parameters.AddWithValue("@n6", combo_grup.Text);
        //    komut.Parameters.AddWithValue("@n7", firmaId);
        //    komut.Parameters.AddWithValue("@n8", rDurumu);
        //    komut.Parameters.AddWithValue("@n9", txt_aciklama.Text);
        //    komut.Parameters.AddWithValue("@n11", txtRapor.Text);
        //    komut.Parameters.AddWithValue("@n12", txtRev.Text);
        //    komut.Parameters.AddWithValue("@n13", akredite);
        //    komut.Parameters.AddWithValue("@n14", "Aktif");
        //    komut.Parameters.AddWithValue("@o1", fDurumu);
        //    komut.Parameters.AddWithValue("@o2", txtEvrak.Text);
        //    komut.Parameters.AddWithValue("@a1", alicifirma);
        //    komut.Parameters.AddWithValue("@a2", txtAdet.Text);
        //    komut.Parameters.AddWithValue("@a3", txt_lot.Text);
        //    komut.Parameters.AddWithValue("@a4", txt_uretim.Text);
        //    komut.Parameters.AddWithValue("@a5", txt_skt.Text);
        //    komut.Parameters.AddWithValue("@a6", txt_basvuru.Text);
        //    komut.Parameters.AddWithValue("@a7", txt_marka.Text);
        //    komut.Parameters.AddWithValue("@a8", txt_model.Text);
        //    komut.Parameters.AddWithValue("@a9", projeID);
        //    komut.Parameters.AddWithValue("@a10", combo_birim.Text);
        //    komut.Parameters.AddWithValue("@b1", dateTermin.EditValue);
        //    komut.Parameters.AddWithValue("@x1", yetkiliID);
        //    komut.Parameters.AddWithValue("@x2", denetciID);
        //    komut.Parameters.AddWithValue("@c1", txtRapor.Text);
        //    komut.Parameters.AddWithValue("@c2", "Yeni Numune");
        //    komut.Parameters.AddWithValue("@c3", dateTime.EditValue);
        //    komut.Parameters.AddWithValue("@c4", Giris.kullaniciID);
        //    komut.ExecuteNonQuery();
        //    bgl.baglanti().Close();
        //}

        //void tekrarevrak()
        //{
        //    SqlCommand komut2 = new SqlCommand("Select ID from Numune_Grup where Tur = '" + combo_tur.Text + "' and Grup = '" + combo_grup.Text + "'", bgl.baglanti());
        //    SqlDataReader dr2 = komut2.ExecuteReader();
        //    while (dr2.Read())
        //    {
        //        TurID = Convert.ToInt32(dr2["ID"]);
        //    }
        //    bgl.baglanti().Close();

        //    if (combo_grup.Text == "Bakanlık")
        //    {
        //        alicifirma = combo_bakanlik.Text;
        //    }
        //    else
        //    {
        //        alicifirma = txt_alicifirma.Text;
        //    }

        //    SqlCommand komut = new SqlCommand("BEGIN TRANSACTION " +
        //                  "insert into NKR (Evrak_No,Numune_Adi,Tarih,Tur,Grup,Firma_ID,Rapor_Durumu,Aciklama,RaporNo,Revno,Akreditasyon,Durum) values (@n1,@n2,@n4,@n5,@n6,@n7,@n8,@n9,@n11,@n12,@n13,@n14) ; " +
        //                  "insert into NumuneDetay(AliciFirma,Miktar,SeriNo,UretimTarihi,SKT,BasvuruNo,Marka,RaporID,Model,ProjeID,Birim) values(@a1,@a2,@a3,@a4,@a5,@a6,@a7,IDENT_CURRENT('NKR'),@a8,@a9,@a10)" +
        //                  "insert into NumuneDetay2(RaporID,YetkiliID, DenetciID) values(IDENT_CURRENT('NKR'),@x1,@x2);" +
        //                  "insert into Termin(RaporID,Termin) values(IDENT_CURRENT('NKR'),@b1); " +
        //                  "insert into Rapor_Durum(RaporNo, Durum, Tarih,TanimlayanID, RaporID) values (@c1,@c2, @c3,@c4,IDENT_CURRENT('NKR')); " +
        //                  "COMMIT TRANSACTION", bgl.baglanti());
        //    komut.Parameters.AddWithValue("@n1", txtEvrak.Text);
        //    komut.Parameters.AddWithValue("@n2", txtNumune.Text);
        //    komut.Parameters.AddWithValue("@n4", dateTime.EditValue);
        //    komut.Parameters.AddWithValue("@n5", combo_tur.Text);
        //    komut.Parameters.AddWithValue("@n6", combo_grup.Text);
        //    komut.Parameters.AddWithValue("@n7", firmaId);
        //    komut.Parameters.AddWithValue("@n8", rDurumu);
        //    komut.Parameters.AddWithValue("@n9", txt_aciklama.Text);
        //    komut.Parameters.AddWithValue("@n11", txtRapor.Text);
        //    komut.Parameters.AddWithValue("@n12", txtRev.Text);
        //    komut.Parameters.AddWithValue("@n13", akredite);
        //    komut.Parameters.AddWithValue("@n14", "Aktif");
        //    komut.Parameters.AddWithValue("@a1", alicifirma);
        //    komut.Parameters.AddWithValue("@a2", txtAdet.Text);
        //    komut.Parameters.AddWithValue("@a3", txt_lot.Text);
        //    komut.Parameters.AddWithValue("@a4", txt_uretim.Text);
        //    komut.Parameters.AddWithValue("@a5", txt_skt.Text);
        //    komut.Parameters.AddWithValue("@a6", txt_basvuru.Text);
        //    komut.Parameters.AddWithValue("@a7", txt_marka.Text);
        //    komut.Parameters.AddWithValue("@a8", txt_model.Text);
        //    komut.Parameters.AddWithValue("@a9", projeID);
        //    komut.Parameters.AddWithValue("@a10", combo_birim.Text);
        //    komut.Parameters.AddWithValue("@b1", dateTermin.EditValue);
        //    komut.Parameters.AddWithValue("@x1", yetkiliID);
        //    komut.Parameters.AddWithValue("@x2", denetciID);
        //    komut.Parameters.AddWithValue("@c1", txtRapor.Text);
        //    komut.Parameters.AddWithValue("@c2", "Yeni Numune");
        //    komut.Parameters.AddWithValue("@c3", dateTime.EditValue);
        //    komut.Parameters.AddWithValue("@c4", Giris.kullaniciID);
        //    komut.ExecuteNonQuery();
        //    bgl.baglanti().Close();
        //}

        //  int raporID;
        public static string akredite, analizsayisi, id, o2;

        //public void proje()
        //{
        //    SqlCommand komut = new SqlCommand("Select Firma_Adi from Firma where Tur= N'Proje' and Durum = N'Aktif' order by Firma_Adi", bgl.baglanti());
        //    SqlDataReader dr = komut.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        comboBoxEdit1.Properties.Items.Add(dr[0]);
        //    }
        //    bgl.baglanti().Close();
        //}


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //Proje fp = new Proje();
            //fp.ShowDialog();
        }

        //int projeID;
        //private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    SqlCommand komut = new SqlCommand("Select ID from Firma where Firma_Adi = N'" + comboBoxEdit1.Text + "'", bgl.baglanti());
        //    SqlDataReader dr = komut.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        projeID = Convert.ToInt32(dr["ID"].ToString());
        //    }
        //    bgl.baglanti().Close();
        //}

        int contRap, oo2;

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
            for (int j = 0; j < gridView2.SelectedRowsCount; j++)
            {
                id = gridView2.GetSelectedRows()[j].ToString();
                int y = Convert.ToInt32(id);
                kod = gridView3.GetRowCellValue(y, "Kod").ToString();
                analiz = gridView3.GetRowCellValue(y, "Analiz Adı").ToString();
                metod = gridView3.GetRowCellValue(y, "Metot").ToString();

                e.Graphics.DrawString(b + ". " + kod + " " + analiz + " / " + metod, analizler, kalem, 20, a);
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


        //public static string name;

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {

        }
        //int yetkiliID, denetciID;
        //private void combo_yetkili_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    SqlCommand komut12 = new SqlCommand("Select ID From Yetkili where Yetkili = N'" + combo_yetkili.Text + "' and Firma_ID = N'" + firmaId + "'", bgl.baglanti());
        //    SqlDataReader dr12 = komut12.ExecuteReader();
        //    while (dr12.Read())
        //    {
        //        yetkiliID = Convert.ToInt32(dr12[0].ToString());
        //    }
        //    bgl.baglanti().Close();
        //}

        //void denetcibul()
        //{
        //    if (combo_bakanlik.Text == "Avrupa")
        //    {
        //        SqlCommand komut2 = new SqlCommand("select Yetkili from yetkili where Firma_ID in (select ID from Firma where Firma_Adi like '%Ticaret Bakanlığı Avrupa%')", bgl.baglanti());
        //        SqlDataReader dr2 = komut2.ExecuteReader();
        //        while (dr2.Read())
        //        {
        //            combo_denetci.Properties.Items.Add(dr2[0]);
        //        }
        //        bgl.baglanti().Close();
        //    }
        //    else if (combo_bakanlik.Text == "Anadolu")
        //    {
        //        SqlCommand komut2 = new SqlCommand("select Yetkili from yetkili where Firma_ID in (select ID from Firma where Firma_Adi like '%Ticaret Bakanlığı Anadolu%')", bgl.baglanti());
        //        SqlDataReader dr2 = komut2.ExecuteReader();
        //        while (dr2.Read())
        //        {
        //            combo_denetci.Properties.Items.Add(dr2[0]);
        //        }
        //        bgl.baglanti().Close();
        //    }
        //    else if (combo_bakanlik.Text == "Gürbulak")
        //    {
        //        SqlCommand komut2 = new SqlCommand("select Yetkili from yetkili where Firma_ID in (select ID from Firma where Firma_Adi like '%Ticaret Bakanlığı Gürbulak%')", bgl.baglanti());
        //        SqlDataReader dr2 = komut2.ExecuteReader();
        //        while (dr2.Read())
        //        {
        //            combo_denetci.Properties.Items.Add(dr2[0]);
        //        }
        //        bgl.baglanti().Close();
        //    }
        //    else
        //    {
        //        SqlCommand komut2 = new SqlCommand("select Yetkili from yetkili where Firma_ID in (select ID from Firma where Firma_Adi like '%Ticaret Bakanlığı İzmir%')", bgl.baglanti());
        //        SqlDataReader dr2 = komut2.ExecuteReader();
        //        while (dr2.Read())
        //        {
        //            combo_denetci.Properties.Items.Add(dr2[0]);
        //        }
        //        bgl.baglanti().Close();
        //    }
        //}

        //private void combo_denetci_SelectedIndexChanged(object sender, EventArgs e)
        //{


        //    if (combo_bakanlik.Text == "Avrupa")
        //    {
        //        SqlCommand komut2 = new SqlCommand("select ID from yetkili where Yetkili = N'" + combo_denetci.Text + "' and Firma_ID in (select ID from Firma where Firma_Adi like '%Ticaret Bakanlığı Avrupa%')", bgl.baglanti());
        //        SqlDataReader dr2 = komut2.ExecuteReader();
        //        while (dr2.Read())
        //        {
        //            denetciID = Convert.ToInt32(dr2[0].ToString());
        //        }
        //        bgl.baglanti().Close();
        //    }
        //    else if (combo_bakanlik.Text == "Anadolu")
        //    {
        //        SqlCommand komut2 = new SqlCommand("select ID from yetkili where Yetkili = N'" + combo_denetci.Text + "' and Firma_ID in (select ID from Firma where Firma_Adi like '%Ticaret Bakanlığı Anadolu%')", bgl.baglanti());
        //        SqlDataReader dr2 = komut2.ExecuteReader();
        //        while (dr2.Read())
        //        {
        //            denetciID = Convert.ToInt32(dr2[0].ToString());
        //        }
        //        bgl.baglanti().Close();
        //    }
        //    else if (combo_bakanlik.Text == "Gürbulak")
        //    {
        //        SqlCommand komut2 = new SqlCommand("select ID from yetkili where Yetkili = N'" + combo_denetci.Text + "' and Firma_ID in (select ID from Firma where Firma_Adi like '%Ticaret Bakanlığı Gürbulak%')", bgl.baglanti());
        //        SqlDataReader dr2 = komut2.ExecuteReader();
        //        while (dr2.Read())
        //        {
        //            denetciID = Convert.ToInt32(dr2[0].ToString());
        //        }
        //        bgl.baglanti().Close();
        //    }
        //    else
        //    {
        //        SqlCommand komut2 = new SqlCommand("select ID from yetkili where Yetkili = N'" + combo_denetci.Text + "' and Firma_ID in (select ID from Firma where Firma_Adi like '%Ticaret Bakanlığı İzmir%')", bgl.baglanti());
        //        SqlDataReader dr2 = komut2.ExecuteReader();
        //        while (dr2.Read())
        //        {
        //            denetciID = Convert.ToInt32(dr2[0].ToString());
        //        }
        //        bgl.baglanti().Close();
        //    }

        //}

        //private void combo_bakanlik_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    combo_denetci.Properties.Items.Clear();
        //    combo_denetci.Text = "";
        //    denetcibul();
        //}


        //void fotokaydet()
        //{
        //    try
        //    {
        //        //string yol;
        //        //yol = pictureEdit1.GetLoadedImageLocation();
        //        //MessageBox.Show(yol + dateTime.EditValue);
        //        string isim = Path.GetFileName(name);
        //        yenisim = lbl_rapno.Text + " - " + isim;
        //        using (var client = new WebClient())
        //        {
        //            string ftpUsername = "massgrup";
        //            string ftpPassword = "Bg1$4xo2";
        //            ftpfullpath = "ftp://" + "www.massgrup.com/httpdocs/mask/Numune/Foto_2021" + "/" + yenisim;
        //            yeniyol = "http://" + "www.massgrup.com/mask/Numune/Foto_2021" + "/" + yenisim;
        //            client.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
        //            client.UploadFile(ftpfullpath, name);
        //        }

        //        //  File.Copy(name, Path.Combine(@"\\WDMyCloud\Numune\2020\Foto", yenisim), true);
        //        //  string yol = Path.Combine(@"C:\Users\X260\Desktop\Yeni Klasör", yenisim);
        //        //string yol = Path.Combine(@"\\WDMyCloud\Numune\2020\Foto", yenisim);
        //        //File.Copy(name, yol, true);

        //        SqlCommand komut = new SqlCommand("Select ID from NKR where RaporNo = N'" + lbl_rapno.Text + "' ", bgl.baglanti());
        //        SqlDataReader dr = komut.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            txt_yeniID.Text = dr[0].ToString();
        //        }
        //        bgl.baglanti().Close();


        //        SqlCommand ekle = new SqlCommand("insert into Fotograf(RaporID,Path) values(@d1,@d2)", bgl.baglanti());
        //        ekle.Parameters.AddWithValue("@d1", txt_yeniID.Text);
        //        ekle.Parameters.AddWithValue("@d2", yenisim);
        //        ekle.ExecuteNonQuery();
        //        bgl.baglanti().Close();




        //        // Fotograf db sine kaydedilir bundan sonra..

        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show("Hata 124134: " + ex);
        //    }
        //}

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            resimguncelle();
        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
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
                add2.Parameters.AddWithValue("@o1", nID);
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
                add2.Parameters.AddWithValue("@o1", nID);
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

        //string yenisim, ftpfullpath, yeniyol;

        string analizadi, metot;
        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Güncelleme işlemi başarılı!");

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
