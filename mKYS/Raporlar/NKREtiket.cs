using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace mKYS.Raporlar
{
    public partial class NKREtiket : DevExpress.XtraReports.UI.XtraReport
    {
        public NKREtiket()
        {
            InitializeComponent();
        }

        public static string nID;
        public void bilgi()
        {
            pID.Value = nID;
        }
    }
}
