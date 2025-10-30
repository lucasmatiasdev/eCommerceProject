using eCommerceProject.Application.Mapping;
using eCommerceProject.Application.Services.Implementations;
using eCommerceProject.Application.Services.Implementations.Authentication;
using eCommerceProject.Application.Services.Interfaces;
using eCommerceProject.Application.Services.Interfaces.Authentication;
using eCommerceProject.Application.Services.Interfaces.Logging;
using eCommerceProject.Application.Validations;
using eCommerceProject.Application.Validations.Authentication;
using FluentValidation;
using FluentValidation.AspNetCore;
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
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();
            services.AddScoped<IValidationService, ValidationService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}
