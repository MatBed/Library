using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Library.ViewModels
{
    public class ListOfBooksViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }

        [Display(Name = "Pages")]
        public int NumberOfPages { get; set; }

        public Status Status { get; set; }
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