using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Project2.Controllers
{
    public class Query4Controller : Controller
    {
        public IActionResult Index()
        {
			return View(MyDB.Users.OrderBy(user => user.Name).ToList());
        }
    }
}