using FluentValidation;
using RentACar.DAL.Dto.BranchCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Validation.BranchCustomer
{
    public class UpdateBranchCustomerValidator : AbstractValidator<UpdateBranchCustomerDto>
    {
        public UpdateBranchCustomerValidator()
        {
            RuleFor(p => p.BranchId).NotEmpty().WithMessage("BranchId boş bırakılamaz.");
            RuleFor(p => p.CustomerId).NotEmpty().WithMessage("CustomerId boş bırakılamaz.");
        }
    }
}
