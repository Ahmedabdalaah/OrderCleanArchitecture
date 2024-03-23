using MediatR;

namespace OrderCleanArchitecture.Core.Features.Category.Queries.Models
{
    public class DeleteCategoryCommand : IRequest<string>
    {
        public int Id { get; set; }
        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
