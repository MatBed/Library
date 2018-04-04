using OperationsOnData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsOnData.Interfaces
{
    public interface IUserOperations
    {
        IQueryable<User> GetUsers();
        void RemoveUser(string id);
        User FindUserById(string id);
        void Booking(Book book, string id);
        void CancleBooking(Book book, string id);
        void ResetBookingBooks(string userId);
        void SetObligation();
    }
}
