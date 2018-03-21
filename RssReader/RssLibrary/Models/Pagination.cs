using System;
using System.Collections.Generic;
using System.Linq;

namespace RssLibrary.Models
{
    public class Pagination
    {
        public string LinkToRss { get; set; } = "https://news.google.com/news/rss/?ned=pl_pl&gl=PL&hl=pl";
        public List<RssModel> RssItemsList { get; set; }
        public int PageSize { get; set; } = 4;
        public int PageIndex { get; set; } = 1;
        public int TotalPages { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public string TitleToSearch { get; set; }

        //public Pagination(List<RssModel> rssItemsList, int pageSize, int pageIndex, string titleToSearch, string linkToRss)
        //{
        //    RssItemsList = rssItemsList.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
        //    PageSize = pageSize;
        //    PageIndex = pageIndex;
        //    TotalPages = (int)Math.Ceiling(rssItemsList.Count / (double)pageSize);
        //    HasNextPage = pageIndex < (int)Math.Ceiling(rssItemsList.Count / (double)pageSize);
        //    HasPreviousPage = pageIndex > 1;
        //    TitleToSearch = titleToSearch;
        //    LinkToRss = linkToRss;
        //}
    }
}