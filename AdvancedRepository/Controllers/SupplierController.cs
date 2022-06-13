using AdvancedRepository.Models.Classes;
using AdvancedRepository.Models.ViewModels;
using AdvancedRepository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedRepository.Controllers
{
    public class SupplierController : Controller
    {
        SupplierModel _sm;
        IUnity _u;

        public SupplierController(SupplierModel sm, IUnity u)
        {
            _sm = sm;
            _u = u;
        }

        public IActionResult List()
        {
            var sList = _u._supRepos.GetSupplierList();
            return View(sList);
        }
        public IActionResult Recover()
        {
            var sList = _u._supRepos.RecoverSupplierList();
            return View(sList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            _sm.Supplier = new Supplier();
            _sm.Title = "Add New Supplier";
            _sm.BtnClass = "btn btn-primary";
            _sm.BtnVal = "Add";
            _sm.CountyList = _u._countyRepos.GetCountyList();
            return View("Crud", _sm);
        }
        [HttpPost]
        public IActionResult Create(SupplierModel sm)
        {
            sm.Supplier.Deleted = false;
            _u._supRepos.Create(sm.Supplier);
            _u.Commit();
            _u.Dispose();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _sm.Title = "Delete Section";
            _sm.BtnClass = "btn btn-danger";
            _sm.BtnVal = "Delete";
            _sm.Supplier = _u._supRepos.Find(id);
            _sm.CountyList = _u._countyRepos.GetCountyList();
            return View("Crud", _sm);
        }
        [HttpPost]
        public IActionResult Delete(SupplierModel sm)
        {
            sm.Supplier.Deleted = true;
            _u._supRepos.Update(sm.Supplier);
            _u.Commit();
            _u.Dispose();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            _sm.Title = "Update Section";
            _sm.BtnClass = "btn btn-success";
            _sm.BtnVal = "Save";
            _sm.Supplier = _u._supRepos.Find(id);
            _sm.CountyList = _u._countyRepos.GetCountyList();
            return View("Crud", _sm);
        }
        [HttpPost]
        public IActionResult Edit(SupplierModel sm)
        {
            _u._supRepos.Update(sm.Supplier);
            _u.Commit();
            _u.Dispose();
            return RedirectToAction("List");
        }
    }
}
