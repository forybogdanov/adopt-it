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
        private IData data;
        private int id = 0;

        public PostService(IData data)
        {
            this.data = data;
            Create(new Post(id++, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", new Animal("Sharo", 3, "dog", "stray"), 0, "Ivan", "ivan123@gmail.com", new DateTime()));
            Create(new Post(id++, "Tempor nec feugiat nisl pretium fusce id velit ut. Commodo ullamcorper a lacus vestibulum sed arcu non odio. ", new Animal("Mecho", 7, "dog", "lost"), 1, "Pesho", "pesho123@gmail.com", new DateTime()));
        }
        public void Create(Post post)
        {
            post.Created = DateTime.Now;
            data.Posts.Add(post);
        }

        public void Delete(int id)
        {
            Post post = GetById(id);
            data.Posts.Remove(post);
        }

        public void Edit(Post post)
        {
            Post oldPost = GetById(post.Id);
            oldPost.Description = post.Description;
            oldPost.Animal = post.Animal;
        }

        public Post GetById(int id)
        {
            return (data.Posts.FirstOrDefault(p => p.Id == id));
        }
        public List<Post> GetAll()
        {
            return data.Posts;
        }

    }
}
