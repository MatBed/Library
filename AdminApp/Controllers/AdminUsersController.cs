using AdminApp.ViewModels;
using Newtonsoft.Json;
using OperationsOnData.Interfaces;
using OperationsOnData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminApp.Controllers
{
    public class AdminUsersController : Controller
    {
        private readonly ILibraryOperations libraryOperations;

        public AdminUsersController(ILibraryOperations libraryOperations)
        {
            this.libraryOperations = libraryOperations;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUsers()
        {
            var users = libraryOperations.GetUsers();
            return Json(new { data = users }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                libraryOperations.RemoveUser(id);
                libraryOperations.SaveChanges();
            }
            catch
            {
                return View("Index");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(string id)
        {
            var foundUserAndBooks = libraryOperations.GetBooksOfUser(id);
            return View(foundUserAndBooks);
        }

        public ActionResult ChangeStatus(int id)
        {
            var book = libraryOperations.FindById(id);
            return View(book);
        }

        [HttpPost]
        public ActionResult ChangeStatus(Book book)
        {
            var userId = book.UserId;
            try
            {
                libraryOperations.ChangeStatus(book);
                libraryOperations.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Details", "AdminUsers", new { id = userId });
        }
    }
}