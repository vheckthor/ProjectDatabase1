using ProjectDatabase1.DataAccess.Repository.IRepository;
using ProjectDatabase1.Models;

namespace ProjectDatabase1.DataAccess.Repository
{
    public class ProjectCategoryRepository : Repository<ProjectCategory>, IProjectCategoryRepository
    {
        private readonly AppDbContext _db;
        public ProjectCategoryRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
