using DevExpress.XtraReports.UI;

namespace mKYS.Raporlar
{
    public partial class frmPrint : DevExpress.XtraEditors.XtraForm
    {
        sqlbaglanti bgl = new sqlbaglanti();

        public frmPrint()
        {
            InitializeComponent();
        } 

        public void PrintInvoice()
        {
            Raporlar.DokumanMaster rapor = new Raporlar.DokumanMaster();       
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                documentViewer1.DocumentSource = rapor;
                rapor.CreateDocument();
            }                
        }

        public void Hamveri()
        {
            Hamveri hamveri = new Hamveri();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in hamveri.Parameters)
            {
                p.Visible = false;
                hamveri.bilgi();
                documentViewer1.DocumentSource = hamveri;
                hamveri.CreateDocument();
            }
        }

        public void KimyasalEtiket()
        {
            Raporlar.KimyasalEtiket etiket = new Raporlar.KimyasalEtiket();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in etiket.Parameters)
            {
                p.Visible = false;
                etiket.bilgi();
                documentViewer1.DocumentSource = etiket;
                etiket.CreateDocument();
            }
        }

        public void NKREtiket()
        {
            Raporlar.NKREtiket etiket = new Raporlar.NKREtiket();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in etiket.Parameters)
            {
                p.Visible = false;
                etiket.bilgi();
                documentViewer1.DocumentSource = etiket;
                etiket.CreateDocument();
            }
        }

        public void CihazEtiket()
        {
            Raporlar.CihazEtiket etiket = new Raporlar.CihazEtiket();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in etiket.Parameters)
            {
                p.Visible = false;
                etiket.bilgi();
                documentViewer1.DocumentSource = etiket;
                etiket.CreateDocument();
            }
        }

        public void CihazListesi()
        {
            Raporlar.DokumanCihaz etiket = new Raporlar.DokumanCihaz();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in etiket.Parameters)
            {
                p.Visible = false;
                etiket.bilgi();
                documentViewer1.DocumentSource = etiket;
                etiket.CreateDocument();
            }
        }

        public void DKD()
        {
            Raporlar.DokumanDKD etiket = new Raporlar.DokumanDKD();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in etiket.Parameters)
            {
                p.Visible = false;
                etiket.bilgi();
                documentViewer1.DocumentSource = etiket;
                etiket.CreateDocument();
            }
        }

        public void StokListesi()
        {
           Raporlar.DokumanStok etiket = new Raporlar.DokumanStok();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in etiket.Parameters)
            {
                p.Visible = false;
                etiket.bilgi();
                documentViewer1.DocumentSource = etiket;
                etiket.CreateDocument();
            }
        }

        public void Tedarikci()
        {
            Raporlar.Tedarikci etiket = new Raporlar.Tedarikci();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in etiket.Parameters)
            {
                p.Visible = false;
                etiket.bilgi();
                documentViewer1.DocumentSource = etiket;
                etiket.CreateDocument();
            }
        }

        public void PersonelListesi()
        {
            Raporlar.DokumanPersonel etiket = new Raporlar.DokumanPersonel();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in etiket.Parameters)
            {
                p.Visible = false;
                etiket.bilgi();
                documentViewer1.DocumentSource = etiket;
                etiket.CreateDocument();
            }
        }

        public void AnalizListesi()
        {
            Raporlar.DokumanAnaliz etiket = new Raporlar.DokumanAnaliz();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in etiket.Parameters)
            {
                p.Visible = false;
                etiket.bilgi();
                documentViewer1.DocumentSource = etiket;
                etiket.CreateDocument();
            }
        }

        public void KozmetikRapor()
        {
            Kozmetik.RaporKozmetik rapor = new Kozmetik.RaporKozmetik();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                rapor.Name = name;
                rapor.CreateDocument();

                Kozmetik.RaporKozmetik2 rapor2 = new Kozmetik.RaporKozmetik2();
                foreach (DevExpress.XtraReports.Parameters.Parameter p2 in rapor2.Parameters)
                {
                    p2.Visible = false;
                    rapor2.bilgi();
                    rapor2.CreateDocument();
                }                
                rapor.Pages.AddRange(rapor2.Pages);
            }
            rapor.PrintingSystem.ContinuousPageNumbering = true;
            documentViewer1.DocumentSource = rapor;
        }

        public void StabiliteRapor()
        {
            Kozmetik.RaporKozmetik rapor = new Kozmetik.RaporKozmetik();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                rapor.Name = name;
                rapor.CreateDocument();

                Kozmetik.Stabilite rapor2 = new Kozmetik.Stabilite();
                foreach (DevExpress.XtraReports.Parameters.Parameter p2 in rapor2.Parameters)
                {
                    p2.Visible = false;
                    rapor2.bilgi();
                    rapor2.CreateDocument();
                }
                rapor.Pages.AddRange(rapor2.Pages);

            }
            rapor.PrintingSystem.ContinuousPageNumbering = true;
            documentViewer1.DocumentSource = rapor;

        }

        public void Stability()
        {
            English.Cosmetic.ReportCosmetic rapor = new English.Cosmetic.ReportCosmetic();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                rapor.Name = name;
                rapor.CreateDocument();

                English.Cosmetic.Stability rapor2 = new English.Cosmetic.Stability();
                foreach (DevExpress.XtraReports.Parameters.Parameter p2 in rapor2.Parameters)
                {
                    p2.Visible = false;
                    rapor2.bilgi();
                    rapor2.CreateDocument();
                }
                rapor.Pages.AddRange(rapor2.Pages);

            }
            rapor.PrintingSystem.ContinuousPageNumbering = true;
            documentViewer1.DocumentSource = rapor;

        }

        public void ChallengeRapor()
        {
            Kozmetik.RaporKozmetik rapor = new Kozmetik.RaporKozmetik();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                rapor.Name = name;
                rapor.CreateDocument();

                Kozmetik.RaporKozmetik3 rapor2 = new Kozmetik.RaporKozmetik3();
                foreach (DevExpress.XtraReports.Parameters.Parameter p2 in rapor2.Parameters)
                {
                    p2.Visible = false;
                    rapor2.bilgi();
                    rapor2.CreateDocument();
                }
                rapor.Pages.AddRange(rapor2.Pages);
            }
            rapor.PrintingSystem.ContinuousPageNumbering = true;
            documentViewer1.DocumentSource = rapor;
        }

        public void EKozmetikRapor()
        {
            English.Cosmetic.ReportCosmetic rapor = new English.Cosmetic.ReportCosmetic();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                rapor.Name = name;
                rapor.CreateDocument();

                English.Cosmetic.ReportCosmetic2 rapor2 = new English.Cosmetic.ReportCosmetic2();
                foreach (DevExpress.XtraReports.Parameters.Parameter p2 in rapor2.Parameters)
                {
                    p2.Visible = false;
                    rapor2.bilgi();
                    rapor2.CreateDocument();
                }
                rapor.Pages.AddRange(rapor2.Pages);
            }
            rapor.PrintingSystem.ContinuousPageNumbering = true;
            documentViewer1.DocumentSource = rapor;
        }

        public void EChallengeRapor()
        {
            English.Cosmetic.ReportCosmetic rapor = new English.Cosmetic.ReportCosmetic();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                rapor.Name = name;
                rapor.CreateDocument();

                English.Cosmetic.ReportCosmetic3 rapor2 = new English.Cosmetic.ReportCosmetic3();
                foreach (DevExpress.XtraReports.Parameters.Parameter p2 in rapor2.Parameters)
                {
                    p2.Visible = false;
                    rapor2.bilgi();
                    rapor2.CreateDocument();
                }
                rapor.Pages.AddRange(rapor2.Pages);
            }
            rapor.PrintingSystem.ContinuousPageNumbering = true;
            documentViewer1.DocumentSource = rapor;
        }

        public void DKozmetikRapor()
        {
            Denetim.Koz1 rapor = new Denetim.Koz1();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                rapor.Name = name;
                rapor.CreateDocument();

                Denetim.Koz2 rapor2 = new Denetim.Koz2();
                foreach (DevExpress.XtraReports.Parameters.Parameter p2 in rapor2.Parameters)
                {
                    p2.Visible = false;
                    rapor2.bilgi();
                    rapor2.CreateDocument();
                }
                rapor.Pages.AddRange(rapor2.Pages);

            }
            rapor.PrintingSystem.ContinuousPageNumbering = true;
            documentViewer1.DocumentSource = rapor;
        }

        public static string name;
        public void DChallengeRapor()
        {
            Denetim.Koz1 rapor = new Denetim.Koz1();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                rapor.Name = name;
                rapor.CreateDocument();

                Denetim.Koz3 rapor2 = new Denetim.Koz3();
                foreach (DevExpress.XtraReports.Parameters.Parameter p2 in rapor2.Parameters)
                {
                    p2.Visible = false;
                    rapor2.bilgi();
                    rapor2.CreateDocument();
                }
                rapor.Pages.AddRange(rapor2.Pages);
            }
            rapor.PrintingSystem.ContinuousPageNumbering = true;
            documentViewer1.DocumentSource = rapor;
        }

        public void ProformaGrup()
        {
            ProformaGrup hamveri = new ProformaGrup();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in hamveri.Parameters)
            {
                p.Visible = false;
                hamveri.bilgi2();
                documentViewer1.DocumentSource = hamveri;
                hamveri.CreateDocument();
            }
        }

        public void ProformaManuel()
        {
            ProformaManuel ham = new ProformaManuel();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in ham.Parameters)
            {
                p.Visible = false;
                ham.bilgi2();
                documentViewer1.DocumentSource = ham;
                ham.CreateDocument();
            }
        }

        public void ProformaYazdir()
        {
            Raporlar.ProformaFatura rapor = new Raporlar.ProformaFatura();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi2();
                documentViewer1.DocumentSource = rapor;
                rapor.CreateDocument();
            }
        }

        public void Rapor()
        {
            Rapor1 rapor = new Rapor1();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                //  documentViewer1.DocumentSource = rapor;
                rapor.CreateDocument();

                tReportx2 rapor2 = new tReportx2();
                foreach (DevExpress.XtraReports.Parameters.Parameter p2 in rapor2.Parameters)
                {
                    p2.Visible = false;
                    rapor2.bilgi();
                    //    documentViewer1.DocumentSource = rapor2;
                    rapor2.CreateDocument();
                }

                Rapor3 rapor3 = new Rapor3();
                foreach (DevExpress.XtraReports.Parameters.Parameter p3 in rapor3.Parameters)
                {
                    p3.Visible = false;
                    rapor3.bilgi();
                    //   documentViewer1.DocumentSource = rapor3;
                    rapor3.CreateDocument();
                }

                rapor.Pages.AddRange(rapor2.Pages);
                rapor.Pages.AddRange(rapor3.Pages);
            }
            rapor.PrintingSystem.ContinuousPageNumbering = true;
            documentViewer1.DocumentSource = rapor;
        }

        public void RaporYeni()
        {
            Yeni.entReport rapor = new Yeni.entReport();
            foreach (DevExpress.XtraReports.Parameters.Parameter p in rapor.Parameters)
            {
                p.Visible = false;
                rapor.bilgi();
                //  documentViewer1.DocumentSource = rapor;
                rapor.CreateDocument();

                Yeni.entReport2 rapor2 = new Yeni.entReport2();
                foreach (DevExpress.XtraReports.Parameters.Parameter p2 in rapor2.Parameters)
                {
                    p2.Visible = false;
                    rapor2.bilgi();
                    //    documentViewer1.DocumentSource = rapor2;
                    rapor2.CreateDocument();
                }

                Yeni.entReport3 rapor3 = new Yeni.entReport3();
                foreach (DevExpress.XtraReports.Parameters.Parameter p3 in rapor3.Parameters)
                {
                    p3.Visible = false;
                    rapor3.bilgi();
                    //   documentViewer1.DocumentSource = rapor3;
                    rapor3.CreateDocument();
                }

                rapor.Pages.AddRange(rapor2.Pages);
                rapor.Pages.AddRange(rapor3.Pages);
            }
            rapor.PrintingSystem.ContinuousPageNumbering = true;
            documentViewer1.DocumentSource = rapor;
        }

        public void RaporCoklu()
        {
            Rapor1 report1 = new Rapor1();
            report1.CreateDocument();
            tReportx2 report2 = new tReportx2();
            report2.CreateDocument();
            Rapor3 report3 = new Rapor3();
            report3.CreateDocument();
            report1.Pages.AddRange(report2.Pages);
            report1.Pages.AddRange(report3.Pages);
            report1.PrintingSystem.ContinuousPageNumbering = true;
            report1.ShowPreviewDialog();
        }
    
    }
}