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
    [Authorize]
    public class AdminUsersController : Controller
    {
        private readonly ILibraryOperations libraryOperations;

        public AdminUsersController(ILibraryOperations libraryOperations)
        {
            this.libraryOperations = libraryOperations;
        }

        public ActionResult Index()
        {
            if (libraryOperations.GetBooks().Any(m => m.EndBookingDate > DateTime.Now))
            {
                libraryOperations.ResetBookingBooks();
                libraryOperations.SaveChanges();
            }

            if (libraryOperations.GetBooks().Any(m => m.ReturnDate > DateTime.Now))
            {
                libraryOperations.SetObligation();
                libraryOperations.SaveChanges();
            }

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
            var foundUserAndBooksVM = new BooksAndUserViewModel()
            {
                Book = foundUserAndBooks.Book,
                Books = foundUserAndBooks.Books,
                User = foundUserAndBooks.User
            };
            return View(foundUserAndBooksVM);
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