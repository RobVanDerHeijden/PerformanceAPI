using Drafter.Model;
using Drafter.Model.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Drafter.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<UserResponse> CreateAsync(User user);
        Task<UserResponse> RemoveAsync(int id);
        Task<UserResponse> UpdateAsync(User user, int id);
       
        Task<IEnumerable<User>> Search(string query);
        
        Task<string> Authenticate(User user);
    }
}