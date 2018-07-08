using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Project2.Controllers
{
    public class TodoController : Controller
    {
        public IActionResult Index(int id)
        {
			Models.Todo todo = null;
			if (id > 0)
			{
				var BigList = from u in MyDB.Users
							  where u.TodoList.Count != 0
							  select u.TodoList;

				List<Models.Todo> temp = new List<Models.Todo>();

				foreach (List<Models.Todo> lp in BigList.ToList())
					temp.AddRange(lp);

				if (temp.Count >= id)				
					todo = (from t in temp
							select t).First(t => t.Id.Equals(id));
				
			}
			return View(todo);
        }
    }
}