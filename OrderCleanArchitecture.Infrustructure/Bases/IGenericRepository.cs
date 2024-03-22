using Microsoft.EntityFrameworkCore.Storage;

namespace OrderCleanArchitecture.Infrustructure.Bases
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        public IQueryable<T> GetTableAsTracking();
        Task<T> GetByIdAsync(int id);
        IDbContextTransaction BeginTransaction();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        void Commit();
        void RollBack();
    }
}
