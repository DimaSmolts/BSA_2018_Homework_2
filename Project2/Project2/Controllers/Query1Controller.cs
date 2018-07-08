using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Project2.Controllers
{
    public class Query1Controller : Controller
    {
        public IActionResult Index()
        {
			return View(null);
        }

		[HttpPost]
		public IActionResult Index(int id)
		{
			List<Models.Post> postList = new List<Models.Post>();
			if (id > 0 && id <= MyDB.Users.Count)
			{
				var respo = (from u in MyDB.Users
							 where u.Id == id
							 select u.PostList).First();
				if (respo.Count != 0)
					postList = respo;
			}
			return View(postList);
		}
    }
}