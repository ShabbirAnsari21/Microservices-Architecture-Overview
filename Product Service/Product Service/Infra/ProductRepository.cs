using Microsoft.EntityFrameworkCore;
using Product_Service.Entity;

namespace Product_Service.Infra
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.ProductTbl.FindAsync(id);
        }

        public async Task AddProduct(Product product)
        {
            _context.ProductTbl.Add(product);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Product>> GetAllProduct()
        {
            return await _context.ProductTbl.ToListAsync();
        }
    }

}
