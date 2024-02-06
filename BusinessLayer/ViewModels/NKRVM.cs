using System;

namespace BusinessLayer.ViewModels
{
    public class NKRVM
    {
        public int ID { get; set; }

        public int Firma_ID { get; set; }

        public int Evrak_No { get; set; }

        public string Numune_Adi { get; set; }

        public int Adet { get; set; }

        public DateTime Tarih { get; set; }

        public string Tur { get; set; }

        public string Grup { get; set; }

        public string Analiz { get; set; }

        public string Rapor_Durumu { get; set; }

        public string Aciklama { get; set; }

        public int RaporNo { get; set; }

        public string Akreditasyon { get; set; }

        public int Revno { get; set; }

        public string Servis { get; set; }

        public string Durum { get; set; }

    }
}
