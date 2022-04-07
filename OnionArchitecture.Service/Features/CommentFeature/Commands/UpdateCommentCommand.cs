using AutoMapper;
using MediatR;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Contracts.ViewModel_DTO.Comment;
using OnionArchitecture.Repository.Repository.Interface;
using OnionArchitecture.Service.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.Service.Features.CommentFeature.Commands
{
    public record UpdateCommentCommand(CommentDto comment) : IRequest<CommentDto>
    {
        public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, CommentDto>
        {
            private readonly IMapper _mapper;
            private readonly ICommentRepository _comment;

            public UpdateCommentCommandHandler(IMapper mapper, ICommentRepository comment)
            {
                _mapper = mapper;
                _comment = comment;
            }

            public async Task<CommentDto> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
            {
                var c = _mapper.Map<Comment>(request.comment);

                if (_comment.Any(c.Id))
                {
                    await _comment.Update(c);
                    return _mapper.Map<CommentDto>(c);
                }
                else
                {
                    throw new NotFoundException("Not Found!", "This comment with this Id not found.");
                }
            }
        }
    }
}
