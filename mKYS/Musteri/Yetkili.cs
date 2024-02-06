using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace mKYS.Musteri
{
    public partial class Yetkili : Form
    {
        sqlbaglanti bgl = new sqlbaglanti();
        int yetkilid;
        int YetkiliId;
        public int firmaID;
        public string firmaAdi;

        public Yetkili()
        {
            InitializeComponent();
        }
           
        void listele()
        {
            lbl_Firma.Text = firmaAdi;
            SqlCommand getir = new SqlCommand("Select Firma_ID from Yetkili", bgl.baglanti());
            SqlDataReader dr = getir.ExecuteReader();
            while (dr.Read())
            {
                YetkiliId = Convert.ToInt32(dr[0].ToString());
                if (YetkiliId == Convert.ToInt32(firmaID))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter("select Yetkili as 'Yetkili Ad Soyad', Gorevi as 'Görevi', Mail, Telefon from Yetkili where Firma_Id = N'" + YetkiliId + "'", bgl.baglanti());
                    da.Fill(dt);
                    gridControl1.DataSource = dt;
                }
            }
            bgl.baglanti().Close();
        }

        void temizle()
        {
            txt_gorev.Text = "";
            txt_mail.Text = "";
            txt_telefon.Text = "";
            txt_yetkili.Text = "";
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult Secim = new DialogResult();
            Secim = MessageBox.Show("Silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (Secim == DialogResult.Yes)
            {
                SqlCommand komutSil = new SqlCommand("delete from Yetkili where ID = @p1", bgl.baglanti());
                komutSil.Parameters.AddWithValue("@p1", lbl_yetkili.Text);
                komutSil.ExecuteNonQuery();
                bgl.baglanti().Close();
                temizle();
                listele();
                MessageBox.Show("Silme işlemi gerçekleşmiştir.");
            }
        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("insert into Yetkili (Yetkili,Mail,Telefon,Firma_ID,Gorevi) values (@a1,@a2,@a3,@a4,@a5)", bgl.baglanti());
                komut.Parameters.AddWithValue("@a1", txt_yetkili.Text);
                komut.Parameters.AddWithValue("@a2", txt_mail.Text);
                komut.Parameters.AddWithValue("@a3", txt_telefon.Text);
                komut.Parameters.AddWithValue("@a4", firmaID);
                komut.Parameters.AddWithValue("@a5", txt_gorev.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt işlemi başarılı.");
                temizle();
                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }           
        }

        private void Yetkili_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                var p2 = MousePosition;
                popupMenu1.ShowPopup(p2);
            }
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update Yetkili set Yetkili = @y1,Telefon = @y2, Mail= @y3,Gorevi=@y4 where ID =@y5", bgl.baglanti());
                komut.Parameters.AddWithValue("@y1", txt_yetkili.Text);
                komut.Parameters.AddWithValue("@y2", txt_telefon.Text);
                komut.Parameters.AddWithValue("@y3", txt_mail.Text);
                komut.Parameters.AddWithValue("@y4", txt_gorev.Text);
                komut.Parameters.AddWithValue("@y5", yetkilid);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Güncelleme İşlemi Başarıyla Gerçekleşmiştir!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                temizle();
                listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata : " + ex.Message);
            }          
        }
        
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //SqlCommand getir = new SqlCommand("Select ID from Yetkili where Yetkili ='" + txt_yetkili.Text + "'", bgl.baglanti());
            //SqlDataReader dr2 = getir.ExecuteReader();
            //while (dr2.Read())
            //{
            //    yetkilid = Convert.ToInt32(dr2[0]);
            //}
            //bgl.baglanti().Close();

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            // Id = dr["ID"].ToString();
            txt_yetkili.Text = dr["Yetkili Ad Soyad"].ToString();
            txt_mail.Text = dr["Mail"].ToString();
            txt_telefon.Text = dr["Telefon"].ToString();
            txt_gorev.Text = dr["Görevi"].ToString();
            SqlCommand getir = new SqlCommand("Select ID from Yetkili where Yetkili = N'" + txt_yetkili.Text + "' and Firma_ID= N'"+ firmaID +"'", bgl.baglanti());
            SqlDataReader dr2 = getir.ExecuteReader();
            while (dr2.Read())
            {
                yetkilid = Convert.ToInt32(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            listele();
        }
    }
    
}
