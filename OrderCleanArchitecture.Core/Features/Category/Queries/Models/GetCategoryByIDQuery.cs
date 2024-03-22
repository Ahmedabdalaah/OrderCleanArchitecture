using MediatR;
using OrderCleanArchitecture.Core.Features.Category.Queries.DTO;

namespace OrderCleanArchitecture.Core.Features.Category.Queries.Models
{
    public class GetCategoryByIDQuery : IRequest<GetCategoryByIDDTO>
    {
        public int Id { get; set; }
        public GetCategoryByIDQuery(int id)
        {
            Id = id;
        }
    }
}
