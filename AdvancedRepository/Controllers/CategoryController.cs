using AdvancedRepository.Models.Classes;
using AdvancedRepository.Models.ViewModels;
using AdvancedRepository.Repository.Interfaces;
using AdvancedRepository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedRepository.Controllers
{
    public class CategoryController : Controller
    {
        IUnity _u; //ICategoryRepopsitory _cr yerine tüm repository'ler Unity altında toplandığı için Unity _u tanımlandı
        CategoryModel _cm;

        public CategoryController(CategoryModel cm, IUnity u)
        {
            _cm = cm;
            _u = u;
        }

        public IActionResult List()
        {
            var x = _u._catRepos.GetCategoryList();
            return View(x);
        }

        public IActionResult Detail(int id)
        {
            var pList = _u._proRepos.ListByCategoryId(id);
            return View(pList);
        }
        public IActionResult Recover()
        {
            var pList = _u._catRepos.CategoryRecover();
            return View(pList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            _cm.Category = new Category();
            _cm.Title = "Add New Category";
            _cm.BtnClass = "btn btn-primary";
            _cm.BtnVal = "Add";
            return View("Crud", _cm);
        }
        [HttpPost]
        public IActionResult Create(CategoryModel cm)
        {   
            cm.Category.Deleted = false;
            _u._catRepos.Create(cm.Category);
            _u.Commit();
            _u.Dispose();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _cm.Title = "Delete Section";
            _cm.BtnClass = "btn btn-danger";
            _cm.BtnVal = "Delete";
            _cm.Category = _u._catRepos.Find(id);
            return View("Crud", _cm);
        }
        [HttpPost]
        public IActionResult Delete(CategoryModel cm)
        {
            //_u._catRepos.Delete(cm.Category);
            cm.Category.Deleted = true;
            _u._catRepos.Update(cm.Category);
            _u.Commit();
            _u.Dispose();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            _cm.Title = "Update Section";
            _cm.BtnClass = "btn btn-success";
            _cm.BtnVal = "Save";
            _cm.Category = _u._catRepos.Find(id);
            return View("Crud", _cm);
        }
        [HttpPost]
        public IActionResult Edit(CategoryModel cm)
        {
            _u._catRepos.Update(cm.Category);
            _u.Commit();
            _u.Dispose();
            return RedirectToAction("List");
        }
    }
}
