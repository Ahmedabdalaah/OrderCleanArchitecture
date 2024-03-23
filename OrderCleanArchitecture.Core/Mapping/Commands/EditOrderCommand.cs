using OrderCleanArchitecture.Core.Features.Orders.Command.Models;
using OrderCleanArchitecture.Data.Entities;

namespace OrderCleanArchitecture.Core.Mapping
{
    public partial class EmployeeProfile
    {
        public void EditOrderCommand()
        {
            CreateMap<EditOrderCommands, Order>()
             .ForMember(destinaton => destinaton.Id, option => option
             .MapFrom(source => source.Id));
        }
    }
}
