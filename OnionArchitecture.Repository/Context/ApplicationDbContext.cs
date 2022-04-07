using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Repository.EntitiesConfig;
using System.Threading.Tasks;

namespace OnionArchitecture.Repository.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        public DbSet<Comment> Comments { get; set; }

        public async Task<long> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ConfigApplication();
        }

    }
}
