using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Project2.Controllers
{
    public class SpecialQueryController : Controller
    {
        public IActionResult Index()
        {
			var BigList = from u in MyDB.Users
						  where u.PostList.Count != 0
						  select u.PostList;

			List<Models.Post> temp = new List<Models.Post>();
			foreach (List<Models.Post> lp in BigList.ToList())
				temp.AddRange(lp);

			return View(temp.OrderByDescending(p => p.CreatedAt).ToList());
        }
    }
}