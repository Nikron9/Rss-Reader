using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCore.Models
{
    public class Pagination<T>
    {
        public List<T> RMList { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public string TitleToSearch { get; set; }

        public static Pagination<T> Create(List<T> rmList, int pageSize, int pageIndex, string titleToSearch)
        {
            return new Pagination<T>
            {
                RMList = rmList.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(),
                PageSize = pageSize,
                PageIndex = pageIndex,
                TotalPages = (int) Math.Ceiling(rmList.Count / (double) pageSize),
                HasNextPage = pageIndex < (int) Math.Ceiling(rmList.Count / (double) pageSize),
                HasPreviousPage = pageIndex > 1,
                TitleToSearch = titleToSearch
            };
        }
    }
}