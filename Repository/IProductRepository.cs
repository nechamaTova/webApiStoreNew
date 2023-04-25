using Entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<Product> addProduct(Product product);
        Task<Product> GetProductById(int id);
        Task<IEnumerable<Product>> GetProducts();
    }
}