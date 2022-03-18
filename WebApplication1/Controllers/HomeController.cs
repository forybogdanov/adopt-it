using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using Microsoft.AspNetCore.Identity;
using WebApplication1.Services;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<User> signInManager;

        public HomeController(ILogger<HomeController> logger, SignInManager <User> signInManager)
        {
            this.signInManager = signInManager;
            _logger = logger;
        }
        public IActionResult Index()
        {
            if (this.User != null)
            {
                var a = signInManager.IsSignedIn(this.User);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
