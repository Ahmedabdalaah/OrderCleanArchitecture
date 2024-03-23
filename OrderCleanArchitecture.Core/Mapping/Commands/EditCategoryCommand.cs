using OrderCleanArchitecture.Core.Features.Category.Commands.Models;
using OrderCleanArchitecture.Data.Entities;

namespace OrderCleanArchitecture.Core.Mapping
{
    public partial class EmployeeProfile
    {
        public void EditCategoryCommand()
        {
            CreateMap<EditCategoryCommand, Category>()
                .ForMember(dest => dest.Id, opt => opt
                .MapFrom(src => src.Id));
        }
    }
}
