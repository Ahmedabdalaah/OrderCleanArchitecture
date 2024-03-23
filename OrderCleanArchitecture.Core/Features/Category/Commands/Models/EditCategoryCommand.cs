using MediatR;

namespace OrderCleanArchitecture.Core.Features.Category.Commands.Models
{
    public class EditCategoryCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
