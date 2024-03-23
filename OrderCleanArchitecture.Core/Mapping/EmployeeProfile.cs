using AutoMapper;

namespace OrderCleanArchitecture.Core.Mapping
{
    public partial class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            GetAllEmployeeMapping();
            GetEmployeeByIDMapping();
            AddEmployeeCommand();
            EditEmployeeCommand();
            GetAllCategoryMapping();
            GetCategoryByIdMapping();
            AddCategoryCommands();
            EditCategoryCommand();
            DeleteCategoryCommand();
            GetAllOrderMapping();
            GetOrderByIdMapping();
            AddOrderCommand();
            EditOrderCommand();
            DeleteOrderCommand();
        }
    }
}
