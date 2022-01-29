using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmlakOfis.Models
{
    public class Sehir
    {
        [Key]
        public int Id { get; set; }
        public string SehirAd { get; set; }
    }
}
