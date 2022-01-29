using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmlakOfis.Models
{
    public class İlanEkle
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public int Metrekare { get; set; }
        public int Yas { get; set; }
        public int Katsayi { get; set; }
        public int OdaSayi { get; set; }
        public int SalonSayi { get; set; }
        public string Acıklama { get; set; }
        public DateTime Tarih { get; set; }
        public string Mahalle { get; set; }
        public int Fiyat { get; set; }
        public string SehirAd { get; set; }
        public string Durum { get; set; }

        public int KategoriId { get; set; }
        public int EmlakciId { get; set; }
        public int SehirId { get; set; }


        public Kategori _Kategori { get; set; }
        public Emlakci _Emlakci { get; set; }
        public Sehir _Sehir { get; set; }
    }
}
