using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class Todo
    {
		public int id { get; set; }
		public DateTime createdAt { get; set; }
		public string name { get; set; }
		public bool isComplete { get; set; }
		public int userId { get; set; }
	}
}
