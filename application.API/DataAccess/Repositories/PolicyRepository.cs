using application.API.Models;
using application.API.Definitions.Repositories;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System;
using application.API.Definitions.Helpers;
using application.API.Dto;

namespace application.API.DataAccess.Repositories
{
    public class PostRepository : Repository<Post>, IRepository<Post>
    {

        public PostRepository(DataContext context) : base(context)
        {
        }
    }
}