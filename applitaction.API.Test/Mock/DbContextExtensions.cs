using application.API.DataAccess;
using application.API.Definitions.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace applitaction.API.Test.Mock
{
    public static class DbContextExtensions
    {
        public static void Seed(this DataContext dbContext)
        {
            // Add entities for DbContext instance

            dbContext.Posts.Add(new application.API.Models.Post
            {
                Body= "Lorem ipsum dolor sit amet,consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.," ,
                Title = "Lorem ipsum",
                State = Constants.Strings.States.Active,
                CreationDate = DateTime.Now,
                Id = Guid.NewGuid().ToString(),
                ClientId = Guid.NewGuid().ToString()
            });

        }
    }
}
