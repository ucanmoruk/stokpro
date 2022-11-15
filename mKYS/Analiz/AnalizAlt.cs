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
    public partial class AnalizAlt : Form
    {
        public AnalizAlt()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter(@"select Aciklama as 'Açıklama',AciklamaEn as 'Explanation', CasNo as 'Cas No', Loq as 'LOQ', Birim as 'Birim', ID from StokAnalizDetay where AnalizID = '"+AnalizID+"' and Durum = 'Aktif'", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;

            gridView1.Columns["ID"].Visible = false;
        }

        void bul()
        {
            SqlCommand komut2 = new SqlCommand("Select * from StokAnalizListesi where ID = N'" + AnalizID + "' ", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                Text = dr2["Kod"].ToString() + ' ' + dr2["Ad"].ToString();
            }
            bgl.baglanti().Close();
        }

        public static string AnalizID;
        private void AnalizAlt_Load(object sender, EventArgs e)
        {
            listele();
            bul();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (combo_tur.Text == "" || combo_tur.Text == null)
            {
                MessageBox.Show("Lütfen tür seçimini yapımız!", "Ooppsss!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (btn_add.Text == "Güncelle")
                {
                    guncelle();
                    txt_aciklama.Text = null;
                    txt_birim.Text = null;
                    txt_cas.Text = null;
                    txt_loq.Text = null;
                    txt_en.Text = null;
                    btn_add.Text = "Ekle";
                }
                else
                {
                    ekleme();
                    txt_aciklama.Text = null;
                    txt_birim.Text = null;
                    txt_cas.Text = null;
                    txt_loq.Text = null;
                    txt_en.Text = null;
                }
                listele();

            }


           
        }

        private void combo_tur_SelectedValueChanged(object sender, EventArgs e)
        {
            if (combo_tur.Text == "Toplam" )
            {
                txt_aciklama.Enabled = false;
                txt_en.Enabled = false;
            }
            else
            {
                txt_aciklama.Enabled = true;
                txt_en.Enabled = true;
            }

        }

        private void AnalizAlt_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnalizID = null;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show("Bunu silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Secim == DialogResult.Yes)
                {
                    SqlCommand komutSil = new SqlCommand("update StokAnalizDetay set Durum=@a1 where ID= N'" + detayID + "'", bgl.baglanti());
                    komutSil.Parameters.AddWithValue("@a1", "Pasif");
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

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btn_add.Text = "Güncelle";

            SqlCommand komut2 = new SqlCommand("Select * from StokAnalizDetay where ID = N'" + detayID + "' ", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                combo_tur.Text = dr2["Tur"].ToString();
                if (combo_tur.Text == "Toplam")
                {
                    txt_aciklama.Text = null;
                    txt_aciklama.Enabled = false;
                    txt_en.Text = null;
                    txt_en.Enabled = false;
                }
                else
                {
                    txt_aciklama.Text = dr2["Aciklama"].ToString();
                    txt_en.Text = dr2["AciklamaEn"].ToString();
                }
                txt_birim.Text = dr2["Birim"].ToString();
                txt_cas.Text = dr2["CasNo"].ToString();
                txt_loq.Text = dr2["Loq"].ToString();
            }
            bgl.baglanti().Close();

        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }
        }

        void ekleme()
        {
            SqlCommand add = new SqlCommand(" insert into StokAnalizDetay (AnalizID, Aciklama, CasNo, Loq, Birim, Tur, Durum, AciklamaEn ) values (@a1, @a2, @a3, @a4, @a5, @a6,@a7, @a8) ", bgl.baglanti());
            add.Parameters.AddWithValue("@a1", AnalizID);
            if (combo_tur.Text == "Toplam")
            {
                add.Parameters.AddWithValue("@a2", "Toplam");
                add.Parameters.AddWithValue("@a8", "Total");
            }
            else
            {
                add.Parameters.AddWithValue("@a2", txt_aciklama.Text);
                add.Parameters.AddWithValue("@a8", txt_en.Text);
            }
            add.Parameters.AddWithValue("@a3", txt_cas.Text);
            add.Parameters.AddWithValue("@a4", txt_loq.Text);
            add.Parameters.AddWithValue("@a5", txt_birim.Text);
            add.Parameters.AddWithValue("@a6", combo_tur.Text);
            add.Parameters.AddWithValue("@a7", "Aktif");
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
            
        }

        void guncelle()
        {
            SqlCommand add = new SqlCommand("update StokAnalizDetay set Aciklama=@a2, CasNo=@a3, Loq=@a4, Birim=@a5, Tur=@a6, AciklamaEn=@a8 where ID = '"+detayID+"' ", bgl.baglanti());
            if (combo_tur.Text == "Toplam")
            {
                add.Parameters.AddWithValue("@a2", "Toplam");
                add.Parameters.AddWithValue("@a8", "Total");
            }              
            else
            {
                add.Parameters.AddWithValue("@a2", txt_aciklama.Text);
                add.Parameters.AddWithValue("@a8", txt_en.Text);
            }                
            add.Parameters.AddWithValue("@a3", txt_cas.Text);
            add.Parameters.AddWithValue("@a4", txt_loq.Text);
            add.Parameters.AddWithValue("@a5", txt_birim.Text);
            add.Parameters.AddWithValue("@a6", combo_tur.Text);
            add.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        string detayID;
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            detayID = dr["ID"].ToString();
        }
    }
}
