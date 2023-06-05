using System.Linq.Expressions;

namespace ProjectDatabase1.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? includeproperties = null);
        Task<IEnumerable<T>> GetSearch(Expression<Func<T, bool>> filter, string? includeproperties = null);
        T GetOne(Expression<Func<T, bool>> filter, string? includeproperties = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
