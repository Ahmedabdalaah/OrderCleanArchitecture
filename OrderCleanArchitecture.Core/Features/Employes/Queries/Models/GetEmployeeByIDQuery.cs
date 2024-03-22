using MediatR;
using OrderCleanArchitecture.Core.Features.Employes.Queries.DTO;

namespace OrderCleanArchitecture.Core.Features.Employes.Queries.Models
{
    public class GetEmployeeByIDQuery : IRequest<GetEmployeeIDDto>
    {
        public int Id { get; set; }
        public GetEmployeeByIDQuery(int id)
        {
            Id = id;
        }
    }
}
