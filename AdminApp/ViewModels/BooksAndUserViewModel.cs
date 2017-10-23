using OperationsOnData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminApp.ViewModels
{
    public class BooksAndUserViewModel
    {
        public Book Book { get; set; }
        public User User { get; set; }
        public IQueryable<Book> Books { get; set; }
    }
}