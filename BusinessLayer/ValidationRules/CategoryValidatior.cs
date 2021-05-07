using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class CategoryValidatior:AbstractValidator<Category>
    {
        public CategoryValidatior()
        {
            RuleFor(p => p.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçmeyiniz");
            RuleFor(p => p.CategoryDescription).NotEmpty().WithMessage("Açıklamayı Boş Geçmeyiniz !");
            RuleFor(p => p.CategoryName).MinimumLength(3).WithMessage("Lütfen En Az Üç Karakter Girişi Yapınız");
            RuleFor(p => p.CategoryName).MaximumLength(20).WithMessage("Lütfen20 karakterden Fazla Girmeyiniz ");


        }
    }
}
