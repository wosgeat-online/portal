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

        private string _image;
        public string Image {
            get {
                return _image;
            }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }
                _image = "https://wosgeatonline-api.azurewebsites.net/images/"+value;
            }
        }

        public string VideoLink { get; set; }

        public string AuthorName { get; set; }

        private string _authorImage { get; set; }
        public string AuthorImage {
            get {
                return _authorImage;
            }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }
                _authorImage = "https://wosgeatonline-api.azurewebsites.net/images/"+value;
            } }

        public int WatchCount { get; set; }

        public DateTime TimestampStart { get; set; }

        public string State { get; set; }
    }
}