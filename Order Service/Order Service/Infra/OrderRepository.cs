using Microsoft.EntityFrameworkCore;
using Order_Service.Entity;

namespace Order_Service.Infra
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context;

        public OrderRepository(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            await _context.OrderTbl.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }
        
        public async Task<List<Order>> GetAll()
        {
            return await _context.OrderTbl.ToListAsync();
        }
        public async Task<Order?> GetById(int id)
        {
            return await _context.OrderTbl.Where(x=> x.OrderId == id).FirstOrDefaultAsync();
        }
    }
}
