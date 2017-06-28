using OperationsOnData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class UserController : Controller
    {
        private readonly IAdminOperations AdminOperations;

        public UserController(IAdminOperations AdminOperations)
        {
            this.AdminOperations = AdminOperations;
        }

        public ActionResult ShowUsers()
        {
            var users = AdminOperations.GetUsers();
            return View(users);
        }

        public ActionResult Details(string id)
        {
            var foundUser = AdminOperations.FindUser(id);
            var foundBooks = AdminOperations.GetBooksOfUser(id);

            var foundUserAndBooks = AdminOperations.GetBooksOfUser(id);

            return View(foundUserAndBooks);
        }
    }
}