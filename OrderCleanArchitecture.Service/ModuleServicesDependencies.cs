using Microsoft.Extensions.DependencyInjection;
using OrderCleanArchitecture.Service.Abstracts;
using OrderCleanArchitecture.Service.Implementations;

namespace OrderCleanArchitecture.Service
{
    public static class ModuleServicesDependencies
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
    {
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<ICategoryService, CategryService>();
            services.AddTransient<IOrderService, OrderService>();
            return services;
        }
    }
}
