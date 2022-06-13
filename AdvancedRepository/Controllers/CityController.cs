using AdvancedRepository.Models.Classes;
using AdvancedRepository.Models.ViewModels;
using AdvancedRepository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedRepository.Controllers
{
    public class CityController : Controller
    {
        CityModel _cm;
        IUnity _u;

        public CityController(CityModel cm, IUnity u)
        {
            _cm = cm;
            _u = u;
        }

        public IActionResult List()
        {
            var cList = _u._cityRepos.GetCityList();
            return View(cList);
        }
        public IActionResult Recover()
        {
            var cList = _u._cityRepos.RecoverCityList();
            return View(cList);
        }


        [HttpGet]
        public IActionResult Create()
        {
            _cm.City = new City();
            _cm.Title = "Add New City";
            _cm.BtnClass = "btn btn-primary";
            _cm.BtnVal = "Add";
            return View("Crud", _cm);
        }
        [HttpPost]
        public IActionResult Create(CityModel cm)
        {
            cm.City.Deleted = false;
            _u._cityRepos.Create(cm.City);
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
            _cm.City = _u._cityRepos.Find(id);
            return View("Crud", _cm);
        }
        [HttpPost]
        public IActionResult Delete(CityModel cm)
        {
            cm.City.Deleted = true;
            _u._cityRepos.Update(cm.City);
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
            _cm.City = _u._cityRepos.Find(id);
            return View("Crud", _cm);
        }
        [HttpPost]
        public IActionResult Edit(CityModel cm)
        {
            _u._cityRepos.Update(cm.City);
            _u.Commit();
            _u.Dispose();
            return RedirectToAction("List");
        }
    }
}
