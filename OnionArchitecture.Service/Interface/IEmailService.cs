using OnionArchitecture.Domain.Setting;
using System.Threading.Tasks;

namespace OnionArchitecture.Service.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
