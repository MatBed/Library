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
using Library.ViewModels;

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
            var booksVM = from book in books
                          select new ListOfBooksViewModel
                          {
                              Title = book.Title,
                              Type = book.Type,
                              Status = (ViewModels.Status)book.Status,
                              Author = book.Author,
                              NumberOfPages = book.NumberOfPages,
                              BookId = book.BookId
                          };
            return Json(new { data = booksVM }, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult ShowBookedBooks()
        {
            var userId = User.Identity.GetUserId();
            var books = libraryOperations.GetBooks().Where(m => m.Status == OperationsOnData.Models.Status.Booked && m.UserId == userId);
            var booksVM = from book in books
                          select new BookedBookViewModel
                          {
                               BookId = book.BookId,
                               Author = book.Author,
                               Title = book.Title,
                               Status = (ViewModels.Status)book.Status,
                               Type = book.Type,
                               NumberOfPages = book.NumberOfPages,
                               BookingDate = book.BookingDate,
                               EndOfBookingDate = book.EndBookingDate
                          };
                
            return View(booksVM);
        }

        [Authorize]
        public ActionResult ShowBorrowedBooks()
        {
            var userId = User.Identity.GetUserId();
            var books = libraryOperations.GetBooks().Where(m => m.Status == OperationsOnData.Models.Status.Borrowed && m.UserId == userId);
            var booksVM = from book in books
                          select new BorrowedBookViewModel
                          {
                              Title = book.Title,
                              Author = book.Author,
                              Status = (ViewModels.Status)book.Status,
                              Type = book.Type,
                              NumberOfPages = book.NumberOfPages,
                              BorrowingDate = book.BorrowingDate,
                              ReturnDate = book.ReturnDate
                          };
            return View(booksVM);
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
