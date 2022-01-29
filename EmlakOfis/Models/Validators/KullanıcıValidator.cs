using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmlakOfis.Models.Validators
{
    public class KullanıcıValidator  : AbstractValidator<EmlakcıEkle>
    {
        public KullanıcıValidator()
        {
            RuleFor(x => x.Ad).NotNull().MinimumLength(2).WithMessage("Boş Bıraklamaz");
            RuleFor(x=>x.Soyad).NotNull().MinimumLength(2).WithMessage("Boş Bıraklamaz");
            RuleFor(x=>x.Telefon).NotNull().MinimumLength(13).MaximumLength(13).WithMessage("Boş Bıraklamaz ve formata uygun olmalı 555 555 55 55");
            RuleFor(x=>x.KullaniciAdi).NotNull().MinimumLength(5).WithMessage("Boş Bıraklamaz");
            RuleFor(x=>x.Sifre).NotNull().MinimumLength(5).WithMessage("Boş Bıraklamaz");
        }
    }
}