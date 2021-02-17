using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Database.Extensions;
using Shop.Domain.Models;

namespace Shop.Database.Repositories
{
    public class ProducerRepository
    {
        private readonly ApplicationDbContext _context;

        public ProducerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TResult> GetProducers<TResult>(Expression<Func<Producer, TResult>> selector)
        {
            return _context.Producers
                .Select(selector)
                .ToList();
        }

        public Task<int> CreateProducer(Producer producer)
        {
            _context.Producers.Add(producer);

            return _context.SaveChangesAsync();
        }

        public Task<int> UpdateProducer(Producer producer)
        {
            _context.Producers.Update(producer);

            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update only fields that are not NULL
        /// </summary>
        /// <param name="producer">Entity to be updated</param>
        /// <returns>Id</returns>
        public Task<int> UpdateProducerPartial(Producer producer)
        {
            _context.PartialUpdate(producer);
            
            return _context.SaveChangesAsync();
        }

        public Task<int> DeleteProducer(int id)
        {
            Producer producer = _context.Producers.FirstOrDefault(x => x.Id == id);

            if (producer == null)
                return null;

            _context.Producers.Remove(producer);

            return _context.SaveChangesAsync();
        }

        public TResult GetProducerById<TResult>(int id, Expression<Func<Producer, TResult>> selector)
        {
            return _context.Producers
                .Where(x => x.Id == id)
                .Include(x => x.File)
                .Select(selector)
                .FirstOrDefault();
        }

        public IEnumerable<TResult> GetProducers<TResult>(Expression<Func<Producer, bool>> condition,
            Expression<Func<Producer, TResult>> selector)
        {
            return _context.Producers
                .Where(condition)
                .Select(selector)
                .ToList();
        }

    }
}