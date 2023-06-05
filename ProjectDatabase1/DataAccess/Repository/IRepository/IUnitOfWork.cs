namespace ProjectDatabase1.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public IProjectCategoryRepository ProjectCategoryRepo { get; }
        public IProjectRepository ProjectRepo { get; }


        void Save();
    
    }
}
