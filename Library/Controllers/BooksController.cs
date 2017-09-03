using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OperationsOnData.DAL;
using OperationsOnData.Models;
using OperationsOnData.Interfaces;
using Microsoft.AspNet.Identity;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly ILibraryOperations libraryOperations;

        public BooksController(ILibraryOperations libraryOperations)
        {
            this.libraryOperations = libraryOperations;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetBooks()
        {
            var books = libraryOperations.GetBooks();
            return Json(new { data = books }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ShowBookedBooks()
        {
            var userId = User.Identity.GetUserId();
            var books = libraryOperations.GetBooks().Where(m => m.Status == Status.Booked && m.UserId == userId);
            return View(books);
        }

        public ActionResult ShowBorrowedBooks()
        {
            var userId = User.Identity.GetUserId();
            var books = libraryOperations.GetBooks().Where(m => m.Status == Status.Borrowed && m.UserId == userId);
            return View(books);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Author,Type,NumberOfPages,Status")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.Status = Status.Available;
                libraryOperations.AddBook(book);
                libraryOperations.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(book);
        }

        [HttpPost]
        [Authorize]
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

        [HttpPost]
        [Authorize]
        public ActionResult Reservation(int id)
        {
            var book = libraryOperations.FindById(id);
            var userId = User.Identity.GetUserId();

            try
            {
                libraryOperations.Booking(book, userId);
                book.UserId = userId;
                libraryOperations.SaveChanges();                
            }
            catch
            {
                return View("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        public ActionResult CancleReservation(int id)
        {
            var book = libraryOperations.FindById(id);
            var userId = User.Identity.GetUserId();

            try
            {
                libraryOperations.CancleBooking(book, userId);
                book.UserId = null;
                libraryOperations.SaveChanges();
            }
            catch
            {
                return View("Index");
            }

            return RedirectToAction("ShowBookedBooks");
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
                libraryOperations.ChangeStatus(book, userId);
                libraryOperations.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
            
            return RedirectToAction("Details", "User", new { id = userId });
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
