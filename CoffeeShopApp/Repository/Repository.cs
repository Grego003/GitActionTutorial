using CoffeeShopApp.Data;
using CoffeeShopApp.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoffeeShopApp.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly  CoffeeShopAppContext _context;

        internal DbSet<T> dbSet;

        protected Repository(CoffeeShopAppContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IQueryable<T> query = dbSet;
            return await query.ToListAsync();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            Task<T?> task = query.FirstOrDefaultAsync(filter);
            System.Threading.Thread.Sleep(2000);

            return await task;
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveBatch(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

    }
}
