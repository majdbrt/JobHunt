using JobHuntApi.Configuration;
using JobHuntApi.Contracts;
using JobHuntApi.Extensions;
using JobHuntApi.Repositories;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

// Use environment variables
DotNetEnv.Env.Load();


// Add services to the container.

// Conntect to Db
builder.Services.ConfigureDB();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Cors Configuration; allow origin http://localhost:3000 with any headers, any methods
builder.Services.ConfigureCors();

// Add IIS Integration Configuration with default properties
builder.Services.ConfigureIISIntegration();

builder.Services.AddDependencyInjection();

builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
    app.UseHsts();

// app.UseHttpsRedirection();
// app.UseStaticFiles();
// app.UseForwardedHeaders(new ForwardedHeadersOptions
// {
//     ForwardedHeaders = ForwardedHeaders.All
// });
app.UseCors("Policy");

app.UseAuthorization();

app.MapControllers();

app.Run();
