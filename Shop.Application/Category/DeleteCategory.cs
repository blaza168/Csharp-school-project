using Shop.Database.Repositories;
using System.Threading.Tasks;

namespace Shop.Application.Category
{
    [Service]
    public class DeleteCategory
    {
        private readonly CategoryRepository _categoryRepository;

        public DeleteCategory(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<int> Do(int categoryId)
        {
            return _categoryRepository.DeleteCategory(categoryId);
        }
    }
}
