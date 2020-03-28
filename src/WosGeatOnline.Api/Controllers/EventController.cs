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
        public EventListDto Get()
        {
            var list = new EventListDto()
            {
                Events = JsonConvert.DeserializeObject<IEnumerable<EventDto>>(System.IO.File.ReadAllText("resources/events.json"))
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
