using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OnionArchitecture.Domain.Common;
using OnionArchitecture.Domain.Identity;
using OnionArchitecture.Contracts.ViewModel_DTO.Authentication;
using OnionArchitecture.Domain.Setting;
using OnionArchitecture.Contracts.Validation;
using OnionArchitecture.Contracts.Validation.Authentication;
using OnionArchitecture.Contracts.ViewModel_DTO.Comment;
using OnionArchitecture.Repository.Context;
using OnionArchitecture.Repository.Repository.Implementation;
using OnionArchitecture.Repository.Repository.Interface;
using OnionArchitecture.Service.Implementation;
using OnionArchitecture.Service.Interface;
using OnionArchitecture.Service.Middleware;
using System;
using System.Text;

namespace OnionArchitecture.Service.Dependency
{
    public static class DependencyInjection
    {
        public static void AddIdentityService(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, IConfiguration configuration)
        {
       
            services.AddDbContext<IdentityContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("IdentityConnection"),
                b => b.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName)));
          
            services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

            #region Services
             services.AddTransient<IAccountService, AccountService>();
            #endregion

           services.Configure<JWTSetting>(configuration.GetSection("JWTSetting"));


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["JWTSetting:Issuer"],
                        ValidAudience = configuration["JWTSetting:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSetting:Key"]))
                    };
                    o.Events = new JwtBearerEvents()
                    {
                        OnAuthenticationFailed = c =>
                        {
                            c.NoResult();
                            c.Response.StatusCode = 500;
                            c.Response.ContentType = "text/plain";
                            return c.Response.WriteAsync(c.Exception.ToString());
                        },
                        OnChallenge = context =>
                        {
                            context.HandleResponse();
                            context.Response.StatusCode = 401;
                            context.Response.ContentType = "application/json";
                            var result = JsonConvert.SerializeObject(new Response<string>("You are not Authorized"));
                            return context.Response.WriteAsync(result);
                        },
                        OnForbidden = context =>
                        {
                            context.Response.StatusCode = 403;
                            context.Response.ContentType = "application/json";
                            var result = JsonConvert.SerializeObject(new Response<string>("You are not authorized to access this resource"));
                            return context.Response.WriteAsync(result);
                        },
                    };
                });
        }

        public static void AddMediatRService(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionBehaviorMiddleware<,>));
        }

        public static void AddScopedServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            serviceCollection.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            serviceCollection.AddScoped<ICommentRepository, CommentRepository>();
        }
        public static void AddTransientServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IEmailService, EmailService>();
            serviceCollection.AddTransient<IAccountService, AccountService>();

            AddValidation(serviceCollection);
        }



        private static void AddValidation(IServiceCollection services)
        {
            services.AddTransient<IValidator<CommentDto>, CommentValidation>();
            services.AddTransient<IValidator<AuthenticationRequest>, AuthenticationRequestValidation>();
            services.AddTransient<IValidator<ForgotPasswordRequest>, ForgotPasswordRequestValidation>();
            services.AddTransient<IValidator<RegisterRequest>, RegisterRequestValidation>();
            services.AddTransient<IValidator<ResetPasswordRequest>, ResetPasswordRequestValidation>();
        }
    }
}
