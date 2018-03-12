using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using RssReader.Models;

namespace RssReader.Controllers
{
    public class RssController : Controller
    {
        // GET: Rss
        public ActionResult Index()
        {
            var RMList = new List<RssModel>();
            var x = XElement.Load("https://news.google.com/news/rss/?ned=pl_pl&gl=PL&hl=pl").Descendants("item");
            foreach (var item in x)
            {
                RMList.Add(new RssModel(
                    item.Element("title").Value,
                    item.Element("category").Value,
                    DateTime.Parse(item.Element("pubDate").Value),
                    item.Element("description").Value));
            }
            return View(RMList);
        }
    }
}