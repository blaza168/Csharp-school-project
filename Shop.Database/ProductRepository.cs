using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Models;

namespace Shop.Database
{
    public class ProductRepository
    {
        // There is so many filtering options in task, why dont use one filtering function with expression argument ? Cuz that wont be a ladder
        
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<TResult> GetProductsByIds<TResult>(IEnumerable<int> ids, Expression<Func<Product, TResult>> selector)
        {
            return _context.Products
                .Where(x => ids.Contains(x.Id))
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

        public IEnumerable<TResult> GetProductsByCategory<TResult>(int categoryId, Expression<Func<Product, TResult>> selector)
        {
            return _context.Products
                .Where(x => x.CategoryId == categoryId)
                .Select(selector)
                .ToList();
        }
        
        // Price doesnt have maximum value. Use null if dont wanna specify
        public IEnumerable<TResult> GetProductsByPrice<TResult>(int minPrice, int? maxPrice, Expression<Func<Product, TResult>> selector)
        {
            IQueryable<Product> query = _context.Products
                .Where(x => minPrice <= x.Price);

            if (maxPrice != null)
            {
                query = query.Where(x => maxPrice <= x.Price);
            }

            return query.Select(selector).ToList();
        }

        public IEnumerable<TResult> GetProductsByProducer<TResult>(int producerId, Expression<Func<Product, TResult>> selector)
        {
            return _context.Products
                .Where(x => x.ProducerId == producerId)
                .Select(selector)
                .ToList();
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
        
        // expressions
        
        public IEnumerable<TResult> GetProductsByPrice<TResult>(int minPrice,
            Expression<Func<Product, TResult>> selector) =>
            GetProductsByPrice(minPrice, null, selector);
    }
}