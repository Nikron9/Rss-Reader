using System;

namespace AspNetCore.Models
{
    public class RssModel
    {
        public RssModel(string title, DateTime date, string description)
        {
            Title = title;
            Date = date;
            Description = description;
        }

        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}