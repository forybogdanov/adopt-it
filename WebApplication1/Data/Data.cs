using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class Data : IData
    {
        public List<User> Users { get; set; }
        public List<Post> Posts { get; set; }
        public List<Animal> Animals { get; set; }

        public Data()
        {
            this.Users = new List<User>();
            this.Posts = new List<Post>();
            this.Animals = new List<Animal>();
        }
    }
}