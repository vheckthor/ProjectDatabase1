using Microsoft.AspNetCore.Mvc;
using ProjectDatabase1.DataAccess.Repository.IRepository;
using ProjectDatabase1.Models;

namespace ProjectDatabase1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _db;
        public CategoryController(IUnitOfWork db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var projectCategories = _db.ProjectCategoryRepo.GetAll();
            return View(projectCategories);
        }

        public IActionResult Create(ProjectCategory category)
        {
            if (ModelState.IsValid)
            {
                _db.ProjectCategoryRepo.Add(category);
                _db.Save();
                return RedirectToAction("Index");
            }
            
            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var categoryFromDb = _db.ProjectCategoryRepo.GetOne(x => x.Id == id);
            if (categoryFromDb == null)
            {
                return RedirectToAction("Index");
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(ProjectCategory category)
        {
            if (ModelState.IsValid)
            {
                _db.ProjectCategoryRepo.Update(category);
                _db.Save();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Delete(int? id)
        {
            var projectCategory = _db.ProjectCategoryRepo.GetOne(x => id == x.Id);
            if (projectCategory == null)
            {
                return NotFound();
            }
            _db.ProjectCategoryRepo.Delete(projectCategory);
            _db.Save();
            return RedirectToAction("Index");
        }
    }
}
