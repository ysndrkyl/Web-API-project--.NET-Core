using WebApiApp.Entities;
using WebApiApp.Manager.Interfaces;

namespace WebApiApp.Manager.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IService<T> GetService<T>() where T : Vehicle;
        Task SaveChangesAsync();
    }
}
