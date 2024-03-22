using OrderCleanArchitecture.Data.Entities;

namespace OrderCleanArchitecture.Service.Abstracts
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<Employee>> GetEmployeeAsync();
        public Task<Employee> GetEmployeeByIdAsync(int id);
        public Task<string> AddEmployeeAsunc(Employee employee);
        public Task<string> EditEmployeeAsunc(Employee employee);
        public Task<string> RemoveEmployeeAsync(Employee employee);
        public Task<Boolean> IsNameExist(string name);
        public Task<Boolean> IsNameExistExclude(string name, int id);


    }
}
