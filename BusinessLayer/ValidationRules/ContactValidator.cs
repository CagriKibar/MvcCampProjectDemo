using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(p => p.UserMail).NotEmpty().WithMessage("Mail Adresini Boş Geçemeszsiniz");
            RuleFor(p => p.Subject).NotEmpty().WithMessage("Konu Adını Boş Geçemeszsiniz");
            RuleFor(p => p.UserName).NotEmpty().WithMessage("Kullanıcı Adını Boş Geçemeszsiniz");
            RuleFor(p => p.Subject).MinimumLength(3).WithMessage("En az 3 karakter girişi yapınız");
            RuleFor(p => p.UserName).MinimumLength(33).WithMessage("En az 3 karakter girişi yapınız");
            RuleFor(p => p.Subject).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla giriş yapmayınız");
        }
    }
}
