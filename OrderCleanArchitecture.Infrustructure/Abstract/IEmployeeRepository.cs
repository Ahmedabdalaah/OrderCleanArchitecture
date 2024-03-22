using OrderCleanArchitecture.Data.Entities;
using OrderCleanArchitecture.Infrustructure.Bases;

namespace OrderCleanArchitecture.Infrustructure.Abstract
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        public Task<List<Employee>> GetEmployeeAsync();

    }
}
