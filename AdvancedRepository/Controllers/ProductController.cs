using AdvancedRepository.Models.Classes;
using AdvancedRepository.Models.ViewModels;
using AdvancedRepository.Repository.Interfaces;
using AdvancedRepository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Controllers
{
    public class ProductController : Controller
    {
        IUnity _u; //Tüm repository'ler Unity altında
        ProductModel _pm;

        public ProductController(ProductModel pm, IUnity u)
        {
            _pm = pm;
            _u = u;
        }

        public IActionResult List()
        {
            var pList = _u._proRepos.GetProductList();
            return View(pList);
        }
        public IActionResult Recover()
        {
            var pList = _u._proRepos.RecoverProductList();
            return View(pList);
        }

        public IActionResult Detail(int id)
        {
            var pList = _u._proRepos.ListByCategoryId(id);
            return View("List", pList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            _pm.Product = new Product();
            _pm.Title = "Add New Product";
            _pm.BtnClass = "btn btn-primary";
            _pm.BtnVal = "Add";
            _pm.EmployeeList = _u._empRepos.GetEmployeeList();
            _pm.SupplierList = _u._supRepos.GetSupplierList();
            _pm.CategoryList = _u._catRepos.GetCategoryList();
            _pm.UnitList = _u._unitRepos.GetUnitList();
            return View("Crud", _pm);
        }
        [HttpPost]
        public IActionResult Create(ProductModel pm)
        {
            pm.Product.Deleted = false;
            _u._proRepos.Create(pm.Product);
            _u.Commit();
            _u.Dispose();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _pm.Title = "Delete Section";
            _pm.BtnClass = "btn btn-danger";
            _pm.BtnVal = "Delete";
            _pm.Product = _u._proRepos.Find(id);
            _pm.EmployeeList = _u._empRepos.GetEmployeeList();
            _pm.CategoryList = _u._catRepos.GetCategoryList();
            _pm.SupplierList = _u._supRepos.GetSupplierList();
            _pm.UnitList = _u._unitRepos.GetUnitList();
            return View("Crud", _pm);
        }
        [HttpPost]
        public IActionResult Delete(ProductModel pm)
        {
            pm.Product.Deleted = true;
            _u._proRepos.Update(pm.Product);
            _u.Commit();
            _u.Dispose();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            _pm.Title = "Update Section";
            _pm.BtnClass = "btn btn-success";
            _pm.BtnVal = "Save";
            _pm.Product = _u._proRepos.Find(id);
            _pm.EmployeeList = _u._empRepos.GetEmployeeList();
            _pm.CategoryList = _u._catRepos.GetCategoryList();
            _pm.SupplierList = _u._supRepos.GetSupplierList();
            _pm.UnitList = _u._unitRepos.GetUnitList();
            return View("Crud", _pm);
        }
        [HttpPost]
        public IActionResult Edit(ProductModel pm)
        {
            _u._proRepos.Update(pm.Product);
            _u.Commit();
            _u.Dispose();
            return RedirectToAction("List");
        }
    }
}
