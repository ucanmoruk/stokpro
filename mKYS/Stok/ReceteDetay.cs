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

namespace mKYS.Stok
{
    public partial class ReceteDetay : Form
    {
        public ReceteDetay()
        {
            InitializeComponent();
        }


        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt2 = new DataTable();
         //   SqlDataAdapter da2 = new SqlDataAdapter("select r.StokKod as 'Kod', l.Ad, l.Miktar, l.Birim, l.Limit as 'Kritik Limit' from StokRecete r inner join StokListesi l on r.StokKod = l.Kod where r.AnalizKod = N'"+skod+"' order by r.StokKod", bgl.baglanti());
         //   SqlDataAdapter da2 = new SqlDataAdapter("select Kod, Ad, Miktar, Birim, Limit as 'Kritik Limit' from StokListesi where ID in (select StokID from StokRecete where AnalizID = '" + aID + "')", bgl.baglanti());
            SqlDataAdapter da2 = new SqlDataAdapter("select l.Kod, l.Ad, l.Miktar as 'Stok Miktarı', r.Miktar as 'Kullanılan Miktar', l.Birim, l.Limit as 'Kritik Limit' " +
                " from StokListesi l left join StokRecete r on l.ID = r.StokID where r.AnalizID = '" + aID + "' order by l.Kod", bgl.baglanti());
            da2.Fill(dt2);
            gridControl1.DataSource = dt2;

            SqlCommand komut2 = new SqlCommand("Select * from StokAnalizListesi where ID = N'" + aID + "' ", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                skod = dr2["Kod"].ToString();
                sad = dr2["Ad"].ToString();
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
                yetki = Convert.ToInt32(dr21["Analiz"]);
            }
            bgl.baglanti().Close();

            if (yetki == 0 || yetki.ToString() == null)
            {
                panelControl2.Visible = false;
                Size = new Size(480, 371);
            }
            else
            {
                panelControl2.Visible = true;
            }

        }

        public static string aID, skod,sad;
        private void ReceteDetay_Load(object sender, EventArgs e)
        {
            yetkibul();
            listele();

            Text = skod + " - " + sad;

            this.gridView1.Columns[0].Width = 30;
            this.gridView1.Columns[4].Width = 30;
            this.gridView1.Columns[2].Width = 45;
            this.gridView1.Columns[3].Width = 45;
            this.gridView1.Columns[5].Width = 45;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            YeniRecete.gelis = "update";
            YeniRecete.aID = aID;

            var mfrm = (Anasayfa)Application.OpenForms["Anasayfa"];
            if (mfrm != null)
            mfrm.YeniRecete();

            this.Close();
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Secim = new DialogResult();

                Secim = MessageBox.Show(skod + " kodlu reçeteyi silmek istediğinizden emin misiniz ?", "Oopppss!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                if (Secim == DialogResult.Yes)
                {
                    SqlCommand komutSil = new SqlCommand("delete from StokRecete where AnalizKod = N'" + skod + "'", bgl.baglanti());
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

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "Kritik Limit" || e.Column.FieldName == "Miktar" || e.Column.FieldName == "Birim")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        }
    }
}
