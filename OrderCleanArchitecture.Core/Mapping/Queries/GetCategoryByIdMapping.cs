using OrderCleanArchitecture.Core.Features.Category.Queries.DTO;
using OrderCleanArchitecture.Data.Entities;

namespace OrderCleanArchitecture.Core.Mapping
{
    public partial class EmployeeProfile
    {
        public void GetCategoryByIdMapping()
        {
            CreateMap<Category, GetCategoryByIDDTO>()
                .ForMember(dest => dest.Name, option => option
                .MapFrom(src => src.Name));
        }
    }
}
