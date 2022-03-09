using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class AnimalModel
    {
        private string name;
        private int age;
        private string specie;
        private string status; // lost found stray

        public AnimalModel(string name, int age, string specie, string status)
        {
            Name = name;
            Age = age;
            Specie = specie;
            status = status;
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
            get { return specie; }
            set { specie = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}