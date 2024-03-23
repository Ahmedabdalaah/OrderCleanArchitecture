using MediatR;

namespace OrderCleanArchitecture.Core.Features.Orders.Command.Models
{
    public class DeleteOrderCommand : IRequest<string>
    {
        public int Id { get; set; }
        public DeleteOrderCommand(int id)
        {
            Id = id;
        }
    }
}
