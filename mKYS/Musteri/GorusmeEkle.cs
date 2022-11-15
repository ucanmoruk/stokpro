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

namespace mKYS.Musteri
{
    public partial class GorusmeEkle : Form
    {
        public GorusmeEkle()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select ID, Firma_Adi as 'Firma' From Firma where Durum= N'Aktif'", bgl.baglanti());
            da2.Fill(dt2);
            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "Firma";
            gridLookUpEdit1.Properties.ValueMember = "ID";
        }

        void detaybul()
        {
            SqlCommand komut2 = new SqlCommand("Select * from CrmMusteri where ID = N'" + gID + "' ", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                txt_yetkili.Text = dr2["Yetkili"].ToString();
                txt_iletisim.Text = dr2["Iletisim"].ToString();
                txt_konu.Text = dr2["Konu"].ToString();
                txt_msj.Text = dr2["Mesaj"].ToString();
                combo_tur.Text = dr2["Tur"].ToString();
                dateEdit1.EditValue = Convert.ToDateTime(dr2["Tarih"].ToString());
                gridLookUpEdit1.EditValue = dr2["FirmaID"].ToString(); 

            }
            bgl.baglanti().Close();
        }

        void temizle()
        {
            gridLookUpEdit1.EditValue = null;
            txt_iletisim.Text = null;
            txt_konu.Text = null;
            txt_msj.Text = null;
            txt_yetkili.Text = null;
            combo_tur.Text = null;
        }

        GorusmeList m = (GorusmeList)System.Windows.Forms.Application.OpenForms["GorusmeList"];

        public static string gID;
        private void GorusmeEkle_Load(object sender, EventArgs e)
        {
            listele();
            DateTime tarih = DateTime.Now;
            dateEdit1.EditValue = tarih;

            if (gID != null)
            {
                detaybul();
                btn_save.Text = "Güncelle";
            }
            else
            {
                btn_save.Text = "Kaydet";
            }

        }

        void guncelle()
        {
            SqlCommand add = new SqlCommand("update CrmMusteri set FirmaID=@a2, Yetkili=@a3, Iletisim=@a4, Tarih=@a5, Tur=@a6, Konu=@a7, Mesaj=@a8 where ID = '" + gID+"'", bgl.baglanti());
            add.Parameters.AddWithValue("@a2", gridLookUpEdit1.EditValue);
            add.Parameters.AddWithValue("@a3", txt_yetkili.Text);
            add.Parameters.AddWithValue("@a4", txt_iletisim.Text);
            add.Parameters.AddWithValue("@a5", dateEdit1.EditValue);
            add.Parameters.AddWithValue("@a6", combo_tur.Text);
            add.Parameters.AddWithValue("@a7", txt_konu.Text);
            add.Parameters.AddWithValue("@a8", txt_msj.Text);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        void kaydet()
        {
            SqlCommand add = new SqlCommand("insert into CrmMusteri (PlasiyerID, FirmaID, Yetkili, Iletisim, Tarih, Tur, Konu, Mesaj, Durum) values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9)", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", Anasayfa.kullanici);
            add.Parameters.AddWithValue("@a2", gridLookUpEdit1.EditValue);
            add.Parameters.AddWithValue("@a3", txt_yetkili.Text);
            add.Parameters.AddWithValue("@a4", txt_iletisim.Text);
            add.Parameters.AddWithValue("@a5", dateEdit1.EditValue);
            add.Parameters.AddWithValue("@a6", combo_tur.Text);
            add.Parameters.AddWithValue("@a7", txt_konu.Text);
            add.Parameters.AddWithValue("@a8", txt_msj.Text);
            add.Parameters.AddWithValue("@a9", "Aktif");
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //txt_yetkili.Text = null;
            //txt_iletisim.Text = null;

            //SqlCommand komutID = new SqlCommand("Select * From Firma where ID = N'" + gridLookUpEdit1.EditValue + "'", bgl.baglanti());
            //SqlDataReader drI = komutID.ExecuteReader();
            //while (drI.Read())
            //{
            //    txt_iletisim.Text = drI["Birim"].ToString();
            //    txt_yetkili.Text = drI["Mail"].ToString();
            //}
            //bgl.baglanti().Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (btn_save.Text == "Güncelle")
            {
                guncelle();
                MessageBox.Show("Güncelleme başarılı!", "Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                kaydet();
                temizle();
                MessageBox.Show("Kaydetme başarılı!", "Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (Application.OpenForms["GorusmeList"] == null)
            {

            }
            else
            {
                m.listele();
            }


        }

        private void GorusmeEkle_FormClosing(object sender, FormClosingEventArgs e)
        {
            gID = null;
        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }
    }
}
