using BrechoApi.Application.DTOs.Product;
using BrechoApi.Application.Interfaces;
using BrechoApi.Domain.Entities;

namespace BrechoApi.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> CreateAsync(CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Category = dto.Category,
                Price = dto.Price,
            };
            return await _productRepository.CreateAsync(product);
        }
        public async Task<List<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }
        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _productRepository.GetByIdAsync(id);

        }
        public async Task<Product?> UpdateAsync(Guid id, UpdateProductDto dto)
        {
            var product = new Product
            {
                Id = id,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Category = dto.Category
            };
            return await _productRepository.UpdateAsync(product);
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _productRepository.DeleteAsync(id);
        }
    }

}
