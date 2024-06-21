using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregatorBackend.Models.Entities
{
	[Serializable]
	public class News
	{
		public News() { }

		public News(uint id, string title, string url, string description, DateTime publishDate, string author, string urlToImage)
		{
			Id = id;
			Title = title;
			Url = url;
			Description = description;
			PublishDate = publishDate;
			Author = author;
			UrlToImage = urlToImage;
		}

		public News(News other)
		{
			Id = other.Id;
			Title = other.Title;
			Url = other.Url;
			Description = other.Description;
			PublishDate = other.PublishDate;
			Author = other.Author;
			UrlToImage = other.UrlToImage;
		}

		public uint? Id { get; set; }
		public string? Title { get; set; }
		public string? Url { get; set; }
		public string? Description { get; set; }
		public DateTime? PublishDate { get; set; }
		public string? Author { get; set; }
		public string? UrlToImage { get; set; }
	}
}
