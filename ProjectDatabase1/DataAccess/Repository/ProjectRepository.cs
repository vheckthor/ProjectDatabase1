using ProjectDatabase1.DataAccess.Repository.IRepository;
using ProjectDatabase1.Models;

namespace ProjectDatabase1.DataAccess.Repository
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private readonly AppDbContext _db;
        public ProjectRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

 
    }
}
