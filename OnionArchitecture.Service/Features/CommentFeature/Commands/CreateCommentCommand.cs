using AutoMapper;
using MediatR;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Infrastructure.ViewModel_DTO.Comment;
using OnionArchitecture.Repository.Context;
using OnionArchitecture.Repository.Repository.Interface;
using OnionArchitecture.Service.Features.CommentFeature.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.Service.Features.CommentFeature.Commands
{
    /// <summary>
    /// with record type you can create an Immutabble object
    /// The "comment" is input and we return "CommentDto" after insert data
    /// </summary>
    public record CreateCommentCommand(CommentDto comment):IRequest<CommentDto>
    {
        /// <summary>
        /// with "IRequestHandler" we can prosses the IRequest 
        /// </summary>
        public class CreateCommentCommandHandle : IRequestHandler<CreateCommentCommand, CommentDto>
        {
            private readonly IMediator _mediator;
            private readonly ICommentRepository _comment;
            private readonly IMapper _mapper;

            public CreateCommentCommandHandle(IMediator mediator, ICommentRepository comment, IMapper mapper)
            {
                _mediator = mediator;
                _comment = comment;
                _mapper = mapper;
            }

            public async Task<CommentDto> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
            {
                var comment = _mapper.Map<Comment>(request.comment);

                await _comment.AddAsync(comment);


                // Raising Event to send email to user
                await _mediator.Publish(new CommentCreatedEvent(request.comment), cancellationToken);

                return _mapper.Map<CommentDto>(comment);
            }

        }
    }
}
