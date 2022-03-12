using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class PostController : Controller
    {
        private IPostService postService;
        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        public IActionResult Index()
        {
            List<Post> posts = postService.GetAll();

            return View(posts);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult ViewPost()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
