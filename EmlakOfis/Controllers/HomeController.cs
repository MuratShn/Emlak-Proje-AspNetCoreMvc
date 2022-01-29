using EmlakOfis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EmlakOfis.Controllers
{
    public class HomeController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var veri = c.evs.Select(i => new EvViewModel()
            {
                Id = i.Id,
                Baslik = i.Baslik,
                Acıklama = i.Acıklama,
                EvDurum = i._Kategori.Durum,
                Tarih = i.Tarih,
                Katsayi = i.Katsayi,
                OdaSayi = i.OdaSayi,
                SalonSayi = i.SalonSayi,
                Yas = i.Yas,
                Metrekare = i.Metrekare,
                Fiyat = i.Fiyat

            }).OrderByDescending(s => s.Tarih).Take(10).ToList();

            return View(veri);
        }
        public IActionResult Satılık()
        {
            var veri = c.evs.Select(i => new EvViewModel()
            {
                Id = i.Id,
                Baslik = i.Baslik,
                Acıklama = i.Acıklama,
                EvDurum = i._Kategori.Durum,
                Tarih = i.Tarih,
                Katsayi = i.Katsayi,
                OdaSayi = i.OdaSayi,
                SalonSayi = i.SalonSayi,
                Yas = i.Yas,
                Metrekare = i.Metrekare,
                Fiyat = i.Fiyat

            }).Where(i => i.EvDurum == "Satılık").ToList();


            return View(veri);
        }
        public IActionResult Kiralık()
        {
            var veri = c.evs.Select(i => new EvViewModel()
            {
                Id = i.Id,
                Baslik = i.Baslik,
                Acıklama = i.Acıklama,
                EvDurum = i._Kategori.Durum,
                Tarih = i.Tarih,
                Fiyat = i.Fiyat

            }).Where(i => i.EvDurum == "Kiralık").ToList();

            return View(veri);
        }
        public IActionResult Tümİlanlar(string sırala, string kolon)
        {
            //Ameleus
            if (sırala == "desc")
            {
                sırala = "asc";
                if (kolon == "Tarih")
                {
                    var veri = c.evs.Select(i => new EvViewModel()
                    {
                        Id = i.Id,
                        EvDurum = i._Kategori.Durum,
                        Baslik = i.Baslik,
                        Metrekare = i.Metrekare,
                        OdaSayi = i.OdaSayi,
                        SalonSayi = i.SalonSayi,
                        Tarih = i.Tarih,
                        Sehir = i._Sehir.SehirAd,
                        Fiyat = i.Fiyat,
                        Sırala = sırala


                    }).OrderByDescending(j => j.Tarih).ToList();

                    return View(veri);
                }
                else if (kolon == "Fiyat")
                {
                    var veri = c.evs.Select(i => new EvViewModel()
                    {
                        Id = i.Id,
                        EvDurum = i._Kategori.Durum,
                        Baslik = i.Baslik,
                        Metrekare = i.Metrekare,
                        OdaSayi = i.OdaSayi,
                        SalonSayi = i.SalonSayi,
                        Tarih = i.Tarih,
                        Sehir = i._Sehir.SehirAd,
                        Fiyat = i.Fiyat,
                        Sırala = sırala


                    }).OrderByDescending(j => j.Fiyat).ToList();

                    return View(veri);
                }

                else if (kolon == "Durum")
                {
                    var veri = c.evs.Select(i => new EvViewModel()
                    {
                        Id = i.Id,
                        EvDurum = i._Kategori.Durum,
                        Baslik = i.Baslik,
                        Metrekare = i.Metrekare,
                        OdaSayi = i.OdaSayi,
                        SalonSayi = i.SalonSayi,
                        Tarih = i.Tarih,
                        Sehir = i._Sehir.SehirAd,
                        Fiyat = i.Fiyat,
                        Sırala = sırala


                    }).OrderByDescending(j => j.EvDurum).ToList();

                    return View(veri);
                }

                else
                {
                    var veri = c.evs.Select(i => new EvViewModel()
                    {
                        Id = i.Id,
                        EvDurum = i._Kategori.Durum,
                        Baslik = i.Baslik,
                        Metrekare = i.Metrekare,
                        OdaSayi = i.OdaSayi,
                        SalonSayi = i.SalonSayi,
                        Tarih = i.Tarih,
                        Sehir = i._Sehir.SehirAd,
                        Fiyat = i.Fiyat,
                        Sırala = sırala


                    }).ToList();
                    return View(veri);

                }
            }


            else
            {
                sırala = "desc";
                if (kolon == "Tarih")
                {
                    var veri = c.evs.Select(i => new EvViewModel()
                    {
                        Id = i.Id,
                        EvDurum = i._Kategori.Durum,
                        Baslik = i.Baslik,
                        Metrekare = i.Metrekare,
                        OdaSayi = i.OdaSayi,
                        SalonSayi = i.SalonSayi,
                        Tarih = i.Tarih,
                        Sehir = i._Sehir.SehirAd,
                        Fiyat = i.Fiyat,
                        Sırala = sırala


                    }).OrderBy(j => j.Tarih).ToList();

                    return View(veri);
                }
                else if (kolon == "Fiyat")
                {
                    var veri = c.evs.Select(i => new EvViewModel()
                    {
                        Id = i.Id,
                        EvDurum = i._Kategori.Durum,
                        Baslik = i.Baslik,
                        Metrekare = i.Metrekare,
                        OdaSayi = i.OdaSayi,
                        SalonSayi = i.SalonSayi,
                        Tarih = i.Tarih,
                        Sehir = i._Sehir.SehirAd,
                        Fiyat = i.Fiyat,
                        Sırala = sırala


                    }).OrderBy(j => j.Fiyat).ToList();

                    return View(veri);
                }

                else if (kolon == "Durum")
                {
                    var veri = c.evs.Select(i => new EvViewModel()
                    {
                        Id = i.Id,
                        EvDurum = i._Kategori.Durum,
                        Baslik = i.Baslik,
                        Metrekare = i.Metrekare,
                        OdaSayi = i.OdaSayi,
                        SalonSayi = i.SalonSayi,
                        Tarih = i.Tarih,
                        Sehir = i._Sehir.SehirAd,
                        Fiyat = i.Fiyat,
                        Sırala = sırala


                    }).OrderBy(j => j.EvDurum).ToList();

                    return View(veri);
                }
                else
                {
                    var veri = c.evs.Select(i => new EvViewModel()
                    {
                        Id = i.Id,
                        EvDurum = i._Kategori.Durum,
                        Baslik = i.Baslik,
                        Metrekare = i.Metrekare,
                        OdaSayi = i.OdaSayi,
                        SalonSayi = i.SalonSayi,
                        Tarih = i.Tarih,
                        Sehir = i._Sehir.SehirAd,
                        Fiyat = i.Fiyat,
                        Sırala = sırala


                    }).ToList();
                    return View(veri);
                }
            }

        }
        [HttpPost]
        public IActionResult Tümİlanlar(string arama)
        {
            if (!String.IsNullOrEmpty(arama))
            {
                var veri = c.evs.Select(i => new EvViewModel()
                {
                    Id = i.Id,
                    Baslik = i.Baslik,
                    Acıklama = i.Acıklama,
                    EvDurum = i._Kategori.Durum,
                    Tarih = i.Tarih,
                    Fiyat = i.Fiyat

                }).Where(i => i.Baslik.Contains(arama)).ToList();
                if (veri.Count > 0)
                {
                    return View(veri);
                }
                else
                {
                    return RedirectToAction("Tümİlanlar");
                }


            }
            else
            {
                return RedirectToAction("Tümİlanlar");
            }
        }



        public IActionResult Detay(int Id)
        {

            var veri = c.evs.Select(i => new EvDetayModel()
            {
                Id = i.Id,
                Baslik = i.Baslik,
                Acıklama = i.Acıklama,
                EvDurum = i._Kategori.Durum,
                Sehir=i._Sehir.SehirAd,
                OdaSayi=i.OdaSayi,
                Metrekare=i.Metrekare,
                Yas=i.Yas,
                Katsayi=i.Katsayi,
                SalonSayi=i.SalonSayi,
                Tarih = i.Tarih,
                Fiyat = i.Fiyat,

                Ad=i._Emlakci.Ad,
                Soyad=i._Emlakci.Soyad,
                Telefon=i._Emlakci.Telefon

            }).Where(i => i.Id == Id).ToList();

            return View(veri);
        }
        public IActionResult deneme()
        {
            return View();
        }
    }
}
