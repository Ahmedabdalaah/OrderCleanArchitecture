using Microsoft.EntityFrameworkCore;
using OrderCleanArchitecture.Data.Entities;
using OrderCleanArchitecture.Infrustructure.Abstract;
using OrderCleanArchitecture.Service.Abstracts;

namespace OrderCleanArchitecture.Service.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        #region Fields
        private readonly IEmployeeRepository _repo;
        #endregion
        #region Constructor
        public EmployeeService(IEmployeeRepository repo)
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

        public async Task<List<Employee>> GetEmployeeAsync()
        {
            return await _repo.GetEmployeeAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<bool> IsNameExist(string name)
        {
            var employee = _repo.GetTableAsTracking().Where(x => x.Name.Equals(name)).FirstOrDefault();
            if (employee == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> IsNameExistExclude(string name, int id)
        {
            var employee = await _repo.GetTableAsTracking().Where(x => x.Name.Equals(name) & !x.Id.Equals(id)).FirstOrDefaultAsync();
            if (employee == null)
            {
                return false;
            }
            return true;

        }

        public async Task<string> RemoveEmployeeAsync(Employee employee)
        {
            await _repo.DeleteAsync(employee);
            return "Success";
        }
        #endregion
    }
}
