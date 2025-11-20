using Domain.Contracts;
using E_Commerce.API.Middlewares;

namespace E_Commerce.API.Extensions
{
    public static class WebApplicationExtensions
    {
        public static async Task<WebApplication>SeedDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var objectofdataseading = scope.ServiceProvider.GetRequiredService<IDataSeading>();
            await objectofdataseading.DataSeedAsync();
            return app;
        }

        public static WebApplication UseExceptionHandlingMiddlewares(this WebApplication app)
        {
            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
            return app;
        }

        public static WebApplication UseSwaggerMiddlewares(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        } 
         
        
        
    }
}
