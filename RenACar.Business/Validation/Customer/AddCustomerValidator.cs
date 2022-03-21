using FluentValidation;
using RentACar.DAL.Dto.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Validation.Customer
{
    public class AddCustomerValidator : AbstractValidator<AddCustomerDto>
    {
        public AddCustomerValidator()
        {
            RuleFor(p => p.CustomerName).NotEmpty().WithMessage("CustomerName boş bırakılamaz").MaximumLength(20).WithMessage("Maksımum 20 karalter girilebilir.");
            RuleFor(p => p.CustomerSurname).NotEmpty().WithMessage("CustomerSurname boş bırakılamaz").MaximumLength(20).WithMessage("Maksımum 20 karalter girilebilir.");
            RuleFor(p => p.CustomerPhoneNumber).NotEmpty().WithMessage("Telefon numarası boş geçilemez").MaximumLength(10).WithMessage("Maksımum 10 karakter giriniz.");
            

        }
    }
}
