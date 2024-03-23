using Microsoft.EntityFrameworkCore;
using OrderCleanArchitecture.Data.Entities;
using OrderCleanArchitecture.Infrustructure.Abstract;
using OrderCleanArchitecture.Infrustructure.Bases;
using OrderCleanArchitecture.Infrustructure.Context;

namespace OrderCleanArchitecture.Infrustructure.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        #region Fields
        private readonly DbSet<Order> _orderSet;
        #endregion
        #region Constructor
        public OrderRepository(AppDbContext context) : base(context)
        {
            _orderSet = context.Set<Order>();
        }
        #endregion
        #region Handle functions
        public async Task<List<Order>> GetAllOrderAsync()
        {
            var orders = await _orderSet.ToListAsync();
            return orders;
        }
        #endregion
    }
}
