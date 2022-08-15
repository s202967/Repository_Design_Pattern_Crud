using EmployeesWeb.Data;
using EmployeesWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;

namespace EmployeesWeb.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _db;
        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
        }

        public async Task AddAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity).ConfigureAwait(false);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _db.Set<T>().AddRange(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _db.Set<T>().Where(expression);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync().ConfigureAwait(false);
        }

        public void Remove(T entity)
        {
            _db.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _db.Set<T>().RemoveRange(entities);
        }
        public void Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
        }
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id).ConfigureAwait(false);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}

