using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    //
    //Summary:
    //  Implements CRUD operations with the DB for the class Post
    //
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
        }
        //
        //Summary:
        //  Creates a new post and ads it to the DB
        //
        public void Create(Post post)
        {
            dbContext.Posts.Add(post);
            dbContext.SaveChanges();
        }
        //
        //Summary:
        //  Deletes a post found by its id and removes it from the DB
        //
        public void Delete(int id)
        {
            animalService.Delete(GetById(id).AnimalId);
        }
        //
        //Summary:
        //  Edits a post and updates the DB
        //
        public void Edit(Post post)
        {
            Post oldPost = GetById(post.Id);
            oldPost.Description = post.Description;
            oldPost.Animal.Age = post.Animal.Age;
            oldPost.Animal.Name = post.Animal.Name;
            oldPost.Animal.Species = post.Animal.Species;
            oldPost.Animal.Status = post.Animal.Status;
            dbContext.SaveChanges();
        }
        //
        //Summary:
        //  Finds a post by Id
        //
        public Post GetById(int id)
        {
            return dbContext.Posts.FirstOrDefault(p => p.Id == id);
        }
        //
        //Summary:
        //  Returns all posts in the DB
        //
        public List<Post> GetAll()
        {
            return dbContext.Posts.ToList<Post>();
        }
        //
        //Summary:
        //  Returns all posts having the given userId
        //
        public List<Post> GetUserPosts(int id)
        {
            return dbContext.Posts.Where(p => p.UserId == id).ToList<Post>();
        }
    }
}
