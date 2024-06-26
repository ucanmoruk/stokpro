﻿using System;
using System.IO;
using System.Windows.Forms;

namespace mKYS.Dokuman
{
    public partial class DokumanGoruntule : Form
    {
        sqlbaglanti bgl = new sqlbaglanti();

        public static string yol, ad, path, yol2;

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
            //path = Path.Combine(Anasayfa.kpath, yol);
            
           // yol2 = @"U:/Drive'ım/Ortak Drive/Dokuman";
            // path = "http://" + "www.rootarge.com/cosmo/Raporlar" + "/" + yol;
            // path = @"C:\\Users\\asp\\Desktop\\kayit\\2018 Stok Kampanya.pdf";
            //path = Path.Combine("https://" + "www.rootarge.com/cosmo/Raporlar" + "/", yol);
            path = Path.Combine("\\\\DESKTOP-UCOU692\\Dokuman" + "\\", yol);
            //MessageBox.Show(path);
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
