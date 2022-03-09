using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class PostModel
    {
        private int id;
        private string description;
        private AnimalModel animal = new AnimalModel();
        private int userId;
        private DateTime created;
        

        public PostModel(int id, string description, AnimalModel animal, int userId, DateTime created)
        {
            Id = id;
            Description = description;
            AnimalModel = animal;
            userId = userId;
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
        public AnimalModel Animal
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
    }
}