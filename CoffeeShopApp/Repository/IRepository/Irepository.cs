
using CoffeeShopApp.Models;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoffeeShopApp.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetAsync(Expression<Func<T, bool>> filter);
        void Add(T entity);
        Task Save();
        void Remove(T entity);
        void RemoveBatch(IEnumerable<T> entity);
    }
}
