using eCommerceProject.Domain.Entities;
using eCommerceProject.Domain.Interfaces;
using eCommerceProject.Infrastructure.Data;
using eCommerceProject.Infrastructure.Middleware;
using eCommerceProject.Infrastructure.Repositories;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

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
                    sqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.GetName().Name);
                    sqlOptions.EnableRetryOnFailure();
                }).UseExceptionProcessor(),
            ServiceLifetime.Scoped
            );
            services.AddScoped<ICRUD<Product>, CRUDRepository<Product>>();
            services.AddScoped<ICRUD<Category>, CRUDRepository<Category>>();
            return services;
        }

        public static IApplicationBuilder UseInfrastructureService(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            return app;
        }
    }
}
