﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmlakOfis.Models
{
    public class EvViewModel
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Acıklama { get; set; }
        public DateTime Tarih { get; set; }
        public string EvDurum { get; set; }
        public int OdaSayi { get; set; }
        public int SalonSayi { get; set; }
        public int Yas { get; set; }
        public int Katsayi { get; set; }
        public int Metrekare { get; set; }
        public string Sehir { get; set; }
        public int Fiyat { get; set; }
        public string Sırala { get; set; }

    }
}
