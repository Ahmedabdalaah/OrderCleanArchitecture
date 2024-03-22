using OrderCleanArchitecture.Data.Entities;
using OrderCleanArchitecture.Infrustructure.Abstract;
using OrderCleanArchitecture.Service.Abstracts;

namespace OrderCleanArchitecture.Service.Implementations
{
    public class CategryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        public CategryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> AddCategoryAsunc(Category category)
        {
            await _repo.AddAsync(category);
            return "Success";
        }

        public async Task<string> EditCategoryAsunc(Category category)
        {
            await _repo.UpdateAsync(category);
            return "Success";
        }

        public async Task<List<Category>> GetCategoryAsync()
        {
            return await _repo.GetAll();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var category = await _repo.GetByIdAsync(id);
            return category;
        }

        public async Task<bool> IsNameExist(string name)
        {
            var category = _repo.GetTableAsTracking().Where(x => x.Name.Equals(name)).FirstOrDefault();
            if (category == null)
            {
                return false;
            }
            return true;
        }

        public async Task<string> RemoveCategoryAsync(Category category)
        {
            await _repo.DeleteAsync(category);
            return "Success";
        }
    }
}
