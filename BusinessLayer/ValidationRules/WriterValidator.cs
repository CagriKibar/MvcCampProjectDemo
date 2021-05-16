using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
  public  class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(p => p.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz");
            RuleFor(p => p.WriterLastName).NotEmpty().WithMessage("Yazar  Soy Adını Boş Geçemezsiniz");
            RuleFor(p => p.WriterAbout).NotEmpty().WithMessage("Hakkımda Kısmını  Boş Geçemezsiniz");
            RuleFor(p => p.WriterLastName).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Girişi Yapınız");
            RuleFor(p => p.WriterLastName).MaximumLength(50).WithMessage("Lütfen 50 Karakterden Fazla Değer Girişi Yapınız");



        }
    }
}
