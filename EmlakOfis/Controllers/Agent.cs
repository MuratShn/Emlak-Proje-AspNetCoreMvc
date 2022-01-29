using EmlakOfis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmlakOfis.Controllers
{
    [Authorize]
    public class Agent : Controller
    {
        Context c = new Context();
        public IActionResult Index(int id)
        {
            var veri = c.evs.Where(s => s.EmlakciId == id).Select(
                i => new EvDetayModel()
                {
                    Id = i.Id,
                    Baslik = i.Baslik,
                    EvDurum = i._Kategori.Durum,
                    Fiyat = i.Fiyat,
                    OdaSayi = i.OdaSayi,
                    SalonSayi = i.SalonSayi,
                    Sehir = i._Sehir.SehirAd,
                    Telefon = i._Emlakci.Telefon,
                    Soyad = i._Emlakci.Soyad,
                    Metrekare = i.Metrekare,
                    Tarih = i.Tarih,
                    Katsayi = i.Katsayi,
                    Yas = i.Yas,
                    Ad = i._Emlakci.Ad
                }).ToList();


            ViewBag.Id = id;
            ViewBag.Title = c.emlakcis.Find(id).Ad;
            return View(veri);
        }
        public IActionResult İlanEkle(int Id)
        {
            List<SelectListItem> durum = (from i in c.kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.Durum,
                                              Value = i.Id.ToString()
                                          }).ToList();

            List<SelectListItem> sehir = (from i in c.sehirs.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.SehirAd,
                                              Value = i.Id.ToString()
                                          }).ToList();

            ViewBag.durum = durum;
            ViewBag.sehir = sehir;
            ViewBag.Id = Id;
            return View();
        }

        [HttpPost]
        public IActionResult İlanEkle(int Id, İlanEkle ie)
        {
            List<SelectListItem> durum = (from i in c.kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.Durum,
                                              Value = i.Id.ToString()
                                          }).ToList();

            List<SelectListItem> sehir = (from i in c.sehirs.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.SehirAd,
                                              Value = i.Id.ToString()
                                          }).ToList();

            ViewBag.durum = durum;
            ViewBag.sehir = sehir;

            if (!ModelState.IsValid)
            {
                var message = ModelState.ToList();
                return View(ie);
            }

            Ev ev = new Ev()
            {
                Acıklama = ie.Acıklama,
                Baslik = ie.Baslik,
                EmlakciId = Id,
                Fiyat = ie.Fiyat,
                Katsayi = ie.Katsayi,
                Mahalle = ie.Mahalle,
                Metrekare = ie.Metrekare,
                OdaSayi = ie.OdaSayi,
                SalonSayi = ie.SalonSayi,
                Yas = ie.Yas,
                Tarih = DateTime.Now,

                SehirId = ie._Sehir.Id,
                KategoriId = ie._Kategori.Id,

            };
            c.evs.Add(ev);
            c.SaveChanges();

            return RedirectToAction(actionName: "Index", controllerName: "Agent", new { id = Id });
        }

        public IActionResult Bilgi(int Id)
        {
            var veri = c.emlakcis.Select(i => new EmlakcıEkle()
            {
                Id = i.Id,
                Ad = i.Ad,
                KullaniciAdi = i.KullaniciAdi,
                Sifre = i.Sifre,
                Soyad = i.Soyad,
                Telefon = i.Telefon
            }).Where(s => s.Id == Id).ToList();

            ViewBag.Id = Id;
            return View(veri[0]);
        }

        [HttpPost]
        public IActionResult Bilgi(EmlakcıEkle em)
        {
            if (!ModelState.IsValid)
            {
                return View(em);
            }
            var eski = c.emlakcis.Find(em.Id);
            eski.Ad = em.Ad;
            eski.Soyad = em.Soyad;
            eski.KullaniciAdi = em.KullaniciAdi;
            eski.Sifre = em.Sifre;
            eski.Telefon = em.Telefon;
            c.SaveChanges();

            return RedirectToAction(actionName: "Index", controllerName: "Agent", new { id = em.Id });
        }

        public IActionResult Sil(int Id, int emlak)
        {
            c.evs.Remove(c.evs.Find(Id));
            c.SaveChanges();
            return RedirectToAction(actionName: "Index", controllerName: "Agent", new { id = emlak });
        }

        public IActionResult Güncelle(int Id, int emlak)
        {
            var veri2 = c.evs.Find(Id);

            var veri = c.evs.Select(i => new İlanEkle()
            {
                Baslik = i.Baslik,
                Acıklama = i.Acıklama,
                Yas = i.Yas,
                Mahalle = i.Mahalle,
                Katsayi = i.Katsayi,
                SalonSayi = i.SalonSayi,
                OdaSayi = i.OdaSayi,
                Fiyat = i.Fiyat,
                Metrekare = i.Metrekare,
                Id = i.Id,
                EmlakciId = i.EmlakciId,
                SehirAd = i._Sehir.SehirAd,
                SehirId = i._Sehir.Id,
                KategoriId = i._Kategori.Id,
                Durum = i._Kategori.Durum,
            }).Where(s => s.Id == Id && s.EmlakciId == emlak).ToList();

            List<SelectListItem> durum = (from i in c.kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.Durum,
                                              Value = i.Id.ToString()
                                          }).ToList();

            List<SelectListItem> sehir = (from i in c.sehirs.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.SehirAd,
                                              Value = i.Id.ToString()
                                          }).ToList();

            ViewBag.durum = durum;
            ViewBag.sehir = sehir;
            ViewBag.Id = emlak;
            return View(veri[0]);

        }

        [HttpPost]
        public IActionResult Güncelle(int emlak, İlanEkle em)
        {
            List<SelectListItem> durum = (from i in c.kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.Durum,
                                              Value = i.Id.ToString()
                                          }).ToList();

            List<SelectListItem> sehir = (from i in c.sehirs.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.SehirAd,
                                              Value = i.Id.ToString()
                                          }).ToList();

            ViewBag.durum = durum;
            ViewBag.sehir = sehir;

            if (!ModelState.IsValid)
            {
                return View(em);
            }
            var eski = c.evs.Find(em.Id);
            eski.Acıklama = em.Acıklama;
            eski.Baslik = em.Baslik;
            eski.Fiyat = em.Fiyat;
            eski.Mahalle = em.Mahalle;
            eski.Metrekare = em.Metrekare;
            eski.OdaSayi = em.OdaSayi;
            eski.Katsayi = em.Katsayi;
            eski.Yas = em.Yas;

            eski.SehirId = em._Sehir.Id;
            eski.KategoriId = em._Kategori.Id;
            c.SaveChanges();

            return RedirectToAction(actionName: "Index", controllerName: "Agent", new { id = emlak });
        }
    }
}
