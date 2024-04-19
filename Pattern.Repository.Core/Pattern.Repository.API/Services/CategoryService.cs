using Pattern.Repository.Core.BaseRepository;
using Pattern.Repository.Core.Models;

namespace Pattern.Repository.API.Services
{
    public class CategoryService
    {
        private readonly IBaseRepository<CategoryDTO> _categoryRepository;

        public CategoryService(IBaseRepository<CategoryDTO> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<CategoryDTO> GetByIdAsync(int Id)
        {
            return await _categoryRepository.GetByIdAsync(Id);
        }
    }
}
