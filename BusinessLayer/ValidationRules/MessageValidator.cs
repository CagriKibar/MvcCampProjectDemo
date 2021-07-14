using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
  public  class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(p => p.ReceiverMail).NotEmpty().WithMessage("Alıcı Adresini Boş Geçecemezsiniz");
            RuleFor(p => p.Subject).NotEmpty().WithMessage("Konuyu Boş Geçecemezsiniz");
            RuleFor(p => p.MessageContent).NotEmpty().WithMessage("İçeriği Boş Geçecemezsiniz");
            RuleFor(p => p.Subject).NotEmpty().WithMessage("İçeriği Boş Geçecemezsiniz");
            RuleFor(p => p.Subject).MinimumLength(3).WithMessage("Lütfen minimum 3 karakter girişi yapınız");
            RuleFor(p => p.Subject).MaximumLength(200).WithMessage("Lütfen Maximumum 100 karakter girişi yapınız");

        }
    }
}
