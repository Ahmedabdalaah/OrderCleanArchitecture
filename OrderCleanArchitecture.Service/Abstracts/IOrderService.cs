using OrderCleanArchitecture.Data.Entities;

namespace OrderCleanArchitecture.Service.Abstracts
{
    public interface IOrderService
    {
        public Task<List<Order>> GetOrderAsync();
        public Task<Order> GetOrderByIdAsync(int id);
        public Task<string> AddOrderAsunc(Order order);
        public Task<string> EditOrderAsunc(Order order);
        public Task<Order> SearchOrderAsunc(int id);

        public Task<string> RemoveOrderAsync(Order order);
    }
}
