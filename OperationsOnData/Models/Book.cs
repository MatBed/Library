﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OperationsOnData.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [MaxLength(40)]
        public string Title { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [MaxLength(40)]
        public string Author { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [MaxLength(25)]
        public string Type { get; set; }

        [Required(ErrorMessage = "This field is required!")]
        [Display(Name = "Pages")]
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