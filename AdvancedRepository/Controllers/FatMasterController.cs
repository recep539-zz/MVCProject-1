using AdvancedRepository.Models.ViewModels;
using AdvancedRepository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Controllers
{
    public class FatMasterController : Controller
    {
        IUnity _u;
        FatMasterModel _model;
        public FatMasterController(IUnity u, FatMasterModel model)
        {
            _u = u;
            _model = model;
            
        }
        public IActionResult List()
        {
            return View(_u._fatRepos.GetFatMaster());
        }
        [HttpGet]
        public IActionResult Create()
        {
            _model.Title = "Fat Masters";
            _model.BtnVal = "Add";
            _model.BtnClass = "btn btn-primary";
            _model.CustomerList = _u._customerRepos.GetCustomerSelect();
            return View(_model);
        }     
        [HttpPost]
        public IActionResult Create(FatMasterModel model)
        {         
            _u._fatRepos.Create(model.FatMasters);
            _u.Commit();
            _u.Dispose();
            return RedirectToAction("Create","FatDetail",new { id=model.FatMasters.Id});
            
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {            
            _model.Title = "Fat Masters";
            _model.BtnVal = "Update";
            _model.BtnClass = "btn btn-success";
            _model.CustomerList = _u._customerRepos.GetCustomerSelect();
            _model.FatMasters = _u._fatRepos.Find(id);         
            return View("Create",_model);
        }
        [HttpPost]
        public IActionResult Edit(FatMasterModel model)
        {
            _u._fatRepos.Update(model.FatMasters);
            _u.Commit();
            _u.Dispose();
            return RedirectToAction("Create", "FatDetail", new { id =model.FatMasters.Id });

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _model.Title = "Fat Masters";
            _model.BtnVal = "Delete";
            _model.BtnClass = "btn btn-danger";
            _model.CustomerList = _u._customerRepos.GetCustomerSelect();
            _model.FatMasters = _u._fatRepos.Find(id);
            return View("Create", _model);
        }
        [HttpPost]
        public IActionResult Delete(FatMasterModel model)
        {
            _u._fatRepos.Delete(model.FatMasters);
            _u.Commit();
            _u.Dispose();
            return RedirectToAction("List");

        }


    }
}
    