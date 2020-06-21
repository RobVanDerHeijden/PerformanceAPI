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
    public class UserService : BaseService, IUserService
    {
        private readonly ITokenManager TokenManager;

        public UserService(AppDbContext context, ITokenManager tokenManager) : base(context)
        {
            TokenManager = tokenManager;
        }

        public async Task<UserResponse> CreateAsync(User user)
        {
            User existingUser = await Context.Users.FirstOrDefaultAsync(entity => entity.Email == user.Email);

            if (existingUser != null)
            {
                return new UserResponse("Email already in use.");
            }

            try
            {
                var result = await Context.Users.AddAsync(user);
                await Context.SaveChangesAsync();
                return new UserResponse(result.Entity);
            }
            catch (Exception exception)
            {
                return new UserResponse(exception.Message);
            }
        }



        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await Context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await Context.Users.FindAsync(id);
        }

        public async Task<UserResponse> RemoveAsync(int id)
        {
            User existingUser = await Context.Users.FindAsync(id);

            try
            {
                Context.Users.Remove(existingUser);
                await Context.SaveChangesAsync();
                return new UserResponse(existingUser);
            }
            catch (Exception exception)
            {
                return new UserResponse(exception.Message);
            }
        }





        public async Task<UserResponse> UpdateAsync(User user, int id)
        {
            try
            {
                User existingUser = await Context.Users.FindAsync(id);

                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;

                Context.Users.Update(existingUser);
                await Context.SaveChangesAsync();
                return new UserResponse(existingUser);
            }
            catch (Exception exception)
            {
                return new UserResponse(exception.Message);
            }
        }

        public async Task<IEnumerable<User>> Search(string query)
        {
            List<User> user = await Context.Users.AsNoTracking().ToListAsync();

            var results = user.Where(user => user.Name.Contains(query));

            return results;
        }

        public async Task<string> Authenticate(User user)
        {
            User auth = await Context.Users.Where(entity => entity.Email == user.Email & entity.Password == user.Password).FirstOrDefaultAsync();
            return TokenManager.GetToken(auth);
        }
    }
}