using OrderCleanArchitecture.Core.Features.Employes.Queries.DTO;
using OrderCleanArchitecture.Data.Entities;

namespace OrderCleanArchitecture.Core.Mapping
{
    public partial class EmployeeProfile
    {
        public void GetEmployeeByIDMapping()
        {
            CreateMap<Employee, GetEmployeeIDDto>()
                .ForMember(dest => dest.CategoryId, option => option
                .MapFrom(src => src.CategoryId));
        }
    }
}

