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
using DevExpress.Utils;

namespace mKYS.Numune
{
    public partial class NumuneDurum : Form
    {
        public NumuneDurum()
        {
            InitializeComponent();
        }
        sqlbaglanti bgl = new sqlbaglanti();

        public void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select d.RaporNo, nk.Numune_Adi ,d.Tarih, d.Durum, k.Ad as 'Kim' from NumuneTeslim d 
            left join NKR nk on d.RaporNo = nk.RaporNo 
            left join Kullanici k on d.Kim = k.ID 
            order by d.RaporNo desc, d.Tarih desc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        public void listele2()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(@"select d.RaporNo, nk.Numune_Adi ,d.Tarih, d.Durum, k.Ad as 'Kim' from NumuneTeslim d 
            left join NKR nk on d.RaporNo = nk.RaporNo 
            left join StokKullanici k on d.Kim = k.ID 
            where d.RaporNo = '" + gelis+"' order by d.RaporNo desc, d.Tarih desc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

            gridView1.Columns[2].DisplayFormat.FormatType = FormatType.DateTime;
            gridView1.Columns[2].DisplayFormat.FormatString = "dd-MM-yyyy HH:mm";


        }

        public static string gelis;
        private void NumuneDurum_Load(object sender, EventArgs e)
        {
            if (gelis == "" || gelis == null)
                listele();
            else
                listele2();
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "RaporNo" || e.Column.FieldName == "Tarih" || e.Column.FieldName == "Durum" || e.Column.FieldName == "Kimde" || e.Column.FieldName == "Bekleyen")
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

        }

        private void NumuneDurum_FormClosing(object sender, FormClosingEventArgs e)
        {
            gelis = "";
        }
    }
}
