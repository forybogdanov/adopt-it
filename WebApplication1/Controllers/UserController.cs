using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Models.DTOs;
using WebApplication1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Models;
using System;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;
        private UserManager<User> userManager;

        public UserController(IUserService userService, UserManager<User > userManager)
        {
            this.userService = userService;
            this.userManager = userManager;
        }



        [HttpGet]
        public async Task< IActionResult> Details()
        {
            User user = await userManager.GetUserAsync(User);
            TempData["loggedId"] = user.Id;
            UserDTO userDTO =userService.GetById(user.Id);


              return View(userDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserDTO userDTO)
        {
            
            User user = await userManager.GetUserAsync(User);
            _ = TempData["loggedId"];
            userService.Update(user.Id, userDTO);

            
            return RedirectToAction(nameof(Details));
        }

        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            User user = await userManager.GetUserAsync(User);
            userService.Delete(user.Id);

            return RedirectToAction("Logout", "Account");
        }

        
    }
}
