using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using OnionArchitecture.Repository.Context;
using AutoMapper;
using OnionArchitecture.Domain.Setting;
using OnionArchitecture.Service.Mapper;
using FluentValidation.AspNetCore;
using MediatR;

namespace OnionArchitecture.Service.Extension
{
    public static class ConfigureServiceContainer
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {
            // or you can use assembly in Extension method in Infra layer with below command
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddFluentValidation();
        }

        public static void AddSwaggerOpenAPI(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(setupAction =>
            {
                setupAction.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "OnionArchitecture.WebAPI.xml"), true);
                setupAction.SwaggerDoc("v1", new OpenApiInfo { Title = "OnionArchitecture.WebAPI", Version = "v1" });

                // config versioning in swagger
                setupAction.DocInclusionPredicate((doc, apiDescription) =>
                {
                    if (!apiDescription.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

                    var version = methodInfo.DeclaringType
                        .GetCustomAttributes<ApiVersionAttribute>(true)
                        .SelectMany(attr => attr.Versions);

                    return version.Any(v => $"v{v.ToString()}" == doc);
                });

                setupAction.SwaggerDoc(
                    "OpenAPISpecification",
                    new OpenApiInfo()
                    {
                        Title = "Onion Architecture WebAPI",
                        Version = "1",
                        Description = "Through this API you can access customer details",
                        //Contact = new OpenApiContact()
                        //{
                        //    Email = "samiramahdavii@gmail.com",
                        //    Name = "Samira Mahdavi",
                        //    Url = new Uri("https://amitpnk.github.io/")
                        //},
                        //License = new OpenApiLicense()
                        //{
                        //    Name = "MIT License",
                        //    Url = new Uri("https://opensource.org/licenses/MIT")
                        //}
                    });

                setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "JWT",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = $"Input your Bearer token in this format - Bearer token to access this API",

                    //کجا ارسال کند
                    //header or cookie
                    In = ParameterLocation.Header,

                });
                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                        }, new List<string>()
                    },
                });
            });


        }

        public static void AddVersion(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                //اگر ای پی آیی داشته باشیم که ورژن نداشته باشه از این ورژن دیفالت استفاده می کنه
                options.AssumeDefaultVersionWhenUnspecified = true;

                //ورژن یک را برای حالت دیفالت ست کن
                options.DefaultApiVersion = new ApiVersion(1, 0);

                //برای اینکه در رسپانس هدر اطلاعاتی از ای پی آی ارسال کنیم
                options.ReportApiVersions = true;
            });
        }

        public static void AddDbContext(this IServiceCollection serviceCollection, Microsoft.Extensions.Configuration.IConfiguration configuration, IConfigurationRoot configRoot)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ApplicationConnection") ?? configRoot["ConnectionStrings:ApplicationConnection"]
                                     , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));

                options.EnableSensitiveDataLogging();
            });
        }

        public static void AddAutoMapper(this IServiceCollection serviceCollection)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CommentMapper());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);

        }

        public static void AddMailSetting(this IServiceCollection serviceCollection, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            serviceCollection.Configure<MailSettings>(configuration.GetSection("MailSettings"));
        }
    }
}
