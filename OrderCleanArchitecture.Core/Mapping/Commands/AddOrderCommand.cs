using OrderCleanArchitecture.Core.Features.Orders.Command.Models;
using OrderCleanArchitecture.Data.Entities;

namespace OrderCleanArchitecture.Core.Mapping
{
    public partial class EmployeeProfile
    {
        public void AddOrderCommand()
        {
            CreateMap<AddOrderCommand, Order>()
               .ForMember(destinaton => destinaton.EmployeeId, option => option
               .MapFrom(source => source.EmployeeId));
        }
    }
}
