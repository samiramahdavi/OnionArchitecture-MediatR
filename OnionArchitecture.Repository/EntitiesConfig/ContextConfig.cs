using Microsoft.EntityFrameworkCore;

namespace OnionArchitecture.Repository.EntitiesConfig
{
    public static class ContextConfig
    {
        public static void ConfigApplication(this ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CommentConfig());
        }
        public static void ConfigIdentity(this ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ApplicationUserConfig());
        }
    }
}
