using application.API.Definitions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using application.API.Models;
using application.API.Definitions.Repositories;
using application.API.Definitions.Helpers;
using Microsoft.AspNetCore.Identity;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace application.API.Business
{
    public class PostService : IPostService
    {
        private IRepository<Post> _postRepository;
        public PostService(IRepository<Post> PostRepository, UserManager<AppUser> userManager)
        {
            _postRepository = PostRepository ?? throw new ArgumentNullException(nameof(PostRepository));
        }
        public int Count(string filterExpression)
        {
            return _postRepository.Count(filterExpression);
        }

        public Post SearchById(string id)
        {
            return _postRepository.SearchById(id);
        }

        public Post Read(string filterExpression)
        {
            return _postRepository.Read(filterExpression);
        }

        public IEnumerable<Post> Search(string filterExpression, string sortingExpression, int? startIndex, int? count, string include)
        {
            return _postRepository.Search(filterExpression, sortingExpression, startIndex, count, include);
        }
        public IEnumerable<Post> Search(string filterExpression, string sortingExpression, string include)
        {
            return this.Search(filterExpression, sortingExpression, null, null, include);
        }
        public IEnumerable<Post> Search(string filterExpression, string sortingExpression)
        {
            return this.Search(filterExpression, sortingExpression, null, null, "");
        }
        public IEnumerable<Post> Search(string filterExpression, string sortingExpression, int? startIndex, int? count)
        {
            return this.Search(filterExpression, sortingExpression, null, null, "");
        }

        public void Delete(object id)
        {
            Post post = SearchById((string)id);
            if(post != null)
            {
                post.State = Constants.Strings.States.Deleted;
                Update(post);
            }
        }

        public void Create(Post entity)
        {


            entity.Id = System.Guid.NewGuid().ToString();
            _postRepository.Create(entity);
            _postRepository.SaveChanges();
        }

        public void Update(Post entity)
        {
            _postRepository.Update(entity);
            _postRepository.SaveChanges();
        }
    }
}
