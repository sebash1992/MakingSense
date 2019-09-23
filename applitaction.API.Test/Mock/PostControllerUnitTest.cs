using application.API.Controllers;
using application.API.Definitions.Helpers;
using application.API.Definitions.Services;
using application.API.Dto;
using application.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace applitaction.API.Test.Mock
{
    public class PostControllerUnitTest
    {
        [Fact]
        public void GetPosts()
        {
            // Arrange
            var mockRepo = new Mock<IPostService>();

            mockRepo.Setup(x => x.Search("State == \"Activo\"",  null, "Client")).Returns(GetMockPosts().Where(x => x.State == Constants.Strings.States.Active));
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new PostProfile()));
            var mapper = new Mapper(configuration);



            var controller = new PostController(mockRepo.Object, mapper);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = createContext() }
            };

            // Act
            var result = controller.Get();

            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<PostDto>>(
                viewResult.Value);
            Assert.Single(model);
        }



        [Fact]
        public void GetPostsAuth()
        {

            // Arrange
            var mockRepo = new Mock<IPostService>();

            mockRepo.Setup(x => x.Search("State == \"Activo\" OR ((State == \"Draft\" OR State == \"Privado\" )AND  ClientId == \"3a7fc558-6db4-4835-956c-521e2ba0a234\")", null, "Client")).Returns(GetMockPosts());
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new PostProfile()));
            var mapper = new Mapper(configuration);



            var controller = new PostController(mockRepo.Object, mapper);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = Auth() }
            };

            // Act
            var result = controller.Get();

            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<PostDto>>(
                viewResult.Value);
            Assert.Equal(5,model.Count());
        }



        private IEnumerable<Post> GetMockPosts()
        {
            var list = new List<Post>()
            {
                new Post()
                {
                    Body = "LorempInsum",
                    Title = "LorempInsum",
                    State = Constants.Strings.States.Active,
                    CreationDate = DateTime.Now,
                    Id= "3a7fc558-6db4-4835-956c-521e2ba0a234",
                    ClientId = "3a7fc558-6db4-4835-956c-521e2ba0a234",
                    Client = new AppUser()
                    {
                        Id = "3a7fc558-6db4-4835-956c-521e2ba0a234",
                        FirstName = "Test",
                        LastName = "User"
                    }

                },
                new Post()
                {
                    Body = "LorempInsum",
                    Title = "LorempInsum",
                    State = Constants.Strings.States.Draft,
                    CreationDate = DateTime.Now,
                    Id= "4a7fc558-6db4-4835-956c-521e2ba0a234",
                    ClientId = "3a7fc558-6db4-4835-956c-521e2ba0a234",
                                        Client = new AppUser()
                    {
                        Id = "3a7fc558-6db4-4835-956c-521e2ba0a234",
                        FirstName = "Test",
                        LastName = "User"
                    }
                },
                 new Post()
                {
                    Body = "LorempInsum",
                    Title = "LorempInsum",
                    State = Constants.Strings.States.Deleted,
                    CreationDate = DateTime.Now,
                    Id= "5a7fc558-6db4-4835-956c-521e2ba0a234",
                    ClientId = "3a7fc558-6db4-4835-956c-521e2ba0a234"
                },
                new Post()
                {
                    Body = "LorempInsum",
                    Title = "LorempInsum",
                    State = Constants.Strings.States.Private,
                    CreationDate = DateTime.Now,
                    Id= "5a7fc558-6db4-4835-956c-521e2ba0a234",
                    ClientId = "3a7fc558-6db4-4835-956c-521e2ba0a234",
                                        Client = new AppUser()
                    {
                        Id = "3a7fc558-6db4-4835-956c-521e2ba0a234",
                        FirstName = "Test",
                        LastName = "User"
                    }
                },
                                new Post()
                {
                    Body = "LorempInsum",
                    Title = "LorempInsum",
                    State = Constants.Strings.States.Private,
                    CreationDate = DateTime.Now,
                    Id= "6a7fc558-6db4-4835-956c-521e2ba0a234",
                    ClientId = "3a7fc558-6db4-4835-956c-421e2ba0a234",
                                        Client = new AppUser()
                    {
                        Id = "3a7fc558-6db4-4835-956c-421e2ba0a234",
                        FirstName = "Test2",
                        LastName = "User"
                    }
                },
            };
            return list.AsEnumerable();

        }



        private ClaimsPrincipal Auth()
        {
            return new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "example name"),
                    new Claim(Constants.Strings.JwtClaimIdentifiers.Id, "3a7fc558-6db4-4835-956c-521e2ba0a234"),
                    new Claim("custom-claim", "example claim value"),
                }, "mock"));
        }

        private ClaimsPrincipal createContext()
        {
            return new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                }, "mock"));




        }
    }
}
