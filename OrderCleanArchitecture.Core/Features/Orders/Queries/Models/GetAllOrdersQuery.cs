using MediatR;
using OrderCleanArchitecture.Core.Features.Orders.Queries.DTO;

namespace OrderCleanArchitecture.Core.Features.Orders.Queries.Models
{
    public class GetAllOrdersQuery : IRequest<List<GetAllOrderDTO>>
    {
    }
}
