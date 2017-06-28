using OperationsOnData.Interfaces;
using OperationsOnData.Models;
using OperationsOnData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OperationsOnData.Library_Operations
{
    public class AdminOperations : IAdminOperations
    {
        private readonly ILibraryContext LibraryDb;

        public AdminOperations(ILibraryContext LibraryDb)
        {
            this.LibraryDb = LibraryDb;
        }

        public IQueryable<User> GetUsers()
        {
            var users = LibraryDb.Users;
            return users;
        }

        public User FindUser(string id)
        {
            User user = LibraryDb.Users.Find(id);
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