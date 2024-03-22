using MediatR;
using OrderCleanArchitecture.Core.Features.Category.Queries.DTO;

namespace OrderCleanArchitecture.Core.Features.Category.Queries.Models
{
    public class GetAllCategoryQuery : IRequest<List<GetAllCategoryDTOQuery>>
    {
    }
}
