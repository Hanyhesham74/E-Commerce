using E_Commerce.API.Factories;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Extensions
{
    public static class WebApiServicesExtensions
    {
        public static IServiceCollection AddWebApiServices(this IServiceCollection services)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = ApiResponceFactory.CustomValidationErrorResponse;
            });
            return services;
        }
    }
}
