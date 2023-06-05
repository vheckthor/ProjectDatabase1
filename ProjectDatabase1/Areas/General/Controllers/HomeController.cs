using Microsoft.AspNetCore.Mvc;
using ProjectDatabase1.DataAccess.Repository.IRepository;
using ProjectDatabase1.Models;
using System.Diagnostics;

namespace ProjectDatabase1.Areas.General.Controllers
{
    [Area("General")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _db;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var projects = _db.ProjectRepo.GetAll(includeproperties: "ProjectCategory");
            var model = new ProjectIndexVM { Projects = projects, SearchModel = new SearchVM() };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(SearchVM searchData)
        {
            var filtered = await _db.ProjectRepo.GetSearch(
                x => x.ProjectTitle.ToLower().Contains(searchData.SearchValue.ToLower()), 
                includeproperties: "ProjectCategory");
            var model = new ProjectIndexVM { Projects = filtered, SearchModel = new SearchVM() };
            return View(model);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}