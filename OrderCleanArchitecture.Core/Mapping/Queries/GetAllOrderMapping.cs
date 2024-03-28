using OrderCleanArchitecture.Core.Features.Orders.Queries.DTO;
using OrderCleanArchitecture.Data.Entities;

namespace OrderCleanArchitecture.Core.Mapping
{
    public partial class EmployeeProfile
    {
        public void GetAllOrderMapping()
        {
            CreateMap<Order, GetAllOrderDTO>()
                .ForMember(dest => dest.EmployeeId,
                option => option.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Id,
                option => option.MapFrom(src => src.Id));
        }
    }
}
