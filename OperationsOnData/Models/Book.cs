using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OperationsOnData.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }
        public int NumberOfPages { get; set; }
        public Status Status { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

    }

    public enum Status
    {
        Available,
        Booked,
        Borrowed
    }
}