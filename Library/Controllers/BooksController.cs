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

        // GET: Books
        public ActionResult Index()
        {
            var books = libraryOperations.GetBooks();
            return View(books);
        }

        public ActionResult ShowBookedBooks()
        {
            var userId = User.Identity.GetUserId();
            var books = libraryOperations.GetBooks().Where(m => m.Status == Status.Booked && m.UserId == userId);
            return View(books);
        }

        // GET: Books/Create
        [Authorize]
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Books/Create
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

            //return View("Index");
        }

        // POST: Books/Delete/5
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

            try
            {
                libraryOperations.Booking(book);
                book.UserId = User.Identity.GetUserId();
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

            try
            {
                libraryOperations.CancleBooking(book);
                book.UserId = null;
                libraryOperations.SaveChanges();
            }
            catch
            {
                return View("Index");
            }

            return RedirectToAction("Index");
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
