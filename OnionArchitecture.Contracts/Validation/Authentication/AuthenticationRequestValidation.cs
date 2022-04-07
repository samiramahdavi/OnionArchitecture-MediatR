using FluentValidation;
using OnionArchitecture.Contracts.ViewModel_DTO.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Contracts.Validation.Authentication
{
    public class AuthenticationRequestValidation : AbstractValidator<AuthenticationRequest>
    {
        public AuthenticationRequestValidation()
        {
            RuleFor(r => r.Email).EmailAddress().NotNull().NotEmpty().WithMessage("Please enter a correct email address");
            RuleFor(r => r.Password).NotNull().NotEmpty().WithMessage("Please enter your password");
        }
    }
}
