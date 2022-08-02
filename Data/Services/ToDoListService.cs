using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListManagement.Models;

namespace ToDoListManagement.Data.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly AppDbContext _context;
        public ToDoListService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddToDoItemAsync(ToDoListModel toDoList)
        {
            await _context.AddAsync(toDoList);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteToDoItemByIdAsync(int Id)
        {
            var footballer = await _context.ToDoList.FirstOrDefaultAsync(m => m.Id == Id);
            _context.Remove(footballer);
            await _context.SaveChangesAsync();
        }

        public async Task<ToDoListModel> GetToDoItemByIdAsync(int Id)
        {
            var footballer = await _context.ToDoList.FirstOrDefaultAsync(m => m.Id == Id);
            return footballer;
        }

        public async Task<IEnumerable<ToDoListModel>> GetToDoItemsAsync()
        {
            var toDoItems = await _context.ToDoList.ToListAsync();
            return toDoItems;
        }

        public async Task<ToDoListModel> UpdateToDoItemAsync(ToDoListModel toDoList)
        {
            _context.Update(toDoList);
            await _context.SaveChangesAsync();
            return toDoList;
        }
    }
}
