using Microsoft.AspNetCore.Mvc;
using NewsAggregatorBackend.Models;
using NewsAggregatorBackend.Models.Entities;
using System.Diagnostics;

namespace NewsAggregatorBackend.Controllers
{
	public class NewsController : Controller
	{
		[HttpGet("GetNews")]
		public List<News> GetNews()
		{
			return new List<News>();
		}

		[HttpGet("Get")]
		public News Get()
		{
  			// Dummy
			return new News(1, "Haha", "htpsre/sgasgsa/asdummyyurk", "neam pojma", new DateTime(1997, 3, 1), "Jas", "nezn");
		}
	}
}
