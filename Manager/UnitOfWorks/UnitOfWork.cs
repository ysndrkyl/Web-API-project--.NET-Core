using WebApiApp.Entities;
using WebApiApp.Manager.Contexts;
using WebApiApp.Manager.Interfaces;
using WebApiApp.Manager.Services;

namespace WebApiApp.Manager.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public IService<T> GetService<T>() where T : Vehicle
        {
            return new Service<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
