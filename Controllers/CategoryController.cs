using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCoreMVC.Data;
using MyCoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreMVC.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Category>>> Index()
        {
            var cat = await _context.Category.ToListAsync();
            return View(cat);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST - INSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                await _context.Category.AddAsync(obj);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(obj);

        }


        // GET - EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var category = await _context.Category.FindAsync(id);
            if (category == null) return NotFound();

            return View(category);

        }


        // POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {

            if (ModelState.IsValid)
            {
                 _context.Category.Update(category);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(category);

        }

        // GET - DELETE
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var category = await _context.Category.FindAsync(id);
            if (category == null) return NotFound();

            return View(category);

        }


        // POST - DELETE  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null) return NotFound();

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
