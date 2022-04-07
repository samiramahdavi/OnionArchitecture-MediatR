using System.ComponentModel.DataAnnotations;


namespace OnionArchitecture.Contracts.ViewModel_DTO.Authentication
{
    public class RegisterRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
