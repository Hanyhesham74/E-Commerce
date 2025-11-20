using Services;
using Services.Implementations;
using Services_Abstraction.Contracts;

namespace E_Commerce.API.Extensions
{
    public static class CoreServicesExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { }, typeof(AssemblyReference).Assembly);
            services.AddScoped<IServiceManger, ServiceManger>();
            return services;
        }
    }
}
