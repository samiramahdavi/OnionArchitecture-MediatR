using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Identity;
using System.Collections.Generic;

namespace OnionArchitecture.Repository.Seed
{
    public static class ContextSeed
    {
        /// <summary>
        /// this extension method adds a seed method in ModelBuilder, that prepare default data in the database
        /// </summary>
        /// <param name="builder"></param>
        public static void Seed(this ModelBuilder builder)
        {
            CreateUsers(builder);
            CreateRoles(builder);
            MapUserRole(builder);
        }

        private static void CreateUsers(ModelBuilder modelBuilder)
        {
            List<ApplicationUser> users = DefaultUser.ApplicationUserList();
            modelBuilder.Entity<ApplicationUser>().HasData(users);
        }
        private static void CreateRoles(ModelBuilder modelBuilder)
        {
            List<ApplicationRole> roles = DefaultRole.IdentityRoleList();
            modelBuilder.Entity<ApplicationRole>().HasData(roles);
        }
        private static void MapUserRole(ModelBuilder modelBuilder)
        {
            var identityUserRoles = MappingDefaultUserRole.UserRoleList();
            modelBuilder.Entity<ApplicationUserRole>().HasData(identityUserRoles);
        }
    }
}
