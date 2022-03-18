using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Animal
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Species { get; set; }
        [Required]
        public string Status { get; set; }  // lost/found/stray

        public Animal()
        {
            Name = "";
            Age = 0;
            Species = "";
            Status = "";
        }

        public Animal(string name, int age, string species, string status)
        {
            Name = name;
            Age = age;
            Species = species;
            Status = status;
        }
    }
}
