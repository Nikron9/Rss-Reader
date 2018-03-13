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

        public string TtleToSearch { get; set; }

        public IActionResult Index(int? page, int? pageSize, string titleToSearch)
        {
            TtleToSearch = titleToSearch;
            ViewBag.titleToSearch = titleToSearch;
            ViewBag.pageSize = pageSize;
            foreach (var item in _rss)
                RMList.Add(new RssModel(
                    item.Element("title").Value,
                    item.Element("category").Value,
                    DateTime.Parse(item.Element("pubDate").Value),
                    item.Element("description").Value));
            if (!string.IsNullOrEmpty(titleToSearch))
                RMList = RMList.Where(x => x.Title.Contains(titleToSearch)).ToList();

            return View(Pagination<RssModel>.Create(RMList.AsQueryable(), page ?? 1, pageSize ?? 4));
        }
    }
}