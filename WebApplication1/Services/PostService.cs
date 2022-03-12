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
        private int lastId = 0;

        public PostService(IData data)
        {
            this.data = data;
            Create(new Post(lastId++, "description 13232ewfw", new Animal("Sharo", 3, "dog", "stray"), 0, new DateTime()));
            Create(new Post(lastId++, "description cmwpd,", new Animal("Mecho", 7, "dog", "lost"), 0, new DateTime()));

        }
        public void Create(Post post)
        {
            data.Posts.Add(post);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(int id, Post post)
        {
            throw new NotImplementedException();
        }

        public Post GetById(int id)
        {
            throw new NotImplementedException();
        }
        public List<Post> GetAll()
        {
            return data.Posts;
        }

    }
}
