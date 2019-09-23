using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using application.API.DataAccess;
using application.API.Definitions.Helpers;
using application.API.Dto;
using application.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace application.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly DataContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        public AccountController(UserManager<AppUser> userManager, IMapper mapper, DataContext appDbContext, IHttpContextAccessor httpContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
            _httpContext = httpContext;
        }

        /// <summary>
        /// Create a user
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <returns>Returns if the acction can be performed or not</returns>
        /// <response code="200">Returns the post requested</response>
        /// <response code="400">Something worng happens</response>  
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserDetailDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var userIdentity = _mapper.Map<AppUser>(model);
                if (userIdentity.Id != null)
                {
                    var user = await _userManager.FindByIdAsync(userIdentity.Id);
                    user.FirstName = userIdentity.FirstName;
                    user.LastName = userIdentity.LastName;
                    var result = await _userManager.UpdateAsync(user);
                    if (!await _userManager.IsInRoleAsync(userIdentity, model.Role))
                    {
                        var roles = await _userManager.GetRolesAsync(user);
                        await _userManager.RemoveFromRolesAsync(user, roles);
                        var roleResult = await _userManager.AddToRoleAsync(user, model.Role);
                    }
                }
                else
                {
                    var result = await _userManager.CreateAsync(userIdentity, model.Password);
                    if (result == IdentityResult.Success)
                    {
                        var roleResult = await _userManager.AddToRoleAsync(userIdentity, model.Role);
                    }
                    else
                    {
                        return BadRequest(result.Errors);
                    }

                    //if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

                    await _appDbContext.SaveChangesAsync();
                }


                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}