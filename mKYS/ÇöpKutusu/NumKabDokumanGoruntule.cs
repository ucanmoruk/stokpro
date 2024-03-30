using System;
using System.IO;
using System.Windows.Forms;

namespace mKYS.Numune
{
    public partial class NumKabDokumanGoruntule : Form
    {
        public string yol = "";
        string path;

        public NumKabDokumanGoruntule()
        {
            InitializeComponent();
        }

        private void NumKabDokumanGoruntule_Shown(object sender, EventArgs e)
        {
            //path = Path.Combine(Anasayfa.kpath, yol);
            //axAcroPDF1.LoadFile(path);
        }
    }
}
