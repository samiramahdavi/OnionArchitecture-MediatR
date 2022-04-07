using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnionArchitecture.Contracts.ViewModel_DTO.Authentication
{
    public class AuthenticationResponse
    {
        public Int64 Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public bool IsVerified { get; set; }
        public string JWToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
