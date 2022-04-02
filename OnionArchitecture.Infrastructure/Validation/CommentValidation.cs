
using FluentValidation;
using OnionArchitecture.Infrastructure.ViewModel_DTO.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Infrastructure.Validation
{
    public class CommentValidation : AbstractValidator<CommentDto>
    {
        public CommentValidation()
        {
            RuleFor(u => u.EmailAddress).EmailAddress().WithMessage("Your mail is not at the correct format");
        }
    }
}
