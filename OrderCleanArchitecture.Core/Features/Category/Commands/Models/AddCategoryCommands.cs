using MediatR;

namespace OrderCleanArchitecture.Core.Features.Category.Commands.Models
{
    public class AddCategoryCommands : IRequest<string>
    {
        public string Name { get; set; }
    }
}
