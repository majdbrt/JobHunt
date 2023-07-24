using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobHuntApi.Contracts;
using JobHuntApi.Models;
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
            services.AddDbContext<JobHuntApiDbContext>(options => {
                String? connectionString = System.Environment.GetEnvironmentVariable("CONNECTION_STRING");
                if(connectionString == null){
                    throw new NullReferenceException(connectionString);
                }
                options.UseNpgsql(connectionString);
            });
        }

        public static void AddDependencyInjection(this IServiceCollection services){
           services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
           services.AddScoped<IApplicationRepository, ApplicationRepository>();
           services.AddScoped<IInterviewRepository, InterviewRepository>();
        }


    }
}