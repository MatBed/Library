using OperationsOnData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsOnData.Interfaces
{
    public interface ILibraryContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<User> Users { get; set; }
        int SaveChanges();
        DbEntityEntry Entry(object entity);
    }
}
