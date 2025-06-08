using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserManagement.Web.Services.Abstractions;
using UserManagement.Web.Services.Options;

namespace UserManagement.Web.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void AddUserHttpServices(this IServiceCollection services, IConfiguration configuration)
        {
            string baseAddress = configuration.GetSection(ConfigurarionOptions.SectionName).GetSection("ApiUrl").Value;

            services.Configure<ConfigurarionOptions>(configuration.GetSection(ConfigurarionOptions.SectionName));
            services.AddHttpClient<IUserHttpService, UserHttpService>((provider, opt) => { opt.BaseAddress = new Uri(baseAddress); });
            services.AddHttpClient<IGroupHttpService, GroupHttpService>((provider, opt) => { opt.BaseAddress = new Uri(baseAddress); });
        }
    }
}
