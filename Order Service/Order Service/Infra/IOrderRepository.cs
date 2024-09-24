using Order_Service.Entity;

namespace Order_Service.Infra
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrder(Order order);
        Task<List<Order>> GetAll();
        Task<Order?> GetById(int id);
    }
}
