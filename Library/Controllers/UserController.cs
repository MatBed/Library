using Microsoft.AspNet.Identity;
using OperationsOnData.Interfaces;
using OperationsOnData.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ILibraryOperations libraryOperations;

        public UserController(ILibraryOperations libraryOperations)
        {
            this.libraryOperations = libraryOperations;
        }

        public ActionResult ShowUsers(string UsersSought)
        {
            IEnumerable<User> foundUsers;

            if (UsersSought == "")
                UsersSought = null;

            if (UsersSought != null)
            {
                foundUsers = libraryOperations.GetUsers().Where(s => s.SecondName == UsersSought || s.Name == UsersSought || (s.Name + " " + s.SecondName) == UsersSought);

                if (foundUsers.Count() == 0)
                {
                    ViewBag.Error = true;
                    return View(foundUsers.OrderBy(o => o.SecondName));
                }
            }
            else
                foundUsers = libraryOperations.GetUsers();

            if (Request.IsAjaxRequest())
                return View(foundUsers.OrderBy(o => o.SecondName));

            return View(foundUsers.OrderBy(o => o.SecondName));
        }

        public ActionResult Details(string id)
        {
            var foundUserAndBooks = libraryOperations.GetBooksOfUser(id);
            return View(foundUserAndBooks);
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                libraryOperations.RemoveUser(id);
                libraryOperations.SaveChanges();
            }
            catch
            {
                return View("ShowUsers");
            }

            TempData["Message"] = "Operation successful!";
            return RedirectToAction("ShowUsers");
        }
    }
}