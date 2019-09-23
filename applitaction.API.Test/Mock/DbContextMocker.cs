using application.API.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace applitaction.API.Test.Mock
{
    public static class DbContextMocker
    {
        public static DataContext GetWideWorldImportersDbContext(string dbName)
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            // Create instance of DbContext
            var dbContext = new DataContext(options);

            // Add entities in memory
            dbContext.Seed();

            return dbContext;
        }
    }
}
