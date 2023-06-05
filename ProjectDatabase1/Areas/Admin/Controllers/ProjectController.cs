using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectDatabase1.DataAccess.Repository.IRepository;
using ProjectDatabase1.Models;

namespace ProjectDatabase1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly IUnitOfWork _db;


        public ProjectController(IUnitOfWork db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var projects = _db.ProjectRepo.GetAll();
            return View(projects);
        }

        public IActionResult Create()
        {
            ProjectVM projectVM = new()
            {
                Project = new(),
                Categories = _db.ProjectCategoryRepo.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CategoryName,
                    Value = u.Id.ToString()
                })
            };
            return View(projectVM);
        }

        [HttpPost]
        public IActionResult Create(ProjectVM projectVM)
        {
            if (ModelState.IsValid)
            {
                _db.ProjectRepo.Add(projectVM.Project);
                _db.Save();
                return RedirectToAction("Index");
            }
            return View(projectVM);
        }


        public IActionResult Edit(int id)
        {
            ProjectVM projectVM = new()
            {
                Project = _db.ProjectRepo.GetOne(x => x.Id == id),
                Categories = _db.ProjectCategoryRepo.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CategoryName,
                    Value = u.Id.ToString()
                })
            };
            return View(projectVM);
        }

        [HttpPost]
        public IActionResult Edit(ProjectVM projectVM)
        {
            if (ModelState.IsValid)
            {
                _db.ProjectRepo.Update(projectVM.Project);
                _db.Save();
                return RedirectToAction("Index");
            }
            return View(projectVM);
        }

        public IActionResult Delete(int id)
        {
            var project = _db.ProjectRepo.GetOne(x => x.Id == id);
            if (project == null)
            {
                return View();
            }    
            _db.ProjectRepo.Delete(project);
            _db.Save();
            return RedirectToAction("Index");
        }
    }

}
