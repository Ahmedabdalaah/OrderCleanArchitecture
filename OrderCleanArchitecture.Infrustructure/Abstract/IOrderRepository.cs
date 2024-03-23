using OrderCleanArchitecture.Data.Entities;
using OrderCleanArchitecture.Infrustructure.Bases;

namespace OrderCleanArchitecture.Infrustructure.Abstract
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        public Task<List<Order>> GetAllOrderAsync();
    }
}
