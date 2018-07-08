using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class PostInfo
    {
		public Post Post { get; set; }
		public Comment LongComment { get; set; }
		public Comment LikedComment { get; set; }
		public int SpecialComment { get; set; }
	}
}
