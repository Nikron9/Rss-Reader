using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Xml.Linq;
using RssReader.Models;

namespace RssReader.Controllers
{
    public class RssController : Controller
    {
        // GET: Rss
        private readonly IEnumerable<XElement> _rss =
            XElement.Load("https://news.google.com/news/rss/?ned=pl_pl&gl=PL&hl=pl").Descendants("item");

        public ActionResult Index()
        {
            var RMList = new List<RssModel>();
            foreach (var item in _rss)
                RMList.Add(new RssModel(
                    item.Element("title").Value,
                    item.Element("category").Value,
                    DateTime.Parse(item.Element("pubDate").Value),
                    item.Element("description").Value));
            return View(RMList);
        }
    }
}