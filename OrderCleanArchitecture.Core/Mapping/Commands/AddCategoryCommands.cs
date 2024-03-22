using OrderCleanArchitecture.Core.Features.Category.Commands.Models;
using OrderCleanArchitecture.Data.Entities;

namespace OrderCleanArchitecture.Core.Mapping
{
    public partial class EmployeeProfile
    {
        public void AddCategoryCommands()
        {
            CreateMap<AddCategoryCommands, Category>()
               .ForMember(destinaton => destinaton.Name, option => option
               .MapFrom(source => source.Name));
        }
    }
}
