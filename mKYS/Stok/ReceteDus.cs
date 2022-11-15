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

namespace mKYS.Stok
{
    public partial class ReceteDus : Form
    {
        public ReceteDus()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        private void listele()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select ID, Kod, Ad From StokAnalizListesi where Durumu = 'Aktif' and ID in (select distinct AnalizID from StokRecete) order by Kod ", bgl.baglanti());
            da2.Fill(dt2);

            gridLookUpEdit1.Properties.DataSource = dt2;
            gridLookUpEdit1.Properties.DisplayMember = "Ad";
            gridLookUpEdit1.Properties.ValueMember = "ID";
        }


        private void ReceteDus_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void gridLookUpEdit1_QueryPopUp(object sender, CancelEventArgs e)
        {
            GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
            gridLookUpEdit.Properties.PopupView.Columns["ID"].Visible = false;
        }

        StokListesi m = (StokListesi)System.Windows.Forms.Application.OpenForms["StokListesi"];

        double miktar, dusus, yenistok, adet;
        string stokid, eskistok;
        void cikarma()
        {
            SqlCommand komutID = new SqlCommand("select * from StokRecete where AnalizID = '" + gridLookUpEdit1.EditValue + "' ", bgl.baglanti());
            SqlDataReader drI = komutID.ExecuteReader();
            while (drI.Read())
            {
                stokid = drI["StokID"].ToString();
               // miktar = float.Parse(drI["Miktar"].ToString());
                miktar = Convert.ToDouble(drI["Miktar"].ToString());
                adet = Convert.ToDouble(txtadet.Text);
                //  float adet = float.Parse(txtadet.Text);

                if (miktar == 0)
                {

                }
                else
                {
                    dusus = miktar * adet * -1;

                    SqlCommand add2 = new SqlCommand("insert into StokHareket (StokID, Marka,Miktar,Tarih,Hareket, BirimID, Durum) values (@a1,@a2,@a3,@a4,@a5,@a6,@a7)", bgl.baglanti());
                    add2.Parameters.AddWithValue("@a1", stokid);
                    add2.Parameters.AddWithValue("@a2", "Reçeteden toplu düşüş");
                    add2.Parameters.AddWithValue("@a3", dusus);
                    add2.Parameters.AddWithValue("@a4", dateEdit1.EditValue);
                    add2.Parameters.AddWithValue("@a5", "Çıkış");
                    add2.Parameters.AddWithValue("@a6", Anasayfa.birimID);
                    add2.Parameters.AddWithValue("@a7", "Aktif");
                    add2.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    SqlCommand komutI = new SqlCommand("select SUM(Miktar) from StokHareket where StokID = '" + stokid + "' and Durum = 'Aktif'", bgl.baglanti());
                    SqlDataReader dra = komutI.ExecuteReader();
                    while (dra.Read())
                    {
                        eskistok = dra[0].ToString();
                    }
                    bgl.baglanti().Close();

                    // yenistok = float.Parse(eskistok);
                    yenistok = Convert.ToDouble(eskistok);

                    SqlCommand add = new SqlCommand("update StokListesi set Miktar = @a1 where ID = N'" + stokid + "'", bgl.baglanti());
                    add.Parameters.AddWithValue("@a1", yenistok);
                    add.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }
               

            }
            bgl.baglanti().Close();

        }


        private void btn_ok_Click(object sender, EventArgs e)
        {
            //  gridLookUpEdit1.EditValue.ToString();
            if (dateEdit1.EditValue == null)
            {
                MessageBox.Show("Lütfen tarih seçiniz!..");
            }
            else
            {
                if (txtadet.Text == "")
                {
                    MessageBox.Show("Lütfen analiz sayısını belirtiniz!..");
                }
                else
                {
                    cikarma();
                    if (Application.OpenForms["StokListesi"] == null)
                    {

                    }
                    else
                    {
                        m.listele();
                    }

                    MessageBox.Show("Stoğunuz başarı ile güncellenmiştir!", "Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtadet.Text = "";
                }

            }
        }


        private void txtadet_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
