using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels
{
    public class BorrowedBookViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }

        [Display(Name = "Pages")]
        public int NumberOfPages { get; set; }

        public Status Status { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Borrowing date")]
        public DateTime? BorrowingDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Return date")]
        public DateTime? ReturnDate { get; set; }
    }
}