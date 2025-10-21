using eCommerceProject.Domain.Entities;
using eCommerceProject.Domain.Interfaces;
using eCommerceProject.Infrastructure.Data;
using eCommerceProject.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerceProject.Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
                    sqlOptions.EnableRetryOnFailure();
                }),
            ServiceLifetime.Scoped
            );
            services.AddScoped<ICRUD<Product>, CRUDRepository<Product>>();
            services.AddScoped<ICRUD<Category>, CRUDRepository<Category>>();
            return services;
        }
    }
}
