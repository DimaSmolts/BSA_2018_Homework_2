using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Project2.Controllers
{
    public class Query6Controller : Controller
    {
        public IActionResult Index()
        {
            return View(null);
        }

		[HttpPost]
		public IActionResult Index(int id)
		{
			Models.PostInfo PI = new Models.PostInfo();
			if (id > 0)
			{
				var BigList = from u in MyDB.Users
							  where u.PostList.Count != 0
							  select u.PostList;

				List<Models.Post> temp = new List<Models.Post>();
				foreach (List<Models.Post> lp in BigList.ToList())
					temp.AddRange(lp);

				var selectedPost = (from p in temp
									where p.Id == id
									select p).FirstOrDefault();
				PI.Post = selectedPost;

				if (selectedPost.CommentList.Count != 0)
				{
					var longComment = (from c in selectedPost.CommentList
									   select c)
									  .Aggregate((i1, i2) => i1.Body.Length > i2.Body.Length ? i1 : i2);
					PI.LongComment = longComment;

					var likedComment = (from c in selectedPost.CommentList
										select c)
										.Aggregate((i1, i2) => i1.Likes > i2.Likes ? i1 : i2);
					PI.LikedComment = likedComment;

					var specialComment = (from c in selectedPost.CommentList
										  where c.Likes == 0 || c.Body.Length < 80
										  select c).Count();
					PI.SpecialComment = specialComment;
				}
			}
			return View(PI);
		}
	}
}