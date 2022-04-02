using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using OnionArchitecture.Service.Middleware;
using Serilog;

namespace OnionArchitecture.Infrastructure.Extension
{
    public static class ConfigureContainer
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomExceptionMiddleware>();
        }
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnionArchitecture.WebAPI v1"));

        }
 
    }
}
