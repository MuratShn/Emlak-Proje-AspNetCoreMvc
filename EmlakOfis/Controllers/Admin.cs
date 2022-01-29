using EmlakOfis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmlakOfis.Controllers
{
    [Authorize]
    public class Admin : Controller
    {
        Context c = new Context();
        public IActionResult Index(string id)
        {
            AdminViewIndex admin = new AdminViewIndex();
            admin.AdminSayi = c.admins.Count();
            admin.EmlakciSayi = c.emlakcis.Count();
            admin.İlanSayi = c.evs.Count();


            return View(admin);
        }
        public IActionResult İlanlar()
        {
            var veri = c.evs.Select(i => new EvDetayModel
            {
                Id = i.Id,
                Ad = i._Emlakci.Ad,
                Soyad = i._Emlakci.Soyad,
                Telefon = i._Emlakci.Telefon,
                Fiyat = i.Fiyat,
                Tarih = i.Tarih,
                EvDurum = i._Kategori.Durum,
                Metrekare = i.Metrekare,
                OdaSayi = i.OdaSayi,
                SalonSayi = i.SalonSayi,
                Sehir = i._Sehir.SehirAd,
                Yas = i.Yas
            }).ToList();
            return View(veri);
        }
        public IActionResult İlanSil(int Id)
        {
            c.Remove(c.evs.Find(Id));
            c.SaveChanges();
            return RedirectToAction("Tümİlanlar");
        }
        public IActionResult Kullanıcılar()
        {
            var veri = c.emlakcis.Select(i => new KullanıcıView()
            {
                Id = i.Id,
                İsim = i.Ad,
                Soyisim = i.Soyad,
                Telefon = i.Telefon,
                KullanıcıAdi = i.KullaniciAdi,
                İlanSayısı = c.evs.Where(s => s.EmlakciId == i.Id).Count()

            }).ToList();
            return View(veri);
        }
    
        public IActionResult KullanıcıEkle()
        {
            return View();

        }
        [HttpPost]
        public IActionResult KullanıcıEkle(EmlakcıEkle em)
        {
            if (!ModelState.IsValid)
            {
                return View(em);
            }
            Emlakci yeni = new Emlakci()
            {
                Id = em.Id,
                Ad = em.Ad,
                Soyad = em.Soyad,
                KullaniciAdi = 123456.ToString(), // Varsayılan Olarak
                Sifre = em.Sifre,
                Telefon = em.Telefon,
            };
            c.emlakcis.Add(yeni);
            c.SaveChanges();
            return RedirectToAction("Kullanıcılar");
        }
    }
}
