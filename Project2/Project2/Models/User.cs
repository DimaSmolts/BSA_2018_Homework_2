using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class User
    {
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public string Name { get; set; }
		public string Avatar { get; set; }
		public List<Post> PostList = new List<Post>();
		public List<Todo> TodoList = new List<Todo>();
		public Address Address { get; set; }
	}
}
