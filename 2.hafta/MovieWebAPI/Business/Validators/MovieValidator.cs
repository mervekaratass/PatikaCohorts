using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(m => m.MovieName)
               .NotEmpty().WithMessage("Film adı zorunludur.")
               .Length(1, 50).WithMessage("Film adı 1 ile 50 karakter arasında olmalıdır.");

            RuleFor(m => m.Duration)
              .GreaterThan(0).WithMessage("Film süresi 0'dan büyük olmalıdır.");

            RuleFor(m => m.Category)
              .NotEmpty().WithMessage("Kategori ismi zorunludur.");

            RuleFor(m => m.Director)
              .NotEmpty().WithMessage("Yönetmen adı zorunludur.")
              .Length(1, 50).WithMessage("Yönetmen adı 1 ile 50 karakter arasında olmalıdır.");
        }
    }
}
