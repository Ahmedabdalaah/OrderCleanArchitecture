using Microsoft.Extensions.DependencyInjection;
using OrderCleanArchitecture.Infrustructure.Bases;

namespace OrderCleanArchitecture.Infrustructure
{
    public static class ModuleInfrustructureDependencies
    {
        public static IServiceCollection AddInfrustructureDependencies(this IServiceCollection services)
        {
            services.AddTransient(typeof(GenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
