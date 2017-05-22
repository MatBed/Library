using OperationsOnData.Interfaces;
using OperationsOnData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OperationsOnData.Library_Operations
{
    public class LibraryOperations : ILibraryOperations
    {
        private readonly ILibraryContext LibraryDb;

        public LibraryOperations(ILibraryContext LibraryDb)
        {
            this.LibraryDb = LibraryDb;
        }

        public IQueryable<Book> GetBooks()
        {
            var books = LibraryDb.Books;
            return books;
        }

        public void AddBook(Book book)
        {
            LibraryDb.Books.Add(book);
        }

        public void SaveChanges()
        {
            LibraryDb.SaveChanges();
        }

        public void RemoveBook(int id)
        {
            var book = FindById(id);
            LibraryDb.Books.Remove(book);
        }

        public Book FindById(int id)
        {
            var foundBook = LibraryDb.Books.Find(id);
            return foundBook;
        }

        public void Booking(Book book)
        {
            book.BookingDate = DateTime.Now.Date;
            book.Status = Status.Booked;
        }
    }
}