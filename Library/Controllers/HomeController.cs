using OperationsOnData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserOperations userOperations;
        private readonly ISaveDatabase db;
        private readonly IBooksOperations bookOperations;

        public HomeController(IUserOperations userOpe, ISaveDatabase db, IBooksOperations booksOpe)
        {
            userOperations = userOpe;
            this.db = db;
            bookOperations = booksOpe;
        }

        public ActionResult Index()
        {
            if (bookOperations.GetBooks().Any(m => m.ReturnDate < DateTime.Now))
            {
                userOperations.SetObligation();
                db.SaveChanges();
            }
            return View();
        }
    }
}