using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RssLibrary;
using RssLibrary.Models;

namespace AspNetCore.Controllers
{
    public class RssController : Controller
    {
        public IActionResult Index(Pagination model)
        {
            if (Tools.RssItemsList == null)
                Tools.LoadRssItemsList(model.LinkToRss ?? "https://news.google.com/news/rss/?ned=pl_pl&gl=PL&hl=pl");

            var rssItemsList = Tools.RssItemsList;

            if (!string.IsNullOrEmpty(model.TitleToSearch))
                rssItemsList = Tools.SearchByRssTitle(Tools.RssItemsList, model.TitleToSearch);

            return View(new Pagination
            {
                LinkToRss = model.LinkToRss,
                RssItemsList = rssItemsList.Skip((model.PageIndex - 1) * model.PageSize).Take(model.PageSize).ToList(),
                PageSize = model.PageSize,
                PageIndex = model.PageIndex,
                TotalPages = (int) Math.Ceiling(rssItemsList.Count / (double) model.PageSize),
                HasNextPage = model.PageIndex < (int) Math.Ceiling(rssItemsList.Count / (double) model.PageSize),
                HasPreviousPage = model.PageIndex > 1,
                TitleToSearch = model.TitleToSearch
            });
        }

        [HttpPost]
        public IActionResult Link(Pagination model)
        {
            Tools.LoadRssItemsList(model.LinkToRss);
            return RedirectToAction(nameof(Index), model);
        }

        [HttpPost]
        public IActionResult Paging(Pagination model)
        {
            return RedirectToAction(nameof(Index), model);
        }
    }
}