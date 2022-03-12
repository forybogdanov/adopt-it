using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Animal
    {
        private string name;
        private int age;
        private string species;
        private string status; // lost/found/stray

        public Animal()
        {
        }

        public Animal(string name, int age, string species, string status)
        {
            Name = name;
            Age = age;
            Specie = species;
            Status = status;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public string Specie
        {
            get { return species; }
            set { species = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
