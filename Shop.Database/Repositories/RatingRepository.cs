using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Shop.Database.Repositories.QueryObjects;
using Shop.Domain.Models;

namespace Shop.Database.Repositories
{
    public class RatingRepository
    {
        private readonly ApplicationDbContext _context;

        public RatingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TResult> GetRatingsForProduct<TResult>(int productId, Expression<Func<Rating, TResult>> selector)
        {
            return _context.Ratings
                .Where(x => x.ProductId == productId)
                .Select(selector)
                .ToList();
        }
        
        public IEnumerable<TResult> GetProductIdsByTotalRating<TResult>(decimal minRating, decimal maxRating, Expression<Func<ProductRatingsGroup, TResult>> selector)
        {
            return _context.Ratings
                .GroupBy(x => x.ProductId)
                .Select(r => new ProductRatingsGroup{ProductId = r.Key, AverageRating = r.Average(row => row.NumericRating)})
                .Where(g => g.AverageRating >= minRating && g.AverageRating <= maxRating)
                .Select(selector)
                .ToList();
        }
    }
}