using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCoreMVC.Data;
using MyCoreMVC.Models;
using MyCoreMVC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NToastNotify;

namespace MyCoreMVC.Controllers
{
    
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IToastNotification _toastNotification;
        public CategoryController(ApplicationDbContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
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

        // [HttpPost]
        public async Task<IActionResult> Upsert(int? id)
        {
            var categoryObj = new Category();
            if (id== null || id == 0)  return View(categoryObj);
            
            else 
            {
                categoryObj = await _context.Category.FirstOrDefaultAsync(c => c.Id == id);
                return View(categoryObj);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Category categoryObj)
        {
            if(ModelState.IsValid)
            {
                if(categoryObj.Id == 0)
                {
                    await _context.Category.AddAsync(categoryObj);
                    _toastNotification.AddSuccessToastMessage("Category successfully Created!");
                }
                else
                {
                    _context.Category.Update(categoryObj);
                    _toastNotification.AddSuccessToastMessage("Category successfully Updated!");
                }

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(categoryObj);
        }

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
            _toastNotification.AddSuccessToastMessage("Category successfully Deleted!");
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        private async Task<bool> CategoryExist(string categoryName)
        {
            return await _context.Category.AnyAsync(x => x.Name == categoryName);
        }
    }
}
