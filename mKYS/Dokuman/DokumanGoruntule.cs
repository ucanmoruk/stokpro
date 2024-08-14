using System;
using System.IO;
using System.Windows.Forms;

namespace mKYS.Dokuman
{
    public partial class DokumanGoruntule : Form
    {
        sqlbaglanti bgl = new sqlbaglanti();

        public static string yol, ad, path, yol2, dkd;

        public DokumanGoruntule()
        {
            InitializeComponent();
        }

        private void DokumanGoruntule_FormClosing(object sender, FormClosingEventArgs e)
        {
            yol = "";
            Text = "";
        }

        private void DokumanGoruntule_Load(object sender, EventArgs e)
        {
            try
            {
                    if(Text == "" || Text == null)
            {
            }
            else
            {
                Text = ad;
            }
                if (dkd == "yes")
                {
                    path = Path.Combine(@"\\DESKTOP-UCOU692\Dokuman" , yol);
                    axAcroPDF1.LoadFile(path);
                }
                else
                {
                    path = Path.Combine("\\\\DESKTOP-UCOU692\\Dokuman" + "\\", yol);
                    axAcroPDF1.LoadFile(path);
                }
                //path = Path.Combine(Anasayfa.kpath, yol);
                    //  File.Copy(name, Path.Combine(@"\\WDMyCloud\KYS_Uygulama\Belgelerim\Sertifikalar", path), true);

                    // yol2 = @"U:/Drive'ım/Ortak Drive/Dokuman";
                    // path = "http://" + "www.rootarge.com/cosmo/Raporlar" + "/" + yol;
                    // path = @"C:\\Users\\asp\\Desktop\\kayit\\2018 Stok Kampanya.pdf";
                    //path = Path.Combine("https://" + "www.rootarge.com/cosmo/Raporlar" + "/", yol);

                    
                   // yol = "open.pdf";
                   // path = Path.Combine(@"\\OGUZHAN\Users\X260\Desktop\Faturalar", yol);
                //    MessageBox.Show(path);
                     
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata! " + ex);
            }


          
            

          
        }
    }
}
