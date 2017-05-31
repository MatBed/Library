using OperationsOnData.Interfaces;
using OperationsOnData.Models;
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

        public IQueryable GetUsers()
        {
            var users = LibraryDb.Users;
            return users;
        }

        public User FindUser(string id)
        {
            User user = LibraryDb.Users.Find(id);
            return user;
        }
    }
}