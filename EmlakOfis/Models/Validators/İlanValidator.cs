using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using System.Threading.Tasks;

namespace EmlakOfis.Models.Validators
{
    public class İlanValidator : AbstractValidator<İlanEkle>
    {
        public İlanValidator()
        {
            RuleFor(x => x.Acıklama).NotNull().MaximumLength(1000).WithMessage("Boş olamaz ve en fazla 1000 kelime");
            RuleFor(x => x.Baslik).NotNull().MaximumLength(70).WithMessage("Boş olamaz ve en fazla 70 kelime");
            RuleFor(x => x.Katsayi).NotNull().WithMessage("Boş olamaz ");
            RuleFor(x => x.Metrekare).NotNull().WithMessage("Boş olamaz ");
            RuleFor(x => x.OdaSayi).NotNull().WithMessage("Boş olamaz ");
            RuleFor(x => x.SalonSayi).NotNull().WithMessage("Boş olamaz ");
            RuleFor(x => x.Fiyat).NotNull().WithMessage("Boş olamaz ");
            RuleFor(x => x.Yas).NotNull().WithMessage("Boş olamaz ");
        }
    }
}
