using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace UserManagement.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var appAssembly = typeof(ServiceCollectionExtension).Assembly;

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(appAssembly));
            services.AddAutoMapper(appAssembly);
            services.AddValidatorsFromAssembly(appAssembly)
                 .AddFluentValidationAutoValidation();
        }
    }
}