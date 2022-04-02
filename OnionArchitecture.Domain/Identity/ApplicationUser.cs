using Microsoft.AspNetCore.Identity;
using System;

namespace OnionArchitecture.Domain.Identity
{
    public class ApplicationUser : IdentityUser<Int64>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
