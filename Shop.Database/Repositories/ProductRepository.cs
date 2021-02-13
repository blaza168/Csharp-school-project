using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Shop.Domain.Models;

namespace Shop.Database.Repositories
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TResult> GetProducts<TResult>(Expression<Func<Product, TResult>> selector)
        {
            return _context.Products
                .Select(selector)
                .ToList();
        }

        public Task<int> CreateProduct(Product product)
        {
            _context.Products.Add(product);

            return _context.SaveChangesAsync();
        }

        public Task<int> UpdateProduct(Product product)
        {
            _context.Products.Update(product);

            return _context.SaveChangesAsync();
        }

        public Task<int> DeleteProduct(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);
            
            if (product == null)
                return null; // or throw exception
            
            _context.Products.Remove(product);

            return _context.SaveChangesAsync();
        }

        public IEnumerable<TResult> GetProducts<TResult>(Func<Product, bool> condition, Expression<Func<Product, TResult>> selector)
        {
            return _context.Products
                .Where(x => condition(x))
                .Select(selector)
                .ToList();
        }
        
        public TResult GetProductById<TResult>(int id, Expression<Func<Product, TResult>> selector)
        {
            return _context.Products
                .Where(x => x.Id == id)
                .Select(selector)
                .FirstOrDefault();
        }

        // Price doesnt have maximum value. Use null if dont wanna specify
        public IEnumerable<TResult> GetProductsByPrice<TResult>(decimal? minPrice, decimal? maxPrice, Expression<Func<Product, TResult>> selector)
        {
            IQueryable<Product> query = _context.Products
                .Where(x => minPrice <= x.Price);

            if (maxPrice != null)
            {
                query = query.Where(x => maxPrice <= x.Price);
            }

            return query.Select(selector).ToList();
        }

        public IEnumerable<TResult> GetProductsByQuantity<TResult>(int minQuantity, int? maxQuantity, Expression<Func<Product, TResult>> selector)
        {
            IQueryable<Product> query = _context.Products
                .Where(x => x.Qty >= minQuantity);

            if (maxQuantity != null)
            {
                query = query.Where(x => x.Qty <= maxQuantity);
            }

            return query.Select(selector).ToList();
        }

        public IEnumerable<TResult> GetProductsByPrice<TResult>(int minPrice, Expression<Func<Product, TResult>> selector)
        {
            return GetProductsByPrice(minPrice, null, selector);
        }

        public IEnumerable<TResult> GetProductsByQuantity<TResult>(int minQuantity,
            Expression<Func<Product, TResult>> selector)
        {
            return GetProductsByQuantity(minQuantity, null, selector);
        }
    }
}