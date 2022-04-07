using MediatR;
using OnionArchitecture.Domain.Setting;
using OnionArchitecture.Contracts.ViewModel_DTO.Comment;
using OnionArchitecture.Service.Interface;
using System.Threading;
using System.Threading.Tasks;

namespace OnionArchitecture.Service.Features.CommentFeature.Events
{
    public record CommentCreatedEvent(CommentDto comment): INotification
    {

        public class CustomerCreatedEmailSenderHandler : INotificationHandler<CommentCreatedEvent>
        {
            private readonly IEmailService _emailService;
            public CustomerCreatedEmailSenderHandler(IEmailService emailService)
            {
                _emailService = emailService;
            }

            public async Task Handle(CommentCreatedEvent notification, CancellationToken cancellationToken)
            {
                var emailRequest = new MailRequest()
                {
                    Body = $"Your comment has been sent. We will answer after review",
                    ToEmail = notification.comment.EmailAddress,
                    Subject = "send comment",
                };
                await _emailService.SendEmailAsync(emailRequest);
            }
        }
    }
}
