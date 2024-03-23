using MediatR;

namespace OrderCleanArchitecture.Core.Features.Orders.Command.Models
{
    public class AddOrderCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }
    }
}
