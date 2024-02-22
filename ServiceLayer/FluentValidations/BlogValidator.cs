using Core.Layer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.FluentValidations
{
    public class BlogValidator : AbstractValidator<Blog>
    {

        public BlogValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Blog İsmi Boş Bırakılamaz").MaximumLength(100).WithMessage("Blog İsmi En Fazla 100 karakter olabilir").MinimumLength(15).WithMessage("Blog İsmi en az 15 karakter olmalıdır");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Blog İçeriği Boş Bırakılamaz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Blog Açıklaması Boş Bırakılamaz").MaximumLength(250).WithMessage("Açıklama en fazla 250 karakter olabilir").MinimumLength(50).WithMessage("Açıklama en az 50 karakter olmalıdır");
            RuleFor(x => x.BlogCategories).NotEmpty().WithMessage("Blog Categorisi Seçiniz");
        }

    }
}
