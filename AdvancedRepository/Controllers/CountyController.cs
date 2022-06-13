using AdvancedRepository.Models.Classes;
using AdvancedRepository.Models.ViewModels;
using AdvancedRepository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedRepository.Controllers
{
    public class CountyController : Controller
    {
        CountyModel _cm;
        IUnity _u;

        public CountyController(CountyModel cm, IUnity u)
        {
            _cm = cm;
            _u = u;
        }

        public IActionResult List()
        {
            var cList = _u._countyRepos.GetCountyList();
            return View(cList);
        }
        public IActionResult Recover()
        {
            var cList = _u._countyRepos.RecoverCountyList();
            return View(cList);
        }

        public IActionResult Detail(int id)
        {
            var cList = _u._countyRepos.ListByCityId(id);
            return View("List", cList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            _cm.County = new County();
            _cm.Title = "Add New County";
            _cm.BtnClass = "btn btn-primary";
            _cm.BtnVal = "Add";
            _cm.CityList = _u._cityRepos.GetCityList();
            return View("Crud", _cm);
        }
        [HttpPost]
        public IActionResult Create(CountyModel cm)
        {
            cm.County.Deleted = false;
            _u._countyRepos.Create(cm.County);
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
            _cm.CityList = _u._cityRepos.GetCityList();
            _cm.County = _u._countyRepos.Find(id);
            return View("Crud", _cm);
        }
        [HttpPost]
        public IActionResult Delete(CountyModel cm)
        {
            cm.County.Deleted = true;
            _u._countyRepos.Update(cm.County);
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
            _cm.CityList = _u._cityRepos.GetCityList();
            _cm.County = _u._countyRepos.Find(id);
            return View("Crud", _cm);
        }
        [HttpPost]
        public IActionResult Edit(CountyModel cm)
        {
            _u._countyRepos.Update(cm.County);
            _u.Commit();
            _u.Dispose();
            return RedirectToAction("List");
        }
    }
}
