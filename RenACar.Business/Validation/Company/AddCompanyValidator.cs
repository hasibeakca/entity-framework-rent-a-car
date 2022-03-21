using FluentValidation;
using RentACar.DAL.Dto.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Validation.Company
{
  public  class AddCompanyValidator : AbstractValidator<AddCompanyDto>
    {
        public AddCompanyValidator()
        {
            RuleFor(p => p.CompanyName).NotEmpty().WithMessage("CompanyName boş bırakılamaz");
           

        }
    }
}
