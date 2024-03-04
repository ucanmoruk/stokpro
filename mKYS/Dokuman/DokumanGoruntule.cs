using System;
using System.IO;
using System.Windows.Forms;

namespace mKYS.Dokuman
{
    public partial class DokumanGoruntule : Form
    {
        sqlbaglanti bgl = new sqlbaglanti();

        public static string yol, ad, path;

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
            path = Path.Combine(Anasayfa.kpath, yol);
            axAcroPDF1.LoadFile(path);

            if(Text == "" || Text == null)
            {
            }
            else
            {
                Text = ad;
            }
               
        }
    }
}
