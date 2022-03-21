using FluentValidation;
using RentACar.DAL.Dto.CarCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Validation.CarCustomer
{
  public  class AddCarCustomerValidator : AbstractValidator<AddCarCustomerDto>
    {
        public AddCarCustomerValidator()
        {
            RuleFor(p => p.CarId).NotEmpty().WithMessage("CarId boş geçilemez.");
            RuleFor(p => p.CustomerId).NotEmpty().WithMessage("CustomerId boş geçilemez.");

        }
    }
}
