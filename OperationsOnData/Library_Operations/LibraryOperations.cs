using OperationsOnData.Interfaces;
using OperationsOnData.Models;
using OperationsOnData.ViewModels;
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

        public void Booking(Book book, string id)
        {
            var user = FindUserById(id);
            user.NumberOfBooks++;
            book.BookingDate = DateTime.Now.Date;
            book.EndBookingDate = book.BookingDate.Value.AddDays(3);
            book.Status = Status.Booked;
        }

        public void CancleBooking(Book book, string id)
        {
            var user = FindUserById(id);
            user.NumberOfBooks--;
            book.BookingDate = null;
            book.Status = Status.Available;

            //if(book.EndBookingDate > DateTime.Now.Date)
            //    book.Status = Status.Available;
        }

        public void ChangeStatus(Book book, string id)
        {
            if (book.Status == Status.Available)
            {
                book.UserId = null;
                book.BookingDate = null;
                book.BorrowingDate = null;
                var user = FindUserById(id);
                user.NumberOfBooks--;
            }                

            if(book.Status == Status.Borrowed)
            {
                book.BookingDate = null;
                book.BorrowingDate = DateTime.Now.Date;
                book.ReturnDate = book.BorrowingDate.Value.AddDays(180);
            }

            LibraryDb.Entry(book).State = System.Data.Entity.EntityState.Modified;
        }

        public IQueryable<User> GetUsers()
        {
            var users = LibraryDb.Users;
            return users;
        }

        public void RemoveUser(string id)
        {
            var user = FindUserById(id);

            if (user.NumberOfBooks == 0)
                LibraryDb.Users.Remove(user);
        }

        public User FindUserById(string id)
        {
            var user = LibraryDb.Users.Find(id);
            return user;
        }

        public BooksAndUserViewModel GetBooksOfUser(string id)
        {
            LibraryOperations libraryOperations = new LibraryOperations(LibraryDb);
            BooksAndUserViewModel booksAndUserViewModel = new BooksAndUserViewModel();

            var allUsers = GetUsers();
            var allBooks = libraryOperations.GetBooks();
            booksAndUserViewModel.User = allUsers.Where(m => m.Id == id).FirstOrDefault();
            booksAndUserViewModel.Books = allBooks.Where(m => m.UserId == id);

            return booksAndUserViewModel;
        }
    }
}