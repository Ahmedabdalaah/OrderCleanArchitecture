using MediatR;
using OrderCleanArchitecture.Core.Features.Orders.Queries.DTO;

namespace OrderCleanArchitecture.Core.Features.Orders.Queries.Models
{
    public class GetOrderByEmpQuery : IRequest<GetOrderByEmpDTO>
    {
        public int Id { get; set; }
        public GetOrderByEmpQuery(int id)
        {
            Id = id;
        }
    }
}
