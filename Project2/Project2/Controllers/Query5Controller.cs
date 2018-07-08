using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Project2.Controllers
{
    public class Query5Controller : Controller
    {
        public IActionResult Index()
        {
            return View(null);
        }

		[HttpPost]
		public IActionResult Index(int id)
		{
			Models.UserInfo userInfo = new Models.UserInfo();
			if(id>0 && id <= MyDB.Users.Count)
			{
				var selectedUser = (from u in MyDB.Users
									where u.Id == id
									select u).First();
				userInfo.User = selectedUser;
				if (selectedUser.PostList.Count != 0)
				{
					var lastPost = (from p in selectedUser.PostList.OrderByDescending(d => d.CreatedAt)
									select p).First();
					userInfo.LastPost = lastPost;

					var lastPostComments = lastPost.CommentList.Count;
					userInfo.LastPostComments = lastPostComments;

					var mostCommentsPost = (from p in selectedUser.PostList
											select p)
											.Aggregate((i1, i2) => i1.CommentList.Count(x => x.Body.Length > 80) > i2.CommentList.Count(x => x.Body.Length > 80) ? i1 : i2);
					userInfo.MostCommentsPost = mostCommentsPost;

					var mostLikesPost = (from p in selectedUser.PostList
										 select p)
									 .Aggregate((i1, i2) => i1.Likes > i2.Likes ? i1 : i2);
					userInfo.MostLikesPost = mostLikesPost;

				}

				var todos = (from u in MyDB.Users
							 where u.Id == id
							 select u.TodoList).First();
				var notComletedtodo = (from t in todos
									   where t.IsComplete == false
									   select t).Count();
				userInfo.NotCompleteddTodo = notComletedtodo;
			}
			return View(userInfo);
		}
	}
}