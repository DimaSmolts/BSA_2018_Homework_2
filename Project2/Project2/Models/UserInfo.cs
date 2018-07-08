using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class UserInfo
    {
		public User User { get; set; }
		public Post LastPost { get; set; }
		public Post MostCommentsPost { get; set; }
		public Post MostLikesPost { get; set; }
		public int LastPostComments { get; set; }
		public int NotCompleteddTodo { get; set; }
	}
}
