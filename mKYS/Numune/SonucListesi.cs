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

namespace mKYS.Numune
{
    public partial class SonucListesi : Form
    {
        public SonucListesi()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        void listele()
        {
           DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(@" select t.ID as 'ID', n.RaporNo as 'RaporNo', '(' + x.Kod + ') ' + x.Aciklama as 'Açıklama', 
            d.Kod + ' - ' + d.Ad + ' - ' + d.Method as 'Analiz', t.Tartim as 'Tartım', t.Birim, y.Aciklama
            , a.Sonuc, a.Birim, a.Limit, a.Degerlendirme from Numune_Tartim t
            left join NumuneX2 x on t.MixID = x.ID
            left join StokAnalizListesi d on x.AnalizID = d.ID
            left join StokKullanici k on t.PersonelID = k.ID
            left join NKR n on x.RaporID = n.ID
            left join NumuneX5 a on x.ID = a.x2ID
            left join StokAnalizDetay y on a.AltAnalizID = y.ID
            where x.RaporID = '" + raporID+"' order by x.AnalizID desc", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            gridView1.Columns["ID"].Visible = false;
            gridView1.Columns["RaporNo"].Visible = false;


          //  this.gridView1.Columns[1].Width = 50;
            this.gridView1.Columns[2].Width = 110;
            this.gridView1.Columns[3].Width = 90;
            this.gridView1.Columns[4].Width = 70;
            this.gridView1.Columns[5].Width = 70;
            this.gridView1.Columns[6].Width = 90;
            this.gridView1.Columns[7].Width = 70;
            this.gridView1.Columns[8].Width = 70;
            this.gridView1.Columns[9].Width = 90;
            this.gridView1.Columns[10].Width = 90;
        }

        public static string raporID, raporNo;
        private void SonucListesi_Load(object sender, EventArgs e)
        {
            listele();
            Text = raporNo + " Analiz Listesi";
        }
    }
}
