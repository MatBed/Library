using OperationsOnData.Models;
using OperationsOnData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsOnData.Interfaces
{
    public interface IAdminOperations
    {
        IQueryable<User> GetUsers();
        User FindUser(string id);
        BooksAndUserViewModel GetBooksOfUser(string id);
    }
}
