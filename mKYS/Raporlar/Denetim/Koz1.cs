using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using mKYS;
using System.Data.SqlClient;

namespace mKYS.Raporlar.Denetim
{
    public partial class Koz1 : DevExpress.XtraReports.UI.XtraReport
    {
        public Koz1()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();


        public static string raporID;
        public void bilgi()
        {
            pRaporID.Value = raporID;

        }
    }
}
