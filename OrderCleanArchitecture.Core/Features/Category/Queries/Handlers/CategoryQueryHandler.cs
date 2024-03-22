using AutoMapper;
using MediatR;
using OrderCleanArchitecture.Core.Bases.ResponsHandler;
using OrderCleanArchitecture.Core.Features.Category.Queries.DTO;
using OrderCleanArchitecture.Core.Features.Category.Queries.Models;
using OrderCleanArchitecture.Service.Abstracts;

namespace OrderCleanArchitecture.Core.Features.Category.Queries.Handlers
{
    public class CategoryQueryHandler : ResponseHandler,
                                         IRequestHandler<GetAllCategoryQuery, List<GetAllCategoryDTOQuery>>,
                                         IRequestHandler<GetCategoryByIDQuery, GetCategoryByIDDTO>


    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryQueryHandler(ICategoryService categoryService, IMapper mapper)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }
        public async Task<List<GetAllCategoryDTOQuery>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categoryList = await _categoryService.GetCategoryAsync();
            var categoryMapper = _mapper.Map<List<GetAllCategoryDTOQuery>>(categoryList);
            return categoryMapper;
        }

        public async Task<GetCategoryByIDDTO> Handle(GetCategoryByIDQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetCategoryByIdAsync(request.Id);
            var categoryMapper = _mapper.Map<GetCategoryByIDDTO>(category);
            return categoryMapper;
        }
    }
}
