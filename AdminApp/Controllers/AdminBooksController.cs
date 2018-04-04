using AdminApp.ViewModels;
using Microsoft.AspNet.Identity;
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
    public class AdminBooksController : Controller
    {
        private readonly IUserOperations userOperations;
        private readonly ISaveDatabase db;
        private readonly IBooksOperations bookOperations;

        public AdminBooksController(IUserOperations userOpe, ISaveDatabase db, IBooksOperations booksOpe)
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

            return View();
        }

        public ActionResult GetBooks()
        {
            var books = bookOperations.GetBooks();
            return Json(new { data = books }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                bookOperations.RemoveBook(id);
                db.SaveChanges();
            }
            catch
            {
                return View("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookViewModel bookViewModel)
        {
            Book book = new Book {
                BookId = bookViewModel.BookId,
                Author = bookViewModel.Author,
                NumberOfPages = bookViewModel.NumberOfPages,
                Status = Status.Available,
                Title = bookViewModel.Title,
                Type = bookViewModel.Type };

            if (ModelState.IsValid)
            {
                bookOperations.AddBook(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(book);
        }

        public ActionResult Edit(int id)
        {
            var foundBook = bookOperations.FindById(id);
            BookViewModel bookVM = new BookViewModel {
                BookId = foundBook.BookId,
                Author = foundBook.Author,
                NumberOfPages = foundBook.NumberOfPages,
                Status = foundBook.Status,
                Title = foundBook.Title,
                Type = foundBook.Type };

            return View(bookVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookViewModel bookViewModel)
        {
            Book book = new Book
            {
                BookId = bookViewModel.BookId,
                Author = bookViewModel.Author,
                Status = bookViewModel.Status,
                NumberOfPages = bookViewModel.NumberOfPages,
                Title = bookViewModel.Title,
                Type = bookViewModel.Type
            };

            if (ModelState.IsValid)
            {
                bookOperations.EditBook(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(book);
        }
    }
}