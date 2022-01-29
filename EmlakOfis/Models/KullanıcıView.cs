using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmlakOfis.Models
{
    public class KullanıcıView
    {
        public int Id { get; set; }
        public string İsim { get; set; }
        public string Soyisim { get; set; }
        public string Telefon { get; set; }
        public string KullanıcıAdi { get; set; }
        public int İlanSayısı { get; set; }

    }
}
