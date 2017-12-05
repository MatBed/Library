using AdminApp.ViewModels;
using OperationsOnData.Interfaces;
using OperationsOnData.Models;
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
            if (libraryOperations.GetBooks().Any(m => m.EndBookingDate > DateTime.Now))
            {
                libraryOperations.ResetBookingBooks();
                libraryOperations.SaveChanges();
            }

            return View();
        }

        public ActionResult GetBooks()
        {
            var books = libraryOperations.GetBooks();
            return Json(new { data = books }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                libraryOperations.AddBook(book);
                libraryOperations.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(book);
        }

        public ActionResult Edit(int id)
        {
            var foundBook = libraryOperations.FindById(id);
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
                libraryOperations.EditBook(book);
                libraryOperations.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(book);
        }
    }
}