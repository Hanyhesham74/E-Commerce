
using Domain.Contracts;
using E_Commerce.API.Extensions;
using E_Commerce.API.Factories;
using E_Commerce.API.Middlewares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presistence.Data;
using Presistence.Repositories;
using Services;
using Services.Implementations;
using Services_Abstraction.Contracts;
using System.Reflection;
using System.Threading.Tasks;

namespace E_Commerce.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //webapiservices
            builder.Services.AddWebApiServices();
            //InfrastructureServices
            builder.Services.AddInfrastructureServices(builder.Configuration); 
            //core services
            builder.Services.AddCoreServices(); 
            //Add-Migration "IntialCreate" -OutputDir Data\Migrations
            var app = builder.Build();

            await app.SeedDatabaseAsync();
            // Configure the HTTP request pipeline.
           app.UseExceptionHandlingMiddlewares();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerMiddlewares();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
