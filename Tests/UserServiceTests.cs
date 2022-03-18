using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;
using WebApplication1.Services;

namespace Tests
{
    [TestFixture]

    public class UserServiceTests
    {
        private UserService userService;

        private User user;

        public UserServiceTests()
        {


            this.userService = userService;
                //= new UserService(dbContext);
        }

        [SetUp]
        public void Setup()
        {
            this.user = new User();
        }

        [Test]
        public void Update()
        {

            Assert.Throws<System.ArgumentException>(() => user.UserName = "");
        }

        [Test]
        public void Delete()
        {

            Assert.Throws<System.ArgumentException>(() => user.UserName = "");
        }
        [Test]
        public void GetEntityById()
        {

            Assert.Throws<System.ArgumentException>(() => user.UserName = "");
        }
        [Test]
        public void GetById()
        {
            User user = new User();

            UserDTO userDTO = new UserDTO();


            Assert.Throws<System.ArgumentException>(() => user.UserName = "");
        }
        [Test]
        public void toDTO()
        {
            User user = new User();
            
            UserDTO userDTO= new UserDTO();

            // ?? toDTO() e private
        }



    }
}
