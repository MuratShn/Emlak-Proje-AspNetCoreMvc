using EmlakOfis.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmlakOfis.Controllers
{
    public class Login : Controller
    {
        Context c = new Context();

        public IActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Giris(AdminGiris ag)
        {
            var averi = c.admins.FirstOrDefault(x => x.KullaniciAdi == ag.KullaniciAdi && x.Sifre == ag.Sifre);
            var everi = c.emlakcis.FirstOrDefault(x => x.KullaniciAdi == ag.KullaniciAdi && x.Sifre == ag.Sifre);

            if (averi != null)
            {
                var claims = new List<Claim>{
                                        new Claim(ClaimTypes.Name,ag.KullaniciAdi)
                                    };
                var useridenty = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridenty);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction(actionName: "Index", controllerName: "Admin", new { id = averi.Id });
            }

            else if (everi != null)

            {
                var claims = new List<Claim>{
                                        new Claim(ClaimTypes.Name,ag.KullaniciAdi)
                                    };
                var useridenty = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridenty);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction(actionName: "Index", controllerName: "Agent", new { id = everi.Id });
            }


            return View();

        }
        public async Task<IActionResult> Cikis()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

    }
}

