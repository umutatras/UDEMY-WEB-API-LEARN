using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Udem.WebApi.Data;
using Udem.WebApi.Interfaces;

namespace Udem.WebApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _productContext;

        public ProductRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<Product> CreateAsync(Product product)
        {
           await _productContext.Products.AddAsync(product);
            await _productContext.SaveChangesAsync();

            return product;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _productContext.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productContext.Products.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var removedEntity = await _productContext.Products.FindAsync(id);
            _productContext.Products.Remove(removedEntity);
            _productContext.SaveChanges();
        }

        public async Task UpdateAsync(Product product)
        {
            var unChangedEntity = await _productContext.Products.FindAsync(product.Id);

            _productContext.Entry(unChangedEntity).CurrentValues.SetValues(product);

            await _productContext.SaveChangesAsync();
           
        }
    }
}
