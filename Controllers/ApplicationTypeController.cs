using Microsoft.AspNetCore.Mvc;
using MyCoreMVC.Data;
using MyCoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyCoreMVC.Controllers
{
    public class ApplicationTypeController : Controller
    {

        private readonly ApplicationDbContext _context;
        public ApplicationTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<ApplicationType>>> Index()
        {
            var app_type = await _context.ApplicationType.ToListAsync();

            return View(app_type);
        }

        
        public async Task<IActionResult> Upsert(int? id)
        {
            var applicationType = new ApplicationType();
            if (id == null || id == 0)
            {
                return View(applicationType);
            }
            else
            {
                applicationType = await _context.ApplicationType.FindAsync(id);
                return View(applicationType);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                if(obj.Id == 0)
                {
                    await _context.ApplicationType.AddAsync(obj);
                }
                else
                {
                     _context.ApplicationType.Update(obj);
                }
                
                await _context.SaveChangesAsync();
                
                return RedirectToAction("Index");
            }

            return View(obj);
        }


        // GET - DELETE
        public async Task<IActionResult> Delete(int? id)
        {
           if (id == null || id == 0) return NotFound();

           var app_type_obj = await _context.ApplicationType.FindAsync(id);
           if (app_type_obj== null) return NotFound();

           return View(app_type_obj);

        }

    
        // POST - DELETE  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {
            var app_type_obj = await _context.ApplicationType.FindAsync(id);
            if (app_type_obj == null) return NotFound();

            _context.ApplicationType.Remove(app_type_obj);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // #region API CALLS
        // [HttpDelete]
        // [Produces("application/json")]
        // public async Task<IActionResult> Delete(int? id)
        // {
        //     if (id == null) return BadRequest();

        //     var obj = await _context.ApplicationType.FindAsync(id);

        //     if (obj == null) return Json(new { success = false, message = "Error while deleting!" });

        //     return Json(new { success = true, message = "Application Type successfully deleted!" });
        // }


        // #endregion
    }
}
