using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCoreMVC.Data;
using MyCoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MyCoreMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TodoListApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TodoListApiController(ApplicationDbContext contex)
        {
            _context = contex;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<TodoModel>>> GetItems()
        {
            var todoList = await _context.TodoList.ToListAsync();
            return todoList;
        }

        [HttpPost]
        public async Task<IActionResult> AddItems([FromBody] TodoModel todo)
        {   
            await _context.TodoList.AddAsync(todo);
            await _context.SaveChangesAsync();

            return Ok(todo);
        }

        private void GetData()
        {
                System.Console.WriteLine("Hehe");
        }


    }
}