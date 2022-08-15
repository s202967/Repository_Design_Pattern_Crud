using System.Linq.Expressions;

namespace EmployeesWeb.Repository
{
    public interface IGenericRepository<T> where T : class
    {   
        Task<T?> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();

        IEnumerable<T> Find(Expression<Func<T, bool>> epression);

        void Add(T entity);

        Task AddAsync(T entity);

        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        void Update(T entity);

        void SaveChanges();
    }
}
