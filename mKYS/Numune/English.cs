using DevExpress.XtraReports.UI;
using mKYS.Raporlar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mKYS.Numune
{
    public partial class English : Form
    {
        public English()
        {
            InitializeComponent();
        }

        public static string numune, miktar, raporNo, tur, name;

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();

            if (tur == "1")
            {
                frmPrint.name = name;
                //mKYS.Raporlar.Kozmetik.RaporKozmetik.raporID = nkrno;
                //mKYS.Raporlar.Kozmetik.RaporKozmetik3.raporID = nkrno;
                //using (Raporlar.frmPrint frm = new Raporlar.frmPrint())
                //{
                //    frm.ChallengeRapor();
                //    frm.ShowDialog();
                //}

                Raporlar.English.Cosmetic.ReportCosmetic.numune = txtad.Text;
                Raporlar.English.Cosmetic.ReportCosmetic.raporID = raporNo;
                Raporlar.English.Cosmetic.ReportCosmetic2.raporID = raporNo;
                Raporlar.English.Cosmetic.ReportCosmetic report1 = new Raporlar.English.Cosmetic.ReportCosmetic();
                report1.bilgi();
                report1.CreateDocument();
                Raporlar.English.Cosmetic.ReportCosmetic2 report2 = new Raporlar.English.Cosmetic.ReportCosmetic2();
                report2.bilgi();
                report2.CreateDocument();
                report1.Pages.AddRange(report2.Pages);
                report1.PrintingSystem.ContinuousPageNumbering = true;
                report1.ShowPreviewDialog();
            }
            else if (tur == "2")
            {
                frmPrint.name = name;
                Raporlar.English.Cosmetic.ReportCosmetic.numune = txtad.Text;
                Raporlar.English.Cosmetic.ReportCosmetic.raporID = raporNo;
                Raporlar.English.Cosmetic.ReportCosmetic3.raporID = raporNo;
                Raporlar.English.Cosmetic.ReportCosmetic report1 = new Raporlar.English.Cosmetic.ReportCosmetic();
                report1.bilgi();
                report1.CreateDocument();
                Raporlar.English.Cosmetic.ReportCosmetic3 report2 = new Raporlar.English.Cosmetic.ReportCosmetic3();
                report2.bilgi();
                report2.CreateDocument();
                report1.Pages.AddRange(report2.Pages);
                report1.PrintingSystem.ContinuousPageNumbering = true;
                report1.ShowPreviewDialog();
            }


        }

        private void English_Load(object sender, EventArgs e)
        {
            txtad.Text = numune;
        }
    }
}
