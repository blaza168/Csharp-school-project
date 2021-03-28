using Microsoft.EntityFrameworkCore;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Shop.Database.Repositories
{
    public class CategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TResult> GetCategories<TResult>(Expression<Func<Category, TResult>> selector)
        {
            return _context.Categories
                .Select(selector)
                .ToList();
        }

        public Task<int> CreateCategory(Category category)
        {
            _context.Categories.Add(category);

            return _context.SaveChangesAsync();
        }

        public TResult GetCategoryById<TResult>(int id, Expression<Func<Category, TResult>> selector)
        {
            return _context.Categories
                .Where(x => x.Id == id)
                .Select(selector)
                .FirstOrDefault();
        }

        public Task<int> DeleteCategory(int id)
        {
            Category category = _context.Categories.FirstOrDefault(x => x.Id == id);

            if (category == null)
                return Task.FromResult(0);

            _context.Categories.Remove(category);

            return _context.SaveChangesAsync();
        }
    }
}
