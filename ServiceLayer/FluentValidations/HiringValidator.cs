using Core.Layer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Layer.FluentValidations
{
    public class HiringValidator : AbstractValidator<Hiring>
    {
        public HiringValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İlan İsmi Boş Bırakılamaz").MaximumLength(100).WithMessage("İlan İsmi En Fazla 100 karakter olabilir").MinimumLength(10).WithMessage("İlan İsmi en az 10 karakter olmalıdır");
            RuleFor(x => x.Content).NotEmpty().WithMessage("İlan İçeriği Boş Bırakılamaz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("İlan Açıklaması Boş Bırakılamaz").MinimumLength(20).WithMessage("İlan Açıklaması En Az 20 Karakter Olmalıdır").MaximumLength(100).WithMessage("İlan AÇIKLAMASI En Fazla 100 Karakter Olabilir");
        }
    }
}
