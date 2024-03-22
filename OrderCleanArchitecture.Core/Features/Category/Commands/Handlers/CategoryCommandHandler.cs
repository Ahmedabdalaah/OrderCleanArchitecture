using AutoMapper;
using MediatR;
using OrderCleanArchitecture.Core.Bases.ResponsHandler;
using OrderCleanArchitecture.Core.Features.Category.Commands.Models;
using OrderCleanArchitecture.Service.Abstracts;

namespace OrderCleanArchitecture.Core.Features.Category.Commands.Handlers
{
    public class CategoryCommandHandler : ResponseHandler,
                                        IRequestHandler<AddCategoryCommands, string>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryCommandHandler(IMapper mapper, ICategoryService categoryService)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<string> Handle(AddCategoryCommands request, CancellationToken cancellationToken)
        {
            // mapping between request and category
            var categoryMapper = _mapper.Map<OrderCleanArchitecture.Data.Entities.Category>(request);
            //add
            var result = await _categoryService.AddCategoryAsunc(categoryMapper);
            return "Success";
        }
    }
}
