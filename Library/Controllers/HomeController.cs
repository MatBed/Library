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
        private readonly ILibraryOperations libraryOperations;

        public HomeController(ILibraryOperations libraryOperations)
        {
            this.libraryOperations = libraryOperations;
        }
        public ActionResult Index()
        {
            if (libraryOperations.GetBooks().Any(m => m.ReturnDate > DateTime.Now))
            {
                libraryOperations.SetObligation();
                libraryOperations.SaveChanges();
            }
            return View();
        }
    }
}