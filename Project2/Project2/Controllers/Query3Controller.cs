using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Project2.Controllers
{
    public class Query3Controller : Controller
    {
		public IActionResult Index()
		{
			return View(null);
		}

		[HttpPost]
		public IActionResult Index(int id)
		{
			List<Models.Todo> tododList = new List<Models.Todo>();
			if (id > 0 && id <= MyDB.Users.Count)
			{
				var todos = (from u in MyDB.Users
							 where u.Id == id
							 select u.TodoList).First();
				if (todos.Count != 0)
				{
					var comletedtodo = from t in todos
									   where t.IsComplete == true
									   select t;
					if (comletedtodo.Count() != 0)
						foreach (var item in comletedtodo)
							tododList.Add(item);					
				}
			}
			return View(tododList);
		}
	}
}