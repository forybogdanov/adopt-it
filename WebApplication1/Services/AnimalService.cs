using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class AnimalService : IAnimalService
    {
        private UserDbContext dbContext;

        public AnimalService(UserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void Create(Animal animal)
        {
            dbContext.Animals.Add(animal);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            dbContext.Animals.Remove(GetById(id));
            dbContext.SaveChanges();
        }

        public void Edit(Animal animal)
        {
            Animal oldAnimal = GetById(animal.Id);
            oldAnimal = animal;
            dbContext.SaveChanges();
        }

        public Animal GetById(int id)
        {
            return dbContext.Animals.FirstOrDefault(p => p.Id == id);
        }
    }
}
