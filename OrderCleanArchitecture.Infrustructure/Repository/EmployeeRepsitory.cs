using Microsoft.EntityFrameworkCore;
using OrderCleanArchitecture.Data.Entities;
using OrderCleanArchitecture.Infrustructure.Abstract;
using OrderCleanArchitecture.Infrustructure.Bases;
using OrderCleanArchitecture.Infrustructure.Context;

namespace OrderCleanArchitecture.Infrustructure.Repository
{
    public class EmployeeRepsitory : GenericRepository<Employee>, IEmployeeRepository
    {

        #region Fields
        private readonly DbSet<Employee> _employeeSet;
        #endregion
        #region Constructor
        public EmployeeRepsitory(AppDbContext context) : base(context)
        {
            _employeeSet = context.Set<Employee>();
        }
        #endregion
        #region Handle functions
        public async Task<List<Employee>> GetEmployeeAsync()
        {
            return await _employeeSet.Include(x => x.Category).ToListAsync();
        }
        #endregion
    }
}
