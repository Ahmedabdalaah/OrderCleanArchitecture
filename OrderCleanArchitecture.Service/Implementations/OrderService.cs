using Microsoft.EntityFrameworkCore;
using OrderCleanArchitecture.Data.Entities;
using OrderCleanArchitecture.Infrustructure.Abstract;
using OrderCleanArchitecture.Service.Abstracts;

namespace OrderCleanArchitecture.Service.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;
        public OrderService(IOrderRepository repo)
        {
            _repo = repo;
        }
        public async Task<string> AddOrderAsunc(Order order)
        {
            await _repo.AddAsync(order);
            return "Success";
        }

        public async Task<string> EditOrderAsunc(Order order)
        {
            await _repo.UpdateAsync(order);
            return "Success";
        }

        public Task<List<Order>> GetOrderAsync()
        {
            return _repo.GetAll();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _repo.GetTableAsTracking().Include(x => x.Employee)
                               .Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }


        public async Task<string> RemoveOrderAsync(Order order)
        {
            await _repo.DeleteAsync(order);
            return "Success";
        }
    }
}
