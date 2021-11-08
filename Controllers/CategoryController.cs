using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCoreMVC.Data;
using MyCoreMVC.Models;
using MyCoreMVC.DTOs;
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
        
        [HttpGet]
       public async Task<ActionResult<IEnumerable<Category>>> Index(string searchString)
        {
            var categories = from m in _context.Category select m;
            if(!String.IsNullOrEmpty(searchString))
            {
                categories = categories.Where(s => s.Name.Contains(searchString));
            }
            // var cat = await _context.Category.ToListAsync();
            
            return View(await categories.ToListAsync());
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            var categories = from m in _context.Category select m;
            if(!String.IsNullOrEmpty(searchString))
            {
                categories = categories.Where(s => s.Name.Contains(searchString));
            }
            
            return "From [HttpPost]Index: Filter on " + searchString; 
            // return await categories.ToListAsync();
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
            // if (ModelState.IsValid)
            // {
            //     await _context.Category.AddAsync(obj);
            //     await _context.SaveChangesAsync();
            //     return RedirectToAction("Index");
            // }

            if (await CategoryExist(obj.Name)) return BadRequest("CategoryName was already exist!"); // We can use PartialView Return or a Bad Request

            while(ModelState.IsValid)
            {
                await _context.Category.AddAsync(obj);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        // GET - EDIT
        public async Task<ActionResult<IEnumerable<CategorDtos>>> Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var category = await _context.Category.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null) return NotFound();


            // var cat = await _context.Category.AnyAsync(x => x.Id == id);
            var categoryDto = new CategorDtos{
                Id = category.Id,
                Name = category.Name,
                DisplayOrder = category.DisplayOrder
            };

             return View(categoryDto);

        }


        // POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            while (ModelState.IsValid)
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

        private async Task<bool> CategoryExist(string categoryName)
        {
            return await _context.Category.AnyAsync(x => x.Name == categoryName);
        }
    }
}
