using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IPostService
    {

        void Edit(Post post);
        void Delete(int id);
        Post GetById(int id);
        void Create(Post post);
        List<Post> GetAll();
        List<Post> GetUserPosts(int id);
    }
}