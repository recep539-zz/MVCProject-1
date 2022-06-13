using AdvancedRepository.Models.Classes;
using AdvancedRepository.Models.ViewModels;
using AdvancedRepository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedRepository.Controllers
{
    public class UnitController : Controller
    {
        UnitModel _um;
        IUnity _u;

        public UnitController(UnitModel um, IUnity u)
        {
            _um = um;
            _u = u;
        }

        public IActionResult List()
        {
            var uList = _u._unitRepos.GetUnitList();
            return View(uList);
        }
        public IActionResult Recover()
        {
            var uList = _u._unitRepos.RecoverUnitList();
            return View(uList);
        }


        [HttpGet]
        public IActionResult Create()
        {
            _um.Unit = new Unit();
            _um.Title = "Add New Unit";
            _um.BtnClass = "btn btn-primary";
            _um.BtnVal = "Add";
            return View("Crud", _um);
        }
        [HttpPost]
        public IActionResult Create(UnitModel um)
        {
            um.Unit.Deleted = false;
            _u._unitRepos.Create(um.Unit);
            _u.Commit();
            _u.Dispose();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _um.Title = "Delete Section";
            _um.BtnClass = "btn btn-danger";
            _um.BtnVal = "Delete";
            _um.Unit = _u._unitRepos.Find(id);
            return View("Crud", _um);
        }
        [HttpPost]
        public IActionResult Delete(UnitModel um)
        {
            um.Unit.Deleted = true;
            _u._unitRepos.Update(um.Unit);
            _u.Commit();
            _u.Dispose();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            _um.Title = "Update Section";
            _um.BtnClass = "btn btn-success";
            _um.BtnVal = "Save";
            _um.Unit = _u._unitRepos.Find(id);
            return View("Crud", _um);
        }
        [HttpPost]
        public IActionResult Edit(UnitModel um)
        {
            _u._unitRepos.Update(um.Unit);
            _u.Commit();
            _u.Dispose();
            return RedirectToAction("List");
        }
    }
}
