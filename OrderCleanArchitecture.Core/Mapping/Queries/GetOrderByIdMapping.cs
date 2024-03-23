using OrderCleanArchitecture.Core.Features.Orders.Queries.DTO;
using OrderCleanArchitecture.Data.Entities;

namespace OrderCleanArchitecture.Core.Mapping
{
    public partial class EmployeeProfile
    {
        public void GetOrderByIdMapping()
        {
            CreateMap<Order, GetOrderByIdDTO>()
                .ForMember(dest => dest.Describtion,
                option => option.MapFrom(src => src.Description))
                .ForMember(dest => dest.EmployeeName,
                option => option.MapFrom(src => src.Employee.Name));
        }
    }
}
