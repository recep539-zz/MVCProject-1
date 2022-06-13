using AdvancedRepository.Models.Classes;
using AdvancedRepository.Models.ViewModels;
using AdvancedRepository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Controllers
{
    public class FatDetailController : Controller
    {
        IUnity _u;
        FatDetailModel _model;
        public FatDetailController(IUnity u, FatDetailModel model)
        {
            _u = u;
            _model = model;
        }
        public IActionResult Create(int id)
        {
            _model.FatDetailLists = _u._fatdetailRepos.GetFatDetailList(id);
            _model.Total = _u._fatdetailRepos.FatTotal(_model.FatDetailLists);
            _model.FatMaster = _u._fatRepos.Find(id);
            _model.ProductSelect = _u._proRepos.GetProductSelect();
            _model.Customers = _u._customerRepos.GetCustomerSelect();
            return View(_model);
        }
        [HttpPost]
        public IActionResult Create(int id, FatDetailModel model)
        {
            model.FatDetail.Id = id;
            model.FatDetailLists = _u._fatdetailRepos.GetFatDetailList(id);
            model.FatMaster = _u._fatRepos.Find(id);
            model.ProductSelect = _u._proRepos.GetProductSelect();
            model.Customers = _u._customerRepos.GetCustomerSelect();
            model.Total = _u._fatdetailRepos.FatTotal(model.FatDetailLists);
            _u._fatdetailRepos.Create(model.FatDetail);
            _u.Commit();
            _u.Dispose();
            return RedirectToAction("Create", "FatDetail", new { id });
        }
        [HttpGet]
        public IActionResult Update(int id,int ProductId) 
        {
           FatDetail fd= _u._fatdetailRepos.Find(id,ProductId);
            return View();
        }
        [HttpPost]
        public IActionResult Update(FatDetail model,int id,int ProductId)
        {
            model.Id = id;
            model.ProductId = ProductId;     
            _u._fatdetailRepos.Update(model);
            _u.Commit();
            _u.Dispose();
            return RedirectToAction("Create", "FatDetail", new { id, ProductId });
        }
        [HttpGet]
        public IActionResult Delete(int id, int ProductId)
        {
            FatDetail fd = _u._fatdetailRepos.Find(id, ProductId);
            return View(fd);
        }
        [HttpPost]
        public IActionResult Delete(FatDetail model, int id)
        {
            model.Id = id;       
            _u._fatdetailRepos.Delete(model);
            _u.Commit();
            _u.Dispose();
            return RedirectToAction("Create", "FatDetail", new { id});
        }
    }
}
