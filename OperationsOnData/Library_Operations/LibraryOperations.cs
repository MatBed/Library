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
    }
}