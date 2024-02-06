using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mKYS.Musteri;

namespace mKYS.Musteri
{
    public partial class TeklifNoSec : Form
    {
        public TeklifNoSec()
        {
            InitializeComponent();
        }

        public static int teklifno;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txt_teklifno.Text == "")
            {
                MessageBox.Show("Lütfen teklif numarasını girer misin.");
            }
            else
            {
                // YeniProforma pf = new YeniProforma();
                TeklifF.nkrevrak = evrakno;
                TeklifF.nkrfirma = firma; 
                TeklifF pf = new TeklifF();
                pf.Show();
                this.Close();
            }

        }

        private void txt_teklifno_TextChanged(object sender, EventArgs e)
        {            
            try
            {
                teklifno = Convert.ToInt32(txt_teklifno.Text.ToString());

            }
            catch (Exception ex)
            {

                MessageBox.Show("Lütfen sadece sayı giriniz!");
            }
        }

        private void txt_teklifno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44)
            // text'e sadece sayıların girmesi,geri silme tuşu(ascii kodu:08),virgül(ascii kodu:44) karakterinin girilmesini sağlar.
            //del tuşununda aktif olmasını isterseniz del ascıı kodu:127
            //
            {
                e.Handled = true;
            }

        }

        private void txt_teklifno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (txt_teklifno.Text == "")
                {
                    MessageBox.Show("Lütfen teklif numarasını girer misin.");
                }
                else
                {
                    TeklifF.nkrevrak = evrakno;
                    TeklifF.nkrfirma = firma;
                    TeklifF pf = new TeklifF();
                    pf.Show();
                    this.Close();
                }
            }
        }

        public static string evrakno, firma;
        private void TeklifNoSec_Load(object sender, EventArgs e)
        {

        }
    }
}
