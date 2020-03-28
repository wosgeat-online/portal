using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace WosGeatOnline.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly ILogger<EventController> _logger;

        public EventController(ILogger<EventController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/events")]
        public EventListDto Get([FromQuery(Name = "category")] string category)
        {
            var events = JsonConvert.DeserializeObject<IEnumerable<EventDto>>(System.IO.File.ReadAllText("resources/events.json"));
            if (!string.IsNullOrEmpty(category))
            {
                events = events.Where(e => e.Category == category);
            }   

            var list = new EventListDto()
            {
                Events = events
            };
            return list;
        }

        [HttpGet("/event/{guid}")]
        public EventDto Get(Guid guid)
        {
            return JsonConvert.DeserializeObject<IEnumerable<EventDto>>(System.IO.File.ReadAllText("resources/events.json")).First( e => e.Id == guid);
        }
    }
}
