using Shop.Application.Category.ViewModels;
using Shop.Database.Repositories;
using System.Collections.Generic;

namespace Shop.Application.Category
{
    [Service]
    public class ListCategories
    {
        private readonly CategoryRepository _categoryRepository;

        public ListCategories(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<CategoryViewModel> Do()
        {
            return _categoryRepository.GetCategories(selector: GetCategory.CategoryMapper);
        }
    }
}
