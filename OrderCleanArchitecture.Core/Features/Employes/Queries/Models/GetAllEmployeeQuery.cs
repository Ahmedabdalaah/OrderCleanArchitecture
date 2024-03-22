using MediatR;
using OrderCleanArchitecture.Core.Features.Employes.Queries.DTO;

namespace OrderCleanArchitecture.Core.Features.Employes.Queries.Models
{
    public class GetAllEmployeeQuery : IRequest<List<GetAllEmployeeDTO>>
    {

    }
}
