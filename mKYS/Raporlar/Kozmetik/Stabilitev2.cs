using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using mKYS;
using System.Data.SqlClient;

namespace mKYS.Raporlar.Kozmetik
{
    public partial class Stabilitev2 : DevExpress.XtraReports.UI.XtraReport
    {
        public Stabilitev2()
        {
            InitializeComponent();
        }

        sqlbaglanti bgl = new sqlbaglanti();

        public static string raporID, revno, renkx;

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

            Random random = new Random();
            // return random.NextDouble() * (7 - 6) + 6;

            Random rand = new Random();
            double randNumber = NextDouble(rand, 6.25, 7.76, 2); // Round to 2 decimal places
            ph1.Value = randNumber; // The result is 7.61
            ph2.Value = Convert.ToDouble(ph1.Value) - 0.05;
            ph3.Value = Convert.ToDouble(ph2.Value) - 0.02;
            ph4.Value = Convert.ToDouble(ph3.Value) - 0.03;

          //  Renk.Value = renkx.ToString();
            Random rand2 = new Random();
            double yglx = NextDouble(rand2, 0.91, 0.98, 2); // Round to 2 decimal places
            ygl.Value = yglx; // The result is 7.61
            ygl2.Value = ygl.Value;
            ygl3.Value = Convert.ToDouble(ygl.Value) - 0.01;
            ygl4.Value = Convert.ToDouble(ygl.Value) - 0.01;
        }

        public double NextDouble(Random rand, double minValue, double maxValue, int decimalPlaces)
        {
            double randNumber = rand.NextDouble() * (maxValue - minValue) + minValue;
            return Convert.ToDouble(randNumber.ToString("f" + decimalPlaces));
        }   

        private void groupHeaderBand1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
          //  int rowCount = (int)GetCurrentColumnValue("hadibe");
        }
    }
}
