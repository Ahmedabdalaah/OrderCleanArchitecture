using OrderCleanArchitecture.Core.Features.Employes.Commands.Models;
using OrderCleanArchitecture.Data.Entities;

namespace OrderCleanArchitecture.Core.Mapping
{
    public partial class EmployeeProfile
    {
        public void AddEmployeeCommand()
        {
            CreateMap<AddEmployeeCommand, Employee>()
               .ForMember(destinaton => destinaton.CategoryId, option => option
               .MapFrom(source => source.CategoryId));
        }
    }
}
