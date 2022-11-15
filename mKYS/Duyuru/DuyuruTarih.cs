using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mKYS.Duyuru
{
    public partial class DuyuruTarih : Form
    {
        public DuyuruTarih()
        {
            InitializeComponent();
        }

        private void DuyuruTarih_Load(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            dateEdit1.EditValue = d;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DuyuruListe.ytarih = Convert.ToString(dateEdit1.EditValue);
            var mfrm = (DuyuruListe)Application.OpenForms["DuyuruListe"];
            if (mfrm != null)
                mfrm.Okundu();
            this.Close();
        }
    }
}
