using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Database.Extensions;
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

        public TResult GetRatingById<TResult>(int id, Expression<Func<Rating, TResult>> selector)
        {
            return _context.Ratings
                .Where(x => x.Id == id)
                //.Include(x => x.File)
                .Select(selector)
                .FirstOrDefault();
        }

        public IEnumerable<TResult> GetRatings<TResult>(Expression<Func<Rating, TResult>> selector)
        {
            return _context.Ratings
                .Select(selector)
                .ToList();
        }

        public Task<int> CreateRating(Rating rating)
        {
            _context.Ratings.Add(rating);

            return _context.SaveChangesAsync();
        }

        public Task<int> DeleteRating(int id)
        {
            Rating rating = _context.Ratings.FirstOrDefault(x => x.Id == id);

            if (rating == null)
                return Task.FromResult(0);

            _context.Ratings.Remove(rating);

            return _context.SaveChangesAsync();
        }

        public Task<int> UpdateRatingPartial(Rating rating)
        {
            _context.PartialUpdate(rating);

            return _context.SaveChangesAsync();
        }
    }
}