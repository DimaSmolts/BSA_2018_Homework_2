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
			Models.Post post = null;
			if (id > 0)
			{				
				var BigList = from u in MyDB.Users
							  where u.PostList.Count != 0
							  select u.PostList;

				List<Models.Post> temp = new List<Models.Post>();

				foreach (List<Models.Post> lp in BigList.ToList())
					temp.AddRange(lp);						

				if (temp.Count >= id)				
					post = (from p in temp
							select p).First(p => p.Id.Equals(id));
							
			}
			return View(post);
        }
    }
}