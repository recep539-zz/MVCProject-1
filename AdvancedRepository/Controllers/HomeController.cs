using AdvancedRepository.DTOs;
using AdvancedRepository.Extensions;
using AdvancedRepository.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedRepository.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public const string UserName = "UserName";//.net core session microsoft sitesinden aldık.
        //public const string Password = "Password";
        public const string Role = "Role";

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var baskets = HttpContext.Session.Get<List<BasketList>>("Basket");
            if (baskets != null)
            {
                ViewBag.Count = baskets.Count;
            }
            else ViewBag.Count = "";
            ViewBag.UserName = HttpContext.Session.Get<string>("UserName");//getstring metodunu get e çekip string e çevirdik extension metot olarak çalışıyor.
            var Role = HttpContext.Session.Get<string>("Role");
            if (Role == "Admin")
            {
                return RedirectToAction("Index", "Admin");
            }
            else return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
