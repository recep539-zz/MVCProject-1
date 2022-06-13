using AdvancedRepository.DTOs;
using AdvancedRepository.Models.Classes;
using AdvancedRepository.Models.ViewModels;
using AdvancedRepository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvancedRepository.Extensions;

namespace AdvancedRepository.Controllers
{
     public class BasketController : Controller
    {
        IUnity _uow;
        BasketModel _model;     
        BasketList _basketlist;
       public BasketController(IUnity uow,BasketModel model, BasketList basketlist)
        {
            _uow = uow;
            _model = model;
           _basketlist = basketlist;
        }
        static List<BasketList> basketlists = new List<BasketList>();
        public IActionResult List()
        {
            return View(basketlists);
        }

        [HttpGet]
        public IActionResult Add()
        {          
            _model.ProductsSelect =_uow._proRepos.GetProductSelect();
            return View(_model);
        }
        [HttpPost]
        public IActionResult Add(BasketModel model)
        {       
            Product product = _uow._proRepos.Find(model.Id);           
            _basketlist.Id = product.Id;
            _basketlist.ProductName = product.ProductName;          
            _basketlist.UnitPrice = product.UnitPrice;
            _basketlist.Amount = model.Amount;
            basketlists.Add(_basketlist);
            HttpContext.Session.Set("Basket", basketlists);
            //basketlists = HttpContext.Session.Get<List<BasketList>>("Basket");
            return RedirectToAction("Index","Home");
        }
    }
}
