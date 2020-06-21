using Drafter.Model;
using Drafter.Model.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Drafter.Interfaces.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAllAsync();
        Task<Team> GetByIdAsync(int id);
        Task<TeamResponse> CreateAsync(Team team);
        Task<TeamResponse> RemoveAsync(int id);
        Task<TeamResponse> UpdateAsync(Team team, int id);
       
        Task<IEnumerable<Team>> Search(string query);
        
        //Task<string> Authenticate(Team team);
    }
}