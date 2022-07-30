using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApiApp.Entities;
using WebApiApp.Manager.Contexts;
using WebApiApp.Manager.Interfaces;

namespace WebApiApp.Manager.Services
{
    public class Service<T> : IService<T> where T : Vehicle
    {
        private readonly DatabaseContext _context;

        public Service(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<T> FindAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync(bool asNoTracking = false)
        {
            return !asNoTracking ? await _context.Set<T>().AsNoTracking().ToListAsync() : await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression, bool asNoTracking = false)
        {
            return !asNoTracking ? await _context.Set<T>().Where(expression).AsNoTracking().ToListAsync() : await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return !asNoTracking ? await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter) : await _context.Set<T>().SingleOrDefaultAsync(filter);
        }

        public IQueryable GetQuery()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity, T unchanged)
        {
            _context.Entry(unchanged).CurrentValues.SetValues(entity);
        }
    }
}
