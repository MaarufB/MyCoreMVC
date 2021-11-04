using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCoreMVC.Models;

namespace MyCoreMVC.Controllers
{
    [Route("[controller]")]
    public class PartialTestController : Controller
    {
        private readonly ILogger<PartialTestController> _logger;

        public PartialTestController()
        {

        }

        // This will be rendered for TagHelpersTest in PartialView
        public IActionResult TagHelpersTest()
        {
            Console.WriteLine("TagHelpers Was Called!");
            return View();
        }

        //  public IActionResult _Login()
        //  {
        //       return new PartialViewResult{
        //          ViewName = "_Login",
        //          ViewData = ViewData,
        //       };
        //  }

    }
}