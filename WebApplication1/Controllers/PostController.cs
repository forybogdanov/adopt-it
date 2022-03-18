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
        public IActionResult Edit()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(postService.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(int id, Post post)
        {
            post.Id = id;
            postService.Edit(post);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Post post)
        {
            postService.Create(post);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(postService.GetById(id));
        }
        public IActionResult ConfirmDelete(int id)
        {
            postService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult ViewPost(int id)
        {
            return View(postService.GetById(id));
        }
    }
}
