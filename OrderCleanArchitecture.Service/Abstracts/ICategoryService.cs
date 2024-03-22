using OrderCleanArchitecture.Data.Entities;

namespace OrderCleanArchitecture.Service.Abstracts
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetCategoryAsync();
        public Task<Category> GetCategoryByIdAsync(int id);
        public Task<string> AddCategoryAsunc(Category category);
        public Task<string> EditCategoryAsunc(Category category);
        public Task<string> RemoveCategoryAsync(Category category);
        public Task<Boolean> IsNameExist(string name);
    }
}
