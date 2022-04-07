using OnionArchitecture.Domain.Identity;
using System.Collections.Generic;


namespace OnionArchitecture.Repository.Seed
{
    public static class DefaultRole
    {
        public static List<ApplicationRole> IdentityRoleList()
        {
            var roleList = new List<ApplicationRole>()
            {
                new ApplicationRole{
                    Id = OnionArchitecture.Domain.Constant.IdentityConstants.MainAdminRoleId,
                    Name =  OnionArchitecture.Domain.Enum.Roles.MainAdmin.ToString(),
                    ConcurrencyStamp = OnionArchitecture.Domain.Constant.IdentityConstants.MainAdminConcurrencyStamp.ToString(),
                    NormalizedName =  OnionArchitecture.Domain.Enum.Roles.MainAdmin.ToString().ToUpper()
                }
                ,
                new ApplicationRole{
                    Id = OnionArchitecture.Domain.Constant.IdentityConstants.BasicRoleId,
                    Name =  OnionArchitecture.Domain.Enum.Roles.Basic.ToString(),
                    ConcurrencyStamp = OnionArchitecture.Domain.Constant.IdentityConstants.BasicConcurrencyStamp.ToString(),
                    NormalizedName =  OnionArchitecture.Domain.Enum.Roles.Basic.ToString().ToUpper()
                }
            };

            return roleList;
        }
    }
}
