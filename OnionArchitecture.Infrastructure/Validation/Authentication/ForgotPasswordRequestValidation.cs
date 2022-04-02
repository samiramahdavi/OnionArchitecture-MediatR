using FluentValidation;
using OnionArchitecture.Domain.Identity.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Infrastructure.Validation.Authentication
{
    public class ForgotPasswordRequestValidation : AbstractValidator<ForgotPasswordRequest>
    {
        public ForgotPasswordRequestValidation()
        {
            RuleFor(p => p.Email).NotEmpty().NotNull().EmailAddress().WithMessage("Please enter a correct email address");
        }
    }
}
