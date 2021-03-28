

using Shop.Application.Category.ViewModels;
using Shop.Database.Repositories;
using System;
using System.Linq.Expressions;

namespace Shop.Application.Category
{
    [Service]
    public class GetCategory
    {
        public static readonly Expression<Func<Domain.Models.Category, CategoryViewModel>> CategoryMapper = p =>
            new CategoryViewModel
            {
                Id = p.Id,
                Name = p.Name
            };

        private readonly CategoryRepository _categoryRepository;

        public GetCategory(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public CategoryViewModel Do(int categoryId)
        {
            return _categoryRepository.GetCategoryById(categoryId, CategoryMapper);
        }
    }
}
