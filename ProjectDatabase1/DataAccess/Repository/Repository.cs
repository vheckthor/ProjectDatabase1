using Microsoft.EntityFrameworkCore;
using ProjectDatabase1.DataAccess.Repository.IRepository;
using System.Linq.Expressions;

namespace ProjectDatabase1.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        public DbSet<T> dbSet;
        public Repository(AppDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
       
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public IEnumerable<T> GetAll(string? includeproperties = null)
        {
            IQueryable<T> query = dbSet;
            if (includeproperties != null)
            {
                foreach (var property in includeproperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            return query;
        }

        public T GetOne(Expression<Func<T, bool>> filter, string? includeproperties = null)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);

            if (includeproperties != null)
            {
                foreach (var property in includeproperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(property);
                }
            }
            return query.FirstOrDefault();
        }

		public async Task<IEnumerable<T>> GetSearch(Expression<Func<T, bool>> filter, string? includeproperties = null)
		{
			IQueryable<T> query = dbSet;
			query = query.Where(filter);
			if (includeproperties != null)
			{
				foreach (var property in includeproperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(property);
				}
			}

            return await query.ToListAsync();
		}

		public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}

