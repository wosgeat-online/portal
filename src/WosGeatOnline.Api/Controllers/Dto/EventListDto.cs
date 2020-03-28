using System;
using System.Collections.Generic;
using System.IO;

namespace WosGeatOnline.Api.Controllers
{
    public class EventListDto
    {
        public IEnumerable<EventDto> Events { get; set; }
    }
}