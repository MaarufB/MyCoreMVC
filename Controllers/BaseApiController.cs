using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyCoreMVC.Controllers
{
    [ApiController]
    [Route("[controller]/[Index]/id?")]

    //controller=Home}/{action=Index}/{id?}
    public class BaseApiController : ControllerBase { }
}