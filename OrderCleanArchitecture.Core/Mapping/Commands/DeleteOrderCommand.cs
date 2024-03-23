using OrderCleanArchitecture.Core.Features.Orders.Command.Models;
using OrderCleanArchitecture.Data.Entities;

namespace OrderCleanArchitecture.Core.Mapping
{
    public partial class EmployeeProfile
    {
        public void DeleteOrderCommand()
        {
            CreateMap<DeleteOrderCommand, Order>()
                .ForMember(dest => dest.Id, opt => opt
                .MapFrom(src => src.Id));
        }
    }
}
