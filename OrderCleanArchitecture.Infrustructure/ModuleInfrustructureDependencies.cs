using Microsoft.Extensions.DependencyInjection;
using OrderCleanArchitecture.Infrustructure.Abstract;
using OrderCleanArchitecture.Infrustructure.Bases;
using OrderCleanArchitecture.Infrustructure.Repository;

namespace OrderCleanArchitecture.Infrustructure
{
    public static class ModuleInfrustructureDependencies
    {
        public static IServiceCollection AddInfrustructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeRepository, EmployeeRepsitory>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return services;
        }
    }
}
