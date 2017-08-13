using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels
{
    public class BookedBookViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }
        public int NumberOfPages { get; set; }
        public Status Status { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? EndOfBookingDate { get; set; }
    }
}