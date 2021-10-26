using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCoreMVC.Models;
using MyCoreMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace MyCoreMVC.Controllers
{
    public class TodoController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TodoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoModel>>> Index()
        {
            var my_todo = await _context.TodoList.ToListAsync();
            return View(my_todo);
        }

        // GET -  CREATE
        public IActionResult Create()
        {
            return View();
        }

        // Post - Insert
        [HttpPost]
        // TODO Add Validation [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TodoModel todo)
        {
            if (ModelState.IsValid)
            {
                await _context.TodoList.AddAsync(todo);
                await _context.SaveChangesAsync();
                
                return RedirectToAction("Index");
            }
            return View(todo);
        }


        // GET - EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var todo = await _context.TodoList.FindAsync(id);

            if (todo == null) return NotFound();

            return View(todo);
        }


        // POST - EDIT
        [HttpPost]
        //TODO TO ADD VALIDATION
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TodoModel todo)
        {   
            if (ModelState.IsValid)
            {
                _context.TodoList.Update(todo);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(todo);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var todo = await _context.TodoList.FindAsync(id);
            if (todo == null) return NotFound();
            
            return View();
        }

        // POST -  DELETE
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {
            var todo = await _context.TodoList.FindAsync(id);
            if (todo == null) return NotFound();

            _context.TodoList.Remove(todo);

            return RedirectToAction("Index");
        }


    }
}
