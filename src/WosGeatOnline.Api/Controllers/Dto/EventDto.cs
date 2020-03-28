using System;
using System.IO;

namespace WosGeatOnline.Api.Controllers
{
    public class EventDto
    {
        public Guid Id { get; set; }
        
        public string Category { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string VideoLink { get; set; }

        public string AuthorName { get; set; }

        public string AuthorImage { get; set; }

        public int WatchCount { get; set; }

        public DateTime TimestampStart { get; set; }

        public string State { get; set; }
    }
}