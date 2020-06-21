using AutoMapper;
using Drafter.Extensions;
using Drafter.Interfaces.Services;
using Drafter.Model;
using Drafter.Model.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace Drafter.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/[controller]")]
    [EnableCors("MyPolicy")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService TeamService;

        private readonly IWebHostEnvironment Environment;

        private readonly IMapper Mapper;

        public TeamsController(ITeamService teamService, IMapper mapper, IWebHostEnvironment environment)
        {
            TeamService = teamService;
            Mapper = mapper;
            Environment = environment;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable> GetAll()
        {
            return Mapper.MapList<TeamResource>(await TeamService.GetAllAsync());
        }


        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            Team team = await TeamService.GetByIdAsync(id);
            return team == null ? (IActionResult)NotFound() : Ok(Mapper.Map<TeamResource>(team));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody]CreateTeamResource team)
        {
            var result = await TeamService.CreateAsync(Mapper.Map<Team>(team));
            return result.Succes ? Created("GetById", Mapper.Map<TeamResource>(result.Entity)) : (IActionResult)Conflict(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]UpdateTeamResource team, int id)
        {
            var result = await TeamService.UpdateAsync(Mapper.Map<Team>(team), id);
            result.Message = "test";
            return result.Succes ? Ok(Mapper.Map<TeamResource>(result.Entity)) : (IActionResult)Conflict(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await TeamService.RemoveAsync(id);
            return result.Succes ? Ok() : (IActionResult)Conflict(result.Message);
        }

        [HttpGet("search")]
        [AllowAnonymous]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            return Ok(await TeamService.Search(query));
        }



    }
}
