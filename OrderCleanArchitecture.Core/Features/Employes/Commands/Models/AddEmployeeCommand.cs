using MediatR;

namespace OrderCleanArchitecture.Core.Features.Employes.Commands.Models
{
    public class AddEmployeeCommand : IRequest<string>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CategoryId { get; set; }
    }
}
