using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using mKYS;
using System.Data.SqlClient;

namespace mKYS.Raporlar.Kozmetik
{
    public partial class RaporKozmetik : DevExpress.XtraReports.UI.XtraReport
    {
        public RaporKozmetik()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();


        public static string raporID, tNu, kod;
        public void bilgi()
        {
            xrLabel26.Text = kod;
            pRaporID.Value = raporID;
            tNo.Value = tNu;
        }
    }
}
