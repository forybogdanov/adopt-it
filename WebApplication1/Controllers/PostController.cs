using Microsoft.AspNetCore.Identity;
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
        private UserManager<User> userManager;
        public PostController(IPostService postService, UserManager<User> userManager)
        {
            this.postService = postService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            List<Post> posts = postService.GetAll();

            return View(posts);
        }
        public async Task<IActionResult> UserPostsAsync()
        {
            User user = await userManager.GetUserAsync(User).ConfigureAwait(false);
            if (user is null) return RedirectToAction(nameof(Index));
            List<Post> posts = postService.GetUserPosts(user.Id);
            return View(posts);
        }
        public IActionResult Edit()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditAsync(int id)
        {
            User user = await userManager.GetUserAsync(User).ConfigureAwait(false);
            Post post = postService.GetById(id);
            if (user is null) return RedirectToAction(nameof(Index));
            if (post.UserId != user.Id) return RedirectToAction(nameof(UserPostsAsync));
            return View(postService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> EditAsync(Post post)
        {
            User user = await userManager.GetUserAsync(User).ConfigureAwait(false);
            if (user is null) return RedirectToAction(nameof(Index));
            if (post.UserId != user.Id) return RedirectToAction(nameof(UserPostsAsync));
            postService.Edit(post);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Post post)
        {
            User user = await userManager.GetUserAsync(User).ConfigureAwait(false);
            if (user is null) return RedirectToAction(nameof(Index));
            if (!ModelState.IsValid) return View();
            post.UserId = user.Id;
            post.Author = user.UserName;
            post.AuthorEmail = user.Email;
            post.Created = DateTime.Now;
            postService.Create(post);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            User user = await userManager.GetUserAsync(User).ConfigureAwait(false);
            Post post = postService.GetById(id);
            if (user is null) return RedirectToAction(nameof(Index));
            if (post.UserId != user.Id) return RedirectToAction(nameof(UserPostsAsync));
            return View(post);
        }
        public async Task<IActionResult> ConfirmDeleteAsync(int id)
        {
            User user = await userManager.GetUserAsync(User).ConfigureAwait(false);
            Post post = postService.GetById(id);
            if (user is null) return RedirectToAction(nameof(Index));
            if (post.UserId != user.Id) return RedirectToAction(nameof(UserPostsAsync));
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
