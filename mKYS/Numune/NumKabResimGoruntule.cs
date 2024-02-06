using System.Drawing;
using System.IO;
using System.Net;

namespace mKYS.Numune
{
    public partial class NumKabResimGoruntule : DevExpress.XtraEditors.XtraForm
    {
        public string yol = "";
        public NumKabResimGoruntule()
        {
            InitializeComponent();
        }

        private void NumKabResimGoruntule_Load(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(yol))
            {
                string uriPath = "http://www.massgrup.com/mask/Numune/Foto_2021/" + yol;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriPath);
                try
                {
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream receiveStream = response.GetResponseStream();
                    if (receiveStream.CanRead)
                    {
                        pictureEdit1.Image = new Bitmap(receiveStream);
                    }
                }
                catch { }
            }
        }
    }
}