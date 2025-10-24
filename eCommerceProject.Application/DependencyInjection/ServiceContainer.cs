using eCommerceProject.Application.Mapping;
using eCommerceProject.Application.Services.Implementations;
using eCommerceProject.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerceProject.Application.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddAplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddProfile<MappingConfig>());
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            return services;
        }
    }
}
