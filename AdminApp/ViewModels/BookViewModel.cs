using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OperationsOnData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminApp.ViewModels
{
    public class BookViewModel
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

        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }
    }
}