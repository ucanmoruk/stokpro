using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace mUnique.Raporlar
{
    public partial class TeklifUni : DevExpress.XtraReports.UI.XtraReport
    {
        public TeklifUni()
        {
            InitializeComponent();
        }
        public static string teklifID;

        public void bilgi()
        {
            pID.Value = teklifID;
        }

    }
}
