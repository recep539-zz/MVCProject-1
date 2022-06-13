using AdvancedRepository.Models;
using AdvancedRepository.Models.Classes;
using AdvancedRepository.Models.ViewModels;
using AdvancedRepository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedRepository.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeModel _em;
        IUnity _u;

        public EmployeeController(EmployeeModel em, IUnity u)
        {
            _em = em;
            _u = u;
        }

        public IActionResult List()
        {
            var eList = _u._empRepos.GetEmployeeList();
            return View(eList);
        }
        public IActionResult Recover()
        {
            var eList = _u._empRepos.RecoverEmployeeList();
            return View(eList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            _em.Employee = new Employee();
            _em.Title = "Add New Employee";
            _em.BtnClass = "btn btn-primary";
            _em.BtnVal = "Add";
            _em.ManagerList = _u._empRepos.GetManagerList();
            _em.CountyList = _u._countyRepos.GetCountyList();
            return View("Crud", _em);
        }
        [HttpPost]
        public IActionResult Create(EmployeeModel em)
        {
            em.Employee.Deleted = false;
            _u._empRepos.Create(em.Employee);
            _u.Commit();
            _u.Dispose();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _em.Title = "Delete Section";
            _em.BtnClass = "btn btn-danger";
            _em.BtnVal = "Delete";
            _em.Employee = _u._empRepos.Find(id);
            _em.ManagerList = _u._empRepos.GetManagerList();
            _em.CountyList = _u._countyRepos.GetCountyList();
            return View("Crud", _em);
        }
        [HttpPost]
        public IActionResult Delete(EmployeeModel em)
        {
            em.Employee.Deleted = true;
            _u._empRepos.Update(em.Employee);
            _u.Commit();
            _u.Dispose();
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            _em.Title = "Update Section";
            _em.BtnClass = "btn btn-success";
            _em.BtnVal = "Save";
            _em.Employee = _u._empRepos.Find(id);
            _em.ManagerList = _u._empRepos.GetManagerList();
            _em.CountyList = _u._countyRepos.GetCountyList();
            return View("Crud", _em);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeModel em)
        {
            _u._empRepos.Update(em.Employee);
            _u.Commit();
            _u.Dispose();
            return RedirectToAction("List");
        }
        public IActionResult Detail(int id)
        {
            var emp = _u._empRepos.GetEmployeeDetail(id);
            return View(emp);
        }
    }
}
