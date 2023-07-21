using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobHuntApi.Contracts;
using JobHuntApi.Repositories;
using Microsoft.EntityFrameworkCore;
namespace JobHuntApi.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy("Policy", builder => {
                    builder.WithOrigins("https://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod();   
                }); 
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services){
            // use default properties
            services.Configure<IISOptions>(options => {    
            });
        }

        public static void ConfigureDB(this IServiceCollection services){
            services.AddDbContext<DbContext>(options => {
                options.UseNpgsql(System.Environment.GetEnvironmentVariable("CONNECTION_STRING"));
            });
        }

        public static void AddDependencyInjection(this IServiceCollection services){
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
        }


    }
}