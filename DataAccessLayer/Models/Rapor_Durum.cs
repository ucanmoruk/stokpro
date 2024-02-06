using System;

namespace DataAccessLayer.Models
{
    public class Rapor_Durum
    {
        public int ID { get; set; }

        public int RaporNo { get; set; }

        public int RaporID { get; set; }

        public string Durum { get; set; }

        public DateTime Tarih { get; set; }

        public int TanimlayanID { get; set; }

    }
}
