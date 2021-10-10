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
            var application_type = await _context.ApplicationType.ToListAsync();
             
            return View(application_type);
        }

        public IActionResult Create()
        {

            return View();

        }
        //POST - CREATE 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ApplicationType application_type)
        {
            await _context.ApplicationType.AddAsync(application_type);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        
    }
}
