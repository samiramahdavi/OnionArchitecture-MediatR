using OnionArchitecture.Domain.Common;
using OnionArchitecture.Contracts.ViewModel_DTO.Authentication;
using System.Threading.Tasks;

namespace OnionArchitecture.Service.Interface
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress);
        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);
        Task<Response<string>> ConfirmEmailAsync(string userId, string code);
        Task ForgotPassword(ForgotPasswordRequest model, string origin);
        Task<Response<string>> ResetPassword(ResetPasswordRequest model);
    }
}
