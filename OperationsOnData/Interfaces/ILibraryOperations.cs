using OperationsOnData.Models;
using OperationsOnData.ViewModels;
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
        void EditBook(Book book);
        Book FindById(int id);
        void Booking(Book book, string id);
        void CancleBooking(Book book, string id);
        void ChangeStatus(Book book);
        void ResetEndBookingDate();

        IQueryable<User> GetUsers();
        void RemoveUser(string id);
        User FindUserById(string id);
        BooksAndUserViewModel GetBooksOfUser(string id);
    }
}
