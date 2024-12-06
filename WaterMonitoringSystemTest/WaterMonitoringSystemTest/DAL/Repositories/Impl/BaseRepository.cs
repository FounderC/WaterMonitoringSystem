using Microsoft.EntityFrameworkCore;
using WaterMonitoringSystemTest.DAL.Repositories.Interfaces;

namespace WaterMonitoringSystemTest.DAL.Repositories.Impl
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _set;
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _set = context.Set<T>();
        }

        public IEnumerable<T> GetAll() => _set.ToList();
        public T Get(int id) => _set.Find(id);
        public IEnumerable<T> Find(Func<T, bool> predicate) => _set.Where(predicate).ToList();
        public void Create(T item) => _set.Add(item);
        public void Update(T item) => _context.Entry(item).State = EntityState.Modified;
        public void Delete(int id)
        {
            var item = Get(id);
            if (item != null) _set.Remove(item);
        }
    }
}