using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Identity;
using OnionArchitecture.Repository.EntitiesConfig;
using OnionArchitecture.Repository.Seed;
using System;

namespace OnionArchitecture.Repository.Context
{
    public class IdentityContext : IdentityDbContext<ApplicationUser, ApplicationRole, Int64,
                                                        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
                                                        ApplicationRoleClaim, ApplicationUserToken>
    {
        public IdentityContext(DbContextOptions<IdentityContext> option) : base(option)
        {

        }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // create identity tables in Identity Schema
            builder.HasDefaultSchema("Identity");

            // change identity tables name
            #region newTableName 
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "User");
            });

            builder.Entity<ApplicationRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<ApplicationUserRole>(entity =>
            {
                entity.ToTable("UserRoles");
            });

            builder.Entity<ApplicationUserClaim>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            builder.Entity<ApplicationUserLogin>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            builder.Entity<ApplicationUserClaim>(entity =>
            {
                entity.ToTable("RoleClaims");
            });

            builder.Entity<ApplicationUserToken>(entity =>
            {
                entity.ToTable("UserTokens");
            });
            #endregion

            // add default data in user,role and userRole tables
            builder.Seed();

            // set custom config on table properties, 
            builder.ConfigIdentity();

        }

    }
}
