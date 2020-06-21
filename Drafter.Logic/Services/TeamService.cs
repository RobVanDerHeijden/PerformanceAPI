using Data.Context;
using Drafter.Model;
using Drafter.Model.Responses;
using Drafter.Interfaces.Authentication;
using Drafter.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Drafter.Logic.Services
{
    public class TeamService : BaseService, ITeamService
    {
        public TeamService(AppDbContext context) : base(context) { }

        public async Task<TeamResponse> CreateAsync(Team team)
        {
            if (await Context.Teams.FirstOrDefaultAsync(entity => entity.Name == team.Name) != null)
            {
                return new TeamResponse("Name already taken.");
            }

            try
            {
                var result = await Context.Teams.AddAsync(team);
                await Context.SaveChangesAsync();
                return new TeamResponse(result.Entity);
            }
            catch (Exception exception)
            {
                return new TeamResponse(exception.Message);
            }
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await Context.Teams.AsNoTracking().ToListAsync();
        }

        public async Task<Team> GetByIdAsync(int id)
        {
            return await Context.Teams.FindAsync(id);
        }

        public async Task<TeamResponse> RemoveAsync(int id)
        {
            Team existingTeam = await Context.Teams.FindAsync(id);

            try
            {
                Context.Teams.Remove(existingTeam);
                await Context.SaveChangesAsync();
                return new TeamResponse(existingTeam);
            }
            catch (Exception exception)
            {
                return new TeamResponse(exception.Message);
            }
        }

        public async Task<TeamResponse> UpdateAsync(Team team, int id)
        {
            Team existingTeam = await Context.Teams.FindAsync(id);

            existingTeam.Name = team.Name;
            existingTeam.Tag = team.Tag;

            try
            {
                _ = Context.Teams.Update(existingTeam);
                _ = await Context.SaveChangesAsync();

                //Context.Teams.Update(existingTeam);
                //await Context.SaveChangesAsync();
                return new TeamResponse(existingTeam);
            }
            catch (Exception exception)
            {
                return new TeamResponse(exception.Message);
            }
        }

        public async Task<IEnumerable<Team>> Search(string query)
        {
            List<Team> team = await Context.Teams.AsNoTracking().ToListAsync();

            var results = team.Where(team => team.Name.Contains(query));

            return results;
        }
    }
}