using System.ComponentModel.DataAnnotations;

namespace OnionArchitecture.Contracts.ViewModel_DTO.Authentication
{
    public class ResetPasswordRequest
    {
        public string Email { get; set; }

        public string Token { get; set; }

        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
