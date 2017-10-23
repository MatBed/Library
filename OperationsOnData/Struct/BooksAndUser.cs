using OperationsOnData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OperationsOnData.Struct
{
    public struct BooksAndUser
    {
        public Book Book { get; set; }
        public User User { get; set; }
        public IQueryable<Book> Books { get; set; }
    }
}