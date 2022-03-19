using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;
using WebApplication1.Services;

namespace Tests
{
    [TestFixture]

    public class UserServiceTests
    {
        private UserService userService;
        private UserDbContext context;

        private User user;


        [SetUp]
        public void Setup()
        {

            var options = new DbContextOptionsBuilder<UserDbContext>()
               .UseInMemoryDatabase("TestDb").Options;

            this.context = new UserDbContext(options);
            userService = new UserService(this.context);



            this.user = new User();
            user.Id = 1;
            user.Email = "asd@asd.com";
            context.Users.Add(user);
            context.SaveChanges();

        }

        [Test]
        public void TestUpdate()
        {

            UserDTO userDTO = new UserDTO();
            userDTO.FirstName = "Alex";
            userDTO.LastName = "Ivanova";
            userDTO.City = "Sofia";
            userDTO.PhoneNumber = "0888888888";

            userService.Update(user.Id, userDTO);

            User userDB = context.Users.FirstOrDefault(u => u.Id == user.Id);

            Assert.NotNull(userDB);
            Assert.AreEqual(userDB.FirstName, "Alex");
            Assert.AreEqual(userDB.LastName, "Ivanova");
            Assert.AreEqual(userDB.City, "Sofia");
            Assert.AreEqual(userDB.PhoneNumber, "0888888888");


        }

        [Test]
        public void TestDelete()
        {

            userService.Delete(user.Id);

            User userDB = context.Users.FirstOrDefault(u => u.Id == user.Id);

            Assert.Null(userDB);
        }
        [Test]
        public void TestGetEntityById()
        {

            User userDB = userService.GetEntityById(user.Id);

            Assert.AreEqual(userDB.Email, "asd@asd.com");
        }
        [Test]
        public void TestGetById()
        {
            UserDTO userDB = userService.GetById(user.Id);

            Assert.AreEqual(userDB.Email, "asd@asd.com");
        }


        [TearDown]
        public void TearDown()
        {
            this.context.Database.EnsureDeleted();
        }

    }
}
