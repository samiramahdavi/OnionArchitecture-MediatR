using FluentValidation;
using OnionArchitecture.Domain.Identity.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Infrastructure.Validation.Authentication
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
