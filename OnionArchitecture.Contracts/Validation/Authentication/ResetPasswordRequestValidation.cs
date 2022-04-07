using FluentValidation;
using OnionArchitecture.Contracts.ViewModel_DTO.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Contracts.Validation.Authentication
{
    public class ResetPasswordRequestValidation:AbstractValidator<ResetPasswordRequest>
    {
        public ResetPasswordRequestValidation()
        {
            RuleFor(r => r.Email).NotEmpty().EmailAddress().WithMessage("Please enter your email address");
            RuleFor(r => r.Token).NotEmpty().WithMessage("Your token is empty");
            RuleFor(r => r.Password).NotEmpty().MinimumLength(6).WithMessage("Please enter a password, atleast 6 character");
            RuleFor(r => r.ConfirmPassword).NotEmpty().MinimumLength(6).WithMessage("Please enter a password, atleast 6 character");
        }
    }
}
