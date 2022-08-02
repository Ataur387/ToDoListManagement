using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListManagement.Models;

namespace ToDoListManagement.Data.Services
{
    public interface IToDoListService
    {
        Task<IEnumerable<ToDoListModel>> GetToDoItemsAsync();
        Task<ToDoListModel> GetToDoItemByIdAsync(int Id);
        Task DeleteToDoItemByIdAsync(int Id);
        Task AddToDoItemAsync(ToDoListModel toDoList);
        Task<ToDoListModel> UpdateToDoItemAsync(ToDoListModel toDoList);
    }
}
