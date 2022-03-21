using FluentValidation;
using RentACar.DAL.Dto.Branch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Validation.Branch
{
    public class UpdateBranchValidator : AbstractValidator<UpdateBranchDto>
    {
        public UpdateBranchValidator()
        {
            RuleFor(p => p.BranchName).NotEmpty().WithMessage("İsim boş bırakılamaz.").MaximumLength(30).WithMessage("Mkasımum 30 karakter giriniz.");
            RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("Telefon numarası boş geçilemez.").MaximumLength(10).WithMessage("Maksımum 10 karakter giriniz.");
        }
    }
}
