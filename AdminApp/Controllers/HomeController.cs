using AdminApp.ViewModels;
using OperationsOnData.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminApp.Controllers
{
    public class HomeController : Controller
    {
        IAuthProvider authProvider;

        public HomeController(IAuthProvider auth)
        {
            authProvider = auth;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(KeyViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.Number, model.AccessKey))
                    return Redirect(returnUrl ?? Url.Action("Index", "Home"));
                else
                {
                    ModelState.AddModelError("", "Incorrect admin number or admin key.");
                    return View();
                }
            }
            else
                return View();
        }
    }
}