using AdminApp.ViewModels;
using Microsoft.AspNet.Identity;
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
        private readonly IUserOperations userOperations;
        private readonly ISaveDatabase db;
        private readonly IBooksOperations bookOperations;

        public AdminUsersController(IUserOperations userOpe, ISaveDatabase db, IBooksOperations booksOpe)
        {
            userOperations = userOpe;
            this.db = db;
            bookOperations = booksOpe;
        }

        public ActionResult Index()
        {
            if (bookOperations.GetBooks().Any(m => m.EndBookingDate < DateTime.Now))
            {
                var userId = User.Identity.GetUserId();
                userOperations.ResetBookingBooks(userId);
                db.SaveChanges();
            }

            if (bookOperations.GetBooks().Any(m => m.ReturnDate < DateTime.Now))
            {
                userOperations.SetObligation();
                db.SaveChanges();
            }

            return View();
        }

        public ActionResult GetUsers()
        {
            var users = userOperations.GetUsers();
            return Json(new { data = users }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                userOperations.RemoveUser(id);
                db.SaveChanges();
            }
            catch
            {
                return View("Index");
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(string id)
        {
            var foundUserAndBooks = bookOperations.GetBooksOfUser(id);
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
            var book = bookOperations.FindById(id);
            return View(book);
        }

        [HttpPost]
        public ActionResult ChangeStatus(Book book)
        {
            var userId = book.UserId;
            try
            {
                bookOperations.ChangeStatus(book);
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Details", "AdminUsers", new { id = userId });
        }
    }
}