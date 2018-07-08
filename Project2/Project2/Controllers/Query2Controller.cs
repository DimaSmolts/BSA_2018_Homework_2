using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Project2.Controllers
{
    public class Query2Controller : Controller
    {
		public IActionResult Index()
		{
			return View(null);
		}

		[HttpPost]
		public IActionResult Index(int id)
		{
			List<Models.Comment> commentList = new List<Models.Comment>();
			if (id > 0 && id <= MyDB.Users.Count)
			{
				var selectedPostList = (from u in MyDB.Users
										where u.Id == id
										select u.PostList).First();
				if (selectedPostList.Count() != 0)
				{
					var selectedCommentLists = (from p in selectedPostList
												select p.CommentList).First();

					if (selectedCommentLists.Count() != 0)
					{
						var selectedComments = from c in selectedCommentLists
											   where c.Body.Length < 50
											   select c;
						if (selectedComments.Count() != 0)
						{
							foreach (Models.Comment com in selectedComments)
								commentList.Add(com);
						}
					}
				}
			}
			return View(commentList);
		}
	}
}