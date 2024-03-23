using MediatR;

namespace OrderCleanArchitecture.Core.Features.Orders.Command.Models
{
    public class EditOrderCommands : IRequest<string>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }
    }
}
