using OperationsOnData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminApp.Controllers
{
    public class AdminBooksController : Controller
    {
        private readonly ILibraryOperations libraryOperations;

        public AdminBooksController(ILibraryOperations libraryOperations)
        {
            this.libraryOperations = libraryOperations;
        }

        public ActionResult Index()
        {
            //var books = libraryOperations.GetBooks();
            return View();
        }

        public ActionResult GetBooks()
        {
            var books = libraryOperations.GetBooks();
            return Json(new { data = books }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                libraryOperations.RemoveBook(id);
                libraryOperations.SaveChanges();
            }
            catch
            {
                return View("Index");
            }
            return RedirectToAction("Index");
        }
    }
}