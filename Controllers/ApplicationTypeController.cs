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
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ActionResult<IEnumerable<ApplicationType>>> Index()
        {
            var applicationUnitObj = await _unitOfWork.ApplicationTypeRepository.GetAllAsync();

            return View(applicationUnitObj);
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
                applicationType = await _unitOfWork.ApplicationTypeRepository.FindAsync(id);
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
                    await _unitOfWork.ApplicationTypeRepository.AddAsync(obj);
                }
                else
                {

                    await _unitOfWork.ApplicationTypeRepository.Update(obj);
                }


                await _unitOfWork.SaveChangeAsync();
                
                return RedirectToAction("Index");
            }

            return View(obj);
        }


        // GET - EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var app_type_obj = await _unitOfWork.ApplicationTypeRepository.FindAsync(id);
            if (app_type_obj == null) return NotFound();

            return View(app_type_obj);

        }


        // GET - DELETE
        public async Task<IActionResult> Delete(int? id)
        {
           if (id == null || id == 0) 
                return NotFound();

            var app_type_obj = await _unitOfWork.ApplicationTypeRepository.FindAsync(id);
           
            if (app_type_obj== null) 
                return NotFound();

           return View(app_type_obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {
            var app_type_obj = await   _unitOfWork.ApplicationTypeRepository.FindAsync(id);
            if (app_type_obj == null) 
                return NotFound();

            await _unitOfWork.ApplicationTypeRepository.DeleteAsync(app_type_obj);

            await _unitOfWork.SaveChangeAsync();

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
