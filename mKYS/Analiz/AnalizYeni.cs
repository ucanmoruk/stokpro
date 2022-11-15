using DevExpress.XtraEditors;
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
    public partial class AnalizYeni : Form
    {
        public AnalizYeni()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void glistele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select ID, Birim from StokFirmaBirim where Durum= 'Aktif'", bgl.baglanti());
            da2.Fill(dt2);

            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "Birim";
            gridLookUpEdit1.Properties.ValueMember = "ID";

            DataTable dt4 = new DataTable();
            SqlDataAdapter da4 = new SqlDataAdapter("Select ID, Kod, Ad from StokDKDListe where Durum= 'Aktif'", bgl.baglanti());
            da4.Fill(dt4);

            gridLookUpEdit2.Properties.DataSource = dt4;
            gridLookUpEdit2.Properties.DisplayMember = "Kod";
            gridLookUpEdit2.Properties.ValueMember = "ID";
        }


        int akod;
        void kontrol()
        {
            if (combo_akre.Text == "" || combo_akre.Text == null)
            {
                MessageBox.Show("Lütfen akreditasyon durumunu belirtiniz!", "Ooppsss!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SqlCommand komutID = new SqlCommand("Select count(ID) From StokAnalizListesi where Kod = N'" + txt_kod.Text + "'", bgl.baglanti());
                SqlDataReader drI = komutID.ExecuteReader();
                while (drI.Read())
                {
                    akod = Convert.ToInt32(drI[0].ToString());
                }
                bgl.baglanti().Close();

                if (akod != 0)
                {
                    MessageBox.Show("Bu kod numaralı analiz daha önce kaydedilmiştir. Lütfen kontrol ediniz!", "Ooppsss!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                }
            }
        }

        void ekleme()
        {
            SqlCommand add = new SqlCommand(" insert into StokAnalizListesi (Kod, Ad, Metot, Matriks, Akreditasyon,Durumu,Birim, Method, AdEn, MethodEn, Sure, Numune, NumGereklilik, NumDipnot, NumDipnotEn) values (@a1, @a2, @a3, @a4, @a5, @a6,@a7, @a8, @a9, @a10, @a11, @a12, @a13, @a14,@a15) " +
                " SET @ID=SCOPE_IDENTITY();", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", txt_kod.Text);
            add.Parameters.AddWithValue("@a2", txt_ad.Text);
            if (String.IsNullOrEmpty(kaynak))
            {
                add.Parameters.AddWithValue("@a3", DBNull.Value);
            }
            else
            {
                add.Parameters.AddWithValue("@a3", kaynak);
            }
            add.Parameters.AddWithValue("@a4", txt_matriks.Text);
            add.Parameters.AddWithValue("@a5", combo_akre.Text);
            add.Parameters.AddWithValue("@a6", "Aktif");
            if (String.IsNullOrEmpty(birim))
            {
                add.Parameters.AddWithValue("@a7", DBNull.Value);
            }
            else
            {
                add.Parameters.AddWithValue("@a7", birim);
            }
            add.Parameters.AddWithValue("@a8", txt_method.Text);
            add.Parameters.AddWithValue("@a9", txt_aden.Text);
            add.Parameters.AddWithValue("@a10", txt_methoden.Text);
            add.Parameters.AddWithValue("@a11", Convert.ToInt32(txt_sure.Text));
            add.Parameters.AddWithValue("@a12", memoEdit1.Text);
            add.Parameters.AddWithValue("@a13", txt_gerek.Text);
            add.Parameters.AddWithValue("@a14", memoEdit2.Text);
            add.Parameters.AddWithValue("@a15", memoEdit3.Text);
            add.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            add.ExecuteNonQuery();
            string AnalizID = add.Parameters["@ID"].Value.ToString();
            bgl.baglanti().Close();

            MessageBox.Show("Yeni analiz başarıyla eklenmiştir!", "Ooppsss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            AnalizAlt.AnalizID = AnalizID;
            this.Close();
            AnalizAlt fr = new AnalizAlt();
            fr.Show();
         
            
        }

        void listele()
        {

            SqlCommand komutID = new SqlCommand("Select * From StokAnalizListesi where Kod = N'" + kod + "'", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                txt_ad.Text = drI["Ad"].ToString();
                txt_kod.Text = drI["Kod"].ToString();
                txt_matriks.Text = drI["Matriks"].ToString();               
                combo_akre.Text = drI["Akreditasyon"].ToString();
                string gbirim = drI["Birim"].ToString();
                string gmetot = drI["Metot"].ToString();
                gridLookUpEdit1.EditValue = gbirim;
                gridLookUpEdit2.EditValue = gmetot;
                txt_aden.Text = drI["AdEn"].ToString();
                txt_method.Text = drI["Method"].ToString();
                txt_methoden.Text = drI["MethodEn"].ToString();
                txt_sure.Text = drI["Sure"].ToString();
                txt_gerek.Text = drI["NumGereklilik"].ToString();
                memoEdit1.Text = drI["Numune"].ToString();
                memoEdit2.Text = drI["NumDipnot"].ToString();
                memoEdit3.Text = drI["NumDipnotEn"].ToString();
            }
            bgl.baglanti().Close();
        }

        void guncelle()
        {
            SqlCommand add = new SqlCommand(" update StokAnalizListesi set Kod=@a1, Ad=@a2, Metot=@a3, Matriks=@a4, Akreditasyon=@a5, Birim=@a6 , " +
                " Method=@a8, AdEn=@a9, MethodEn=@a10, Sure=@a11, Numune=@a12, NumGereklilik=@a13, NumDipnot = @a14, NumDipnotEn = @a15 where ID = '" + aID+"' ", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", txt_kod.Text);
            add.Parameters.AddWithValue("@a2", txt_ad.Text);
            if (String.IsNullOrEmpty(kaynak))
            {
                add.Parameters.AddWithValue("@a3", DBNull.Value);
            }
            else
            {
                add.Parameters.AddWithValue("@a3", kaynak);
            }
            add.Parameters.AddWithValue("@a4", txt_matriks.Text);
            add.Parameters.AddWithValue("@a5", combo_akre.Text);
            if (String.IsNullOrEmpty(birim))
            {
                add.Parameters.AddWithValue("@a6", DBNull.Value);
            }
            else
            {
                add.Parameters.AddWithValue("@a6", birim);
            }
            add.Parameters.AddWithValue("@a8", txt_method.Text);
            add.Parameters.AddWithValue("@a9", txt_aden.Text);
            add.Parameters.AddWithValue("@a10", txt_methoden.Text);
            add.Parameters.AddWithValue("@a11", Convert.ToInt32(txt_sure.Text));
            add.Parameters.AddWithValue("@a12", memoEdit1.Text);
            add.Parameters.AddWithValue("@a13", txt_gerek.Text);
            add.Parameters.AddWithValue("@a14", memoEdit2.Text);
            add.Parameters.AddWithValue("@a15", memoEdit3.Text);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Analiz bilgileri başarıyla güncellenmiştir!", "Ooppsss!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        public static string kod, aID;
        private void AnalizYeni_Load(object sender, EventArgs e)
        {
            if (aID == "" || aID == null)
            {                
                glistele();
            }
            else
            {
                glistele();
                listele();               
                btn_add.Text = "Güncelle";
                Text = "Analiz Bilgi Güncelle";
            }
        }

        AnalizListesi m = (AnalizListesi)System.Windows.Forms.Application.OpenForms["AnalizListesi"];

        private void btn_add_Click(object sender, EventArgs e)
        {

            if (btn_add.Text == "Güncelle")
            {
                guncelle(); 
           
            }
            else
            {
                if (txt_kod.Text == "")
                {
                    MessageBox.Show("Lütfen analiz kodu bölümünü doldurunuz!", "Oooppss!"); 
                }
                else
                {

                    if (gridLookUpEdit1.EditValue.ToString() == "")
                    {
                        MessageBox.Show("Lütfen analizin yapıldığı birimi seçiniz!", "Oooppss!");
                    }
                    else
                    {
                        kontrol();
                        ekleme();

                        txt_ad.Text = "";
                        txt_kod.Text = "";
                        txt_matriks.Text = "";
                        gridLookUpEdit1.EditValue = null;
                        gridLookUpEdit2.EditValue = null;
                        combo_akre.Text = "";
                        txt_sure.Text = "";
                        txt_aden.Text = "";
                        txt_gerek.Text = "";
                        txt_method.Text = "";
                        txt_methoden.Text = "";
                        memoEdit1.Text = "";
                        memoEdit2.Text = "";
                        memoEdit3.Text = "";

                    }

                   

                }



            }

            if (Application.OpenForms["AnalizListesi"] == null)
            {

            }
            else
            {
                m.listele();
            }
            


        }
        

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        private void gridLookUpEdit2_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
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

        string birim, kaynak;

        private void gridLookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            if (gridLookUpEdit2.EditValue == null)
                kaynak = null;
            else
                kaynak = gridLookUpEdit2.EditValue.ToString();
        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (gridLookUpEdit1.EditValue == null)
                birim = null;
            else
                birim = gridLookUpEdit1.EditValue.ToString();
        }

        private void txt_sure_KeyPress(object sender, KeyPressEventArgs e)
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

        private void AnalizYeni_FormClosing(object sender, FormClosingEventArgs e)
        {
            kod = null;
            aID = null;
        }

    }
}
