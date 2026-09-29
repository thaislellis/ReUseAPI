using ReUseApi.Application.Interfaces;
using ReUseApi.Domain.Entities;
using ReUseApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ReUseApi.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product?> UpdateAsync(Product product)
        {
            var existingProduct = await _context.Products.FindAsync(product.Id);

            if (existingProduct == null)
            {
                return null;
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Category = product.Category;

            await _context.SaveChangesAsync();

            return existingProduct;
        }
         public async Task<bool> DeleteAsync(Guid id)
        {
            var existingProduct = await _context.Products.FindAsync(id);
           
            if (existingProduct == null)
            {
                return false;
            }

            _context.Products.Remove(existingProduct);
            
            await _context.SaveChangesAsync();
            
            return true;
        }

    }
}
