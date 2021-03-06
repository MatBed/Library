﻿using OperationsOnData.Interfaces;
using OperationsOnData.Models;
using OperationsOnData.Struct;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OperationsOnData.Library_Operations
{
    public class LibraryOperations : ISaveDatabase, IUserOperations, IBooksOperations
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
            if (LibraryDb.Books.Count() > 0)
            {
                var maxId = GetBooks().Max(m => m.BookId);
                book.BookId = maxId + 1;
            }
            else
            {
                var maxId = 1;
                book.BookId = maxId;
            }                

            LibraryDb.Books.Add(book);
        }

        public void SaveChanges()
        {
            LibraryDb.SaveChanges();
        }

        public void RemoveBook(int id)
        {
            var book = FindById(id);
            if(book.Status == Status.Available)
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
            book.EndBookingDate = null;
            book.Status = Status.Available;
        }

        public void ChangeStatus(Book book)
        {
            if (book.Status == Status.Available)
            {
                var user = FindUserById(book.UserId);
                user.NumberOfBooks--;
                book.EndBookingDate = null;
                book.ReturnDate = null;
                book.BookingDate = null;
                book.BorrowingDate = null;
                book.UserId = null;
            }

            if (book.Status == Status.Booked)
            {
                var user = FindUserById(book.UserId);
                book.BookingDate = DateTime.Now.Date;
                book.EndBookingDate = book.BookingDate.Value.AddDays(3);
                book.BorrowingDate = null;
                book.ReturnDate = null;
            }

            if (book.Status == Status.Borrowed)
            {
                book.BookingDate = null;
                book.EndBookingDate = null;
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

            if (user.NumberOfBooks == 0 && user.Obligation == 0)
                LibraryDb.Users.Remove(user);
        }

        public User FindUserById(string id)
        {
            var user = LibraryDb.Users.Find(id);
            return user;
        }

        public BooksAndUser GetBooksOfUser(string userId)
        {
            BooksAndUser booksOfUser = new BooksAndUser();
            var allUsers = GetUsers();
            var allBooks = GetBooks();

            booksOfUser.User = allUsers.Where(m => m.Id == userId).FirstOrDefault();
            booksOfUser.Books = allBooks.Where(m => m.UserId == userId);

            return booksOfUser;
        }

        public void EditBook(Book book)
        {
            LibraryDb.Entry(book).State = EntityState.Modified;
        }

        public void SetObligation()
        {
            var actuallDate = DateTime.Now;
            int numberOfDays;
            List<Book> books;
            List<int> obligation = new List<int>();
            var users = GetUsers();
            
            foreach (var user in users)
            {
                books = GetBooks().Where(m => m.UserId == user.Id && m.ReturnDate < actuallDate).ToList();
                foreach (var book in books)
                {
                    numberOfDays = (actuallDate - (DateTime)book.ReturnDate).Days;
                    obligation.Add(numberOfDays);
                }
                user.Obligation = obligation.Sum();
                obligation.RemoveRange(0, obligation.Count);
            }
        }

        public void ResetBookingBooks(string userId)
        {
            var books = GetBooks();
            var user = FindUserById(userId);
            user.NumberOfBooks--;
            var booksWithWrongDate = books.Where(m => m.EndBookingDate < DateTime.Now);

            foreach (var item in booksWithWrongDate)
            {
                item.Status = Status.Available;
                item.EndBookingDate = null;
                item.BookingDate = null;
                item.UserId = null;
            }            
        }
    }
}