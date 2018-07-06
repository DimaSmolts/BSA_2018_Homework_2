using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Project2
{
    public static class MyDB
    {
		public static string URL = "https://5b128555d50a5c0014ef1204.mockapi.io";

		public static readonly Lazy <List<Models.User>> lazy =
			new Lazy<List<Models.User>>(()=>new List<Models.User>());

		public static List<Models.User> Users { get { return lazy.Value; } }

		public static void SendRequest()
		{
			Users.Clear();

			var client = new HttpClient();

			var userResponse = client.GetAsync(URL + "/users").Result;
			var userJSON = userResponse.Content.ReadAsStringAsync().Result;
			List<Models.User> userList = JsonConvert.DeserializeObject<List<Models.User>>(userJSON);

			var postResponse = client.GetAsync(URL + "/posts").Result;
			var postJSON = postResponse.Content.ReadAsStringAsync().Result;
			List<Models.Post> postList0 = JsonConvert.DeserializeObject<List<Models.Post>>(postJSON);

			var commentResponse = client.GetAsync(URL + "/comments").Result;
			var commentJSON = commentResponse.Content.ReadAsStringAsync().Result;
			List<Models.Comment> commentList = JsonConvert.DeserializeObject<List<Models.Comment>>(commentJSON);

			var todoResponse = client.GetAsync(URL + "/todos").Result;
			var todoJSON = todoResponse.Content.ReadAsStringAsync().Result;
			List<Models.Todo> todoList = JsonConvert.DeserializeObject<List<Models.Todo>>(todoJSON);

			var addressResponse = client.GetAsync(URL + "/address").Result;
			var addressJSON = addressResponse.Content.ReadAsStringAsync().Result;
			List<Models.Address> addressList = JsonConvert.DeserializeObject<List<Models.Address>>(addressJSON);


			var postList = (from post in postList0
							join comment in commentList on post.Id equals comment.UserId into comments
							select new Models.Post
							{
								Id = post.Id,
								CreatedAt = post.CreatedAt,
								Title = post.Title,
								Body = post.Body,
								UserId = post.UserId,
								Likes = post.Likes,
								CommentList = comments.ToList()
							}).ToList();
			Users.AddRange
				(
					(from user in userList
					 join post in postList on user.Id equals post.UserId into postsJoin
					 join todo in todoList on user.Id equals todo.UserId into todosJoin
					 join address in addressList on user.Id equals address.UserId into addressJoin
					 select new Models.User
					 {
						 Address = addressJoin.FirstOrDefault(),
						 Avatar = user.Avatar,
						 CreatedAt = user.CreatedAt,
						 Id = user.Id,
						 Name = user.Name,
						 PostList = postsJoin.ToList(),
						 TodoList = todosJoin.ToList()
					 }).ToList()
				);
		}

		//static MyDB()
		//{
		//	SendRequest();
		//}
	}
}
