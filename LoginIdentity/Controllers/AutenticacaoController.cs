using LoginIdentity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace LoginIdentity.Controllers
{
    [AllowAnonymous]
    public class AutenticacaoController : Controller
    {
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            var model = new Usuario
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(Usuario model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (model.Login == "leoaugusto45" && model.Password == "123")
            {

                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, "Leonardo"),
                    new Claim(ClaimTypes.Email, "leoaugusto45@gmail.com"),
                    new Claim(ClaimTypes.PostalCode, "06386-000")
                }, "ApplicationCookie");


                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);

                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }

            ModelState.AddModelError("", "Usuário ou senha inválidos");
            return View();
        }

        public ActionResult LogOut()
        {

            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");

            return RedirectToAction("index", "home");

        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {

                return Url.Action("index", "home");
            }

            return returnUrl;
        }
    }
}