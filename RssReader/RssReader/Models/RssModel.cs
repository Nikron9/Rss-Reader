using System;

namespace RssReader.Models
{
    public class RssModel
    {
        public RssModel(string title, string category, DateTime date, string description)
        {
            Title = title;
            Category = category;
            Date = date;
            Description = description;
        }

        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}