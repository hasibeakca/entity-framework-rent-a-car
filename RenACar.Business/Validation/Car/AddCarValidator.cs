using FluentValidation;
using RentACar.DAL.Dto.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Validation.Car
{
  public  class AddCarValidator : AbstractValidator<AddCarDto>
    {
        public AddCarValidator()
        {
            RuleFor(p => p.CarName).NotEmpty().WithMessage("CarName boş bırakılamaz").MaximumLength(20).WithMessage("20 karakterden fazla giremezsiniz.");
            RuleFor(p => p.Color).NotEmpty().WithMessage("Color boş bırakılamaz").MaximumLength(20).WithMessage("20 karakterden fazla giremezsiniz.");
            RuleFor(p => p.ModelName).NotEmpty().WithMessage("ModelName boş bırakılamaz").MaximumLength(30).WithMessage("30 karakterden fazla giremezsiniz.");

        }
    }
}
