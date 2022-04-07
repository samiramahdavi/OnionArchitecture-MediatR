using FluentValidation;
using OnionArchitecture.Contracts.ViewModel_DTO.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Contracts.Validation.Authentication
{
    public class RegisterRequestValidation:AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidation()
        {
            RuleFor(r => r.FirstName).NotEmpty().WithMessage("Please enter your first name");
            RuleFor(r => r.LastName).NotEmpty().WithMessage("Please enter your last name");

            RuleFor(r => r.Email).NotEmpty().EmailAddress().WithMessage("Please enter your email address");
            RuleFor(r => r.UserName).NotEmpty().MinimumLength(6).WithMessage("Please enter a valid username, atleast 6 character");
            RuleFor(r => r.Password).NotEmpty().MinimumLength(6).WithMessage("Please enter a password, atleast 6 character");
            RuleFor(r => r.ConfirmPassword).NotEmpty().MinimumLength(6).WithMessage("Please enter a password, atleast 6 character");
        }
    }
}
