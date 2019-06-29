using ShopProject.Models;
using ShopProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShopProject.Controllers
{
    public class AuthController : Controller
    {
        AuthService _authService = new AuthService();

        public ActionResult Auth()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Auth(UserAuthModel user)
        {
            if(ModelState.IsValid)
            {
                if (_authService.Login(user))
                {
                    FormsAuthentication.SetAuthCookie(user.Name, true);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("","Такого пользователя не существует");
            }
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (!_authService.IsUserExist(model.Name))
                {
                    _authService.Register(model);
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "такой пользователь уже существует");
                }
            }
            return View();
        }
    }
}