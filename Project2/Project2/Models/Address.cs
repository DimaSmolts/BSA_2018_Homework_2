using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class Address
    {
		public int id { get; set; }
		public string country { get; set; }
		public string city { get; set; }
		public string street { get; set; }
		public string zip { get; set; }
		public int userId { get; set; }
	}
}
