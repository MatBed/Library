using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Library.ViewModels
{
    public class ListOfBooksViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }        
        public int NumberOfPages { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }
    }

    public enum Status
    {        
        Booked = 0,
        Available = 1,
        Borrowed = 2
    }
}