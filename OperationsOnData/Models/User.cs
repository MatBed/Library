﻿using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OperationsOnData.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Books = new HashSet<Book>();
        }

        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Second Name is required!")]
        [Display(Name = "Second Name")]
        public string SecondName { get; set; }

        [Range(0, 5)]
        [Display(Name = "Count of books")]
        public byte NumberOfBooks { get; set; }
        
        [Range(0, 1000)]
        public double Obligation { get; set; }

        public virtual ICollection<Book> Books { get; private set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}