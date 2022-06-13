using AdvancedRepository.Models.ViewModels;
using AdvancedRepository.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvancedRepository.Extensions;//ELLE EKLEME YAPTIK

namespace AdvancedRepository.Controllers
{
    public class AuthController : Controller
    {
        IUnity _u;
        LoginModel _model;
        public AuthController(IUnity u, LoginModel model)
        {
            _u = u;
            _model = model;
        }
        public IActionResult Register()
        {
            return View(_model);
        }
        [HttpPost]
        public IActionResult Register(LoginModel model)
        {
            _u._authRepository.Register(model.UserName, model.Password);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Login()
        {
            HttpContext.Session.GetString("UserName");
            //HttpContext.Session.GetString("Role");
            return View("Register", _model);
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var user = _u._authRepository.Login(model.UserName, model.Password);
            if (user != null)
            {
                HttpContext.Session.Set<string>("UserName", user.UserName);//EXTENSİON YAPTIĞIMIZ İÇİN DÜZENLEDİK
                HttpContext.Session.Set<string>("Role", user.Role);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public IActionResult Logout()
        {
            // HttpContext.Session.Clear();//hepsini temizler.     
            HttpContext.Session.Set<string>("UserName", "");//sepet hariç temizler
            HttpContext.Session.Set<string>("Role", "");
            return RedirectToAction("Index", "Home");
        }

    }
}
