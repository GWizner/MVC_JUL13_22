using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCJUL13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCJUL13.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult NewUser()
        {
            var newUser = new User();
            newUser.Id = Program.userList.Count()+1;
            newUser.FirstName = "New";
            newUser.LastName = "User";
            newUser.FavoriteCartoon = "Unknown";
            return View(newUser);
        }
        [HttpPost]

        public IActionResult NewUserSubmit(User newUserData)
        {
            Program.userList.Add(newUserData);
           return View("NewUser", newUserData);
        }

        public IActionResult EditUser (int Id)
        {
            User targetUser = null;

            foreach (var currUser in Program.userList)
            { 
                if (currUser.Id == Id)
                {
                    targetUser = currUser;
                    break;
                }
            }
            
            if (targetUser != null)
            {
                return View("NewUser", targetUser);
            }
            else
            {
                throw new Exception("Ahhh!");
            }
        }

        public IActionResult EditUserSubmit (User newUserData)
        {
            User targetUser = null;

            foreach (var currUser in Program.userList)
            {
                if (currUser.Id == newUserData.Id)
                {
                    targetUser = currUser;
                    break;
                }
            }

            if (targetUser != null)
            {
                targetUser.FirstName = newUserData.FirstName;
                targetUser.LastName = newUserData.LastName;
                targetUser.FavoriteCartoon = newUserData.FavoriteCartoon;
                return Redirect("/");
            }
            else
            {
                throw new Exception("Ahhh!");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
