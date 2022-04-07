using AutoMapper;
using MediatR;
using OnionArchitecture.Repository.Repository.Interface;
using OnionArchitecture.Service.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.Service.Features.CommentFeature.Commands
{
    public record DeleteCommentCommand(Int64 id) : IRequest<Int64>
    {

        public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Int64>
        {
            private readonly IMapper _mapper;
            private readonly ICommentRepository _comment;

            public DeleteCommentCommandHandler(IMapper mapper, ICommentRepository comment)
            {
                _mapper = mapper;
                _comment = comment;
            }

            public async Task<long> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
            {
                if (_comment.Any(request.id))
                {
                    var comment = await _comment.GetAsync(request.id);
                    await _comment.Remove(comment);

                    return request.id;
                }
                else
                {
                    throw new NotFoundException("Not Found!", "This comment with this Id not found.");
                }
            }
        }
    }
}
