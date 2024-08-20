using EcoTech.Repositories.implementations;
using EcoTech.Repositories.Interfaces;

namespace EcoTech.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IClientUserRepository, ClientUserRepository>();

            return services;
        }
    }
}
