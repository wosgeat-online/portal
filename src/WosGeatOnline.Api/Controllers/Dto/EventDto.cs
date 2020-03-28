using System;
using System.IO;

namespace WosGeatOnline.Api.Controllers
{
    public class EventDto
    {
        public Guid Guid { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        
        public string ImageName { private get; set; }

        public byte[] Image {
            get {
                var path = "resources/" + ImageName;
                if (!File.Exists(path))
                {
                    return null;
                }
                return File.ReadAllBytes(path);
            }
        }

        public string VideoLink { get; set; }

        public int WatchCount { get; set; }

        public DateTime TimestampStart { get; set; }

        public bool IsRunning {
            get {
                return TimestampStart <= DateTime.Now;
            }
        }
    }
}