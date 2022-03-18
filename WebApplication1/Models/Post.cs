using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Animal Animal { get; set; }
        [ForeignKey("Animal")]
        public int AnimalId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string Author { get; set; }
        public string AuthorEmail { get; set; }
        public DateTime Created { get; set; }


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
        public Post()
        {
        }
    }
}