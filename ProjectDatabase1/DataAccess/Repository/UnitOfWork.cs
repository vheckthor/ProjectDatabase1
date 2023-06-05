using ProjectDatabase1.DataAccess.Repository.IRepository;

namespace ProjectDatabase1.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
            ProjectCategoryRepo = new ProjectCategoryRepository(db);
            ProjectRepo = new ProjectRepository(db);
        }
        public IProjectCategoryRepository ProjectCategoryRepo { get; private set; }

        public IProjectRepository ProjectRepo { get; private set; }
    
    
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
