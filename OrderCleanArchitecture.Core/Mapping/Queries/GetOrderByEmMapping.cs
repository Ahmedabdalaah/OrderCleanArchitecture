using OrderCleanArchitecture.Core.Features.Orders.Queries.DTO;
using OrderCleanArchitecture.Data.Entities;

namespace OrderCleanArchitecture.Core.Mapping
{
    public partial class EmployeeProfile
    {
        public void GetOrderByEmMapping()
        {
            CreateMap<Order, GetOrderByEmpDTO>()
                .ForMember(dest => dest.EmployeeId, option => option
                .MapFrom(src => src.EmployeeId));
        }
    }
}
