using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NewsAggregatorBackend.Models.Entities
{
	[Serializable]
	public class NewsSource
	{
		public NewsSource() { }

		public NewsSource(string source, string feedUrl, string title, string link, string author, string pubDate, Dictionary<string, (string? AttrString, Regex? AttrRegex)> urlToImage)
		{
			Source = source;
			FeedUrl = feedUrl;
			Title = title;
			Link = link;
			Author = author;
			PubDate = pubDate;
			UrlToImage = urlToImage;
		}

		public string? Source { get; set; }
		public string? FeedUrl { get; set; }
		public string? Title { get; set; }
		public string? Link { get; set; }
		public string? Author { get; set; }
		public string? PubDate { get; set; }
		public Dictionary<string, (string? AttrString, Regex? AttrRegex)>? UrlToImage { get; set; }
	}
}
