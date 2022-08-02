using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListManagement.Models;

namespace ToDoListManagement.Data.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetUsersAsync();
        Task<UserModel> GetUserByIdAsync(int Id);
        Task DeleteUserByIdAsync(int Id);
        Task AddUserAsync(UserModel User);
        Task<UserModel> UpdateUserAsync(UserModel User);
        Task<UserModel> FindRoleAsync(UserModel User);
    }
}
