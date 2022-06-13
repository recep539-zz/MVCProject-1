using AdvancedRepository.Models.Classes;
using AdvancedRepository.Models.ViewModels;
using AdvancedRepository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedRepository.Controllers
{
    public class CustomerController : Controller
    {
        CustomerModel _cm;
        IUnity _u;

        public CustomerController(CustomerModel cm, IUnity u)
        {
            _cm = cm;
            _u = u;
        }

        public IActionResult List()
        {
            var cList = _u._customerRepos.GetCustomerList();
            return View(cList);
        }
        public IActionResult Recover()
        {
            var cList = _u._customerRepos.RecoverCustomerList();
            return View(cList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            _cm.Customer = new Customer();
            _cm.Title = "Add New Customer";
            _cm.BtnClass = "btn btn-primary";
            _cm.BtnVal = "Add";
            _cm.CountyList = _u._countyRepos.GetCountyList();
            return View("Crud", _cm);
        }
        [HttpPost]
        public IActionResult Create(CustomerModel cm)
        {
            cm.Customer.Deleted = false;
            _u._customerRepos.Create(cm.Customer);
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
            _cm.Customer = _u._customerRepos.Find(id);
            _cm.CountyList = _u._countyRepos.GetCountyList();
            return View("Crud", _cm);
        }
        [HttpPost]
        public IActionResult Delete(CustomerModel cm)
        {
            cm.Customer.Deleted = true;
            _u._customerRepos.Update(cm.Customer);
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
            _cm.Customer = _u._customerRepos.Find(id);
            _cm.CountyList = _u._countyRepos.GetCountyList();
            return View("Crud", _cm);
        }
        [HttpPost]
        public IActionResult Edit(CustomerModel cm)
        {
            _u._customerRepos.Update(cm.Customer);
            _u.Commit();
            _u.Dispose();
            return RedirectToAction("List");
        }
    }
}
