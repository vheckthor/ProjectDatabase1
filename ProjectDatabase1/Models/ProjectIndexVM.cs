namespace ProjectDatabase1.Models
{
    public class ProjectIndexVM
    {
        public IEnumerable<Project> Projects { get; set; } = Enumerable.Empty<Project>();
        public SearchVM SearchModel { get; set; }
    }
}
