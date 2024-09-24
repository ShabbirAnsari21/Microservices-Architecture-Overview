using Product_Service.Entity;

namespace Product_Service.Infra
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(int id);
        Task AddProduct(Product product);
        Task<List<Product>> GetAllProduct();
    }
}
