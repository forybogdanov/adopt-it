using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication1.Models.DTOs;
using WebApplication1.Services;
using Microsoft.AspNetCore.Authorization;

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

        [HttpPost]
        public IActionResult Create(UserDTO user) 
        {

            bool isCreated = userService.Create(user);

            if (isCreated)
            {
                TempData["signupDefaultMessage"] = null;
                return View(LoginAsync(user));
            }
            TempData["signupDefaultMessage"] = false;
            return RedirectToAction("Create");

        }


        [HttpGet]
        public IActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(UserDTO userDTO)
        {
            bool isLogged=userService.Login(userDTO);
            
            if (isLogged)
            {
                var user = userService.GetById(userService.LoggedId);  
                
                Claim[] claims = new[] { new Claim(ClaimTypes.Sid, user.Id.ToString()),
                     new Claim(ClaimTypes.Name, user.Username),
                     new Claim(ClaimTypes.Email, user.Email),
                     new Claim(ClaimTypes.Role, user.Role),};
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                                         CookieAuthenticationDefaults.AuthenticationScheme,
                                         new ClaimsPrincipal(identity),
                                         new AuthenticationProperties
                                         {
                                             IsPersistent = false   //remember me
                                               });
                

                TempData["loginDefaultMessage"] = null;
                return RedirectToAction("Index", "Home");
            }
            TempData["loginDefaultMessage"] = false;
            return RedirectToAction("Login");
        }


        


        [HttpGet]
       // [Authorize(Roles = "User")]
        public IActionResult Details()
        {
           UserDTO userDTO= userService.GetById(userService.LoggedId);
            return View(userDTO);
        }

        [HttpPost]
        public IActionResult Update(string firstName, string lastName,string city, string phoneNumber)
        {
            userService.Update( firstName,  lastName,  city,  phoneNumber);

            return RedirectToAction(nameof(Details));
        }

        [HttpGet]
        public IActionResult Delete()
        {
            userService.Delete();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> LogoutAsync()
        {
            userService.Logout();

            await HttpContext.SignOutAsync();
                return RedirectToAction("Index", "Home");
            
        }

    }
}
