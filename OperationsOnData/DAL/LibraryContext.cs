using OperationsOnData.Interfaces;
using OperationsOnData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OperationsOnData.DAL
{
    public class LibraryContext : DbContext, ILibraryContext
    {
        public LibraryContext() : base("LibraryConnection")
        {

        }

        public static LibraryContext Create()
        {
            return new LibraryContext();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}