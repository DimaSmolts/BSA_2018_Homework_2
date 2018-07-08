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
			Models.User user = null;

			if (id > 0 && id <= MyDB.Users.Count)			
				user = MyDB.Users.First(u => u.Id.Equals(id));
			
            return View(user);
        }
    }
}