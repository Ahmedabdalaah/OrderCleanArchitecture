using OrderCleanArchitecture.Data.Entities;
using OrderCleanArchitecture.Infrustructure.Bases;
using OrderCleanArchitecture.Service.Abstracts;

namespace OrderCleanArchitecture.Service.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        #region Fields
        private readonly IGenericRepository<Employee> _repo;
        #endregion
        #region Constructor
        public EmployeeService(IGenericRepository<Employee> repo)
        {
            _repo = repo;
        }
        #endregion
        #region Handle Functions
        public async Task<string> AddEmployeeAsunc(Employee employee)
        {
            await _repo.AddAsync(employee);
            return "Success";
        }

        public async Task<string> EditEmployeeAsunc(Employee employee)
        {
            await _repo.UpdateAsync(employee);
            return "Success";
        }

        public async Task<IEnumerable<Employee>> GetEmployeeAsync()
        {
            return await _repo.GetAll();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public Task<bool> IsNameExist(string name)
        {
            var employee = _repo.GetTableAsTracking().Where(t => t.Name.Equals(name)).FirstOrDefault();
            throw new NotImplementedException();

        }

        public Task<bool> IsNameExistExclude(string name, int id)
        {
            throw new NotImplementedException();

        }

        public Task<string> RemoveEmployeeAsync(Employee employee)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
