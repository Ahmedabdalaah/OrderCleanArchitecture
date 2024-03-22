using OrderCleanArchitecture.Data.Entities;
using OrderCleanArchitecture.Infrustructure.Bases;

namespace OrderCleanArchitecture.Infrustructure.Abstract
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        public Task<List<Category>> GetCategoryAsync();

    }
}
