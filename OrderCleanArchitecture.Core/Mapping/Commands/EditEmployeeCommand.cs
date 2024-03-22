using OrderCleanArchitecture.Core.Features.Employes.Commands.Models;
using OrderCleanArchitecture.Data.Entities;

namespace OrderCleanArchitecture.Core.Mapping
{
    public partial class EmployeeProfile
    {
        public void EditEmployeeCommand()
        {
            CreateMap<EditEmployeeCommand, Employee>()
             .ForMember(destinaton => destinaton.CategoryId, option => option
             .MapFrom(source => source.CategoryId));
        }
    }
}
