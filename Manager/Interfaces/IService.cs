using System.Linq.Expressions;
using WebApiApp.Entities;

namespace WebApiApp.Manager.Interfaces
{
    public interface IService<T> where T:Vehicle
    {
        Task<List<T>> GetAllAsync(bool asNoTracking = false);
        Task<List<T>> GetAllAsync(Expression<Func<T,bool>> expression, bool asNoTracking = false);
        Task<T> FindAsync(int id);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false);
        void Remove(T entity);
        IQueryable GetQuery();
        Task CreateAsync(T entity);
        void Update(T entity, T unchanged);
    }
}
