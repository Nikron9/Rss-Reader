using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.Controllers
{
    public class RssController : Controller
    {
        // GET: Rss
        private readonly IEnumerable<XElement> _rss =
            XElement.Load("https://news.google.com/news/rss/?ned=pl_pl&gl=PL&hl=pl").Descendants("item");

        public List<RssModel> RMList = new List<RssModel>();

        public IActionResult Index(int? page, int? pageSize, string titleToSearch)
        {
            foreach (var item in _rss)
                RMList.Add(new RssModel(
                    item.Element("title").Value,
                    DateTime.Parse(item.Element("pubDate").Value),
                    item.Element("description").Value));

            if (!string.IsNullOrEmpty(titleToSearch))
                RMList = RMList.Where(x => x.Title.ToLower().Contains(titleToSearch.ToLower())).ToList();

            return View(Pagination<RssModel>.Create(RMList, pageSize ?? 4, page ?? 1, titleToSearch));
        }
    }
}