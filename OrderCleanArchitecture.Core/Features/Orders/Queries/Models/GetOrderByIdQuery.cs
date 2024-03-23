using MediatR;
using OrderCleanArchitecture.Core.Features.Orders.Queries.DTO;

namespace OrderCleanArchitecture.Core.Features.Orders.Queries.Models
{
    public class GetOrderByIdQuery : IRequest<GetOrderByIdDTO>
    {
        public int Id { get; set; }
        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
