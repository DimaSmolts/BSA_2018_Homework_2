using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Project2.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index(int id)
        {
			ViewData["UserId"] = id;
            return View();
        }
    }
}