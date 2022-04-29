using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCoreMVC.Models;
using MyCoreMVC.DTOs;

namespace MyCoreMVC.Controllers
{
    [Route("[controller]")]
    public class PartialTestController : Controller
    {
        //private readonly ILogger<PartialTestController> _logger;

        public TagHelpersCustomModel CustomTagHelper { get; set; }

        public PartialTestController()
        {

        }

        // This will be rendered for TagHelpersTest in PartialView
        public IActionResult TagHelpersTest()
        {
            ViewData["PartialData"] = "This is the Partial Data Test";
            ViewBag.CategorDtos = new CategorDtos{
                Id = 1,
                Name = "View Bag",
                DisplayOrder = 1
            };

            CustomTagHelper = new TagHelpersCustomModel{
                Name = "Ma-aruf",
                Type = "ASP.NET CORE"
            };

            return View();

        }

    //   public IActionResult TestPartial()
    //   {
    //       return PartialView();
    //   }

    }
}