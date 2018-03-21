using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using RssLibrary.Models;

namespace RssLibrary
{
    public static class Tools
    {
        public static List<RssModel> RssItemsList { get; set; }

        public static IEnumerable<IEnumerable<T>> Split<T>(IEnumerable<T> rssItemsList, int columns)
        {
            for (var i = 0; i < (double)rssItemsList.Count() / columns; i++)
            {
                yield return rssItemsList.Skip(i * columns).Take(columns);
            }
        }

        public static void LoadRssItemsList(string link)
        {
            RssItemsList = XElement
                .Load(link ?? "https://news.google.com/news/rss/?ned=pl_pl&gl=PL&hl=pl")
                .Descendants("item")
                .Select(x => new RssModel(x.Element("title")?.Value, DateTime.Parse(x.Element("pubDate")?.Value), x.Element("description")?.Value))
                .ToList();
        }

        public static List<RssModel> SearchByRssTitle(List<RssModel> list, string title)
        {
            return list.Where(x => x.Title.ToLower().Contains(title.ToLower())).ToList();
        }
    }
}