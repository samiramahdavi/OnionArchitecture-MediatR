using System;

namespace OnionArchitecture.Domain.Constant
{
    public static class IdentityConstants
    {
        public static readonly Int64 MainAdminRoleId = 1;
        public static readonly Int64 BasicRoleId = 2;
        public static readonly string MainAdminConcurrencyStamp = Guid.NewGuid().ToString();
        public static readonly string BasicConcurrencyStamp = Guid.NewGuid().ToString();


        public static readonly Int64 MainAdminUserId = 1;
        public static readonly Int64 BasicUserId = 2;
    }
}
