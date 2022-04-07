using FluentValidation;
using OnionArchitecture.Contracts.ViewModel_DTO.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Contracts.Validation.Authentication
{
    public class ForgotPasswordRequestValidation : AbstractValidator<ForgotPasswordRequest>
    {
        public ForgotPasswordRequestValidation()
        {
            RuleFor(p => p.Email).NotEmpty().NotNull().EmailAddress().WithMessage("Please enter a correct email address");
        }
    }
}
