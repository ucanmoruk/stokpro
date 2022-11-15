using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mKYS
{
    public partial class NumuneGuncelle : Form
    {
        public NumuneGuncelle()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select a.Kod, a.AD as 'Analiz Adı', a.Method as 'Metot', a.Matriks from NumuneX1 r inner join StokAnalizListesi a on r.AnalizID = a.ID where r.RaporID = N'" + nID +"'  ", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        string durum, fotoname;

        public void fotobul()
        {
            nID = NKR.nkrID;
            SqlCommand detay2 = new SqlCommand("Select Path from Fotograf where RaporID = '" + nID + "'", bgl.baglanti());
            SqlDataReader dre = detay2.ExecuteReader();
            while (dre.Read())
            {
                fotoname = dre["Path"].ToString();
            }

            dateTermin.EditValue = Convert.ToDateTime(NKR.termin);

        }

        public void goster()
        {
            nID = NKR.nkrID;
            txtEvrak.Text = NKR.evrakNo;
            txtNumune.Text = NKR.fnumune;
            txtRapor.Text = NKR.raporNo;
            //  txtRev.Text = NKR.revizyonNo;
            txtRev.Text = NKR.nrev;
            dateTime.EditValue = Convert.ToDateTime(NKR.ftarih);
            comboFirma.Text = NKR.ffirma;
            //  combo_tur.Text = NKR.ftur;
            string tur = NKR.ntur;
            combo_tur.Text = tur;
            combo_grup.Text = NKR.fgrup;
            txt_aciklama.Text = NKR.faciklama;
           // comboBoxEdit1.Text = projeadi;

            if (NKR.nakr == "Var")
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
                combo_bakanlik.Text = NKR.alicifirma;

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
                txt_alicifirma.Text = NKR.alicifirma;
            }

            
            txtAdet.Text = NKR.fadet;
            txt_lot.Text = NKR.lot;
            txt_uretim.EditValue = NKR.üt;
            txt_skt.Text = NKR.skt;
            txt_basvuru.Text = NKR.basvuru;
            txt_model.Text = NKR.model;
            txt_marka.Text = NKR.marka;
            combo_birim.Text = NKR.fbirim;

            SqlCommand komut2 = new SqlCommand("select Yetkili from Yetkili where ID in (select YetkiliID from NumuneDetay2 where RaporID = N'" + nID + "')", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                combo_yetkili.Text = dr2[0].ToString();
            }
            bgl.baglanti().Close();

        }

        void Firma()
        {
            SqlCommand komut = new SqlCommand("Select Firma_Adi from Firma where Durum = 'Aktif'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboFirma.Properties.Items.Add(dr[0]);
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


        private void NumuneGuncelle_Load(object sender, EventArgs e)
        {
           // IDbul();
           // MessageBox.Show(nID.ToString());
            temizle();
            
            
            Firma();
            goster();
            fotobul();
            listele();
            proje();
            projebul();
          
            //  OpenFileDialog open = new OpenFileDialog();
            try
            {
                if (fotoname == null)
                {
                    string logo = @"\\WDMyCloud\Numune\2020\Foto\Logo.png";
                    pictureEdit1.Image = new Bitmap(logo);
                }
                else
                {
                    string yol = @"http://www.massgrup.com/mask/Numune/Foto_2021/" + fotoname;
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
        

        NKR n = (NKR)System.Windows.Forms.Application.OpenForms["NKR"];

        public static int nID,firmadanGelenID, aliciid;

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

        public static int projeid,odemeid;
        public static string projeadi;
        public void projebul()
        {

            SqlCommand detay = new SqlCommand("select ProjeID from NumuneDetay where RaporID = (Select ID from NKR where RaporNo = N'"+txtRapor.Text+"')", bgl.baglanti());
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

        private void btn_firmaekle_Click(object sender, EventArgs e)
        {
            //Firmalar f1 = new Firmalar();
            //f1.ShowDialog();
        }
        public static int TurID;
        string alicifirma;
        private void btn_analizekle_Click(object sender, EventArgs e)
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
                 "update Odeme set Evrak_No=@k1 where ID = N'"+odemeid+"'" +
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
                n.listele();
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


        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //Proje fp = new Proje();
            //fp.ShowDialog();
        }
        int projeID;
        string ftpfullpath, yeniyol;
        string name;
        string yenisim, isim;
        private void simpleButton3_Click(object sender, EventArgs e)
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
                        string ftpPassword = "Bg1$4xo2";
                        ftpfullpath = "ftp://"+"www.massgrup.com/httpdocs/mask/Numune/Foto_2021"+"/"+yenisim;
                        yeniyol = "http://"+"www.massgrup.com/mask/Numune/Foto_2021"+"/"+yenisim;
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

        private void combo_tur_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            //AnalizGuncelle f11 = new AnalizGuncelle();
            //f11.ShowDialog();
        }

        private void combo_grup_SelectedIndexChanged_2(object sender, EventArgs e)
        {
          //  combo_tur.Properties.Items.Clear();
          //  combo_tur.Text = "";
            SqlCommand komut = new SqlCommand("Select * from Numune_Grup where Grup = N'" + combo_grup.SelectedItem + "' order by Tur", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                combo_tur.Properties.Items.Add(dr["Tur"]);
            }
            bgl.baglanti().Close();

            if (combo_grup.Text == "Özel")
            {
                //txt_basvuru.Enabled = false;
                //txt_marka.Enabled = false;
                //txt_model.Enabled = false;
                //combo_tur.Enabled = false;
                txt_lot.Enabled = true;
                txt_skt.Enabled = true;
                txt_uretim.Enabled = true;
                labelControl5.Text = "Alıcı / Üretici Firma:";
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
                txt_model.Enabled = true;
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
                txt_model.Enabled = true;
                labelControl5.Text = "Alıcı / Üretici Firma:";
                combo_denetci.Visible = false;
                txt_alicifirma.Visible = true;
                combo_bakanlik.Visible = false;
            }
            else
            {
                txt_lot.Enabled = true;
                txt_skt.Enabled = true;
                txt_uretim.Enabled = true;
                combo_tur.Enabled = false;
                txt_basvuru.Enabled = true;
                txt_marka.Enabled = true;
                txt_model.Enabled = true;
                labelControl5.Text = "Alıcı / Üretici Firma:";
                combo_denetci.Visible = false;
                txt_alicifirma.Visible = true;
                combo_bakanlik.Visible = false;
            }

        }

     }
   
}
