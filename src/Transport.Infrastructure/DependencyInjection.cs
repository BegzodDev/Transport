using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Transport.Application.Abstractions;
using Transport.Domain.Entities;
using Transport.Infrastructure.Persistence;
using Transport.Infrastructure.Services;

namespace Transport.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTransport(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost";
                options.InstanceName = "local";
            });





                services.AddSingleton<IHashService, HashService>();
                services.AddScoped<ITokenService, JWTService>();
                services.AddScoped<ICurrentUserService, CurrentUserService>();
                services.AddScoped<IGovermentService, GovermentService>();
                services.AddScoped<IEconomyService, EconomyService>();
                services.AddScoped<ISecurityService, SecureService>();

                services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidAudience = configuration["JWTConfiguration:ValidAudience"],
                       ValidIssuer = configuration["JWTConfiguration:ValidIssuer"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTConfiguration:Secret"]!))
                   };
               });



            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminActions", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, nameof(Admin)); // tekshirish kerak
                });

                options.AddPolicy("UserActions", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, nameof(User)); // tekshirish kerak
                });
            });


            return services;
        }
    }
}
