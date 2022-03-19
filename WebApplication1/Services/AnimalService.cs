using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    //
    //Summary:
    //  Implements CRUD operations with the DB for the Class Animal
    //
    public class AnimalService : IAnimalService
    {
        private UserDbContext dbContext;

        public AnimalService(UserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //
        //Summary:
        //  Base method for the AnimalService used to Create a new instance of the class Animal and update the DB
        //
        public void Create(Animal animal)
        {
            dbContext.Animals.Add(animal);
            dbContext.SaveChanges();
        }
        //
        //Summary:
        //    Base method for the AnimalService used to Delete an instance of the class Animal and remove it from the DB
        //
        public void Delete(int id)
        {
            dbContext.Animals.Remove(GetById(id));
            dbContext.SaveChanges();
        }
        //
        //Summary:
        //    Base method for the AnimalService used to Edit an instance of the class Animal and update the DB
        //
        public void Edit(Animal animal)
        {
            Animal oldAnimal = GetById(animal.Id);
            oldAnimal.Age = animal.Age;
            oldAnimal.Name = animal.Name;
            oldAnimal.Species = animal.Species;
            oldAnimal.Status = animal.Status;
            dbContext.SaveChanges();
        }
        //
        //Summary:
        //    Base method for the AnimalService used to find an instance of the class Animal in the DB Context by Id
        //
        public Animal GetById(int id)
        {
            return dbContext.Animals.FirstOrDefault(p => p.Id == id);
        }
    }
}
