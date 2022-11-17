using mKYS.Cihaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mKYS.Stok
{
    public partial class SKTGuncelle : Form
    {
        public SKTGuncelle()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public static string kod, ID;
        public static DateTime tarih;
        private void SKTGuncelle_Load(object sender, EventArgs e)
        {
            Text = kod + " kodlu stok";
            dateEdit1.EditValue = tarih;
        }

        SonKullanim m = (SonKullanim)System.Windows.Forms.Application.OpenForms["SonKullanim"];
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand add2 = new SqlCommand("update StokHareket set SKT= @a1 where ID = '" + ID + "'", bgl.baglanti());
            add2.Parameters.AddWithValue("@a1", dateEdit1.EditValue);
            add2.ExecuteNonQuery();
            bgl.baglanti().Close();

            MessageBox.Show("Başarılı!");

            if (Application.OpenForms["SonKullanim"] == null)
            {

            }
            else
            {
                m.listele();
            }
        }
    }
}
