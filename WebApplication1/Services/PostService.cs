using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{

    public class PostService : IPostService
    {
        private UserDbContext dbContext;
        private AnimalService animalService;
        public PostService(UserDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.animalService = new AnimalService(dbContext);
            foreach (var post in dbContext.Posts.ToList<Post>())
            {
                post.Animal = animalService.GetById(post.AnimalId);
            }
            //Create(new Post(id++, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", new Animal("Sharo", 3, "dog", "stray"), 0, "Ivan", "ivan123@gmail.com", new DateTime()));
            //Create(new Post(id++, "Tempor nec feugiat nisl pretium fusce id velit ut. Commodo ullamcorper a lacus vestibulum sed arcu non odio. ", new Animal("Mecho", 7, "dog", "lost"), 1, "Pesho", "pesho123@gmail.com", new DateTime()));
        }
        public void Create(Post post)
        {
            dbContext.Posts.Add(post);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            animalService.Delete(GetById(id).AnimalId);
        }

        public void Edit(Post post)
        {
            Post oldPost = GetById(post.Id);
            oldPost.Description = post.Description;
            oldPost.Animal = post.Animal;
            dbContext.SaveChanges();
        }

        public Post GetById(int id)
        {
            return dbContext.Posts.FirstOrDefault(p => p.Id == id);
        }
        public List<Post> GetAll()
        {
            return dbContext.Posts.ToList<Post>();
        }
        public List<Post> GetUserPosts(int id)
        {
            return dbContext.Posts.Where(p => p.UserId == id).ToList<Post>();
        }
    }
}
