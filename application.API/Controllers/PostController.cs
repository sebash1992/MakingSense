using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using application.API.Definitions.Services;
using AutoMapper;
using application.API.Dto;
using Microsoft.AspNetCore.Authorization;
using Serilog;
using System.Security.Claims;
using application.API.Definitions.Helpers;
using application.API.Models;
using application.API.Definitions.Helpers;

namespace application.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Policy")]
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        public PostController(IPostService postService, IMapper mapper)
        {
            _mapper = mapper;
            _postService = postService;
        }

        /// <summary>
        /// Get all the active posts, if a user is logged on it also returns the draft and private post for the user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// </remarks>
        /// <returns>Returns the posts</returns>
        /// <response code="200">Returns all the post requested</response>
        /// <response code="400">Something worng happens</response>   
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            try
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                string filterExpression = string.Format("State == \"{0}\"", Constants.Strings.States.Active);
                if (claimsIdentity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id) != null)
                {
                    var UserId = claimsIdentity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value;
                    filterExpression = string.Format("State == \"{0}\" OR ((State == \"{1}\" OR State == \"{2}\" )AND  ClientId == \"{3}\")", Constants.Strings.States.Active, Constants.Strings.States.Draft, Constants.Strings.States.Private, UserId);
                }
                var posts = _postService.Search(filterExpression, null, "Client");
                Response.AddResponseHeaders(_postService.Count(filterExpression));
                var postToReturn = _mapper.Map<IEnumerable<PostDto>>(posts);
                return Ok(postToReturn);

            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest();
            }
        }



        /// <summary>
        /// Get a specific post, if the post does not exist a new post will be created
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get/8234cfb3-3225-42b3-afc1-4e55af4c41ce
        /// </remarks>
        /// <returns>Returns the post requested</returns>
        /// <response code="200">Returns the post requested</response>
        /// <response code="400">Something worng happens</response>   
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;

                var UserId = claimsIdentity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value;
                string filterExpression = string.Format("Id == \"{0}\"", id);
                var post = _postService.Search(filterExpression, null, "Client").FirstOrDefault();

                if (post == null)
                {
                    post = new Post();
                }

                var postToReturn = _mapper.Map<PostDto>(post);
                return Ok(postToReturn);

            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest();
            }
        }

        /// <summary>
        /// Update/Create a post
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// </remarks>
        /// <returns>Returns if the acction can be performed or not</returns>
        /// <response code="200">Returns the post requested</response>
        /// <response code="400">Something worng happens</response>   
        [HttpPost]
        public IActionResult Post([FromBody]PostDto post)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var nPost = _mapper.Map<Post>(post);
                if (post.Id == null)
                {
                    var claimsIdentity = User.Identity as ClaimsIdentity;

                    var UserId = claimsIdentity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id).Value;
                    nPost.ClientId = UserId;
                    _postService.Create(nPost);
                }
                else
                {
                    _postService.Update(nPost);
                }
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest();
            }
        }



        /// <summary>
        /// Delete a specific post
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE/8234cfb3-3225-42b3-afc1-4e55af4c41ce
        /// </remarks>
        /// <returns>Returns if the acction can be performed or not</returns>
        /// <response code="200">Returns the post requested</response>
        /// <response code="400">Something worng happens</response>  
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _postService.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return BadRequest();
            }
        }
    }
}