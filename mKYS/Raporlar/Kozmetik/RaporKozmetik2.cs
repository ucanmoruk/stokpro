﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using mKYS;
using System.Data.SqlClient;

namespace mKYS.Raporlar.Kozmetik
{
    public partial class RaporKozmetik2 : DevExpress.XtraReports.UI.XtraReport
    {
        public RaporKozmetik2()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public static string raporID;

        public void bilgi()
        {
            pRaporID.Value = raporID;

        }

        private void groupHeaderBand1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
          //  int rowCount = (int)GetCurrentColumnValue("hadibe");
        }
    }
}
