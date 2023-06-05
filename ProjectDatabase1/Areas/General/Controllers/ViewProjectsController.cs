using Microsoft.AspNetCore.Mvc;
using ProjectDatabase1.DataAccess.Repository.IRepository;

namespace ProjectDatabase1.Areas.General.Controllers
{
    [Area("General")]
    public class ViewProjectsController : Controller
    {
        private readonly IUnitOfWork _db;

        public ViewProjectsController(IUnitOfWork db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var projects = _db.ProjectRepo.GetAll(includeproperties: "ProjectCategory");
            return View(projects);
        }
    }
}
