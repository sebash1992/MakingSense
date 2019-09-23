using application.API.Dto;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace application.API.DataAccess
{
    public static class Seed
    {

        public static async Task Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            return;
        }
    }
}
