using BusinessLayer.Services;
using BusinessLayer.ViewModels;
using System;
using System.Data;
using System.Windows.Forms;
using mKYS.Musteri;
using System.Data.SqlClient;
using DevExpress.XtraEditors;

namespace mKYS.Musteri
{
    public partial class FirmaYeni : Form
    {
        public bool isUpdated = false;
        public int firmaUpdateID = 0;
        FirmaService firmaService = new FirmaService(Giris.sqlTip);
        FirmaVM firmaVMEski;
        FirmaVM firmaVMYeni;

        Firmalar f = (Firmalar)System.Windows.Forms.Application.OpenForms["Firmalar"];
        sqlbaglanti bgl = new sqlbaglanti();

        public FirmaYeni()
        {
            InitializeComponent();
        }

        void detaybul()
        {
            

            SqlCommand komutID = new SqlCommand("Select * From Firma where ID= N'" + fID + "'", bgl.baglanti());
            SqlDataReader dr = komutID.ExecuteReader();
            while (dr.Read())
            {                
                txt_firmaad.Text = dr["Firma_Adi"].ToString();
                txt_adres.Text = dr["Adres"].ToString();
                txt_telefon.Text = dr["Telefon"].ToString();
                txt_vergid.Text = dr["Vergi_Dairesi"].ToString();
                txt_vergino.Text = dr["Vergi_No"].ToString();
                txt_Mail.Text = dr["Mail"].ToString();
                txt_sektor.Text = dr["Sektor"].ToString();
                txt_not.Text = dr["Hizmet"].ToString();
                gridLookUpEdit1.EditValue = dr["PlasiyerID"].ToString();
                combo_tur.Text = dr["Tur"].ToString();
                txt_vade.Text = dr["Vade"].ToString(); ;
                combo_odeme.Text = dr["Odeme"].ToString(); ;
            }
            bgl.baglanti().Close();
        }

        public static string fID;
        private void FirmaYeni_Load(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select Ad, Soyad, ID from StokKullanici where Durum= 'Aktif'", bgl.baglanti());
            da2.Fill(dt2);

            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "Ad";
            gridLookUpEdit1.Properties.ValueMember = "ID";

            if (fID == null ||fID =="")
            {

            }
            else
            {
                detaybul();
                button_ekle.Text = "Güncelle";
            }

           
        }

        private void button_ekle_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_firmaad.Text) || string.IsNullOrWhiteSpace(txt_firmaad.Text))
            {
                MessageBox.Show("Firma Adını Boş Bırakamazsınız!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (combo_odeme.SelectedIndex < 0)
            {
                MessageBox.Show("Ödeme Türünü Boş Bırakamazsınız!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToInt32(gridLookUpEdit1.EditValue) < 0)
            {
                MessageBox.Show("Plasiyeri Boş Bırakamazsınız!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (button_ekle.Text == "Güncelle")
                {
                    guncelle();
                }
                else
                {
                    kaydet();
                }

           
            }

            if (Application.OpenForms["Firmalar"] == null)
            {

            }
            else
            {
                f.listele();
            }

        }

        string parola;
        public string parolaolustur()
        {            
            char[] cr = "0123456789abcdefghijklmnopqrstuvwxyz".ToCharArray();
            string result = string.Empty;
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                parola += cr[r.Next(0, cr.Length - 1)].ToString();
            }

            return parola;
        }

        void kaydet()
        {
            parolaolustur();

            //  SqlCommand komut = new SqlCommand("insert into Firma (Firma_Adi,Adres,Vergi_Dairesi,Vergi_No,Telefon,Plasiyer,mail) values (@f1,@f2,@f3,@f4,@f5,@f6,@f7) ; insert into Yetkili (Yetkili,Mail,Telefon,Firma_ID) values (@y1,@y2,@y3,IDENT_CURRENT('Firma'))", bgl.baglanti());
            SqlCommand komut = new SqlCommand(@"insert into Firma (Firma_Adi,Adres,Vergi_Dairesi,Vergi_No,Telefon,PlasiyerID,Mail,Durum,Sektor,Hizmet,Kod,Parola,Tur,Vade,Odeme ) 
            values (@f1,@f2,@f3,@f4,@f5,@f6,@f7,@f8,@f9,@f10,Concat('COS',IDENT_CURRENT('Firma')),@f12,@f13,@f14,@f15) ", bgl.baglanti());
            komut.Parameters.AddWithValue("@f1", txt_firmaad.Text);
            komut.Parameters.AddWithValue("@f2", txt_adres.Text);
            komut.Parameters.AddWithValue("@f3", txt_vergid.Text);
            komut.Parameters.AddWithValue("@f4", txt_vergino.Text);
            komut.Parameters.AddWithValue("@f5", txt_telefon.Text);
            komut.Parameters.AddWithValue("@f6", gridLookUpEdit1.EditValue);
            komut.Parameters.AddWithValue("@f7", txt_Mail.Text);
            komut.Parameters.AddWithValue("@f8", "Aktif");
            komut.Parameters.AddWithValue("@f9", txt_sektor.Text);
            komut.Parameters.AddWithValue("@f10", txt_not.Text);
            komut.Parameters.AddWithValue("@f12", parola);
            komut.Parameters.AddWithValue("@f13", combo_tur.Text);
            komut.Parameters.AddWithValue("@f14", combo_odeme.Text);
            komut.Parameters.AddWithValue("@f15", txt_vade.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();

            temizle();
            MessageBox.Show("Kaydetme işlemi başarılı!", "Oopppss!");

            this.Close();
        }

        void guncelle()
        {
            SqlCommand komut = new SqlCommand(@"Update Firma Set Firma_Adi = N'" + txt_firmaad.Text + "', Hizmet = N'" + txt_not.Text + "', Adres = N'" + txt_adres.Text + "', Telefon = N'" + txt_telefon.Text + "',  Mail = N'" + txt_Mail.Text + "', Vergi_Dairesi = N'" + txt_vergid.Text + "', Vergi_No = N'" + txt_vergino.Text + "', Sektor = N'" + txt_sektor.Text + "',PlasiyerID = N'" + gridLookUpEdit1.EditValue + "', " +
                "Tur= N'" + combo_tur.Text + "' , Vade = N'" + txt_vade.Text + "', Odeme = N'" + combo_odeme.Text + "' where ID = N'" + fID + "' ", bgl.baglanti());
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Güncelleme işlemi başarılı!", "Oopppss!");
        }

        public void temizle()
        {
            txt_adres.Text = "";
            txt_firmaad.Text = "";
            txt_Mail.Text = "";
            txt_telefon.Text = "";
            txt_vergino.Text = "";
            txt_vergid.Text = "";
            gridLookUpEdit1.EditValue = "";
            txt_sektor.Text = "";
            txt_not.Text = "";
            combo_odeme.Text = "";
            txt_vade.Text = "";
        }

        private void FirmaYeni_FormClosed(object sender, FormClosedEventArgs e)
        {
            fID = null;
        }

        private void gridLookUpEdit1_QueryCloseUp(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void gridLookUpEdit1_QueryPopUp(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }
    }
}
