using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreTodo.Services;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoItemService _todoItemService;

        public TodoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }
        public async Task<IActionResult> Index()
        {
            //get to-do tiems from database
            var items = await _todoItemService.GetIncompleteItemsAsync();


            //put items into a model
            var model = new TodoViewModel()
            {
                Items = items
            };

            return View(model);

            //render view using the model
        }
    }
}