using System.Threading.Tasks;
using Shop.Application.Category.Requests;
using Shop.Database.Repositories;

namespace Shop.Application.Category
{
    [Service]
    public class CreateCategory
    {
        private readonly CategoryRepository _categoryRepository;
    
        public CreateCategory(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<int> Do(CreateCategoryRequest request)
        {
            return _categoryRepository.CreateCategory(new Domain.Models.Category
            {
                Name = request.Name
            });
        }
    }
}
