using OnionArchitecture.Domain.Identity;
using System.Collections.Generic;

namespace OnionArchitecture.Repository.Seed
{
    public static class DefaultUser
    {
        public static List<ApplicationUser> ApplicationUserList()
        {
            var userList = new List<ApplicationUser>() 
            {
                new ApplicationUser
                {
                    Id =OnionArchitecture.Domain.Constant.IdentityConstants.MainAdminUserId,
                    FirstName = "MainAdmin",
                    LastName = "MainAdmin",
                    UserName = "MainAdmin",
                    Email = "MainAdmin@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    // Password@123
                    PasswordHash = "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==",
                    NormalizedEmail= "MAINADMIN@GMAIL.COM",
                    NormalizedUserName="MAINADMIN"
                },
                 new ApplicationUser
                {
                    Id =OnionArchitecture.Domain.Constant.IdentityConstants.BasicUserId,
                    FirstName = "Basic",
                    LastName = "Basic",
                    UserName = "Basic",
                    Email = "Basic@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    // Password@123
                    PasswordHash = "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==",
                    NormalizedEmail= "BASIC@GMAIL.COM",
                    NormalizedUserName="BASIC"
                }
            };

            return userList;
        }
    }
}
