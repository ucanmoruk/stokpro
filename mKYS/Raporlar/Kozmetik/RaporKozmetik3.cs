using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using mKYS;
using System.Data.SqlClient;

namespace mKYS.Raporlar.Kozmetik
{
    public partial class RaporKozmetik3 : DevExpress.XtraReports.UI.XtraReport
    {
        public RaporKozmetik3()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public static string raporID, revno;

        public void bilgi()
        {
            pRaporID.Value = raporID;

            SqlCommand komut = new SqlCommand("select RevNo from NKR where RaporNo = N'" + raporID + "'", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                revno = dr["RevNo"].ToString();
            }
            bgl.baglanti().Close();

            pRevNo.Value = revno;

        }

        private void groupHeaderBand1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
          //  int rowCount = (int)GetCurrentColumnValue("hadibe");
        }
    }
}
