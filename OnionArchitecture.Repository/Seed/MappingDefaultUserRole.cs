using OnionArchitecture.Domain.Constant;
using OnionArchitecture.Domain.Identity;
using System.Collections.Generic;


namespace OnionArchitecture.Repository.Seed
{
    public static class MappingDefaultUserRole
    {
        public static List<ApplicationUserRole> UserRoleList()
        {
            var list = new List<ApplicationUserRole>()
            { 
                new ApplicationUserRole{ RoleId = IdentityConstants.MainAdminRoleId , UserId = IdentityConstants.MainAdminUserId},
                new ApplicationUserRole{ RoleId = IdentityConstants.BasicRoleId , UserId = IdentityConstants.BasicUserId}
            };

            return list;
        }

    }
}
