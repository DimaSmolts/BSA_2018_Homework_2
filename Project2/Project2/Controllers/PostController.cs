using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Project2.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index(int id)
        {
			ViewData["PostId"] = id;
			return View();
        }
    }
}