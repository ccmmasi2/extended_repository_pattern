using Pattern.Repository.Core.BaseRepository;
using Pattern.Repository.Core.Models;

namespace Pattern.Repository.API.Services
{
    public class ProductService
    {
        private readonly IBaseRepository<ProductDTO> _productRepository;

        public ProductService(IBaseRepository<ProductDTO> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<ProductDTO> GetByIdAsync(int Id)
        {
            return await _productRepository.GetByIdAsync(Id);
        }
    }
}
