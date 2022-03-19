using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;

namespace Tests
{
    [TestFixture]
    class AnimalServiceTests
    {
        private AnimalService animalService;

        private UserDbContext context;

        private Animal animal;

        private int animalId = 1;

        [SetUp]
        public void Setup()
        {

            var options = new DbContextOptionsBuilder<UserDbContext>()
               .UseInMemoryDatabase("TestDb").Options;

            this.context = new UserDbContext(options);
            animalService = new AnimalService(this.context);


            Animal animal = new Animal( "animal name",12, "species","lost");
            animal.Id = animalId;

            context.Animals.Add(animal);
            context.SaveChanges();

        }

        [Test]
        public void TestCreate()
        {

            Animal animal2 = new Animal("animal two", 12, "species", "found");

            animalService.Create(animal2);

            Animal animalDB = context.Animals.FirstOrDefault(p => p.Id == animal2.Id);

            Assert.NotNull(animalDB);
        }

        [Test]
        public void TestEdit()
        {

            Animal animal2 = new Animal("animal two", 12, "species", "found");
            animal2.Id = animalId;

            animalService.Edit(animal2);

            Animal animalDB = context.Animals.FirstOrDefault(p => p.Id == animalId);

            Assert.NotNull(animalDB);
            Assert.AreEqual(animalDB.Name, "animal two");
            Assert.AreEqual(animalDB.Age, 12);
            Assert.AreEqual(animalDB.Status, "found");

        }

        [Test]
        public void TestDelete()
        {

            animalService.Delete(animalId);

            Animal animalDB = context.Animals.FirstOrDefault(p => p.Id == animalId);

            Assert.Null(animalDB);
        }


        [Test]
        public void TestGetById()
        {

            Animal animalDB = animalService.GetById(animalId);

            Assert.AreEqual(animalDB.Name, "animal name");
            Assert.AreEqual(animalDB.Age, 12);
            Assert.AreEqual(animalDB.Species, "species");
            Assert.AreEqual(animalDB.Status, "lost");
        }


        [TearDown]
        public void TearDown()
        {
            this.context.Database.EnsureDeleted();
        }

        
    }
}
