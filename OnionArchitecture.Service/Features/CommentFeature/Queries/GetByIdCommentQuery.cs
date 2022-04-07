using AutoMapper;
using MediatR;
using OnionArchitecture.Contracts.ViewModel_DTO.Comment;
using OnionArchitecture.Repository.Repository.Interface;
using OnionArchitecture.Service.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.Service.Features.CommentFeature.Queries
{
    public record GetByIdCommentQuery(Int64 commentId) : IRequest<CommentDto>
    {

        public class GetByIdCommentQueryHandler : IRequestHandler<GetByIdCommentQuery, CommentDto>
        {
            private readonly IMapper _mapper;
            private readonly ICommentRepository _comment;

            public GetByIdCommentQueryHandler(ICommentRepository comment, IMapper mapper)
            {
                _mapper = mapper;
                _comment = comment;
            }

            public async Task<CommentDto> Handle(GetByIdCommentQuery request, CancellationToken cancellationToken)
            {
                if (_comment.Any(request.commentId))
                {
                    var result = await _comment.GetAsync(request.commentId);
                    var temp = _mapper.Map<CommentDto>(result);
                    return temp;
                }
                else
                {
                    throw new NotFoundException("Not Found!", "This comment with this Id not found.");
                }
            }
        }
    }
}
