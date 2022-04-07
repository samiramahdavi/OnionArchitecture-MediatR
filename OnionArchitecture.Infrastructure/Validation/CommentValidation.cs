using FluentValidation;
using OnionArchitecture.Contracts.ViewModel_DTO.Comment;

namespace OnionArchitecture.Contracts.Validation
{
    public class CommentValidation : AbstractValidator<CommentDto>
    {
        public CommentValidation()
        {
            RuleFor(u => u.EmailAddress).EmailAddress().WithMessage("Your mail is not at the correct format");
        }
    }
}
