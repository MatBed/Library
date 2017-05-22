using OperationsOnData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsOnData.Interfaces
{
    public interface ILibraryOperations
    {
        IQueryable<Book> GetBooks();
        void AddBook(Book book);
        void SaveChanges();
        void RemoveBook(int id);
        Book FindById(int id);
        void Booking(Book book);
    }
}
