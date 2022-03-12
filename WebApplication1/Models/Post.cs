using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Post
    {
        private int id;
        private string description;
        private Animal animal = new Animal();
        private int userId;
        private string author;
        private string authorEmail;
        private DateTime created;


        public Post(int id, string description, Animal animal, int userId, string author, string authorEmail, DateTime created)
        {
            Id = id;
            Description = description;
            Animal = animal;
            UserId = userId;
            Author = author;
            AuthorEmail = authorEmail;
            Created = created;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public Animal Animal
        {
            get { return animal; }
            set { animal = value; }
        }
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        public DateTime Created
        {
            get { return created; }
            set { created = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public string AuthorEmail 
        {
            get { return authorEmail; }
            set { authorEmail = value; }
        }
    }
}