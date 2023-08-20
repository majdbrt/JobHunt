using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobHuntApi.Contracts;
using JobHuntApi.Models;
using JobHuntApi.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace JobHuntApi.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("Policy", builder =>
                {
                    builder.WithOrigins("https://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            // use default properties
            services.Configure<IISOptions>(options =>
            {
            });
        }

        public static void ConfigureDB(this IServiceCollection services)
        {
            services.AddDbContext<JobHuntApiDbContext>(options =>
            {
                String? connectionString = System.Environment.GetEnvironmentVariable("CONNECTION_STRING");
                if (connectionString == null)
                {
                    throw new NullReferenceException(connectionString);
                }
                options.UseNpgsql(connectionString);
            });
        }

        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IInterviewRepository, InterviewRepository>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;

            })
            .AddEntityFrameworkStores<JobHuntApiDbContext>()
            .AddDefaultTokenProviders();
        }

        public static void ConfigureJWT(this IServiceCollection services)
        {
            String? validIssuer = System.Environment.GetEnvironmentVariable("JWT_VALID_ISSUER");
            String? validAudience = System.Environment.GetEnvironmentVariable("JWT_VALID_AUDIENCE");
            String? secret = System.Environment.GetEnvironmentVariable("JWT_SECRET");

            if (secret == null)
            {
                throw new NullReferenceException(secret);
            }

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = validIssuer,
                    ValidAudience = validAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
                };
            });

        }
    }
}