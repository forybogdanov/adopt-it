using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;
        
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

       /* [HttpPost]
        public IActionResult Create(string username, string email, string password)
        {
            userService.Create(username, email, password);

            return RedirectToAction(nameof(Index));  //s nameof ako promenim imeto na Index ot otgore i tyk 6te se promeni
        }*/
        [HttpPost]
        public IActionResult Create(UserDTO user) // sega user entity iz4ezva ot kontrolera 
        {
            userService.Create(user);

            return RedirectToAction(nameof(Index)); 
        }


        [HttpGet]
        public IActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserDTO user)
        {
            bool command=userService.Login(user);
            
            if (command)
            {
                TempData["loginDefaultMessage"] = null;
                return RedirectToAction("Index", "Home");
                // return View(nameof(Create));
            }
            TempData["loginDefaultMessage"] = false;
            return RedirectToAction("Login");
        }

    }
}
