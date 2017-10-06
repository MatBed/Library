using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Script.Serialization;

namespace OperationsOnData.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [MaxLength(140)]
        public string Title { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [MaxLength(80)]
        public string Author { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [MaxLength(50)]
        public string Type { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [Display(Name = "Pages")]
        public int NumberOfPages { get; set; }

        public Status Status { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Booking date")]
        public DateTime? BookingDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "End booking date")]
        public DateTime? EndBookingDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Borrowing date")]
        public DateTime? BorrowingDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Return date")]
        public DateTime? ReturnDate { get; set; }

        public string UserId { get; set; }

        [ScriptIgnore]
        public User User { get; set; }
    }

    public enum Status
    {
        [EnumMember(Value = "Available")]
        Available = 1,

        [EnumMember(Value = "Booked")]
        Booked = 0,

        [EnumMember(Value = "Borrowed")]
        Borrowed = 2
    }
}