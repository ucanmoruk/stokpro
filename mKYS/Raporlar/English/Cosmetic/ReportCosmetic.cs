using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using mKYS;
using System.Data.SqlClient;

namespace mKYS.Raporlar.English.Cosmetic
{
    public partial class ReportCosmetic : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportCosmetic()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();


        public static string raporID, numune, miktar, tNu;
        public void bilgi()
        {
            pRaporID.Value = raporID;
            pNumune.Value = numune;
            pMiktar.Value = miktar;
            tNo.Value = tNu;
        }
    }
}
