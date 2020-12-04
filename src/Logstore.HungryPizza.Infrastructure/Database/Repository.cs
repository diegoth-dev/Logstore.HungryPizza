using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Logstore.HungryPizza.Core.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Logstore.HungryPizza.Infrastructure.Database
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public Task<T> GetByIdAsync<T>(int id, params Expression<Func<T, object>>[] includes) where T : BaseEntity
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (Expression<Func<T, object>> include in includes)
            {
               query = query.Include(include);
            }
            
            return query.SingleOrDefaultAsync(e => e.Id == id);
        }

        public Task<List<T>> ListAsync<T>() where T : BaseEntity
        {
            return _context.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync<T>(T entity) where T : BaseEntity
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync<T>(T entity) where T : BaseEntity
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : BaseEntity
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}