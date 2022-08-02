using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListManagement.Models;

namespace ToDoListManagement.Data.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public Task AddUserAsync(UserModel User)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> FindRoleAsync(UserModel User)
        {
            var result = await _context.Users.FirstOrDefaultAsync(a => a.UserName == User.UserName);
            if (result != null && User.Password == result.Password)return result;
            else return null;
        }

        public Task<UserModel> GetUserByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> UpdateUserAsync(UserModel User)
        {
            throw new NotImplementedException();
        }
    }
}
