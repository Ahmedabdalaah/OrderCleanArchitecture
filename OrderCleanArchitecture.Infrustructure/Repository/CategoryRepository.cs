using Microsoft.EntityFrameworkCore;
using OrderCleanArchitecture.Data.Entities;
using OrderCleanArchitecture.Infrustructure.Abstract;
using OrderCleanArchitecture.Infrustructure.Bases;
using OrderCleanArchitecture.Infrustructure.Context;

namespace OrderCleanArchitecture.Infrustructure.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        #region Fields
        private readonly DbSet<Category> _categorySet;
        #endregion
        #region Constructor
        public CategoryRepository(AppDbContext context) : base(context)
        {
            _categorySet = context.Set<Category>();
        }
        #endregion
        #region Handle functions
        public async Task<List<Category>> GetCategoryAsync()
        {
            return await _categorySet.ToListAsync();
        }
        #endregion
    }
}
