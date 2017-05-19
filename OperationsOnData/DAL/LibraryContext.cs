using Microsoft.AspNet.Identity.EntityFramework;
using OperationsOnData.Interfaces;
using OperationsOnData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OperationsOnData.DAL
{
    public class LibraryContext : IdentityDbContext, ILibraryContext
    {
        public LibraryContext() : base("Library")
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