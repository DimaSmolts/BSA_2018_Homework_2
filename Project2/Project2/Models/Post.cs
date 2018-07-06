﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    public class Post
    {
		public int id { get; set; }
		public DateTime createdAt { get; set; }
		public string title { get; set; }
		public string body { get; set; }
		public int userId { get; set; }
		public int likes { get; set; }
		public List<Comment> CommentList = new List<Comment>();
	}
}