using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListManagement.Data.Services;
using ToDoListManagement.Models;

namespace ToDoListManagement.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly IToDoListService _service;
        public ToDoListController(IToDoListService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetToDoItemsAsync();
            return View(data);
        }
        //Create/ToDoItem/1
        [Authorize(Policy = "Admin")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title", "isChecked")] ToDoListModel toDoItem)
        {
            await _service.AddToDoItemAsync(toDoItem);
            return RedirectToAction(nameof(Index));
        }
        //Delete/ToDoItem/1
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete(int Id)
        {
            var data = await _service.GetToDoItemByIdAsync(Id);
            return View(data);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            await _service.DeleteToDoItemByIdAsync(Id);
            return RedirectToAction(nameof(Index));
        }
        //Edit/ToDoItem/1
        public async Task<IActionResult> Edit(int Id)
        {
            var data = await _service.GetToDoItemByIdAsync(Id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id", "Title", "isChecked")] ToDoListModel toDoItem)
        {
            if (!ModelState.IsValid)
            {
                return View(toDoItem);
            }
            await _service.UpdateToDoItemAsync(toDoItem);
            return RedirectToAction(nameof(Index));
        }
    }
}
