using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Dream.Web.Controllers
{
    public class VueUITestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       
    }
}