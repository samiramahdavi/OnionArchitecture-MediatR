using AutoMapper;
using MediatR;
using OnionArchitecture.Contracts.ViewModel_DTO.Comment;
using OnionArchitecture.Repository.Repository.Interface;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.Service.Features.CommentFeature.Queries
{
    public record GetAllCommentQuery : IRequest<IEnumerable<CommentDto>>
    {
        public class GetAllCommentQueryHandler : IRequestHandler<GetAllCommentQuery, IEnumerable<CommentDto>>
        {
            private readonly IMapper _mapper;
            private readonly ICommentRepository _comment;

            public GetAllCommentQueryHandler(IMapper mapper, ICommentRepository comment)
            {
                _mapper = mapper;
                _comment = comment;
            }

            public async Task<IEnumerable<CommentDto>> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
            {
                var list = await _comment.GetAllAsync();
                if (list==null)
                {
                    return null;
                }

               return _mapper.Map< List<CommentDto>> (list);
            }
        }
    }
}
