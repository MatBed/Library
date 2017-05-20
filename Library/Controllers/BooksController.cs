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
            return View("Index", books);
        }

        

        //// GET: Books/Create
        //public ActionResult Create()
        //{
        //    return View("Create");   
        //}

        //// POST: Books/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "BookId,Title,Author,Type,NumberOfPages,Status,UserId")] Book book)
        //{
            
        //}

        

        //// GET: Books/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    return View("Delete");
        //}

        //// POST: Books/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id)
        //{
            
        //}

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
