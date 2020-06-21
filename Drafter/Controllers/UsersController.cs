using AutoMapper;
using Drafter.Model;
using Drafter.Model.Resources;
using Drafter.Extensions;
using Drafter.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace Drafter.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [EnableCors("MyPolicy")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService UserService;

        private readonly IWebHostEnvironment Environment;

        private readonly IMapper Mapper;

        public UsersController(IUserService userService, IMapper mapper, IWebHostEnvironment environment)
        {
            UserService = userService;
            Mapper = mapper;
            Environment = environment;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable> GetAll()
        {
            return Mapper.MapList<UserResource>(await UserService.GetAllAsync());
        }


        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            User user = await UserService.GetByIdAsync(id);
            return user == null ? (IActionResult)NotFound() : Ok(Mapper.Map<UserResource>(user));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody]CreateUserResource user)
        {
            var result = await UserService.CreateAsync(Mapper.Map<User>(user));
            return result.Succes ? Created("GetById", Mapper.Map<UserResource>(result.Entity)) : (IActionResult)Conflict(result.Message);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateUserResource user)
        {
            var result = await UserService.UpdateAsync(Mapper.Map<User>(user), Convert.ToInt32(User.Identity.Name));
            return result.Succes ? Ok(Mapper.Map<UserResource>(user)) : (IActionResult)Conflict(result.Message);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            var result = await UserService.RemoveAsync(Convert.ToInt32(User.Identity.Name));
            return result.Succes ? Ok() : (IActionResult)Conflict(result.Message);
        }

        [HttpGet("search")]
        [AllowAnonymous]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            return Ok(await UserService.Search(query));
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticationResource user)
        {
            string token = await UserService.Authenticate(Mapper.Map<User>(user));
            return token == null ? Unauthorized() : (IActionResult)Ok(token);
        }

        //[HttpDelete("profile{Id:int}")]
        //public async Task<IActionResult> DeleteProfile(int Id)
        //{
        //    return Ok(await ProfileService.RemoveAsync(Id));
        //}

        //[HttpDelete("profile/festivals{userId:int}")]
        //public async Task<IActionResult> GetAttendingFestivals(int userId)
        //{
        //    return Ok(await ProfileService.GetAttendingFestivals(userId));
        //}
    }
}