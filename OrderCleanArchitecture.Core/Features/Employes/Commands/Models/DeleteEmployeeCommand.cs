using MediatR;

namespace OrderCleanArchitecture.Core.Features.Employes.Commands.Models
{
    public class DeleteEmployeeCommand : IRequest<string>
    {
        public int Id { get; set; }
        public DeleteEmployeeCommand(int id)
        {
            Id = id;
        }
    }
}
