using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        Store214089435Context _store214089435;

        public ProductRepository(Store214089435Context store214104465)
        {
            this._store214089435 = store214104465;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _store214089435.Products.Include(p => p.Category).ToListAsync();
        }
        public async Task<Product> GetProductById(int id)
        {
            Product? product = await _store214089435.Products.FindAsync(id);//.Include(p => p.Category);
            return product != null ? product : null;
        }
        public async Task<Product> addProduct(Product product)
        {
            await _store214089435.Products.AddAsync(product);
            await _store214089435.SaveChangesAsync();
            return product;
        }
    }
}
