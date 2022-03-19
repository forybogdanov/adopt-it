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
    class PostServiceTests
    {
        private PostService postService;

        private UserDbContext context;

        private Post post;
        private int userId = 1;

        [SetUp]
        public void Setup()
        {

            var options = new DbContextOptionsBuilder<UserDbContext>()
               .UseInMemoryDatabase("TestDb").Options;

            this.context = new UserDbContext(options);
            postService = new PostService(this.context);


            Animal animal = new Animal();
            animal.Id = 1;
            animal.Name = "animal name";
            animal.Age = 12;
            animal.Species = "species";
            animal.Status = "lost";


            this.post = CreatePost(1,"Alex", "description", userId);
            post.Animal = animal;
            post.AnimalId = animal.Id;

            context.Posts.Add(post);
            context.SaveChanges();

        }

        [Test]
        public void TestCreate()
        {
            Post post = CreatePost(2, "Alex", "description 2", userId);

            postService.Create(post);

            Post postDB = context.Posts.FirstOrDefault(p=>p.Id== post.Id);

            Assert.NotNull(postDB);
        }
        
        [Test]
        public void TestEdit()
        {

            Post post = CreatePost(1, "Alex", "changed description",userId);
            post.Animal = new Animal();

            postService.Edit(post);

            Post postDB =context.Posts.FirstOrDefault(p => p.Id == post.Id);

            Assert.NotNull(postDB);
            Assert.AreEqual(postDB.Description, "changed description");

        }

        [Test]
        public void TestDelete()
        {
            postService.Delete(post.Id);

            Post postDB = context.Posts.FirstOrDefault(p => p.Id == post.Id);

            Assert.Null(postDB);
        }


        [Test]
        public void TestGetAll()
        {
            Post post2 = CreatePost(2, "Toni", "description 2",2);
            Post post3 = CreatePost(3, "Duci", "description 3",3);

            postService.Create(post2);
            postService.Create(post3);

            List<Post> posts = postService.GetAll();

            Assert.AreEqual(3, posts.Count);
            Assert.AreEqual("Alex", posts[0].Author);

        }


        [Test]
        public void TestGetById()
        {

            Post postDB = postService.GetById(post.Id);

            Assert.AreEqual(postDB.Description, "description");
        }
        

        [Test]
        public void TestGetUserPosts()
        {
            Post post2 = CreatePost(2, "Toni", "description 2", 2);
            Post post3 = CreatePost(3, "Alex", "description 3", userId);

            postService.Create(post2);
            postService.Create(post3);

            List<Post> posts = postService.GetUserPosts(userId);


            Assert.AreEqual(2, posts.Count);
            Assert.AreEqual("Alex", posts[0].Author);
        }


        [TearDown]
        public void TearDown()
        {
            this.context.Database.EnsureDeleted();
        }


        private Post CreatePost(int id, string author, string description, int userId)
        {
            Post post = new Post();
            post.Id = id;
            post.Author = author;
            post.Description = description;
            post.UserId = userId;

            return post;
        }
    }
}
