using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyCoreMVC.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BreweryApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBrewery()
        {
            Console.WriteLine($"Text");
            
            return Ok("Test");
        }
    }
}