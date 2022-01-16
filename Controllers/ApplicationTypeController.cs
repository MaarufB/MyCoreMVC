using Microsoft.AspNetCore.Mvc;
using MyCoreMVC.Data;
using MyCoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCoreMVC.IRepository;

namespace MyCoreMVC.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly IApplicationTypeRepository _repository;
        private readonly ApplicationDbContext _context;
        public ApplicationTypeController(ApplicationDbContext context, IApplicationTypeRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public async Task<ActionResult<IEnumerable<ApplicationType>>> Index()
        {
            //var app_type = await _context.ApplicationType.ToListAsync();
            var applicationTypeObj = await _repository.GetAllAsync();

            return View(applicationTypeObj);
        }

        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST - INSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicationType app_obj)
        {
            if (ModelState.IsValid)
            {
                await _context.ApplicationType.AddAsync(app_obj);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(app_obj);

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
                    //await _context.ApplicationType.AddAsync(obj);
                    await _repository.AddAsync(obj);
                }
                else
                {
                     //_context.ApplicationType.Update(obj);
                    await _repository.Update(obj);
                }

                //await _context.SaveChangesAsync();
                await _repository.SaveChangesAsync();
                
                return RedirectToAction("Index");
            }

            return View(obj);
        }


        // GET - EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var app_type_obj = await _context.ApplicationType.FindAsync(id);
            if (app_type_obj == null) return NotFound();

            return View(app_type_obj);

        }

        // POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ApplicationType app_type_obj)
        {

            if (ModelState.IsValid)
            {
                _context.ApplicationType.Update(app_type_obj);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(app_type_obj);

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
    }
}
