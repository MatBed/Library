using OperationsOnData.Models;
using OperationsOnData.Struct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsOnData.Interfaces
{
    public interface IBooksOperations
    {
        void RemoveBook(int id);
        void EditBook(Book book);
        void AddBook(Book book);
        BooksAndUser GetBooksOfUser(string id);
        void ChangeStatus(Book book);
        IQueryable<Book> GetBooks();
        Book FindById(int id);
    }
}
